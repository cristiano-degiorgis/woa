<%@ Control Language="c#" AutoEventWireup="false" Inherits="Steve.UserControl.ElencoAnamnesiRemote" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<div class="step">

<h5>Elenco Anamnesi Remote</h5>
<div>
	<asp:Label ID="lblNoItem" Runat="server" Visible="False">No sono stati ancora inseriti esami per questo consulto</asp:Label></div>
	
<asp:DataGrid id="dg1" DataKeyField="ID" Width="500" HeaderStyle-CssClass="trHeader" AutoGenerateColumns="false" OnItemCommand="Item_Command" Runat="server">
	<ItemStyle CssClass="rowD"></ItemStyle>
	<AlternatingItemStyle CssClass="rowP"></AlternatingItemStyle>
	<Columns>
		<asp:BoundColumn DataField="data" ItemStyle-Width="1%" HeaderStyle-CssClass="tdHeader" ItemStyle-VerticalAlign="Top" HeaderText="data" DataFormatString="{0:d}"></asp:BoundColumn>		
		<asp:BoundColumn DataField="descrizione" ItemStyle-Width="96%" HeaderStyle-CssClass="tdHeader" ItemStyle-VerticalAlign="Top" HeaderText="descrizione"></asp:BoundColumn>
		<asp:BoundColumn DataField="tipo_anamnesi" ItemStyle-Width="1%" HeaderStyle-CssClass="tdHeader" ItemStyle-VerticalAlign="Top" HeaderText="tipo"></asp:BoundColumn>

		<asp:ButtonColumn ButtonType="PushButton" HeaderText="Dettagli" ItemStyle-Width="1%" ItemStyle-HorizontalAlign="Center" CommandName="mostra" Text="&gt;&gt;"></asp:ButtonColumn>
		<asp:ButtonColumn ButtonType="PushButton" HeaderText="Mofifica" ItemStyle-Width="1%" ItemStyle-HorizontalAlign="Center" CommandName="modifica" Text="&gt;&gt;"></asp:ButtonColumn>
	</Columns>
</asp:DataGrid>

	<div class="contextLink">
		<asp:HyperLink id="hlAdd" Runat="server" >&gt;&gt; Inserisci Anamnesi Remota</asp:HyperLink></div>	

</div>
