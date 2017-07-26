using System;

public partial class Visitas_Novo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string IdInst = Session["InstID"].ToString();

        //<!--*******Customização somente se for usar um "ID Auxiliar" para o novo registro *******-->
        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDAuxHidden').value = \"" + IdInst + "\";" +
                        "</script>";        
        Literal1.Text = ScriptAux;
        
    }
}