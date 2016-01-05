<%@ Control Language="c#" AutoEventWireup="false" Inherits="Steve.UserControl.ElencoTrattamenti" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<div class="panel panel-default">
	<div class="panel-heading">Trattamenti</div>
	<div class="panel-body">
		<div>
			<asp:Label ID="lblNoItem" runat="server" Visible="False">No sono stati ancora inseriti trattamenti per questo consulto</asp:Label>
		</div>

		<asp:DataGrid ID="dg1" 
			CssClass="table table-striped table-bordered table-hover table-condensed"
			HeaderStyle-CssClass="trHeader" AutoGenerateColumns="false" DataKeyField="ID" OnItemCommand="Item_Command" runat="server">

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
			<asp:HyperLink ID="hlAdd" runat="server">&gt;&gt; Inserisci Trattamento</asp:HyperLink>
		</div>

	</div>
</div>
