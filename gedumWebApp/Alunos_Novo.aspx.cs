using System;


public partial class Alunos_Novo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string InstID = Session["InstID"].ToString();

        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDHidden').value = \"" + InstID + "\";" +
                        "</script>";
            
        Literal1.Text = ScriptAux;


    }
}