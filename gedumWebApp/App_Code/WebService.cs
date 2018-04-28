using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
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
    public string AvaliacaoSalvar(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7)
    {
        string url;
        string insert = "INSERT INTO tbl_avaliacao (id_inst, ID_Disc, id_turma, id_periodo, tipo, dataAva, notaMax, Ano_Letivo) " +
                        "VALUES (" +
                        "'" + param0 + "'," +
                        "'" + param1 + "'," +
                        "'" + param2 + "'," +
                        "'" + param3 + "'," +
                        "'" + param4 + "'," +
                        "'" + param5 + "'," +
                        "'" + param6 + "'," +
                        "'" + param7 + "'" +
                        ")";

        OperacaoBanco op = new OperacaoBanco();
        bool inserir = op.Insert(insert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Avaliacao_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string AvaliacaoAlterar(string param0, string param1, string param2, string param3, string param4, string param5, string param6)
    {
        string url;

        OperacaoBanco operacao = new OperacaoBanco();

        bool update = operacao.Update("update tbl_avaliacao set " +
            "id_Disc = '" + param1 + "'," +
            "id_turma = '" + param2 + "'," +
            "id_periodo = '" + param3 + "'," +
            "tipo = '" + param4 + "'," +
            "dataAva = '" + param5 + "'," +
            "notamax = '" + param6 + "' " +
            "where id_avaliacao  = " + param0);

        ConexaoBancoSQL.fecharConexao();

        if (update == true)
        {
            url = "Avaliacao_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }
        
        return url;
        
    }

    [WebMethod]
    public string AvaExcluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from tbl_avaliacao where id_avaliacao =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Avaliacao_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string IncluiAl(string param0, string param1, string param2)
    {
        string url;

        OperacaoBanco oper = new OperacaoBanco();

        string insert = "INSERT INTO tbl_aluno_avaliacao (id_avaliacao, id_aluno, nota) " +
                        "VALUES (" +
                        "'" + param0 + "'," +
                        "'" + param1 + "'," +
                        "'" + param2 + "')";

        OperacaoBanco op = new OperacaoBanco();
        bool inserir = op.Insert(insert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "OK";
        }
        else
        {
            url = "Não foi possivel";
        }

        return url;

    }

    [WebMethod]
    public string ExcluirAl(string param1)
    {
        string url;

        OperacaoBanco operacaoDelUSer = new OperacaoBanco();
        Boolean deletarUser = operacaoDelUSer.Delete("delete from tbl_aluno_avaliacao where id_aa =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletarUser == true)
        {
            url = "OK";
        }
        else
        {
            url = "NÃO FOI POSSIVEL EXCLUIR USUARIO";
        }

        return url;
    }




    [WebMethod]
    public string PeriodoSalvar(string param0, string param1)
    {
        string url;
        string insert = "INSERT INTO tbl_periodo_avaliacao (Descricao , id_inst) " +
                        "VALUES (" +
                        "'" + param0 + "'," +
                        "'" + param1 + "'" + ")";

        OperacaoBanco op = new OperacaoBanco();
        bool inserir = op.Insert(insert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "PeriodoAvaliacao_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";

        }

        return url;
    }

    [WebMethod]
    public string PeriodoExclui(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from tbl_periodo_avaliacao where id_periodo =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "PeriodoAvaliacao_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string PeriodoAlterar(string param0, string param1)
    {
        string url;

        OperacaoBanco operacao = new OperacaoBanco();

        bool update = operacao.Update("update tbl_periodo_avaliacao set " +
            "Descricao = '" + param0 + "' " +
            "where id_periodo = " + param1 );

        ConexaoBancoSQL.fecharConexao();

        if (update == true)
        {
            url = "PeriodoAvaliacao_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }


        return url;


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

        bool inserir = operacao.Update("update Tbl_Disciplinas set " +

            "nome= '" + param0 + "'," +
            "obs= '" + param1 + "' " +
            "where ID_Disc = " + param2);

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
            "Nome = '" + param0 + "'," +
            "sigla = '" + param1 + "'," +
            "equivalencia = '" + param2 + "'," +
            "modalidade_educacional= '" + param3 + "'," +
            "faixa_ini = '" + param4 + "'," +
            "faixa_fim = '" + param5 + "'," +
            "curso_anterior= '" + param6 + "', " +
            "obs= '" + param7 + "' " +
            "where ID_Curs = " + param8);

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
        string param5, string param6, string param7, string param8)
    {
        string url;
        string strInsert = "INSERT INTO Tbl_Turmas (" +
            "Nome," +
            "turno," +
            "Tipo_atend," +
            "Multiplicada ," +
            "ID_curso," +
            "curso," +
            "ID_Sala," +
            "Sala," +
            "ID_Inst" +
            ") VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'," +
            "'" + param2 + "'," +
            "'" + param3 + "'," +
            "'" + param4 + "'," +
            "'" + param5 + "'," +
            "'" + param6 + "'," +
            "'" + param7 + "'," +
            "'" + param8 + "'" +
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
        string param5, string param6, string param7, string param8)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("update Tbl_Turmas set " +
            "Nome= '" + param0 + "'," +
            "turno= '" + param1 + "'," +
            "Tipo_atend = '" + param2 + "'," +
            "Multiplicada = '" + param3 + "'," +
            "ID_curso = '" + param4 + "'," +
            "CURSO = '" + param5 + "'," +
            "ID_Sala = '" + param6 + "'," +
            "Sala = '" + param7 + "'" +
            " where ID_turma = " + param8);

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
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Turmas where ID_turma =" + param1);
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
    public string VisitasSalvar(string param0, string param1, string param2, string param3, string param4, string param5, string param6)
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
        string param50, string param51, string param52, string param53, string param54)
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
            "ID_Curso," +
            "ID_Turma," +
            "matricula," +
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
            "'" + param54 + "'" +
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
        string param50, string param51, string param52, string param53, string param54)
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
            "ID_Curso= '" + param14 + "'," +
            "ID_Turma= '" + param15 + "'," +
            "matricula = '" + param16 + "'," +
            "Endereco= '" + param17 + "'," +
            "Latitude= '" + param18 + "'," +
            "Longitude= '" + param19 + "'," +
            "Numero= '" + param20 + "'," +
            "Bairro= '" + param21 + "'," +
            "CEP= '" + param22 + "'," +
            "Cidade= '" + param23 + "'," +
            "UF= '" + param24 + "'," +
            "Celular1= '" + param25 + "'," +
            "Celular2= '" + param26 + "'," +
            "TelFixo= '" + param27 + "'," +
            "email= '" + param28 + "'," +
            "PIS= '" + param29 + "'," +
            "CPF= '" + param30 + "'," +
            "RG= '" + param31 + "'," +
            "RGEmissor= '" + param32 + "'," +
            "RGEmissao= '" + param33 + "'," +
            "CTPS= '" + param34 + "'," +
            "CTPSserie= '" + param35 + "'," +
            "CTPSEmissao= '" + param36 + "'," +
            "Titulo= '" + param37 + "'," +
            "Zona= '" + param38 + "'," +
            "Secao= '" + param39 + "'," +
            "CNH= '" + param40 + "'," +
            "Passaporte= '" + param41 + "'," +
            "CertNasc= '" + param42 + "'," +
            "Alergias= '" + param43 + "'," +
            "AlergiasMed= '" + param44 + "'," +
            "AcidenteAvisar= '" + param45 + "'," +
            "CartaoSUS= '" + param46 + "'," +
            "FardaCamisa= '" + param47 + "'," +
            "FardaCamiseta= '" + param48 + "'," +
            "FardaCalca= '" + param49 + "'," +
            "FardaSapato= '" + param50 + "'," +
            "FardaBota= '" + param51 + "'," +
            "FardaObs= '" + param52 + "'," +
            "FotoDataURI= '" + param53 + "' " +
            "WHERE ID_Aluno = " + param54;

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
    public string ProdutosSalvar(string param0, string param1, string param2, string param3, string param4)
    {
        string url;
        string strInsert = "insert INTO Tbl_Produtos (Descricao, tipo, unidade, Estoque_min, ID_Inst  ) " +
            "VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'," +
            "'" + param2 + "'," +
            "'" + param3 + "'," +
            "'" + param4 + "'" +
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
            "tipo= '" + param1 + "'," +
            "unidade= '" + param2 + "'," +
            "estoque_min= '" + param3 + "'" +
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
        string strInsert = "insert INTO Tbl_Fornecedor_Alimentos (Descricao, cpf_cnpj, cep, rua, numero, complemento, bairro," +
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
        bool inserir = operacao.Update("update Tbl_Fornecedor_Alimentos set " +
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

        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Fornecedor_Alimentos where ID_fornecedoralimento =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
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
    public string Patrimonio_Salvar(string param0, string param1, string param2, string param3, string param4, string param5,
        string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13)
    {
        string url;
        string strInsert = "insert INTO Tbl_Patrimonios (Descricao , Tombo , Tipo_Bem , Situacao , Valor, Incorp_Tipo , Incorp_Data ," +
                           "NF_Numero , NF_Data , Fornecedor , Sala , Deprec_Anual , Observacoes, ID_Inst ) " +
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
            "'" + param12 + "'," +
            param13 +
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
        bool alterar = operacao.Update("update Tbl_Patrimonios set " +
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
            " where ID_patrimonio = " + param13);
        ConexaoBancoSQL.fecharConexao();

        if (alterar == true)
        {
            url = "Patrimonio_Listagem.aspx";
        }
        else
        {
            url = "XXXX.aspx";
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



    [WebMethod]
    public string VeiculosSalvar(string param0, string param1, string param2, string param3, string param4, string param5,
           string param6, string param7)
    {
        string url;
        string strInsert = "insert INTO Tbl_Veiculos (modelo, placa, cor, km_inicial, combustivel," +
            "proprietario, obs, ID_Inst, id_modelo ) " +
            "VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'," +
            "'" + param2 + "'," +
            "'" + param3 + "'," +
            "'" + param4 + "'," +
            "'" + param5 + "'," +
            "'" + param6 + "'," +
            "'" + param7 + "'," +
            "'" + 0 + "'" +
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Veiculos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string VeiculosAlterar(string param0, string param1, string param2, string param3,
        string param4, string param5, string param6, string param7)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_Veiculos set " +
            "modelo= '" + param0 + "'," +
            "placa= '" + param1 + "'," +
            "cor = '" + param2 + "'," +
            "km_inicial = '" + param3 + "'," +
            "combustivel = '" + param4 + "'," +
            "proprietario = '" + param5 + "'," +
            "obs = '" + param6 + "' " +
            "where ID_Veiculo = " + param7);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Veiculos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string VeiculosExcluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Veiculos where ID_veiculo =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Veiculos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }




    [WebMethod]
    public string ViagensSalvar(string param0, string param1, string param2, string param3, string param4, string param5,
           string param6, string param7, string param8, string param9, string param10)
    {
        string url;
        string strInsert = "insert INTO Tbl_Viagens (data_viagem, motorista, hora_saida, " +
            "km_inicial, hora_chegada, km_final, " +
            "destino_viagem, motivo_viagem, id_veiculo, veiculo, id_inst, id_motorista " +
            ") VALUES (" +
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
            "'" + 0 + "'" +
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Viagens_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }


    [WebMethod]
    public string ViagensAlterar(string param0, string param1, string param2, string param3, string param4, string param5,
        string param6, string param7, string param8, string param9, string param10)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_Viagens set " +
            "data_viagem= '" + param0 + "'," +
            "motorista= '" + param1 + "'," +
            "hora_saida = '" + param2 + "'," +
            "km_inicial = '" + param3 + "'," +
            "hora_chegada = '" + param4 + "'," +
            "km_final = '" + param5 + "'," +
            "destino_viagem = '" + param6 + "'," +
            "motivo_viagem = '" + param7 + "'," +
            "id_veiculo = '" + param8 + "'," +
            "veiculo = '" + param9 + "'" +
            "where ID_Viagem = " + param10);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Viagens_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }


    [WebMethod]
    public string ViagensExcluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Viagens where ID_viagem =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Viagens_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }



    [WebMethod]
    public string EmprestimosSalvar(string param1, string param2, string param3, string param4, string param5,
        string param6, string param7, string param8)
    {
        string url;
        string strInsert = "insert INTO tbl_Controle_Entregas (ID_aluno, aluno, id_livro, livro, ID_funcionario, funcionario, " +
            "dataOperacao, ID_inst ) " +
            "VALUES (" +
            "'" + param1 + "'," +
            "'" + param2 + "'," +
            "'" + param3 + "'," +
            "'" + param4 + "'," +
            "'" + param5 + "'," +
            "'" + param6 + "'," +
            "'" + param7 + "'," +
            "'" + param8 + "'" +
            ")";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Emprestimos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }


    [WebMethod]
    public string EmprestimosAlterar(string param1, string param2, string param3, string param4,
        string param5, string param6, string param7, string param8, string param9)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_Controle_Entregas set " +
            "Id_aluno= '" + param1 + "'," +
            "Aluno= '" + param2 + "'," +
            "ID_livro = '" + param3 + "'," +
            "livro = '" + param4 + "'," +
            "ID_funcionario = '" + param5 + "'," +
            "funcionario = '" + param6 + "'," +
            "dataOperacao = '" + param7 + "'," +
            "DataDevolucao = '" + param8 + "' " +
            "where ID_Controle_Entrega = " + param9);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Emprestimos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }


    [WebMethod]
    public string EmprestimosExcluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Controle_Entregas where ID_controle_entrega =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Emprestimos_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }





    [WebMethod]
    public string LivrosSalvar(string param0, string param1, string param2, string param3, string param4, string param5,
           string param6)
    {
        string url;
        string strInsert = "insert INTO Tbl_Livros (nome, editora, materia, doado_por, quantidade, obs, ID_Inst ) " +
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
            url = "Livros_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string LivrosAlterar(string param0, string param1, string param2, string param3,
        string param4, string param5, string param6)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_Livros set " +
            "nome= '" + param0 + "'," +
            "editora= '" + param1 + "'," +
            "materia= '" + param2 + "'," +
            "doado_por = '" + param3 + "'," +
            "quantidade = '" + param4 + "'," +
            "obs = '" + param5 + "' " +
            "where ID_Livro = " + param6);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Livros_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string LivrosExcluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Livros where ID_livro =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Livros_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }




    [WebMethod]
    public string ReceitasSalvar(string param0, string param1, string param2)
    {
        string url;
        string strInsert = "insert INTO Tbl_Receitas (Nome, modo_preparo, ID_Inst ) " +
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
            url = "Receitas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string ReceitasAlterar(string param0, string param1, string param2)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_receitas set " +
            "Nome= '" + param0 + "'," +
            "modo_preparo = '" + param1 + "' " +
            "where ID_Receita = " + param2);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Receitas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string ReceitasExcluir(string param1)
    {

        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Receitas where ID_receita =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Receitas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string ReceitasItensSalvar(string param1, string param2, string param3, string param4)
    {
        string url;
        int IdProduto = 0;

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirItens = operacaoInst2.Insert("INSERT INTO tbl_receitas_itens (ID_receita , id_produto, quantidade, unidade ) " +
           "VALUES (" +
           param1 + "," +
           IdProduto + "," +
           //"'" + param2 + "'," +
           "'" + param3 + "'," +
           "'" + param4 + "'" +
           ")"
           );

        ConexaoBancoSQL.fecharConexao();

        if (inserirItens == true)
        {
            url = "OK";
        }
        else
        {
            url = "NÃO FOI POSSIVEL INCLUIR INGREDIENTE";
        }

        return url;
    }

    [WebMethod]
    public string ReceitasItensExcluir(string param1)
    {
        string url;

        OperacaoBanco operacaoDeltens = new OperacaoBanco();
        Boolean deletarReceitasItens = operacaoDeltens.Delete("delete from tbl_receitas_itens where ID_receita_itens =" + param1);   // <!--*******Customização*******-->
        ConexaoBancoSQL.fecharConexao();

        if (deletarReceitasItens == true)
        {
            url = "OK";
        }
        else
        {
            url = "NÃO FOI POSSIVEL EXCLUIR ITEM";
        }

        return url;
    }




    [WebMethod]
    public string Estoque_Entrada(string param1, string param2, string param3, string param4, string param5, string param6)
    {
        string url;

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirItens = operacaoInst2.Insert("INSERT INTO Tbl_Produtos_Movimento " +
            "(ID_Produto , ID_Fornecedor, Forn_Resp, DataOperacao , Documento, Quant_Entrada ) " +
           "VALUES (" +
           "'" + param1 + "'," +
           "'" + param2 + "'," +
           "'" + param3 + "'," +
           "'" + param4 + "'," +
           "'" + param5 + "'," +
           "'" + param6 + "'" +
           ")"
           );

        ConexaoBancoSQL.fecharConexao();

        if (inserirItens == true)
        {
            url = "Jesus is the Lord";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string Estoque_Saida(string param1, string param2, string param3, string param4, string param5)
    {
        string url;

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirItens = operacaoInst2.Insert("INSERT INTO Tbl_Produtos_Movimento " +
            "(ID_Produto , Forn_Resp, DataOperacao , Documento, Quant_Saida ) " +
           "VALUES (" +
           "'" + param1 + "'," +
           "'" + param2 + "'," +
           "'" + param3 + "'," +
           "'" + param4 + "'," +
           "'" + param5 + "'" +
           ")"
           );

        ConexaoBancoSQL.fecharConexao();

        if (inserirItens == true)
        {
            url = "Jesus is the Lord";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string Estoque_Excluir(string param1)
    {
        string url;

        OperacaoBanco operacaoDeltens = new OperacaoBanco();
        Boolean deletarReceitasItens = operacaoDeltens.Delete("delete from Tbl_Produtos_Movimento where ID_Operacao =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletarReceitasItens == true)
        {
            url = "Jesus is the Lord";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }



    [WebMethod]
    public string Inseri_Boletim(string param1, string param2, string param3, string param4, string param5, string param6, string param7)
    {
        string url;

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirItens = operacaoInst2.Insert("INSERT INTO Tbl_Boletins " +
            "(ID_Aluno, ID_Disciplina, Unidade, tipo_avaliacao, data_avaliacao, ano_letivo, nota ) " +
           "VALUES (" +
           param1 + "," +
           param2 + "," +
           "'" + param3 + "'," +
           "'" + param4 + "'," +
           "'" + param5 + "'," +
           param6 + "," +
           param7 +
           ")"
           );

        ConexaoBancoSQL.fecharConexao();

        if (inserirItens == true)
        {
            url = "OK";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }



    [WebMethod]
    public string OcorrenciasSalvar(string param1, string param2, string param3, string param4, string param5, string param6)
    {
        string url;
        string strInsert = "insert INTO tbl_Ocorrencias (ID_func, ID_aluno, data_ocorrencia, tipo_ocorrencia, descricao_ocorrencia, ID_inst ) " +
            "VALUES (" +
            param1 + "," +
            param2 + "," +
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
            url = "Ocorrencias_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string OcorrenciasAlterar(string param1, string param2, string param3, string param4,
        string param5, string param6)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_Ocorrencias set " +
            "Id_func= " + param1 + "," +
            "Id_aluno= " + param2 + "," +
            "data_ocorrencia= '" + param3 + "'," +
            "tipo_ocorrencia = '" + param4 + "'," +
            "descricao_ocorrencia = '" + param5 + "' " +
            "where ID_Ocorrencia = " + param6);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Ocorrencias_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string OcorrenciasExcluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Ocorrencias where ID_ocorrencia =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Ocorrencias_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }




    [WebMethod]
    public string AtestadosSalvar(string param1, string param2, string param3, string param4, string param5)
    {
        string url;
        string strInsert = "insert INTO tbl_Atestados (ID_aluno, data_atestado, tipo_atestado, observacoes, id_inst ) " +
            "VALUES (" +
            param1 + "," +
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
            url = "Atestados_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string AtestadosAlterar(string param1, string param2, string param3, string param4, string param5)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_Atestados set " +
            "Id_aluno= " + param1 + "," +
            "data_atestado= '" + param2 + "'," +
            "tipo_atestado= '" + param3 + "'," +
            "observacoes= '" + param4 + "'" +
            "where ID_Atestado = " + param5);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Atestados_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string AtestadosExcluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Atestados where ID_atestado =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Atestados_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }




    [WebMethod]
    public string ParametroAlterar(string param1, string param2, string param3, string param4, string param5)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Update("update Tbl_Parametros set " +
            "ano_letivo = " + param1 + "," +
            "matricula = " + param2 + "," +
            "permite_pre_mat = '" + param3 + "', " +
            "id_periodo = '" + param4 + "' " +
            "where ID_inst = " + param5
            );

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "home.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }





    [WebMethod]
    public string ExcluirDisc(string param1)
    {
        string url;

        OperacaoBanco operacaoDelUSer = new OperacaoBanco();
        Boolean deletarUser = operacaoDelUSer.Delete("delete from tbl_cursos_disciplina where id_cd =" + param1);
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
    public string ExcluirProf(string param1)
    {
        string url;

        OperacaoBanco operacaoDelUSer = new OperacaoBanco();
        Boolean deletarUser = operacaoDelUSer.Delete("delete from tbl_disciplina_professor where id_dp =" + param1);
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
    public string AlunoEntrarTurma(string param1, string param2)
    {
        string url;

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        bool alterarTurma = operacaoInst2.Update("update tbl_alunos set " +
           "ID_Turma = '" + param1 + "' " +
           "where ID_aluno= '" + param2 + "'");

        ConexaoBancoSQL.fecharConexao();

        if (alterarTurma == true)
        {
            url = "OK";
        }
        else
        {
            url = "NÃO FOI POSSIVEL INCLUIR O ALUNO";
        }

        return url;
    }

    [WebMethod]
    public string AlunoSairdaTurma(string param1)
    {
        string url;

        OperacaoBanco operacaoDelUSer = new OperacaoBanco();
        bool AlunoTurmaSair = operacaoDelUSer.Update("Update tbl_alunos set ID_Turma = 0 where ID_Aluno =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (AlunoTurmaSair == true)
        {
            url = "OK";
        }
        else
        {
            url = "NÃO FOI POSSIVEL EXCLUIR O ALUNO";
        }

        return url;
    }

    [WebMethod]
    public string IncluiDisc(string param1, string param2)
    {
        string url;

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirUser = operacaoInst2.Insert("INSERT INTO tbl_cursos_disciplina (id_curso, id_dsciplina ) " +
           "VALUES (" +
           "'" + param1 + "'," +
           "'" + param2 + "')"
           );

        ConexaoBancoSQL.fecharConexao();

        if (inserirUser == true)
        {
            url = "OK";
        }
        else
        {
            url = "NÃO FOI POSSIVEL INCLUIR A DISCIPLINA";
        }

        return url;
    }

    [WebMethod]
    public string IncluiProf(string param1, string param2)
    {
        string url;

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirUser = operacaoInst2.Insert("INSERT INTO tbl_disciplina_professor (id_disc, id_func ) " +
           "VALUES (" +
           "'" + param1 + "'," +
           "'" + param2 + "')"
           );

        ConexaoBancoSQL.fecharConexao();

        if (inserirUser == true)
        {
            url = "OK";
        }
        else
        {
            url = "NÃO FOI POSSIVEL INCLUIR A DISCIPLINA";
        }

        return url;
    }

    [WebMethod]
    public string Matriculas_Parametros(string param1)
    {
        string mat_aux = "";
        string retorno;


        //verifica numero de matricula disponível
        string stringSelect = "select matricula from Tbl_Parametros where id_inst = " + param1;
        OperacaoBanco operacao = new OperacaoBanco();
        SqlDataReader dados = operacao.Select(stringSelect);
        while (dados.Read())
        {
            mat_aux = Convert.ToString(dados[0]);
        }
        ConexaoBancoSQL.fecharConexao();

        //atualiza numero de matricula em tabela de parametros
        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean alterar = operacao3.Update("update tbl_parametros set matricula = matricula + 1 where ID_Inst=" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (alterar == true)
        {
            retorno = mat_aux;
        }
        else
        {
            retorno = "Não foi possível atualizar o Parâmetro : Número sequencial de Matrícula";
        }

        return retorno;
    }




    [WebMethod]
    public string SolicitacoesMatriculas_Excluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from tbl_solicitacoes_matricula  where ID_Solicita =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "SolicitacoesMatriculas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string SolicitacoesMatriculas_Alterar(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9,
        string param10, string param11, string param12, string param13, string param14, string param15, string param16, string param17, string param18, string param19,
        string param20, string param21, string param22, string param23, string param24)
    {

        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool alterar = operacao.Update("update tbl_solicitacoes_matricula set " +
            "ID_Curso= " + param0 + "," +
            "Nome= '" + param1 + "'," +
            "Nascimento= '" + param2 + "'," +
            "EstadoCivil= '" + param3 + "'," +
            "Pai= '" + param4 + "'," +
            "Mae= '" + param5 + "'," +
            "Responsavel= '" + param6 + "'," +
            "ResponsavelCPF= '" + param7 + "'," +
            "ResponsavelTel= '" + param8 + "'," +
            "ResponsavelEmail= '" + param9 + "'," +
            "Naturalidade= '" + param10 + "'," +
            "Nacionalidade= '" + param11 + "'," +
            "Etnia= '" + param12 + "'," +
            "Deficiente= '" + param13 + "'," +
            "DeficienteTipo= '" + param14 + "'," +
            "Endereco= '" + param15 + "'," +
            "Latitude= '" + param16 + "'," +
            "Longitude= '" + param17 + "'," +
            "Numero= '" + param18 + "'," +
            "Bairro= '" + param19 + "'," +
            "CEP= '" + param20 + "'," +
            "Cidade= '" + param21 + "'," +
            "UF= '" + param22 + "'," +
            "TelFixo= '" + param23 + "' " +
            "where ID_Solicita = " + param24);

        ConexaoBancoSQL.fecharConexao();

        if (alterar == true)
        {
            url = "SolicitacoesMatriculas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;

    }

    [WebMethod]
    public string SolicitacoesMatriculas_Confirmar(string param1, string param2)
    {
        //param1 =ID da solictação de matricula
        //param2 = ID da INstrituição

        string url;

        //obtem numero de matricula (parametros)
        string strSelect = "select matricula from tbl_parametros where ID_inst = '" + param2 + "'";
        string matAux = "0";
        OperacaoBanco operacaoSelect = new OperacaoBanco();
        SqlDataReader rcrdset = operacaoSelect.Select(strSelect);
        while (rcrdset.Read())
        {
            matAux = Convert.ToString(rcrdset[0]);
        }
        ConexaoBancoSQL.fecharConexao();
        int MatNova = Convert.ToInt32(matAux) + 1;

        //insere em tabela de alunos
        string strInsert = "INSERT INTO tbl_alunos (" +
            "Nome, Nascimento, EstadoCivil, Pai, Mae, Responsavel, ResponsavelCPF, ResponsavelTel, ResponsavelEmail," +
            "Naturalidade, Nacionalidade, Etnia, Deficiente, DeficienteTipo, Endereco, Latitude, Longitude, " +
            "Numero, Bairro, CEP, Cidade, uf, TelFixo, ID_Inst, ID_Curso, matricula  " +
            ") SELECT " +
            "Nome, Nascimento, EstadoCivil, Pai, Mae, Responsavel, ResponsavelCPF, ResponsavelTel, ResponsavelEmail," +
            "Naturalidade, Nacionalidade, Etnia, Deficiente, DeficienteTipo, Endereco, Latitude, Longitude, " +
            "Numero, Bairro, CEP, Cidade, uf, TelFixo, ID_Inst, ID_Curso, '" + MatNova + "' " +
            "FROM tbl_solicitacoes_matricula  " +
            "WHERE ID_Solicita = " + param1;
        OperacaoBanco operacao3 = new OperacaoBanco();
        bool inserir = operacao3.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            // apaga em tabela de solicitações de matriculas
            OperacaoBanco operacao4 = new OperacaoBanco();
            Boolean deletar = operacao3.Delete("delete from tbl_solicitacoes_matricula where ID_Solicita =" + param1);
            ConexaoBancoSQL.fecharConexao();

            if (deletar == true)
            {
                //altera parâmetro - numero de matricula sequnecial
                OperacaoBanco operacao5 = new OperacaoBanco();
                Boolean alterarMat = operacao5.Update("update tbl_parametros set matricula = '" + MatNova + "' " +
                    "where ID_inst =" + param2);
                ConexaoBancoSQL.fecharConexao();

                url = "SolicitacoesMatriculas_Listagem.aspx";
            }
            else
            {
                url = "Sorry.aspx";
            }

            return url;
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }




    [WebMethod]
    public string Frequencia_Aula_Lancar(string param1, string param2, string param3, string param4, string param5, string param6)
    {
        //param1 = ID da Turma
        //param2 = ID da Disciplina
        //param3 = data da aula
        //param4 = observações
        //param5 = Período
        //param6 = ID da Instituição

        bool AulaExiste = false;
        string retorno = "", Ano="0";

        //verifica se já foi gerada Aula em tabela de frequencias_aulas
        string strSelect = "select ID_Aula from Tbl_Alunos_Frequencia_Aulas " +
            "where ID_Turma = '" + param1 + "' " +
            "and ID_Disc = '" + param2 + "' " +
            "and Data_Aula = '" + param3 + "' ";
        OperacaoBanco operacaoSelect = new OperacaoBanco();
        SqlDataReader rcrdset = operacaoSelect.Select(strSelect);
        while (rcrdset.Read())
        {
            AulaExiste = true;
        }
        ConexaoBancoSQL.fecharConexao();

        // Insere aula caso não exista
        if (!AulaExiste)
        {

            //Verifica Ano Letivo
            strSelect = "select ano_letivo from tbl_parametros " +
                "where ID_inst=" + param6 ;
            OperacaoBanco operacaoAno = new OperacaoBanco();
            SqlDataReader rcrdsetAno = operacaoAno.Select(strSelect);
            while (rcrdsetAno.Read())
            {
                Ano = Convert.ToString(rcrdsetAno[0]);
            }
            ConexaoBancoSQL.fecharConexao();

            OperacaoBanco operacaoInst2 = new OperacaoBanco();
            Boolean inserirUser = operacaoInst2.Insert("INSERT INTO Tbl_Alunos_Frequencia_Aulas (ID_Turma , ID_Disc , " +
                "Data_Aula,Observ, id_periodo, ano_letivo ) " +
               "VALUES (" +
               "'" + param1 + "'," +
               "'" + param2 + "'," +
               "'" + param3 + "'," +
               "'" + param4 + "'," +
               "'" + param5 + "'," +
               "'" + Ano + "'" +
               ")");
            ConexaoBancoSQL.fecharConexao();

            if (inserirUser == true)
            {
                retorno = "Aula Cadastrada com Sucesso";
            }
            else
            {
                retorno = "Aula Não Cadastrada";
            }

        }

        return retorno;
    }

    [WebMethod]
    public string Frequencia_Aulas_Excluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Alunos_Frequencia_Aulas where ID_Aula =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            //Apagar registros filhos
            operacao3 = new OperacaoBanco();
            deletar = operacao3.Delete("delete from Tbl_Alunos_Frequencia_Alunos where ID_Aula =" + param1);
            ConexaoBancoSQL.fecharConexao();

            url = "SolicitacoesMatriculas_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Frequencia_Aulas_Listar(string param1, string param2)
    {
        // TODAS AS AULAS DA TURMA/DISCIPLINA
        string Resultado = "";
        int totalRegistros = 0;
        List<Object> resultado = new List<object>();

        try
        {
            OperacaoBanco operacao1 = new OperacaoBanco();
            SqlDataReader dados1 = operacao1.Select("select t1.ID_Aula, format(t1.Data_Aula,'dd/MM/yyyy') as d1 , t1.Observ, t2.Descricao "
                    + "FROM Tbl_Alunos_Frequencia_Aulas t1 " 
                    + "inner join tbl_periodo_avaliacao t2 on (t1.id_periodo = t2.id_periodo) "
                    + "where t1.ID_Turma ='" + param1 + "' "
                    + "and t1.ID_Disc = '" + param2 + "' "
                    + "order by t1.Data_Aula desc"
                    );

            while (dados1.Read())
            {
                resultado.Add(new
                {
                    ID_Aula = dados1[0].ToString(),
                    Data_Aula = dados1[1].ToString(),
                    Observ = dados1[2].ToString(),
                    Periodo = dados1[3].ToString()
                });
                totalRegistros += 1;
            }
            ConexaoBancoSQL.fecharConexao();

            if (totalRegistros == 0)
            {
                resultado.Add(new
                {
                    ID_Aula = "9999",
                    Data_Aula = "X",
                    Observ = "X",
                    Periodo = "X"
                });
            }

            //O JavaScriptSerializer vai fazer o web service retornar JSON
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(resultado);

        }
        catch (Exception)
        {
            Resultado = "FALHA";
        }

        return Resultado;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Frequencia_Aulas_Listar_Alunos(string param1)
    {
        // RETORNA JSON COM TODOS os alunos da turma

        string Resultado = "";
        int totalRegistros = 0;
        List<Object> resultado = new List<object>();

        try
        {
            OperacaoBanco operacao1 = new OperacaoBanco();
            SqlDataReader dados1 = operacao1.Select("select ID_Aluno "
                    + "FROM Tbl_Alunos "
                    + "where ID_Turma ='" + param1 + "'");

            while (dados1.Read())
            {
                resultado.Add(new
                {
                    ID_Aluno = dados1[0].ToString()
                });
                totalRegistros += 1;
            }
            ConexaoBancoSQL.fecharConexao();

            if (totalRegistros == 0)
            {
                resultado.Add(new
                {
                    ID_Aluno = "9999"
                });
            }

            //O JavaScriptSerializer vai fazer o web service retornar JSON
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(resultado);

        }
        catch (Exception)
        {
            Resultado = "FALHA";
        }

        return Resultado;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Frequencia_Aulas_Listar_Indiv(string param1)
    {
        // frequencia individual
        string Resultado = "";
        int totalRegistros = 0;
        List<Object> resultado = new List<object>();

        try
        {
            OperacaoBanco operacao1 = new OperacaoBanco();
            SqlDataReader dados1 = operacao1.Select("select t1.ID_Freq, t2.Nome, t1.Presente  "
                    + "FROM Tbl_Alunos_Frequencia_Alunos t1 "
                    + "inner join Tbl_Alunos t2 on (t1.ID_Aluno = t2.ID_Aluno) "
                    + "where ID_Aula ='" + param1 + "'");

            while (dados1.Read())
            {
                resultado.Add(new
                {
                    ID_freq = dados1[0].ToString(),
                    Aluno = dados1[1].ToString(),
                    presenca = dados1[2].ToString()
                });
                totalRegistros += 1;
            }
            ConexaoBancoSQL.fecharConexao();

            if (totalRegistros == 0)
            {
                resultado.Add(new
                {
                    ID_freq = "9999",
                    Aluno = "X",
                    presenca = "0"
                });
            }

            //O JavaScriptSerializer vai fazer o web service retornar JSON
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(resultado);

        }
        catch (Exception)
        {
            Resultado = "FALHA";
        }

        return Resultado;
    }

    [WebMethod]
    public string Frequencia_Aluno_Lancar_Indiv(string param1, string param2, string param3)
    {
        //param1 = ID da Aula
        //param2 = ID do Aluno
        //param3 = status: 1-presente  0-ausente

        string retorno = "";

        OperacaoBanco operacaoInst2 = new OperacaoBanco();
        Boolean inserirUser = operacaoInst2.Insert("INSERT INTO Tbl_Alunos_Frequencia_Alunos (ID_Aula, ID_Aluno, Presente ) " +
           "VALUES (" +
           "'" + param1 + "'," +
           "'" + param2 + "'," +
           "'" + param3 + "')"
           );
        ConexaoBancoSQL.fecharConexao();

        if (inserirUser == true)
        {
            retorno = "Sucesso";
        }
        else
        {
            retorno = "Não Cadastrada";
        }

        return retorno;
    }

    [WebMethod]
    public string Frequencia_Alunos_Excluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Alunos_Frequencia_Alunos where ID_Aula =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
           url = "OK";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string Frequencia_Alunos_Alterar_Status(string param1, string param2)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        bool alterar = operacao3.Update("update Tbl_Alunos_Frequencia_Alunos " +
            "set Presente = '" + param2 + "' " +
            "where ID_Freq =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (alterar == true)
        {
            url = "OK";
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


