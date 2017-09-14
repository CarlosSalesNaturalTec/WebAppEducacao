using System;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class Funcionarios_Relatorios_PDF : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string strTabela;
    string strCabecalho;
    string RelFiltro;

    string idMunicAux;
    string nomeUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            idMunicAux = "1";           //Session["ID_Munic"].ToString();
            nomeUser = "Carlos Sales";  // Session["UserName"].ToString();
            RelFiltro = "";             //Request.QueryString["p1"];

            //TabelaHeader();
            //TabelaCorpo();
            //TabelaRodape();
            //Cabecalho();

            MontaPDF();

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

    private void MontaPDF()
    {

        Document doc = new Document(PageSize.A4.Rotate(), 40, 40, 60, 60);
        System.IO.MemoryStream str = new System.IO.MemoryStream();
        PdfWriter writer = PdfWriter.GetInstance(doc, str);

        PDFHeaderFooter obj = new PDFHeaderFooter();
        obj.Header_a = "Prefeitura Municipal de Conde - Gestão Educacional Municipal"; //NomeMunicipio(idMunicAux) + " - Gestão Educacional Municipal";
        obj.Header_b = "GEDUM";
        obj.Footer_a = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
        obj.Footer_b = "Usuario: " + nomeUser;

        writer.PageEvent = obj;

        #region Corpo do PDF
        doc.Open();
        for (int i = 0; i < 3; i++)
        {
            doc.Add(new Paragraph("Corpo da Página: " + i));
            doc.NewPage();
        }
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

    public class PDFHeaderFooter : PdfPageEventHelper
    {

        #region Fields
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

        Font ffont = new Font(Font.FontFamily.UNDEFINED, 12, Font.NORMAL);
        Font ffontBold = new Font(Font.FontFamily.UNDEFINED, 12, Font.BOLD);

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte cb = writer.DirectContent;

            Phrase header = new Phrase(Header_a, ffontBold);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, header, document.LeftMargin, document.Top + 30, 0);
            Phrase headerB = new Phrase(Header_b, ffont);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, headerB, document.Right, document.Top + 30, 0);

            Phrase footer = new Phrase(Footer_a, ffont);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, footer, document.LeftMargin, document.Bottom - 30, 0);
            Phrase pagina = new Phrase("Pag.:" + writer.PageNumber + " - " + Footer_b, ffont);
            ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, pagina, document.Right, document.Bottom - 30, 0);
        }

    }

}