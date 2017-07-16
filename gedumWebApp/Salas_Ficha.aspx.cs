using System;
using System.Text;

public partial class Salas_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string idAux;

    protected void Page_Load(object sender, EventArgs e)
    {
        idAux = Request.QueryString["v1"];
        PreencheCampos(idAux);

        //DependentesLista(idAux);
        //BeneficiosLista(idAux);
        //CargaHLista(idAux);

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
            "Profissao," +
            "Nascimento," +
            "Pai," +
            "Mae," +
            "Naturalidade," +
            "Nacionalidade," +
            "Escolaridade," +
            "EstadoCivil," +
            "Etnia," +
            "TipoSanguinio," +
            "Deficiente," +
            "DeficienteTipo," +
            "Endereco," +
            "Numero," +
            "Bairro," +
            "CEP," +
            "UF," +
            "Cidade," +
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
            "SituacaoOutros," +
            "Funcao," +
            "TabelaSal," +
            "Sindicalizado," +
            "SindicatoNome," +
            "Alergias," +
            "AlergiasMed," +
            "AcidenteAvisar," +
            "FardaCamisa," +
            "FardaCamiseta," +
            "FardaCalca," +
            "FardaSapato," +
            "FardaBota," +
            "FardaObs," +
            "FotoDataURI," +
            // "TEXT NULL,
            "Latitude," +
            "Longitude," +
            "ResponsavelLegal," +
            "Serie," +
            "Nivel," +
            "UsaTransp " +
            "from Tbl_Alunos " +
            "where ID_alun  = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i <= 57; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            ScriptDados = "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[58]) + "\"/>'; ";
            str.Append(ScriptDados);
            ScriptDados = "document.getElementById('Hidden1').value = \"" + Convert.ToString(rcrdset[58]) + "\";";
            str.Append(ScriptDados);
            ScriptDados = "document.getElementById('IDHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

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


}