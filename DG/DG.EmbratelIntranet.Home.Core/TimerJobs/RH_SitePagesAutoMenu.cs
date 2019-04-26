using DG.Framework.Data.External;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DG.EmbratelIntranet.Home.Core.TimerJobs
{
    public class RH_SitePagesAutoMenu : SPJobDefinition
    {
        public const string JobName = "RH_SitPages Auto Menu Bind";

        public RH_SitePagesAutoMenu() : base() { }
        public RH_SitePagesAutoMenu(string jobName, SPService service)
            : base(jobName, service, null, SPJobLockType.None)
        {
            this.Title = JobName;
        }

        public RH_SitePagesAutoMenu(string jobName, SPWebApplication webapp)
            : base(jobName, webapp, null, SPJobLockType.ContentDatabase)
        {
            this.Title = JobName;
        }

        public override void Execute(Guid targetInstanceId)
        {
            SPWebApplication webApp = this.Parent as SPWebApplication;
            SPSite site = webApp.Sites[0];
            SPWeb web = site.RootWeb;

            
            web.Dispose();
            site.Dispose();
        }

    }
}
