using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG
{
    internal static class WebExtensions
    {
        public static SPList FindListByName(this SPWeb web, string name)
        {
            SPList instance = null;

            if (web.Properties.ContainsKey(name))
                try
                {
                    instance = web.Lists[new Guid(web.Properties[name])];
                }
                catch
                {
                    web.AllowUnsafeUpdates = true;

                    web.Properties.Remove(name);
                    web.Properties.Update();

                    return FindListByName(web, name);
                }
            else
            {
                web.AllowUnsafeUpdates = true;

                foreach (SPList list in web.Lists)
                {
                    if (!list.Hidden)
                    {
                        web.Properties.Remove(list.RootFolder.Name);
                        web.Properties.Update();

                        web.Properties.Add(list.RootFolder.Name, list.ID.ToString("B"));
                        web.Properties.Update();
                    }
                }
            }

            return instance;
        }

        public static SPWeb Elevate(this SPWeb web)
        {
            SPWeb _Web = null;

            if (web != null)
            {
                SPUserToken token = null;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(web.Site.ID))
                        token = site.SystemAccount.UserToken;
                });

                using (SPSite site = new SPSite(web.Site.ID, token))
                    _Web = site.OpenWeb(web.ID);
            }

            return _Web;
        }
    }
}
