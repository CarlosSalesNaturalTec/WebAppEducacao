using System;
using System.Text;

public partial class Cursos_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string idAux;

    protected void Page_Load(object sender, EventArgs e)
    {
        idAux = Request.QueryString["v1"];
        PreencheCampos(idAux);
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
            "sigla," +
            "equivalencia," +
            "modalidade_educacional," +
            "faixa_ini," +
            "faixa_fim," +
            "curso_anterior, " +
            "obs " +
            "from Tbl_Cursos " +
            "where ID_curs  = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 7; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            //ID do registro
            ScriptDados = "document.getElementById('IDInstHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";      
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }


}