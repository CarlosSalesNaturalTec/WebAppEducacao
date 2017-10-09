﻿using System;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class PDF_Teste : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GeneratePDF(object sender, System.EventArgs e)
    {
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            Document document = new Document(PageSize.A4, 10, 10, 10, 10);

            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            Chunk chunk = new Chunk("This is from chunk. ");
            document.Add(chunk);

            Phrase phrase = new Phrase("This is from Phrase.");
            document.Add(phrase);

            Paragraph para = new Paragraph("This is from paragraph.");
            document.Add(para);

            string text = @"you are successfully created PDF file.";
            Paragraph paragraph = new Paragraph();
            paragraph.SpacingBefore = 10;
            paragraph.SpacingAfter = 10;
            paragraph.Alignment = Element.ALIGN_LEFT;
            paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
            paragraph.Add(text);
            document.Add(paragraph);

            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";

            string pdfName = "User";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }

}

