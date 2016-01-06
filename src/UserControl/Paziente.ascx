<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="Paziente.ascx.cs" Inherits="Steve.UserControl.Paziente" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<div class="panel panel-default">
	<div class="panel-heading">Paziente</div>
	<div class="panel-body">

		<div>
			<asp:Label ID="lblMsg" runat="server"></asp:Label>
		</div>

		<div class="container">
			<div class="row">
				<asp:Panel ID="pnEditing" runat="server" Visible="False">

					<div class="col-md-8">
						<div class="form-group">
							<asp:Label AssociatedControlID="txtNome" runat="server">Nome:</asp:Label>
							<asp:TextBox ID="txtNome" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtCognome" runat="server">Cognome:</asp:Label>
							<asp:TextBox ID="txtCognome" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtDataNascita" runat="server">Data di nascita:</asp:Label>
							<asp:TextBox ID="txtDataNascita" runat="server" CssClass="form-control" MaxLength="10" Width="100"></asp:TextBox>
<script>
	$(function () {
		$("#<%= txtDataNascita.ClientID %>").datepicker({ dateFormat: "dd/mm/yy" });
		$("#<%= txtDataNascita.ClientID %>").datepicker("setDate", "<%= txtDataNascita.Text %>");
});
</script>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtProfesione" runat="server">Professione:</asp:Label>
							<asp:TextBox ID="txtProfesione" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtIndirizzo" runat="server">Indirizzo:</asp:Label>
							<asp:TextBox ID="txtIndirizzo" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtCitta" runat="server">Città:</asp:Label>
							<asp:TextBox ID="txtCitta" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="ddlProv" runat="server">Provincia:</asp:Label>
							<asp:DropDownList ID="ddlProv" CssClass="form-control" runat="server">
								<asp:ListItem Value="--">--</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtCap" runat="server">CAP:</asp:Label>
							<asp:TextBox ID="txtCap" CssClass="form-control" runat="server" MaxLength="5" Width="100"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtTel" runat="server">Telefono Fisso:</asp:Label>
							<asp:TextBox ID="txtTel" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtCell" runat="server">Telefono Cell.:</asp:Label>
							<asp:TextBox ID="txtCell" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtEmail" runat="server">Email:</asp:Label>
							<asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
						</div>

						<asp:Button ID="cmdSalva" OnClick="Salva_Dati" runat="server" CssClass="btn btn-primary" Text="Esegui >>"></asp:Button>
					</div>
				</asp:Panel>

				<asp:Panel ID="pnShow" runat="server" Visible="False">

					<div class="col-md-4">
						<div class="form-group">
							<span class="etichettaShow">Nome:</span>
							<asp:Label ID="lblNome" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Cognome:</span>
							<asp:Label ID="lblCognome" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Data di nascita:</span>
							<asp:Label ID="lblDataNascita" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Professione:</span>
							<asp:Label ID="lblProfessione" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Indirizzo:</span>
							<asp:Label ID="lblIndirizzo" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Città:</span>
							<asp:Label ID="lblCitta" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Provincia:</span>
							<asp:Label ID="lblProv" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">CAP:</span>
							<asp:Label ID="lblCap" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Telefono Fisso:</span>
							<asp:Label ID="lblTel" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Telefono Cell.:</span>
							<asp:Label ID="lblCell" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Email.:</span>
							<asp:Label ID="lblEmail" runat="server"></asp:Label>
						</div>
						<div class="contextLink">
							<asp:HyperLink ID="hlUpd" runat="server">&gt;&gt; Modifica Anagrafica Paziente</asp:HyperLink>
						</div>
					</div>
				</asp:Panel>
			</div>
		</div>
	</div>
</div>
