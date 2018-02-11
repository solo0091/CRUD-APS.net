using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class pageempresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void btnbuevo_Click(object sender, EventArgs e)
    {
        if (btnnuevo.Text == "Nuevo")
        {
            txtidempresa.Focus();
            //cambia el estado de los controles
            btnnuevo.Text = "Guardar";
            txtidempresa.Enabled = true;
            txtnombre.Enabled = true;


            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
            txtcorreo.Enabled = true;


            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
            //limpia el formulario
            txtidempresa.Text = "";
            txtnombre.Text = "";


            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            lblestado.Text = "";
        }
        else if (btnnuevo.Text == "Guardar")
        {
            try
            {
                clsempresa emp = new clsempresa(0, "", "", "", "");
                //cambia el estado de los controles
                btnnuevo.Text = "Nuevo";
                btnmodificar.Enabled = true;
                btnnuevo.Enabled = true;
                btneliminar.Enabled = true;
                btncancelar.Enabled = true;
                txtidempresa.Enabled = false;
                txtnombre.Enabled = false;


                txtdireccion.Enabled = false;
                txttelefono.Enabled = false;
                txtcorreo.Enabled = false;

                if (emp.existe(int.Parse(txtidempresa.Text)))
                {
                    //captura datos del formulario
                    emp.Idempresa = int.Parse(txtidempresa.Text.Trim());
                    emp.Nombre = txtnombre.Text;


                    emp.Direccion = txtdireccion.Text;
                    emp.Telefono = txttelefono.Text;
                    emp.Correo = txtcorreo.Text;
                    emp.modificar();//actualiza el registro en la base de datos                   
                    lblestado.Text = "Registro Actualizado";
                }
                else
                {
                    //captura datos del formulario
                    emp.Idempresa = int.Parse(txtidempresa.Text.Trim());
                    emp.Nombre = txtnombre.Text;

                    emp.Direccion = txtdireccion.Text;
                    emp.Telefono = txttelefono.Text;
                    emp.Correo = txtcorreo.Text;
                    emp.agregar();//agrega un nuevo registro a la base de datos                
                    lblestado.Text = "Nuevo Registro Guardado";
                }
            }
            catch { lblestado.Text = "No puede dejar espacios vacidos"; }
        }
    }
    protected void btnmodificar_Click(object sender, EventArgs e)
    {
        if (btnnuevo.Text == "Nuevo" && txtidempresa.Text != "")
        {
            //cambia el estado de los controles
            btnnuevo.Text = "Guardar";
            txtidempresa.Enabled = true;
            txtnombre.Enabled = true;


            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
            txtcorreo.Enabled = true;

            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
        }
        else
        {
            lblestado.Text = "No hay registro para modificar";
        }
    }
    protected void btneliminar_Click(object sender, EventArgs e)
    {
        try
        {
            clsempresa emp = new clsempresa(0, "", "", "", "");
            emp.eliminar(int.Parse(txtidempresa.Text));//elimina el registro especificado
            lblestado.Text = "Registro Eliminado";//mensaje de exito
            txtbuscar.Enabled = true;
            txtidempresa.Enabled = false;
            txtnombre.Enabled = false;


            txtdireccion.Enabled = false;
            txttelefono.Enabled = false;
            txtcorreo.Enabled = false;

            btnnuevo.Enabled = true;
            btnnuevo.Text = "Nuevo";
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
            txtidempresa.Text = "";
            txtnombre.Text = "";


            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";

        }
        catch
        {
            lblestado.Text = "El Registro no se puede Eliminar";
        }
    }
    protected void btncancelar_Click(object sender, EventArgs e)
    {
        txtbuscar.Enabled = true;
        txtidempresa.Enabled = false;
        txtnombre.Enabled = false;

        txtdireccion.Enabled = false;
        txttelefono.Enabled = false;
        txtcorreo.Enabled = false;

        btnnuevo.Enabled = true;
        btnnuevo.Text = "Nuevo";
        btnmodificar.Enabled = true;
        btneliminar.Enabled = true;
        btncancelar.Enabled = true;
    }

    protected void buscarRegistro()
    {
        try
        {
            clsempresa emp = new clsempresa(0, "", "", "", "");
            txtbuscar.Enabled = true;
            txtidempresa.Enabled = false;
            txtnombre.Enabled = false;

            txtdireccion.Enabled = false;
            txttelefono.Enabled = false;
            txtcorreo.Enabled = false;
            btnnuevo.Enabled = true;
            btnnuevo.Text = "Nuevo";
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
            if (emp.existe(int.Parse(txtbuscar.Text.Trim())))
            {
                //captura los atributos devueltos por la busqueda
                txtidempresa.Text = emp.Idempresa.ToString();
                txtnombre.Text = emp.Nombre;

                txtdireccion.Text = emp.Direccion;
                txttelefono.Text = emp.Telefono;
                txtcorreo.Text = emp.Correo;
                //despliega un mensaje indicando el exito e la busqueda
                lblestado.Text = "Registro Encontrado";
            }
            else
            {
                txtidempresa.Text = "";
                txtnombre.Text = "";


                txtdireccion.Text = "";
                txttelefono.Text = "";
                txtcorreo.Text = "";

                lblestado.Text = "El registro no existe";
            }
        }
        catch
        {
            //error
            lblestado.Text = "No ha especificado nigún parámetro de Búsqueda Válido";
            txtidempresa.Enabled = false;
            txtnombre.Enabled = false;


            txtdireccion.Enabled = false;
            txttelefono.Enabled = false;
            txtcorreo.Enabled = false;

            txtidempresa.Text = "";
            txtnombre.Text = "";


            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";

            btnnuevo.Enabled = true;
            btnnuevo.Text = "Nuevo";
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
        }


    }
    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        buscarRegistro();
    }
    protected void txtidempresa_TextChanged(object sender, EventArgs e)
    {
        try
        {

            clsempresa emp = new clsempresa(0, "", "", "", "");
            if (emp.existe(int.Parse(txtidempresa.Text.Trim())))
            {
                //captura los atributos devueltos por la busqueda
                txtidempresa.Text = emp.Idempresa.ToString();
                txtnombre.Text = emp.Nombre;
                txtdireccion.Text = emp.Direccion;
                txttelefono.Text = emp.Telefono;
                txtcorreo.Text = emp.Correo;
                //RadioButtonListCategoria.SelectedIndex = RadioButtonListCategoria.Items.IndexOf(RadioButtonListCategoria.Items.FindByValue(emp.Categoria.ToString()));
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
    protected void drpempresa_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtbuscar.Text = drpempresa.SelectedValue.ToString();
        buscarRegistro();
    }
}