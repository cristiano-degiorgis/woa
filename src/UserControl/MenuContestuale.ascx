<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="MenuContestuale.ascx.cs" Inherits="Steve.UserControl.MenuContestuale" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

	<asp:Repeater ID="rptLinks" runat="server">
		<HeaderTemplate>
			<ul class="dropdown-menu">
		</HeaderTemplate>
		<ItemTemplate>
			<li>
				<a href="<%# DataBinder.Eval(Container.DataItem, "Url") %>">
					<%# DataBinder.Eval(Container.DataItem, "Text") %>
				</a>
			</li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>

