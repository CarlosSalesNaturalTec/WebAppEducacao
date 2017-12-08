using System;
using System.Text;

public partial class Viagens_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    StringBuilder strCombo = new StringBuilder();
    string idAux, InstID;

    protected void Page_Load(object sender, EventArgs e)
    {
        idAux = Request.QueryString["v1"];       // Id da Viagem
        InstID = Session["InstID"].ToString();   //ID da Instituição

        // preenche combo VEículos
        string stringselect = "select ID_veiculo,placa from tbL_veiculos where id_inst = " + InstID + " order by placa";
        Preenche_Combo(stringselect, "Selecione um Veículo");
        Literal_veiculo.Text = strCombo.ToString();

        PreencheCampos(idAux);
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

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);
        ScriptDados = "var x = document.getElementsByClassName('form-control');";
        str.Append(ScriptDados);

        string stringSelect = "select " +
            "format(data_viagem,'yyyy-MM-dd') as d1," +
            "motorista," +
            "hora_saida," +
            "km_inicial," +
            "hora_chegada," +
            "km_final," +
            "destino_viagem," +
            "motivo_viagem, " +
            "id_veiculo " +
            "from Tbl_Viagens " +
            "where ID_Viagem = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 7; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            ScriptDados = "document.getElementById('input_veiculo').value = \"" + Convert.ToString(rcrdset[8]) + "\";";
            str.Append(ScriptDados);

            //ID do registro
            ScriptDados = "document.getElementById('IDInstHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }


}