<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Boletins_Ficha_Listagem.aspx.cs" Inherits="Boletins_Ficha_Listagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Boletim Escolar - Listagem de Notas</title>
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
            background-image: url("images/fundo.jpg");
            background-repeat: repeat;
            height: 100%;
        }

        #results {
            float: left;
            margin: 5px;
            padding: 5px;
            border: 1px solid;
            background: #ccc;
        }
    </style>

</head>
<body>

    <div>
        <h3>&nbsp;&nbsp;&nbsp;Boletim Escolar - Listagem de Notas</h3>
        <hr />
        <div class="w3-container w3-animate-left">

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="input_nome" class="col-md-1 control-label">Nome</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_nome" disabled>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input_Curso" class="col-md-1 control-label">Curso</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_Curso" disabled>
                            </div>
                            <label for="input_Curso" class="col-md-1 control-label">Turma</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_Turma" disabled>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input_mat" class="col-md-1 control-label">Matrícula</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_mat" disabled>
                            </div>
                             <label for="input_Ano" class="col-md-1 control-label">Ano Letivo</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_Ano" disabled>
                            </div>
                        </div>
                    </fieldset>
                </form>

            </div>

            <!-- Camera -->
            <div class="w3-quarter">
                <div id="results"></div>
            </div>
            <!-- Camera -->

        </div>
    </div>

    <hr />

    <!-- Planilha  -->
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small" style="margin-left: 2%; margin-right: 2%">
        <asp:Literal ID="Literal_Table" runat="server"></asp:Literal>
    </div>
    <!-- Planilha  -->

    <hr />

    <!-- Auxiliares -->
    <asp:Literal ID="LiteralAux" runat="server"></asp:Literal>

</body>
</html>
