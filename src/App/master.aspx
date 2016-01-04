<%@ Register TagPrefix="uc1" TagName="Testata" Src="~/UserControl/Testata.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuContestuale" Src="~/UserControl/MenuContestuale.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Paziente" Src="~/UserControl/Paziente.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MainMenu" Src="~/UserControl/MainMenu.ascx" %>

<%@ Page Language="c#" CodeBehind="master.aspx.cs" AutoEventWireup="True" Inherits="Steve.App.master" %>

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
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<uc1:Testata ID="Testata1" runat="server"></uc1:Testata>
		<uc1:MainMenu ID="MainMenu1" runat="server"></uc1:MainMenu>
		<uc1:MenuContestuale ID="MenuContestuale1" runat="server"></uc1:MenuContestuale>

		<div class="container">
			<div class="row">
				<div class="col-md-8">
					<asp:Panel ID="pnLoadControl" runat="server"></asp:Panel>
				</div>
				<div class="col-md-4">
					<uc1:Paziente ID="Paziente1" Azione="Show" runat="server"></uc1:Paziente>
				</div>
			</div>
		</div>
	</form>

	<script src="/woa/js/jquery-1.11.3.min.js"></script>
	<script src="/woa/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
