using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/* video 15*/
public partial class pageclientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        try
        {
            if ((bool)(Session["login"]) == false) //evalua si la var de secion existe
            {
                Response.Redirect("~/pagelogin.aspx");
            }
        }
        catch { Response.Redirect("~/pagelogin.aspx"); }
    }

    //busca el elemento especificado en la base de datos
    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        buscarRegistro();
    }

    //elimina el registro especificado de la base de datos.
    protected void btneliminar_Click(object sender, EventArgs e)
    {
        try
        {
            clscliente clt = new clscliente(0, 0, "", "", "", "", "", "", "");//instancia de clase cliente
            clt.eliminar(int.Parse(txtidcliente.Text));//elimina el registro especificado
            lblestado.Text = "Registro Eliminado";//mensaje de exito
            txtbuscar.Enabled = true;
            txtidcliente.Enabled = false;
            txtcedula.Enabled = false;
            drpempresa.Enabled = false;
            txtnombre.Enabled = false;
            txtapellido1.Enabled = false;
            txtapellido2.Enabled = false;
            txtdireccion.Enabled = false;
            txttelefono.Enabled = false;
            txtcorreo.Enabled = false;
            //RadioButtonListCategoria.Enabled = false;
            btnnuevo.Enabled = true;
            btnnuevo.Text = "Nuevo";
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
            txtidcliente.Text = "";
            txtcedula.Text = "";
            txtnombre.Text = "";
            txtapellido1.Text = "";
            txtapellido2.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            //drpempresa.SelectedIndex = drpempresa.Items.IndexOf(drpempresa.Items.FindByValue("0"));
        }
        catch
        {
            lblestado.Text = "El Registro no se puede Eliminar";
        }
    }
    protected void btnmodificar_Click(object sender, EventArgs e)
    {
        if (btnnuevo.Text == "Nuevo" && txtidcliente.Text != "")
        {
            //cambia el estado de los controles
            btnnuevo.Text = "Guardar";
            txtidcliente.Enabled = true;
            txtcedula.Enabled = true;
            drpempresa.Enabled = true;
            txtnombre.Enabled = true;
            txtapellido1.Enabled = true;
            txtapellido2.Enabled = true;
            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
            txtcorreo.Enabled = true;
            drpempresa.Enabled = true;
            //RadioButtonListCategoria.Enabled = true;
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
        }
        else
        {
            lblestado.Text = "No hya registro para modificar";
        }
    }

    protected void btnbuevo_Click(object sender, EventArgs e)
    {
        if (btnnuevo.Text == "Nuevo")
        {
            //cambia el estado de los controles
            btnnuevo.Text = "Guardar";
            txtidcliente.Enabled = true;
            txtcedula.Enabled = true;
            txtnombre.Enabled = true;
            txtapellido1.Enabled = true;
            txtapellido2.Enabled = true;
            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
            txtcorreo.Enabled = true;
            drpempresa.Enabled = true;

            //RadioButtonListCategoria.Enabled = true;
            //RadioButtonListCategoria.SelectedIndex = 0;
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
            //limpia el formulario
            txtidcliente.Text = "";
            // drpempresa.SelectedIndex = drpempresa.Items.IndexOf(drpempresa.Items.FindByValue("0"));
            txtcedula.Text = "";
            txtnombre.Text = "";
            txtapellido1.Text = "";
            txtapellido2.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            lblestado.Text = "";

        }
        else if (btnnuevo.Text == "Guardar")
        {

            try
            {
                clscliente clt = new clscliente(0, 0, "", "", "", "", "", "", "");//instancia de clase cliente                
                //cambia el estado de los controles
                btnnuevo.Text = "Nuevo";
                btnmodificar.Enabled = true;
                btnnuevo.Enabled = true;
                btneliminar.Enabled = true;
                btncancelar.Enabled = true;
                txtidcliente.Enabled = false;
                txtcedula.Enabled = false;
                drpempresa.Enabled = false;
                txtnombre.Enabled = false;
                txtapellido1.Enabled = false;
                txtapellido2.Enabled = false;
                txtdireccion.Enabled = false;
                txttelefono.Enabled = false;
                txtcorreo.Enabled = false;
                //RadioButtonListCategoria.Enabled = false;
                if (clt.existe(int.Parse(txtidcliente.Text.Trim())))
                {
                    //captura datos del formulario
                    clt.Idcliente = int.Parse(txtidcliente.Text.Trim());
                    clt.Idempresa = int.Parse(txtidcliente.Text.Trim());
                    clt.Cedula = txtcedula.Text;
                    clt.Nombre = txtnombre.Text;
                    clt.Apellido1 = txtapellido1.Text;
                    clt.Apellido2 = txtapellido2.Text;
                    clt.Direccion = txtdireccion.Text;
                    clt.Telefono = txttelefono.Text;
                    clt.Correo = txtcorreo.Text;
                    //clt.Categoria = int.Parse(RadioButtonListCategoria.SelectedValue);
                    clt.modificar();//actualiza el registro en la base de datos                   
                    lblestado.Text = "Registro Actualizado";
                }
                else
                {
                    //captura datos del formulario
                    //  clt.Cedula = txtidcliente.Text.Trim();
                    clt.Idcliente = int.Parse(txtidcliente.Text.Trim());
                    clt.Idempresa = int.Parse(drpempresa.SelectedValue);
                    clt.Cedula = txtcedula.Text;
                    clt.Nombre = txtnombre.Text;
                    clt.Apellido1 = txtapellido1.Text;
                    clt.Apellido2 = txtapellido2.Text;
                    clt.Direccion = txtdireccion.Text;
                    clt.Telefono = txttelefono.Text;
                    clt.Correo = txtcorreo.Text;
                    //clt.Categoria = int.Parse(RadioButtonListCategoria.SelectedValue);
                    clt.agregar();//agrega un nuevo registro a la base de datos                
                    lblestado.Text = "Nuevo Registro Guardado";
                }
            }
            catch { lblestado.Text = "No puede dejar espacios vacidos"; }
        }


    }
    protected void buscarRegistro()
    {
        try
        {
            clscliente clt = new clscliente(0, 0, "", "", "", "", "", "", "");
            txtbuscar.Enabled = true;
            txtidcliente.Enabled = false;
            drpempresa.Enabled = false;
            txtcedula.Enabled = false;
            txtnombre.Enabled = false;
            txtapellido1.Enabled = false;
            txtapellido2.Enabled = false;
            txtdireccion.Enabled = false;
            txttelefono.Enabled = false;
            txtcorreo.Enabled = false;
            //RadioButtonListCategoria.Enabled = false;
            btnnuevo.Enabled = true;
            btnnuevo.Text = "Nuevo";
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
            if (clt.existe(int.Parse(txtbuscar.Text.Trim())))
            {
                //captura los atributos devueltos por la busqueda
                txtidcliente.Text = clt.Idcliente.ToString();
                drpempresa.SelectedIndex = drpempresa.Items.IndexOf(drpempresa.Items.FindByValue(clt.Idempresa.ToString()));
                txtcedula.Text = clt.Cedula;
                txtnombre.Text = clt.Nombre;
                txtapellido1.Text = clt.Apellido1;
                txtapellido2.Text = clt.Apellido2;
                txtdireccion.Text = clt.Direccion;
                txttelefono.Text = clt.Telefono;
                txtcorreo.Text = clt.Correo;
                //RadioButtonListCategoria.SelectedIndex = RadioButtonListCategoria.Items.IndexOf(RadioButtonListCategoria.Items.FindByValue(clt.Categoria.ToString()));
                //despliega un mensaje indicando el exito e la busqueda
                lblestado.Text = "Registro Encontrado";
            }
            else
            {
                txtidcliente.Text = "";
                txtcedula.Text = "";
                txtnombre.Text = "";
                txtapellido1.Text = "";
                txtapellido2.Text = "";
                txtdireccion.Text = "";
                txttelefono.Text = "";
                txtcorreo.Text = "";
                //RadioButtonListCategoria.SelectedIndex = 0;
                lblestado.Text = "El registro no existe";
            }
        }
        catch
        {
            //error
            lblestado.Text = "No ha especificado nigún parámetro de Búsqueda Válido";
            txtidcliente.Enabled = false;
            txtcedula.Enabled = false;
            txtnombre.Enabled = false;
            txtapellido1.Enabled = false;
            txtapellido2.Enabled = false;
            txtdireccion.Enabled = false;
            txttelefono.Enabled = false;
            txtcorreo.Enabled = false;
            //RadioButtonListCategoria.Enabled = false;
            txtidcliente.Text = "";
            drpempresa.SelectedIndex = drpempresa.Items.IndexOf(drpempresa.Items.FindByValue("0"));
            txtcedula.Text = "";
            txtnombre.Text = "";
            txtapellido1.Text = "";
            txtapellido2.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            //RadioButtonListCategoria.SelectedIndex = 0;
            btnnuevo.Enabled = true;
            btnnuevo.Text = "Nuevo";
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
        }

    }
    protected void btncancelar_Click(object sender, EventArgs e)
    {
        txtbuscar.Enabled = true;
        txtidcliente.Enabled = false;
        drpempresa.Enabled = false;
        txtnombre.Enabled = false;
        txtapellido1.Enabled = false;
        txtapellido2.Enabled = false;
        txtdireccion.Enabled = false;
        txttelefono.Enabled = false;
        txtcorreo.Enabled = false;
        //RadioButtonListCategoria.Enabled = false;
        btnnuevo.Enabled = true;
        btnnuevo.Text = "Nuevo";
        btnmodificar.Enabled = true;
        btneliminar.Enabled = true;
        btncancelar.Enabled = true;
    }
    protected void txtidcliente_TextChanged(object sender, EventArgs e)
    {
        try
        {

            clscliente clt = new clscliente(0, 0, "", "", "", "", "", "", "");
            if (clt.existe(int.Parse(txtidcliente.Text.Trim())))
            {
                //captura los atributos devueltos por la busqueda
                //txtidcliente.Text = clt.Cedula.ToString();
                txtidcliente.Text = clt.Idcliente.ToString();
                txtnombre.Text = clt.Nombre;
                txtapellido1.Text = clt.Apellido1;
                txtapellido2.Text = clt.Apellido2;
                txtdireccion.Text = clt.Direccion;
                txttelefono.Text = clt.Telefono;
                txtcorreo.Text = clt.Correo;
                //RadioButtonListCategoria.SelectedIndex = RadioButtonListCategoria.Items.IndexOf(RadioButtonListCategoria.Items.FindByValue(clt.Categoria.ToString()));
                //despliega un mensaje indicando el exito e la busqueda
                lblestado.Text = "Registro Encontrado";
                txtnombre.Focus();
            }
            else
            {
                txtnombre.Focus();
            }
        }
        catch { lblestado.Text = "El campo unicamente admite números"; }
    }

    protected void drpcliente_SelectedIndexChanged(object sender, EventArgs e)
    { //canpo busquedA  =obtenemos el valor desdes Label base delegate datos
        txtbuscar.Text = drpcliente.SelectedValue.ToString();
        buscarRegistro();// se realisa la busqueda automatica
    }
}