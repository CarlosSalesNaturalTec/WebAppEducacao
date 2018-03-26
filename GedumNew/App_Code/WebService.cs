using System;
using System.Web.Services;
using System.Data.SqlClient;

[WebService(Namespace = "http://gedum.azurewebsites.net/")]
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
    public string TentaLogin(string user, string pwd)
    {
        string Identificador_msg = "0";

        // localiza usuario
        string stringSelect = "select senha,nome,ID_user,ID_Munic, nivel from tbl_usuarios where usuario = '" + user + "'";
        OperacaoBanco Identificador_Operacao = new OperacaoBanco();
        SqlDataReader Identificador_rcrdset = Identificador_Operacao.Select(stringSelect);
        while (Identificador_rcrdset.Read())
        {
            if (pwd == Convert.ToString(Identificador_rcrdset[0]))
            {

                int nivel = Convert.ToInt16(Identificador_rcrdset[4]);

                if (nivel > 1)
                {
                    // nivel 2 em diante não tem acesso a este modulo/master
                    Identificador_msg = "1";
                }
                else
                {

                    string vValida1, vValida2;
                    vValida1 = DateTime.Now.ToString("dd");
                    vValida2 = DateTime.Now.ToString("MM");
                    int vValida3 = Convert.ToInt16(vValida1) * Convert.ToInt16(vValida2);
                    string vValida4 = vValida3.ToString();

                    Identificador_msg = "http://gedumaster.azurewebsites.net/LogIn.aspx" +
                        "?p1=" + vValida4 +
                        "&p2=" + Convert.ToString(Identificador_rcrdset[1]) +
                        "&p3=" + Convert.ToString(Identificador_rcrdset[2]) +
                        "&p4=" + nivel +
                        "&p5=" + Convert.ToString(Identificador_rcrdset[3]);
                }
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
    public string Identificador(string user, string pwd)
    {
        string Identificador_msg = "0";

        // localiza usuario
        string stringSelect = "select senha,nome,ID_user,ID_inst,nivel  from tbl_usuarios where usuario = '" + user + "'";
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

                Identificador_msg = "http://gedumopera.azurewebsites.net/LogIn.aspx" +
                    "?p1=" + vValida4 +
                    "&p2=" + Convert.ToString(Identificador_rcrdset[1]) +
                    "&p3=" + Convert.ToString(Identificador_rcrdset[2]) +
                    "&p4=" + Convert.ToString(Identificador_rcrdset[3]) +
                    "&p5=" + Convert.ToString(Identificador_rcrdset[4]);

                // Nome da Instituição
                stringSelect = "select nome from Tbl_Instituicao where ID_inst = " + Identificador_rcrdset[3];
                OperacaoBanco Operacao = new OperacaoBanco();
                SqlDataReader rcrdset = Operacao.Select(stringSelect);
                string nomeInst = "ID DE INSTITUIÇÃO NAO LOCALIZADO";
                while (rcrdset.Read())
                {
                    nomeInst = Convert.ToString(rcrdset[0]);
                }

                Identificador_msg = Identificador_msg + "&p6=" + nomeInst;

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
    public string AlunosSoliSalvar(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9,
         string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19,
         string param20, string param21, string param22, string param23, string param24, string param25)
    { 
        string url;
        string strInsert = "INSERT INTO tbl_solicitacoes_matricula (" +

            "curso," +
            "instituicao," +
            "Nome," +
            "Nascimento," +
            "EstadoCivil," +
            "Pai," +
            "Mae," +
            "Responsavel," +
            "ResponsavelCPF," +
            "ResponsavelTel," +
            "ResponsavelEmail," +
            "Naturalidade," +
            "Nacionalidade," +
            "Etnia," +
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
            "TelFixo, " +
            "FotoDataURI " +

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
            "'" + param25 + "'" + ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "SolicitacoesObrigado_Novo.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
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
            // <!--*******Customização*******-->
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
