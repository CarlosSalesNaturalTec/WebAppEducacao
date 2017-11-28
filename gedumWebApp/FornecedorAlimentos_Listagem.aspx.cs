using System;
using System.Text;

public partial class FornecedorAlimentos_Listagem : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    int TotaldeRegistros = 0;
    string InstID;

    protected void Page_Load(object sender, EventArgs e)
    {
        InstID = Session["InstID"].ToString();

        montaCabecalho();
        dadosCorpo();
        montaRodape();

        Literal1.Text = str.ToString();

    }

    private void montaCabecalho()
    {
        // <!--*******Customização*******-->
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover table-bordered \">" +
            "<thead>" +
            "<tr>" +
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Nome</th>" +
            "<th>CPF/CNPJ</th>" +
            "<th>CIDADE</th>" +
            "<th>TELEFONE 1</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        // <!--*******Customização*******-->
        string stringselect = "select ID_FornecedorAlimento, descricao, cpf_cnpj, cep , rua, " +
                "numero, complemento, bairro, cidade, uf, telefone1, telefone2, email, home_page, obs " +
                "from Tbl_FonrecedorAlimentos " +
                "where ID_Inst =" + InstID +
                " and tipo = 'ALIMENTOS'" + 
                " order by Descricao";

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
            string Coluna6 = Convert.ToString(dados[6]);
            string Coluna7 = Convert.ToString(dados[7]);
            string Coluna8 = Convert.ToString(dados[8]);
            string Coluna9 = Convert.ToString(dados[9]);
            string Coluna10 = Convert.ToString(dados[10]);
            string Coluna11 = Convert.ToString(dados[11]);
            string Coluna12 = Convert.ToString(dados[12]);
            string Coluna13 = Convert.ToString(dados[13]);
            string Coluna14 = Convert.ToString(dados[14]);

            // <!--*******Customização*******-->
            string bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='Produtos_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
            string bt2 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Excluir(" + Coluna0 + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + bt2 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                "<td>" + Coluna7 + "</td>" +
                "<td>" + Coluna8 + "</td>" +
                "<td>" + Coluna9 + "</td>" +
                "<td>" + Coluna10 + "</td>" +
                "<td>" + Coluna11 + "</td>" +
                "<td>" + Coluna12 + "</td>" +
                "<td>" + Coluna13 + "</td>" +
                "<td>" + Coluna14 + "</td>" +
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