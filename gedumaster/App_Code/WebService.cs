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

                    Identificador_msg = "LogIn.aspx" +
                        "?p1=" + vValida4 + 
                        "&p2=" + Convert.ToString(Identificador_rcrdset[1]) +
                        "&p3=" + Convert.ToString(Identificador_rcrdset[2]) +
                        "&p4=" + nivel +
                        "&p5=" + Convert.ToString(Identificador_rcrdset[3]) ;
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
    public string InstituicaoSalvar(string param0, string param1, string param2, string param3, string param4, string param5,
        string param6, string param7, string param8, string param9, string param10,
        string param11, string param12, string param13, string param14, string param15,
        string param16, string param17, string param18, string param19, string param20,
        string param21, string param22, string param23, string param24, string param25, 
        string param26, string param27)
    {
        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        // <!--*******Customização*******-->
        bool inserir = operacao.Insert("INSERT INTO Tbl_Instituicao (Nome, Razao, CNPJ, IE, Cat_Adm , MEC_Cadastro, " +
            "Endereco, Numero , Complemento , Bairro , CEP ,Cidade ,UF , Telefone , Celular , Fax , Email," +
            "Diretor , Admissao ," +
            "Salas , AreaJogos ,AreaInfo ,Teatro ,CampoFutebol ,QuadraEsportes ,Biblioteca, Logomarca, ID_Munic ) " +
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
            "'" + param27 + "')");
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "CAD_Instituicao_Listagem.aspx";    // <!--*******Customização*******-->
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
        Boolean deletar = operacao3.Delete("delete from Tbl_Instituicao where ID_inst =" + param1);   // <!--*******Customização*******-->
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "CAD_Instituicao_Listagem.aspx";  // <!--*******Customização*******-->
        }
        else
        {
            url = "CADSorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string InstituicaoAlterar(string param0, string param1, string param2, string param3, string param4, string param5,
        string param6, string param7, string param8, string param9, string param10,
        string param11, string param12, string param13, string param14, string param15,
        string param16, string param17, string param18, string param19, string param20,
        string param21, string param22, string param23, string param24, string param25,
        string param26, string param27)
    {
        string url;

        OperacaoBanco operacao4 = new OperacaoBanco();
        // <!--*******Customização*******-->
        bool alterar = operacao4.Update("update Tbl_Instituicao set " +
            "Nome = '" + param0 + "'," +
            "Razao = '" + param1 + "'," +
            "CNPJ = '" + param2 + "'," +
            "IE = '" + param3 + "'," +
            "Cat_Adm = '" + param4 + "'," +
            "MEC_Cadastro = '" + param5 + "'," +
            "Endereco = '" + param6 + "'," +
            "Numero = '" + param7 + "'," +
            "Complemento = '" + param8 + "'," +
            "Bairro = '" + param9 + "'," +
            "CEP = '" + param10 + "'," +
            "Cidade = '" + param11 + "'," +
            "UF = '" + param12 + "'," +
            "Telefone = '" + param13 + "'," +
            "Celular = '" + param14 + "'," +
            "Fax = '" + param15 + "'," +
            "Email = '" + param16 + "'," +
            "Diretor = '" + param17 + "'," +
            "Admissao = '" + param18 + "'," +
            "Salas = '" + param19 + "'," +
            "AreaJogos = '" + param20 + "'," +
            "AreaInfo = '" + param21 + "'," +
            "Teatro = '" + param22 + "'," +
            "CampoFutebol = '" + param23 + "',"  +
            "QuadraEsportes = '" + param24 + "'," +
            "Biblioteca = '" + param25 + "'," +
            "Logomarca = '" + param26 + "' " +
            "where ID_inst =" + param27);  // <!--*******Customização - ultimo parametro *******-->

        ConexaoBancoSQL.fecharConexao();

        if (alterar == true)
        {
            url = "CAD_Instituicao_Listagem.aspx";   // <!--*******Customização*******-->
        }
        else
        {
            url = "CADSorry.aspx";
        }

        return url;
    }


    [WebMethod]
    public string InstituicaoNewUser(string param1, string param2, string param3, string param4)
    {
        string url;
        string nivel = "3";  // 0 = developer master    1 = Gestor Municipal habilitado a cadastrar instituições    2 = Gestor de Instituição, habilitado a cadastrar funcionarios  3 = Funcionarios,  habilitados a usar o site.

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirUser = operacaoInst2.Insert("INSERT INTO tbl_usuarios (ID_inst , Nome , usuario , senha , nivel, DataCadastro ) " +
           "VALUES (" +
           "'" + param1 + "'," +
           "'" + param2 + "'," +
           "'" + param3 + "'," +
           "'" + param4 + "'," +
           nivel + ", " +
           "dateadd(hh,-3,getdate()) " +
           ")"
           ); 

        ConexaoBancoSQL.fecharConexao();

        if (inserirUser == true)
        {
            url = "OK";  
        }
        else
        {
            url = "NÃO FOI POSSIVEL INCLUIR USUARIO";
        }

        return url;
    }

    [WebMethod]
    public string InstituicaoDELuser(string param1)
    {
        string url;

        OperacaoBanco operacaoDelUSer = new OperacaoBanco();
        Boolean deletarUser = operacaoDelUSer.Delete("delete from tbl_usuarios where ID_user =" + param1);   // <!--*******Customização*******-->
        ConexaoBancoSQL.fecharConexao();

        if (deletarUser == true)
        {
            url = "OK";  // <!--*******Customização*******-->
        }
        else
        {
            url = "NÃO FOI POSSIVEL EXCLUIR USUARIO";
        }

        return url;
    }

    [WebMethod]
    public string MunicipioExcluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Municipios where ID_Munic =" + param1);   // <!--*******Customização*******-->
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "CAD_Municipio_Listagem.aspx";  // <!--*******Customização*******-->
        }
        else
        {
            url = "CADSorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string MunicipioSalvar(string param0, string param1, string param2, string param3, string param4, string param5,
            string param6, string param7, string param8)
    {
        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        // <!--*******Customização*******-->
        bool inserir = operacao.Insert("INSERT INTO Tbl_Municipios (Nome, UF, Gestor, TElefone, email, Endereco, " +
            "Latitude, Longitude, Logomarca ) " +
            "VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'," +
            "'" + param2 + "'," +
            "'" + param3 + "'," +
            "'" + param4 + "'," +
            "'" + param5 + "'," +
            "'" + param6 + "'," +
            "'" + param7 + "'," +
            "'" + param8 + "'" +
            ")");
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "CAD_Municipio_Listagem.aspx";    // <!--*******Customização*******-->
        }
        else
        {
            url = "CADSorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string MunicipioAlterar(string param0, string param1, string param2, string param3, string param4, string param5,
        string param6, string param7, string param8, string param9)
    {
        string url;

        OperacaoBanco operacao4 = new OperacaoBanco();
        // <!--*******Customização*******-->
        bool alterar = operacao4.Update("update Tbl_Municipios set " +
            "Nome = '" + param0 + "'," +
            "uf = '" + param1 + "'," +
            "gestor = '" + param2 + "'," +
            "telefone = '" + param3 + "'," +
            "email = '" + param4 + "'," +
            "Endereco = '" + param5 + "'," +
            "Latitude = '" + param6 + "'," +
            "Longitude = '" + param7 + "'," +
            "Logomarca = '" + param8 + "' " +
            "where ID_Munic =" + param9);  // <!--*******Customização - ultimo parametro *******-->

        ConexaoBancoSQL.fecharConexao();

        if (alterar == true)
        {
            url = "CAD_Municipio_Listagem.aspx";   // <!--*******Customização*******-->
        }
        else
        {
            url = "CADSorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string MunicipioNewUser(string param1, string param2, string param3, string param4)
    {
        string url;
        string nivel = "1";  // 0 = developer master    1 = Gestor Municipal habilitado a cadastrar instituições    2 = Gestor de Instituição, habilitado a cadastrar funcionarios  3 = Funcionarios,  habilitados a usar o site.

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirUser = operacaoInst2.Insert("INSERT INTO tbl_usuarios (ID_Munic, Nome , usuario , senha , nivel, DataCadastro ) " +
           "VALUES (" +
           "'" + param1 + "'," +
           "'" + param2 + "'," +
           "'" + param3 + "'," +
           "'" + param4 + "'," +
           nivel + ", " +
           "dateadd(hh,-3,getdate()) " +
           ")"
           );

        ConexaoBancoSQL.fecharConexao();

        if (inserirUser == true)
        {
            url = "OK";
        }
        else
        {
            url = "NÃO FOI POSSIVEL INCLUIR USUARIO";
        }

        return url;
    }

    [WebMethod]
    public string MunicipioDELuser(string param1)
    {
        string url;

        OperacaoBanco operacaoDelUSer = new OperacaoBanco();
        Boolean deletarUser = operacaoDelUSer.Delete("delete from tbl_usuarios where ID_user =" + param1);   // <!--*******Customização*******-->
        ConexaoBancoSQL.fecharConexao();

        if (deletarUser == true)
        {
            url = "OK";  // <!--*******Customização*******-->
        }
        else
        {
            url = "NÃO FOI POSSIVEL EXCLUIR USUARIO";
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
