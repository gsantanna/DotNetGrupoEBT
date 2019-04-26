using DG.Framework.Data.Adapter;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls.WebParts;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.MenuPrincipal
{
    [ToolboxItemAttribute(false)]
    public partial class MenuPrincipal : WebPart
    {
        private string _viewTitle = "Menu Superior";

        private string _outterTemplate = @"
            <nav id=""cbp-hrmenu"" class=""cbp-hrmenu"">
                <ul>
                    {menus}
                </ul>
            </nav>";

        private string _menuTemplate = @"
            <li>
			    {menu}
			    <div class=""cbp-hrsub"">
                    {boxes}
                </div>
            </li>";

        private string _menuLinkTemplate = @"
            <a href=""[Url]"" class=""[ClassedeEstiloCSS]"" [Destino]>[Title]</a>";

        private string _groupBoxTemplate = @"
            <div class=""cbp-hrsub-inner""> 
                {groups}
            </div>";

        private string _groupTemplate = @"
            <div>
                <h4 class=""[ClassedeEstiloCSS]"">[Title]</h4>
                <ul>
                    {subitems}
                </ul>
            </div>";

        private string _subitemTemplate = @"
            <li>
                {link}
                {subitems}
            </li>";

        private string _subitemLinkTemplate = @"
            <a href=""[Url]"" class=""[ClassedeEstiloCSS]"" [Destino]>[Title]</a>";

        private int _groupsPerBox = 3;

        private int _cacheTimeout = 0;

        private bool _currentSiteOnly = false;

        private bool _allSites = false;

        private string _onlyFromSiteUrl = @"/";

        private string _webUrl = @"";


        [WebBrowsable(true), Personalizable(true), WebDisplayName("Título da View que fornece os dados"), Category("Outros")]
        public string ViewTitle
        {
            get { return _viewTitle; }
            set { _viewTitle = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Template de HTML externo"), Category("Outros")]
        public string OutterTemplate
        {
            get { return _outterTemplate; }
            set { _outterTemplate = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Template de HTML dos menus"), Category("Outros")]
        public string MenuTemplate
        {
            get { return _menuTemplate; }
            set { _menuTemplate = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Template de HTML do link dos menus"), Category("Outros")]
        public string MenuLinkTemplate
        {
            get { return _menuLinkTemplate; }
            set { _menuLinkTemplate = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Template de HTML da linha dos grupos"), Category("Outros")]
        public string GroupBoxTemplate
        {
            get { return _groupBoxTemplate; }
            set { _groupBoxTemplate = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Template de HTML dos grupos"), Category("Outros")]
        public string GroupTemplate
        {
            get { return _groupTemplate; }
            set { _groupTemplate = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Template de HTML dos sublinks"), Category("Outros")]
        public string SubitemTemplate
        {
            get { return _subitemTemplate; }
            set { _subitemTemplate = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Template de HTML do link dos sublinks"), Category("Outros")]
        public string SubitemLinkTemplate
        {
            get { return _subitemLinkTemplate; }
            set { _subitemLinkTemplate = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Quantidade de grupos por linha"), Category("Outros")]
        public int GroupsPerBox
        {
            get { return _groupsPerBox; }
            set { _groupsPerBox = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Tempo em minutos para atualizar o cache (default=2)"), Category("Outros")]
        public int CacheTimeout
        {
            get { return _cacheTimeout; }
            set { _cacheTimeout = value; }
        }


        [WebBrowsable(true), Personalizable(true), WebDisplayName("Apenas site atual"), Category("Outros")]
        public bool CurrentSiteOnly
        {
            get { return _currentSiteOnly; }
            set { _currentSiteOnly = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Todos os sites"), Category("Outros")]
        public bool FromAllSites
        {
            get { return _allSites; }
            set { _allSites = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Apenas de um site específico"), Category("Outros")]
        public string OnlyFromSiteUrl
        {
            get
            {
                return _onlyFromSiteUrl;
            }
            set { _onlyFromSiteUrl = value; }
        }

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Url da web (vazio = root web)"), Category("Outros")]
        public string WebUrl
        {
            get
            {
                return _webUrl;
            }
            set { _webUrl = value; }
        }


        public MenuPrincipal()
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
                string MenuPrincipalHtml = string.Empty;

                if (CacheTimeout > 0)
                {
                    string sessionName = ViewTitle + SPContext.Current.Site.ServerRelativeUrl;

                    MenuPrincipalHtml = (string)Page.Session.GetWithTimeout(sessionName);
                    Context.Session.AddWithTimeout(sessionName, MenuPrincipalHtml, TimeSpan.FromMinutes(CacheTimeout));
                }

                if (string.IsNullOrWhiteSpace(MenuPrincipalHtml))
                    MenuPrincipalHtml = ProvisionarNavegacao(MenuPrincipalHtml);

                ltrMenus.Text = MenuPrincipalHtml;
            }
            catch { }
        }

        private string ProvisionarNavegacao(string MenuPrincipalHtml)
        {
            StringBuilder html = new StringBuilder();

            SPSecurity.CatchAccessDeniedException = false;
            if (CurrentSiteOnly)
            {
                if (SPContext.Current.Site.RootWeb.Lists.TryGetList("Menu Principal") != null)
                    html.Append(GetMenus(SPContext.Current.Site.RootWeb));
            }
            else if (FromAllSites)
                foreach (SPSite site in SPContext.Current.Site.WebApplication.Sites)
                {
                    try
                    {
                        using (SPWeb web = site.OpenWeb())
                        {
                            if (web.Lists.TryGetList("Menu Principal") != null)
                                html.Append(GetMenus(web));
                        }

                        site.Dispose();
                    }
                    catch { }
                }
            else
            {
                if (OnlyFromSiteUrl == "/")
                    OnlyFromSiteUrl = Page.Request.Url.Scheme + "://" + Page.Request.Url.Host + ":" + Page.Request.Url.Port;

                using (SPSite site = new SPSite(OnlyFromSiteUrl))
                using (SPWeb web = WebUrl != string.Empty ? site.OpenWeb(WebUrl) : site.OpenWeb())
                {
                    if (web.Lists.TryGetList("Menu Principal") != null)
                        html.Append(GetMenus(web));
                }
            }

            MenuPrincipalHtml = OutterTemplate
                .Replace("{menus}", html.ToString());

            return MenuPrincipalHtml;
        }

        private string GetMenus(SPWeb web)
        {
            StringBuilder menusHtml = new StringBuilder();

            MenuPrincipalAdapter MenuPrincipalAdapter = new MenuPrincipalAdapter(web);

            IEnumerable<Framework.Domain.MenuPrincipal> allMenus = MenuPrincipalAdapter.GetByViewTitle(ViewTitle);

            IEnumerable<IGrouping<int, Framework.Domain.MenuPrincipal>> groupedMenus = allMenus.GroupBy(menu => menu.ParentID);

            menusHtml.Append(RenderMenus(groupedMenus));

            return menusHtml.ToString();
        }

        private string RenderMenus(IEnumerable<IGrouping<int, Framework.Domain.MenuPrincipal>> groupedMenus)
        {
            StringBuilder menusHtml = new StringBuilder();

            IEnumerable<Framework.Domain.MenuPrincipal> menus = groupedMenus.FirstOrDefault(group => group.Key == 0);

            if (menus == null)
                return string.Empty;

            foreach (Framework.Domain.MenuPrincipal menu in menus)
            {
                string destino = string.Empty;

                if (menu.Destino == Core.Domain.Destino.Fancybox)
                {
                    menu.ClassedeEstiloCSS += " fancybox";
                    destino = "data-fancybox-type=\"iframe\"";
                }
                else if (menu.Destino != Core.Domain.Destino.Invalido)
                {
                    destino = string.Format("target=\"{0}\"", menu.Destino.ToString());
                }

                string menulink = MenuLinkTemplate
                    .Replace("[Title]", menu.Title)
                    .Replace("[Url]", menu.URL)
                    .Replace("[ClassedeEstiloCSS]", menu.ClassedeEstiloCSS)
                    .Replace("[Destino]", destino);

                string groupboxes = RenderBoxedGroups(groupedMenus, menu);

                menusHtml.Append(
                    MenuTemplate
                    .Replace("{menu}", menulink)
                    .Replace("{boxes}", groupboxes));
            }

            return menusHtml.ToString();
        }

        public string RenderBoxedGroups(IEnumerable<IGrouping<int, Framework.Domain.MenuPrincipal>> groupedMenus, Framework.Domain.MenuPrincipal rootMenu)
        {
            StringBuilder boxedGroupshtml = new StringBuilder();

            IGrouping<int, Framework.Domain.MenuPrincipal> groupsNode = groupedMenus.FirstOrDefault(group => group.Key == rootMenu.ID);

            if (groupsNode == null)
                return string.Empty;

            int boxCount = (int)Math.Ceiling((double)groupsNode.Count() / GroupsPerBox);

            for (int i = 0; i < boxCount; i++)
            {
                StringBuilder groupshtml = new StringBuilder();

                foreach (Framework.Domain.MenuPrincipal currentGroup in groupsNode.Skip(i * GroupsPerBox).Take(GroupsPerBox))
                {
                    string destino = string.Empty;

                    if (currentGroup.Destino == Core.Domain.Destino.Fancybox)
                    {
                        currentGroup.ClassedeEstiloCSS += " fancybox";
                        destino = "data-fancybox-type=\"iframe\"";
                    }
                    else if (currentGroup.Destino != Core.Domain.Destino.Invalido)
                    {
                        destino = string.Format("target=\"{0}\"", currentGroup.Destino.ToString());
                    }

                    IGrouping<int, Framework.Domain.MenuPrincipal> subitems = groupedMenus
                        .FirstOrDefault(group => group.Key == currentGroup.ID);

                    string subitemsHtml = RenderSubMenus(groupedMenus, subitems);

                    groupshtml.Append(
                        GroupTemplate
                        .Replace("[Title]", currentGroup.Title)
                        .Replace("[Url]", currentGroup.URL)
                        .Replace("[ClassedeEstiloCSS]", currentGroup.ClassedeEstiloCSS)
                        .Replace("[Destino]", destino)
                        .Replace("{subitems}", subitemsHtml));
                }

                boxedGroupshtml.Append(
                    GroupBoxTemplate
                    .Replace("{groups}", groupshtml.ToString()));
            }

            return boxedGroupshtml.ToString();
        }

        public string RenderSubMenus(IEnumerable<IGrouping<int, Framework.Domain.MenuPrincipal>> groupedMenus, IGrouping<int, Framework.Domain.MenuPrincipal> submenu)
        {
            StringBuilder groupshtml = new StringBuilder();

            if (submenu == null)
                return string.Empty;

            foreach (Framework.Domain.MenuPrincipal menu in submenu)
            {
                string destino = string.Empty;

                if (menu.Destino == Core.Domain.Destino.Fancybox)
                {
                    menu.ClassedeEstiloCSS += " fancybox";
                    destino = "data-fancybox-type=\"iframe\"";
                }
                else if (menu.Destino != Core.Domain.Destino.Invalido)
                {
                    destino = string.Format("target=\"{0}\"", menu.Destino.ToString());
                }

                string menulink = SubitemLinkTemplate
                    .Replace("[Title]", menu.Title)
                    .Replace("[Url]", menu.URL)
                    .Replace("[ClassedeEstiloCSS]", menu.ClassedeEstiloCSS)
                    .Replace("[Destino]", destino);

                IGrouping<int, Framework.Domain.MenuPrincipal> childs = groupedMenus.FirstOrDefault(group => group.Key == menu.ID);

                string subitemsHtml = RenderSubMenus(groupedMenus, childs);

                groupshtml.Append(
                    SubitemTemplate
                    .Replace("{link}", menulink)
                    .Replace("{subitems}", subitemsHtml));
            }

            return groupshtml.ToString();
        }
    }
}
