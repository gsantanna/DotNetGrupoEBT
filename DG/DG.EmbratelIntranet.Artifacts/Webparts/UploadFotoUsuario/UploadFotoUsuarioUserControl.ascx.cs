using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using DG.Framework.Data.Adapter;
using Microsoft.SharePoint;
using System.ComponentModel;
using System.Drawing;


namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.UploadFotoUsuario
{
    public partial class UploadFotoUsuarioUserControl : UserControl
    {
        private string _siteDataSourceUrl = "/";
        [WebBrowsable(true),
        Personalizable(true),
        Category("Outros"),
        WebDisplayName("Site de Origem dos Dados:")]
        public string SiteDataSourceUrl
        {
            get { return _siteDataSourceUrl; }
            set { _siteDataSourceUrl = value; }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
        }

        List<String> ArquivosValidos = new List<String> { "image/jpeg", "image/jpg" };

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string strLogin = SPContext.Current.Web.CurrentUser.LoginName;
                
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                lblErro.Text = string.Empty;
                lblErro.ForeColor = Color.Red;


                #region PrivilegeCode

                if (Request.Files.Count == 0)
                {
                    lblErro.Text = "Favor selecionar um arquivo válido";
                    return;
                }
                var arquivo = Request.Files[0];

                //verificar se a imagem está dentro dos padrões
                if (!ArquivosValidos.Contains(arquivo.ContentType))
                {
                    lblErro.Text = "Tipo de arquivo inválido! Favor selecionar uma imagem JPG válida.";
                    return;
                }


                //verifica o tamanho da foto 
                if (arquivo.ContentLength > (1024 * 50))
                {
                    lblErro.Text = "O arquivo não pode ser maior que 50KB, tente novamente com um arquivo menor";
                    return;
                }

                Stream srArq = arquivo.InputStream;
                srArq.Position = 0;
                byte[] bArq = new byte[srArq.Length];
                srArq.Read(bArq, 0, arquivo.ContentLength);

                //Carregar matricula do usuário 
                if (SiteDataSourceUrl == "/")
                    SiteDataSourceUrl = Page.Request.Url.Scheme + "://" + Page.Request.Url.Host + ":" + Page.Request.Url.Port;



                SPList listaPessoas = SPContext.Current.Web.Lists.TryGetList("Pessoas");
                SPQuery objQuery = new SPQuery { Query="<Where><Contains><FieldRef Name='USERNAME' /><Value Type='Text'>" + strLogin+ "</Value></Contains></Where>" };


                var eu = listaPessoas.GetItems(objQuery);
                if (eu == null || eu.Count == 0)
                {
                    lblErro.Text = "Usuário não encontrado, não foi possível salvar a imagem";
                    return;
                }

               

                    using (SPSite site = new SPSite(SiteDataSourceUrl))
                    {
                        using (SPWeb web = site.RootWeb)
                        {
                            SPList listaFotos = web.Lists.TryGetList("Fotos");
                            var matricula = (String)eu[0]["Matrícula"];
                            //Adiciona o novo arquivo.
                            string strDestino = string.Format("/Fotos/{0}.JPG", matricula);
                            web.Files.Add(strDestino, bArq, true);

                            lblErro.Text = "Imagem atualizada com sucesso!";
                            lblErro.ForeColor = Color.Green;

                        }
                    }

                });//delegate

                #endregion 


            }
            catch
            {
                lblErro.Text = "Erro ao gravar a foto do usuário";
            }

        }




























    }
}
