﻿using System;
using System.Text;
using iTextSharp.text;
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


    private void MontaPDF(string HtmlTxt)
    {

        Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
        System.IO.MemoryStream str = new System.IO.MemoryStream();
        PdfWriter writer = PdfWriter.GetInstance(doc, str);
        writer.PageEvent = new PDFHeaderFooter();

        doc.Open();

        PdfPTable tab = new PdfPTable(3);

        PdfPCell cell = new PdfPCell(new Phrase("Header", new Font(Font.FontFamily.HELVETICA, 24F)));

        cell.Colspan = 3;
        cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
        cell.BorderColor = new BaseColor(System.Drawing.Color.Red);
        cell.Border = Rectangle.BOTTOM_BORDER; // | Rectangle.TOP_BORDER;
        cell.BorderWidthBottom = 3f;
        tab.AddCell(cell);

        //row 1
        tab.AddCell("R1C1");
        tab.AddCell("R1C2");
        tab.AddCell("R1C3");
        //row 2
        tab.AddCell("R2C1");
        tab.AddCell("R2C2");
        tab.AddCell("R2C3");
        cell = new PdfPCell();
        cell.Colspan = 3;

        iTextSharp.text.List pdfList = new List(List.UNORDERED);
        pdfList.Add(new iTextSharp.text.ListItem(new Phrase("Unorder List 1")));
        pdfList.Add("Unorder List 2");
        pdfList.Add("Unorder List 3");
        pdfList.Add("Unorder List 4");
        cell.AddElement(pdfList);
        tab.AddCell(cell);
        doc.Add(tab);

        doc.Close();

        Response.Clear();
        Response.AddHeader("content-disposition", "filename=RelatorioFuncionarios.pdf");  //vizualiza em tela
        Response.ContentType = "application/pdf";
        Response.Buffer = true;
        Response.OutputStream.Write(str.GetBuffer(), 0, str.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.End();


       

    }

    public class PDFHeaderFooter : PdfPageEventHelper
    {
        #region Fields
        private string _header;
        #endregion

        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion

        //http://nilthakkar.blogspot.com.br/2015/08/itextsharp-add-dynamic-header.html


        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            Font baseFontNormal = new Font(Font.FontFamily.HELVETICA, 12f, Font.NORMAL, .BaseColor.BLACK);
            Phrase p1Header = new Phrase(Header, baseFontNormal);



            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            cell = new PdfPCell(new Phrase("Footer"));
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);
        }




    }
}