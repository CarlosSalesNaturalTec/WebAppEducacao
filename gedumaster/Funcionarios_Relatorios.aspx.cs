using System;
using System.Text;

public partial class Funcionarios_Relatorios : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {

        // somente usuarios nivel 1 tem acesso (gestor de município)
        int nivel = Convert.ToInt16(Session["UserLevel"].ToString());
        if (nivel != 1) { Response.Redirect("NaoAutorizado.aspx"); }

        //============================================================================
        //graficos 
        string stringDadosGraf;

        // Bloco 1
        stringDadosGraf = "select lotado, count(ID_func) as q1 " +
            "from Tbl_Funcionarios " +
            "where ID_Munic = " + Session["ID_Munic"].ToString() +
            "group by lotado";
        Literal_Bloco1.Text = Monta_Graf_Morris_Bar(stringDadosGraf, "Bloco1_Chart");


        // Bloco 3
        stringDadosGraf = "select Funcao , count(ID_func) as q1 " +
            "from Tbl_Funcionarios " +
            "where ID_Munic = " + Session["ID_Munic"].ToString() +
            "group by Funcao ";
        Literal_Bloco3.Text = Monta_Graf_Morris_Donut(stringDadosGraf, "Bloco3_Chart");

        // Bloco 4
        stringDadosGraf = "select Vinculo , count(ID_func) as q1 " +
            "from Tbl_Funcionarios " +
            "where ID_Munic = " + Session["ID_Munic"].ToString() +
            "group by Vinculo ";
        Literal_Bloco4.Text = Monta_Graf_Morris_Donut(stringDadosGraf, "Bloco4_Chart");

        // Bloco 5
        stringDadosGraf = "select format(CadastroData,'dd/MM/yyyy') as d1, count(ID_func) as q1 " +
            "from Tbl_Funcionarios " +
            "where ID_Munic = " + Session["ID_Munic"].ToString() +
            "group by format(CadastroData,'dd/MM/yyyy')";
        Literal_Bloco5.Text = Monta_Graf_Morris_Bar(stringDadosGraf, "Bloco5_Chart");


        //============================================================================
    }

    private string Monta_Graf_Morris_Bar(string stringselect, string ID_Chart)
    {
        string txtAux = "";
        str.Clear();

        txtAux = "<script type=\"text/javascript\">";
        str.Append(txtAux);

        txtAux = "Morris.Bar({element: '" + ID_Chart + "', data: [";
        str.Append(txtAux);

        //dados
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        while (dados.Read())
        {
            txtAux = "{coluna: \"" + Convert.ToString(dados[0]) + "\", valor: " + Convert.ToString(dados[1]) + "},";
            str.Append(txtAux);
        }
        ConexaoBancoSQL.fecharConexao();

        txtAux = "],";
        str.Append(txtAux);

        txtAux = "xkey: 'coluna',";
        str.Append(txtAux);

        txtAux = "ykeys: ['valor'],";
        str.Append(txtAux);

        txtAux = "labels: ['Quant. Total']";
        str.Append(txtAux);

        txtAux = "});";
        str.Append(txtAux);

        txtAux = "</script>";
        str.Append(txtAux);

        return str.ToString();

    }

    private string Monta_Graf_Morris_Donut(string stringselect, string ID_Chart)
    {
        string txtAux = "";
        str.Clear();

        txtAux = "<script type=\"text/javascript\">";
        str.Append(txtAux);

        txtAux = "Morris.Donut({element: '" + ID_Chart + "', data: [";
        str.Append(txtAux);

        //dados
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        while (dados.Read())
        {
            txtAux = "{label: \"" + Convert.ToString(dados[0]) + "\", value: " + Convert.ToString(dados[1]) + "},";
            str.Append(txtAux);
        }
        ConexaoBancoSQL.fecharConexao();

        txtAux = "]});";
        str.Append(txtAux);

        txtAux = "</script>";
        str.Append(txtAux);

        return str.ToString();

    }

}