<%@ Control Language="c#" AutoEventWireup="True" Codebehind="Esame.ascx.cs" Inherits="Steve.UserControl.Esame" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<div class="step">

	<h5>Esame</h5>

	<div>
		<asp:Label ID="lblMsg" Runat="server"></asp:Label>
	</div>


	<asp:Panel ID="pnEditing" Runat="server" Visible="False">
		<DIV class="bloccoForm">Data: <ASP:TEXTBOX id="txtData" Runat="server" ReadOnly="False"></ASP:TEXTBOX>
		</DIV>
		<DIV class="bloccoForm">
			Tipo: <ASP:DROPDOWNLIST id="ddlTipo" Runat="server">
				<ASP:LISTITEM Value="0">
					Selziona un tipo di
					esame
				</ASP:LISTITEM>
			</ASP:DROPDOWNLIST>
		</DIV>
		<DIV class="bloccoForm">Descrizione:<BR><ASP:TEXTBOX id="txtDescrizione" Runat="server" Width="500" Height="200" TextMode="MultiLine"></ASP:TEXTBOX>
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
			<span class="etichettaShow">Tipo:</span> 
			<asp:Label id="lblTipo" Runat="server"></asp:Label>
		</DIV>
		<DIV class="bloccoForm">
			<span class="etichettaShow">Descrizione:</span><div class="csMemo">
				<asp:Label id="lblDescrizione" Runat="server"></asp:Label>
			</div>
		</DIV>
		<DIV class="contextLink">
			<asp:HyperLink id="hlUpd" Runat="server">&gt;&gt; Modifica Esame</asp:HyperLink>
		</DIV>
	</asp:Panel>

	<asp:Panel ID="pnIsNull" Runat="server" Visible="False">
		<asp:HyperLink id="hlAdd" Runat="server">Inserisci Esame</asp:HyperLink>
	</asp:Panel>

</div>