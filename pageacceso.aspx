<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdministrador.master" AutoEventWireup="true" CodeFile="pageacceso.aspx.cs" Inherits="pageacceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <form id="form1" runat="server">   
    
    <h1>Gestión de Niveles de Acceso</h1>
    
        <table class="style1" border="0" width="100%">
            <tr>
                <td class="style3">
                    <asp:TextBox ID="txtbuscar" runat="server" 
                        ToolTip="Buscar por ID"></asp:TextBox>
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" onclick="btnbuscar_Click" />
                </td>
                <td align="left" colspan="2">
                    <div>
                        <asp:Button ID="btnnuevo" runat="server" onclick="btnbuevo_Click" 
                            Text="Nuevo" />
                        <asp:Button ID="btnmodificar" runat="server" onclick="btnmodificar_Click" 
                            Text="Modificar" />
                        <asp:Button ID="btneliminar" runat="server" onclick="btneliminar_Click" 
                            Text="Eliminar" />
                        <asp:Button ID="btncancelar" runat="server" onclick="btncancelar_Click" 
                            Text="Cancelar" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td align="left" colspan="2">
                   <h3><asp:Label ID="lblestado" runat="server"></asp:Label></h3>                   
                </td>
            </tr>
            <tr>
                <td rowspan="11" class="style3">
                    <img alt="Nivel de Acceso" src="images/nivelacceso/acceso.png" 
                        style="width: 220px; height: 260px" /></td>
                <td align="left">

                    Id Nivel Acceso
                </td>
                <td>
    
        <asp:TextBox ID="txtidacceso" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Descripción
                </td>
                <td>
        <asp:TextBox ID="txtdescripcion" runat="server" Enabled="False" AutoPostBack="True" 
                        ontextchanged="txtdescripcion_TextChanged"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td align="left">
                    &nbsp; &nbsp; </td>
                <td>
        
        
                </td>
            </tr>           
           
            <tr>
                <td align="left">
                    &nbsp;</td>
                <td>
        
        
                    &nbsp;</td>
            </tr>           
           
            <tr>
                <td align="left">
                    &nbsp;</td>
                <td>
        
        
                    &nbsp;</td>
            </tr>           
           
            <tr>
                <td align="left">
                    &nbsp;</td>
                <td>
        
        
                    &nbsp;</td>
            </tr>           
          </table>
    </form>

</asp:Content>

