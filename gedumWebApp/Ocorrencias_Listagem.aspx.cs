using System;
using System.Text;

public partial class Ocorrencias_Listagem : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    int TotaldeRegistros = 0;
    string InstID;

    protected void Page_Load(object sender, EventArgs e)
    {

        //caso não esteja logado, gera um erro em tempo de execução e vai para página de login
        InstID = Session["InstID"].ToString();

        montaCabecalho();
        dadosCorpo();
        montaRodape();

        Literal1.Text = str.ToString();

    }

    private void montaCabecalho()
    {
        
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover table-bordered \">" +
            "<thead>" +
            "<tr>" +
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OCORRÊNCIA</th>" +
            "<th>DATA OCORRÊNCIA</th>" +
            "<th>TIPO OCORRÊNCIA</th>" +
            "<th>ALUNO</th>" +
            "<th>FUNCIONARIO</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {

  string stringselect = "select o.ID_ocorrencia, o.descricao_ocorrencia, o.data_ocorrencia, o.tipo_ocorrencia, " +
                "a.nome as aluno, f.nome as funcionario " + 
                "from tbl_Ocorrencias o " +
                "inner join tbl_alunos a on (o.id_aluno = a.id_aluno) " + 
                "inner join tbl_funcionarios f on(o.id_func = f.id_func) " +
                "where o.ID_Inst =" + InstID +
                "order by o.descricao_ocorrencia"; 

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
                        
            string bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='Ocorrencias_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
            string bt2 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Excluir(" + Coluna0 + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + bt2 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
            TotaldeRegistros += 1;
        }
        ConexaoBancoSQL.fecharConexao();

        lblTotalRegistros.Text = TotaldeRegistros.ToString();

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }
}