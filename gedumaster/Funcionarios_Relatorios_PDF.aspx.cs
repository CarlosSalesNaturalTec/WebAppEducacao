﻿using System;
using System.Text;

using System.IO;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Funcionarios_Relatorios_PDF : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string strTabela;
    string strCabecalho;
    string idMunicAux;
    string RelFiltro;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            idMunicAux = Session["ID_Munic"].ToString();
            RelFiltro = Request.QueryString["p1"];

            TabelaHeader();
            TabelaCorpo();
            TabelaRodape();

            Cabecalho();

            MontaPDF("<html><body>" + strCabecalho + strTabela + "</body></html>");
        }
    }

    private void TabelaHeader()
    {
        string stringcomaspas = "<table border='1'>" +
                "<tr>" +
                "<th><b>LOTADO EM</b></th>" +
                "<th><b>NOME</b></th>" +
                "<th><b>VINCULO</b></th>" +
                "<th><b>SITUAÇÃO</b></th>" +
                "<th><b>FUNÇÃO</b></th>" +
                "</tr>";

        str.Clear();
        str.Append(stringcomaspas);
    }

    private void TabelaCorpo()
    {
        string stringcomaspas = "";
        string stringselect = "";

        switch (RelFiltro)
        {
            case "Todas":
                stringselect = "select lotado , nome, vinculo, Situacao , funcao " +
                    "from Tbl_Funcionarios " +
                    "where ID_Munic = " + idMunicAux +
                    " order by lotado,nome";
                break;
            
            default:
                stringselect = "select lotado , nome, vinculo, Situacao , funcao " +
                    "from Tbl_Funcionarios " +
                    "where ID_Munic = " + idMunicAux +
                    " and lotado = '" + RelFiltro + "'" +
                    " order by lotado,nome";
                break;
        }



        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        string Coluna1, Coluna2, Coluna3, Coluna4, Coluna5;

        while (dados.Read())
        {

            Coluna1 = Convert.ToString(dados[0]);
            Coluna2 = Convert.ToString(dados[1]);
            Coluna3 = Convert.ToString(dados[2]);
            Coluna4 = Convert.ToString(dados[3]);
            Coluna5 = Convert.ToString(dados[4]);

            stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "</tr>";
            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();
    }

    private void TabelaRodape()
    {
        string footer = "</table>";
        str.Append(footer);

        strTabela = str.ToString();
    }

    private void Cabecalho()
    {
        string strTexto;
        str.Clear();

        strTexto = "<h3><b>" + NomeMunicipio(idMunicAux) + "</b></h3>";
        str.Append(strTexto);

        strTexto = "<h3>Relatório de Funcionários - Por Secretaria: " + RelFiltro + "</h3>";
        str.Append(strTexto);

        strTexto = "<br><br>";
        str.Append(strTexto);

        strCabecalho = str.ToString();
    }

    private void MontaPDF(string HtmlTxt)
    {

        HtmlForm form = new HtmlForm();
        Document document = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
        MemoryStream ms = new MemoryStream();
        PdfWriter writer = PdfWriter.GetInstance(document, ms);
        HTMLWorker obj = new HTMLWorker(document);

        StringReader se = new StringReader(HtmlTxt);
        document.Open();
        obj.Parse(se);
        document.Close();
        Response.Clear();

        Response.AddHeader("content-disposition", "filename=RelatorioFuncionarios.pdf");  //vizualiza em tela

        Response.ContentType = "application/pdf";
        Response.Buffer = true;
        Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.End();

    }

    public string NomeMunicipio(string IDAux)
    {

        string Munic = "";

        string stringSelect = "select Nome from Tbl_Municipios where ID_Munic   = " + IDAux;
        OperacaoBanco Operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = Operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            Munic = Convert.ToString(rcrdset[0]);
        }
        ConexaoBancoSQL.fecharConexao();

        return Munic;
    }


}