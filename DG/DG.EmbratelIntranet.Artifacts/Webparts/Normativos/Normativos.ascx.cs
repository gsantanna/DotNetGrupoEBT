using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using Microsoft.SharePoint.Linq;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.Normativos
{
    [ToolboxItemAttribute(false)]
    public partial class Normativos : WebPart
    {
        private string _ListDataSource;
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Lista de Origem dos Dados:")]
        public string ListDataSource
        {
            get { return _ListDataSource; }
            set { _ListDataSource = value; }
        }

        private static string html = @"
            <div>
                <a href=""/{url}"">
                    <span>{title}</span>
                    <p>{name}</p>
                    <span class=""data"">{date}</span>
                </a>
            </div>";

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Normativos()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (SPSite site = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb web = site.RootWeb)
                    {
                        SPDocumentLibrary libNormativos = (SPDocumentLibrary)web.Lists.TryGetList(ListDataSource);

                        if (libNormativos != null)
                        {
                            SPListItemCollection normativos = libNormativos.Items;

                            string output = String.Empty;

                            if (normativos.Count > 0)
                            {
                                foreach (SPListItem normativo in normativos)
                                {
                                    output += html
                                        .Replace("{url}", normativo.Url)
                                        .Replace("{name}", normativo.Name)
                                        .Replace("{title}", normativo.Title)
                                        .Replace("{date}", Convert.ToDateTime(normativo["Modified"].ToString()).ToShortDateString());
                                }
                            }
                            else
                                output = "Não existem documentos cadastrados na Biblioteca Instrumentos Normativos.";

                            divNormativos.InnerHtml = output;
                        }
                        else
                            pnlNoListDataSource.Visible = true;
                    }
                }
            }
        }
    }
}
