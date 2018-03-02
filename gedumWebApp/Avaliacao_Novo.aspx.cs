using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Avaliacao_Novo : System.Web.UI.Page
{

    
    protected void Page_Load(object sender, EventArgs e)
    {
        string idInst = Session["InstID"].ToString();

        
        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDInstHidden').value = \"" + idInst + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;

        mostraDisciplina(idInst);
        mostrarTurma(idInst);
    }


    private void mostraDisciplina(string id)
    {

        StringBuilder str = new StringBuilder();

        str.Clear();
        str.Append("<option value=\"0\"> </option>");

        string strSelect = "select ID_Disc, nome from Tbl_Disciplinas where ID_Inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            str.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        Literal_disciplina.Text = str.ToString();


    }

    private void mostrarTurma(string id)
    {
        StringBuilder str = new StringBuilder();

        str.Clear();
        str.Append("<option value=\"0\"> </option>");

        string strSelect = "select ID_Turma, Nome from Tbl_Turmas where ID_Inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            str.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        Literal_turma.Text = str.ToString();

    }
}