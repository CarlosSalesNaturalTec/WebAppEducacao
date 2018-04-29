using System;
using System.Text;

public partial class Historico_Escolar : System.Web.UI.Page
{
    StringBuilder strInst = new StringBuilder();
    string IDInst;

    protected void Page_Load(object sender, EventArgs e)
    {  
        IDInst = Session["InstID"].ToString();  //ID da Instituição
        DropDwon_Alunos(IDInst);       
    }

    private void DropDwon_Alunos(string idAux)
    {
        strInst.Clear();
        string strSelect = "select t1.ID_Aluno, t1.Nome " +
            "from tbl_alunos t1 " +
            "inner join tbl_turmas t2 on (t1.id_turma = t2.id_turma)" +
            " where t1.ID_Inst = " + idAux +
            " order by t1.Nome";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_Alunos.Text = strInst.ToString();
    }

}