<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Noticias.ascx.cs" Inherits="DG.EmbratelIntranet.Home.Artifacts.Webparts.Noticias.Noticias" %>


    <asp:Label ID="lblErro" runat="server"></asp:Label>



<script type="text/javascript">
    $(document).ready(function () {
        $("#noticiasitens").owlCarousel({
           autoPlay: <%= ((DG.EmbratelIntranet.Home.Artifacts.Webparts.Noticias.Noticias)this).DisplayTime %> * 1000,
            
            items: <%= ((DG.EmbratelIntranet.Home.Artifacts.Webparts.Noticias.Noticias)this).TotalNoticias %>,
            itemsDesktop: [1199, <%= ((DG.EmbratelIntranet.Home.Artifacts.Webparts.Noticias.Noticias)this).TotalNoticias %>],
            itemsDesktopSmall: [979, <%= ((DG.EmbratelIntranet.Home.Artifacts.Webparts.Noticias.Noticias)this).TotalNoticias %>]

        });
    });
    //$(document).ready(function () {

    //    $("#owl-demo").owlCarousel({

    //        autoPlay: 3000, //Set AutoPlay to 3 seconds

    //        items: 3,
    //        itemsDesktop: [1199, 3],
    //        itemsDesktopSmall: [979, 3]

    //    });

    //});
</script>

<div id="noticias">
    <asp:MultiView ID="mtvViews" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewNoticias" runat="server">
            <asp:Repeater ID="rptItens" runat="server">
                <HeaderTemplate>
                    <div id="noticiasitens">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="item">
                        <a href="/SitePages/Noticias.aspx?isdlg=1&IdNoticia=<%# Eval("ID") %>" title="<%# Eval("Title") %>" data-fancybox-type="iframe" class="fancybox">
                            <div class="thumb">
                                <img src="<%# GetAttachment(Eval("ID")) %>" alt="<%# Eval("Title") %>" title="<%# Eval("Title") %>">
                            </div>
                            <%# Eval("Title") %>
                        </a>
                        <p><%# Eval("Chamada") %></p>
                        <p><%# Eval("Criado") %></p>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </asp:View>

        <asp:View ID="viewNoticia" runat="server">
            <div id="divNoticiaFull" runat="server"></div>
        </asp:View>
    </asp:MultiView>

    <asp:Panel ID="pnlTodasNoticias" runat="server" Visible="false">
        <a href="/Lists/Noticias/Todas.aspx?isdlg=1" data-fancybox-type="iframe" title="Todas as notícias" class="maisInfo fancybox">Ver todas as notícias</a>
    </asp:Panel>


</div>

