<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SAP.ascx.cs" Inherits="DG.EmbratelIntranet.Home.Artifacts.Webparts.SAP.SAP" %>

<div class="sap">
    <asp:MultiView ID="mtvTelas" runat="server" ActiveViewIndex="0">

        <asp:View ID="viewContent" runat="server">
            <iframe runat="server" id="iframe"></iframe>
        </asp:View>
        <asp:View ID="viewNoDataSource" runat="server">
            <p>Origem de dados não configurada.</p>
        </asp:View>
        <asp:View ID="viewNoData" runat="server">
            <p>Não existem documentos em seu nível para aprovação.</p>
        </asp:View>
    </asp:MultiView>
</div>
