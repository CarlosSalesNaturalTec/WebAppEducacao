using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SolicitacoesMatricula_Novo2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        mostrarCurso();

    }

    private void mostrarCurso() {

        StringBuilder strg = new StringBuilder();
        strg.Clear();
        strg.Append("<option value=\"0\"> </option>");


        string strSelect = "select ID_Curs, Nome from Tbl_Cursos";

        OperacaoBanco oper = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = oper.Select(strSelect);


        while (dados.Read())
        {

            strg.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");


        }


        ConexaoBancoSQL.fecharConexao();

        literal_curso.Text = strg.ToString();

    }


}