<%@ Register TagPrefix="uc1" TagName="Testata" Src="~/UserControl/Testata.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuContestuale" Src="~/UserControl/MenuContestuale.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Paziente" Src="~/UserControl/Paziente.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MainMenu" Src="~/UserControl/MainMenu.ascx" %>
<%@ Page language="c#" Codebehind="master.aspx.cs" AutoEventWireup="false" Inherits="Steve.App.master" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>W.O.A.</title>
	<link href="/steve/css/main.css" rel="stylesheet" type="text/css" >
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <SCRIPT language="javascript" type="text/javascript" src="/steve/js/global.js"></SCRIPT>
</HEAD>
  <body>
    <form id="Form1" method="post" runat="server">		
    <uc1:Testata id="Testata1" runat="server"></uc1:Testata>
    <uc1:MainMenu id="MainMenu1" runat="server"></uc1:MainMenu>
    <uc1:MenuContestuale id="MenuContestuale1" Runat="server"></uc1:MenuContestuale>
    
    <div id="Content">		
		<div style="CLEAR:both">
					
			<asp:Panel ID="pnLoadControl" Runat="server"></asp:Panel>	
				
			<uc1:Paziente id="Paziente1" Azione="Show" runat="server"></uc1:Paziente>				
			
		</div>
	</div>		
     </form>
	
  </body>
</HTML>
