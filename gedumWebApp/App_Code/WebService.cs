using System;
using System.Web.Services;
using System.Data.SqlClient;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string Identificador(string user, string pwd)
    {
        string Identificador_msg = "0";

        // localiza usuario
        string stringSelect = "select senha,nome,ID_user,ID_inst  from tbl_usuarios where usuario = '" + user + "'";
        OperacaoBanco Identificador_Operacao = new OperacaoBanco();
        SqlDataReader Identificador_rcrdset = Identificador_Operacao.Select(stringSelect);
        while (Identificador_rcrdset.Read())
        {
            if (pwd == Convert.ToString(Identificador_rcrdset[0]))
            {
                string vValida1, vValida2;
                vValida1 = DateTime.Now.ToString("dd");
                vValida2 = DateTime.Now.ToString("MM");
                int vValida3 = Convert.ToInt16(vValida1) * Convert.ToInt16(vValida2);
                string vValida4 = vValida3.ToString();

                Identificador_msg = "Login.aspx?p1=" + vValida4 + "&p2=" + Convert.ToString(Identificador_rcrdset[1]) +
                    "&p3=" + Convert.ToString(Identificador_rcrdset[2]) + "&p4=" + Convert.ToString(Identificador_rcrdset[3]);
            }
            else
            {
                Identificador_msg = "2";
            }
        }
        ConexaoBancoSQL.fecharConexao();

        return Identificador_msg;

    }

    [WebMethod]
    public string FuncionariosSalvar(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, 
        string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19,
        string param20, string param21, string param22, string param23, string param24, string param25, string param26, string param27, string param28, string param29,
        string param30, string param31, string param32, string param33, string param34, string param35, string param36, string param37, string param38, string param39,
        string param40, string param41, string param42, string param43, string param44, string param45, string param46, string param47, string param48, string param49,
        string param50, string param51, string param52, string param53, string param54, string param55, string param56, string param57)
    {
        string url;
        string strInsert = "INSERT INTO Tbl_Funcionarios (" +
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
            "Situacao," +
            "SituacaoOutros," +
            "Funcao," +
            "TabelaSal," +
            "Sindicalizado," +
            "SindicatoNome," +
            "Banco," +
            "Agencia," +
            "ContaTipo," +
            "ContaNumero," +
            "ContaOperacao," +
            "Alergias," +
            "AlergiasMed," +
            "AcidenteAvisar," +
            "FardaCamisa," +
            "FardaCamiseta," +
            "FardaCalca," +
            "FardaSapato," +
            "FardaBota," +
            "FardaObs," +
            "ID_Inst," +
            "FotoDataURI" +
            ") " +
            "VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'," +
            "'" + param2 + "'," +
            "'" + param3 + "'," +
            "'" + param4 + "'," +
            "'" + param5 + "'," +
            "'" + param6 + "'," +
            "'" + param7 + "'," +
            "'" + param8 + "'," +
            "'" + param9 + "'," +
            "'" + param10 + "'," +
            "'" + param11 + "'," +
            "'" + param12 + "'," +
            "'" + param13 + "'," +
            "'" + param14 + "'," +
            "'" + param15 + "'," +
            "'" + param16 + "'," +
            "'" + param17 + "'," +
            "'" + param18 + "'," +
            "'" + param19 + "'," +
            "'" + param20 + "'," +
            "'" + param21 + "'," +
            "'" + param22 + "'," +
            "'" + param23 + "'," +
            "'" + param24 + "'," +
            "'" + param25 + "'," +
            "'" + param26 + "'," +
            "'" + param27 + "'," +
            "'" + param28 + "'," +
            "'" + param29 + "'," +
            "'" + param30 + "'," +
            "'" + param31 + "'," +
            "'" + param32 + "'," +
            "'" + param33 + "'," +
            "'" + param34 + "'," +
            "'" + param35 + "'," +
            "'" + param36 + "'," +
            "'" + param37 + "'," +
            "'" + param38 + "'," +
            "'" + param39 + "'," +
            "'" + param40 + "'," +
            "'" + param41 + "'," +
            "'" + param42 + "'," +
            "'" + param43 + "'," +
            "'" + param44 + "'," +
            "'" + param45 + "'," +
            "'" + param46 + "'," +
            "'" + param47 + "'," +
            "'" + param48 + "'," +
            "'" + param49 + "'," +
            "'" + param50 + "'," +
            "'" + param51 + "'," +
            "'" + param52 + "'," +
            "'" + param53 + "'," +
            "'" + param54 + "'," +
            "'" + param55 + "'," +
            param56 + "," +
            "'" + param57 + "'" +
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Funcionarios_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string FuncionariosExcluir(string param1)
    {
        // <!--*******Customização*******-->
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Funcionarios where ID_func =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Funcionarios_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string FuncionariosAlterar(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9,
        string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19,
        string param20, string param21, string param22, string param23, string param24, string param25, string param26, string param27, string param28, string param29,
        string param30, string param31, string param32, string param33, string param34, string param35, string param36, string param37, string param38, string param39,
        string param40, string param41, string param42, string param43, string param44, string param45, string param46, string param47, string param48, string param49,
        string param50, string param51, string param52, string param53, string param54, string param55, string param56, string param57)
    {

        // param0 a param55 = campos
        // param56 = foto
        // param57 = id func

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("update Tbl_Funcionarios set " +
            "Nome= '" + param0 + "', " +
            "Profissao= '" + param1 + "', " +
            "Nascimento= '" + param2 + "', " +
            "Pai= '" + param3 + "', " +
            "Mae= '" + param4 + "', " +
            "Naturalidade= '" + param5 + "', " +
            "Nacionalidade= '" + param6 + "', " +
            "Escolaridade= '" + param7 + "', " +
            "EstadoCivil= '" + param8 + "', " +
            "Etnia= '" + param9 + "', " +
            "TipoSanguinio= '" + param10 + "', " +
            "Deficiente= '" + param11 + "', " +
            "DeficienteTipo= '" + param12 + "', " +
            "Endereco= '" + param13 + "', " +
            "Numero= '" + param14 + "', " +
            "Bairro= '" + param15 + "', " +
            "CEP= '" + param16 + "', " +
            "UF= '" + param17 + "', " +
            "Cidade= '" + param18 + "', " +
            "Celular1= '" + param19 + "', " +
            "Celular2= '" + param20 + "', " +
            "TelFixo= '" + param21 + "', " +
            "email= '" + param22 + "', " +
            "PIS= '" + param23 + "', " +
            "CPF= '" + param24 + "', " +
            "RG= '" + param25 + "', " +
            "RGEmissor= '" + param26 + "', " +
            "RGEmissao= '" + param27 + "', " +
            "CTPS= '" + param28 + "', " +
            "CTPSserie= '" + param29 + "', " +
            "CTPSEmissao= '" + param30 + "', " +
            "Titulo= '" + param31 + "', " +
            "Zona= '" + param32 + "', " +
            "Secao= '" + param33 + "', " +
            "CNH= '" + param34 + "', " +
            "Passaporte= '" + param35 + "', " +
            "Situacao= '" + param36 + "', " +
            "SituacaoOutros= '" + param37 + "', " +
            "Funcao= '" + param38 + "', " +
            "TabelaSal= '" + param39 + "', " +
            "Sindicalizado= '" + param40 + "', " +
            "SindicatoNome= '" + param41 + "', " +
            "Banco= '" + param42 + "', " +
            "Agencia= '" + param43 + "', " +
            "ContaTipo= '" + param44 + "', " +
            "ContaNumero= '" + param45 + "', " +
            "ContaOperacao= '" + param46 + "', " +
            "Alergias= '" + param47 + "', " +
            "AlergiasMed= '" + param48 + "', " +
            "AcidenteAvisar= '" + param49 + "', " +
            "FardaCamisa= '" + param50 + "', " +
            "FardaCamiseta= '" + param51 + "', " +
            "FardaCalca= '" + param52 + "', " +
            "FardaSapato= '" + param53 + "', " +
            "FardaBota= '" + param54 + "', " +
            "FardaObs= '" + param55 + "', " +
            "FotoDataURI= '" + param56 + "' " +
            "where ID_func = " + param57);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Funcionarios_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

}

public class ConexaoBancoSQL
{
    private static SqlConnection objConexao = null;
    private string stringconnection1;

    public void tentarAbrirConexaoRemota()
    {
        objConexao = new SqlConnection();
        objConexao.ConnectionString = stringconnection1;
        objConexao.Open();
    }

    public ConexaoBancoSQL()
    {
        // *** STRING DE CONEXÃO COM BANCO DE DADOS - Atenção! Alterar dados conforme seu servidor
        stringconnection1 = "Server=tcp:servereducacao.database.windows.net,1433;Initial Catalog=dbeducacao;Persist Security Info=False;User ID=admserver;Password=Pwd@2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        try
        {
            tentarAbrirConexaoRemota();
        }
        catch
        {
            Console.WriteLine("Atenção! Não foi possível Conectar ao Servidor de Banco de Dados.");
        }
    }

    public static SqlConnection getConexao()
    {
        new ConexaoBancoSQL();
        return objConexao;
    }
    public static void fecharConexao()
    {
        objConexao.Close();
    }
}

public class OperacaoBanco
{
    private SqlCommand TemplateMethod(String query)
    {
        SqlConnection Conexao = ConexaoBancoSQL.getConexao();
        SqlCommand Commando = new SqlCommand(query, Conexao);
        try
        {
            Commando.ExecuteNonQuery();
            return Commando;
        }
        catch
        {
            return Commando;
        }
    }

    public SqlDataReader Select(String query)
    {
        SqlDataReader dadosObtidos = TemplateMethod(query).ExecuteReader();
        return dadosObtidos;
    }

    public Boolean Insert(String query)
    {
        SqlConnection Conexao = ConexaoBancoSQL.getConexao();
        SqlCommand Commando = new SqlCommand(query, Conexao);
        try
        {
            Commando.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Boolean Update(String query)
    {
        SqlConnection Conexao = ConexaoBancoSQL.getConexao();
        SqlCommand Commando = new SqlCommand(query, Conexao);
        try
        {
            Commando.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Boolean Delete(String query)
    {
        SqlConnection Conexao = ConexaoBancoSQL.getConexao();
        SqlCommand Commando = new SqlCommand(query, Conexao);
        try
        {
            Commando.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }

}
