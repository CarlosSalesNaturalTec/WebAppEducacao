using System;
using System.Text;

public partial class Alunos_Frequencia : System.Web.UI.Page
{
    StringBuilder strInst = new StringBuilder();
    string IDInst;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        IDInst = Session["InstID"].ToString();  //ID da Instituição

        Listar_Turmas(IDInst);
        Listar_Disc(IDInst);

    }

    private void Listar_Turmas(string idAux)
    {
        
        strInst.Clear();
        string strSelect = "select ID_turma, Nome from tbl_turmas where ID_Inst = " + idAux;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        Literal_Turmas.Text = strInst.ToString();
    }

    private void Listar_Disc(string idAux)
    {
        strInst.Clear();
        string strSelect = "select ID_disc, Nome from Tbl_Disciplinas where ID_Inst = " + idAux;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_Disc.Text = strInst.ToString();
    }
}