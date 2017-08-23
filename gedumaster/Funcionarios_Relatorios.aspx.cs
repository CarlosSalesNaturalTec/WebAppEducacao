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

        Instituicoes(Session["ID_Munic"].ToString());

    }

    private void Instituicoes(string idaux)
    {
        str.Clear();
        string Coluna0, Coluna1;
        string stringselect = "select ID_inst , nome " +
                "from Tbl_Instituicao  " +
                "where ID_Munic = " + idaux +
                " order by Nome";

        str.Append("<option value=\"TODAS\">TODAS</option>");

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        while (dados.Read())
        {
            Coluna0 = Convert.ToString(dados[0]); //id
            Coluna1 = Convert.ToString(dados[1]);
            str.Append("<option value=\"" + Coluna0 + "\">" + Coluna1 + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_Instituicoes.Text = str.ToString();
    }
}