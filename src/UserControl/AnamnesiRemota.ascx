<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="AnamnesiRemota.ascx.cs" Inherits="Steve.UserControl.AnamnesiRemota" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<div class="panel panel-default">
	<div class="panel-heading">Anamnesi Remota</div>
	<div class="panel-body">

		<div>
			<asp:Label ID="lblMsg" runat="server"></asp:Label>
		</div>

		<div class="container">
			<div class="row">
				<asp:Panel ID="pnEditing" runat="server" Visible="False">
					<div class="col-md-8">
						<div class="form-group">
							<asp:Label AssociatedControlID="txtData" CssClass="etichetta" runat="server">Data:</asp:Label>
							<asp:TextBox ID="txtData" runat="server" CssClass="form-control" Width="100" MaxLength="10" ReadOnly="False"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="ddlTipo" CssClass="etichetta" runat="server">Tipo:</asp:Label>
							<asp:DropDownList ID="ddlTipo" CssClass="form-control" runat="server">
								<asp:ListItem Value="0">
				Selziona un tipo di
				anamnesi
								</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="taDescrizione" CssClass="etichetta" runat="server">Descrizione:</asp:Label>
							<asp:TextBox ID="taDescrizione" runat="server" CssClass="form-control" Width="500" Height="200" TextMode="MultiLine"></asp:TextBox>
						</div>
						<asp:Button ID="cmdSalva" OnClick="Salva_Dati" CssClass="btn btn-primary" runat="server"></asp:Button>
					</div>
				</asp:Panel>

				<asp:Panel ID="pnShow" runat="server" Visible="False">
					<div class="col-md-8">
						<div class="form-group">
							<span class="etichettaShow">Data:</span>
							<asp:Label ID="lblData" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Tipo:</span>
							<asp:Label ID="lblTipo" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							Descrizione:</SPAN>
		<div
			class="csMemo">
			<asp:Label ID="lblDescrizione" runat="server"></asp:Label>
		</div>
						</div>
						<div class="contextLink">
							<asp:HyperLink ID="hlUpd" runat="server">&gt;&gt; Modifica Anamnesi Remota</asp:HyperLink>
						</div>

						<asp:Panel ID="pnIsNull" runat="server" Visible="False">
							<asp:HyperLink ID="hlAdd" runat="server">Inserisci anamesi remota</asp:HyperLink>
						</asp:Panel>
					</div>
				</asp:Panel>
			</div>
		</div>

	</div>
</div>
