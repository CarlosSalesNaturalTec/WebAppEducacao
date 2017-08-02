using System;

public partial class Alunos_Novo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //caso não esteja logado, gera um erro em tempo de execução e vai para página de login
        string IDInst = Session["InstID"].ToString();

        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + IDInst  + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;
    }
}