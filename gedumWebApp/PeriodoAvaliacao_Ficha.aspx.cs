using System;
using System.Text;

public partial class PeriodoAvalicao_Ficha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {


        string iDi = Request.QueryString["v1"];

        PreencheCampos(iDi);


        
    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);
        ScriptDados = "var x = document.getElementsByClassName('form-control');";
        str.Append(ScriptDados);

        string stringselect = "select Descricao " +
                "from tbl_periodo_avaliacao " +
                "where id_periodo = " + ID;
                
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringselect);
        while (rcrdset.Read())
        {
            for (int i = 0; i < 1 ; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            ScriptDados = "document.getElementById('IDInstHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();
        
    }




}