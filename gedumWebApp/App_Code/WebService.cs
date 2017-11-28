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

                Identificador_msg = "Login.aspx?p1=" + vValida4 + 
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
    public string DisciplinasSalvar(string param0, string param1, string param2)
    {
        string url;
        string strInsert = "INSERT INTO Tbl_Disciplinas (Nome, obs, ID_Inst) " +
            "VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'," +
            param2 +
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

    [WebMethod]
    public string DisciplinasExcluir(string param1)
    {
        // <!--*******Customização*******-->
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Disciplinas where ID_disc =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Disciplinas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string DisciplinasAlterar(string param0, string param1, string param2)
    {
        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("update Tbl_Disciplinas set " +
            "Nome= '" + param0 + "'," +
            "obs= '" + param1 + "' " +
            "where ID_disc = " + param2);

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



    [WebMethod]
    public string SalasSalvar(string param0, string param1, string param2, string param3, string param4, string param5)
    {
        string url;
        string strInsert = "insert INTO Tbl_Salas (Nome, sala_adm,  dimensao , capacidade_max, obs, ID_Inst ) " +
            "VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'," +
            "'" + param2 + "'," +
            "'" + param3 + "'," +
            "'" + param4 + "'," +
            param5 +
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Salas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string SalasAlterar(string param0, string param1, string param2, string param3, string param4, string param5)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_Salas set " +
            "Nome= '" + param0 + "'," +
            "sala_adm= '" + param1 + "'," +
            "dimensao= '" + param2 + "'," +
            "capacidade_max = '" + param3 + "'," +
            "obs = '" + param4 + "' " +
            "where ID_Sala = " + param5);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Salas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string SalasExcluir(string param1)
    {
        // <!--*******Customização*******-->
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Salas where ID_sala =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Salas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }




    [WebMethod]
    public string CursosSalvar(string param0, string param1, string param2, string param3, string param4, 
        string param5, string param6, string param7, string param8)
    {
        string url;
        string strInsert = "INSERT INTO Tbl_Cursos (" +
            "Nome," +
            "sigla," +
            "equivalencia," +
            "modalidade_educacional," +
            "faixa_ini," +
            "faixa_fim," +
            "curso_anterior, " +
            "obs , " +
            "ID_Inst " +
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
            param8 + 
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Cursos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string CursosAlterar(string param0, string param1, string param2, string param3, 
        string param4, string param5, string param6, string param7, string param8)
    {
        string url;
        OperacaoBanco operacao = new OperacaoBanco();
        bool alterar = operacao.Update("update Tbl_Cursos set " +
            "Nome= '" + param0 + "'," +
            "sigla= '" + param1 + "'," +
            "equivalencia= '" + param2 + "'," +
            "modalidade_educacional= '" + param3 + "'," +
            "faixa_ini = '" + param4 + "'," +
            "faixa_fim = '" + param5 + "'," +
            "curso_anterior= '" + param6 + "', " +
            "obs= '" + param7 + "' " +
            "where ID_curs = " + param8);

        ConexaoBancoSQL.fecharConexao();

        if (alterar == true)
        {
            url = "Cursos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }
    
    [WebMethod]
    public string CursosExcluir(string param1)
    {
        // <!--*******Customização*******-->
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Cursos where ID_curs =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Cursos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }




    [WebMethod]
    public string TurmasSalvar(string param0, string param1, string param2, string param3, string param4, 
        string param5, string param6, string param7, string param8, string param9, string param10)
    {
        string url;
        string strInsert = "INSERT INTO Tbl_Turmas (" +
            "Nome," +
            "turno," +
            "tipo_atendimento," +
            "id_inst," +
            "localizacao_sala," +
            "id_sala," +
            "turma_multiplicada," +
            "id_curso," +
            "obs," +
            "vagas " +
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
            "'" + param10 + "'" +
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Turmas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string TurmasAlterar(string param0, string param1, string param2, string param3, string param4, 
        string param5, string param6, string param7, string param8, string param9, string param10)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("update Tbl_Turmas set " +
            "Nome= '" + param0 + "'," +
            "turno= '" + param1 + "'," +
            "tipo_atendimento= '" + param2 + "'," +
            "id_inst= '" + param3 + "'," +
            "localizacao_sala= '" + param4 + "'," +
            "id_sala= '" + param5 + "'," +
            "turma_multiplicada= '" + param6 + "'," +
            "id_curso= '" + param7 + "'," +
            "obs= '" + param8 + "'," +
            "vagas= '" + param9 + "' " +
            "where ID_turm = " + param10);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Turmas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string TurmasExcluir(string param1)
    {
        // <!--*******Customização*******-->
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Turmas where ID_turm =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Turmas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }



    [WebMethod]
    public string VisitasExcluir(string param1)
    {
        // <!--*******Customização*******-->
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Visitas where ID_Visita =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Visitas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string VisitasSalvar(string param0, string param1, string param2, string param3, string param4,string param5, string param6)
    {
        string url;
        string strInsert = "INSERT INTO Tbl_Visitas  (" +
            "Nome," +
            "DataVisita ," +
            "Horario, " +
            "Funcionario," +
            "Objetivo ," +
            "Observacoes, " +
            "ID_Inst " +
            ") " +
            "VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'," +
            "'" + param2 + "'," +
            "'" + param3 + "'," +
            "'" + param4 + "'," +
            "'" + param5 + "'," +
            param6 + 
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Visitas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string VisitasAlterar(string param0, string param1, string param2, string param3, string param4, string param5, string param6)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("update Tbl_Visitas set " +
            "Nome= '" + param0 + "'," +
            "DataVisita = '" + param1 + "'," +
            "Horario  = '" + param2 + "'," +
            "Funcionario = '" + param3 + "'," +
            "Objetivo = '" + param4 + "'," +
            "Observacoes = '" + param5 + "' " +
            "where ID_Visita = " + param6);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Visitas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }



    [WebMethod]
    public string AlunosSalvar(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9,
        string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19,
        string param20, string param21, string param22, string param23, string param24, string param25, string param26, string param27, string param28, string param29,
        string param30, string param31, string param32, string param33, string param34, string param35, string param36, string param37, string param38, string param39,
        string param40, string param41, string param42, string param43, string param44, string param45, string param46, string param47, string param48, string param49,
        string param50, string param51)
    {
        string url;
        string strInsert = "INSERT INTO tbl_alunos (" +
            "Nome," +
            "Nascimento," +
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
            "'" + param41 + "'," +
            "'" + param43 + "'," +
            "'" + param44 + "'," +
            "'" + param45 + "'," +
            "'" + param46 + "'," +
            "'" + param47 + "'," +
            "'" + param48 + "'," +
            "'" + param49 + "'," +
            param50 + "," +
             "'" + param51 + "'" +
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Alunos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string AlunosExcluir(string param1)
    {
        // <!--*******Customização*******-->
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from tbl_alunos where ID_Aluno =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Alunos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string AlunosAlterar(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9,
        string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19,
        string param20, string param21, string param22, string param23, string param24, string param25, string param26, string param27, string param28, string param29,
        string param30, string param31, string param32, string param33, string param34, string param35, string param36, string param37, string param38, string param39,
        string param40, string param41, string param42, string param43, string param44, string param45, string param46, string param47, string param48, string param49,
        string param50, string param51)
    {
        string url;
        string strInsert = "update tbl_alunos set " +
            "Nome = '" + param0 + "'," +
            "Nascimento= '" + param1 + "'," +
            "EstadoCivil= '" + param2 + "'," +
            "Pai= '" + param3 + "'," +
            "Mae= '" + param4 + "'," +
            "Responsavel= '" + param5 + "'," +
            "ResponsavelCPF= '" + param6 + "'," +
            "ResponsavelTel= '" + param7 + "'," +
            "Naturalidade= '" + param8 + "'," +
            "Nacionalidade= '" + param9 + "'," +
            "Etnia= '" + param10 + "'," +
            "TipoSanguinio= '" + param11 + "'," +
            "Deficiente= '" + param12 + "'," +
            "DeficienteTipo= '" + param13 + "'," +
            "Endereco= '" + param14 + "'," +
            "Latitude= '" + param15 + "'," +
            "Longitude= '" + param16 + "'," +
            "Numero= '" + param17 + "'," +
            "Bairro= '" + param18 + "'," +
            "CEP= '" + param19 + "'," +
            "Cidade= '" + param20 + "'," +
            "UF= '" + param21 + "'," +
            "Celular1= '" + param22 + "'," +
            "Celular2= '" + param23 + "'," +
            "TelFixo= '" + param24 + "'," +
            "email= '" + param25 + "'," +
            "PIS= '" + param26 + "'," +
            "CPF= '" + param27 + "'," +
            "RG= '" + param28 + "'," +
            "RGEmissor= '" + param29 + "'," +
            "RGEmissao= '" + param30 + "'," +
            "CTPS= '" + param31 + "'," +
            "CTPSserie= '" + param32 + "'," +
            "CTPSEmissao= '" + param33 + "'," +
            "Titulo= '" + param34 + "'," +
            "Zona= '" + param35 + "'," +
            "Secao= '" + param36 + "'," +
            "CNH= '" + param37 + "'," +
            "Passaporte= '" + param38 + "'," +
            "CertNasc= '" + param39 + "'," +
            "Alergias= '" + param40 + "'," +
            "AlergiasMed= '" + param41 + "'," +
            "AcidenteAvisar= '" + param42 + "'," +
            "CartaoSUS= '" + param43 + "'," +
            "FardaCamisa= '" + param44 + "'," +
            "FardaCamiseta= '" + param45 + "'," +
            "FardaCalca= '" + param46 + "'," +
            "FardaSapato= '" + param47 + "'," +
            "FardaBota= '" + param48 + "'," +
            "FardaObs= '" + param49 + "'," +
            "FotoDataURI= '" + param50 + "' " +
            "WHERE ID_Aluno = " + param51;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Alunos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }


    [WebMethod]
    public string ProdutosSalvar(string param0, string param1, string param2, string param3, string param4, string param5)
    {
        string url;
        string strInsert = "insert INTO Tbl_Produtos (Descricao, marca, unidade, estoque_min, ID_Inst, tipo ) " +
            "VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'," +
            "'" + param2 + "'," +
            param3 + "," +            
            param4 + "," +
            "'" + param5 + "'" +
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Produtos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }


    [WebMethod]
    public string ProdutosAlterar(string param0, string param1, string param2, string param3, string param4)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_Produtos set " +
            "descricao= '" + param0 + "'," +
            "marca= '" + param1 + "'," +
            "unidade= '" + param2 + "'," +
            "estoque_min = " + param3 + 
            " where ID_Produto = " + param4);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Produtos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }



    [WebMethod]
    public string ProdutosExcluir(string param1)
    {
        // <!--*******Customização*******-->
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Produtos where ID_produto =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Produtos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string FornecedorAlimentosSalvar(string param0, string param1, string param2, string param3, string param4, string param5,
        string param6, string param7, string param8, string param9, string param10, string param11,
        string param12, string param13, string param14, string param15)
    {
        string url;
        string strInsert = "insert INTO Tbl_Fornecedor_Alimento (Descricao, cpf_cnpj, cep, rua, numero, complemento, bairro,"+
                           "cidade, uf, telefone1, telefone2, email, home_page, obs,ID_Inst, tipo ) " +
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
            param14 + "," +
            "'" + param15 + "'" +
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "FornecedorAlimentos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string FornecedorAlimentosAlterar(string param0, string param1, string param2, string param3, string param4, string param5, string param6,
        string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_Fornecedor_Alimento set " +
            "descricao= '" + param0 + "'," +
            "cpf_cnpj= '" + param1 + "'," +
            "cep= '" + param2 + "'," +
            "rua= '" + param3 + "'," +
            "numero= '" + param4 + "'," +
            "complemento= '" + param5 + "'," +
            "bairro= '" + param6 + "'," +
            "cidade= '" + param7 + "'," +
            "uf= '" + param8 + "'," +
            "telefone1= '" + param9 + "'," +
            "telefone2= '" + param10 + "'," +
            "email= '" + param11 + "'," +
            "home_page= '" + param12 + "'," +
            "obs= '" + param13 + "'" +
            " where ID_FornecedorAlimento = " + param14);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "FornecedorAlimentos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string FornecedorAlimentosExcluir(string param1)
    {
        // <!--*******Customização*******-->
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Fornecedor_Alimento where ID_produto =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Produtos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }




    [WebMethod]
    public string Patrimonio_Salvar(string param0, string param1, string param2, string param3, string param4, string param5,
        string param6, string param7, string param8, string param9, string param10, string param11, string param12)
    {
        string url;
        string strInsert = "insert INTO Tbl_Patrimonios (Descricao , Tombo , Tipo_Bem , Situacao , Valor, Incorp_Tipo , Incorp_Data ," +
                           "NF_Numero , NF_Data , Fornecedor , Sala , Deprec_Anual , Observacoes ) " +
            "VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'," +
            "'" + param2 + "'," +
            "'" + param3 + "'," +
            param4 + "," +
            "'" + param5 + "'," +
            "'" + param6 + "'," +
            "'" + param7 + "'," +
            "'" + param8 + "'," +
            "'" + param9 + "'," +
            "'" + param10 + "'," +
            param11 + "," +
            "'" + param12 + "'" +
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Patrimonio_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string Patrimonio_Alterar(string param0, string param1, string param2, string param3, string param4, string param5, string param6,
       string param7, string param8, string param9, string param10, string param11, string param12, string param13)
    {

        string url;
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_Patrimonios set " +
            "descricao= '" + param0 + "'," +
            "Tombo = '" + param1 + "'," +
            "Tipo_Bem= '" + param2 + "'," +
            "Situacao= '" + param3 + "'," +
            "Valor= " + param4 + "," +
            "Incorp_Tipo= '" + param5 + "'," +
            "Incorp_Data= '" + param6 + "'," +
            "NF_Numero= '" + param7 + "'," +
            "NF_Data= '" + param8 + "'," +
            "Fornecedor= '" + param9 + "'," +
            "Sala= '" + param10 + "'," +
            "Deprec_Anual= " + param11 + "," +
            "Observacoes= '" + param12 + "'" +
            " where ID_FornecedorAlimento = " + param13);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Patrimonio_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string Patrimonio_Excluir(string param1)
    {
        string url;
        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Patrimonios where ID_Patrimonio =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Patrimonio_Listagem.aspx";
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


