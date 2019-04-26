using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using System.Web.UI.WebControls;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.MeusSistemas
{
    [ToolboxItemAttribute(false)]
    public partial class MeusSistemas : WebPart
    {
        private bool _Home = true;
        [WebBrowsable(true),
        Personalizable(true),
        WebDisplayName("Home"),
        Category("Outros")]
        public bool Home
        {
            get { return _Home; }
            set { _Home = value; }
        }

        private const string LIST_MEUSSISTEMAS = "Meus Sistemas";
        private const string LIST_SISTEMASAZ = "Sistemas de A a Z";

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public MeusSistemas()
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
                if (Home)
                    ShowHome();
                else if (Page.Request.QueryString["IdSistema"] != null)
                    RemoveSistema(Convert.ToInt32(Page.Request.QueryString["IdSistema"].ToString()));
                else
                    ShowAll();
        }

        private void ShowAll()
        {
            mtvViews.SetActiveView(viewAll);

            using (IntranetData intranet = new IntranetData(SPContext.Current.Web.Url))
            {
                foreach (Sistema sistema in intranet.SistemasDeAAZ)
                {
                    ddlSistemas.Items.Add(new ListItem(new SPFieldUrlValue(sistema.URL.ToString()).Description, sistema.Id.ToString()));
                }
            }

            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    SPList listMeusSistemas = web.Lists.TryGetList(LIST_MEUSSISTEMAS);

                    if (listMeusSistemas != null)
                    {
                        var query = new SPQuery()
                        {
                            Query = @"<Where><Eq><FieldRef Name='Author' /><Value Type='User'>" + web.CurrentUser.Name + "</Value></Eq></Where>"
                        };

                        SPListItemCollection sistemas = listMeusSistemas.GetItems(query);

                        rptItens2.DataSource = sistemas.GetDataTable();
                        rptItens2.DataBind();
                    }
                }
            }
        }

        private void ShowHome()
        {
            mtvViews.SetActiveView(viewHome);

            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    SPList listMeusSistemas = web.Lists.TryGetList(LIST_MEUSSISTEMAS);

                    if (listMeusSistemas != null)
                    {
                        var query = new SPQuery()
                        {
                            Query = @"<Where><Eq><FieldRef Name='Author' /><Value Type='User'>" + web.CurrentUser.Name + "</Value></Eq></Where>"
                        };

                        SPListItemCollection sistemas = listMeusSistemas.GetItems(query);

                        rptItens.DataSource = sistemas.GetDataTable();
                        rptItens.DataBind();

                        if (rptItens.Items.Count == 0)
                        {
                            pnlNoData.Visible = true;
                            rptItens.Visible = false;
                            //verTodosMeusSistemas.Visible = false;
                        }
                    }
                }
            }
        }

        private void RemoveSistema(int id)
        {
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    web.AllowUnsafeUpdates = true;

                    SPList listMeusSistemas = web.Lists.TryGetList(LIST_MEUSSISTEMAS);

                    if (listMeusSistemas != null)
                    {
                        SPListItem sistema = listMeusSistemas.Items.GetItemById(id);

                        if (sistema != null)
                        {
                            sistema.Delete();
                            Page.Response.Redirect("/SitePages/MeusSistemas.aspx");
                        }
                    }

                    web.AllowUnsafeUpdates = false;
                }
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    SPList listMeusSistemas = web.Lists.TryGetList(LIST_MEUSSISTEMAS);

                    if (listMeusSistemas != null)
                    {
                        var query = new SPQuery()
                        {
                            Query = String.Format(@"<Where><And><Eq><FieldRef Name='Sistema' /><Value Type='Lookup'>{0}</Value></Eq><Eq><FieldRef Name='Author' /><Value Type='User'>{1}</Value></Eq></And></Where>", ddlSistemas.SelectedValue, web.CurrentUser.Name)
                        };

                        SPListItemCollection sistemas = listMeusSistemas.GetItems(query);

                        if (sistemas.Count == 0)
                        {
                            SPListItem novoSistema = listMeusSistemas.AddItem();
                            novoSistema["Sistema"] = ddlSistemas.SelectedValue;
                            novoSistema.Update();

                            Page.Response.Redirect("/SitePages/MeusSistemas.aspx");
                        }
                    }
                }
            }
        }

        public string GetSistema(object id)
        {
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    SPList listSistemasAZ = web.Lists.TryGetList(LIST_SISTEMASAZ);

                    if (listSistemasAZ != null)
                    {
                        SPListItem sistema = listSistemasAZ.Items.GetItemById(Convert.ToInt32(id));

                        if (sistema != null)
                        {
                            return sistema.Name;
                        }
                    }
                }
            }

            return string.Empty;
        }

        public string GetSistemaUrl(object id)
        {
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    SPList listSistemasAZ = web.Lists.TryGetList(LIST_SISTEMASAZ);

                    if (listSistemasAZ != null)
                    {
                        SPListItem sistema = listSistemasAZ.Items.GetItemById(Convert.ToInt32(id));

                        if (sistema != null)
                        {
                            return sistema["URL"].ToString();
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
