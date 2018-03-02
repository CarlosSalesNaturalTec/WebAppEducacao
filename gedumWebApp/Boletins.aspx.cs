using System;
using System.Text;

public partial class Boletins : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    StringBuilder strCombo = new StringBuilder();
    string idAux,idInstAux;

    protected void Page_Load(object sender, EventArgs e)
    {
        idInstAux = Session["InstID"].ToString();       // Id da Instituição
         
        PreencheCampos(idAux);
        anoLetivo();

        // preenche combo Alunos
        string stringselect = "select ID_aluno, nome from tbl_Alunos where id_inst = " + idInstAux + " order by nome";
        Preenche_Combo(stringselect, "Selecione um Aluno");
        Literal_aluno.Text = strCombo.ToString();

        string stringselect2 = "select ID_disc, nome from tbl_Disciplinas where id_inst = " + idInstAux + " order by nome";
        Preenche_Combo(stringselect2, "Selecione uma Disciplina");
        Literal_disciplina.Text = strCombo.ToString();

    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);

        //ID Da Instituição
        ScriptDados = "document.getElementById('IDHidden').value = \"" + ID + "\";";
        str.Append(ScriptDados);
        
        //Data Atual
        string dataAtual = DateTime.Now.ToString("yyyy-MM-dd");
        ScriptDados = "document.getElementById('input_dataavaliacao').value = \"" + dataAtual + "\";";
        str.Append(ScriptDados);

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

    private void anoLetivo()
    {

        StringBuilder str = new StringBuilder();

        str.Clear();
        str.Append("<option value=\"0\"> </option>");

        string select = "select ID_Inst, ano_letivo from tbl_parametros";

        OperacaoBanco oper = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = oper.Select(select);

        while (dados.Read())
        {
            str.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
            
        }

        ConexaoBancoSQL.fecharConexao();

        literal_input_anoletivo.Text = str.ToString();

    }

}