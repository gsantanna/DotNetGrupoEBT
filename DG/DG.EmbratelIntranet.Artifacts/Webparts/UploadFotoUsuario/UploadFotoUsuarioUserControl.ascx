<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadFotoUsuarioUserControl.ascx.cs" Inherits="DG.EmbratelIntranet.Home.Artifacts.Webparts.UploadFotoUsuario.UploadFotoUsuarioUserControl" %>



<h2>Orientações para o upload de fotos:</h2>

<p>
1) Dimensões da foto: 74x74 pixels, formato: JPG <br />

2) Tamanho da foto: máximo de 50Kb <br />

3) Lembre-se de que você está no seu local de trabalho e de que a sua foto é visualizada por todos os outros funcionários através da busca por pessoas. <br />
    <br />
Veja algumas orientações: <br />
· A foto serve para identificar quem você é, portanto, lembre-se de inserir uma imagem sua, em que só você apareça. <br />
· Tenha bom senso ao escolher a sua foto. Não são permitidas Imagens que remetam a conteúdo político, religioso, filosófico, esportivo, racial ou sexual. <br />
    <br />
A não-observância das orientações acima pode implicar em sanções, de acordo com o Código de Ética do Grupo Embratel.</p>
<p>
&nbsp;<asp:Label  runat="server" ID="lblErro" CssClass="lblErro"></asp:Label>

</p>



    <input id="FotoUsuario" type="file" runat="server" />

<br />
<br />
<asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click"  />
