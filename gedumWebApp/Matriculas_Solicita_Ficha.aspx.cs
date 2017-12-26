using System;
using System.Text;

public partial class Matriculas_Solicita_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    StringBuilder strCombo = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        // ID da Solicitação de Matricula
        string idAux = Request.QueryString["v1"];   

        // id da instituição
        string IDInst = Session["InstID"].ToString();

        // preenche combo Cursos
        string stringselect = "select ID_curs,nome from tbL_cursos where id_inst = " + IDInst + " order by Nome";
        Preenche_Combo(stringselect, "Selecione um Curso");
        Literal_Cursos.Text = strCombo.ToString();

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
            "Nome," +
            "format(Nascimento,'yyyy-MM-dd') as d1, " +
            "EstadoCivil," +
            "Pai," +
            "Mae," +
            "Responsavel," +
            "ResponsavelCPF," +
            "ResponsavelTel," +
            "Naturalidade," +
            "Nacionalidade," +
            "Etnia," +
            "TipoSanguinio," +
            "Deficiente," +
            "DeficienteTipo," +
            "Endereco," +
            "Latitude," +
            "Longitude," +
            "Numero," +
            "Bairro," +
            "CEP," +
            "Cidade," +
            "UF," +
            "Celular1," +
            "Celular2," +
            "TelFixo," +
            "email," +
            "PIS," +
            "CPF," +
            "RG," +
            "RGEmissor," +
            "RGEmissao," +
            "CTPS," +
            "CTPSserie," +
            "CTPSEmissao," +
            "Titulo," +
            "Zona," +
            "Secao," +
            "CNH," +
            "Passaporte," +
            "CertNasc ," +
            "Alergias," +
            "AlergiasMed," +
            "AcidenteAvisar," +
            "CartaoSUS," +
            "FardaCamisa," +
            "FardaCamiseta," +
            "FardaCalca," +
            "FardaSapato," +
            "FardaBota," +
            "FardaObs," +
            "format(Data_Confirma,'yyyy-MM-dd') as d2, " +
            "Matricula, " +
            "ID_Curso," +
            "FotoDataURI " +
            "from tbl_matriculas_solicitacoes " +
            "where ID_Solicita = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i < 52; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            // ID do curso
            ScriptDados = "document.getElementById('input_curso').value = \"" + Convert.ToString(rcrdset[52]) + "\";";
            str.Append(ScriptDados);

            //Foto
            ScriptDados = "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[53]) + "\"/>'; ";
            str.Append(ScriptDados);
            ScriptDados = "document.getElementById('Hidden1').value = \"" + Convert.ToString(rcrdset[53]) + "\";";
            str.Append(ScriptDados);

            // ID da Solicitação de Matricula
            ScriptDados = "document.getElementById('IDHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

            //Lat Lng  Mapa
            ScriptDados = "var latitude = document.getElementById('input_lat').value;";
            str.Append(ScriptDados);
            ScriptDados = "var longitude = document.getElementById('input_lng').value;";
            str.Append(ScriptDados);
            ScriptDados = "var urlMapa = \"MapaAuxiliar.aspx?lat=\" + latitude + \"&lng=\" + longitude;";
            str.Append(ScriptDados);

            ScriptDados = "window.open(urlMapa, 'MapFrame');";
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