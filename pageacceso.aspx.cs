using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pageacceso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        try
        {
            clsacceso accs = new clsacceso(0, "");//instancia de clase   
            txtbuscar.Enabled = true;
            txtidacceso.Enabled = false;
            txtdescripcion.Enabled = false;

            btnnuevo.Enabled = true;
            btnnuevo.Text = "Nuevo";
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
            if (accs.existe(int.Parse(txtbuscar.Text.Trim())))
            {
                //captura los atributos devueltos por la busqueda
                txtidacceso.Text = accs.Idacceso.ToString();
                txtdescripcion.Text = accs.Descripcion;

                lblestado.Text = "Registro Encontrado";
            }
            else
            {
                txtidacceso.Text = "";
                txtdescripcion.Text = "";

                lblestado.Text = "El registro no existe";
            }
        }
        catch
        {
            //error
            lblestado.Text = "No ha especificado nigún parámetro de Búsqueda Válido";
            txtidacceso.Enabled = false;
            txtdescripcion.Enabled = false;

            txtidacceso.Text = "";
            txtdescripcion.Text = "";

            btnnuevo.Enabled = true;
            btnnuevo.Text = "Nuevo";
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
        }
        txtbuscar.Focus();
    }
    protected void btnbuevo_Click(object sender, EventArgs e)
    {
        if (btnnuevo.Text == "Nuevo")
        {
            //cambia el estado de los controles
            btnnuevo.Text = "Guardar";
            txtidacceso.Enabled = true;
            txtdescripcion.Enabled = true;
            txtidacceso.Focus();
            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;

            //limpia el formulario
            txtidacceso.Text = "";
            txtdescripcion.Text = "";

            lblestado.Text = "";
        }
        else if (btnnuevo.Text == "Guardar")
        {
            try
            {
                clsacceso accs = new clsacceso(0, "");//instancia de clase                
                //cambia el estado de los controles
                btnnuevo.Text = "Nuevo";
                btnmodificar.Enabled = true;
                btnnuevo.Enabled = true;
                btneliminar.Enabled = true;
                btncancelar.Enabled = true;
                txtidacceso.Enabled = false;
                txtdescripcion.Enabled = false;

                if (accs.existe(int.Parse(txtidacceso.Text)))
                {
                    //captura datos del formulario
                    accs.Idacceso = int.Parse(txtidacceso.Text.Trim());
                    accs.Descripcion = txtdescripcion.Text;
                    accs.modificar();//actualiza el registro en la base de datos                   
                    lblestado.Text = "Registro Actualizado";
                }
                else
                {
                    //captura datos del formulario
                    accs.Idacceso = int.Parse(txtidacceso.Text.Trim());
                    accs.Descripcion = txtdescripcion.Text;

                    accs.agregar();//agrega un nuevo registro a la base de datos                
                    lblestado.Text = "Nuevo Registro Guardado";
                }
            }
            catch { lblestado.Text = "No puede dejar espacios vacidos"; }
        }
    }
    protected void btnmodificar_Click(object sender, EventArgs e)
    {
        if (btnnuevo.Text == "Nuevo" && txtidacceso.Text != "")
        {
            //cambia el estado de los controles
            btnnuevo.Text = "Guardar";
            txtidacceso.Enabled = true;
            txtdescripcion.Enabled = true;

            btnmodificar.Enabled = false;
            btneliminar.Enabled = false;
        }
        else
        {
            lblestado.Text = "No hya registro para modificar";
        }
    }
    protected void btneliminar_Click(object sender, EventArgs e)
    {
        try
        {
            clsacceso accs = new clsacceso(0, "");//instancia de clase      
            accs.eliminar(int.Parse(txtidacceso.Text));//elimina el registro especificado
            lblestado.Text = "Registro Eliminado";//mensaje de exito
            txtbuscar.Enabled = true;
            txtidacceso.Enabled = false;
            txtdescripcion.Enabled = false;

            btnnuevo.Enabled = true;
            btnnuevo.Text = "Nuevo";
            btnmodificar.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;
            txtidacceso.Text = "";
            txtdescripcion.Text = "";

        }
        catch
        {
            lblestado.Text = "El Registro no se puede Eliminar";
        }
    }
    protected void btncancelar_Click(object sender, EventArgs e)
    {
        txtbuscar.Enabled = true;
        txtidacceso.Enabled = false;
        txtdescripcion.Enabled = false;

        btnnuevo.Enabled = true;
        btnnuevo.Text = "Nuevo";
        btnmodificar.Enabled = true;
        btneliminar.Enabled = true;
        btncancelar.Enabled = true;
    }

    protected void txtidacceso_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtdescripcion_TextChanged(object sender, EventArgs e)
    {
        btnnuevo.Focus();
    }
}