<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Welcome.ascx.cs" Inherits="DG.EmbratelIntranet.Home.Artifacts.Webparts.Welcome.Welcome" %>



<link rel="stylesheet" type="text/css" href="http://grupoembratel/Style%20Library/JS/3rd/tooltipster/css/tooltipster.css" />
<script type="text/javascript" src="http://grupoembratel/Style%20Library/JS/3rd/tooltipster/js/jquery.tooltipster.min.js"></script>
<script>
$(document).ready(function() {
$('.tooltip').tooltipster();
});
</script>
<!--
     Modificado em 25/06/2015 Rodrigo 
     Solicitacao Eder.
     -->

<div class="dadosAcesso ms-soften">

   
<a href="/SitePages/ConfiguracaoUsuario.aspx" style="width:74px;height:74px;" class="tooltip" title="Clique aqui para editar seus dados"  >
    
     <asp:Literal ID="ltrUserImage"  runat="server"></asp:Literal></a>

    <p>BEM-VINDO(A), <strong> <asp:Literal ID="ltrUserName" runat="server"></asp:Literal><%--<%= SPContext.Current.Web.CurrentUser != null ? SPContext.Current.Web.CurrentUser.Name : "Visitante" %>--%></strong>,</p>
    <p><%= DateTime.Now.ToString(@"dddd, dd \de MMMM \de yyyy - HH:mm") %></p>
</div>


    

