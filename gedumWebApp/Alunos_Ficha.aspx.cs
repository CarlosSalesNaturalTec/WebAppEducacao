﻿using System;
using System.Text;

public partial class Alunos_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string idAux;

    protected void Page_Load(object sender, EventArgs e)
    {

        string InstID = Session["InstID"].ToString();
        idAux = Request.QueryString["v1"];

        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDinst').value = \"" + InstID + "\";" +
                        "</script>";
        Literal1.Text = ScriptAux;

        mostraCurso(InstID);
        mostraTurma(InstID);

        PreencheCampos(idAux);
        
    }

    private void mostraCurso(string id)
    {
        StringBuilder strInst = new StringBuilder();
        strInst.Clear();
        strInst.Append("<option value=\"0\"> </option>");

        string strSelect = "select ID_Curs, Nome from Tbl_Cursos where ID_Inst = "  + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        LITERAL_CURSO.Text = strInst.ToString();

    }

    private void mostraTurma(string id)
    {
        StringBuilder strInst = new StringBuilder();
        strInst.Clear();
        strInst.Append("<option value=\"0\"></option>");

        string strSelect = "select ID_turma, Nome from Tbl_Turmas where ID_Inst = " + id;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(strSelect);

        while (dados.Read())
        {
            strInst.Append("<option value=\"" + Convert.ToString(dados[0]) + "\">" + Convert.ToString(dados[1]) + "</option>");

        }
        ConexaoBancoSQL.fecharConexao();

        literal_turma.Text = strInst.ToString();

    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);
        ScriptDados = "var x = document.getElementsByClassName('form-control');";
        str.Append(ScriptDados);

        string stringSelect = "select " +
            "Nome," +           
            "format(Nascimento,'yyyy-MM-dd') as d1, " +
            "EstadoCivil," +
            "Pai," +
            "Mae," +
            "Responsavel," +
            "ResponsavelCPF," +
            "ResponsavelTel," +
            "Naturalidade," +
            "Nacionalidade," +
            "Etnia," +                      //10
            "TipoSanguinio," +  
            "Deficiente," +
            "DeficienteTipo," +
            "ID_Curso," +
            "ID_Turma," +
            "matricula," +
            "Endereco," +
            "Latitude," +
            "Longitude," +
            "Numero," +                 //20
            "Bairro," +
            "CEP," +
            "Cidade," +
            "UF," +
            "Celular1," +
            "Celular2," +
            "TelFixo," +
            "email," +
            "PIS," +
            "CPF," +                    //30
            "RG," +
            "RGEmissor," +
            "RGEmissao," +
            "CTPS," +
            "CTPSserie," +
            "CTPSEmissao," +
            "Titulo," +
            "Zona," +
            "Secao," +
            "CNH," +                    //40
            "Passaporte," +
            "CertNasc ," +
            "Alergias," +
            "AlergiasMed," +
            "AcidenteAvisar," +
            "CartaoSUS," +
            "FardaCamisa," +
            "FardaCamiseta," +
            "FardaCalca," +
            "FardaSapato," +            //50
            "FardaBota," +
            "FardaObs," +
            "FotoDataURI " +            //53
            "from Tbl_Alunos " +
            "where ID_aluno  = " + ID;

        string getValor = " ";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i < 53; i++)
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            ScriptDados = "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[53]) + "\"/>'; ";
            str.Append(ScriptDados);
            ScriptDados = "document.getElementById('Hidden1').value = \"" + Convert.ToString(rcrdset[53]) + "\";";
            str.Append(ScriptDados);
            ScriptDados = "document.getElementById('IDHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('al1').innerHTML = \"" + Convert.ToString(rcrdset[0]) + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('al2').innerHTML = \"" + Convert.ToString(rcrdset[0]) + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('al3').innerHTML = \"" + Convert.ToString(rcrdset[0]) + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('al4').innerHTML = \"" + Convert.ToString(rcrdset[0]) + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('al5').innerHTML = \"" + Convert.ToString(rcrdset[0]) + "\";";
            str.Append(ScriptDados);

            ScriptDados = "document.getElementById('al6').innerHTML = \"" + Convert.ToString(rcrdset[0]) + "\";";
            str.Append(ScriptDados);


            ScriptDados = "var latitude = document.getElementById('input_lat').value;";
            str.Append(ScriptDados);

            ScriptDados = "var longitude = document.getElementById('input_lng').value;";
            str.Append(ScriptDados);

            ScriptDados = "var urlMapa = \"MapaAuxiliar.aspx?lat=\" + latitude + \"&lng=\" + longitude;";
            str.Append(ScriptDados);

            ScriptDados = "window.open(urlMapa, 'MapFrame');";
            str.Append(ScriptDados);

            getValor = "document.getElementById('input_matri').value = \"" + Convert.ToString(rcrdset[16]) + "\";";
            str.Append(getValor);

            if(getValor == "0")
            {
                getValor = " " ;
            }           

        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";      
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }


}