<%@ Page language="c#" Codebehind="dettagli_consulto.aspx.cs" AutoEventWireup="True" Inherits="Steve.App.dettagli_consulto" %>
<%@ Register TagPrefix="uc1" TagName="Paziente" Src="~/UserControl/Paziente.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoConsulti" Src="~/UserControl/ElencoConsulti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Consulto" Src="~/UserControl/Consulto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AnamnesiProssima" Src="~/UserControl/AnamnesiProssima.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoEsami" Src="~/UserControl/ElencoEsami.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoTrattamenti" Src="~/UserControl/ElencoTrattamenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ElencoValutazioni" Src="~/UserControl/ElencoValutazioni.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MainMenu" Src="~/UserControl/MainMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuContestuale" Src="~/UserControl/MenuContestuale.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Testata" Src="~/UserControl/Testata.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>W.O.A.</title>
	<link href="/woa/css/main.css" rel="stylesheet" type="text/css" />
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">    
    <SCRIPT language="javascript" type="text/javascript" src="/woa/js/global.js"></SCRIPT>
  </head>
  <body>
	
    <form id="Form1" method="post" runat="server">
		<uc1:Testata id="Testata1" runat="server"></uc1:Testata>
		<uc1:MainMenu id="MainMenu1" runat="server"></uc1:MainMenu>		
		<uc1:MenuContestuale id="MenuContestuale1" Runat="server"></uc1:MenuContestuale>		 		
		<div id="Content">
			
			<h4>Dettagli Consulto</h4>
			
			<div id="RightPanel">
			<uc1:Paziente id="Paziente1" Azione="Show" runat="server"></uc1:Paziente>	
			<uc1:ElencoConsulti id="ElencoConsulti1" runat="server"></uc1:ElencoConsulti>
			</div>				
			
			<div id="MainPanel">
			
			<uc1:Consulto id="Consulto1" Azione="Show" runat="server"></uc1:Consulto>		
			<uc1:AnamnesiProssima id="AnamnesiProssima1" Azione="Show" runat="server"></uc1:AnamnesiProssima>		
			
			<uc1:ElencoEsami id="ElencoEsami1" runat="server"></uc1:ElencoEsami> 
			<uc1:ElencoTrattamenti id="ElencoTrattamenti1" runat="server"></uc1:ElencoTrattamenti>  
			<uc1:ElencoValutazioni id="ElencoValutazioni1" runat="server"></uc1:ElencoValutazioni>  			
			
			</div>

	

		</div>
     </form>
	
  </body>
</html>
