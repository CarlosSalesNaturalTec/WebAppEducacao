using System;
using System.Text;

public partial class Alunos_Novo : System.Web.UI.Page

{
    protected void Page_Load(object sender, EventArgs e)

{
        StringBuilder str = new StringBuilder();

        string InstID = Session["InstID"].ToString();

        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDHidden').value = \"" + InstID + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;

        mostraCurso(InstID);
        mostraTurma(InstID);

    }

    private void mostraCurso(string id)
    {
        StringBuilder strInst = new StringBuilder();
        strInst.Clear();
        strInst.Append("<option value=\"0\"></option>");

        string strSelect = "select ID_Curs, Nome from Tbl_Cursos where ID_Inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        LITERAL_CURSO.Text = strInst.ToString();

    }

    private void mostraTurma(string id)
    {
        StringBuilder strInst = new StringBuilder();
        strInst.Clear();
        strInst.Append("<option value=\"0\"></option>");

        string strSelect = "select ID_turma, Nome from Tbl_Turmas where ID_Inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        literal_turma.Text = strInst.ToString();

    }
}