<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="Trattamento.ascx.cs" Inherits="Steve.UserControl.Trattamento" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<div class="panel panel-default">
	<div class="panel-heading">Trattamento</div>
	<div class="panel-body">

		<div>
			<asp:Label ID="lblMsg" runat="server"></asp:Label>
		</div>


		<asp:Panel ID="pnEditing" runat="server" Visible="False">
			<div class="form-group">
				<asp:Label AssociatedControlID="txtData" runat="server">Data:</asp:Label>
				<asp:TextBox ID="txtData" runat="server" CssClass="form-control" Width="100" MaxLength="10" ReadOnly="False"></asp:TextBox>
<script>
	$(function () {
		$("#<%= txtData.ClientID %>").datepicker({ dateFormat: "dd/mm/yy" });
		$("#<%= txtData.ClientID %>").datepicker("setDate", "<%= txtData.Text %>");
});
</script>			
			</div>
			<div class="form-group">
				<asp:Label AssociatedControlID="txtDescrizione" runat="server">Descrizione:</asp:Label>
				<asp:TextBox ID="txtDescrizione" runat="server" CssClass="form-control" Width="500" Height="200" TextMode="MultiLine"></asp:TextBox>
			</div>
				<asp:Button ID="cmdSalva" OnClick="Salva_Dati" CssClass="btn btn-primary" runat="server"></asp:Button>
		</asp:Panel>

		<asp:Panel ID="pnShow" runat="server" Visible="False">
			<div class="form-group">
				<span class="etichettaShow">Data:</span>
				<asp:Label ID="lblData" runat="server"></asp:Label>
			</div>
			<div class="form-group">
				<span class="etichettaShow">Descrizione:</span><div class="csMemo">
					<asp:Label ID="lblDescrizione" runat="server"></asp:Label>
				</div>
			</div>
			<div class="contextLink">
				<asp:HyperLink ID="hlUpd" runat="server">&gt;&gt; Modifica Trattamento</asp:HyperLink>
			</div>
		</asp:Panel>

		<asp:Panel ID="pnIsNull" runat="server" Visible="False">
			<asp:HyperLink ID="hlAdd" runat="server">Inserisci Trattamento</asp:HyperLink>
		</asp:Panel>

	</div>
</div>
