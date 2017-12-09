using System;
using System.Text;

public partial class Receitas_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string idAux, idProdutoAux;

    protected void Page_Load(object sender, EventArgs e)
    {
        idAux = Request.QueryString["v1"];

        // ID da Instituição
        idProdutoAux = Session["InstID"].ToString();

        PreencheCampos(idAux);
        listaReceitasItens(idAux);
        PreencheProdutos(idProdutoAux);

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
            "Nome," +
            "modo_preparo " +
            "from Tbl_Receitas " +
            "where ID_Receita = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 1; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            //ID do registro
            ScriptDados = "document.getElementById('IDHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }

    private void listaReceitasItens(string ID)
    {

        string stringSelect = "select ri.ID_receita_itens, ri.id_produto, p.descricao, ri.quantidade, ri.unidade "+
                              "from tbl_receitas_itens ri "+
                              "inner join tbl_produtos p on(ri.id_produto = p.id_produto) "+
            " where ri.ID_receita = " + ID +
            " order by ri.id_produto";
        OperacaoBanco operacaoUsers = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetUsers = operacaoUsers.Select(stringSelect);

        str.Clear();
        string ScriptDados;

        while (rcrdsetUsers.Read())
        {

            string bt1 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='ExcluirReceitasItens(this," +
                Convert.ToString(rcrdsetUsers[0]) +
                ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            ScriptDados = "<tr>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + bt1 + Convert.ToString(rcrdsetUsers[1]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[2]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[3]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[4]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "</tr>";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal2.Text = str.ToString();

    }

    private void PreencheProdutos(string ID)
    {

        string stringSelect = @"select ID_produto, descricao from Tbl_Produtos WHERE tipo='alimentos' order by Descricao";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

        str.Clear();

        string scrNome = "<select class=\"form-control\" id=\"select_produtos\">";
        str.Append(scrNome);

        scrNome = "<option value=\"0\">Selecione um Produto</option>";
        str.Append(scrNome);

        while (rcrdset.Read())
        {
            scrNome = "<option value=\"" + Convert.ToString(rcrdset[0]) + "\">" + Convert.ToString(rcrdset[1]) + "</option>";
            str.Append(scrNome);
        }
        ConexaoBancoSQL.fecharConexao();

        scrNome = "</select>";
        str.Append(scrNome);

        Literal_Produto.Text = str.ToString();


    }

}