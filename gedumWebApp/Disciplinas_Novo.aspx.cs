using System;

public partial class Disciplinas_Novo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ID da Instituição
        string InstID = Session["InstID"].ToString();

        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + InstID + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;
    }
}