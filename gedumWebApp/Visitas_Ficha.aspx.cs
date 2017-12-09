using System;
using System.Text;

public partial class Visitas_Ficha : System.Web.UI.Page
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
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);
        ScriptDados = "var x = document.getElementsByClassName('form-control');";
        str.Append(ScriptDados);

        string stringSelect = "select " +
            "Nome," +
            "format(DataVisita,'yyyy-MM-dd') as d1," +
            "Horario," +
            "Funcionario," +
            "Objetivo," +
            "Observacoes " +
            "from Tbl_Visitas  " +
            "where ID_Visita  = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 4; i++) 
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            // remove quebra de linha em campo TextArea
            ScriptDados = "document.getElementById('input_obs').value = \"" + Convert.ToString(rcrdset[5]).Replace("\n", "   ")  + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('IDAuxHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";      
        str.Append(ScriptDados);
    }
}