<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdministrador.master" AutoEventWireup="true" CodeFile="pageclientes.aspx.cs" Inherits="pageclientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <form id="form1" runat="server">   
    
    <h1>Gestión de Cliente</h1>
    
        <table class="style1" border="0" width="100%">
            <tr>
                <td class="style3" style="width: 111px">
                    <asp:DropDownList ID="drpcliente" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceCliente" DataTextField="nombre" DataValueField="idcliente" OnSelectedIndexChanged="drpcliente_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtbuscar" runat="server" ToolTip="Buscar por Cédula"></asp:TextBox>
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" onclick="btnbuscar_Click" />
                    <asp:SqlDataSource ID="SqlDataSourceCliente" runat="server" ConnectionString="<%$ ConnectionStrings:facturacionConnectionString %>" SelectCommand="SELECT [idcliente], [nombre] FROM [tbl_cliente]"></asp:SqlDataSource>
                </td>
                <td align="center" colspan="4">
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
                <td class="style3" style="width: 111px">
                    &nbsp;</td>
                <td align="left" colspan="2">
                   <h3><asp:Label ID="lblestado" runat="server"></asp:Label></h3>                   
                </td>
            </tr>
            <tr>
                <td  rowspan="11" class="style3" style="width: 111px">
                    <img alt="" class="style2" src="images/clientes/imgclientes.png" 
                        style="height: 342px; width: 379px" /></td>
                <td align="left">

                  Cédula
                </td>
                <td>
    
        <asp:TextBox ID="txtidcliente" runat="server" Enabled="False" AutoPostBack="True" 
                        ontextchanged="txtidcliente_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">

                    Codigo Cel</td>
                <td>
    
                    <asp:TextBox ID="txtcedula" runat="server" Enabled="False"></asp:TextBox>
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
                <td align="left" style="height: 33px">
                    Primer Apellido</td>
                <td style="height: 33px">
        <asp:TextBox ID="txtapellido1" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Segundo Apellido
                </td>
                <td>
        <asp:TextBox ID="txtapellido2" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
        Dirección
                </td>
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
                    Empresa</td>
                <td>
        
                    <asp:DropDownList ID="drpempresa" runat="server" 
                        DataSourceID="SqlDataSourceEmpresa" DataTextField="nombre" 
                        DataValueField="idempresa" Enabled="False">
                        <asp:ListItem Value="0">Ninguna</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceEmpresa" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:facturacionConnectionString %>" 
                        SelectCommand="SELECT [idempresa], [nombre] FROM [tbl_empresa]">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="left">        
                    
                </td>
            </tr>
            <tr>
                <td class="style3" style="width: 111px">
                    &nbsp;</td>
                <td colspan="2" align="left">
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</asp:Content>

