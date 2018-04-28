using System;
using System.Text;

public partial class Avaliacao_Novo : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string AnoLetivo = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        string idInst = Session["InstID"].ToString();

        Verifica_AnoLetivo(idInst);

        preenchecampos(idInst);

        DropDown_Disciplina(idInst);
        DropDown_Turma(idInst);
        DropDown_Periodo(idInst);
    }

    private void Verifica_AnoLetivo(string idAux)
    {
        string strSelect = "select ano_letivo from tbl_parametros where ID_Inst = " + idAux;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            AnoLetivo = Convert.ToString(dados[0]);
        }
        ConexaoBancoSQL.fecharConexao();
    }

    private void preenchecampos(string idAux)
    {
        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + idAux + "\";" +
                        "document.getElementById('input_ano').value = \"" + AnoLetivo + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;
    }

    private void DropDown_Disciplina(string id)
    {
        str.Clear();
        str.Append("<option value=\"0\">Selecione uma Disciplina</option>");

        string strSelect = "select ID_Disc, nome from Tbl_Disciplinas where ID_Inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            str.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_disciplina.Text = str.ToString();
    }

    private void DropDown_Turma(string id)
    {

        str.Clear();
        str.Append("<option value=\"0\">Selecione uma Turma</option>");

        string strSelect = "select ID_Turma, Nome from Tbl_Turmas where ID_Inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            str.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_turma.Text = str.ToString();

    }

    private void DropDown_Periodo(string id)
    {
        str.Clear();
        str.Append("<option value=\"0\">Selecione o Período</option>");

        string select = "select id_periodo, Descricao from tbl_periodo_avaliacao where id_inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(select);

        while (dados.Read())
        {
            str.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
        }

        ConexaoBancoSQL.fecharConexao();

        Literal_periodo.Text = str.ToString();

    }

}