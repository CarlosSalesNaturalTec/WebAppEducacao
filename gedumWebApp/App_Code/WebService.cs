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
        string stringSelect = "select senha,nome,ID_user from tbl_usuarios where usuario = '" + user + "'";
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

                Identificador_msg = "Login.aspx?p1=" + vValida4 + "&p2=" + Convert.ToString(Identificador_rcrdset[1]) + "&p3=" + Convert.ToString(Identificador_rcrdset[2]);
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
    public string FuncionariosSalvar(string param1, string param2, string param3, string param4, string param5,
    string param6, string param7, string param8, string param9, string param10,
    string param11, string param12, string param13, string param14, string param15,
    string param16, string param17, string param18)
    {
        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("INSERT INTO tbl_Atletas (Nome, Apelido , posicao, Naturalidade , Nascimento, " +
            "nacionalidade, idioma, clube, ContratoInicio, ContratoFinal, " +
            "RegistroCBF, DireitoEcon, Procuracao, altura, peso, " +
            "chute, Caracteristicas , FotoURI )" +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', '" + param5 +
            "' , '" + param6 + "', '" + param7 + "', '" + param8 + "', '" + param9 + "', '" + param10 +
            "' , '" + param11 + "', " + param12 + ", '" + param13 + "', " + param14 + ", " + param15 +
            " , '" + param16 + "', '" + param17 + "', '" + param18 + "')");
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Atletas_Listagem.aspx";
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
    public string FuncionariosAlterar(string param1, string param2, string param3, string param4, string param5,
       string param6, string param7, string param8, string param9, string param10,
       string param11, string param12, string param13, string param14, string param15,
       string param16, string param17, string param18, string param19)
    {
        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("update tbl_Atletas set " +
            "Nome= '" + param1 + "', " +
            "Apelido = '" + param2 + "', " +
            "posicao = '" + param3 + "', " +
            "Naturalidade = '" + param4 + "', " +
            "Nascimento = '" + param5 + "', " +
            "nacionalidade = '" + param6 + "', " +
            "idioma = '" + param7 + "', " +
            "clube = '" + param8 + "', " +
            "ContratoInicio = '" + param9 + "', " +
            "ContratoFinal = '" + param10 + "', " +
            "RegistroCBF = '" + param11 + "', " +
            "DireitoEcon = " + param12 + ", " +
            "Procuracao = '" + param13 + "', " +
            "altura = " + param14 + ", " +
            "peso = " + param15 + ", " +
            "chute= '" + param16 + "', " +
            "Caracteristicas = '" + param17 + "', " +
            "FotoURI = '" + param18 +
            "' where ID_Atleta = " + param19);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Atletas_Listagem.aspx";
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
