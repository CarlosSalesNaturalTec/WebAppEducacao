using System;
using System.Text;

public partial class Matriculas_Solicita_Listagem : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    int TotaldeRegistros = 0;
    string IDInst;
    int Ano_Letivo_Aux = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        //ID da Instituição
        IDInst = Session["InstID"].ToString();

        Ano_Letivo_Aux = Verifica_Ano_Letivo(IDInst);

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
            "<th>DATA SOLICITAÇÃO</th>" +
            "<th>STATUS</th>" +
            "<th>DATA CONFIRMAÇÃO</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string stringselect = "select ID_Solicita, nome, format(Data_Solicita,'dd/MM/yyyy') as d1 , Status_Solicita, format(Data_Confirma,'dd/MM/yyyy') as d2  " +
                "from tbl_matriculas_solicitacoes" +
                " where ID_Inst = " + IDInst +
                " and Ano_letivo = " + Ano_Letivo_Aux  +
                " order by Nome"; 

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]); //id 
        
            string Coluna1 = Convert.ToString(dados[1]);
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);

            string bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='Matriculas_Solicita_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
            string bt2 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Excluir(" + Coluna0 + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + bt2 + Coluna1 + "</td>" +
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

    private int Verifica_Ano_Letivo(string ID)
    {
        string stringselect = "select ano_letivo from Tbl_Parametros where id_inst = " + ID;
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        int Ano_Aux = 0;

        while (dados.Read())
        {
            Ano_Aux = Convert.ToInt16(dados[0]); 
        }
        ConexaoBancoSQL.fecharConexao();

        return Ano_Aux;

    }
}