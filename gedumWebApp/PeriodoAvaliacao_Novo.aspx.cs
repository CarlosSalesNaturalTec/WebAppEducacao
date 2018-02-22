using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PeriodoAvalicao_Novo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string idInst = Session["InstID"].ToString();

        string scriptDados = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + idInst + "\";" +
                        "</script>";

        Literal1.Text = scriptDados;

    }
}