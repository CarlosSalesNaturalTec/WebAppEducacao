using System;
using System.Text;

public partial class Turmas_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    StringBuilder strCombo = new StringBuilder();
    string idAux, idAux2;

    protected void Page_Load(object sender, EventArgs e)
    {

        idAux = Request.QueryString["v1"];          // ID da Turma
        idAux2 = Session["InstID"].ToString();      // id DA INSTITUIÇÃO;

        // preenche combo Cursos
        string stringselect = "select ID_curs,nome from tbL_cursos where id_inst = " + idAux2 + " order by Nome";
        Preenche_Combo(stringselect, "Selecione um Curso");
        Literal_Cursos.Text = strCombo.ToString();

        // preenche combo SALAS
        stringselect = "select ID_Sala,nome from tbL_salas where id_inst = " + idAux2 + " order by Nome";
        Preenche_Combo(stringselect, "Selecione uma Sala");
        Literal_Salas.Text = strCombo.ToString();

        PreencheCampos(idAux);
         mostrarAluno();
         listaAluno(idAux);
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
            "turno," +
            "Tipo_atend ," +
            "Multiplicada ," +
            "ID_curso, " +
            "id_SALA " +
            "from Tbl_Turmas " +
            "where ID_Turma = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 3; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            ScriptDados = "document.getElementById('input_curso').value = \"" + Convert.ToString(rcrdset[4]) + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('input_sala').value = \"" + Convert.ToString(rcrdset[5]) + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('IDHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";      
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }

    private void mostrarAluno()
    {
        StringBuilder strInst = new StringBuilder();
        strInst.Clear();
        strInst.Append("<option value=\"0\"> </option>");

        string strSelect = "select ID_Aluno, Nome from tbl_alunos";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        literal_aluno.Text = strInst.ToString();

    }

    private void listaAluno(string ID)
    {

        string stringSelect = "select tbl_turmas_alunos.id_ta, tbl_alunos.Nome" +
            " from tbl_turmas_alunos " +
            " inner join tbl_alunos on tbl_turmas_alunos.id_aluno = tbl_alunos.ID_Aluno " +
            " where tbl_turmas_alunos.id_turma = " + ID;


        OperacaoBanco operacaoUsers = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetUsers = operacaoUsers.Select(stringSelect);

        str.Clear();
        string ScriptDados;

        while (rcrdsetUsers.Read())
        {

            string bt1 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='ExcluirAluno(this," +
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

        Literal_table.Text = str.ToString();

    }


}