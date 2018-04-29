using System;
using System.Text;

public partial class Boletins_Listagem : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string IDInst;

    protected void Page_Load(object sender, EventArgs e)
    {

        IDInst = Session["InstID"].ToString(); //ID da Instituição

        montaCabecalho();
        dadosCorpo();
        montaRodape();

        Literal1.Text = str.ToString();

    }

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NOME</th>" +
            "<th>CURSO</th>" +
            "<th>TURMA</th>" +
            "<th>RESPONSÁVEL</th>" +
            "<th>TEL. RESPONSÁVEL</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        // ANo Letivo
        string AnoLetivo = "0";
        string stringselect = "select ano_letivo from tbl_parametros where ID_Inst = " + IDInst;
        OperacaoBanco operacaoAno = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dadosAno = operacaoAno.Select(stringselect);
        while (dadosAno.Read())
        {
            AnoLetivo = Convert.ToString(dadosAno[0]);
        }
        ConexaoBancoSQL.fecharConexao();
        
        // LIstagem de Alunos da Instituição
        stringselect = "select tbl_Alunos.ID_aluno, tbl_Alunos.nome, Tbl_Cursos.nome as Curso, " +
                "Tbl_Turmas.Nome, tbl_Alunos.Responsavel, tbl_Alunos.ResponsavelTel, tbl_Alunos.ID_Turma " +
                "from tbl_Alunos " +
                "INNER JOIN Tbl_Cursos ON tbl_Alunos.ID_Curso = Tbl_Cursos.ID_Curs " +
                "INNER JOIN Tbl_Turmas ON tbl_Alunos.ID_Turma = Tbl_Turmas.ID_Turma " +
                "where tbl_Alunos.ID_Inst = " + IDInst +
                " order by tbl_Alunos.Nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        string Coluna0, Coluna1, Coluna2, Coluna3, Coluna4, Coluna5, bt1, bt2, stringcomaspas;

        while (dados.Read())
        {
            Coluna0 = Convert.ToString(dados[0]); //id 

            Coluna1 = Convert.ToString(dados[1]);
            Coluna2 = Convert.ToString(dados[2]);
            Coluna3 = Convert.ToString(dados[3]);
            Coluna4 = Convert.ToString(dados[4]);
            Coluna5 = Convert.ToString(dados[5]);

            bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='Boletins_Ficha.aspx" +
                "?v1=" + Coluna0 +      // ID do Aluno
                "&v2=" + Coluna2 +      // Nome do Curso
                "&v3=" + Coluna3 +      // Nome da Turma
                "&v4=" + Convert.ToString(dados[6]) +       // ID da Turma
                "&v5=" + AnoLetivo +                        // Ano Letivo
                "&v6=1" +                                   // 1 = Boletim Escolar   2 = Historico Escolar
                "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";

            bt2 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='Boletins_Ficha_Listagem.aspx" +
                "?v1=" + Coluna0 +      // ID do Aluno
                "&v2=" + Coluna2 +      // Nome do Curso
                "&v3=" + Coluna3 +      // Nome da Turma
                "&v4=" + Convert.ToString(dados[6]) +       // ID da Turma
                "&v5=" + AnoLetivo +                        // Ano Letivo
                "&v6=1" +                                   // 1 = Boletim Escolar   2 = Historico Escolar
                "'><i class='fa fa-list-alt' aria-hidden='true'></i></a>";

            stringcomaspas = "<tr>" +
                "<td>" + bt1 + bt2 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }
}