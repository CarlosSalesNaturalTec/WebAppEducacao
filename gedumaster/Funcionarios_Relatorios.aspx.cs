using System;
using System.Text;

public partial class Funcionarios_Relatorios : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {

        // somente usuarios nivel 1 tem acesso (gestor de município)
        int nivel = Convert.ToInt16(Session["UserLevel"].ToString());
        if (nivel != 1) { Response.Redirect("NaoAutorizado.aspx"); }

    }

}