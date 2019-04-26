<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="Microsoft.SharePoint.WebPartPages" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Aniversariantes.ascx.cs" Inherits="DG.EmbratelIntranet.Home.Artifacts.Webparts.Aniversariantes.Aniversariantes" %>

<asp:MultiView ID="mtvViews" runat="server" ActiveViewIndex="0">
    <asp:View ID="viewResumo" runat="server">
        <asp:Repeater ID="rptItens" runat="server">
            <HeaderTemplate>
                <div id="aniversariantes">
                    <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li <%#  DateTime.Now.Day.ToString("00") == ((int)Eval("DiaAniversario")).ToString("00") && DateTime.Now.Month.ToString("00") == ((int)Eval("MesAniversario")).ToString("00") ? " class=\"hoje\"" : "" %>>
                    <a href="/Lists/Pessoas/DispForm.aspx?ID=<%# Eval("ID") %>&isdlg=1" data-fancybox-type="iframe" class="fancybox" title="Aniversariante - <%# Eval("Nome") %>">
                        <%--<%# ((int)Eval("DiaAniversario")).ToString("00") %>/<%# ((int)Eval("MesAniversario")).ToString("00") %> - --%> <%# Eval("Nome") %> 
                    </a>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            <a href="/Lists/Pessoas/ResumoAniversariantes.aspx?isdlg=1" data-fancybox-type="iframe" class="maisInfo fancybox" title="Parabéns aos aniversariantes!">Ver todos</a>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </asp:View>
    <asp:View ID="viewNoData" runat="server">
        Não existem aniversariantes a serem exibidos. <br /> <br />

            <a href="/Lists/Pessoas/ResumoAniversariantes.aspx?isdlg=1" data-fancybox-type="iframe" class="maisInfo fancybox" title="Parabéns aos aniversariantes!">Ver todos</a>
     
    </asp:View>
</asp:MultiView>