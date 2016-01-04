<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="MenuContestuale.ascx.cs" Inherits="Steve.UserControl.MenuContestuale" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<div id="divMenuContestuale" class="MenuContestuale" runat="server">
	<asp:Repeater ID="rptLinks" runat="server">
		<ItemTemplate>
			<div class="item">
				<a href="<%# DataBinder.Eval(Container.DataItem, "Url") %>">
					<%# DataBinder.Eval(Container.DataItem, "Text") %>
				</a>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
