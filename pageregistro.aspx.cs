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

    public void GUiEdicion() {
        txtbuscar.Enabled = true;
        txtidempleado.Enabled = true;
        txtnombre.Enabled = true;
        txtusuario.Enabled = true;
        txtcontraseña.Enabled = true;
        rdbacceso.Enabled = true;
        lblestado.Text ="";

        btnmodificar.Enabled = false;
        btneliminar.Enabled = false;
       
    }
    public void GUIlimpiar() {
        txtcontraseña.Text = "";
        txtidempleado.Text = "";
        txtidempleado.Text = "";
        txtnombre.Text = "";
        txtusuario.Text ="";
        rdbacceso.ClearSelection();
      //  txtbuscar
    }

    public void GUIEdicionTerminada() {
        txtbuscar.Enabled = true;
        txtidempleado.Enabled = false;
        txtcontraseña.Enabled = false;
        txtusuario.Enabled = false;
        txtnombre.Enabled = false;
        lblestado.Text = "false";
        btnnuevo.Text = "Nuevo";

        btnmodificar.Enabled = true;
        btneliminar.Enabled = true;
        

    
    }
    protected void btnnuevo_Click(object sender, EventArgs e)
    {
        if (btnnuevo.Text=="Nuevo"){//canbia el txt del bot
             GUiEdicion();
             GUIlimpiar();
             btnnuevo.Text = "Guardar";
     
        }else if(btnnuevo.Text=="Guardar"){
            // sirve para captura errores en try
            try { 
                 clsempleado emp = new clsempleado(0, 0, "", "", "");  //iniciamos y mandamos los valores q espera la clase

                 //*******************CASO CUANDO SE MODIFICA UN EMPLEADO****************************
                if (emp.existe(int.Parse(txtidempleado.Text.Trim()))){  //obtenemos el idemple y lo mandamos a la clase emp
                     
                        emp.Idempleado = int.Parse(txtidempleado.Text);    // mandamos los valores otra vez a la clase
                        emp.Idacceso = int.Parse(rdbacceso.SelectedValue);
                        emp.Nombre = txtnombre.Text;
                        emp.Usuario = txtusuario.Text;

                        txtcontraseña.Attributes.Add("Value", emp.Contraseña);// emp.Contraseña = txtcontraseña.Text;   //muestra la contraseña normal
                    
                       emp.modificar();
                       GUIEdicionTerminada();
                       lblestado.Text="Registro actualizado";
                       btnnuevo.Text="Nuevo";

                }else{  //*******************CASO CUANDO SE CREA UN NUEVO EMPLEADO****************************
                        emp.Idempleado = int.Parse(txtidempleado.Text);    // sacamos el val de el form y lo mandamos al metodo
                        emp.Idacceso = int.Parse(rdbacceso.SelectedValue);// que lo almacena
                        emp.Nombre = txtnombre.Text;                      // emp.metodo
                        emp.Usuario = txtusuario.Text;
                        emp.Contraseña = txtcontraseña.Text;
                    //una vez mandado los valores a la clase

                     emp.agregar();//agregamos a al base de datos  
                     GUIEdicionTerminada();
                    
                     lblestado.Text = "Nuevo Registro Guardado";   
                    btnnuevo.Text="Nuevo";
                }
            }catch{
                lblestado.Text = "NO debe de dejar espacios en blanco";
            }         
        }
      



    }
    protected void btnmodificar_Click(object sender, EventArgs e)
    {   if (btnnuevo.Text=="Nuevo"){
               GUiEdicion();
                btnnuevo.Text = "Guardar"; //canbiamos el valor del boton
          } 
    }
    protected void btneliminar_Click(object sender, EventArgs e)
    {
        try
        {
            clsempleado emp = new clsempleado(0, 0, "", "", "");  //iniciamos

            emp.eliminar(int.Parse(txtidempleado.Text));
            lblestado.Text = "Registro Eliminado";
        }catch{
            lblestado.Text = "HUbo un error";
        }
    }
    protected void btnbuscar_Click(object sender, EventArgs e)
    {    
        //sirve para qe no se caiga el sistema en casos no definidos o extraños (try)
        //tb se debe de hacer donde hay conexiones a la base de datos
        btnmodificar.Enabled = true;
        btneliminar.Enabled = true;

        try{
            clsempleado emp = new clsempleado(0, 0, "", "", "");  //iniciamos
            if (emp.existe(int.Parse(txtbuscar.Text.Trim())))
            {
                txtidempleado.Text = emp.Idempleado.ToString();
                txtnombre.Text = emp.Nombre;
                txtusuario.Text = emp.Usuario;
                txtcontraseña.Text = emp.Contraseña;

                rdbacceso.SelectedIndex = rdbacceso.Items.IndexOf(rdbacceso.Items.FindByValue(emp.Idacceso.ToString()));
                lblestado.Text = "Registro Encontrado";
            }

            else { lblestado.Text = "NO hubieron resultados"; }
        }catch{  //mostramos un error donde queremos
            lblestado.Text = "NO existe un patron de busqueda";
        }
        

    }
    protected void btncancelar_Click(object sender, EventArgs e)
    {
        GUIEdicionTerminada();
    }
}