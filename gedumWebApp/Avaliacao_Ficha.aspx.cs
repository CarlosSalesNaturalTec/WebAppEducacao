using System;
using System.Text;

public partial class Avaliacao_Ficha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string idAux, idTurma;

    protected void Page_Load(object sender, EventArgs e)
    {
        idAux = Request.QueryString["v1"];          // ID da avaliação

        string idIns = Session["InstID"].ToString();        // ID da Instituição

        mostraDisciplina(idIns);
        mostrarTurma(idIns);
        mostrarPeriodo(idIns);

        PreencheCampos(idAux);

        mostraAlunos(idTurma);            // dropDown Alunos da Turma
        listaAl(idAux);                 // tabela com notas dos alunos

    }

    private void mostraDisciplina(string id)
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

    private void mostrarTurma(string id)
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

    private void mostrarPeriodo(string id)
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

    
    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);
        ScriptDados = "var x = document.getElementsByClassName('form-control');";
        str.Append(ScriptDados);

        string stringSelect = "select " +
            "id_disc," +
            "id_turma," +
            "tipo," +
            "id_periodo," +
            "format(dataAva,'yyyy-MM-dd') as d1, " +
            "notamax " +
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

            //ID da Avaliação
            ScriptDados = "document.getElementById('IDAuxHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

            //ID da Turma
            idTurma = Convert.ToString(rcrdset[1]);
        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }

    private void mostraAlunos(string id)
    {
        StringBuilder strA = new StringBuilder();
        strA.Clear();
        strA.Append("<option value=\"0\">Selecione um Aluno</option>");

        string select = "select id_aluno, Nome from tbl_alunos where id_turma = " + id;

        OperacaoBanco oper = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = oper.Select(select);

        while (dados.Read())
        {
            strA.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();

        literal_alunos.Text = strA.ToString();
    }

    private void listaAl(string ID)
    {

        string stringSelect = "select t1.id_aa, t2.nome, t1.nota " +
            "from tbl_aluno_avaliacao t1 " +
            "inner join tbl_alunos t2 on (t1.id_aluno = t2.ID_Aluno ) " +
            "where t1.id_avaliacao = " + ID;

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

        Literal_table.Text = str.ToString();

    }

}

