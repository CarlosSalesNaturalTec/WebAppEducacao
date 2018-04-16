<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Avaliacao_Novo.aspx.cs" Inherits="Avaliacao_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Cadastro de Avaliações</title>
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
    </style>

</head>
<body>
    <!--*******MENU LATERAL *******-->
    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 180px">
        <div class="w3-padding w3-center">
            <img src="Images/brasaobahiacolorsmall.png" />
        </div>
        <hr />
        <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Avaliação</button>
        <hr />

    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 - Dados Avaliacao -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">

            <div class="w3-threequarter">
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Nova Avaliacão</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <hr />

                        <div class="form-group">
                            <label for="input-disciplina" class="col-md-2 control-label">Disciplina</label>
                            <div class="col-md-5">
                                <select class="form-control" id="input-disciplina">
                                    <asp:Literal ID="Literal_disciplina" runat="server"></asp:Literal>

                                </select>
                            </div>

                        </div>

                        <div class="form-group">
                            <label for="input-turma" class="col-md-2 control-label">Turma</label>
                            <div class="col-md-5">
                                <select class="form-control" id="input-turma">
                                    <asp:Literal ID="Literal_turma" runat="server"></asp:Literal>

                                </select>
                            </div>

                        </div>

                        <div class="form-group">

                            <label for="input-tipo" class="col-md-2 control-label">Tipo Ava.</label>
                            <div class="col-md-5">
                                <select class="form-control" id="input-tipo">
                                    <option value=""> </option>
                                    <option value="PROVA">PROVA</option>
                                    <option value="TESTE">TESTE</option>
                                    <option value="TRABALHO INDIVIDUAL">TRABALHO INDIVIDUAL</option>
                                    <option value="TRABALHO EM GRUPO">TRABALHO EM GRUPO</option>
                                    <option value="PROVA FINAL">PROVA FINAL</option>
                                    <option value="RECUPERAÇÃO">RECUPERAÇÃO</option>
                                </select>
                            </div>
                        </div>


                        <div class="form-group">

                            <label for="input-periodo" class="col-md-2 control-label">Periodo</label>
                            <div class="col-md-5">
                                <select class="form-control" id="input-periodo">
                                      <asp:Literal ID="Literal_periodo" runat="server"></asp:Literal>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">

                            <label for="input_dataAv" class="col-md-2 control-label">Data</label>
                            <div class="col-md-3">
                                <input type="date" class="form-control" id="input_dataAv">
                            </div>
                        </div>
                        
                     <div class="form-group">

                            <label for="input-nota" class="col-md-2 control-label">Nota Máxima</label>
                            <div class="col-md-2">
                                <input type="number" class="form-control" id="input-nota" value="10">
                            </div>
                        </div>
                        
                        
                       
            
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-9 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

        </div>
    </div>

    <!-- auxiliares -->
    <input id="IDInstHidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeAvaliacao_Novo.js"></script>

</body>
</html>

