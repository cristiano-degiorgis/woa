<%@ Control Language="c#" AutoEventWireup="True" Codebehind="MainMenu.ascx.cs" Inherits="Steve.UserControl.MainMenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<ul class="nav nav-tabs">
    <li><asp:HyperLink ID="hlHome" NavigateUrl="~/" Runat="server">Home</asp:HyperLink></li>
    <li><asp:HyperLink ID="hlPaziente" Runat="server">Paziente</asp:HyperLink></li>
    <li><asp:HyperLink ID="hlConsulto" Runat="server">Consulto</asp:HyperLink></li>
</ul>