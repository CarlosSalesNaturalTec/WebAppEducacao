using System;

public partial class Turmas_Novo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + Session["InstID"].ToString() + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;
    }
}