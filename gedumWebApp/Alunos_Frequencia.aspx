<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alunos_Frequencia.aspx.cs" Inherits="Alunos_Frequencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Controle de Frequência</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

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
    <div class="col-md-3">
        <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Controle de Frequência</h3>
    </div>

    <!-- Filtro -->
    <div class="w3-container">
        <form class="form-horizontal">
            <fieldset>

                <div class="form-group">
                    <label for="select_Turma" class="col-md-1 control-label">Turma</label>
                    <div class="col-md-2">
                        <select id="select_Turma" class="form-control">
                            <option value="0">Selecione</option>
                            <asp:Literal ID="Literal_Turmas" runat="server"></asp:Literal>
                        </select>
                    </div>

                    <label for="select_Disc" class="col-md-1 control-label">Disciplina</label>
                    <div class="col-md-2">
                        <select id="select_Disc" class="form-control">
                            <option value="0">Selecione</option>
                            <asp:Literal ID="Literal_Disc" runat="server"></asp:Literal>
                        </select>
                    </div>

                    <label for="input_Data" class="col-md-1 control-label">Data</label>
                    <div class="col-md-2">
                        <input id="input_Data" type="date" class="form-control" />
                    </div>

                    <div class="col-md-2">
                        <button id="lancar_Freq" type="button" class="w3-btn w3-round w3-border w3-green w3-left" onclick="lancar_freq()"><i class="fa fa-plus"></i>&nbsp;Lançar Frequência</button>
                    </div>

                </div>

            </fieldset>
        </form>
    </div>

    <br />

    <!-- Planilha  -->
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small" style="margin-left: 2%; margin-right: 2%">
        <table id="tabela_freq" style="width: 100%;" class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Aluno</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>
    <!-- Planilha  -->

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeAlunos_Frequencia.js"></script>

    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script>

</body>
</html>
