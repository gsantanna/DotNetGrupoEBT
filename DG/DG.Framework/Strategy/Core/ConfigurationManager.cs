
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DG.Framework.Strategy
{
    public static class ConfigurationManager
    {
        public const string SITE_SYSTEM_NAME = "Intranet EMBRATEL";

        private static string _Url;
        private static SPWeb __spWeb;

        public static SPWeb SystemRootElevatedWeb
        {
            get { return __spWeb ?? new SPSite(Url).OpenWeb(Url).Elevate(); }
        }

        static Dictionary<string, string> __configurations = new Dictionary<string, string>();

        public static string Url
        {
            get
            {
                if (_Url == null)
                {
                    SPWebApplication app = SPWebService.ContentService.WebApplications
                        .FirstOrDefault(a => a.Properties.ContainsKey(ConfigurationManager.SITE_SYSTEM_NAME));

                    if (app != null)
                        _Url = app.Sites[0].RootWeb.Url;
                }

                return _Url;
            }
        }

        public static string Get(string key)
        {
            if (!__configurations.ContainsKey(key))
                __configurations = GetConfigurations();

            return __configurations[key];
        }

        private static Dictionary<string, string> GetConfigurations()
        {
            Dictionary<string, string>  _obj = new ConfigurationAdapter(ConfigurationManager.SystemRootElevatedWeb)
                .GetAll()
                .ToDictionary(c => c.Title, c => c.Value);

            return _obj;
        }

    }
}

