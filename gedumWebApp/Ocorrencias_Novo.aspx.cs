using System;
using System.Text;

public partial class Ocorrencias_Novo : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    StringBuilder strCombo = new StringBuilder();
    string idAux, InstID;

    protected void Page_Load(object sender, EventArgs e)
    {
        //ID da Instituição
        string InstID = Session["InstID"].ToString();

        // preenche combo Alunos
        string stringselect = "select ID_aluno, nome from tbl_Alunos where id_inst = " + InstID + " order by nome";
        Preenche_Combo(stringselect, "Selecione um Aluno");
        Literal_Aluno.Text = strCombo.ToString();

        // preenche combo Funcionários
        // string stringselectF = "select ID_func, nome from tbl_Funcionarios where id_inst = " + InstID + " order by nome";
        string stringselectF = "select ID_func, nome from tbl_Funcionarios order by nome";
        Preenche_Combo(stringselectF, "Selecione um Funcionário");
        Literal_Funcionario.Text = strCombo.ToString();

        //Data Atual
        string dataAtual = DateTime.Now.ToString("yyyy-MM-dd");

        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + InstID + "\";" +
                        "document.getElementById('input_data_ocorrencia').value = \"" + dataAtual + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;
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