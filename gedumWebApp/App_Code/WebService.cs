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
        string param50, string param51, string param52, string param53, string param54, string param55, string param56, string param57, string param58, string param59)
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
            "Latitude," +
            "Longitude," +
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
            "'" + param56 + "'," +
            "'" + param57 + "'," +
            param58 + "," +
            "'" + param59 + "'" +
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
        string param50, string param51, string param52, string param53, string param54, string param55, string param56, string param57, string param58, string param59)
    {

        // param0 a param57 = campos
        // param58 = foto
        // param59 = id func

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
            "Latitude= '" + param14 + "', " +
            "Longitude= '" + param15 + "', " +
            "Numero= '" + param16 + "', " +
            "Bairro= '" + param17 + "', " +
            "CEP= '" + param18 + "', " +
            "UF= '" + param19 + "', " +
            "Cidade= '" + param20 + "', " +
            "Celular1= '" + param21 + "', " +
            "Celular2= '" + param22 + "', " +
            "TelFixo= '" + param23 + "', " +
            "email= '" + param24 + "', " +
            "PIS= '" + param25 + "', " +
            "CPF= '" + param26 + "', " +
            "RG= '" + param27 + "', " +
            "RGEmissor= '" + param28 + "', " +
            "RGEmissao= '" + param29 + "', " +
            "CTPS= '" + param30 + "', " +
            "CTPSserie= '" + param31 + "', " +
            "CTPSEmissao= '" + param32 + "', " +
            "Titulo= '" + param33 + "', " +
            "Zona= '" + param34 + "', " +
            "Secao= '" + param35 + "', " +
            "CNH= '" + param36 + "', " +
            "Passaporte= '" + param37 + "', " +
            "Situacao= '" + param38 + "', " +
            "SituacaoOutros= '" + param39 + "', " +
            "Funcao= '" + param40 + "', " +
            "TabelaSal= '" + param41 + "', " +
            "Sindicalizado= '" + param42 + "', " +
            "SindicatoNome= '" + param43 + "', " +
            "Banco= '" + param44 + "', " +
            "Agencia= '" + param45 + "', " +
            "ContaTipo= '" + param46 + "', " +
            "ContaNumero= '" + param47 + "', " +
            "ContaOperacao= '" + param48 + "', " +
            "Alergias= '" + param49 + "', " +
            "AlergiasMed= '" + param50 + "', " +
            "AcidenteAvisar= '" + param51 + "', " +
            "FardaCamisa= '" + param52 + "', " +
            "FardaCamiseta= '" + param53 + "', " +
            "FardaCalca= '" + param54 + "', " +
            "FardaSapato= '" + param55 + "', " +
            "FardaBota= '" + param56 + "', " +
            "FardaObs= '" + param57 + "', " +
            "FotoDataURI= '" + param58 + "' " +
            "where ID_func = " + param59);

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
    public string FuncionariosNewDep(string param1, string param2, string param3, string param4)
    {
        string url;
        
        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirUser = operacaoInst2.Insert("INSERT INTO Tbl_Funcionarios_Dependentes (ID_func , Nome , Parentesco  , Nascimento ) " +
           "VALUES (" +
           param1 + "," +
           "'" + param2 + "'," +
           "'" + param3 + "'," +
           "'" + param4 + "'" +
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
    public string FuncionariosDelDep(string param1)
    {
        string url;

        OperacaoBanco operacaoDelUSer = new OperacaoBanco();
        Boolean deletarUser = operacaoDelUSer.Delete("delete from Tbl_Funcionarios_Dependentes  where ID_Depend=" + param1);   // <!--*******Customização*******-->
        ConexaoBancoSQL.fecharConexao();

        if (deletarUser == true)
        {
            url = "OK";  // <!--*******Customização*******-->
        }
        else
        {
            url = "NÃO FOI POSSIVEL EXCLUIR DEPENDENTE";
        }

        return url;
    }

    [WebMethod]
    public string FuncionariosNewBenef(string param1, string param2, string param3, string param4)
    {
        string url;

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirUser = operacaoInst2.Insert("INSERT INTO Tbl_Funcionarios_Beneficios (ID_func , Beneficio, Situacao , Inicio ) " +
           "VALUES (" +
           param1 + "," +
           "'" + param2 + "'," +
           "'" + param3 + "'," +
           "'" + param4 + "'" +
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
    public string FuncionariosDelBenef(string param1)
    {
        string url;

        OperacaoBanco operacaoDelUSer = new OperacaoBanco();
        Boolean deletarUser = operacaoDelUSer.Delete("delete from Tbl_Funcionarios_Beneficios where ID_Benef =" + param1);   
        ConexaoBancoSQL.fecharConexao();

        if (deletarUser == true)
        {
            url = "OK"; 
        }
        else
        {
            url = "NÃO FOI POSSIVEL EXCLUIR BENEFICIO";
        }

        return url;
    }

    [WebMethod]
    public string FuncionariosNewCargaH(string param1, string param2, string param3, string param4, string param5, string param6)
    {
        string url;

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirUser = operacaoInst2.Insert("INSERT INTO Tbl_Funcionarios_CargaHor (ID_func , DiaSemana , Turno, Entrada,Saida,Descanso ) " +
           "VALUES (" +
           param1 + "," +
           "'" + param2 + "'," +
           "'" + param3 + "'," +
           "'" + param4 + "'," +
           "'" + param5 + "'," +
           "'" + param6 + "'" +
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
    public string FuncionariosDelCargaH(string param1)
    {
        string url;

        OperacaoBanco operacaoDelUSer = new OperacaoBanco();
        Boolean deletarUser = operacaoDelUSer.Delete("delete from Tbl_Funcionarios_CargaHor where ID_CargaH =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletarUser == true)
        {
            url = "OK";
        }
        else
        {
            url = "NÃO FOI POSSIVEL EXCLUIR CARGA HORÁRIA";
        }

        return url;
    }


    [WebMethod]
    public string DisciplinasSalvar(string param0, string param1)
    {
        string url;
        string strInsert = "INSERT INTO Tbl_Disciplinas (" +
            "Nome," +
            "ID_Inst" +
            ") " +
            "VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'" +
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Disciplinas_Listagem.aspx";
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
