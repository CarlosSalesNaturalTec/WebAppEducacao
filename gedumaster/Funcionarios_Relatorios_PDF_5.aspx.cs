using System;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class Funcionarios_Relatorios_PDF_5 : System.Web.UI.Page
{
    string RelFiltro, idMunicAux, nomeUser, txtAux;
    int colunas;
    PdfPTable table;
    PdfPCell cell;

    Font fontTitulo = new Font(Font.FontFamily.UNDEFINED, 12, Font.BOLD);
    Font fontSubTitulo = new Font(Font.FontFamily.UNDEFINED, 10, Font.NORMAL);
    Font fontTabelaHeader = new Font(Font.FontFamily.UNDEFINED, 10, Font.BOLDITALIC);
    Font fontTabela = new Font(Font.FontFamily.UNDEFINED, 10, Font.NORMAL);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            idMunicAux = Session["ID_Munic"].ToString();
            nomeUser = Session["UserName"].ToString();

            RelFiltro = Request.QueryString["p1"];
            switch (RelFiltro) { case "Todas": colunas = 5; break; default: colunas = 4; break; }

            MontaPDF();
        }
    }

    private void MontaPDF()
    {

        Document doc = new Document(PageSize.A4.Rotate(), 40, 40, 60, 60);
        System.IO.MemoryStream str = new System.IO.MemoryStream();
        PdfWriter writer = PdfWriter.GetInstance(doc, str);

        #region Cabeçalhos e Rodapés das Páginas
        PDFHeaderFooter obj = new PDFHeaderFooter();
        obj.Header_a = NomeMunicipio(idMunicAux) + " - Gestão Educacional Municipal";
        obj.Header_b = "GEDUM";
        obj.Footer_a = "Emissão: " + DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
        obj.Footer_b = "Usuario: " + nomeUser;
        #endregion

        writer.PageEvent = obj;
        doc.Open();

        #region Titulo e SubTitulo do Relatorio
        txtAux = "Relatório de Funcionários";
        doc.Add(new Paragraph(txtAux, fontTitulo));
        txtAux = "Por Tipo Sanguíneo: " + RelFiltro;
        doc.Add(new Paragraph(txtAux, fontSubTitulo));
        doc.Add(Chunk.NEWLINE);
        #endregion

        #region Header Tabela
        table = new PdfPTable(colunas);
        table.WidthPercentage = 100;

        cell = new PdfPCell(new Phrase("Nome", fontTabelaHeader)); table.AddCell(cell);
        cell = new PdfPCell(new Phrase("Vínculo", fontTabelaHeader)); table.AddCell(cell);
        cell = new PdfPCell(new Phrase("Situação", fontTabelaHeader)); table.AddCell(cell);
        cell = new PdfPCell(new Phrase("Função", fontTabelaHeader)); table.AddCell(cell);
        if (colunas ==5) {
            cell = new PdfPCell(new Phrase("Tipo Sanguíneo", fontTabelaHeader)); table.AddCell(cell);
        }
        #endregion

        #region Corpo da Tabela
        TabelaCorpo();
        #endregion

        #region Montagem e Visualização do PDF
        doc.Add(table);
        doc.Close();

        Response.Clear();
        Response.AddHeader("content-disposition", "filename=RelatorioFuncionarios.pdf");  //vizualiza em tela
        Response.ContentType = "application/pdf";
        Response.Buffer = true;
        Response.OutputStream.Write(str.GetBuffer(), 0, str.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.End();
        #endregion

    }

    private void TabelaCorpo()
    {
        string stringselect = "";

        switch (RelFiltro)
        {
            case "Todas":
                stringselect = "select  nome, vinculo, Situacao , funcao, TipoSanguinio  " +
                    "from Tbl_Funcionarios " +
                    "where ID_Munic = " + idMunicAux +
                    " order by TipoSanguinio, nome";
                break;

            default:
                stringselect = "select nome, vinculo, Situacao , funcao, TipoSanguinio " +
                    "from Tbl_Funcionarios " +
                    "where ID_Munic = " + idMunicAux +
                    " and TipoSanguinio = '" + RelFiltro + "'" +
                    " order by TipoSanguinio ,nome";
                break;
        }

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        string Coluna1, Coluna2, Coluna3, Coluna4, Coluna5;
        int total_registros = 0;

        while (dados.Read())
        {
            Coluna1 = Convert.ToString(dados[0]);
            Coluna2 = Convert.ToString(dados[1]);
            Coluna3 = Convert.ToString(dados[2]);
            Coluna4 = Convert.ToString(dados[3]);
            Coluna5 = Convert.ToString(dados[4]);

            cell = new PdfPCell(new Phrase(Coluna1, fontTabela)); table.AddCell(cell);
            cell = new PdfPCell(new Phrase(Coluna2, fontTabela)); table.AddCell(cell);
            cell = new PdfPCell(new Phrase(Coluna3, fontTabela)); table.AddCell(cell);
            cell = new PdfPCell(new Phrase(Coluna4, fontTabela)); table.AddCell(cell);
            if (colunas == 5 ) { cell = new PdfPCell(new Phrase(Coluna5, fontTabela)); table.AddCell(cell); }
            total_registros++;
        }
        ConexaoBancoSQL.fecharConexao();

        string totalreg = "Total de Registros:" + total_registros;
        string linhabranco = "---";
        cell = new PdfPCell(new Phrase(linhabranco, fontTabelaHeader)); table.AddCell(cell);
        cell = new PdfPCell(new Phrase(linhabranco, fontTabelaHeader)); table.AddCell(cell);
        cell = new PdfPCell(new Phrase(linhabranco, fontTabelaHeader)); table.AddCell(cell);
        if (colunas == 5)
        {
            cell = new PdfPCell(new Phrase(linhabranco, fontTabelaHeader)); table.AddCell(cell);
            cell = new PdfPCell(new Phrase(totalreg, fontTabelaHeader)); table.AddCell(cell);
        }
        else
        {
            cell = new PdfPCell(new Phrase(totalreg, fontTabelaHeader)); table.AddCell(cell);
        }
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


    public class PDFHeaderFooter : PdfPageEventHelper
    {

        #region Cabeçalho e Rodapé - Construtores
        private string _header_a;
        private string _header_b;
        private string _footer_a;
        private string _footer_b;

        public string Header_a
        {
            get { return _header_a; }
            set { _header_a = value; }
        }
        public string Header_b
        {
            get { return _header_b; }
            set { _header_b = value; }
        }

        public string Footer_a
        {
            get { return _footer_a; }
            set { _footer_a = value; }
        }
        public string Footer_b
        {
            get { return _footer_b; }
            set { _footer_b = value; }
        }
        #endregion

        Font ffont = new Font(Font.FontFamily.UNDEFINED, 9, Font.NORMAL);
        Font ffont1 = new Font(Font.FontFamily.UNDEFINED, 9, Font.ITALIC);

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte cb = writer.DirectContent;
            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = document.Right - document.Left;
            PdfPCell cell = new PdfPCell(new Phrase());
            table.AddCell(cell);

            #region HEADER
            Phrase header = new Phrase(Header_a, ffont1);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, header, document.LeftMargin, document.Top + 30, 0);
            Phrase headerB = new Phrase(Header_b, ffont1);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, headerB, document.Right, document.Top + 30, 0);
            //table.WriteSelectedRows(0, 1, document.Left, document.Top + 20, writer.DirectContent);
            #endregion

            #region FOOTER
            Phrase footer = new Phrase(Footer_a, ffont1);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, footer, document.LeftMargin, document.Bottom - 30, 0);
            Phrase pagina = new Phrase(Footer_b + " - " + "Pag.: " + writer.PageNumber, ffont1);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, pagina, document.Right, document.Bottom - 30, 0);
            table.WriteSelectedRows(0, 1, document.Left, document.Bottom - 10, writer.DirectContent);
            #endregion

        }

    }

}