<%@ Control Language="c#" AutoEventWireup="True" Codebehind="MainMenu.ascx.cs" Inherits="Steve.UserControl.MainMenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<div id="MainMenu">
	<div class="item">
		<asp:HyperLink ID="hlHome" NavigateUrl="~/" Runat="server">Home</asp:HyperLink></div>
	<div class="item">
		<asp:HyperLink ID="hlPaziente" Runat="server">Paziente</asp:HyperLink></div>
	<div class="item">
		<asp:HyperLink ID="hlConsulto" Runat="server">Consulto</asp:HyperLink></div>
</div>
