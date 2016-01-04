<%@ Control Language="c#" AutoEventWireup="false" Inherits="Steve.UserControl.ElencoAnamnesiRemote" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

	<h5>Elenco Anamnesi Remote</h5>
	<div>
		<asp:Label ID="lblNoItem" Runat="server" Visible="False">No sono stati ancora inseriti esami per questo consulto</asp:Label>
	</div>

	<asp:DataGrid id="dg1" 
		DataKeyField="ID" HeaderStyle-CssClass="trHeader" AutoGenerateColumns="false"
		 OnItemCommand="Item_Command" Runat="server"
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
		<asp:HyperLink id="hlAdd" Runat="server">&gt;&gt; Inserisci Anamnesi Remota</asp:HyperLink>
	</div>

