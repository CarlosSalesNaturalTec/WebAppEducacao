<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alunos_Frequencia.aspx.cs" Inherits="Alunos_Frequencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Controle de Frequência</title>
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

                    <div class="col-md-2">
                        <button id="Ver_aulas" type="button" class="w3-btn w3-round w3-border w3-green w3-block"
                            onclick="verificar_aulas()">
                            <i class="fa fa-search"></i>&nbsp;Ver Aulas</button>
                    </div>

                    <div class="col-md-2">
                        <button id="lancar_Aula" type="button" class="w3-btn w3-round w3-border w3-green w3-block"
                            onclick="Lancar_aulas()">
                            <i class="fa fa-plus"></i>&nbsp;Lançar Aula</button>
                    </div>

                </div>

            </fieldset>
        </form>
    </div>

    <br />

    <!-- Planilha  Aulas -->
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small" style="margin-left: 2%; margin-right: 2%">
        <table id="tabela_aulas" style="width: 100%;" class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Cod.</th>
                    <th>Data</th>
                    <th>Observações</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>
    <!-- Planilha  Aulas -->

    <!-- Planilha  Frequencia-->
    <div id="DIvFreq" class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small" style="margin-left: 2%; margin-right: 2%; display:none">
        <table id="tabela_freq" style="width: 100%;" class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Cod.</th>
                    <th>Aluno</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>
    <!-- Planilha  Frequencia-->


    <!-- Modal Incluir Aula -->
    <div id="DivModal" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 300px">

            <form class="w3-container">
                <div class="w3-section w3-center">
                    <header class="w3-container w3-blue w3-center">
                        <h4><strong>Informe Data da Aula</strong></h4>
                    </header>

                    <br />
                    <input id="input_Data" type="date" class="form-control" />
                    <br />
                    <input id="input_Obs" type="text" class="form-control"  placeholder="Observações"  />
                    <br />

                    <p>
                        <button type="button" class="w3-button w3-round w3-border w3-light-blue w3-hover-red" onclick="Lancar_Cancel()">Cancelar</button>&nbsp;&nbsp;&nbsp;
                        <button type="button" class="w3-button w3-round w3-border w3-light-blue w3-hover-green" onclick="Lancar_aulas_Confirma()">Confirmar</button>
                    </p>
                    <br />
                </div>
            </form>
            <input type="hidden" id="HiddenID" />
        </div>
    </div>
    <!-- Modal Excluir -->

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeAlunos_Frequencia.js"></script>

</body>
</html>
