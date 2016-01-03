<%@ Control Language="c#" AutoEventWireup="false" Inherits="Steve.UserControl.ElencoTrattamenti" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<div class="stepNoFloat">

	<h5>Elenco Trattamenti</h5>
	<div>
		<asp:Label ID="lblNoItem" Runat="server" Visible="False">No sono stati ancora inseriti trattamenti per questo consulto</asp:Label>
	</div>

	<asp:DataGrid id="dg1" Width="500" HeaderStyle-CssClass="trHeader" AutoGenerateColumns="false" DataKeyField="ID" OnItemCommand="Item_Command" Runat="server">

		<ItemStyle CssClass="rowD"></ItemStyle>
		<AlternatingItemStyle CssClass="rowP"></AlternatingItemStyle>
		<Columns>
			<asp:BoundColumn DataField="data" ItemStyle-Width="1%" HeaderStyle-CssClass="tdHeader" HeaderText="data" ItemStyle-VerticalAlign="Top" DataFormatString="{0:d}"></asp:BoundColumn>
			<asp:BoundColumn DataField="descrizione" ItemStyle-Width="97%" HeaderStyle-CssClass="tdHeader" ItemStyle-VerticalAlign="Top" HeaderText="descrizione"></asp:BoundColumn>

			<asp:ButtonColumn ButtonType="PushButton" HeaderText="Dettagli" ItemStyle-Width="1%" ItemStyle-HorizontalAlign="Center" CommandName="mostra" Text="&gt;&gt;"></asp:ButtonColumn>
			<asp:ButtonColumn ButtonType="PushButton" ItemStyle-Width="1%" HeaderText="Mofifica" ItemStyle-HorizontalAlign="Center" CommandName="modifica" Text="&gt;&gt;"></asp:ButtonColumn>
		</Columns>
	</asp:DataGrid>

	<div class="contextLink">
		<asp:HyperLink id="hlAdd" Runat="server">&gt;&gt; Inserisci Trattamento</asp:HyperLink>
	</div>

</div>