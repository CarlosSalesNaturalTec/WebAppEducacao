using System;
using System.Text;

public partial class Turmas_Novo : System.Web.UI.Page
{
    StringBuilder strCombo = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        //ID da Instituição
        string idAux = Session["InstID"].ToString();
        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + idAux + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;

        // preenche combo Cursos
        string stringselect = "select ID_curs,nome from tbL_cursos where id_inst = " + idAux + " order by Nome";
        Preenche_Combo(stringselect, "Selecione um Curso");
        Literal_Cursos.Text = strCombo.ToString();

        // preenche combo SALAS
        stringselect = "select ID_Sala,nome from tbL_salas where id_inst = " + idAux + " order by Nome";
        Preenche_Combo(stringselect, "Selecione uma Sala");
        Literal_Salas.Text = strCombo.ToString();

    }

    private void Preenche_Combo(string string_select, string label)
    {
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(string_select);

        strCombo.Clear();
        strCombo.Append("<option value=\"0\">" + label + "</option>");

        while (dados.Read())
        {
            strCombo.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + 
                Convert.ToString(dados[1]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();
    }

}