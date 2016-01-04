<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="Consulto.ascx.cs" Inherits="Steve.UserControl.Consulto" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<h5>Consulto</h5>

<div>
	<asp:Label ID="lblMsg" runat="server"></asp:Label>
</div>

<div class="container">
	<div class="row">
		<asp:Panel ID="pnEditing" runat="server" Visible="False">
			<div class="col-md-8">
				<div class="form-group">
					<asp:Label AssociatedControlID="txtData" runat="server">Data:</asp:Label>
					<asp:TextBox ID="txtData" runat="server" CssClass="form-control" ReadOnly="False" Width="100" MaxLength="10"></asp:TextBox>
				</div>
				<div class="form-group">
					<asp:Label AssociatedControlID="txtProblema" runat="server">Problema Iniziale:</asp:Label>
					<asp:TextBox ID="txtProblema" runat="server" CssClass="form-control" Width="500" Height="200" TextMode="MultiLine"></asp:TextBox>
				</div>
				<asp:Button ID="cmdSalva" OnClick="Salva_Dati" CssClass="button" runat="server"></asp:Button>
			</div>
		</asp:Panel>

		<asp:Panel ID="pnShow" runat="server" Visible="False">
			<div class="col-md-6">
				<div class="form-group">
					<span class="etichettaShow">Data:</span>
					<asp:Label ID="lblData" runat="server"></asp:Label>
				</div>
				<div class="form-group">
					<span class="etichettaShow">Problema Iniziale:</span>
					<div class="csMemo">
						<asp:Label ID="lblProblema" runat="server"></asp:Label>
					</div>
				</div>
				<div class="contextLink">
					<asp:HyperLink ID="hlUpd" runat="server">&gt;&gt; Modifica Consulto</asp:HyperLink>
				</div>

				<asp:Panel ID="pnIsNull" runat="server" CssClass="contextLink" Visible="False">
					<asp:HyperLink ID="hlAdd" runat="server">&gt;&gt; Inserisci Consulto</asp:HyperLink>
				</asp:Panel>
			</div>
		</asp:Panel>
	</div>
</div>
