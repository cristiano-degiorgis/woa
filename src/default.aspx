<%@ Register TagPrefix="uc1" TagName="ElencoPazienti" Src="~/UserControl/ElencoPazienti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Testata" Src="~/UserControl/Testata.ascx" %>
<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="True" Inherits="Steve._default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD>
	<title>W.O.A.</title>
	<link href="/woa/css/main.css" rel="stylesheet" type="text/css">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
</HEAD>
<body>

<form id="Form1" method="post" runat="server">
	<uc1:Testata id="Testata1" runat="server"></uc1:Testata>
	<div id="Content">

		<div id="CheckConn">
			<asp:Label ID="lblCheckConn" Runat="server"></asp:Label>
		</div>

		<DIV style="MARGIN: 20px 0px">
			<asp:Panel ID="pnCerca" CssClass="csCercaPaziente" Runat="server">
				<DIV class="bloccoForm">
					<SPAN style="WIDTH: 100px">Nome</SPAN><asp:TextBox id="txtNome" Runat="server" Width="250"></asp:TextBox>
				</DIV>
				<DIV class="bloccoForm">
					<SPAN style="WIDTH: 100px">Cognome</SPAN><asp:TextBox id="txtCognome" Runat="server" Width="250"></asp:TextBox>
				</DIV>
				<DIV class="bloccoSubmit" style="MARGIN: 15px 0px 0px 100px">
					<asp:Button id="cmdCercaPaziente" onclick="Cerca_Paziente" Runat="server" CssClass="button" Text="Cerca >>"></asp:Button>
				</DIV>
			</asp:Panel>
		</DIV>

		<DIV style="MARGIN-BOTTOM: 4px">
			<asp:Button id="cmdShowPazienti" onclick="Show_Pazienti" Runat="server" Text="Mostra elenco completo pazienti" CssClass="button"></asp:Button>
		</DIV>

		<asp:Panel ID="pnScegli" Visible="False" Runat="server">
			<uc1:ElencoPazienti id="ElencoPazienti1" runat="server"></uc1:ElencoPazienti>
		</asp:Panel>

		<asp:Panel ID="pnNuovo" Runat="server" Visible="False">
			Nessun paziente
			presente in base ai criteri inseriti. <asp:HyperLink id="HyperLink1" Runat="server" NavigateUrl="~/AddPaziente.aspx">Aggiungi Nuovo</asp:HyperLink>
		</asp:Panel>
	</div>
</form>

</body>
</HTML>