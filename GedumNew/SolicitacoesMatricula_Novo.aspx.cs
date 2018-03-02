using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SolicitacoesMatricula_Novo : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        string str = Request.QueryString["v1"];

        string ScriptAux = "<script type=\"text/javascript\">" +
                    "document.getElementById('IDHidden').value = \"" + str + "\";" +
                    "</script>";
        Literal1.Text = ScriptAux;


        mostraInstituicao();

    }

  
    private void mostraInstituicao()
    {
        StringBuilder strg = new StringBuilder();
        strg.Clear();
        strg.Append("<option value=\"0\"> </option>");
        

        string strSelect = "select ID_inst, Nome from Tbl_instituicao";
        
        OperacaoBanco oper = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = oper.Select(strSelect);
        

        while (dados.Read())
        {

            strg.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");
            

        }

    
       ConexaoBancoSQL.fecharConexao();

        literal_inst.Text = strg.ToString();
    }
}