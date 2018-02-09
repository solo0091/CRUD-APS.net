using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pageregistro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnnuevo_Click(object sender, EventArgs e)
    {
        clsempleado emp = new clsempleado(0,0,"","","");  //iniciamos

        emp.Idempleado =int.Parse( txtidempleado.Text);    // establemos los valores
        emp.Idacceso = int.Parse(rdbacceso.SelectedValue);
        emp.Nombre = txtnombre.Text;
        emp.Usuario = txtusuario.Text;
        emp.Contraseña = txtcontraseña.Text;

        emp.agregar();//agregamos a al base de datos

        lblestado.Text = "Registro Guardado";



    }
    protected void btnmodificar_Click(object sender, EventArgs e)
    {
        clsempleado emp = new clsempleado(0, 0, "", "", "");  //iniciamos

        emp.Idempleado = int.Parse(txtidempleado.Text);    // establemos los valores
        emp.Idacceso = int.Parse(rdbacceso.SelectedValue);
        emp.Nombre = txtnombre.Text;
        emp.Usuario = txtusuario.Text;
        emp.Contraseña = txtcontraseña.Text;


        emp.modificar();
        lblestado.Text = "Registro Modificado";

    }
    protected void btneliminar_Click(object sender, EventArgs e)
    {
        clsempleado emp = new clsempleado(0, 0, "", "", "");  //iniciamos
        emp.eliminar(int.Parse(txtidempleado.Text));
        lblestado.Text = "Registro Eliminado";
    }
    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        clsempleado emp = new clsempleado(0, 0, "", "", "");  //iniciamos
        if(emp.existe(int.Parse(txtbuscar.Text.Trim()))){
            txtidempleado.Text = emp.Idempleado.ToString();
            txtnombre.Text = emp.Nombre;
            txtusuario.Text = emp.Usuario;
            txtcontraseña.Text = emp.Contraseña;

            rdbacceso.SelectedIndex = rdbacceso.Items.IndexOf(rdbacceso.Items.FindByValue(emp.Idacceso.ToString()));
            lblestado.Text = "Registro Encontrado";
        }
         

    }
    protected void btncancelar_Click(object sender, EventArgs e)
    {

    }
}