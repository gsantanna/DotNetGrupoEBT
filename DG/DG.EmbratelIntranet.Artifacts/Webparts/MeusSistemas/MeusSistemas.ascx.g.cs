﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DG.EmbratelIntranet.Home.Artifacts.Webparts.MeusSistemas {
    using System.Web.UI.WebControls.Expressions;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.Text;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.SharePoint.WebPartPages;
    using System.Web.SessionState;
    using System.Configuration;
    using Microsoft.SharePoint;
    using System.Web;
    using System.Web.DynamicData;
    using System.Web.Caching;
    using System.Web.Profile;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System;
    using Microsoft.SharePoint.Utilities;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint.WebControls;
    using System.CodeDom.Compiler;
    
    
    public partial class MeusSistemas {
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.Panel pnlNoData;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.Repeater rptItens;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.HtmlControls.HtmlAnchor verTodosMeusSistemas;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.View viewHome;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.DropDownList ddlSistemas;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.Button btnAdicionar;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.Repeater rptItens2;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.View viewAll;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.MultiView mtvViews;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebPartCodeGenerator", "12.0.0.0")]
        public static implicit operator global::System.Web.UI.TemplateControl(MeusSistemas target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.Panel @__BuildControlpnlNoData() {
            global::System.Web.UI.WebControls.Panel @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Panel();
            this.pnlNoData = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "pnlNoData";
            @__ctrl.Visible = false;
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                <p>Você ainda não possui nenhum Sistema.</p>\r\n            "));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControl__control2(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                    <ul>\r\n                "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.DataBoundLiteralControl @__BuildControl__control4() {
            global::System.Web.UI.DataBoundLiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.DataBoundLiteralControl(3, 2);
            @__ctrl.TemplateControl = this;
            @__ctrl.SetStaticString(0, "\r\n                    <li><a href=\"");
            @__ctrl.SetStaticString(1, "\" data-fancybox-type=\"iframe\" class=\"fancybox\">");
            @__ctrl.SetStaticString(2, "</a></li>\r\n                ");
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBind__control4);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        public void @__DataBind__control4(object sender, System.EventArgs e) {
            System.Web.UI.WebControls.RepeaterItem Container;
            System.Web.UI.DataBoundLiteralControl target;
            target = ((System.Web.UI.DataBoundLiteralControl)(sender));
            Container = ((System.Web.UI.WebControls.RepeaterItem)(target.BindingContainer));
            target.SetDataBoundString(0, global::System.Convert.ToString((new SPFieldUrlValue(GetSistemaUrl(Eval("Sistema"))).Url), global::System.Globalization.CultureInfo.CurrentCulture));
            target.SetDataBoundString(1, global::System.Convert.ToString((new SPFieldUrlValue(GetSistemaUrl(Eval("Sistema"))).Description), global::System.Globalization.CultureInfo.CurrentCulture));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControl__control3(System.Web.UI.Control @__ctrl) {
            global::System.Web.UI.DataBoundLiteralControl @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control4();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControl__control5(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                    </ul>\r\n                "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.Repeater @__BuildControlrptItens() {
            global::System.Web.UI.WebControls.Repeater @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Repeater();
            this.rptItens = @__ctrl;
            @__ctrl.HeaderTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control2));
            @__ctrl.ItemTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control3));
            @__ctrl.FooterTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control5));
            @__ctrl.ID = "rptItens";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.HtmlControls.HtmlAnchor @__BuildControlverTodosMeusSistemas() {
            global::System.Web.UI.HtmlControls.HtmlAnchor @__ctrl;
            @__ctrl = new global::System.Web.UI.HtmlControls.HtmlAnchor();
            this.verTodosMeusSistemas = @__ctrl;
            @__ctrl.HRef = "/SitePages/MeusSistemas.aspx?isdlg=1";
            @__ctrl.Title = "Meus Sistemas";
            ((System.Web.UI.IAttributeAccessor)(@__ctrl)).SetAttribute("data-fancybox-type", "iframe");
            ((System.Web.UI.IAttributeAccessor)(@__ctrl)).SetAttribute("class", "maisInfo fancybox");
            @__ctrl.ID = "verTodosMeusSistemas";
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("Ver todos meus sistemas"));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.View @__BuildControlviewHome() {
            global::System.Web.UI.WebControls.View @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.View();
            this.viewHome = @__ctrl;
            @__ctrl.ID = "viewHome";
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.Panel @__ctrl1;
            @__ctrl1 = this.@__BuildControlpnlNoData();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n            "));
            global::System.Web.UI.WebControls.Repeater @__ctrl2;
            @__ctrl2 = this.@__BuildControlrptItens();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n            "));
            global::System.Web.UI.HtmlControls.HtmlAnchor @__ctrl3;
            @__ctrl3 = this.@__BuildControlverTodosMeusSistemas();
            @__parser.AddParsedSubObject(@__ctrl3);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            <a href=\"/Lists/SistemasAZ/AllItems.aspx?isdlg=1\" title=\"Sistemas d" +
                        "e A a Z\" data-fancybox-type=\"iframe\" class=\"maisInfo fancybox\">Sistemas de A a Z" +
                        "</a>\r\n        "));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.DropDownList @__BuildControlddlSistemas() {
            global::System.Web.UI.WebControls.DropDownList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.DropDownList();
            this.ddlSistemas = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "ddlSistemas";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.Button @__BuildControlbtnAdicionar() {
            global::System.Web.UI.WebControls.Button @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Button();
            this.btnAdicionar = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "btnAdicionar";
            @__ctrl.Text = "Adicionar";
            @__ctrl.Click -= new System.EventHandler(this.btnAdicionar_Click);
            @__ctrl.Click += new System.EventHandler(this.btnAdicionar_Click);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControl__control6(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                    <ul>\r\n                "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.DataBoundLiteralControl @__BuildControl__control8() {
            global::System.Web.UI.DataBoundLiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.DataBoundLiteralControl(3, 2);
            @__ctrl.TemplateControl = this;
            @__ctrl.SetStaticString(0, "\r\n                    <li>");
            @__ctrl.SetStaticString(1, " - <a href=\"/SitePages/MeusSistemas.aspx?IdSistema=");
            @__ctrl.SetStaticString(2, "\">Remover</a></li>\r\n                ");
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBind__control8);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        public void @__DataBind__control8(object sender, System.EventArgs e) {
            System.Web.UI.WebControls.RepeaterItem Container;
            System.Web.UI.DataBoundLiteralControl target;
            target = ((System.Web.UI.DataBoundLiteralControl)(sender));
            Container = ((System.Web.UI.WebControls.RepeaterItem)(target.BindingContainer));
            target.SetDataBoundString(0, global::System.Convert.ToString(GetSistema(Eval("Sistema")), global::System.Globalization.CultureInfo.CurrentCulture));
            target.SetDataBoundString(1, global::System.Convert.ToString(Eval("ID"), global::System.Globalization.CultureInfo.CurrentCulture));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControl__control7(System.Web.UI.Control @__ctrl) {
            global::System.Web.UI.DataBoundLiteralControl @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control8();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControl__control9(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                    </ul>\r\n                "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.Repeater @__BuildControlrptItens2() {
            global::System.Web.UI.WebControls.Repeater @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Repeater();
            this.rptItens2 = @__ctrl;
            @__ctrl.HeaderTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control6));
            @__ctrl.ItemTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control7));
            @__ctrl.FooterTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control9));
            @__ctrl.ID = "rptItens2";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.View @__BuildControlviewAll() {
            global::System.Web.UI.WebControls.View @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.View();
            this.viewAll = @__ctrl;
            @__ctrl.ID = "viewAll";
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.DropDownList @__ctrl1;
            @__ctrl1 = this.@__BuildControlddlSistemas();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.Button @__ctrl2;
            @__ctrl2 = this.@__BuildControlbtnAdicionar();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n            "));
            global::System.Web.UI.WebControls.Repeater @__ctrl3;
            @__ctrl3 = this.@__BuildControlrptItens2();
            @__parser.AddParsedSubObject(@__ctrl3);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        "));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.MultiView @__BuildControlmtvViews() {
            global::System.Web.UI.WebControls.MultiView @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.MultiView();
            this.mtvViews = @__ctrl;
            @__ctrl.ID = "mtvViews";
            @__ctrl.ActiveViewIndex = 0;
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        "));
            global::System.Web.UI.WebControls.View @__ctrl1;
            @__ctrl1 = this.@__BuildControlviewHome();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n        "));
            global::System.Web.UI.WebControls.View @__ctrl2;
            @__ctrl2 = this.@__BuildControlviewAll();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n    "));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControlTree(global::DG.EmbratelIntranet.Home.Artifacts.Webparts.MeusSistemas.MeusSistemas @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n<div class=\"meusSistemas\">\r\n    "));
            global::System.Web.UI.WebControls.MultiView @__ctrl1;
            @__ctrl1 = this.@__BuildControlmtvViews();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n</div>"));
        }
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}
