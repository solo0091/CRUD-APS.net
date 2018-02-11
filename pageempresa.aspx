<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdministrador.master" AutoEventWireup="true" CodeFile="pageempresa.aspx.cs" Inherits="pageempresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">   
    
    <h1>Gestión de Empresas</h1>
    
        <table class="style1" border="0" width="100%">
            <tr>
                <td class="style3" style="width: 116px">
                    <asp:DropDownList ID="drpempresa" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceEmpresa" DataTextField="nombre" DataValueField="idempresa" OnSelectedIndexChanged="drpempresa_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceEmpresa" runat="server" ConnectionString="<%$ ConnectionStrings:facturacionConnectionString %>" SelectCommand="SELECT [idempresa], [nombre] FROM [tbl_empresa]"></asp:SqlDataSource>
                    <asp:TextBox ID="txtbuscar" runat="server" 
                        ToolTip="Buscar por Código de Empresa"></asp:TextBox>
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
                <td class="style3" style="width: 116px">
                    &nbsp;</td>
                <td align="left" colspan="2">
                   <h3><asp:Label ID="lblestado" runat="server"></asp:Label></h3>                   
                </td>
            </tr>
            <tr>
                <td rowspan="8" class="style3" style="width: 116px">
                    <img alt="proveedores" src="images/proveedores/imgproveedor.png" 
                        style="width: 433px; height: 247px" /></td>
                <td align="left">

                    Código
                </td>
                <td>
    
        <asp:TextBox ID="txtidempresa" runat="server" Enabled="False" AutoPostBack="True" 
                        ontextchanged="txtidempresa_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
        Nombre
                </td>
                <td>
        <asp:TextBox ID="txtnombre" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Dirección</td>
                <td>
        <asp:TextBox ID="txtdireccion" runat="server" Enabled="False" Height="36px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
        Teléfono
                </td>
                <td>
        <asp:TextBox ID="txttelefono" runat="server" Enabled="False"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td align="left">
        Correo
                </td>
                <td>
        <asp:TextBox ID="txtcorreo" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp; &nbsp; </td>
                <td>
        
        
                </td>
            </tr>           
          </table>
    </form>


</asp:Content>

