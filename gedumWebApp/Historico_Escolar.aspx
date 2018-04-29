<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Historico_Escolar.aspx.cs" Inherits="Historico_Escolar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Histórico Escolar</title>
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
        }
    </style>

</head>
<body>
    <div class="col-md-3">
        <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Histórico Escolar</h3>
    </div>

    <!-- Filtro -->
    <div class="w3-container">
        <form class="form-horizontal">
            <fieldset>

                <div class="form-group">
                    <label for="select_Aluno" class="col-md-1 control-label">Aluno</label>
                    <div class="col-md-4">
                        <select id="select_Aluno" class="form-control">
                            <option value="0"></option>
                            <asp:Literal ID="Literal_Alunos" runat="server"></asp:Literal>
                        </select>
                    </div>

                    <label for="input_ano" class="col-md-1 control-label">Ano Letivo</label>
                    <div class="col-md-2">
                        <input id="input_ano" class="form-control" type="number" value="0" />
                    </div>

                    <div class="col-md-2">
                        <button id="Ver_aulas" type="button" class="w3-btn w3-round w3-border w3-green w3-block"
                            onclick="verificar()">
                            <i class="fa fa-search"></i>&nbsp;Buscar</button>
                    </div>
                </div>

            </fieldset>
        </form>
    </div>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeHistorico.js"></script>

</body>
</html>
