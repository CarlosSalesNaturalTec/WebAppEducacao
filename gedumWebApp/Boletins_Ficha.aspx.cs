using System;
using System.Collections.Generic;
using System.Text;

public partial class Boletins_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string idAux, idCurso, CursoAux, TurmaAux, IDTurmaAux;
    string periodo1 = "", periodo2 = "", periodo3 = "", periodo4 = "";
    string AnoLetivo = "0";

    int Taulas = 0, Tpresencas = 0, Tfaltas = 0;

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
        //dadosCorpo();
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

        // LIST/ARRAY auxiliar
        List<string> Lista_Periodos = new List<string>();

        string stringSelect = "select " +
            "Descricao " +
            "from tbl_periodo_avaliacao " +
            "where ID_inst = " + idAux;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            Lista_Periodos.Add(Convert.ToString(rcrdset[0]));
        }
        ConexaoBancoSQL.fecharConexao();

        for (int i = 0; i < Lista_Periodos.Count; i++)
        {
            switch (i)
            {
                case 0:
                    periodo1 = Lista_Periodos[i];
                    break;
                case 1:
                    periodo2 = Lista_Periodos[i];
                    break;
                case 2:
                    periodo3 = Lista_Periodos[i];
                    break;
                case 3:
                    periodo4 = Lista_Periodos[i];
                    break;
                default:
                    break;
            }
        }
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

            ScriptDados = "document.getElementById('input_Ano').value = \"" + AnoLetivo + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[3]) + "\"/>'; ";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

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
        string Coluna1 = "", Coluna2 = "", Coluna3 = "", Coluna4 = "", Coluna5 = "";

        // LIST/ARRAY auxiliar
        List<string> Lista_IdsDisc = new List<string>();

        // Disciplinas do Curso
        string select_aux = "select id_dsciplina " +
            "from tbl_cursos_disciplina " +
            "where iD_curso = " + idCurso;
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(select_aux);
        while (dados.Read())
        {
            Lista_IdsDisc.Add(Convert.ToString(dados[0]));
        }
        ConexaoBancoSQL.fecharConexao();

        // percorre todas as Disciplinas
        for (int i = 0; i < Lista_IdsDisc.Count; i++)
        {

            Coluna1 = nomeDisc(Lista_IdsDisc[i]);                                   //Nome da Disciplina

            percorreAulas(IDTurmaAux, Lista_IdsDisc[i]);

            Coluna2 = Taulas.ToString();
            Coluna3 = Tpresencas.ToString();
            Coluna4 = Tfaltas.ToString();

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

            Coluna5 = v3.ToString();

            // Monta linha
            string str_linha = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "</tr>";
            str.Append(str_linha);

        }

    }

    private void percorreAulas(string IDTurmaAux, string IDDiscAux)
    {

        Taulas = 0; Tpresencas = 0; Tfaltas = 0;

        string select_aux = "select ID_Aula " +
           "from Tbl_Alunos_Frequencia_Aulas " +
           "where ID_turma = " + IDTurmaAux +
           " and ID_Disc = " + IDDiscAux;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(select_aux);
        while (dados.Read())
        {
            Taulas++;   //total de aulas
            Verifica_Presenca(Convert.ToString(dados[0]), idAux);    //verifica presença a partir do ID_Aula e ID_Aluno
        }
        ConexaoBancoSQL.fecharConexao();
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

    private string nomeDisc(string ID_Disc_Aux)
    {
        string nomeRetorno = "XXX";

        string strSelect = "select Nome from Tbl_Disciplinas where ID_Disc = " + ID_Disc_Aux;
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);
        while (dados.Read())
        {
            nomeRetorno = Convert.ToString(dados[0]);
        }
        ConexaoBancoSQL.fecharConexao();

        return nomeRetorno;
    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);

        Literal_Table.Text = str.ToString();
    }


}