﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Boletins.aspx.cs" Inherits="Boletins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Boletim</title>
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
            background-repeat: repeat;
            height: 100%;
        }
    </style>

</head>
<body>

    <!-- Boletim -->
    <div class="w3-container">
        <form class="form-horizontal">
            <fieldset>

                <br />

                <!-- nome do Aluno -->
                <div class="form-group">

                    <label for="select_aluno" class="col-md-1 control-label">ALUNO</label>
                    <div class="col-md-4">
                        <select id="select_aluno" class="w3-select w3-round w3-border">
                            <asp:Literal ID="Literal_aluno" runat="server"></asp:Literal>
                        </select>
                    </div>


                    <!-- nome da Disciplina -->

                    <label for="select_disciplina" class="col-md-1 control-label">DISCIPLINA</label>
                    <div class="col-md-4">
                        <select id="select_disciplina" class="w3-select w3-round w3-border">
                            <asp:Literal ID="Literal_disciplina" runat="server"></asp:Literal>
                        </select>
                    </div>
                </div>


                <div class="form-group">

                    <label for="input_Unidade" class="col-md-1 control-label">Unidade</label>
                    <div class="col-md-3">
                        <select class="form-control" id="input_Unidade">
                            <option value="1° UNIDADE">1° UNIDADE</option>
                            <option value="2° UNIDADE">2° UNIDADE</option>
                            <option value="3° UNIDADE">3° UNIDADE</option>
                            <option value="4° UNIDADE">4° UNIDADE</option>
                        </select>
                    </div>

                    <label for="input_TipoAvaliacao" class="col-md-2 control-label">Tipo Avaliação</label>
                    <div class="col-md-3">
                        <select class="form-control" id="input_TipoAvaliacao">
                            <option value="PROVA">PROVA</option>
                            <option value="TESTE">TESTE</option>
                            <option value="TRABALHO">TRABALHO</option>
                        </select>
                    </div>

                </div>

                <!-- Data Avaliação -->
                <div class="form-group">
                    <label for="input_dataavaliacao" class="col-md-1 control-label">Data Avaliação</label>
                    <div class="col-md-2">
                        <input type="date" class="form-control" id="input_dataavaliacao"/>
                    </div>

                    <label for="input_anoletivo" class="col-md-3 control-label">Ano Letivo</label>
                    <div class="col-md-1">
                        <input type="number" class="form-control" id="input_anoletivo"/>
                    </div>

                    <label for="input_nota" class="col-md-1 control-label">Nota</label>
                    <div class="col-md-1">
                        <input type="number" class="form-control" id="input_nota"/>
                    </div>

                    <div class="col-md-2">
                        <button id="btnAdicionar" type="button" class="w3-btn  w3-block w3-round w3-border w3-light-green w3-hover-green btcontroles"
                                onclick="Adicionar()">
                            Adicionar
                        </button>
                    </div>

                </div>


            </fieldset>
        </form>
    </div>

    <hr />

    <!-- GRID Histórico Boletins -->
    <div class="w3-container">
        <form class="form-horizontal">
            <fieldset>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">
                        <table id="tabela" class="w3-table-all w3-hoverable">
                            <thead>
                                <tr class="w3-grey">
                                    <th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Disciplina</th>
                                    <th>Tipo Avalição</th>
                                    <th>Unidade</th>
                                    <th>Nota</th>
                                    <th>Ano</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="Literal_historico" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
            </fieldset>
        </form>
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
                        <button type="button" class="w3-button w3-round w3-border w3-light-green w3-hover-red" onclick="Estoque_Excluir()">Sim</button>
                    </p>
                    <br />
                </div>
            </form>
            <input type="hidden" id="HiddenID" />
        </div>
    </div>
    <!-- Modal Excluir -->

    <!-- auxiliares -->
    <input id="IDProdutoHidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeBoletins.js"></script>

    <!-- Script Paginação
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script> -->

</body>
</html>
