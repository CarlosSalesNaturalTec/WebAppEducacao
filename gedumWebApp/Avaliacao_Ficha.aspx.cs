using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Avaliacao_Ficha : System.Web.UI.Page
{


    StringBuilder str = new StringBuilder();
    string idAux;


    protected void Page_Load(object sender, EventArgs e)
    {
        idAux = Request.QueryString["v1"];

        string idIns = Session["InstID"].ToString();

        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDinst').value = \"" + idIns + "\";" +
                        "</script>";

        Literal1.Text = ScriptAux;

        
        mostraDisc(idIns);
        mostraTurma(idIns);
        mostrarPeriodo(idIns);
        mostraAlunos(idIns);
        PreencheCampos(idAux);



    }

 
    private void mostraDisc(string id)
    {

        StringBuilder strInst = new StringBuilder();
        strInst.Clear();
        strInst.Append("<option value=\"0\"> </option>");

        string strSelect = "select ID_Disc, nome from Tbl_Disciplinas where ID_Inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        Literal_disciplina.Text = strInst.ToString();
  }

    private void mostraTurma(string id)
{

        StringBuilder strInst = new StringBuilder();
        strInst.Clear();
        strInst.Append("<option value=\"0\"> </option>");

        string strSelect = "select ID_Turma, Nome from Tbl_Turmas where ID_Inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        Literal_turma.Text = strInst.ToString();

    }

    private void mostrarPeriodo(string id)
    {

        StringBuilder strP = new StringBuilder();
        strP.Clear();
        strP.Append("<option value=\"0\"> </option>");

        string select = "select id_periodo, Descricao from tbl_periodo_avaliacao where id_inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(select);

        while (dados.Read())
        {
            strP.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
        }

        ConexaoBancoSQL.fecharConexao();

        Literal_periodo.Text = strP.ToString();

    }

    private void mostraAlunos(string id)
    {
        StringBuilder strA = new StringBuilder();
        strA.Clear();
        strA.Append("<option value=\"0\"> </option>");

        string select = "select id_aluno, Nome from tbl_alunos where id_inst = " + id;

        OperacaoBanco oper = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = oper.Select(select);

        while (dados.Read())
        {
            strA.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();

        literal_alunos.Text = strA.ToString();
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
            "disciplina," +
            "turma," +
            "tipo," +
            "periodo," +
            "format(dataAva,'yyyy-MM-dd') as d1, " +
            "nota " +
            "from tbl_avaliacao " +
            "where id_avaliacao  = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 5; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            //ID do registro
            ScriptDados = "document.getElementById('IDInstHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);


        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }

    private void listaDisc(string ID)
    {

        string stringSelect = "select tbl_aluno_avaliacao.id_aa, tbl_alunos.nome, tbl_aluno_avaliacao.nota" +
            " from tbl_aluno_avaliacao " +
            " inner join tbl_aluno on tbl_aluno_avaliacao.id_aluno = tbl_alunos.ID_Aluno " +
            " where tbl_aluno_avaliacao.id_avaliacao = " + ID;

        OperacaoBanco operacaoUsers = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetUsers = operacaoUsers.Select(stringSelect);

        str.Clear();
        string ScriptDados;

        while (rcrdsetUsers.Read())
        {

            string bt1 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='ExcluirAl(this," +
                Convert.ToString(rcrdsetUsers[0]) +
                ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            ScriptDados = "<tr>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + bt1 + Convert.ToString(rcrdsetUsers[1]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[2]) + "</td>";
            str.Append(ScriptDados);


            ScriptDados = "</tr>";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal2.Text = str.ToString();

    }




}

