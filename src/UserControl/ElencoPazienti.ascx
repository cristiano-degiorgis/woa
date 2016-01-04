<%@ Control Language="c#" AutoEventWireup="True" Codebehind="ElencoPazienti.ascx.cs" Inherits="Steve.UserControl.ElencoPazienti" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<div>
	<asp:Label ID="lblMsg" Runat="server" Visible="False"></asp:Label>

	<asp:DataGrid
		id="dg1"
		OnSortCommand="Dg1_Sort"
		OnPageIndexChanged="Dg1_Page"
		PageSize="30"
		AllowPaging="True"
		AllowSorting="True"
		DataSource="<%# view %>"
		DataKeyField="ID"
		OnItemCommand="Item_Command"
		OnItemCreated="Item_Created"
		Runat="server"
		HeaderStyle-CssClass="trHeader"
		AutoGenerateColumns="False"
		CssClass="table table-striped table-bordered table-hover table-condensed">
		<ItemStyle CssClass="rowD"></ItemStyle>
		<AlternatingItemStyle CssClass="rowP"></AlternatingItemStyle>

		<PagerStyle
			nextpagetext="Next Page &gt;&gt;"
			prevpagetext="&lt;&lt; Page Prev."
			horizontalalign="Right"
			position="TopAndBottom"
			backcolor="#ffffff"
			PageButtonCount="10"
			Mode="NextPrev"
			Font-Size="0.9em"/>

		<Columns>
			<asp:BoundColumn DataField="nome" HeaderStyle-CssClass="tdHeader" HeaderText="nome"></asp:BoundColumn>
			<asp:BoundColumn DataField="cognome" SortExpression="cognome" HeaderStyle-CssClass="tdHeader" HeaderText="cognome"></asp:BoundColumn>
			<asp:BoundColumn DataField="data_nascita" HeaderStyle-CssClass="tdHeader" HeaderText="data nascita" DataFormatString="{0:d}"></asp:BoundColumn>
			<asp:BoundColumn DataField="professione" HeaderStyle-CssClass="tdHeader" HeaderText="professione"></asp:BoundColumn>
			<asp:BoundColumn DataField="citta" HeaderStyle-CssClass="tdHeader" HeaderText="citta"></asp:BoundColumn>
			<asp:ButtonColumn ButtonType="PushButton" CommandName="modifica" Text="&gt;&gt;" ItemStyle-HorizontalAlign="Center" HeaderText="Modifica"></asp:ButtonColumn>
			<asp:ButtonColumn ButtonType="PushButton" CommandName="dettagli" Text="&gt;&gt;" ItemStyle-HorizontalAlign="Center" HeaderText="Dettagli"></asp:ButtonColumn>
			<asp:ButtonColumn ButtonType="PushButton" CommandName="elimina" Text="&gt;&gt;" ItemStyle-HorizontalAlign="Center" HeaderText="Elimina"></asp:ButtonColumn>
		</Columns>
	</asp:DataGrid>
</div>