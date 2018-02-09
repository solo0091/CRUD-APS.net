<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageLogin.master" AutoEventWireup="true" CodeFile="pageregistro.aspx.cs" Inherits="pageregistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <table style="width: 100%">
            <tr>
                <td style="width: 192px">
                    <asp:TextBox ID="txtbuscar" runat="server"></asp:TextBox>
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" OnClick="btnbuscar_Click" />
                </td>
                <td colspan="2">
                    <asp:Button ID="btnnuevo" runat="server" Text="Nuevo" OnClick="btnnuevo_Click" />
                    <asp:Button ID="btnmodificar" runat="server" Text="Modificar" OnClick="btnmodificar_Click" />
                    <asp:Button ID="btneliminar" runat="server" Text="Eliminar" OnClick="btneliminar_Click" />
                    <asp:Button ID="btncancelar" runat="server" Text="Cancelar" OnClick="btncancelar_Click" />
                </td>
            </tr>
            <tr>
                <td rowspan="7" style="width: 192px">
                    <img alt="" src="images/Login/empleado.png" style="width: 256px; height: 256px" /></td>
                <td colspan="2">
                    <h1>
                         <asp:Label ID="lblestado" runat="server" Text="Estado"></asp:Label>
                    </h1>
                   
                </td>
            </tr>
            <tr>
                <td style="height: 27px">Cedula</td>
                <td style="height: 27px">
                    <asp:TextBox ID="txtidempleado" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td>
                    <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Usuario</td>
                <td>
                    <asp:TextBox ID="txtusuario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Contraseña</td>
                <td>
                    <asp:TextBox ID="txtcontraseña" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Nivel Acceso</td>
                <td>
                    <asp:RadioButtonList ID="rdbacceso" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">Nivel 1</asp:ListItem>
                        <asp:ListItem Value="2">NIvel 2</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</asp:Content>

