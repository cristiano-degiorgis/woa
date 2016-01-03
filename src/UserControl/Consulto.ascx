<%@ Control Language="c#" AutoEventWireup="True" Codebehind="Consulto.ascx.cs" Inherits="Steve.UserControl.Consulto" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<div class="step">

	<h5>Consulto</h5>

	<div>
		<asp:Label ID="lblMsg" Runat="server"></asp:Label>
	</div>


	<asp:Panel ID="pnEditing" Runat="server" Visible="False">
		<DIV class="bloccoForm">Data: <ASP:TEXTBOX id="txtData" Runat="server" ReadOnly="False" Width="80" MaxLength="10"></ASP:TEXTBOX>
		</DIV>
		<DIV class="bloccoForm">Problema Iniziale:<BR><ASP:TEXTBOX id="txtProblema" Runat="server" Width="500" Height="200" TextMode="MultiLine"></ASP:TEXTBOX>
		</DIV>
		<DIV class="bloccoSubmit">
			<ASP:BUTTON id="cmdSalva" onclick="Salva_Dati" CssClass="button" Runat="server"></ASP:BUTTON>
		</DIV>
	</asp:Panel>

	<asp:Panel ID="pnShow" Runat="server" Visible="False">
		<DIV class="bloccoForm">
			<span class="etichettaShow">Data:</span> 
			<asp:Label id="lblData" Runat="server"></asp:Label>
		</DIV>
		<DIV class="bloccoForm">
			<span class="etichettaShow">Problema Iniziale:</span><div class="csMemo">
				<asp:Label id="lblProblema" Runat="server"></asp:Label>
			</div>
		</DIV>
		<DIV class="contextLink">
			<asp:HyperLink id="hlUpd" Runat="server">&gt;&gt; Modifica Consulto</asp:HyperLink>
		</DIV>
	</asp:Panel>

	<asp:Panel ID="pnIsNull" Runat="server" CssClass="contextLink" Visible="False">
		<asp:HyperLink id="hlAdd" Runat="server">&gt;&gt; Inserisci Consulto</asp:HyperLink>
	</asp:Panel>

</div>