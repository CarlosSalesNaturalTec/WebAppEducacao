using System;
using System.Text;

public partial class Alunos_Frequencia_Presencas : System.Web.UI.Page
{
    StringBuilder strInst = new StringBuilder();
    string IDAula, IDturma;

    protected void Page_Load(object sender, EventArgs e)
    {
        IDAula = Request.QueryString["v1"];  //ID da Aula
        IDturma = Request.QueryString["v2"];  //ID da Turma

        Listar_Alunos(IDturma);
    }

    private void Listar_Alunos(string idAux)
    {

        strInst.Clear();
        string strSelect = "select ID_Aluno, Nome " +
            "from tbl_Alunos " +
            "where ID_turma = " + idAux;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        Literal_Aluno.Text = strInst.ToString();
    }

}