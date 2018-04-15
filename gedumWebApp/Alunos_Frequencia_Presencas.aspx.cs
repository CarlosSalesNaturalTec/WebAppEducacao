using System;
using System.Text;

public partial class Alunos_Frequencia_Presencas : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string IDAula, IDturma;

    protected void Page_Load(object sender, EventArgs e)
    {
        IDAula = Request.QueryString["v1"];  //ID da Aula
        IDturma = Request.QueryString["v2"];  //ID da Turma

        string nomeTurma = Request.QueryString["v3"];  //nome da Turma
        string nomeDisc = Request.QueryString["v4"];  //nome da disciplina
        Literal1.Text = nomeTurma + " / " + nomeDisc;

        Listar_Alunos(IDturma);

        montaCabecalho();
        dadosCorpo();
        montaRodape();

        PreencheIDAula(IDAula);

    }

    private void Listar_Alunos(string idAux)
    {

        str.Clear();
        string strSelect = "select ID_Aluno, Nome " +
            "from tbl_Alunos " +
            "where ID_turma = " + idAux;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            str.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        Literal_Aluno.Text = str.ToString();
    }

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ALUNO</th>" +
            "<th>STATUS</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string stringselect = "select t1.ID_Freq, t2.Nome, t1.Presente " +
           "from Tbl_Alunos_Frequencia_Alunos t1 " +
           "inner join Tbl_Alunos t2 on (t1.ID_Aluno = t2.ID_Aluno) " +
           "where t1.ID_Aula = " + IDAula;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        string Coluna1 = "", Coluna2="", Coluna2a="";

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]); //id 

            Coluna1 = Convert.ToString(dados[1]);
            Coluna2 = Convert.ToString(dados[2]);

            if (Coluna2 == "True")
            {
                Coluna2a = "Presente";
            }
            else
            {
                Coluna2a = "Ausente";
            }

            string bt1 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='ExcluirAluno(this," +
                Convert.ToString(dados[0]) +
                ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + Coluna1 + "</td>" +
                "<td>" + Coluna2a + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
            
        }
        ConexaoBancoSQL.fecharConexao();

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
        Literal3.Text = str.ToString();
    }

    private void PreencheIDAula(string ID)
    {
        string ScriptDados = "";
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);

        ScriptDados = "document.getElementById('IDAuxHidden').value = \"" + ID + "\";";
        str.Append(ScriptDados);

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal2.Text = str.ToString();

    }

}