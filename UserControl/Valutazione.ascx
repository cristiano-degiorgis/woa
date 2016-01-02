<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Valutazione.ascx.cs" Inherits="Steve.UserControl.Valutazione" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<div class="step">

<h5>Valutazione</h5>

<div>
	<asp:Label ID="lblMsg" Runat="server"></asp:Label></div>
	
	
<asp:Panel ID="pnEditing" Runat="server" Visible="False">
<DIV class="bloccoForm">Strutturale:<BR><ASP:TEXTBOX id="txtStrutturale" Runat="server" TextMode="MultiLine" Height="200" Width="500"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm">Cranio Sacrale:<BR><ASP:TEXTBOX id="txtCranioSacrale" Runat="server" TextMode="MultiLine" Height="200" Width="500"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm">Ak Ortodontica:<BR><ASP:TEXTBOX id="txtAkOrtodontica" Runat="server" TextMode="MultiLine" Height="200" Width="500"></ASP:TEXTBOX></DIV>
<DIV class="bloccoSubmit"><ASP:BUTTON id="cmdSalva" onclick="Salva_Dati" CssClass="button" Runat="server"></ASP:BUTTON></DIV>
</asp:Panel>

<asp:Panel ID="pnShow" Runat="server" Visible="False">
<DIV class="bloccoForm"><span class="etichettaShow">Strutturale:</span><div class="csMemo"><asp:Label id="lblStrutturale" Runat="server"></asp:Label></div></DIV>
<DIV class="bloccoForm"><span class="etichettaShow">Cranio Sacrale:</span><div class="csMemo"><asp:Label id="lblCranioSacrale" Runat="server"></asp:Label></div></DIV>
<DIV class="bloccoForm"><span class="etichettaShow">Ak Ortodontica:</span><div class="csMemo"><asp:Label id="lblAkOrtodontica" Runat="server"></asp:Label></div></DIV>
<DIV class="contextLink"><asp:HyperLink id="hlUpd" Runat="server">&gt;&gt; Modifica Valutazione</asp:HyperLink></DIV>
</asp:Panel>

<asp:Panel ID="pnIsNull" Runat="server" Visible="False"><asp:HyperLink id="hlAdd" Runat="server">Inserisci Valutazione</asp:HyperLink>
</asp:Panel>

</div>
