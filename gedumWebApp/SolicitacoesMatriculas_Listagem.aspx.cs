using System;
using System.Text;

public partial class SolicitacoesMatriculas_Listagem : System.Web.UI.Page
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

        //ID da instituição - Auxiliar
        Literal2.Text = "<input id=\"IDInstAux\" type=\"hidden\" value= \"" + InstID + "\" />";

    }

    private void montaCabecalho()
    {
        
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover table-bordered \">" +
            "<thead>" +
            "<tr>" +
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NOME</th>" +
            "<th>NASCIMENTO</th>" +
            "<th>CURSO</th>" +
            "<th>FILIAÇÃO - PAI</th>" +
            "<th>FILIAÇÃO - MÃE</th>" +
            "<th>DATA SOLIC.</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string stringselect = "select ID_Solicita , tbl_solicitacoes_matricula.Nome, format(Nascimento,'dd/MM/yyyy') as Nasc , " +
            "Tbl_Cursos.Nome as Curso, Pai, Mae, format(SolicitacaoData,'dd/MM/yyyy') as Solicitacao " +
            "from tbl_solicitacoes_matricula " +
            "INNER JOIN Tbl_Cursos ON tbl_solicitacoes_matricula.ID_Curso = Tbl_Cursos.ID_Curs " +
            "where tbl_solicitacoes_matricula.ID_Inst =" + InstID; 

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

            string bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='SolicitacoesMatriculas_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
            string bt2 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Excluir(" + Coluna0 + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";
            string bt3 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' onclick='Confirmar(" + Coluna0 + ",\"" + Coluna1 +"\")'><i class='fa fa-check-square' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            string stringcomaspas = "<tr>" +
                "<td>" + bt3 + bt1 + bt2 + Coluna1 + "</td>" +
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

    //
}