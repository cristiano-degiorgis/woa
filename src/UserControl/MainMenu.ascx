<%@ Control Language="c#" AutoEventWireup="True" Codebehind="MainMenu.ascx.cs" Inherits="Steve.UserControl.MainMenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="MenuContestuale" Src="~/UserControl/MenuContestuale.ascx" %>

<ul class="nav nav-pills">
    <li id="liHome" role="presentation" runat="server"><asp:HyperLink ID="hlHome" NavigateUrl="~/" Runat="server">Home</asp:HyperLink></li>
    <li id="liPaziente" role="presentation" runat="server"><asp:HyperLink ID="hlPaziente" Runat="server">Paziente</asp:HyperLink></li>
    <li id="liConsulto" role="presentation" runat="server" CssClass="dropdown">
	    <asp:HyperLink ID="hlConsulto" data-toggle="dropdown" class="dropdown-toggle" Runat="server">
		    Consulto
	    </asp:HyperLink>
		 
		<uc1:MenuContestuale ID="MenuContestuale1" runat="server"></uc1:MenuContestuale>
    </li>
</ul>