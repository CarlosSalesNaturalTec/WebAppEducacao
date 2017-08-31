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

        string idMunicAux = Session["ID_Munic"].ToString();

        PreencheInstituicoes(idMunicAux);

    }

    private void PreencheInstituicoes(string idMunic)
    {

        StringBuilder strInst = new StringBuilder();
        strInst.Clear();
        strInst.Append("<option value=\"Todas\">Todas</option>");

        string strSelect = "select Instituicao " + 
            "from Tbl_Funcionarios_CargaHor " +
            "INNER JOIN Tbl_Funcionarios  ON Tbl_Funcionarios_CargaHor.ID_func  = Tbl_Funcionarios.ID_func " +
            "where Tbl_Funcionarios.ID_Munic = " + idMunic +
            " group by Instituicao";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[0]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();

        literal_instituicao.Text = strInst.ToString();

    }

}