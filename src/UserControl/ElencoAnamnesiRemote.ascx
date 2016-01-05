<%@ Control Language="c#" AutoEventWireup="false" Inherits="Steve.UserControl.ElencoAnamnesiRemote" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<div class="panel panel-default">
	<div class="panel-heading">Anamnesi Remote</div>
	<div class="panel-body">
		<div>
			<asp:Label ID="lblNoItem" runat="server" Visible="False">No sono stati ancora inseriti esami per questo consulto</asp:Label>
		</div>

		<asp:DataGrid ID="dg1"
			DataKeyField="ID" HeaderStyle-CssClass="trHeader" AutoGenerateColumns="false"
			OnItemCommand="Item_Command" runat="server"
			CssClass="table table-striped table-bordered table-hover table-condensed">
			<ItemStyle CssClass="rowD"></ItemStyle>
			<AlternatingItemStyle CssClass="rowP"></AlternatingItemStyle>
			<Columns>
				<asp:BoundColumn DataField="data" HeaderStyle-CssClass="tdHeader" ItemStyle-VerticalAlign="Top" HeaderText="data" DataFormatString="{0:d}"></asp:BoundColumn>
				<asp:BoundColumn DataField="descrizione" HeaderStyle-CssClass="tdHeader" HeaderText="descrizione"></asp:BoundColumn>
				<asp:BoundColumn DataField="tipo_anamnesi" HeaderStyle-CssClass="tdHeader" HeaderText="tipo"></asp:BoundColumn>

				<asp:ButtonColumn ButtonType="PushButton" HeaderText="Dettagli" ItemStyle-HorizontalAlign="Center" CommandName="mostra" Text="&gt;&gt;"></asp:ButtonColumn>
				<asp:ButtonColumn ButtonType="PushButton" HeaderText="Mofifica" ItemStyle-HorizontalAlign="Center" CommandName="modifica" Text="&gt;&gt;"></asp:ButtonColumn>
			</Columns>
		</asp:DataGrid>

		<div class="contextLink">
			<asp:HyperLink ID="hlAdd" runat="server">&gt;&gt; Inserisci Anamnesi Remota</asp:HyperLink>
		</div>

	</div>
</div>

