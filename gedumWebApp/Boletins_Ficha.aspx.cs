using System;
using System.Collections.Generic;
using System.Text;

public partial class Boletins_Ficha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string idAux, idCurso, CursoAux, TurmaAux, IDTurmaAux;
    string periodo1 = "", periodo2 = "", periodo3 = "", periodo4 = "";
    int quantPeriodos = 0;
    string AnoLetivo = "0";
    List<string> Lista_IdPeriodos = new List<string>(); // IDs dos períodos de Avaliações
    int Taulas = 0, Tpresencas = 0, Tfaltas = 0;

    //ESTÁ MOSTRANDO sempre 4 colunas. alterar para quant dinamica de colunas

    protected void Page_Load(object sender, EventArgs e)
    {
        idAux = Request.QueryString["v1"];      // ID do Aluno
        CursoAux = Request.QueryString["v2"];   // Nome do Curso
        TurmaAux = Request.QueryString["v3"];   // Nome da Turma
        IDTurmaAux = Request.QueryString["v4"]; // ID da Turma

        string InstID = Session["InstID"].ToString();   //ID da Instituição

        Verifica_AnoLetivo(InstID);
        PreencheCampos(idAux);
        Verifica_Periodos(InstID);

        montaCabecalho();
        dadosCorpo();
        montaRodape();
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

    private void Verifica_Periodos(string idAux)
    {
        string stringSelect = "select Descricao, id_periodo " +
            "from tbl_periodo_avaliacao " +
            "where ID_inst = " + idAux;
        int i = 0;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            switch (i)
            {
                case 0:
                    periodo1 = Convert.ToString(rcrdset[0]);
                    Lista_IdPeriodos.Add(Convert.ToString(rcrdset[1]));
                    quantPeriodos++;
                    break;
                case 1:
                    periodo2 = Convert.ToString(rcrdset[0]);
                    Lista_IdPeriodos.Add(Convert.ToString(rcrdset[1]));
                    quantPeriodos++;
                    break;
                case 2:
                    periodo3 = Convert.ToString(rcrdset[0]);
                    Lista_IdPeriodos.Add(Convert.ToString(rcrdset[1]));
                    quantPeriodos++;
                    break;
                case 3:
                    periodo4 = Convert.ToString(rcrdset[0]);
                    Lista_IdPeriodos.Add(Convert.ToString(rcrdset[1]));
                    quantPeriodos++;
                    break;
                default:
                    break;
            }
            i++;
        }
        ConexaoBancoSQL.fecharConexao();
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
            "<th>" + periodo1 + "</th>" +
            "<th>" + periodo2 + "</th>" +
            "<th>" + periodo3 + "</th>" +
            "<th>" + periodo4 + "</th>" +
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
            "where t1.ID_curso = " + idCurso;
        string Coluna0 = "",Coluna1 ="", Coluna2="", Coluna3 = "", Coluna4 = "";
        string ColunaTemp = "";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);
        while (dados.Read())
        {
            Coluna0 = Convert.ToString(dados[1]);    // nome da disciplina

            // resultado da disciplina por período
            for (int i = 0; i < quantPeriodos; i++)
            {
                ColunaTemp = "média: <b>" + MediaPeriodo(Convert.ToString(dados[0]), Lista_IdPeriodos[i]) +
                            "</b>  freq.: <b>" + FrequenciaPeriodo(Convert.ToString(dados[0]), IDTurmaAux, Lista_IdPeriodos[i]) +
                            "%</b>";
                switch (i)
                {
                    case 0:
                        Coluna1 = ColunaTemp;
                        break;
                    case 1:
                        Coluna2 = ColunaTemp;
                        break;
                    case 2:
                        Coluna3 = ColunaTemp;
                        break;
                    case 3:
                        Coluna4 = ColunaTemp;
                        break;
                    default:
                        break;
                }
            }

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna0 + "</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();
    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);

        Literal_Table.Text = str.ToString();
    }

    private string MediaPeriodo(string idDisc, string idPer)
    {
        //avaliacões no periodo
        string stringSelect = "select id_avaliacao, notaMax  " + 
            "from tbl_avaliacao " +
            "where id_Disc=" + idDisc + 
            " and id_periodo=" + idPer ;
        decimal v1 = 0, v2 = 0;
        int quantAvaliacoes = 0;

        //soma resultados individuais = nota obtida / nota maxima
        OperacaoBanco operacao1 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset1 = operacao1.Select(stringSelect);
        while (rcrdset1.Read())
        {
            v1 = v1 + (NotaObtida(Convert.ToString(rcrdset1[0]), idAux) / Convert.ToDecimal(rcrdset1[1]));
            quantAvaliacoes++;
        }
        ConexaoBancoSQL.fecharConexao();

        //média = soma resultados individuais / quantidade de avaliações
        if (quantAvaliacoes>0)
        {
            v2 = (v1 / quantAvaliacoes) * 10;
        }

        return v2.ToString("0.0");
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

    private string FrequenciaPeriodo(string idDisc, string idTurma, string idPer)
    {
        //aulas da disciplina na turma no periodo
        string stringSelect = "select id_aula " +
            "from Tbl_Alunos_Frequencia_Aulas " +
            "where id_Disc=" + idDisc +
            " and id_turma=" + idTurma +
            " and id_periodo=" + idPer;

        //totaliza aulas,presencas e faltas
        Taulas = 0; Tpresencas = 0; Tfaltas = 0;
        OperacaoBanco operacao3 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset3 = operacao3.Select(stringSelect);
        while (rcrdset3.Read())
        {
            Taulas++;   //total de aulas
            Verifica_Presenca(Convert.ToString(rcrdset3[0]), idAux);    //verifica presença a partir do ID_Aula e ID_Aluno
        }
        ConexaoBancoSQL.fecharConexao();

        decimal v1 = Convert.ToDecimal(Taulas);
        decimal v2 = Convert.ToDecimal(Tpresencas);
        decimal v3;

        if (Taulas > 0)
        {
            v3 = (v2 / v1) * 100;
        }
        else
        {
            v3 = 0;
        }

        return v3.ToString("00.00");
    }

    private void Verifica_Presenca(string IDAulaAux, string IDAlunoAux)
    {

        //verifica se foi registrada presença do aluno na aula
        string select_aux = "select Presente " +
           "from Tbl_Alunos_Frequencia_Alunos  " +
           "where ID_Aula = " + IDAulaAux +
           " and ID_Aluno = " + IDAlunoAux;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(select_aux);
        while (dados.Read())
        {
            if (Convert.ToString(dados[0]) == "True")
            {
                Tpresencas++;
            }
            else
            {
                Tfaltas++;
            }
        }
        ConexaoBancoSQL.fecharConexao();

    }
}