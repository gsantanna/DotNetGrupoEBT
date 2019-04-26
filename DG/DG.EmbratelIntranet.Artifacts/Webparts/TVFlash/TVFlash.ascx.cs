using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.TVFlash
{
    [ToolboxItemAttribute(false)]
    public partial class TVFlash : WebPart
    {
        private string _ListDataSource = "TVFlash";
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Lista de Origem dos Dados:")]
        public string ListDataSource
        {
            get { return _ListDataSource; }
            set { _ListDataSource = value; }
        }

        private string _defaultImageUrlEmptyData = "#";
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Imagem de banner vazio:")]
        public string DefaultImageUrlEmptyData
        {
            get { return _defaultImageUrlEmptyData; }
            set { _defaultImageUrlEmptyData = value; }
        }

        string cliptemplate = "{url:'{url}', linkurl:'{linkurl}', destino:'{destino}', text:'{text}', position:{Posicao}, duration:{Duracao}}";

        public string TVFlashHtml { get; set; }

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public TVFlash()
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
                SPWeb web = SPContext.Current.Site.RootWeb;
                SPDocumentLibrary library = (SPDocumentLibrary)web.Lists.TryGetList(this.ListDataSource);
                if (library != null)
                {
                    var query = new SPQuery()
                    {
                        Query = String.Format(@"
                            <OrderBy>
                                <FieldRef Name='Ordem'  Ascending='True' />
                            </OrderBy>
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

                    SPListItemCollection items = library.GetItems(query);

                    int num = 1;
                    foreach (SPListItem item in items)
                    {
                        if (this.TVFlashHtml != null)
                        {
                            this.TVFlashHtml = this.TVFlashHtml + ", ";
                        }

                        var link = string.Format("{0}",  Convert.ToString(item["Url"]).Replace("&", "{}"));


                        

                        this.TVFlashHtml += this.cliptemplate
                            .Replace("{url}", web.Site.MakeFullUrl(item.Url))
                            .Replace("{text}", num++.ToString())

                            .Replace("{linkurl}", link)

                            //.Replace("{destino}", (string)item["Destino"] ?? "")
                            .Replace("{Posicao}", double.Parse((item["Posicao"] ?? "0").ToString()).ToString())
                            .Replace("{Duracao}", double.Parse((item["Duracao"] ?? "5").ToString()).ToString());
                    }
                }
            }
        }

    }
}
