using System;
using System.Text;

public partial class Ocorrencias_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    StringBuilder strCombo = new StringBuilder();
    string idAux, InstID;

    protected void Page_Load(object sender, EventArgs e)
    {

        InstID = Session["InstID"].ToString();  // ID Instituição

        // preenche combo Livros
        string stringselectF = "select ID_func, nome from tbl_funcionarios "; //  where id_inst = " + InstID + " order by nome";
        Preenche_Combo(stringselectF, "Selecione um Funcionário");
        Literal_Funcionario.Text = strCombo.ToString();

        // preenche combo Alunos
        string stringselect = "select ID_aluno, nome from tbl_Alunos where id_inst = " + InstID + " order by nome";
        Preenche_Combo(stringselect, "Selecione um Aluno");
        Literal_Aluno.Text = strCombo.ToString();

        idAux = Request.QueryString["v1"];      // ID do Ocorrências
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
            "ID_func," +
            "ID_aluno," +            
            "format(data_ocorrencia,'yyyy-MM-dd') as d1," +
            "tipo_ocorrencia, " +
            "descricao_ocorrencia, " +
            "ID_Inst " +
            "from Tbl_Ocorrencias " +
            "where ID_Ocorrencia = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 4; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            //ID do registro
            ScriptDados = "document.getElementById('IDAuxHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }

    private void Preenche_Combo(string string_select, string label)
    {
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(string_select);

        strCombo.Clear();
        strCombo.Append("<option value=\"0\">" + label + "</option>");

        while (dados.Read())
        {
            strCombo.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" +
                Convert.ToString(dados[1]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();
    }
}