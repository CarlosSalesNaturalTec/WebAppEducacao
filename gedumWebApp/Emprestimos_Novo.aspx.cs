using System;
using System.Text;

public partial class Emprestimos_Novo : System.Web.UI.Page
{

    StringBuilder strCombo = new StringBuilder();
    string InstID;

    protected void Page_Load(object sender, EventArgs e)
    {
        string dataAtual = DateTime.Now.ToString("yyyy-MM-dd");

        //ID da Instituição
        InstID = Session["InstID"].ToString();
        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + InstID + "\";" +
                        "document.getElementById('input_data').value = \"" + dataAtual + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;

        // preenche combo Alunos
        string stringselect = "select ID_aluno, nome from tbl_Alunos where id_inst = " + InstID + " order by nome";
        Preenche_Combo(stringselect, "Selecione um Aluno");
        Literal_Aluno.Text = strCombo.ToString();

        // preenche combo Livros
        stringselect = "select ID_livro, nome from tbl_livros where id_inst = " + InstID + " order by nome";
        Preenche_Combo(stringselect, "Selecione um Livro");
        Literal_Livro.Text = strCombo.ToString();

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