using DG.Framework.Data.Adapter;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls.WebParts;

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.Aniversariantes
{
    [ToolboxItemAttribute(false)]
    public partial class Aniversariantes : WebPart
    {
        [WebBrowsable(true), Personalizable(true), WebDisplayName("Resumo"), Category("Outros")]
        public bool Resumo { get; set; }

        string _ViewTitle = "Resumo Aniversariantes";

        [WebBrowsable(true), Personalizable(true), WebDisplayName("Título da View de resultados"), Category("Outros")]
        public string ViewTitle
        {
            get { return _ViewTitle; }
            set { _ViewTitle = value; }
        }

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Aniversariantes()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Resumo && !Page.IsPostBack)
                ShowResumo();
        }

        private void ShowResumo()
        {
            try
            {
                mtvViews.SetActiveView(viewResumo);

                AniversarianteAdapter aniversarianteAdapter = new AniversarianteAdapter(SPContext.Current.Web);

                AniversarianteExclusaoAdapter aniversarianteExclusaoAdapter = new AniversarianteExclusaoAdapter(SPContext.Current.Web);


                //Todos os aniversáriantes do mês.
                IEnumerable<DG.Framework.Domain.Aniversariante> itens = aniversarianteAdapter.GetByViewTitle(ViewTitle);

                //Carrega o usuário atual.
                IEnumerable<DG.Framework.Domain.Aniversariante> Eu = aniversarianteAdapter.GetByViewTitle("Eu");

                //Carrega as exclusões
                IEnumerable<DG.Framework.Domain.AniversarianteExclusao> exclusoes = aniversarianteExclusaoAdapter.GetAll();



                //Filtra Area de lotação
                if(Eu != null && Eu.Count() > 0 )
                {
                    itens = itens.Where(f => f.AREA_LOTACAO == Eu.First().AREA_LOTACAO);
                }
                     

                //Filtra Excluidos.
                var itensSaida = from item in itens
                        where exclusoes.Where(ec => ec.USERNAME == item.USERNAME).Count() ==0 
                        select item;




                if (itensSaida.Count() > 0)
                {
                    rptItens.DataSource = itensSaida;
                    rptItens.DataBind();
                }

                if (rptItens.Items.Count == 0)
                {
                    rptItens.Visible = false;
                    mtvViews.SetActiveView(viewNoData);
                }
            }
            catch (Exception ex)
            {
                mtvViews.SetActiveView(viewNoData);
            }
        }


    }
}
