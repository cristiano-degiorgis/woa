<%@ Control Language="c#" AutoEventWireup="false" Inherits="Steve.UserControl.ElencoValutazioni" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<div class="stepNoFloat">

<h5>Elenco Valutazioni</h5>
<div>
	<asp:Label ID="lblNoItem" Runat="server" Visible="False">No sono stati ancora inseriti valutazioni per questo consulto</asp:Label></div>
	
<asp:DataGrid id="dg1" Width="500" HeaderStyle-CssClass="trHeader" AutoGenerateColumns="false" DataKeyField="ID" OnItemCommand="Item_Command" Runat="server">

	<ItemStyle CssClass="rowD"></ItemStyle>
	<AlternatingItemStyle CssClass="rowP"></AlternatingItemStyle>
	<Columns>
		<asp:BoundColumn DataField="strutturale" ItemStyle-Width="33%" HeaderStyle-CssClass="tdHeader" HeaderText="strutturale" ItemStyle-VerticalAlign="Top"></asp:BoundColumn>		
		<asp:BoundColumn DataField="cranio_sacrale" ItemStyle-Width="33%" HeaderStyle-CssClass="tdHeader" HeaderText="cranio sacrale" ItemStyle-VerticalAlign="Top"></asp:BoundColumn>		
		<asp:BoundColumn DataField="ak_ortodontica" ItemStyle-Width="32%" HeaderStyle-CssClass="tdHeader" ItemStyle-VerticalAlign="Top" HeaderText="AK Ortodontica"></asp:BoundColumn>
	
		<asp:ButtonColumn ButtonType="PushButton" HeaderText="Dettagli" ItemStyle-Width="1%" ItemStyle-HorizontalAlign="Center" CommandName="mostra" Text="&gt;&gt;"></asp:ButtonColumn>	
		<asp:ButtonColumn ButtonType="PushButton" HeaderText="Mofifica" ItemStyle-Width="1%" ItemStyle-HorizontalAlign="Center" CommandName="modifica" Text="&gt;&gt;"></asp:ButtonColumn>
</Columns>
</asp:DataGrid>

	<div class="contextLink">
		<asp:HyperLink id="hlAdd" Runat="server" >&gt;&gt; Inserisci Valutazione</asp:HyperLink></div>	
</div>
