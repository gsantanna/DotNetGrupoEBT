<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MeusSistemas.ascx.cs" Inherits="DG.EmbratelIntranet.Home.Artifacts.Webparts.MeusSistemas.MeusSistemas" %>

<div class="meusSistemas">
    <asp:MultiView ID="mtvViews" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewHome" runat="server">
            <asp:Panel ID="pnlNoData" runat="server" Visible="false">
                <p>Você ainda não possui nenhum Sistema.</p>
            </asp:Panel>

            <asp:Repeater ID="rptItens" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><a href="<%# (new SPFieldUrlValue(GetSistemaUrl(Eval("Sistema"))).Url) %>" data-fancybox-type="iframe" class="fancybox"><%# (new SPFieldUrlValue(GetSistemaUrl(Eval("Sistema"))).Description) %></a></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>

            <a href="/SitePages/MeusSistemas.aspx?isdlg=1" title="Meus Sistemas" data-fancybox-type="iframe" class="maisInfo fancybox" id="verTodosMeusSistemas" runat="server">Ver todos meus sistemas</a>
            <a href="/Lists/SistemasAZ/AllItems.aspx?isdlg=1" title="Sistemas de A a Z" data-fancybox-type="iframe" class="maisInfo fancybox">Sistemas de A a Z</a>
        </asp:View>

        <asp:View ID="viewAll" runat="server">
            <asp:DropDownList ID="ddlSistemas" runat="server"></asp:DropDownList>
            <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />

            <asp:Repeater ID="rptItens2" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><%# GetSistema(Eval("Sistema")) %> - <a href="/SitePages/MeusSistemas.aspx?IdSistema=<%# Eval("ID") %>">Remover</a></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </asp:View>
    </asp:MultiView>
</div>