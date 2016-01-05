<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="AnamnesiProssima.ascx.cs" Inherits="Steve.UserControl.AnamnesiProssima" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<div class="panel panel-default">
	<div class="panel-heading">Anamnesi Prossima</div>
	<div class="panel-body">

		<div>
			<asp:Label ID="lblMsg" runat="server"></asp:Label>
		</div>

		<div class="container">
			<div class="row">
				<asp:Panel ID="pnEditing" runat="server" Visible="False">
					<div class="col-md-8">
						<div class="form-group">
							<asp:Label AssociatedControlID="txtPrimaVolta" runat="server">Prima Volta:</asp:Label>
							<asp:TextBox ID="txtPrimaVolta" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtTipologia" runat="server">Tipologia:</asp:Label>
							<asp:TextBox ID="txtTipologia" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtLocalizzazione" runat="server">Localizzazione:</asp:Label>
							<asp:TextBox ID="txtLocalizzazione" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtIrradiazione" runat="server">Irradiazione:</asp:Label>
							<asp:TextBox ID="txtIrradiazione" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtPeriodoInsorgenza" runat="server">Periodo Insorgenza:</asp:Label>
							<asp:TextBox ID="txtPeriodoInsorgenza" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtDurata" runat="server">Durata:</asp:Label>
							<asp:TextBox ID="txtDurata" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtFamiliarita" runat="server">Familiarità:</asp:Label>
							<asp:TextBox ID="txtFamiliarita" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtAltreTerapie" runat="server">Altre Terapie:</asp:Label>
							<asp:TextBox ID="txtAltreTerapie" CssClass="form-control" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label AssociatedControlID="txtVarie" runat="server">Varie:</asp:Label>
							<asp:TextBox ID="txtVarie" runat="server" CssClass="form-control" Width="500" Height="200" TextMode="MultiLine"></asp:TextBox>
						</div>
						<asp:Button ID="cmdSalva" OnClick="Salva_Dati" CssClass="btn btn-primary" runat="server"></asp:Button>
					</div>
				</asp:Panel>

				<asp:Panel ID="pnShow" runat="server" Visible="False">
					<div class="col-md-8">
						<div class="form-group">
							<span class="etichettaShow">Prima Volta:</span>
							<asp:Label ID="lblPrimaVolta" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Tipologia:</span>
							<asp:Label ID="lblTipologia" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Localizzazione:</span>
							<asp:Label ID="lblLocalizzazione" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Irradiazione:</span>
							<asp:Label ID="lblIrradiazione" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Periodo Insorgenza:</span>
							<asp:Label ID="lblPeriodoInsorgenza" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Durata: 
							<asp:Label ID="lblDurata" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Familiarità:</span>
							<asp:Label ID="lblFamiliarita" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Altre Terapie:</span>
							<asp:Label ID="lblAltreTerapie" runat="server"></asp:Label>
						</div>
						<div class="form-group">
							<span class="etichettaShow">Varie:</span><div class="csMemo">
								<asp:Label ID="lblVarie" runat="server"></asp:Label>
							</div>
						</div>
						<div class="contextLink">
							<asp:HyperLink ID="hlUpd" runat="server">&gt;&gt; Modifica Anamnesi Prossima</asp:HyperLink>
						</div>
					</div>
				</asp:Panel>


				<asp:Panel ID="pnIsNull" runat="server" Visible="False">
					<div class="col-md-8">
						<asp:HyperLink ID="hlAdd" runat="server">Inserisci anamesi prossima</asp:HyperLink>
					</div>
				</asp:Panel>

			</div>
		</div>

	</div>
</div>


