using System;
using System.Collections.Generic;
using System.Text;

public partial class Boletins_Ficha_Listagem : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string idAux, idCurso, CursoAux, TurmaAux, IDTurmaAux;
    string Coluna0 = "", Coluna1 = "", Coluna2 = "", Coluna3 = "", Coluna4 = "", Coluna5 = "";
    string AnoLetivo = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        idAux = Request.QueryString["v1"];      // ID do Aluno
        CursoAux = Request.QueryString["v2"];   // Nome do Curso
        TurmaAux = Request.QueryString["v3"];   // Nome da Turma
        IDTurmaAux = Request.QueryString["v4"]; // ID da Turma
        AnoLetivo = Request.QueryString["v5"];  // Ano Letivo

        string InstID = Session["InstID"].ToString();   //ID da Instituição

        PreencheCampos(idAux);

        montaCabecalho();
        dadosCorpo();
        montaRodape();
    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);

        string stringSelect = "select " +
            "ID_Curso," +
            "Nome," +
            "Matricula," +
            "FotoDataURI " +
            "from Tbl_Alunos " +
            "where ID_aluno  = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            idCurso = Convert.ToString(rcrdset[0]);

            ScriptDados = "document.getElementById('input_nome').value = \"" + Convert.ToString(rcrdset[1]) + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('input_mat').value = \"" + Convert.ToString(rcrdset[2]) + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[3]) + "\"/>'; ";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "document.getElementById('input_Ano').value = \"" + AnoLetivo + "\";";
        str.Append(ScriptDados);

        ScriptDados = "document.getElementById('input_Curso').value = \"" + CursoAux + "\";";
        str.Append(ScriptDados);

        ScriptDados = "document.getElementById('input_Turma').value = \"" + TurmaAux + "\";";
        str.Append(ScriptDados);

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        LiteralAux.Text = str.ToString();

    }

    private void montaCabecalho()
    {
        str.Clear();

        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>DISCIPLINA</th>" +
            "<th>TIPO AVALIAÇÃO</th>" +
            "<th>DATA AVALIAÇÃO</th>" +
            "<th>PERÍODO</th>" +
            "<th>NOTA MAX.</th>" +
            "<th>NOTA OBTIDA</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        //Disciplinas do Curso
        string strSelect = "select t1.id_dsciplina, t2.nome " +
            "from tbl_cursos_disciplina t1 " +
            "inner join Tbl_Disciplinas t2 on (t1.id_dsciplina = t2.id_disc) " +
            "where t1.ID_curso = " + idCurso +
            " order by t2.nome";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);
        while (dados.Read())
        {
            Coluna0 = Convert.ToString(dados[1]);    // nome da disciplina
            ListaAvaliacoesDisciplina(Convert.ToString(dados[0]), IDTurmaAux, AnoLetivo);
        }
        ConexaoBancoSQL.fecharConexao();
    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);

        Literal_Table.Text = str.ToString();
    }

    private void ListaAvaliacoesDisciplina(string idDisc, string idTurma, string Anoletivo)
    {
        //avaliacões da Disciplina na Turma no Ano Letivo
        string stringSelect = "select t1.id_avaliacao, T1.TIPO, format(t1.dataAva,'dd/MM/yyyy') as d1, t2.Descricao, format(t1.notaMax,'0.00') as n1 " +
            "from tbl_avaliacao t1 " +
            "inner join tbl_periodo_avaliacao t2 on (t1.ID_Periodo = t2.id_periodo) " +
            "where t1.id_Disc=" + idDisc +
            " and t1.id_turma=" + idTurma +
            " and t1.ano_letivo=" + Anoletivo +
            " order by t1.dataAva";
        OperacaoBanco operacao1 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset1 = operacao1.Select(stringSelect);
        while (rcrdset1.Read())
        {
            Coluna1 = Convert.ToString(rcrdset1[1]);        //TIPO DE AVALIAÇÃO
            Coluna2 = Convert.ToString(rcrdset1[2]);        //DATA AVALIAÇÃO
            Coluna3 = Convert.ToString(rcrdset1[3]);        //PERÍODO
            Coluna4 = Convert.ToString(rcrdset1[4]);        //NOTA MAX.
            Coluna5 = NotaObtida(Convert.ToString(rcrdset1[0]), idAux).ToString("0.00"); // nota obtida
           
            string stringcomaspas = "<tr>" +
                "<td>" + Coluna0 + "</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);

        }
        ConexaoBancoSQL.fecharConexao();

    }

    private decimal NotaObtida(string idAvaliacao, string idAluno)
    {
        decimal retornoNota = 0;

        string stringSelect = "select nota " +
            "from tbl_aluno_avaliacao " +
            "where id_avaliacao = " + idAvaliacao +
            " and id_aluno = " + idAluno;
        OperacaoBanco operacao2 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset2 = operacao2.Select(stringSelect);
        while (rcrdset2.Read())
        {
            retornoNota = Convert.ToDecimal(rcrdset2[0]);
        }
        ConexaoBancoSQL.fecharConexao();

        return retornoNota;
    }

}