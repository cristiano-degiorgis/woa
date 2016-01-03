<%@ Control Language="c#" AutoEventWireup="True" Codebehind="Paziente.ascx.cs" Inherits="Steve.UserControl.Paziente" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<div class=step>
<h5>Anagrafica Paziente</h5>
<div><asp:label id=lblMsg Runat="server"></asp:label></div><asp:panel 
id=pnEditing Runat="server" Visible="False">
<DIV class="bloccoForm"><SPAN class="etichetta">Nome:</SPAN><asp:TextBox id="txtNome" Runat="server"></asp:TextBox></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Cognome:</SPAN><asp:TextBox id="txtCognome" Runat="server"></asp:TextBox></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Data di nascita:</SPAN><asp:TextBox id="txtDataNascita" Runat="server" MaxLength="10" Width="80"></asp:TextBox></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Professione:</SPAN><asp:TextBox id="txtProfesione" Runat="server"></asp:TextBox></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Indirizzo:</SPAN><asp:TextBox id="txtIndirizzo" Runat="server" Width="250"></asp:TextBox></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Città:</SPAN><asp:TextBox id="txtCitta" Runat="server"></asp:TextBox></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Provincia:</SPAN><asp:DropDownList id="ddlProv" Runat="server"><asp:ListItem Value="--">--</asp:ListItem></asp:DropDownList></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">CAP:</SPAN><asp:TextBox id="txtCap" Runat="server" MaxLength="5" Width="50"></asp:TextBox></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Telefono Fisso:</SPAN><asp:TextBox id="txtTel" Runat="server"></asp:TextBox></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Telefono Cell.:</SPAN><asp:TextBox id="txtCell" Runat="server"></asp:TextBox></DIV>
<DIV class="bloccoForm"><SPAN class="etichetta">Email:</SPAN><asp:TextBox id="txtEmail" Runat="server"></asp:TextBox></DIV>
<DIV class="bloccoSubmit"><asp:Button id="cmdSalva" onclick="Salva_Dati" Runat="server" CssClass="button" Text="Esegui >>"></asp:Button></DIV></asp:panel><asp:panel 
id=pnShow Runat="server" Visible="False">
<DIV class="bloccoForm"><SPAN class="etichettaShow">Nome:</SPAN> <asp:Label id="lblNome" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><SPAN class="etichettaShow">Cognome:</SPAN> <asp:Label id="lblCognome" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><SPAN class="etichettaShow">Data di nascita:</SPAN> <asp:Label id="lblDataNascita" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><SPAN class="etichettaShow">Professione:</SPAN> <asp:Label id="lblProfessione" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><SPAN class="etichettaShow">Indirizzo:</SPAN> <asp:Label id="lblIndirizzo" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><SPAN class="etichettaShow">Città:</SPAN> <asp:Label id="lblCitta" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><SPAN class="etichettaShow">Provincia:</SPAN> <asp:Label id="lblProv" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><SPAN class="etichettaShow">CAP:</SPAN><asp:Label id="lblCap" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><SPAN class="etichettaShow">Telefono Fisso:</SPAN> <asp:Label id="lblTel" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><SPAN class="etichettaShow">Telefono Cell.:</SPAN> <asp:Label id="lblCell" Runat="server"></asp:Label></DIV>
<DIV class="bloccoForm"><SPAN class="etichettaShow">Email.:</SPAN> <asp:Label id="lblEmail" Runat="server"></asp:Label></DIV>
<DIV class="contextLink"><asp:HyperLink id="hlUpd" Runat="server">&gt;&gt; Modifica Anagrafica Paziente</asp:HyperLink></DIV></asp:panel></div>
