using System;
using System.Web.Services;
using System.Data.SqlClient;

[WebService(Namespace = "http://gedumaster.azurewebsites.net/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string TentaLogin(string user, string pwd)
    {
        string Identificador_msg = "0";

        // localiza usuario
        string stringSelect = "select senha,nome,ID_user from tbl_usuarios where usuario = '" + user + "'";
        OperacaoBanco Identificador_Operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader Identificador_rcrdset = Identificador_Operacao.Select(stringSelect);
        while (Identificador_rcrdset.Read())
        {
            if (pwd == Convert.ToString(Identificador_rcrdset[0]))
            {

                string vValida1, vValida2;
                vValida1 = DateTime.Now.ToString("dd");
                vValida2 = DateTime.Now.ToString("MM");
                int vValida3 = Convert.ToInt16(vValida1) * Convert.ToInt16(vValida2);
                string vValida4 = vValida3.ToString();

                Identificador_msg = "LogIn.aspx?p1=" + vValida4 + "&p2=" + Convert.ToString(Identificador_rcrdset[1]) + "&p3=" + Convert.ToString(Identificador_rcrdset[2]);

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
    public string InstituicaoSalvar(string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8)
    {
        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Instituicao  (Nome, Diretor , email, Tel, uf, cidade ) " +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', '" + param5 + "', '" + param6 + "')");
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "CADInstituicoes_Listagem.aspx";   // ATENÇÃO - FALTA SALVAR EM TABELA DE USUARIOS E SENHAS
        }
        else
        {
            url = "CADSorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string InstituicaoExcluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Instituicao where ID_inst =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "CADInstituicoes_Listagem.aspx";
        }
        else
        {
            url = "CADSorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string InstituicaoAlterar(string param1, string param2, string param3, string param4, string param5, string param6, string param7)
    {
        string url;

        OperacaoBanco operacao4 = new OperacaoBanco();
        bool alterar = operacao4.Update(@"update  Tbl_Instituicao set " +
            "Nome = '" + param1 + "', Diretor = '" + param2 + "', email='" + param3 + "', tel = '" + param4 + 
            "', uf = '" + param5 + "', cidade = '" + param6 +
            "' where ID_inst =" + param7);
        ConexaoBancoSQL.fecharConexao();

        if (alterar == true)
        {
            url = "CADInstituicoes_Listagem.aspx";
        }
        else
        {
            url = "CADSorry.aspx";
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
