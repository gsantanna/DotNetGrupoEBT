using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using Microsoft.SharePoint.Linq;
using System.Collections.Generic;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.Noticias
{
    [ToolboxItemAttribute(false)]
    public partial class Noticias : WebPart
    {
        private string _defaultImage = "/Style%20Library/Images/noticiadefault.png";
        [WebBrowsable(true),
        Personalizable(true),
        WebDisplayName("Url de imagem default"),
        Category("Outros")]
        public string DefaultImageUrl
        {
            get { return _defaultImage; }
            set { _defaultImage = value; }
        }

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

        private bool _ExibirLinkMais = true;
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Exibir link Mais Notícias:")]
        public bool ExibirLinkMais
        {
            get { return _ExibirLinkMais; }
            set { _ExibirLinkMais = value; }
        }

        private int _TotalNoticias = 3;
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Total de notícias exibidas:")]
        public int TotalNoticias
        {
            get { return _TotalNoticias; }
            set { _TotalNoticias = value; }
        }

        private int _NoticiasPorLinha = 9;
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Notícias por linha:")]
        public int NoticiasPorLinha
        {
            get { return _NoticiasPorLinha; }
            set { _NoticiasPorLinha = value; }
        }

        private int _IgnorarInicio = 0;
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Ignorar o início:")]
        public int IgnorarInicio
        {
            get { return _IgnorarInicio; }
            set { _IgnorarInicio = value; }
        }

        private int _DisplayTime = 5;
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Tempo de exibição dos itens do Carrossel (em segundos):")]
        public int DisplayTime
        {
            get { return _DisplayTime; }
            set { _DisplayTime = value; }
        }

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Noticias()
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
                if (!Page.IsPostBack)
                    if (Home)
                        ShowHome();
                    else if (Page.Request.QueryString["IdNoticia"] != null)
                        ShowFull();
                    else
                        ShowAll();
            } catch (Exception ex)
            {
                this.lblErro.Text = "Erro ao carregar as notícias. <!-- " + ex.Message + " -->";

            }
        }

        private void ShowAll()
        {
            mtvViews.SetActiveView(viewNoticias);

            using (IntranetData intranet = new IntranetData(SPContext.Current.Web.Url))
            {
                rptItens.DataSource = intranet.Notícias
                    .Where(n => n.DataInicio <= DateTime.Now && n.DataFim > DateTime.Now && n.Aprovado=="0")
                    .OrderByDescending(n => n.Id)
                    .ToList();
                rptItens.DataBind();

                if (rptItens.Items.Count == 0)
                    rptItens.Visible = false;
            }
        }

        private void ShowFull()
        {
            mtvViews.SetActiveView(viewNoticia);

            int idNoticia = 0;

            if (!int.TryParse(Page.Request.QueryString["IdNoticia"], out idNoticia))
                throw new ArgumentException("Query string inválida.", "IdNoticia");

            using (IntranetData intranet = new IntranetData(SPContext.Current.Web.Url))
            {
                Notícia noticia = intranet.Notícias.Where(n => n.Id == idNoticia).FirstOrDefault();

                if (noticia == null)
                    throw new Exception("Notícia não encontrada.");

                divNoticiaFull.InnerHtml = noticia.Texto.ToString();
            }
        }

        private void ShowHome()
        {
            try
            {
                mtvViews.SetActiveView(viewNoticias);
                if (ExibirLinkMais)
                    pnlTodasNoticias.Visible = true;


                //string strQuery = "<Where><And><Eq> <FieldRef Name='_ModerationStatus' />  <Value Type='Number'>0</Value> </Eq><And><Leq><FieldRef Name='DataInicio' /><Value IncludeTimeValue='TRUE' Type='DateTime'><Today/></Value></Leq><Geq><FieldRef Name='DataFim' /><Value IncludeTimeValue='TRUE' Type='DateTime'><Today/></Value></Geq></And></And></Where>";
                string strQuery = "<Where><Eq> <FieldRef Name='_ModerationStatus' />  <Value Type='Number'>0</Value> </Eq></Where>";

                SPList lista = SPContext.Current.Web.Lists["Notícias"];
                SPQuery q = new SPQuery { Query = strQuery };
                List<Object> dsTmp = new List<object>();


                List<Notícia> objTmp = new List<Notícia>();
                foreach (SPListItem item in lista.GetItems(q)) 
                {
                    objTmp.Add(new Notícia
                    {
                        Aprovado ="0",
                        Chamada = Convert.ToString(item["Chamada"]),
                        Criado = Convert.ToDateTime(item["Created"]),
                        DataFim = Convert.ToDateTime(item["DataFim"]),
                        DataInicio = Convert.ToDateTime(item["DataInicio"]),
                        Id = item.ID,
                        Title = item.Title,
                        Version = 1
                    });
                        
                }    
       
                objTmp = objTmp.Where(f=>  f.DataInicio <= DateTime.Now && f.DataFim >= DateTime.Now ).ToList();

                

                   rptItens.DataSource = objTmp                       
                        .OrderByDescending(n => n.DataInicio)
                        .Skip(IgnorarInicio)
                        .Take(NoticiasPorLinha)
                        .ToList();
                    rptItens.DataBind();

                    if (rptItens.Items.Count == 0)
                        rptItens.Visible = false;
           


            } catch (Exception ex)
            {
                this.lblErro.Text = "Erro ao carregar as notícias. <!-- " + ex.Message + " -->";

            }
        }

        public string GetAttachment(object id)
        {
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    SPList listNoticias = web.Lists.TryGetList("Notícias");

                    if (listNoticias != null)
                    {
                        SPListItem noticia = listNoticias.Items.GetItemById(Convert.ToInt32(id));

                        if (noticia != null)
                        {
                            string attachmentUrl = GetItemAttachmentUrl(noticia);

                            if (attachmentUrl != String.Empty)
                                return attachmentUrl;
                        }
                    }
                }
            }

            return DefaultImageUrl;
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
