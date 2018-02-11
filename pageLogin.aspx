<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageLogin.master" AutoEventWireup="true" CodeFile="pageLogin.aspx.cs" Inherits="pageLogin" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <table style="width: 100%" class="ser">
        <tr>
            <td rowspan="8">
                <img alt="" src="images/Login/login.png" style="width: 182px; height: 259px" /></td>
            <td>&nbsp;</td>
            <td>Iniciar secion</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Usuario</td>
            <td>
                <asp:TextBox ID="txtusuario" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Contraseñaco</td>
            <td>
                <asp:TextBox ID="txtcontraseña" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:CheckBox ID="chkboxrecordad" runat="server" Text="Recordar la proxima vez" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btninicio" runat="server" Text="Inicio de Sesion" OnClick="btninicio_Click" />
                <asp:HyperLink ID="likregistrarse" runat="server" NavigateUrl="~/pageregistro.aspx">Registrarse</asp:HyperLink>
            </td>
        </tr>
        <tr>
          
            <td colspan="2">
            <h1>
                <asp:Label ID="lblestado" runat="server"></asp:Label>
            </h1> 
        </td>
        </tr>
    </table>
</form>
</asp:Content>

