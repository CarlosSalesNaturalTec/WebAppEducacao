using System;
using System.Text;

public partial class Turmas_Novo : System.Web.UI.Page
{
    StringBuilder strCombo = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        //ID da Instituição
        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + Session["InstID"].ToString() + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;

        // preenche combo SALAS
        string stringselect = "select ID_Sala , nome " +
                "from tbL_salas " +
                "order by Nome";
        Preenche_Combo(stringselect);

    }

    private void Preenche_Combo(string string_select)
    {
       
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(string_select);

        strCombo.Clear();
        strCombo.Append("<option value=\"0\">Selecione uma Sala</option>");

        while (dados.Read())
        {
            strCombo.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();
    }

}