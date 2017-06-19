using System;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string vValida1, vValida2;
        vValida1 = DateTime.Now.ToString("dd");
        vValida2 = DateTime.Now.ToString("MM");
        int vValida3 = Convert.ToInt16(vValida1) * Convert.ToInt16(vValida2);
        string vValida4 = vValida3.ToString();

        string param1 = Request.QueryString["p1"];
        if (param1 != vValida4)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Session["UserName"] = Request.QueryString["p2"];
            Session["UserID"] = Request.QueryString["p3"];
            Session["InstID"] = Request.QueryString["p4"];
            Response.Redirect("Painel.aspx");
        }
    }
}