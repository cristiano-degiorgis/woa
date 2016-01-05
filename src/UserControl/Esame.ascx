<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="Esame.ascx.cs" Inherits="Steve.UserControl.Esame" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<div class="panel panel-default">
	<div class="panel-heading">Esame</div>
	<div class="panel-body">

		<div>
			<asp:Label ID="lblMsg" runat="server"></asp:Label>
		</div>


		<asp:Panel ID="pnEditing" runat="server" Visible="False">
			<div class="form-group">
				<asp:Label AssociatedControlID="txtData" runat="server">Data:</asp:Label>
				<asp:TextBox ID="txtData" runat="server" Width="100" CssClass="form-control" ReadOnly="False"></asp:TextBox>
			</div>
			<div class="form-group">
				<asp:Label AssociatedControlID="ddlTipo" runat="server">Tipo:</asp:Label>
				<asp:DropDownList ID="ddlTipo" CssClass="form-control" runat="server">
					<asp:ListItem Value="0">
					Selziona un tipo di
					esame
					</asp:ListItem>
				</asp:DropDownList>
			</div>
			<div class="form-group">
				<asp:Label AssociatedControlID="txtDescrizione" runat="server">Descrizione:</asp:Label>
				<asp:TextBox ID="txtDescrizione" runat="server" Width="500" Height="200" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
			</div>
				<asp:Button ID="cmdSalva" OnClick="Salva_Dati" CssClass="btn btn-primary" runat="server"></asp:Button>
		</asp:Panel>

		<asp:Panel ID="pnShow" runat="server" Visible="False">
			<div class="form-group">
				<span class="etichettaShow">Data:</span>
				<asp:Label ID="lblData" runat="server"></asp:Label>
			</div>
			<div class="form-group">
				<span class="etichettaShow">Tipo:</span>
				<asp:Label ID="lblTipo" runat="server"></asp:Label>
			</div>
			<div class="form-group">
				<span class="etichettaShow">Descrizione:</span><div class="csMemo">
					<asp:Label ID="lblDescrizione" runat="server"></asp:Label>
				</div>
			</div>
			<div class="contextLink">
				<asp:HyperLink ID="hlUpd" runat="server">&gt;&gt; Modifica Esame</asp:HyperLink>
			</div>
		</asp:Panel>

		<asp:Panel ID="pnIsNull" runat="server" Visible="False">
			<asp:HyperLink ID="hlAdd" runat="server">Inserisci Esame</asp:HyperLink>
		</asp:Panel>

	</div>
</div>
