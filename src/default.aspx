<%@ Register TagPrefix="uc1" TagName="ElencoPazienti" Src="~/UserControl/ElencoPazienti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Testata" Src="~/UserControl/Testata.ascx" %>

<%@ Page Language="c#" CodeBehind="default.aspx.cs" AutoEventWireup="True" Inherits="Steve._default" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
	<title>W.O.A.</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" type="text/css" href="/woa/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="/woa/bootstrap/css/woa.css">
	<!-- Optional Bootstrap theme -->
	<link rel="stylesheet" href="/woa/bootstrap/css/bootstrap-theme.min.css">
	<link rel="stylesheet" type="text/css" href="/woa/bootstrap/css/woa.css">
</head>
<body>

	<form id="Form1" method="post" runat="server">
		<uc1:Testata ID="Testata1" runat="server"></uc1:Testata>


		<h4>
			<asp:Label ID="lblCheckConn" CssClass="label" runat="server"></asp:Label>
		</h4>
		<div class="container-fluid">
			<div class="row">
				<div class="col-md-4">
					<asp:Panel ID="pnCerca" runat="server">

						<div class="form-group">
							<asp:Label runat="server" AssociatedControlID="txtNome">Nome</asp:Label>
							<asp:TextBox ID="txtNome" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label runat="server" AssociatedControlID="txtCognome">Cognome</asp:Label>
							<asp:TextBox ID="txtCognome" CssClass="form-control" runat="server"></asp:TextBox>
						</div>

						<asp:Button ID="cmdCercaPaziente" OnClick="Cerca_Paziente" runat="server"
							CssClass="btn btn-primary" Text="Cerca >>"></asp:Button>
					</asp:Panel>
				</div>

				<div class="col-md-8">
					<asp:Button ID="cmdShowPazienti" OnClick="Show_Pazienti" runat="server"
						Text="Mostra elenco completo pazienti" CssClass="btn btn-info"></asp:Button>
					<asp:Panel ID="pnScegli" Visible="False" runat="server">
						<uc1:ElencoPazienti ID="ElencoPazienti1" runat="server"></uc1:ElencoPazienti>
					</asp:Panel>
				</div>
			</div>
		</div>

		<asp:Panel ID="pnNuovo" runat="server" Visible="False">
			<p>Nessun paziente presente in base ai criteri inseriti.</p>
			<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddPaziente.aspx">
					Aggiungi Nuovo
			</asp:HyperLink>
		</asp:Panel>
		</div>
	</form>
	<script src="/woa/jquery/jquery-1.11.3.min.js"></script>
	<script src="/woa/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
