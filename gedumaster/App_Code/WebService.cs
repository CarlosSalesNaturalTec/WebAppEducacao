﻿using System;
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
        string param26, string param27, string param28, string param29, string param30,
        string param31, string param32, string param33, string param34, string param35,
        string param36, string param37, string param38, string param39, string param40,
        string param41, string param42, string param43, string param44, string param45,
        string param46, string param47, string param48, string param49, string param50,
        string param51, string param52, string param53)
    {
        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        // <!--*******Customização*******-->
        bool inserir = operacao.Insert("INSERT INTO Tbl_Instituicao (Nome, Razao, CNPJ, IE, Cat_Adm , MEC_Cadastro, Investimento , " +
            "Endereco, Numero , Complemento , Bairro , CEP ,Cidade ,UF , Telefone , Celular , Fax , Zona, Email," +
            "Diretor , Admissao ," +
            "InepCodigo , UECodigo , Porte , Modalidade , DecretoCriacao , DataCriacao, " +
            "FuncionaMatutino , FuncionaVespertino , FuncionaNoturno,  " +
            "Anexo,Transporte, ColetaLixo, " +
            "Biblioteca,Ginasio,Assentamento, " +
            "TipoCercado , TipoEsgoto , " +
            "EnergiaEletrica,PredioImovel ,UsoPredio ," +
            "QuantPredios, QuantSalasAdm, QuantSalasApoio, " +
            "QuantBanheirosMasc,QuantBanheirosFem , " +
            "Salas , AreaJogos ,AreaInfo ,Teatro ,CampoFutebol ,QuadraEsportes ," +
            "Logomarca, ID_Munic ) " +
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
            "'" + param53 + "')");
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
        string param26, string param27, string param28, string param29, string param30,
        string param31, string param32, string param33, string param34, string param35,
        string param36, string param37, string param38, string param39, string param40,
        string param41, string param42, string param43, string param44, string param45,
        string param46, string param47, string param48, string param49, string param50,
        string param51, string param52, string param53)
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
            "Investimento = '" + param6 + "'," +

            "Endereco = '" + param7 + "'," +
            "Numero = '" + param8 + "'," +
            "Complemento = '" + param9 + "'," +
            "Bairro = '" + param10 + "'," +
            "CEP = '" + param11 + "'," +
            "Cidade = '" + param12 + "'," +
            "UF = '" + param13 + "'," +
            "Telefone = '" + param14 + "'," +
            "Celular = '" + param15 + "'," +
            "Fax = '" + param16 + "'," +
            "Zona = '" + param17 + "'," +
            "Email = '" + param18 + "'," +
            "Diretor = '" + param19 + "'," +
            "Admissao = '" + param20 + "'," +

            "InepCodigo = '" + param21 + "'," +
            "UECodigo = '" + param22 + "'," +
            "Porte = '" + param23 + "'," +
            "Modalidade = '" + param24 + "'," +
            "DecretoCriacao = '" + param25 + "'," +
            "DataCriacao = '" + param26 + "'," +
            "FuncionaMatutino = '" + param27 + "'," +
            "FuncionaVespertino = '" + param28 + "'," +
            "FuncionaNoturno = '" + param29 + "'," +
            "Anexo = '" + param30 + "'," +
            "Transporte = '" + param31 + "'," +
            "ColetaLixo = '" + param32 + "'," +
            "Biblioteca = '" + param33 + "'," +
            "Ginasio = '" + param34 + "'," +
            "Assentamento = '" + param35 + "'," +
            "TipoCercado = '" + param36 + "'," +
            "TipoEsgoto = '" + param37 + "'," +
            "EnergiaEletrica = '" + param38 + "'," +
            "PredioImovel = '" + param39 + "'," +
            "UsoPredio = '" + param40 + "'," +
            "QuantPredios = '" + param41 + "'," +
            "QuantSalasAdm = '" + param42 + "'," +
            "QuantSalasApoio = '" + param43 + "'," +
            "QuantBanheirosMasc = '" + param44 + "'," +
            "QuantBanheirosFem = '" + param45 + "'," +

            "Salas = '" + param46 + "'," +
            "AreaJogos = '" + param47 + "'," +
            "AreaInfo = '" + param48 + "'," +
            "Teatro = '" + param49 + "'," +
            "CampoFutebol = '" + param50 + "',"  +
            "QuadraEsportes = '" + param51 + "'," +
            "Logomarca = '" + param52 + "' " +
            "where ID_inst =" + param53);  // <!--*******Customização - ultimo parametro *******-->

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
