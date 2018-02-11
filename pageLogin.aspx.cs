using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pageLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//sino exixte postba
        {
            Session["login"] = false; //creamos  variable de cesion
            if (Request.Cookies["login"] != null)//revisa si existe el cookie
            {
                if (Request.Cookies["login"]["usuario"] != null)
                {
                    txtusuario.Text = Request.Cookies["login"]["usuario"];//tomamos el valor del co
                    string clv = Request.Cookies["login"]["clave"];
                    txtcontraseña.Attributes.Add("Value", clv);
                }
            }
            txtusuario.Focus();
        }
    }
    protected void btninicio_Click(object sender, EventArgs e)
    {
        

        try
        {
            clsempleado emp = new clsempleado(0, 0, "", "", "");  //iniciamos
            if (emp.login(txtusuario.Text, txtcontraseña.Text))
            {


                //cookies de inicio de sesion
                HttpCookie coologin = new HttpCookie("login");
                coologin["idusuario"] = emp.Idempleado.ToString();
                Session["login"] = true;

                if (chkboxrecordad.Checked) 
                {
                   // coologin["idusuario"] = emp.Idempleado.ToString();
                    coologin["usuario"] = txtusuario.Text;
                    coologin["clave"] = txtcontraseña.Text;
                    coologin.Expires = DateTime.Now.AddDays(1);//expira cuando pasa un dia
                    Response.Cookies.Add(coologin);
                }
                else
                {   //limpiamos la cookies a valores vacios
                    coologin["usuario"] = "";  
                    coologin["clave"] = "";
                    coologin.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(coologin);
                }

                //valida y redirecciona segun nivel de acceso
                if (emp.Idacceso == 1)
                {
                    //menu de administracion. todas las opciones programa
                    Response.Redirect("~/Default.aspx");
                }
                else if (emp.Idacceso == 2)
                {
                    //menu, opciones limitadas.
                    Response.Redirect("~/paginainicio");
                }
            }
            else {
                lblestado.Text="Validacion fallida";
                txtusuario.Focus();//ponemos el puntero en el input
            }
        }
        catch { 
        
        }

    }
}