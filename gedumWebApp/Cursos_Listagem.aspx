<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cursos_Listagem.aspx.cs" Inherits="Cursos_Listagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    
    <title>Listagem de Cursos</title>         <!--*******Customização*******-->
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- Paginação -->
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css" />

    <!--*******Customização*******-->
    <style> 
        body {
            background-image: url("images/fundo.jpg"); 
        }
    </style>

</head>
<body>
    <p></p>
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-green" style="margin-left: 2%; margin-right: 2%">
        <small><i class="fa fa-calendar-check-o fa-2x"></i>&nbsp;&nbsp;Total de Cursos Cadastradas:
            <asp:Literal ID="lblTotalRegistros" runat="server"></asp:Literal></small> <!--*******Customização*******-->
        &nbsp;&nbsp;
        <button class="w3-btn w3-round w3-border w3-green w3-right" onclick="NovoRegistro()"><i class="fa fa-plus"></i>&nbsp;Novo Curso</button>  <!--*******Customização*******-->
    </div>

    <br />


    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small" style="margin-left: 2%; margin-right: 2%">
        <!-- Planilha  -->
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <!-- Planilha  -->
    </div>

    <!-- Modal Excluir -->
    <div id="DivModal" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 400px">

            <form class="w3-container">
                <div class="w3-section w3-center">
                    <header class="w3-container w3-green w3-center">
                        <h4><strong>Atenção</strong></h4>
                    </header>
                    <br />
                    <i class="fa fa-3x fa-exclamation-triangle" aria-hidden="true"></i>
                    <br />
                    <h3><strong>Confirma Exclusão?</strong> </h3>
                    <br />
                    <p>
                        <button type="button" class="w3-button w3-round w3-border w3-light-green w3-hover-green" onclick="Excluir_cancel()">Não</button>&nbsp;&nbsp;&nbsp;
                        <button type="button" class="w3-button w3-round w3-border w3-light-green w3-hover-red" onclick="ExcluirRegistro()">Sim</button>
                    </p>
                    <br />
                </div>
            </form>
            <input type="hidden" id="HiddenID" />
        </div>
    </div>
    <!-- Modal Excluir -->

    <!-- Scripts Diversos -->
    <script type="text/javascript" src="Scripts/codeCursos_Listagem.js"></script>   <!--*******Customização*******-->

    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script>

</body>
</html>
