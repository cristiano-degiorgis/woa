<%@ Page Language="c#" CodeBehind="dettagli_paziente.aspx.cs" AutoEventWireup="True" Inherits="Steve.App.dettagli_paziente" %>

<%@ Register TagPrefix="uc1" TagName="Paziente" Src="~/UserControl/Paziente.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoConsulti" Src="~/UserControl/ElencoConsulti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoAnamnesiRemote" Src="~/UserControl/ElencoAnamnesiRemote.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MainMenu" Src="~/UserControl/MainMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Testata" Src="~/UserControl/Testata.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
	<title>W.O.A.</title>
	<%--<link href="/woa/css/main.css" rel="stylesheet" type="text/css">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">--%>
	<script language="javascript" type="text/javascript" src="/woa/js/global.js"></script>
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
				<div class="col-md-3">
					<uc1:Paziente ID="Paziente1" runat="server"></uc1:Paziente>
				</div>
				<div class="col-md-4">
					<uc1:ElencoAnamnesiRemote ID="ElencoAnamnesiRemote1" runat="server"></uc1:ElencoAnamnesiRemote>
				</div>

				<div class="col-md-4">
					<uc1:ElencoConsulti ID="ElencoConsulti1" runat="server"></uc1:ElencoConsulti>
				</div>
			</div>
		</div>
	</form>

	<script src="/woa/jquery/jquery-1.11.3.min.js"></script>
	<script src="/woa/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
