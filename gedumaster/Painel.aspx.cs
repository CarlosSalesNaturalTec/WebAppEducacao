using System;

public partial class Painel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblWelcome.Text = Session["UserName"].ToString();
    }
}