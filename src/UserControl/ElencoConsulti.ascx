<%@ Control Language="c#" AutoEventWireup="True" Codebehind="ElencoConsulti.ascx.cs" Inherits="Steve.UserControl.ElencoConsulti" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<div class="stepNoFloat">

<h5>Elenco Consulti</h5>

<asp:Panel ID="pnConsulti" Runat="server">
	<asp:Label id="lblNoConsulti" Runat="server" Visible="False">
		Non vi sono consulti registrati per questo paziente</asp:Label>
	
	<asp:DataGrid id="dg1" DataKeyField="ID" Width="500" HeaderStyle-CssClass="trHeader" OnItemCommand="Item_Command" OnItemDataBound="Item_Data_Bound" Runat="server" AutoGenerateColumns="False">
		<ItemStyle CssClass="rowD"></ItemStyle>
		<AlternatingItemStyle CssClass="rowP"></AlternatingItemStyle>
		<Columns>
			<asp:BoundColumn DataField="data" HeaderStyle-CssClass="tdHeader" HeaderText="data" DataFormatString="{0:d}"></asp:BoundColumn>		
			<asp:BoundColumn DataField="problema_iniziale" HeaderStyle-CssClass="tdHeader" HeaderText="problema iniziale"></asp:BoundColumn>
			<asp:ButtonColumn ButtonType="PushButton" HeaderText="Dettagli" ItemStyle-HorizontalAlign="Center" CommandName="dettagli" Text="&gt;&gt;"></asp:ButtonColumn>
			<asp:ButtonColumn ButtonType="PushButton" HeaderText="Mofifica" ItemStyle-HorizontalAlign="Center" CommandName="modifica" Text="&gt;&gt;"></asp:ButtonColumn>
			<asp:ButtonColumn ButtonType="PushButton" HeaderText="Anam. Pross." ItemStyle-HorizontalAlign="Center" CommandName="add_ap" Text="Add"></asp:ButtonColumn>
		</Columns>
	</asp:DataGrid>
	
	<div class="contextLink">
		<asp:HyperLink id="hlAdd" Runat="server" >&gt;&gt; Inserisci Consulto</asp:HyperLink></div>	
</asp:Panel>

</div>

