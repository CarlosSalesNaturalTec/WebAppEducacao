﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Boletins_Listagem.aspx.cs" Inherits="Boletins_Listagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Boletim Escolar</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- Paginação -->
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css" />
    
    <style>
        body {
            background-image: url("images/fundo.jpg");
        }
    </style>

</head>
<body>
    <p></p>
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-green" style="margin-left: 2%; margin-right: 2%">
        <h4>Boletim Escolar</h4>
    </div>

    <br />

    <!-- Planilha  -->
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small" style="margin-left: 2%; margin-right: 2%">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    <!-- Planilha  -->

    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script>

</body>
</html>
