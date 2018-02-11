<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdministrador.master" AutoEventWireup="true" CodeFile="pageordenservicio.aspx.cs" Inherits="pageordenservicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1>Orden de Servicio 
        -# 
        <asp:Label ID="lblorden" runat="server"></asp:Label></h1>   
   
   <form id="form1" runat="server">
    
   <table style="width: 100%">
       <tr>
           <td colspan="2">
               <h1>Cliente</h1>
               
                 <%-- <div>              
            <asp:TextBox ID="txtidcliente" runat="server" 
                   ontextchanged="txtidcliente_TextChanged" ToolTip="Buscar " 
                       CausesValidation="True"></asp:TextBox>
               <asp:Button ID="btnbuscar" runat="server" onclick="btnbuscar_Click" 
                   Text="Buscar" style="width: 61px" />
               <asp:HyperLink ID="lnkregistrar" runat="server" 
                   NavigateUrl="~/pageclientes.aspx" Target="_self" 
                   ToolTip="Registrar un nuevo Cliente">Registrar</asp:HyperLink> 
               </div>
               <div> 
                   <asp:GridView ID="DataGridViewCliente" runat="server" 
                       AutoGenerateSelectButton="true" 
                       onselectedindexchanged="DataGridViewCliente_SelectedIndexChanged">
                   </asp:GridView>
               </div>--%>
           </td>
           <td>
               <h1> Categoría</h1>
              <%--<asp:SqlDataSource ID="SqlDataSourceCategoria1" runat="server" 
               <asp:DropDownList ID="drpcategoria1" runat="server" AutoPostBack="True" 
                    ToolTip="Categoría" DataSourceID="SqlDataSourceCategoria1" 
                   DataTextField="descripcion" DataValueField="idcategoria1">
               </asp:DropDownList>
                   ConnectionString="<%$ ConnectionStrings:facturacionConnectionString %>" 
                   SelectCommand="SELECT * FROM [tbl_categoria1]"></asp:SqlDataSource>
               <asp:SqlDataSource ID="SqlDataSourceCategoria1" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:facturacionConnectionString %>" 
                   SelectCommand="SELECT * FROM [tbl_categoria1] ORDER BY [descripcion]"></asp:SqlDataSource>
               
               <asp:DropDownList ID="drpcategoria2" runat="server" AutoPostBack="True" 
                    ToolTip="Subcategoría" DataSourceID="SqlDataSourceCategoria2" 
                   DataTextField="descripcion" DataValueField="idcategoria2">
               </asp:DropDownList>
               <asp:SqlDataSource ID="SqlDataSourceCategoria2" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:facturacionConnectionString %>" 
                   SelectCommand="SELECT * FROM [tbl_categoria2]"></asp:SqlDataSource>
               <asp:SqlDataSource ID="SqlDataSourceCategoria2" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:facturacionConnectionString %>" 
                   SelectCommand="SELECT * FROM [View_Categoria2] WHERE ([idcategoria1] = @idcategoria1)">
                   <SelectParameters>
                       <asp:ControlParameter ControlID="drpcategoria1" DefaultValue="0" 
                           Name="idcategoria1" PropertyName="SelectedValue" Type="Int32" />
                   </SelectParameters>
               </asp:SqlDataSource>--%>
               
           </td>
           <td rowspan="1">
               <h1>Estado</h1>
               <asp:DropDownList ID="drpestado" runat="server" 
                   DataSourceID="SqlDataSourceEstado" DataTextField="descripcion" 
                   DataValueField="idestado" ToolTip="Estado de la Orden">
               </asp:DropDownList>

               <asp:SqlDataSource ID="SqlDataSourceEstado" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:facturacionConnectionString %>" 
                   SelectCommand="SELECT * FROM [tbl_estado]">
               </asp:SqlDataSource>
           </td>
       </tr>
       <tr>
           <td style="width: 44px">
               ID Cliente</td>
           <td>
               <asp:Label ID="lblidcliente" runat="server"></asp:Label>
           </td>
           <td rowspan="6">
               
               <h1>Servicio</h1>
               <asp:DropDownList ID="drpservicio" runat="server" 
                   DataSourceID="SqlDataSourceServicio" DataTextField="descripcion" 
                   DataValueField="idservicio" ToolTip="Servicios">
               </asp:DropDownList>
               <asp:SqlDataSource ID="SqlDataSourceServicio" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:facturacionConnectionString %>" 
                   SelectCommand="SELECT * FROM [tbl_servicio] ORDER BY [descripcion]"></asp:SqlDataSource>
           </td>
           <td rowspan="6">
               <h1>
                   Especialista</h1>
              <%-- <asp:DropDownList ID="drpempleado" runat="server" 
                   DataSourceID="SqlDataSourceEmpleados" DataTextField="nombre" 
                   DataValueField="idempleado" 
                   onselectedindexchanged="drpempleado_SelectedIndexChanged">
               </asp:DropDownList>

               <asp:SqlDataSource ID="SqlDataSourceEmpleados" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:facturacionConnectionString %>" 
                   SelectCommand="SELECT * FROM [tbl_empleado]"></asp:SqlDataSource>--%>

           </td>
       </tr>
       <tr>
           <td style="width: 44px">
               Cédula:</td>
           <td>
               <asp:Label ID="lblcedula" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td style="width: 44px">
               Cliente: </td>
           <td>
               <asp:Label ID="lblcliente" runat="server"></asp:Label>
           </td>

       </tr>
       <tr>
           <td style="width: 44px">
               Dirección: </td>
           <td>
               <asp:Label ID="lbldireccion" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td style="width: 44px">
               Teléfono: </td>
           <td>
               <asp:Label ID="lbltelefono" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td style="width: 44px">
               Correo: </td>
           <td>
               <asp:Label ID="lblcorreo" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td colspan="4">
               <hr />
              <h1>Descripción de la Solicitud</h1>
           </td>
       </tr>
       <tr>
           <td colspan="4">
               <asp:TextBox ID="txtsolicitud" runat="server" AutoCompleteType="Notes" 
                   Height="150px" TextMode="MultiLine" ToolTip="Solicitud del Cliente" 
                   Width="100%" MaxLength="200"></asp:TextBox>
           </td>
       </tr>
       <tr>
           <td colspan="4">
               <h1>Observaciones</h1>
           </td>
       </tr>
       <tr>
           <td colspan="4">
              <%-- <asp:CheckBoxList ID="chkobservacion" runat="server" 
                   DataSourceID="SqlDataSourceObservacion" DataTextField="descripcion" 
                   DataValueField="idobservacion" RepeatColumns="2" ToolTip="Observaciones" 
                   AutoPostBack="True" 
                   onselectedindexchanged="chkobservacion_SelectedIndexChanged">
               </asp:CheckBoxList>
               <asp:SqlDataSource ID="SqlDataSourceObservacion" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:facturacionConnectionString %>" 
                   SelectCommand="SELECT * FROM [tbl_observacion]"></asp:SqlDataSource>--%>
           </td>
       </tr>
       <tr>
           <td colspan="2">
               <h3>
                   <asp:Label ID="lblotraobservacion" runat="server" Text="Otra" Visible="False"></asp:Label></h3>
               <asp:TextBox ID="txtobservacion" runat="server" AutoCompleteType="Notes" 
                   Height="100px" TextMode="MultiLine" ToolTip="Otra Observación" 
                   Width="100%" MaxLength="200" Visible="False"></asp:TextBox>
           </td>
           <td colspan="2">
               <h1>Agrear Imagen
               </h1>
               <h1>
                   <asp:Label ID="lblestadoimagen" runat="server" Text=""></asp:Label>
               </h1>
               <asp:FileUpload ID="uplimagen" runat="server" ToolTip="Subir Imagen" />
              <%-- <asp:Button ID="btnagregar" runat="server" onclick="btnagregar_Click" 
                   Text="Agregar" Width="67px" />--%>
               <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
               <br />
               <%--<asp:ListBox ID="ListBoxImagenes" runat="server" Width="100%" AutoPostBack="True" 
                   onselectedindexchanged="ListBox1_SelectedIndexChanged" Visible="False"></asp:ListBox>--%>
               <br />
           </td>
       </tr>
       <tr>
           <td>
               <%--<asp:ImageButton ID="btnGuardar" runat="server" Height="42px" 
                   ImageUrl="~/images/Guardar/guardar.png" ToolTip="Guardar" Width="43px" 
                   onclick="btnGuardar_Click" />--%>
           </td>
           <td>
               &nbsp;</td>
           <td>
               &nbsp;</td>
           <td>
               &nbsp;</td>
       </tr>
       </table>
    
   </form>
</asp:Content>

