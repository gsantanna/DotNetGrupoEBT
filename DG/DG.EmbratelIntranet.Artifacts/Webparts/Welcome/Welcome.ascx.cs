using DG.Framework.Data.Adapter;
using Microsoft.SharePoint;
using System;
using System.Linq;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using DG.Framework.Domain;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.Welcome
{
    [ToolboxItemAttribute(false)]
    public partial class Welcome : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Welcome()
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
                ltrUserName.Text = "Visitante";

                try
                {
                    PessoaAdapter pessoaAdapter = new PessoaAdapter(new SPSite(Page.Request.Url.Scheme + "://" + Page.Request.Url.Host + ":" + Page.Request.Url.Port).RootWeb);
                    Pessoa pessoa = pessoaAdapter.GetByViewTitle("Eu").FirstOrDefault();

                    if (pessoa != null)
                    {
                        ltrUserImage.Text = pessoa.FOTO_HTML;

                        if (!string.IsNullOrWhiteSpace(pessoa.Nome))
                            ltrUserName.Text = pessoa.Nome;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
