using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls.WebParts;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.ConteudoMidia
{
    [ToolboxItemAttribute(false)]
    public partial class ConteudoMidia : WebPart
    {
        string itemhtml = "<div class=\"itensTv\"><a href=\"{url}\" title=\"{titulo}\" {destino}>{titulo}</a></div>";

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public ConteudoMidia()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SPList list = SPContext.Current.Web.Lists["Conteúdo de Mídia"];

                IntranetData intranet = new IntranetData(SPContext.Current.Web.Url);

                IEnumerable<DG.EmbratelIntranet.Home.ConteudoMidia> itensTv = intranet.ConteudoMidia.Where(t => (t.DataInicio <= DateTime.Now && t.DataFim > DateTime.Now));

                List<string> htmlElements = new List<string>();

                foreach (DG.EmbratelIntranet.Home.ConteudoMidia tv in itensTv)
                {
                    SPListItem item = list.GetItemById(tv.Id.Value);
                    
                    string url = new SPFieldUrlValue(tv.URL).Url;

                    if (item.Attachments.Count > 0)
                        url = SPUrlUtility.CombineUrl(item.Attachments.UrlPrefix, item.Attachments[0]);
                    else if (!string.IsNullOrWhiteSpace(tv.URL))
                        url = new SPFieldUrlValue(tv.URL).Url;
                    else
                        continue;

                    htmlElements.Add(itemhtml
                            .Replace("{titulo}", tv.Title)
                            .Replace("{destino}", ObterDestino(tv))
                            .Replace("{url}", url));
                }

                rptItens.DataSource = htmlElements;
                rptItens.DataBind();

                if (rptItens.Items.Count == 0)
                {
                    this.Hidden = true;
                }
            }
            catch { }
        }

        private static string ObterDestino(DG.EmbratelIntranet.Home.ConteudoMidia tv)
        {
            if (tv.Destino != null)
            {
                switch (tv.Destino)
                {
                    case Destino.Fancybox:
                        return "data-fancybox-type=\"iframe\" class=\"fancybox-media\"";
                    case Destino.MesmaJanela:
                        return "target=\"_self\"";
                    case Destino.NovaJanela:
                        return "target=\"_blank\"";
                }
            }

            return "";
        }

    }
}
