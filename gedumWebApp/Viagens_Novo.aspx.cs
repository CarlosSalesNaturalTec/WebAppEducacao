using System;
using System.Text;

public partial class Viagens_Novo : System.Web.UI.Page
{
    StringBuilder strCombo = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        //ID da Instituição
        string InstID = Session["InstID"].ToString();

        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + InstID + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;

        // preenche combo VEículos
        string stringselect = "select ID_veiculo,placa from tbL_veiculos where id_inst = " + InstID + " order by placa";
        Preenche_Combo(stringselect, "Selecione um Veículo");
        Literal_veiculo.Text = strCombo.ToString();
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