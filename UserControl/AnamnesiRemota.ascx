<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AnamnesiRemota.ascx.cs" Inherits="Steve.UserControl.AnamnesiRemota" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<div class="step">

<h5>Anamnesi Remota</h5>

<div>
	<asp:Label ID="lblMsg" Runat="server"></asp:Label></div>
	
	
<asp:Panel ID="pnEditing" Runat="server" Visible="False">
<DIV class="bloccoForm"><SPAN class="etichetta">Data:</SPAN><ASP:TEXTBOX id="txtData" Runat="server" Width="80" MaxLength="10" ReadOnly="False"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Tipo:</SPAN><ASP:DROPDOWNLIST id="ddlTipo" Runat="server"><ASP:LISTITEM Value="0">Selziona un tipo di 
anamnesi</ASP:LISTITEM> </ASP:DROPDOWNLIST></DIV>
<DIV class="bloccoForm">Descrizione:<BR><ASP:TEXTBOX id="taDescrizione" Runat="server" Width="500" Height="200" TextMode="MultiLine"></ASP:TEXTBOX></DIV>
<DIV class="bloccoSubmit"><ASP:BUTTON id="cmdSalva" onclick="Salva_Dati" Runat="server" CssClass="button"></ASP:BUTTON></DIV>
	
</asp:Panel>

<asp:Panel ID="pnShow" Runat="server" Visible="False">
<DIV class="bloccoForm"><SPAN class="etichettaShow">Data:</SPAN> <asp:Label id="lblData" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><SPAN class="etichettaShow">Tipo:</SPAN> <asp:Label id="lblTipo" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm">Descrizione:</SPAN> 
<DIV 
class="csMemo"><asp:Label id="lblDescrizione" Runat="server"></asp:Label></DIV></DIV>
<DIV class="contextLink"><asp:HyperLink id="hlUpd" Runat="server">&gt;&gt; Modifica Anamnesi Remota</asp:HyperLink></DIV>
</asp:Panel>

<asp:Panel ID="pnIsNull" Runat="server" Visible="False"><asp:HyperLink id="hlAdd" Runat="server">Inserisci anamesi remota</asp:HyperLink>
</asp:Panel>

</div>
