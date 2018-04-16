using System;
using System.Text;

public partial class Avaliacao_Listagem : System.Web.UI.Page
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

        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover table-bordered \">" +
            "<thead>" +
            "<tr>" +
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DISCIPLINA</th>" +
            "<th>TURMA</th>" +
            "<th>TIPO</th>" +
            "<th>PERIODO</th>" +
            "<th>DATA</th>" +
            "<th>NOTA MAX.</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string stringselect = "select t1.id_avaliacao, t2.nome, t4.nome, t1.tipo , t3.descricao, format(t1.dataAva,'dd/MM/yyyy'), t1.notaMax " +
                "from tbl_avaliacao t1 " +
                "inner join tbl_Disciplinas t2 on (t1.id_disc = t2.id_disc) " +
                "inner join tbl_periodo_avaliacao t3 on (t1.ID_Periodo = t3.ID_Periodo) " +
                "inner join tbl_turmas t4 on (t1.id_turma = t4.id_turma) " +
                "where t1.id_inst = " + InstID + " " +
                "order by t2.nome";

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

            string bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='Avaliacao_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
            string bt2 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Excluir(" + Coluna0 + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + bt2 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
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