using System;
using System.Text;

public partial class Funcionarios_Listagem : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    int TotaldeRegistros = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        //caso não esteja logado, gera um erro em tempo de execução e vai para página de login
        string iduser = Session["UserID"].ToString();

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
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NOME</th>" +
            "<th>FUNÇÃO</th>" +
            "<th>SETOR</th>" +
            "<th>TELEFONE</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string stringselect = "select ID_func , nome, funcao, setor, telefone " +
                "from Tbl_Funcionarios " +
                "order by Nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]); //id atleta

            string Coluna1 = Convert.ToString(dados[1]);
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);
            
            string bt1 = "<a class='w3-btn w3-round w3-hover-blue' href='Funcionarios_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
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