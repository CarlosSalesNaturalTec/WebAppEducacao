using System;
using System.Text;

public partial class SolicitacoesMatricula_Novo2 : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {

        string InstID = Session["InstID"].ToString();
        string idAux = Request.QueryString["v1"];

        mostraCurso(InstID);
        PreencheCampos(idAux);
        
    }

    private void mostraCurso(string id)
    {
        StringBuilder strInst = new StringBuilder();
        strInst.Clear();
        strInst.Append("<option value=\"0\"> </option>");

        string strSelect = "select ID_Curs, Nome from Tbl_Cursos where ID_Inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();

        LITERAL_CURSO.Text = strInst.ToString();

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
            "ID_curso," +
            "nome ," +
            "format(Nascimento,'yyyy-MM-dd') as d1 ," +
            "EstadoCivil ," +
            "pai, " +
            "mae, " +
            "Responsavel , " +
            "ResponsavelCPF," +
            "ResponsavelTel," +
            "ResponsavelEmail ," +
            "Naturalidade ," +
            "Nacionalidade," +
            "Etnia ," +
            "Deficiente  ," +
            "DeficienteTipo ," +
            "Endereco ," +
            "Latitude," +
            "Longitude, " +
            "Numero  ," +
            "Bairro  ," +
            "CEP ," +
            "cidade ," +
            "uf," +
            "TelFixo " +
            "from tbl_solicitacoes_matricula " +
            "where ID_Solicita = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 23; i++)
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

}