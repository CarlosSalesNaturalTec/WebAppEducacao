using System;
using System.Text;

public partial class Funcionarios_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        PreencheCampos(Request.QueryString["v1"]);
        Literal1.Text = str.ToString();
    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";

        //<!--*******Customização*******-->
        string stringSelect = "select Nome " +
            "from tbl_Funcionarios " +
            "where ID_func  = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('input_nome').value = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "</script>";
        }
        
        ConexaoBancoSQL.fecharConexao();

        str.Clear();
        str.Append(ScriptDados);
    }
}