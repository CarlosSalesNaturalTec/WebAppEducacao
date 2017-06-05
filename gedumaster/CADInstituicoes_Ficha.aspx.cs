using System;
using System.Text;

public partial class CADInstituicoes_Ficha : System.Web.UI.Page
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

        string stringSelect = "select nome, diretor, email, tel,uf, cidade  " +
            "from Tbl_Instituicao " +
            "where ID_inst = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('input1').value = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('input2').value = \"" + Convert.ToString(rcrdset[1]) + "\";" +
                "document.getElementById('input3').value = \"" + Convert.ToString(rcrdset[2]) + "\";" +
                "document.getElementById('input4').value = \"" + Convert.ToString(rcrdset[3]) + "\";" +
                "document.getElementById('input5').value = \"" + Convert.ToString(rcrdset[4]) + "\";" +
                "document.getElementById('input6').value = \"" + Convert.ToString(rcrdset[5]) + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();

        str.Clear();
        str.Append(ScriptDados);
    }
}