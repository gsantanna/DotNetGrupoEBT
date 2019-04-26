using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.AcessoRapido
{
    [ToolboxItemAttribute(false)]
    public partial class AcessoRapido : WebPart
    {
        private string _siteDataSourceUrl = "/";
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Site de Origem dos Dados:")]
        public string SiteDataSourceUrl
        {
            get { return _siteDataSourceUrl; }
            set { _siteDataSourceUrl = value; }
        }

        private string _ListDataSource = "Acesso Rápido";
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Lista de Origem dos Dados:")]
        public string ListDataSource
        {
            get { return _ListDataSource; }
            set { _ListDataSource = value; }
        }

        private bool _showDescription = false;
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Exibir Descrição no ícone")]
        public bool ShowDescription
        {
            get { return _showDescription; }
            set { _showDescription = value; }
        }


        private static string html = @"<a href=""{url}"" title=""{title}"" {destino} class=""scrollItem {class}""><img src=""/{img}"" alt=""{title}"" />{description}</a>";

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public AcessoRapido()
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
                if (SiteDataSourceUrl == "/")
                    SiteDataSourceUrl = Page.Request.Url.Scheme + "://" + Page.Request.Url.Host + ":" + Page.Request.Url.Port;

                using (SPSite site = new SPSite(SiteDataSourceUrl))
                using (SPWeb web = site.RootWeb)
                {
                    SPList listAcessoRapido = web.Lists.TryGetList(ListDataSource);

                    if (listAcessoRapido != null)
                    {
                        SPQuery query = new SPQuery()
                        {
                            Query = @"<OrderBy><FieldRef Name='Posicao' Ascending='True' /></OrderBy>"
                        };

                        SPListItemCollection itens = listAcessoRapido.GetItems(query);

                        string output = "<ul class=\"smoothScroll\">";

                        foreach (SPListItem item in itens)
                        {
                            object url = item["URL"];

                            output += html
                                .Replace("{url}", url != null ? new SPFieldUrlValue(url.ToString()).Url : "#")
                                .Replace("{destino}", ObterDestino(item))
                                .Replace("{img}", item.Url)
                                .Replace("{class}", (string)item["Destino"] == "Fancybox" ? "fancybox" : "")
                                .Replace("{title}", item.Title)
                                .Replace("{description}", ShowDescription ? "<span>" + item.Title + "</span>" : "");
                        }

                        output += "</ul>";

                        divAcessoRapido.InnerHtml = output;
                    }
                }
            }
        }

        private static string ObterDestino(SPListItem item)
        {
            if (item["Destino"] != null)
            {
                switch (item["Destino"].ToString())
                {
                    case "Fancybox":
                        return "data-fancybox-type=\"iframe\"";
                    case "Mesma Janela":
                        return "target=\"_self\"";
                    case "Nova Janela":
                        return "target=\"_blank\"";
                }
            }

            return "";
        }
    }
}
