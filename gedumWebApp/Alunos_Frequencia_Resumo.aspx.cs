using System;
using System.Text;

public partial class Alunos_Frequencia_Resumo : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    int TotaldeRegistros = 0;
    string IDInst;

    protected void Page_Load(object sender, EventArgs e)
    {

        //ID da Instituição
        IDInst = Session["InstID"].ToString();

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
        string stringselect = "select tbl_Alunos.ID_aluno, tbl_Alunos.nome, Tbl_Cursos.nome as Curso, " +
                "Tbl_Turmas.Nome, tbl_Alunos.Responsavel, tbl_Alunos.ResponsavelTel, tbl_Alunos.ID_Turma " +
                "from tbl_Alunos " +
                "INNER JOIN Tbl_Cursos ON tbl_Alunos.ID_Curso = Tbl_Cursos.ID_Curs " +
                "INNER JOIN Tbl_Turmas ON tbl_Alunos.ID_Turma = Tbl_Turmas.ID_Turma " +
                "where tbl_Alunos.ID_Inst = " + IDInst +
                " order by tbl_Alunos.Nome";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]); //id 

            string Coluna1 = Convert.ToString(dados[1]);
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);
            string Coluna5 = Convert.ToString(dados[5]);

            string bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='Alunos_Ficha_Frequencia.aspx" +
                "?v1=" + Coluna0 + 
                "&v2=" + Coluna2 +
                "&v3=" + Coluna3 +
                "&v4=" + Convert.ToString(dados[6]) +       // ID da Turma
                "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
        
            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
            TotaldeRegistros += 1;
        }
        ConexaoBancoSQL.fecharConexao();

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }
}