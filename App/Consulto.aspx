<%@ Page language="c#" Codebehind="Consulto.aspx.cs" AutoEventWireup="false" Inherits="Steve.App.Consulto" %>
<%@ Register TagPrefix="uc1" TagName="Consulto" Src="~/UserControl/Consulto.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Consulto</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body>
	
    <form id="Form1" method="post" runat="server">
		<asp:Panel ID="pnMenuContestuale" Runat="server"></asp:Panel>
    
		<uc1:Consulto id="UcConsulto" runat="server"></uc1:Consulto>
     </form>
	
  </body>
</HTML>
