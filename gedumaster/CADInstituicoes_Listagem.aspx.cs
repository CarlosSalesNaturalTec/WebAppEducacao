using System;
using System.Text;

public partial class CADInstituicoes_Listagem : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string iduser;
    int TotaldeRegistros;

    protected void Page_Load(object sender, EventArgs e)
    {

        iduser = Session["UserID"].ToString();
        TotaldeRegistros = 0;

        montaCabecalho();
        dadosCorpo();
        montaRodape();

        Literal1.Text = str.ToString();
        lblTotalRegistros.Text = TotaldeRegistros.ToString();
    }

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;INSTITUIÇÃO</th>" +
            "<th>UF</th>" +
            "<th>CIDADE</th>" +
            "<th>DIRETOR</th>" +
            "<th>E-MAIL</th>" +
            "<th>TELEFONE</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string stringselect = "select ID_inst,Nome,uf,cidade,Diretor,email, Tel " +
                "from Tbl_Instituicao " +
                "order by Nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]); // id 

            string Coluna1 = Convert.ToString(dados[1]);
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);
            string Coluna5 = Convert.ToString(dados[5]);
            string Coluna6 = Convert.ToString(dados[6]);

            string bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='CADInstituicoes_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-pencil-square-o' aria-hidden='true'></i></a>";
            string bt2 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='ExcluirRegistro(" + Coluna0 + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + bt2 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
            TotaldeRegistros +=1;
        }
        ConexaoBancoSQL.fecharConexao();

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }
}