using System;

public partial class Painel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblInst.Text =  Session["InstNome"].ToString();
        //lblUSer.Text =  Session["UserName"].ToString();
    }
}