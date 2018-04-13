<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alunos_Frequencia_Presencas.aspx.cs" Inherits="Alunos_Frequencia_Presencas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Controle de Frequência - Alunos Presentes</title>
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
    <div class="col-md-8">
        <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Controle de Frequência - Alunos Presentes</h3>
    </div>

    <!-- Filtro -->
    <div class="w3-container">
        <form class="form-horizontal">
            <fieldset>

                <div class="form-group">
                    <label for="select_Aluno" class="col-md-1 control-label">Aluno</label>
                    <div class="col-md-6">
                        <select id="select_Aluno" class="form-control">
                            <option value="0">Selecione</option>
                            <asp:Literal ID="Literal_Aluno" runat="server"></asp:Literal>
                        </select>
                    </div>

                    <div class="col-md-2">
                        <button id="bt_Presente" type="button" class="w3-btn w3-round w3-border w3-green w3-block"
                            onclick="">
                            <i class="fa fa-search"></i>&nbsp;Presente</button>
                    </div>

                    <div class="col-md-2">
                        <button id="bt_ausente" type="button" class="w3-btn w3-round w3-border w3-green w3-block"
                            onclick="">
                            <i class="fa fa-plus"></i>&nbsp;Ausente</button>
                    </div>

                </div>

            </fieldset>
        </form>
    </div>

    <br />

    <!-- Planilha Alunos Presentes/Ausentes-->
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small" style="margin-left: 2%; margin-right: 2%">
        <table id="tabela_alunos" style="width: 100%;" class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Aluno</th>
                    <th>Presença</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>
    <!-- Planilha  Aulas -->

</body>
</html>
