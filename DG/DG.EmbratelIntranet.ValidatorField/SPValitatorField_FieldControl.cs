using System;
using System.Runtime.InteropServices;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.Security;
using System.Security.Permissions;
using System.Web;
using Microsoft.SharePoint;

namespace DG.Embratelintranet
{
    public class SPValitatorField_FieldControl : BaseFieldControl
    {
        protected TextBox txtText;
        protected CustomValidator customValidator;
        protected RegularExpressionValidator regexValidator;
        protected RequiredFieldValidator requiredValidator;

        protected override string DefaultTemplateName
        {
            [SharePointPermission(SecurityAction.LinkDemand, ObjectModel = true)]
            [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
            get { return "DG.EmbratelintranetRendering"; }
        }

        public override object Value
        {
            [SharePointPermission(SecurityAction.LinkDemand, ObjectModel = true)]
            [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
            get
            {
                EnsureChildControls();
                return txtText.Text.Trim();
            }

            [SharePointPermission(SecurityAction.LinkDemand, ObjectModel = true)]
            [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
            set
            {
                EnsureChildControls();
                txtText.Text = value.ToString();
            }
        }

        [SharePointPermission(SecurityAction.LinkDemand, ObjectModel = true)]
        [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
        public override void Focus()
        {
            txtText.Focus();
        }

        [SharePointPermission(SecurityAction.LinkDemand, ObjectModel = true)]
        [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
        protected override void CreateChildControls()
        {
            try
            {
                //verifica se o field está adicionado e é valido
                if (Field == null)
                    return;

                base.CreateChildControls();

                //verifica se está apenas no modo de display. este código só vale para edição e inclusão
                if (ControlMode == SPControlMode.Display)
                    return;

                //registra o jquery e os seus plugins necessários para esta funcionalidade
                Page.Header.Controls.Add(new Literal() { Text = "<script type=\"text/javascript\" src=\"/SiteAssets/jquery.min.js\"></script>" });
                Page.Header.Controls.Add(new Literal() { Text = "<script type=\"text/javascript\" src=\"/SiteAssets/jquery.validate.js\"></script>" });
                Page.Header.Controls.Add(new Literal() { Text = "<script type=\"text/javascript\" src=\"/SiteAssets/jquery.maskedinput.min.js\"></script>" });

                //obtém os controles do aspx
                txtText = (TextBox)TemplateContainer.FindControl("txtText");
                customValidator = (CustomValidator)TemplateContainer.FindControl("customValidator");
                regexValidator = (RegularExpressionValidator)TemplateContainer.FindControl("regexValidator");
                requiredValidator = (RequiredFieldValidator)TemplateContainer.FindControl("requiredValidator");

                //configura as propriedades do textbox no formulario
                txtText.TabIndex = TabIndex;
                txtText.CssClass = CssClass;
                txtText.ToolTip = Field.Title;

                RegisterClientScripts();

                //verifica o modo de validação
                #region Validação
                switch (Field.GetCustomProperty("ddlTipo").ToString())
                {
                    case "Email":
                        SetRegexValidator(@"\b[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b");
                        break;

                    case "CPF":
                        SetValidateFunction("validaCPF");
                        break;

                    case "CNPJ":
                        SetValidateFunction("validaCNPJ");
                        break;

                    case "Telefone":
                        break;

                    case "Personalizar...":
                        string option = Field.GetCustomProperty("rblOption").ToString();
                        string logic = Field.GetCustomProperty("txtValidationLogic").ToString();

                        //verifica a opção de validação
                        if (option == "Regex")
                        {
                            SetRegexValidator(logic);
                        }
                        else if (option == "Função de código JavaScript")
                        {
                            //pega o nome da função
                            int iIndex = logic.IndexOf(' ');
                            int fIndex = logic.IndexOf('(');
                            string functionName = logic.Substring(iIndex, fIndex).Trim();

                            //registra a função na página
                            Page.ClientScript.RegisterClientScriptBlock(typeof(string), "functionScript", logic, true);

                            //especifica a o nome da função de validação
                            SetValidateFunction(functionName);
                        }
                        break;

                    default:
                        throw new Exception("Tipo inválido de validação.");
                }
                #endregion

                //verifica o tipo de máscara do textbox
                #region Máscaras
                switch (Field.GetCustomProperty("ddlMascara").ToString())
                {
                    case "CPF | 999.999.999-99":
                        SetMask("999.999.999-99");
                        break;

                    case "CNPJ | 99.999.999/9999-99":
                        SetMask("99.999.999/9999-99");
                        break;

                    case "Telefone | (99) 9999-9999":
                        SetMask("(99) 9999-9999");
                        break;

                    case "Data | 99/99/9999":
                        SetMask("99/99/9999");
                        break;

                    case "CEP | 99.999-999":
                        SetMask("99.999-999");
                        break;

                    case "Nenhuma":
                        break;

                    case "Personalizar...":
                        //obtem a máscara personalizada na configuração do field
                        string mask = Field.GetCustomProperty("txtMascara").ToString();
                        break;

                    default:
                        throw new Exception("Tipo inválido de máscara.");
                }
                #endregion

                if (Field.Required)
                {
                    SetRequired();
                }


            } catch 
            {

            }
        }

        private void RegisterClientScripts()
        {
            if (Page.ClientScript.IsClientScriptBlockRegistered("fieldGetter"))
                Page.ClientScript.RegisterClientScriptBlock(typeof(string), "fieldGetter",
                    "function getField(attrName, attrValue){return $('input['+attrName+'=\"'+attrValue+'\"]');}", true);

            Page.ClientScript.RegisterClientScriptBlock(typeof(string), "maskScript",
                "$(document).ready(function() { $('input[mask]').each( function(i,l){ if($(this).attr('mask').length>0)$(this).mask($(this).attr('mask')); } ); });"
                , true);
        }

        void SetMask(string mask)
        {
            txtText.Attributes["mask"] = mask;
        }

        void SetValidateFunction(string function)
        {
            string validationErrorMessage = Field.GetCustomProperty("txtMessage").ToString();

            customValidator.ClientValidationFunction = function;
            customValidator.ErrorMessage = validationErrorMessage;
            customValidator.Visible = true;
        }

        void SetRegexValidator(string regex)
        {
            string validationErrorMessage = Field.GetCustomProperty("txtMessage").ToString();

            regexValidator.ValidationExpression = regex;
            regexValidator.ErrorMessage = validationErrorMessage;
            regexValidator.Visible = true;
        }

        private void SetRequired()
        {
            requiredValidator.ErrorMessage = "Este campo é de preenchimento obrigatório.";
            requiredValidator.Visible = true;
        }

    }
}
