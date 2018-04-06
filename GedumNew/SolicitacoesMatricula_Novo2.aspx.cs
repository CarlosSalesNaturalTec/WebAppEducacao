using System;
using System.Text;

public partial class SolicitacoesMatricula_Novo2 : System.Web.UI.Page
{
    StringBuilder strg = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        string idAux = Request.QueryString["v1"];
        string InstNome = Request.QueryString["v2"];

        lbl_inst1.Text = InstNome;
        lbl_inst2.Text = InstNome;

        mostrarCurso(idAux);
        IdInst(idAux);
    }

    private void mostrarCurso( string idaux) {
 
        strg.Clear();
        strg.Append("<option value=\"0\"> </option>");

        string strSelect = "select ID_Curs, Nome from Tbl_Cursos" +
            " where ID_inst = " + idaux +
            " order by Nome";

        OperacaoBanco oper = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = oper.Select(strSelect);

        while (dados.Read())
        {
            strg.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
        }

        ConexaoBancoSQL.fecharConexao();

        literal_curso.Text = strg.ToString();

    }

    private void IdInst(string idaux)
    {

        strg.Clear();
        strg.Append("<input id=\"IDHidden\" type=\"hidden\" value=\"" + idaux + "\"/>");
        Literal2.Text = strg.ToString();

    }
}