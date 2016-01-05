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
					<span class="etichetta">Prima Volta:</span><asp:TextBox ID="txtPrimaVolta" runat="server"></asp:TextBox>
				</div>
				<div class="form-group">
					<span class="etichetta">Tipologia:</span><asp:TextBox ID="txtTipologia" runat="server"></asp:TextBox>
				</div>
				<div class="form-group">
					<span class="etichetta">Localizzazione:</span><asp:TextBox ID="txtLocalizzazione" runat="server"></asp:TextBox>
				</div>
				<div class="form-group">
					<span class="etichetta">Irradiazione:</span><asp:TextBox ID="txtIrradiazione" runat="server"></asp:TextBox>
				</div>
				<div class="form-group">
					<span class="etichetta">Periodo Insorgenza:</span><asp:TextBox ID="txtPeriodoInsorgenza" runat="server"></asp:TextBox>
				</div>
				<div class="form-group">
					<span class="etichetta">Durata:</span><asp:TextBox ID="txtDurata" runat="server"></asp:TextBox>
				</div>
				<div class="form-group">
					<span class="etichetta">Familiarità:</span><asp:TextBox ID="txtFamiliarita" runat="server"></asp:TextBox>
				</div>
				<div class="form-group">
					<span class="etichetta">Altre Terapie:</span><asp:TextBox ID="txtAltreTerapie" runat="server"></asp:TextBox>
				</div>
				<div class="form-group">
					Varie:<br>
					<asp:TextBox ID="txtVarie" runat="server" Width="500" Height="200" TextMode="MultiLine"></asp:TextBox>
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


