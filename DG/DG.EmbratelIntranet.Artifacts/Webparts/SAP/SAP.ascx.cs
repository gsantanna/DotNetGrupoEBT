using Microsoft.SharePoint;
using System;
using System.Linq;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.SAP
{
    [ToolboxItemAttribute(false)]
    public partial class SAP : WebPart
    {
        private string _ListDataSource = "SAP";
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
        public SAP()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            SPDocumentLibrary libSAP = (SPDocumentLibrary)SPContext.Current.Web.Lists.TryGetList(ListDataSource);

            if (libSAP != null)
            {
                SPListItem docSAP = libSAP.Items.OfType<SPListItem>().FirstOrDefault();

                if (docSAP != null)
                    iframe.Attributes["src"] = new SPFieldUrlValue(docSAP["URL"].ToString()).Url;
                else
                    mtvTelas.SetActiveView(viewNoData);
            }
            else
                mtvTelas.SetActiveView(viewNoDataSource);
        }
    }
}
