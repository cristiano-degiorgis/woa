<%@ Page Language="c#" CodeBehind="dettagli_consulto.aspx.cs" AutoEventWireup="True" Inherits="Steve.App.dettagli_consulto" %>

<%@ Register TagPrefix="uc1" TagName="Paziente" Src="~/UserControl/Paziente.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoConsulti" Src="~/UserControl/ElencoConsulti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Consulto" Src="~/UserControl/Consulto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AnamnesiProssima" Src="~/UserControl/AnamnesiProssima.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoEsami" Src="~/UserControl/ElencoEsami.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoTrattamenti" Src="~/UserControl/ElencoTrattamenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoValutazioni" Src="~/UserControl/ElencoValutazioni.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MainMenu" Src="~/UserControl/MainMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Testata" Src="~/UserControl/Testata.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html>
<head>
	<title>W.O.A.</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" type="text/css" href="/woa/bootstrap/css/bootstrap.min.css">
	<!-- Optional Bootstrap theme -->
	<link rel="stylesheet" href="/woa/bootstrap/css/bootstrap-theme.min.css">
	<link rel="stylesheet" type="text/css" href="/woa/bootstrap/css/woa.css">
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<uc1:Testata ID="Testata1" runat="server"></uc1:Testata>
		<uc1:MainMenu ID="MainMenu1" runat="server"></uc1:MainMenu>
		<div class="container-fluid">
			<div class="row">
				<div class="col-md-8">
					<uc1:Consulto ID="Consulto1" Azione="Show" runat="server"></uc1:Consulto>
					<uc1:AnamnesiProssima ID="AnamnesiProssima1" Azione="Show" runat="server"></uc1:AnamnesiProssima>
					<uc1:ElencoEsami ID="ElencoEsami1" runat="server"></uc1:ElencoEsami>
					<uc1:ElencoTrattamenti ID="ElencoTrattamenti1" runat="server"></uc1:ElencoTrattamenti>
					<uc1:ElencoValutazioni ID="ElencoValutazioni1" runat="server"></uc1:ElencoValutazioni>
				</div>
				<div class="col-md-4">
					<uc1:Paziente ID="Paziente1" Azione="Show" runat="server"></uc1:Paziente>
					<uc1:ElencoConsulti ID="ElencoConsulti1" runat="server"></uc1:ElencoConsulti>
				</div>
			</div>
		</div>
	</form>
	<script src="/woa/js/jquery-1.11.3.min.js"></script>
	<script src="/woa/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
