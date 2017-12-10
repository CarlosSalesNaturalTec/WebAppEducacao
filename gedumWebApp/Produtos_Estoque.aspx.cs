using System;
using System.Text;

public partial class Produtos_Estoque : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    StringBuilder strCombo = new StringBuilder();
    string idAux,idInstAux;

    protected void Page_Load(object sender, EventArgs e)
    {
        idAux = Request.QueryString["v1"];              // ID do produto
        idInstAux = Session["InstID"].ToString();       // Id da Instituição
         
        PreencheCampos(idAux);

        // preenche combo Fornecedores
        string stringselect = "select ID_fornecedoralimento, descricao from tbl_Fornecedor_Alimentos where id_inst = " + idInstAux + " order by descricao";
        Preenche_Combo(stringselect, "Selecione um Fornecedor");
        Literal_Fornec.Text = strCombo.ToString();

        Monta_Grid();

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
            "tipo, " +            
            "unidade, " +
            "Descricao " +
            "from Tbl_Produtos " +
            "where ID_Produto = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 1; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            //Nome do Produto
            Literal_Produto.Text = Convert.ToString(rcrdset[2]);

            //ID do registro
            ScriptDados = "document.getElementById('IDProdutoHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

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

    private void Monta_Grid() {

        string stringselect = "select ID_Operacao , format(DataOperacao,'dd/MM/yyyy') as d1 , Documento , Forn_Resp ,Quant_Entrada , Quant_Saida  " +
                "from Tbl_Produtos_Movimento  " +
                "where ID_Produto =" + idAux +
                " order by DataOperacao desc";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        str.Clear();
        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]);
            string Coluna1 = Convert.ToString(dados[1]);
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);
            string Coluna5 = Convert.ToString(dados[5]);

            string bt1 = "<a id='bt_excluirEstoque' class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Estoque_Excluir(" + Coluna0 + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
            
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_historico.Text = str.ToString();

    }
}