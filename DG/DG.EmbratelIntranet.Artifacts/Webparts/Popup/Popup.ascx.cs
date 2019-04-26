using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.Popup
{
    [ToolboxItemAttribute(false)]
    public partial class Popup : WebPart
    {
        private string _ListDataSource = "Popup";
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Lista de Origem dos Dados:")]
        public string ListDataSource
        {
            get { return _ListDataSource; }
            set { _ListDataSource = value; }
        }

        private static string js = @"
        <script type=""text/javascript"">
            $(document).ready(function () {
                $.fancybox.open(
                    [
                        {popups}
                    ],
                    {
                                
                        beforeShow: function() {
                            var link = this.link;
                            var target = this.target;
                            
                            $('.fancybox-inner').unbind();

                            $('.fancybox-inner').mousedown(function(){

                                if ( target != '' ) 
                                {
                                    window.open(link);
                                } else 
                                {
                                    document.location.href=link ;
                                }

                            });

                         },
                        onPlayEnd: function() {
                            setTimeout(function(){$.fancybox.close();}, {bugultimaduracao});
                        },
                        autoSize: true,
                        autoPlay: true,
                        loop: false,
                        nextEffect: 'fade',
                        prevEffect: 'fade',
                        helpers: { 
                            overlay: {overlay},
                            title: null
                        },
                        padding: 0,
                        fitToView: false
                    }
                );
            });
        </script>";

        private static string popuptmpl = @"
                        {
                            href: '{href}',
                            link: '{link}',
                            target: '{target}',
                            title: '{title}',
                            playSpeed: {duracao},
                            width: {width},
                            height: {height}
                        }";

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Popup()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                if (!Page.IsPostBack)
                {
                    using (SPSite site = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb web = site.RootWeb)
                        {
                            web.AllowUnsafeUpdates = true;

                            SPList listPopup = web.Lists.TryGetList(ListDataSource);

                            if (listPopup != null)
                            {
                                var query = new SPQuery()
                                {
                                    Query = String.Format(@"
                                <Where>
                                    <And>
                                        <Leq>
                                            <FieldRef Name='DataInicio' />
                                            <Value IncludeTimeValue='TRUE' Type='DateTime'>{0}</Value>
                                        </Leq>
                                        <And>
                                            <Gt>
                                                <FieldRef Name='DataFim' />
                                                <Value IncludeTimeValue='TRUE' Type='DateTime'>{0}</Value>
                                            </Gt>
                                            <Eq>
                                                <FieldRef Name='_ModerationStatus' />
                                                <Value Type='ModStat'>0</Value>
                                            </Eq>
                                        </And>
                                    </And>
                                </Where>",
                                        SPUtility.CreateISO8601DateTimeFromSystemDateTime(DateTime.Now))
                                };

                                SPListItemCollection popups = listPopup.GetItems(query);
                                string popupJS = null;

                                int bugultimaduracao = 1000;
                                bool bugultimofundoescuro = false;

                                foreach (SPListItem popupItem in popups)
                                {

                                    // Obrigatórios
                                    string bannerUrl = GetItemAttachmentUrl(popupItem);
                                    bugultimofundoescuro = Convert.ToBoolean(popupItem["FundoEscuro"].ToString());
                                    bugultimaduracao = Convert.ToInt32(popupItem["Duracao"].ToString()) * 1000; // multiplicado por 1000 para converter em ms

                                    if (bannerUrl != String.Empty)
                                    {
                                        // Opcionais
                                        string url = "#";
                                        string destino = String.Empty;
                                        string periodo = String.Empty;

                                        if (popupItem["URL"] != null)
                                        {
                                            SPFieldUrlValue urlValue = new SPFieldUrlValue(popupItem["URL"].ToString());
                                            url = urlValue.Url;
                                        }

                                        if (popupItem["Destino"] != null)
                                            destino = popupItem["Destino"].ToString();

                                        if (popupItem["PeriodoExibicao"] != null)
                                            periodo = popupItem["PeriodoExibicao"].ToString();

                                        if (periodo == "Todos" ||
                                            periodo == "Manhã" && (DateTime.Now.Hour >= 1 && DateTime.Now.Hour < 12) ||
                                            periodo == "Tarde" && (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18) ||
                                            periodo == "Noite" && (DateTime.Now.Hour >= 18 && DateTime.Now.Hour < 1))
                                        {
                                            if (popupJS != null)
                                                popupJS += ",";

                                            popupJS += popuptmpl
                                                .Replace("{link}", url)
                                                .Replace("{target}", destino)
                                                .Replace("{title}", popupItem.Title)
                                                .Replace("{href}", bannerUrl)
                                                .Replace("{width}", Convert.ToInt32(popupItem["Largura"]).ToString())
                                                .Replace("{height}", Convert.ToInt32(popupItem["Altura"]).ToString())
                                                .Replace("{duracao}", bugultimaduracao.ToString());

                                            //AtualizaTotalExibicoes(popupItem);
                                        }
                                    }
                                }

                                string linkpopup = js
                                    .Replace("{popups}", popupJS)
                                    .Replace("{bugultimaduracao}", bugultimaduracao.ToString())
                                    .Replace("{overlay}", (bugultimofundoescuro) ? "true" : "null");

                                ltrPopupsJS.Text = linkpopup;
                            }

                            web.AllowUnsafeUpdates = false;
                        }
                    }
                }





            });

        }

        private void AtualizaTotalExibicoes(SPListItem item)
        {
            /*
            if (item["QuantidadeExibicoes"] == null)
                item["QuantidadeExibicoes"] = 1;
            else
                item["QuantidadeExibicoes"] = Convert.ToInt32(item["QuantidadeExibicoes"].ToString()) + 1;
            item.Update();

            if (item.ModerationInformation.Status == SPModerationStatusType.Pending)
            {
                item.ModerationInformation.Status = SPModerationStatusType.Approved;
                item.Update();
            }*/


        }

        private static string GetItemAttachmentUrl(SPListItem item)
        {
            if (item.Attachments.Count > 0)
            {
                string attachment = item.Attachments[0];
                SPFile file = item.ParentList.ParentWeb.GetFile(item.Attachments.UrlPrefix + attachment);
                return file.ServerRelativeUrl;
            }

            return String.Empty;
        }
    }
}
