<%-- _lcid="1046" _version="15.0.4442" _dal="1" --%>
<%-- _LocalBinding --%>
<%@ Page language="C#" MasterPageFile="~masterurl/default.master"    Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage,Microsoft.SharePoint,Version=15.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c"  %> <%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Import Namespace="Microsoft.SharePoint" %> <%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:ListItemProperty Property="BaseName" maxlength="40" runat="server" __designer:Preview="Home" __designer:Values="&lt;P N=&#39;Property&#39; T=&#39;BaseName&#39; /&gt;&lt;P N=&#39;MaxLength&#39; T=&#39;40&#39; /&gt;&lt;P N=&#39;InDesign&#39; T=&#39;False&#39; /&gt;&lt;P N=&#39;ID&#39; ID=&#39;1&#39; T=&#39;ctl00&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;2&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;2&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;"/>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server">
	<meta name="GENERATOR" content="Microsoft SharePoint" />
	<meta name="ProgId" content="SharePoint.WebPartPage.Document" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="CollaborationServer" content="SharePoint Team Web Site" />
	<SharePoint:ScriptBlock runat="server" __designer:Preview="&lt;script type=&quot;text/javascript&quot;&gt;// &lt;![CDATA[ 


	var navBarHelpOverrideKey = &quot;WSSEndUser&quot;;
	// ]]&gt;
&lt;/script&gt;" __designer:Values="&lt;P N=&#39;ID&#39; ID=&#39;1&#39; T=&#39;ctl01&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;2&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;2&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;">
	var navBarHelpOverrideKey = "WSSEndUser";
	</SharePoint:ScriptBlock>
<SharePoint:StyleBlock runat="server" __designer:Preview="&lt;style type=&quot;text/css&quot;&gt;
body #s4-leftpanel {
	display:none;
}
.s4-ca {
	margin-left:0px;
}
&lt;/style&gt;" __designer:Values="&lt;P N=&#39;ID&#39; ID=&#39;1&#39; T=&#39;ctl02&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;2&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;2&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;">
body #s4-leftpanel {
	display:none;
}
.s4-ca {
	margin-left:0px;
}
</SharePoint:StyleBlock>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderSearchArea" runat="server">
	<SharePoint:DelegateControl runat="server"
		ControlId="SmallSearchInputBox" __designer:Preview="&lt;span style=&quot;display:none&quot;&gt;&lt;/span&gt;" __designer:Values="&lt;P N=&#39;ControlId&#39; T=&#39;SmallSearchInputBox&#39; /&gt;&lt;P N=&#39;ID&#39; ID=&#39;1&#39; T=&#39;ctl03&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;2&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;2&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;"/>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
	<SharePoint:ProjectProperty Property="Description" runat="server" __designer:Preview="" __designer:Values="&lt;P N=&#39;Property&#39; T=&#39;Description&#39; /&gt;&lt;P N=&#39;InDesign&#39; T=&#39;False&#39; /&gt;&lt;P N=&#39;ID&#39; ID=&#39;1&#39; T=&#39;ctl04&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;2&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;2&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;"/>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">
  <div class="ms-hide">
	<WebPartPages:WebPartZone runat="server" title="loc:TitleBar" id="TitleBar" AllowLayoutChange="false" AllowPersonalization="false" Style="display:none;" __designer:Preview="&lt;Regions&gt;&lt;Region Name=&quot;0&quot; Editable=&quot;True&quot; Content=&quot;&quot; NamingContainer=&quot;True&quot; /&gt;&lt;/Regions&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;0&quot; border=&quot;0&quot; id=&quot;TitleBar&quot; style=&quot;display:none;&quot;&gt;
	&lt;tr&gt;
		&lt;td style=&quot;white-space:nowrap;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
			&lt;tr&gt;
				&lt;td style=&quot;white-space:nowrap;&quot;&gt;Barra de Título&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;&lt;tr&gt;
		&lt;td style=&quot;height:100%;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;border-color:Gray;border-width:1px;border-style:Solid;width:100%;height:100%;&quot;&gt;
			&lt;tr valign=&quot;top&quot;&gt;
				&lt;td _designerRegion=&quot;0&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
					&lt;tr&gt;
						&lt;td style=&quot;height:100%;&quot;&gt;&lt;/td&gt;
					&lt;/tr&gt;
				&lt;/table&gt;&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;" __designer:Values="&lt;P N=&#39;ID&#39; ID=&#39;1&#39; T=&#39;TitleBar&#39; /&gt;&lt;P N=&#39;AllowPersonalization&#39; T=&#39;False&#39; /&gt;&lt;P N=&#39;HeaderText&#39; T=&#39;loc:TitleBar&#39; /&gt;&lt;P N=&#39;DisplayTitle&#39; ID=&#39;2&#39; T=&#39;Barra de Título&#39; /&gt;&lt;P N=&#39;AllowLayoutChange&#39; T=&#39;False&#39; /&gt;&lt;P N=&#39;Title&#39; R=&#39;2&#39; /&gt;&lt;P N=&#39;LockLayout&#39; T=&#39;True&#39; /&gt;&lt;P N=&#39;HasAttributes&#39; T=&#39;True&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;3&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;3&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;" __designer:Templates="&lt;Group Name=&quot;ZoneTemplate&quot;&gt;&lt;Template Name=&quot;ZoneTemplate&quot; Content=&quot;&quot; /&gt;&lt;/Group&gt;"><ZoneTemplate><WebPartPages:TitleBarWebPart runat="server" HeaderTitle="Gente" Title="Barra de T&#237;tulo da P&#225;gina de Web Parts" FrameType="None" SuppressWebPartChrome="False" Description="" IsIncluded="True" ZoneID="TitleBar" PartOrder="1" FrameState="Normal" AllowRemove="False" AllowZoneChange="True" AllowMinimize="False" AllowConnect="True" AllowEdit="True" AllowHide="True" IsVisible="True" DetailLink="" HelpLink="" HelpMode="Modeless" Dir="Default" PartImageSmall="" MissingAssembly="N&#227;o &#233; poss&#237;vel importar esta Web Part." ImportErrorMessage="N&#227;o &#233; poss&#237;vel importar esta Web Part." PartImageLarge="" IsIncludedFilter="" ExportControlledProperties="True" ConnectionID="00000000-0000-0000-0000-000000000000" ID="g_210f7d4f_d8ad_4f93_8bd0_72da30cd6cd5" AllowClose="False" ChromeType="None" ExportMode="All" __designer:Values="&lt;P N=&#39;HeaderTitle&#39; T=&#39;Gente&#39; /&gt;&lt;P N=&#39;ZoneID&#39; T=&#39;TitleBar&#39; /&gt;&lt;P N=&#39;PartOrder&#39; T=&#39;1&#39; /&gt;&lt;P N=&#39;ID&#39; T=&#39;g_210f7d4f_d8ad_4f93_8bd0_72da30cd6cd5&#39; /&gt;&lt;P N=&#39;StorageKey&#39; T=&#39;210f7d4f-d8ad-4f93-8bd0-72da30cd6cd5&#39; /&gt;&lt;P N=&#39;Qualifier&#39; T=&#39;WPQ1&#39; /&gt;&lt;P N=&#39;ClientName&#39; T=&#39;varPartWPQ1&#39; /&gt;&lt;P N=&#39;Permissions&#39; E=&#39;0&#39; /&gt;&lt;P N=&#39;EffectiveStorage&#39; E=&#39;2&#39; /&gt;&lt;P N=&#39;AllowClose&#39; T=&#39;False&#39; /&gt;&lt;P N=&#39;ExportMode&#39; E=&#39;1&#39; /&gt;&lt;P N=&#39;IsShared&#39; T=&#39;True&#39; /&gt;&lt;P N=&#39;IsStandalone&#39; T=&#39;False&#39; /&gt;&lt;P N=&#39;IsStatic&#39; T=&#39;False&#39; /&gt;&lt;P N=&#39;WebBrowsableObject&#39; R=&#39;0&#39; /&gt;&lt;P N=&#39;ZoneIndex&#39; T=&#39;1&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;1&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;1&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;" __designer:Preview="&lt;div class=&quot;ms-webpart-chrome ms-webpart-chrome-vertical ms-webpart-chrome-fullWidth &quot;&gt;
	&lt;div WebPartID=&quot;210f7d4f-d8ad-4f93-8bd0-72da30cd6cd5&quot; HasPers=&quot;false&quot; id=&quot;WebPartWPQ1&quot; width=&quot;100%&quot; class=&quot;&quot; allowMinimize=&quot;false&quot; allowRemove=&quot;false&quot; allowDelete=&quot;false&quot; style=&quot;&quot; &gt;&lt;div id=&quot;WebPartContent&quot;&gt;
		&lt;div&gt;&lt;table id=&quot;MSOWebPart_Header&quot; border=&quot;0&quot; cellpadding=&quot;0&quot; cellspacing=&quot;0&quot; width=&quot;100%&quot;&gt;
	&lt;tr&gt;
		&lt;td style=&quot;width:100%;&quot;&gt;&lt;table border=&quot;0&quot; cellpadding=&quot;0&quot; cellspacing=&quot;0&quot;&gt;
			&lt;tr&gt;
				&lt;td title=&quot;&quot; class=&quot;ms-titlewpTitleArea&quot; name=&quot;titlewpTitleArea&quot; style=&quot;padding-left:5px;&quot;&gt;&lt;span class=&quot;ms-pagetitle&quot;&gt;Gente&lt;/span&gt;&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;&lt;nobr&gt;&lt;a href=&quot;javascript:MSOTlPn_ShowToolPane2Wrapper(&#39;Edit&#39;, 16, &#39;g_210f7d4f_d8ad_4f93_8bd0_72da30cd6cd5&#39;)&quot; id=&quot;EditTitleBar&quot; style=&quot;display:none;&quot;&gt;Editar Propriedades da Barra de Título&lt;/a&gt;&lt;/nobr&gt;
	&lt;/tr&gt;
&lt;/table&gt;&lt;/div&gt;
	&lt;/div&gt;&lt;div class=&quot;ms-clear&quot;&gt;&lt;/div&gt;&lt;/div&gt;
&lt;/div&gt;" __MarkupType="vsattributemarkup" __WebPartId="{210F7D4F-D8AD-4F93-8BD0-72DA30CD6CD5}" WebPart="true" Height="" Width=""></WebPartPages:TitleBarWebPart>

</ZoneTemplate></WebPartPages:WebPartZone>
  </div>
  <table class="ms-core-tableNoSpace ms-webpartPage-root" width="100%">
				<tr>
					<td id="_invisibleIfEmpty" name="_invisibleIfEmpty" colspan="2" valign="top" width="100%"> <WebPartPages:WebPartZone runat="server" Title="loc:Header" ID="Header" FrameType="TitleBarOnly" __designer:Preview="&lt;Regions&gt;&lt;Region Name=&quot;0&quot; Editable=&quot;True&quot; Content=&quot;&quot; NamingContainer=&quot;True&quot; /&gt;&lt;/Regions&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;0&quot; border=&quot;0&quot; id=&quot;Header&quot;&gt;
	&lt;tr&gt;
		&lt;td style=&quot;white-space:nowrap;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
			&lt;tr&gt;
				&lt;td style=&quot;white-space:nowrap;&quot;&gt;Cabeçalho&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;&lt;tr&gt;
		&lt;td style=&quot;height:100%;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;border-color:Gray;border-width:1px;border-style:Solid;width:100%;height:100%;&quot;&gt;
			&lt;tr valign=&quot;top&quot;&gt;
				&lt;td _designerRegion=&quot;0&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
					&lt;tr&gt;
						&lt;td style=&quot;height:100%;&quot;&gt;&lt;/td&gt;
					&lt;/tr&gt;
				&lt;/table&gt;&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;" __designer:Values="&lt;P N=&#39;ID&#39; ID=&#39;1&#39; T=&#39;Header&#39; /&gt;&lt;P N=&#39;HeaderText&#39; T=&#39;loc:Header&#39; /&gt;&lt;P N=&#39;DisplayTitle&#39; ID=&#39;2&#39; T=&#39;Cabeçalho&#39; /&gt;&lt;P N=&#39;FrameType&#39; E=&#39;2&#39; /&gt;&lt;P N=&#39;Title&#39; R=&#39;2&#39; /&gt;&lt;P N=&#39;PartChromeType&#39; E=&#39;3&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;3&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;3&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;" __designer:Templates="&lt;Group Name=&quot;ZoneTemplate&quot;&gt;&lt;Template Name=&quot;ZoneTemplate&quot; Content=&quot;&quot; /&gt;&lt;/Group&gt;"><ZoneTemplate>
<WebPartPages:ContentEditorWebPart runat="server" __MarkupType="xmlmarkup" WebPart="true" __WebPartId="{C1D63775-445B-434E-A282-24C5C3017CA3}" __Preview="&lt;div class=&quot;ms-webpart-chrome ms-webpart-chrome-fullWidth &quot;&gt;
	&lt;div class=&quot;ms-webpart-chrome-title&quot; id=&quot;WebPart_ChromeTitle&quot;&gt;
		&lt;span title=&quot;Cabeçalho - Permite que os autores insiram conteúdo rich text.&quot; id=&quot;WebPartTitle&quot; class=&quot;js-webpart-titleCell&quot;&gt;&lt;div class=&quot;ms-webpart-titleText&quot;&gt;&lt;nobr&gt;&lt;span&gt;Cabeçalho&lt;/span&gt;&lt;span id=&quot;WebPartCaption&quot;&gt;&lt;/span&gt;&lt;/nobr&gt;&lt;/div&gt;&lt;/span&gt;
	&lt;/div&gt;&lt;div WebPartID=&quot;c1d63775-445b-434e-a282-24c5c3017ca3&quot; HasPers=&quot;false&quot; id=&quot;WebPart&quot; width=&quot;100%&quot; class=&quot;ms-WPBody ms-WPBorder ms-wpContentDivSpace &quot; allowDelete=&quot;false&quot; style=&quot;&quot; &gt;&lt;div id=&quot;WebPartContent&quot; PreviewAvailable=&quot;false&quot;&gt;&lt;/div&gt;&lt;div class=&quot;ms-clear&quot;&gt;&lt;/div&gt;&lt;/div&gt;
&lt;/div&gt;" >
<WebPart xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/WebPart/v2">
  <Title>Cabeçalho</Title>
  <FrameType>Default</FrameType>
  <Description>Permite que os autores insiram conteúdo rich text.</Description>
  <IsIncluded>true</IsIncluded>
  <ZoneID>Header</ZoneID>
  <PartOrder>0</PartOrder>
  <FrameState>Normal</FrameState>
  <Height />
  <Width />
  <AllowRemove>true</AllowRemove>
  <AllowZoneChange>true</AllowZoneChange>
  <AllowMinimize>true</AllowMinimize>
  <AllowConnect>true</AllowConnect>
  <AllowEdit>true</AllowEdit>
  <AllowHide>true</AllowHide>
  <IsVisible>true</IsVisible>
  <DetailLink />
  <HelpLink />
  <HelpMode>Modeless</HelpMode>
  <Dir>Default</Dir>
  <PartImageSmall />
  <MissingAssembly>Não é possível importar esta Web Part.</MissingAssembly>
  <PartImageLarge>/_layouts/15/images/mscontl.gif</PartImageLarge>
  <IsIncludedFilter />
  <ExportControlledProperties>true</ExportControlledProperties>
  <ConnectionID>00000000-0000-0000-0000-000000000000</ConnectionID>
  <ID>g_c1d63775_445b_434e_a282_24c5c3017ca3</ID>
  <ContentLink xmlns="http://schemas.microsoft.com/WebPart/v2/ContentEditor" />
  <Content xmlns="http://schemas.microsoft.com/WebPart/v2/ContentEditor"><![CDATA[​​Conteúdo de exemplo]]></Content>
  <PartStorage xmlns="http://schemas.microsoft.com/WebPart/v2/ContentEditor" />
</WebPart>
</WebPartPages:ContentEditorWebPart>
</ZoneTemplate></WebPartPages:WebPartZone> </td>
				</tr>
				<tr>
					<td id="_invisibleIfEmpty" name="_invisibleIfEmpty" valign="top" height="100%" width="100%"> <WebPartPages:WebPartZone runat="server" Title="loc:Body" ID="Body" FrameType="TitleBarOnly" __designer:Preview="&lt;Regions&gt;&lt;Region Name=&quot;0&quot; Editable=&quot;True&quot; Content=&quot;&quot; NamingContainer=&quot;True&quot; /&gt;&lt;/Regions&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;0&quot; border=&quot;0&quot; id=&quot;Body&quot;&gt;
	&lt;tr&gt;
		&lt;td style=&quot;white-space:nowrap;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
			&lt;tr&gt;
				&lt;td style=&quot;white-space:nowrap;&quot;&gt;Corpo&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;&lt;tr&gt;
		&lt;td style=&quot;height:100%;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;border-color:Gray;border-width:1px;border-style:Solid;width:100%;height:100%;&quot;&gt;
			&lt;tr valign=&quot;top&quot;&gt;
				&lt;td _designerRegion=&quot;0&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
					&lt;tr&gt;
						&lt;td style=&quot;height:100%;&quot;&gt;&lt;/td&gt;
					&lt;/tr&gt;
				&lt;/table&gt;&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;" __designer:Values="&lt;P N=&#39;ID&#39; ID=&#39;1&#39; T=&#39;Body&#39; /&gt;&lt;P N=&#39;HeaderText&#39; T=&#39;loc:Body&#39; /&gt;&lt;P N=&#39;DisplayTitle&#39; ID=&#39;2&#39; T=&#39;Corpo&#39; /&gt;&lt;P N=&#39;FrameType&#39; E=&#39;2&#39; /&gt;&lt;P N=&#39;Title&#39; R=&#39;2&#39; /&gt;&lt;P N=&#39;PartChromeType&#39; E=&#39;3&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;3&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;3&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;" __designer:Templates="&lt;Group Name=&quot;ZoneTemplate&quot;&gt;&lt;Template Name=&quot;ZoneTemplate&quot; Content=&quot;&quot; /&gt;&lt;/Group&gt;"><ZoneTemplate>
<WebPartPages:ContentEditorWebPart runat="server" __MarkupType="xmlmarkup" WebPart="true" __WebPartId="{E7465C70-8460-4DD6-B586-FCDB76F4A9EA}" __Preview="&lt;div class=&quot;ms-webpart-chrome ms-webpart-chrome-fullWidth &quot;&gt;
	&lt;div class=&quot;ms-webpart-chrome-title&quot; id=&quot;WebPart_ChromeTitle&quot;&gt;
		&lt;span title=&quot;Conteúdo principal - Permite que os autores insiram conteúdo rich text.&quot; id=&quot;WebPartTitle&quot; class=&quot;js-webpart-titleCell&quot;&gt;&lt;div class=&quot;ms-webpart-titleText&quot;&gt;&lt;nobr&gt;&lt;span&gt;Conteúdo principal&lt;/span&gt;&lt;span id=&quot;WebPartCaption&quot;&gt;&lt;/span&gt;&lt;/nobr&gt;&lt;/div&gt;&lt;/span&gt;
	&lt;/div&gt;&lt;div WebPartID=&quot;e7465c70-8460-4dd6-b586-fcdb76f4a9ea&quot; HasPers=&quot;false&quot; id=&quot;WebPart&quot; width=&quot;100%&quot; class=&quot;ms-WPBody ms-WPBorder ms-wpContentDivSpace &quot; allowDelete=&quot;false&quot; style=&quot;&quot; &gt;&lt;div id=&quot;WebPartContent&quot; PreviewAvailable=&quot;false&quot;&gt;&lt;/div&gt;&lt;div class=&quot;ms-clear&quot;&gt;&lt;/div&gt;&lt;/div&gt;
&lt;/div&gt;" >
<WebPart xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/WebPart/v2">
  <Title>Conteúdo principal</Title>
  <FrameType>Default</FrameType>
  <Description>Permite que os autores insiram conteúdo rich text.</Description>
  <IsIncluded>true</IsIncluded>
  <ZoneID>Body</ZoneID>
  <PartOrder>0</PartOrder>
  <FrameState>Normal</FrameState>
  <Height />
  <Width />
  <AllowRemove>true</AllowRemove>
  <AllowZoneChange>true</AllowZoneChange>
  <AllowMinimize>true</AllowMinimize>
  <AllowConnect>true</AllowConnect>
  <AllowEdit>true</AllowEdit>
  <AllowHide>true</AllowHide>
  <IsVisible>true</IsVisible>
  <DetailLink />
  <HelpLink />
  <HelpMode>Modeless</HelpMode>
  <Dir>Default</Dir>
  <PartImageSmall />
  <MissingAssembly>Não é possível importar esta Web Part.</MissingAssembly>
  <PartImageLarge>/_layouts/15/images/mscontl.gif</PartImageLarge>
  <IsIncludedFilter />
  <ExportControlledProperties>true</ExportControlledProperties>
  <ConnectionID>00000000-0000-0000-0000-000000000000</ConnectionID>
  <ID>g_e7465c70_8460_4dd6_b586_fcdb76f4a9ea</ID>
  <ContentLink xmlns="http://schemas.microsoft.com/WebPart/v2/ContentEditor" />
  <Content xmlns="http://schemas.microsoft.com/WebPart/v2/ContentEditor"><![CDATA[<p>Conteúdo de exemplo</p>]]></Content>
  <PartStorage xmlns="http://schemas.microsoft.com/WebPart/v2/ContentEditor" />
</WebPart>
</WebPartPages:ContentEditorWebPart>
</ZoneTemplate></WebPartPages:WebPartZone> </td>
					<td id="_invisibleIfEmpty" name="_invisibleIfEmpty" valign="top" height="100%"> <WebPartPages:WebPartZone runat="server" Title="loc:RightColumn" ID="RightColumn" FrameType="TitleBarOnly" __designer:Preview="&lt;Regions&gt;&lt;Region Name=&quot;0&quot; Editable=&quot;True&quot; Content=&quot;&quot; NamingContainer=&quot;True&quot; /&gt;&lt;/Regions&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;0&quot; border=&quot;0&quot; id=&quot;RightColumn&quot;&gt;
	&lt;tr&gt;
		&lt;td style=&quot;white-space:nowrap;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
			&lt;tr&gt;
				&lt;td style=&quot;white-space:nowrap;&quot;&gt;Coluna da Direita&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;&lt;tr&gt;
		&lt;td style=&quot;height:100%;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;border-color:Gray;border-width:1px;border-style:Solid;width:100%;height:100%;&quot;&gt;
			&lt;tr valign=&quot;top&quot;&gt;
				&lt;td _designerRegion=&quot;0&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
					&lt;tr&gt;
						&lt;td style=&quot;height:100%;&quot;&gt;&lt;/td&gt;
					&lt;/tr&gt;
				&lt;/table&gt;&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;" __designer:Values="&lt;P N=&#39;ID&#39; ID=&#39;1&#39; T=&#39;RightColumn&#39; /&gt;&lt;P N=&#39;HeaderText&#39; T=&#39;loc:RightColumn&#39; /&gt;&lt;P N=&#39;DisplayTitle&#39; ID=&#39;2&#39; T=&#39;Coluna da Direita&#39; /&gt;&lt;P N=&#39;FrameType&#39; E=&#39;2&#39; /&gt;&lt;P N=&#39;Title&#39; R=&#39;2&#39; /&gt;&lt;P N=&#39;PartChromeType&#39; E=&#39;3&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;3&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;3&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;" __designer:Templates="&lt;Group Name=&quot;ZoneTemplate&quot;&gt;&lt;Template Name=&quot;ZoneTemplate&quot; Content=&quot;&quot; /&gt;&lt;/Group&gt;"><ZoneTemplate>
<WebPartPages:ContentEditorWebPart runat="server" __MarkupType="xmlmarkup" WebPart="true" __WebPartId="{5DE4735C-3D82-45D8-B1F6-82F1DC391ECC}" __Preview="&lt;div class=&quot;ms-webpart-chrome ms-webpart-chrome-fullWidth &quot;&gt;
	&lt;div class=&quot;ms-webpart-chrome-title&quot; id=&quot;WebPart_ChromeTitle&quot;&gt;
		&lt;span title=&quot;Conteúdo lateral - Permite que os autores insiram conteúdo rich text.&quot; id=&quot;WebPartTitle&quot; class=&quot;js-webpart-titleCell&quot;&gt;&lt;div class=&quot;ms-webpart-titleText&quot;&gt;&lt;nobr&gt;&lt;span&gt;Conteúdo lateral&lt;/span&gt;&lt;span id=&quot;WebPartCaption&quot;&gt;&lt;/span&gt;&lt;/nobr&gt;&lt;/div&gt;&lt;/span&gt;
	&lt;/div&gt;&lt;div WebPartID=&quot;5de4735c-3d82-45d8-b1f6-82f1dc391ecc&quot; HasPers=&quot;false&quot; id=&quot;WebPart&quot; width=&quot;100%&quot; class=&quot;ms-WPBody ms-WPBorder ms-wpContentDivSpace &quot; allowDelete=&quot;false&quot; style=&quot;&quot; &gt;&lt;div id=&quot;WebPartContent&quot; PreviewAvailable=&quot;false&quot;&gt;&lt;/div&gt;&lt;div class=&quot;ms-clear&quot;&gt;&lt;/div&gt;&lt;/div&gt;
&lt;/div&gt;" >
<WebPart xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/WebPart/v2">
  <Title>Conteúdo lateral</Title>
  <FrameType>Default</FrameType>
  <Description>Permite que os autores insiram conteúdo rich text.</Description>
  <IsIncluded>true</IsIncluded>
  <ZoneID>RightColumn</ZoneID>
  <PartOrder>0</PartOrder>
  <FrameState>Normal</FrameState>
  <Height />
  <Width />
  <AllowRemove>true</AllowRemove>
  <AllowZoneChange>true</AllowZoneChange>
  <AllowMinimize>true</AllowMinimize>
  <AllowConnect>true</AllowConnect>
  <AllowEdit>true</AllowEdit>
  <AllowHide>true</AllowHide>
  <IsVisible>true</IsVisible>
  <DetailLink />
  <HelpLink />
  <HelpMode>Modeless</HelpMode>
  <Dir>Default</Dir>
  <PartImageSmall />
  <MissingAssembly>Não é possível importar esta Web Part.</MissingAssembly>
  <PartImageLarge>/_layouts/15/images/mscontl.gif</PartImageLarge>
  <IsIncludedFilter />
  <ExportControlledProperties>true</ExportControlledProperties>
  <ConnectionID>00000000-0000-0000-0000-000000000000</ConnectionID>
  <ID>g_5de4735c_3d82_45d8_b1f6_82f1dc391ecc</ID>
  <ContentLink xmlns="http://schemas.microsoft.com/WebPart/v2/ContentEditor" />
  <Content xmlns="http://schemas.microsoft.com/WebPart/v2/ContentEditor"><![CDATA[​​Conteúdo de exemplo​]]></Content>
  <PartStorage xmlns="http://schemas.microsoft.com/WebPart/v2/ContentEditor" />
</WebPart>
</WebPartPages:ContentEditorWebPart>
</ZoneTemplate></WebPartPages:WebPartZone> </td>
				</tr>
				<SharePoint:ScriptBlock runat="server" __designer:Preview="&lt;script type=&quot;text/javascript&quot;&gt;// &lt;![CDATA[ 

if(typeof(MSOLayout_MakeInvisibleIfEmpty) == &quot;function&quot;) {MSOLayout_MakeInvisibleIfEmpty();}// ]]&gt;
&lt;/script&gt;" __designer:Values="&lt;P N=&#39;ID&#39; ID=&#39;1&#39; T=&#39;ctl05&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;2&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;2&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;">if(typeof(MSOLayout_MakeInvisibleIfEmpty) == "function") {MSOLayout_MakeInvisibleIfEmpty();}</SharePoint:ScriptBlock>
		</table>
</asp:Content>
