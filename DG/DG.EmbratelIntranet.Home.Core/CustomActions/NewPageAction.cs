using DG.Framework.Data.Abstraction;
using DG.Framework.Data.Adapter;
using DG.Framework.Domain;
using DG.Framework.Strategy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace DG.Framework.Home.Core.CustomActions
{
    public class NewPageAction : IExecutable
    {
        public void Execute(System.Web.UI.Page page, Microsoft.SharePoint.SPContext context)
        {
            string urlParent = page.Request.UrlReferrer.AbsolutePath.ToLower();
            string pageCreationUrl = context.Site.MakeFullUrl(string.Format("/_layouts/15/spcf.aspx?List={0}&RootFolder=%2FSitePages&ContentTypeId=0x0101090100B376979C3565E2489CF19B4387E89143"
                , HttpUtility.UrlEncode(context.Web.Lists.EnsureSitePagesLibrary().ID.ToString("B"))));

            MemoryPersisted.Set("NewPageActionReferrer", urlParent);
            MemoryPersisted.Set("SecaoMenu", page.Request.QueryString["Secao"]);

            page.Response.Redirect(pageCreationUrl);
        }
    }
}
