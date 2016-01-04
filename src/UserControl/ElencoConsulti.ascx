<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="ElencoConsulti.ascx.cs" Inherits="Steve.UserControl.ElencoConsulti" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<h5>Elenco Consulti</h5>
<asp:Panel ID="pnConsulti" runat="server">
	<asp:Label ID="lblNoConsulti" runat="server" Visible="False">
			Non vi sono consulti registrati per questo paziente
	</asp:Label>

	<asp:DataGrid ID="dg1" DataKeyField="ID" HeaderStyle-CssClass="trHeader"
		OnItemCommand="Item_Command" OnItemDataBound="Item_Data_Bound" runat="server"
		AutoGenerateColumns="False"
		CssClass="table table-striped table-bordered table-hover table-condensed">
		<ItemStyle CssClass="rowD"></ItemStyle>
		<AlternatingItemStyle CssClass="rowP"></AlternatingItemStyle>
		<Columns>
			<asp:BoundColumn DataField="data" HeaderStyle-CssClass="tdHeader" HeaderText="data" DataFormatString="{0:d}"></asp:BoundColumn>
			<asp:BoundColumn DataField="problema_iniziale" HeaderStyle-CssClass="tdHeader" HeaderText="problema iniziale"></asp:BoundColumn>
			<asp:ButtonColumn ButtonType="PushButton" HeaderText="Dettagli" CommandName="dettagli" Text="&gt;&gt;"></asp:ButtonColumn>
			<asp:ButtonColumn ButtonType="PushButton" HeaderText="Mofifica" CommandName="modifica" Text="&gt;&gt;"></asp:ButtonColumn>
			<asp:ButtonColumn ButtonType="PushButton" HeaderText="Anam. Pross." CommandName="add_ap" Text="Add"></asp:ButtonColumn>
		</Columns>
	</asp:DataGrid>

	<div class="contextLink">
		<asp:HyperLink ID="hlAdd" runat="server">&gt;&gt; Inserisci Consulto</asp:HyperLink>
	</div>
</asp:Panel>

