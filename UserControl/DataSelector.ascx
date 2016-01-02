<%@ Control Language="c#" AutoEventWireup="false" Codebehind="DataSelector.ascx.cs" Inherits="Steve.UserControl.DataSelector" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<SCRIPT language=javascript src="/steve/js/calendar.js"></SCRIPT>
<INPUT id="hfData1" type="hidden" name="hfData1" runat="server"> 
<INPUT id="hfData2" type="hidden" name="hfData2" runat="server"> 

<SPAN id="lblData1" Runat="server"></SPAN>
<asp:Literal ID="ltImg1" Runat="server"></asp:Literal>
<SPAN id="lblData2" Runat="server" Visible="False"></SPAN>
<asp:Literal ID="ltImg2" Runat="server" Visible="False"></asp:Literal>
