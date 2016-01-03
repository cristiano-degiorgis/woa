<%@ Page language="c#" Codebehind="dettagli_paziente.aspx.cs" AutoEventWireup="True" Inherits="Steve.App.dettagli_paziente" %>
<%@ Register TagPrefix="uc1" TagName="Paziente" Src="~/UserControl/Paziente.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoConsulti" Src="~/UserControl/ElencoConsulti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoAnamnesiRemote" Src="~/UserControl/ElencoAnamnesiRemote.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MainMenu" Src="~/UserControl/MainMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Testata" Src="~/UserControl/Testata.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD>
	<title>W.O.A.</title>
	<link href="/woa/css/main.css" rel="stylesheet" type="text/css"/>
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<SCRIPT language="javascript" type="text/javascript" src="/woa/js/global.js"></SCRIPT>
</HEAD>
<body>

<form id="Form1" method="post" runat="server">
	<uc1:Testata id="Testata1" runat="server"></uc1:Testata>
	<uc1:MainMenu id="MainMenu1" runat="server"></uc1:MainMenu>
	<div id="Content">
		<h4>Dettagli Paziente</h4>

		<uc1:Paziente id="Paziente1" runat="server"></uc1:Paziente>
		<uc1:ElencoAnamnesiRemote id="ElencoAnamnesiRemote1" runat="server"></uc1:ElencoAnamnesiRemote>
		<uc1:ElencoConsulti id="ElencoConsulti1" runat="server"></uc1:ElencoConsulti>
	</div>
</form>

</body>
</HTML>