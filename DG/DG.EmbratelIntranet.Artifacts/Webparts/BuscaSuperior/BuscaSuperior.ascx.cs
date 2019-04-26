using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.BuscaSuperior
{
    [ToolboxItemAttribute(false)]
    public partial class BuscaSuperior : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public BuscaSuperior()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imbSubmit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (rblTiposBusca.SelectedItem.Value == "pessoa")
            {

                var pessoas = txtTexto.Text.Split(' ');
                string strQs = "";
                for (int i = 0; i < pessoas.Length; i++)
                {
                    strQs += "pessoa_" + i.ToString() + "=" + pessoas[i] + "&";

                }

                Page.Response.Redirect("/Lists/Pessoas/Busca.aspx?" + strQs);
            }
            else
                Page.Response.Redirect(string.Format("{0}/_layouts/15/osssearchresults.aspx?u={1}&k={2}", SPContext.Current.Site.Url, HttpUtility.UrlEncode(SPContext.Current.Site.Url), HttpUtility.UrlEncode(txtTexto.Text)));
        }
    }
}

