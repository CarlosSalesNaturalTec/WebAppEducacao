﻿using System;

public partial class Funcionarios_Novo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //caso não esteja logado, gera um erro em tempo de execução e vai para página de login
        string iduser = Session["UserID"].ToString();


    }
}