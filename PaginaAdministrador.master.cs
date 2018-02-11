using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaginaAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //verifica si la sesion se encuentra abierta o cerrada.
        try
        {
            if ((bool)(Session["login"]) == false)
            {
                Response.Redirect("~/pagelogin.aspx");
            }
            else if (Request.Cookies["login"] != null)
            {
                lblempleado.Text = Request.Cookies["login"]["usuario"];
                //String idempleado = Request.Cookies["login"]["idusuario"];
            }

        }
        catch { Response.Redirect("~/pagelogin.aspx"); }

    }
}
