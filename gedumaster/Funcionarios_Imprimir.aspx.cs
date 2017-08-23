using System;
using System.Text;

public partial class Funcionarios_Imprimir : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string URIlogo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string IDaUX = Request.QueryString["p1"];
        DadosFUncionario(IDaUX);   
    }

    private void DadosFUncionario(string IDaUX)
    {

        string ScriptDados, strTexto, idAuxMunic="",NomeMunic;
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);

        string stringSelect = "select Nome,cpf,ID_Munic from Tbl_Funcionarios  where ID_func  = " + IDaUX;
        OperacaoBanco Operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = Operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            strTexto = "document.getElementById('txtNome').innerHTML=' " + Convert.ToString(rcrdset[0]) + " ';";
            str.Append(strTexto);
            strTexto = "document.getElementById('txtNome1a').innerHTML=' " + Convert.ToString(rcrdset[0]) + " ';";
            str.Append(strTexto);

            strTexto = "document.getElementById('txtCPF').innerHTML=' " + Convert.ToString(rcrdset[1]) + " ';";
            str.Append(strTexto);
            strTexto = "document.getElementById('txtCPF1a').innerHTML=' " + Convert.ToString(rcrdset[1]) + " ';";
            str.Append(strTexto);

            idAuxMunic = Convert.ToString(rcrdset[2]);

        }
        ConexaoBancoSQL.fecharConexao();

        string DataAtual = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        strTexto = "document.getElementById('txtData').innerHTML=' " + DataAtual + " ';";
        str.Append(strTexto);
        strTexto = "document.getElementById('txtData1a').innerHTML=' " + DataAtual + " ';";
        str.Append(strTexto);

        NomeMunic = NomeMunicipio(idAuxMunic);

        strTexto = "document.getElementById('txtMunicipio').innerHTML='PREFEITURA MUNICIPAL DE " + NomeMunic + "'; ";
        str.Append(strTexto);
        strTexto = "document.getElementById('txtMunicipio1a').innerHTML='PREFEITURA MUNICIPAL DE " + NomeMunic + "'; ";
        str.Append(strTexto);

        strTexto = "document.getElementById('txtMunicipio2').innerHTML='" + NomeMunic + "';";
        str.Append(strTexto);
        strTexto = "document.getElementById('txtMunicipio21a').innerHTML='" + NomeMunic + "';";
        str.Append(strTexto);

        strTexto = "document.getElementById('logomarca').innerHTML = '<img src=\"" + URIlogo + "\" />';";
        str.Append(strTexto);
        strTexto = "document.getElementById('logomarca1a').innerHTML = '<img src=\"" + URIlogo + "\" />';";
        str.Append(strTexto);

        ScriptDados = "window.print(); ";
        str.Append(ScriptDados);

        ScriptDados = "</script>";
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }

    public string NomeMunicipio(string IDAux)
    {
        string MunicFormatado="", Munic = "";

        string stringSelect = "select Nome,Logomarca from Tbl_Municipios where ID_Munic   = " + IDAux;
        OperacaoBanco Operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = Operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            Munic = Convert.ToString(rcrdset[0]);
            URIlogo = Convert.ToString(rcrdset[1]);
        }
        ConexaoBancoSQL.fecharConexao();

        int lenMunic = Munic.Length;
        if (lenMunic > 24)
        {
            MunicFormatado = Munic.Substring(24, lenMunic - 24);
        }

        return MunicFormatado;
    }


}