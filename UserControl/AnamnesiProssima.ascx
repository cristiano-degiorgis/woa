<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AnamnesiProssima.ascx.cs" Inherits="Steve.UserControl.AnamnesiProssima" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<div class="step">

<h5>Anamnesi Prossima</h5>

<div>
	<asp:Label ID="lblMsg" Runat="server"></asp:Label></div>
	
	
<asp:Panel ID="pnEditing" Runat="server" Visible="False">
<DIV class="bloccoForm"><SPAN class="etichetta">Prima Volta:</span><ASP:TEXTBOX id="txtPrimaVolta" Runat="server"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Tipologia:</span><ASP:TEXTBOX id="txtTipologia" Runat="server"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Localizzazione:</span><ASP:TEXTBOX id="txtLocalizzazione" Runat="server"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Irradiazione:</span><ASP:TEXTBOX id="txtIrradiazione" Runat="server"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Periodo Insorgenza:</span><ASP:TEXTBOX id="txtPeriodoInsorgenza" Runat="server"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Durata:</span><ASP:TEXTBOX id="txtDurata" Runat="server"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Familiarità:</span><ASP:TEXTBOX id="txtFamiliarita" Runat="server"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Altre Terapie:</span><ASP:TEXTBOX id="txtAltreTerapie" Runat="server"></ASP:TEXTBOX></DIV>
<DIV class="bloccoForm">Varie:<BR><ASP:TEXTBOX id="txtVarie" Runat="server" Width="500" Height="200" TextMode="MultiLine"></ASP:TEXTBOX></DIV>
<DIV class="bloccoSubmit"><ASP:BUTTON id="cmdSalva" onclick="Salva_Dati" CssClass="button" Runat="server"></ASP:BUTTON></DIV>
</asp:Panel>

<asp:Panel ID="pnShow" Runat="server" Visible="False">
<DIV class="bloccoForm"><span class="etichettaShow">Prima Volta:</span> <asp:Label id="lblPrimaVolta" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><span class="etichettaShow">Tipologia:</span> <asp:Label id="lblTipologia" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><span class="etichettaShow">Localizzazione:</span> <asp:Label id="lblLocalizzazione" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><span class="etichettaShow">Irradiazione:</span> <asp:Label id="lblIrradiazione" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><span class="etichettaShow">Periodo Insorgenza:</span> <asp:Label id="lblPeriodoInsorgenza" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><span class="etichettaShow">Durata: 
<asp:Label id="lblDurata" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><span class="etichettaShow">Familiarità:</span> <asp:Label id="lblFamiliarita" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><span class="etichettaShow">Altre Terapie:</span> <asp:Label id="lblAltreTerapie" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><span class="etichettaShow">Varie:</span><div class="csMemo"><asp:Label id="lblVarie" Runat="server"></asp:Label></div></DIV>
<DIV class="contextLink">
	<asp:HyperLink id="hlUpd" Runat="server">&gt;&gt; Modifica Anamnesi Prossima</asp:HyperLink></DIV>
</asp:Panel>


<asp:Panel ID="pnIsNull" Runat="server" Visible="False"><asp:HyperLink id="hlAdd" Runat="server">Inserisci anamesi prossima</asp:HyperLink>
</asp:Panel>

</div>
