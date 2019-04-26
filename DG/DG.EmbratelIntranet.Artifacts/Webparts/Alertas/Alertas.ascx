<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Alertas.ascx.cs" Inherits="DG.EmbratelIntranet.Home.Artifacts.Webparts.Alertas.Alertas" %>

<asp:Repeater ID="rptItens" runat="server">
    <HeaderTemplate>
        <!-- Componente Alertas : Inicio -->
        <div class="alertas">
            <h3 class="tituloBox" style="background-color: #d52b31;">Alertas</h3>
    </HeaderTemplate>
    <ItemTemplate>
            <!-- Alertas : Inicio -->
        <%# Container.DataItem %>
            <!-- Alertas : Fim -->
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
<asp:Label ID="lblNoData" runat="server" Text="Não existem alertas a serem exibidos." Visible="false" EnableViewState="false"></asp:Label>