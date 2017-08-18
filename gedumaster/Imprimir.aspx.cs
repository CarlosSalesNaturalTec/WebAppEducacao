using System;
using System.Text;

public partial class Imprimir : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {

        string URIAux = Request.QueryString["p1"];

        string ScriptDados;
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);

        ScriptDados = "document.getElementById('result_Digitaliza1').innerHTML = '<img src=\"" + URIDoc(URIAux) + "\"/>'; ";
        str.Append(ScriptDados);

        ScriptDados = "window.print(); ";
        str.Append(ScriptDados);

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();
    }

    private string URIDoc(string IDDoc)
    {
        string uriFinal = "";

        string stringSelect = "select Digitaliza from Tbl_Funcionarios_Digitalizacoes where ID_Digitaliza = " + IDDoc;
        OperacaoBanco Operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = Operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            uriFinal = Convert.ToString(rcrdset[0]);
        }
        ConexaoBancoSQL.fecharConexao();

        return uriFinal;

    }

}