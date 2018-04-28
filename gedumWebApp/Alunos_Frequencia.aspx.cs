using System;
using System.Text;

public partial class Alunos_Frequencia : System.Web.UI.Page
{
    StringBuilder strInst = new StringBuilder();
    StringBuilder str = new StringBuilder();
    string IDInst;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        IDInst = Session["InstID"].ToString();  //ID da Instituição

        Listar_Turmas(IDInst);
        Listar_Disc(IDInst);

        DropDown_Periodo(IDInst);

        PreencheCampos(IDInst);

    }

    private void Listar_Turmas(string idAux)
    {
        
        strInst.Clear();
        string strSelect = "select ID_turma, Nome " +
            "from tbl_turmas " +
            "where ID_Inst = " + idAux +
            " order by Nome";

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

    private void DropDown_Periodo(string id)
    {
        str.Clear();
        str.Append("<option value=\"0\"></option>");

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

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);

        string stringSelect = "select " +
            "id_periodo " +
            "from tbl_parametros " +
            "where id_inst = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "document.getElementById('input_periodo').value = \"" + Convert.ToString(rcrdset[0])  + "\";";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }
}