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

        // <!--*******Customização. adicionar todos os campos, separados um em cada linha*******-->
        string stringSelect = "select " +
            "Nome," +
            "DataVisita," +
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
            for (int i = 0; i < 6; i++)  // <!--*******Customização*******--> Atenção para quantidade de campos. Ex: neste formulario tenho 2 campos 
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            ScriptDados = "document.getElementById('IDAuxHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";      
        str.Append(ScriptDados);
    }
}