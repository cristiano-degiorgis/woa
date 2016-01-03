<%@ Control Language="c#" AutoEventWireup="True" Codebehind="Trattamento.ascx.cs" Inherits="Steve.UserControl.Trattamento" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<div class="step">

<h5>Trattamento</h5>

<div>
	<asp:Label ID="lblMsg" Runat="server"></asp:Label></div>
	
	
<asp:Panel ID="pnEditing" Runat="server" Visible="False">
<DIV class="bloccoForm">Data: <ASP:TEXTBOX id="txtData" Runat="server" Width="80" MaxLength="10" ReadOnly="False"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm">Descrizione:<BR><ASP:TEXTBOX id="txtDescrizione" Runat="server" Width="500" Height="200" TextMode="MultiLine"></ASP:TEXTBOX></DIV>
<DIV class="bloccoSubmit"><ASP:BUTTON id="cmdSalva" onclick="Salva_Dati" CssClass="button" Runat="server"></ASP:BUTTON></DIV>
</asp:Panel>

<asp:Panel ID="pnShow" Runat="server" Visible="False">
<DIV class="bloccoForm"><span class="etichettaShow">Data:</span> 
<asp:Label id="lblData" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm">
	<span class="etichettaShow">Descrizione:</span><div class="csMemo"><asp:Label id="lblDescrizione" Runat="server"></asp:Label></div></DIV>
<DIV class="contextLink"><asp:HyperLink id="hlUpd" Runat="server">&gt;&gt; Modifica Trattamento</asp:HyperLink></DIV>
</asp:Panel>

<asp:Panel ID="pnIsNull" Runat="server" Visible="False"><asp:HyperLink id="hlAdd" Runat="server">Inserisci Trattamento</asp:HyperLink>
</asp:Panel>

</div>
