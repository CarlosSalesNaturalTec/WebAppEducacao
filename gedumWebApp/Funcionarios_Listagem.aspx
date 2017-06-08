﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Funcionarios_Listagem.aspx.cs" Inherits="Funcionarios_Listagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Listagem de Funcionários - GEDUM</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">


    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <style>
        body {
            background-image: url("Images/fundo.jpg");
        }
    </style>

</head>
<body>
    <div>
        <header class="w3-container w3-green w3-center w3-padding-small">
            <h4><strong>Cadastro de Funcionários</strong></h4>
        </header>
    </div>

    <br />

    <div class="w3-container w3-border w3-round w3-padding-16" style="margin-left: 2%; margin-right: 2%">
        <small><i class="fa fa-users fa-2x"></i>&nbsp;&nbsp;Total de Funcionários Cadastrados:
            <asp:Literal ID="lblTotalRegistros" runat="server"></asp:Literal></small>
        &nbsp;&nbsp;
        <button class="w3-btn w3-round w3-green w3-right" onclick="NovoRegistro()"><i class="fa fa-plus"></i>&nbsp;Novo Funcionário</button>
    </div>

    <br />

    <div class="w3-small">
        <!-- Planilha  -->
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <!-- Planilha  -->
    </div>


    <script type="text/javascript" src="Scripts/codeFuncionario_Listagem.js"></script>

</body>
</html>