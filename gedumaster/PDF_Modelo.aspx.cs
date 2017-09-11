using System;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class PDF_Modelo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);  
        }

        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            tabFot.SpacingAfter = 10F;
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            cell = new PdfPCell(new Phrase("Header"));
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);


        }

        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            cell = new PdfPCell(new Phrase("Footer"));
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);
        }

        //write on close of document
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            //base.OnCloseDocument(writer, document);
        }

    }

    }