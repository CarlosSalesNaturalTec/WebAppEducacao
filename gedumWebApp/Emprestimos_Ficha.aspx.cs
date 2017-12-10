using System;
using System.Text;

public partial class Emprestimos_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    StringBuilder strCombo = new StringBuilder();
    string idAux, InstID;

    protected void Page_Load(object sender, EventArgs e)
    {

        InstID = Session["InstID"].ToString();  // ID Instituição

        // preenche combo Alunos
        string stringselect = "select ID_aluno, nome from tbl_Alunos where id_inst = " + InstID + " order by nome";
        Preenche_Combo(stringselect, "Selecione um Aluno");
        Literal_Aluno.Text = strCombo.ToString();

        // preenche combo Livros
        stringselect = "select ID_livro, nome from tbl_livros where id_inst = " + InstID + " order by nome";
        Preenche_Combo(stringselect, "Selecione um Livro");
        Literal_Livro.Text = strCombo.ToString();

        idAux = Request.QueryString["v1"];      // ID do Empréstimo
        PreencheCampos(idAux);

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
            "ID_aluno," +
            "ID_livro," +
            "funcionario," +
            "format(dataOperacao,'yyyy-MM-dd') as d1," +
            "format(dataDevolucao,'yyyy-MM-dd') as d2 " +
            "from Tbl_controle_entregas " +
            "where ID_controle_entrega = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 4; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            //ID do registro
            ScriptDados = "document.getElementById('IDAuxHidden').value = \"" + ID + "\";";
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
}