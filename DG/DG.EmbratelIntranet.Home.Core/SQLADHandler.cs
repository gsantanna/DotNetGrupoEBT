using System;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using DG.Framework.Data.External;
using System.Web.Configuration;
using Microsoft.SharePoint.Administration;
using System.Configuration;

namespace DG.EmbratelIntranet.Home.Core
{
    public class SQLADHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //write your handler implementation here.
                context.Response.ContentType = "text/plain";


                var query = context.Request.Params["p"];

                
                
                


                var inv = new[] { "update", "delete", "create ", "alter ","drop","database" };

                foreach (var i in inv)
                {
                    if (query.ToLower().Contains(i))
                    {
                        context.Response.StatusCode = 500;
                        context.Response.StatusDescription = "Invalid Query";
                        context.Response.Write("Invalid Query");
                        context.Response.End();
                        return;
                    }
                }



                DataTable dtSaida = SQLConnector.GetDataTable(query, ConfigurationManager.AppSettings.Get("ConnectionStrPessoas"));


                context.Response.ContentType = "application/json";

                context.Response.Write(
                JsonConvert.SerializeObject(dtSaida, Formatting.Indented)
                );

                context.Response.End();


            } catch
            { 


            }



        }

        #endregion
    }
}
