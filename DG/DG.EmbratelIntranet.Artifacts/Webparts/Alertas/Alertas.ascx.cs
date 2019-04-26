using Microsoft.SharePoint;
using System;
using System.Linq;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.Alertas
{
    [ToolboxItemAttribute(false)]
    public partial class Alertas : WebPart
    {
        string itemhtml = @"
            <div class=""boxAlerta boxAlertaTop"">
                <div class=""detTitulo"" style=""border-color: {cor} transparent transparent {cor};""></div>
                <div class=""boxTitulo"" style=""color: {cor}"">
                    {titulo}
                </div>
                <div class=""boxContent"">
                    <p>{texto}</p>
                    <span class=""dataAlerta"">{data}</span><br />
                    <a href=""{url}"" {destino}><img src=""/style library/images/ico-mais.png"" style=""background-color: {cor};"" /> Saiba mais</a>
                </div>
            </div>";

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Alertas()
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
                try
                {
                    IntranetData intranet = new IntranetData(SPContext.Current.Web.Url);

                    IEnumerable<Alerta> alertas = intranet.Alertas.Where(a =>
                        (a.DataInicio <= DateTime.Now && a.DataFim > DateTime.Now));

                    List<string> htmlElements = new List<string>();

                    foreach (Alerta alerta in alertas)
                    {
                        string cor = null;

                        switch (alerta.Categoria.Value)
                        {
                            case Categoria.Emergencial:
                                cor = "#d52b31";
                                break;
                            case Categoria.Atenção:
                                cor = "#f95200";
                                break;
                            case Categoria.Observação:
                                cor = "#2d820f";
                                break;
                            default:
                                break;
                        }

                        htmlElements.Add(itemhtml
                                .Replace("{titulo}", alerta.Title)
                                .Replace("{cor}", cor)
                                .Replace("{destino}", ObterDestino(alerta))
                                .Replace("{data}", alerta.DataInicio.Value.ToString("dd/MM/yy HH'h'mm"))
                                .Replace("{url}", alerta.URL)
                                .Replace("{texto}", alerta.Texto));
                    }

                    rptItens.DataSource = htmlElements;
                    rptItens.DataBind();

                    if (rptItens.Items.Count == 0)
                    {
                        this.Hidden = true;
                    }
                }
                catch { }
            }
        }

        private static string ObterDestino(Alerta alerta)
        {
            //return alerta.Destino.Value.ToString();

            if (alerta.Destino != null)
            {
                switch (alerta.Destino)
                {
                    case Destino.Fancybox:
                        return "data-fancybox-type=\"iframe\" class=\"saibaMaisAlerta fancybox\"";
                    case Destino.MesmaJanela:
                        return "class=\"saibaMaisAlerta\" target=\"_self\"";
                    case Destino.NovaJanela:
                        return "class=\"saibaMaisAlerta\" target=\"_blank\"";
                }
            }

            return "";
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.Hidden)
                base.OnPreRender(e);
        }

    }
}
