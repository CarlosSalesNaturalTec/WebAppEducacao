using System;

public partial class CAD_Instituicao_Novo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // <!--*******Customização somente se for usar um "ID Auxiliar" para o novo registro *******-->

        string IDMun = Session["ID_Munic"].ToString();
        
        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDMunicipio').value = \"" + IDMun + "\";" +
                        "</script>";        
        Literal1.Text = ScriptAux;
       
    }
}