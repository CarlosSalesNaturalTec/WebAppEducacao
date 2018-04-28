using System;
using System.Text;

public partial class Cursos_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string idAux;


    protected void Page_Load(object sender, EventArgs e)
    {
        idAux = Request.QueryString["v1"];      // ID do curso
        string idInst = Session["InstID"].ToString();

        PreencheCampos(idAux);
        mostraDisc(idInst);
        listaDisc(idAux);

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
            "sigla," +
            "equivalencia," +
            "modalidade_educacional," +
            "faixa_ini," +
            "faixa_fim," +
            "curso_anterior, " +
            "obs " +
            "from Tbl_Cursos " +
            "where ID_curs  = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 7; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            //ID do registro
            ScriptDados = "document.getElementById('IDInstHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

            //Nome do Curso
            ScriptDados = "document.getElementById('curso').innerHTML = \"" + Convert.ToString(rcrdset[0]) + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('curso1').innerHTML = \"" + Convert.ToString(rcrdset[0]) + "\";";
            str.Append(ScriptDados);

        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }

    private void mostraDisc(string id)
    {

        StringBuilder strInst = new StringBuilder();
        strInst.Clear();
        strInst.Append("<option value=\"0\"> </option>");

        string strSelect = "select ID_Disc, nome from Tbl_Disciplinas where ID_Inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        literal_disc.Text = strInst.ToString();

    }

    private void listaDisc(string ID)
    {

        string stringSelect = "select tbl_cursos_disciplina.id_cd, Tbl_Disciplinas.nome" +
            " from tbl_cursos_disciplina " +
            " inner join Tbl_Disciplinas on tbl_cursos_disciplina.id_dsciplina = Tbl_Disciplinas.ID_Disc " +
            " where tbl_cursos_disciplina.id_curso = " + ID;

        OperacaoBanco operacaoUsers = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetUsers = operacaoUsers.Select(stringSelect);

        str.Clear();
        string ScriptDados;

        while (rcrdsetUsers.Read())
        {

            string bt1 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='ExcluirDisc(this," +
                Convert.ToString(rcrdsetUsers[0]) +
                ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            ScriptDados = "<tr>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + bt1 + Convert.ToString(rcrdsetUsers[1]) + "</td>";
            str.Append(ScriptDados);


            ScriptDados = "</tr>";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal2.Text = str.ToString();

    }

   
    }




