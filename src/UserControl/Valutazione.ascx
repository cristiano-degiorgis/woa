<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="Valutazione.ascx.cs" Inherits="Steve.UserControl.Valutazione" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<div class="panel panel-default">
	<div class="panel-heading">Trattamento</div>
	<div class="panel-body">

		<div>
			<asp:Label ID="lblMsg" runat="server"></asp:Label>
		</div>


		<asp:Panel ID="pnEditing" runat="server" Visible="False">
			<div class="form-group">
				<asp:Label AssociatedControlID="txtStrutturale" runat="server">Strutturale:</asp:Label>
				<asp:TextBox ID="txtStrutturale" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200" Width="500"></asp:TextBox>
			</div>
			<div class="form-group">
				<asp:Label AssociatedControlID="txtCranioSacrale" runat="server">Cranio Sacrale:</asp:Label>
				<asp:TextBox ID="txtCranioSacrale" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200" Width="500"></asp:TextBox>
			</div>
			<div class="form-group">
				<asp:Label AssociatedControlID="txtAkOrtodontica" runat="server">Ak Ortodontica:</asp:Label>
				<asp:TextBox ID="txtAkOrtodontica" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200" Width="500"></asp:TextBox>
			</div>
			<asp:Button ID="cmdSalva" OnClick="Salva_Dati" CssClass="btn btn-primary" runat="server"></asp:Button>
		</asp:Panel>

		<asp:Panel ID="pnShow" runat="server" Visible="False">
			<div class="form-group">
				<span class="etichettaShow">Strutturale:</span><div class="csMemo">
					<asp:Label ID="lblStrutturale" runat="server"></asp:Label>
				</div>
			</div>
			<div class="form-group">
				<span class="etichettaShow">Cranio Sacrale:</span><div class="csMemo">
					<asp:Label ID="lblCranioSacrale" runat="server"></asp:Label>
				</div>
			</div>
			<div class="form-group">
				<span class="etichettaShow">Ak Ortodontica:</span><div class="csMemo">
					<asp:Label ID="lblAkOrtodontica" runat="server"></asp:Label>
				</div>
			</div>
			<div class="contextLink">
				<asp:HyperLink ID="hlUpd" runat="server">&gt;&gt; Modifica Valutazione</asp:HyperLink>
			</div>
		</asp:Panel>

		<asp:Panel ID="pnIsNull" runat="server" Visible="False">
			<asp:HyperLink ID="hlAdd" runat="server">Inserisci Valutazione</asp:HyperLink>
		</asp:Panel>

	</div>
</div>
