using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using Microsoft.SharePoint.Linq;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint.Utilities;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.Temas
{
    [ToolboxItemAttribute(false)]
    public partial class Temas : WebPart
    {
        private string _ListDataSource = "Temas Intranet";
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Lista de Origem dos Dados:")]
        public string ListDataSource
        {
            get { return _ListDataSource; }
            set { _ListDataSource = value; }
        }

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Temas()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    SPList listTemas = web.Lists.TryGetList(ListDataSource);

                    if (listTemas != null)
                    {
                        var query = new SPQuery()
                        {
                            Query = String.Format(@"
                                <Where>
                                    <And>
                                        <Eq>
                                            <FieldRef Name='DefinirLayoutPadrao' />
                                            <Value Type='Boolean'>1</Value>
                                        </Eq>
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
                                    </And>
                                </Where>",
                            SPUtility.CreateISO8601DateTimeFromSystemDateTime(DateTime.Now)),
                            RowLimit = 1
                        };

                        SPListItemCollection temas = listTemas.GetItems(query);

                        if (temas.Count > 0)
                        {
                            string cssFile = GetItemCssAttachmentUrl(temas[0]);

                            if (cssFile != String.Empty)
                                this.Controls.Add(GetCssLink(cssFile));
                        }
                    }
                }
            }
        }

        private static HtmlLink GetCssLink(string path)
        {
            HtmlLink link = new HtmlLink();

            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("type", "text/css");
            link.Href = path;

            return link;
        }

        private static string GetItemCssAttachmentUrl(SPListItem item)
        {
            if (item.Attachments.Count > 0)
            {
                string cssFile = String.Empty;

                foreach (string attachment in item.Attachments)
                {
                    if (System.IO.Path.GetExtension(attachment) == ".css")
                    {
                        cssFile = attachment;
                        break;
                    }
                }

                if (cssFile != String.Empty)
                {
                    SPFile file = item.ParentList.ParentWeb.GetFile(item.Attachments.UrlPrefix + cssFile);
                    return file.ServerRelativeUrl;
                }
            }

            return String.Empty;
        }
    }
}
