using System;
using System.Text;

public partial class Matriculas_Solicita_Novo : System.Web.UI.Page
{

    StringBuilder strCombo = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        // id da instituição
        string IDInst = Session["InstID"].ToString();

        // ano letivo
        int Ano_Letivo_Aux = 0;
        Ano_Letivo_Aux = Verifica_Ano_Letivo(IDInst);

        //preeenche campos auxiliares
        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + IDInst  + "\";" +
                        "document.getElementById('AnoLetivoHidden').value = \"" + Ano_Letivo_Aux + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;

        // preenche combo Cursos
        string stringselect = "select ID_curs,nome from tbL_cursos where id_inst = " + IDInst + " order by Nome";
        Preenche_Combo(stringselect, "Selecione um Curso");
        Literal_Cursos.Text = strCombo.ToString();

    }

    private int Verifica_Ano_Letivo(string ID)
    {
        string stringselect = "select ano_letivo from Tbl_Parametros where id_inst = " + ID;
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        int Ano_Aux = 0;

        while (dados.Read())
        {
            Ano_Aux = Convert.ToInt16(dados[0]);
        }
        ConexaoBancoSQL.fecharConexao();

        return Ano_Aux;

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