﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Veiculos_Ficha.aspx.cs" Inherits="Veiculos_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Cadastro de Veículos</title>
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
            <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Gerais</button>
        
        <hr />

    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 - Dados Veículos -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Veículo</h3>
            <hr />

            <div class="w3-rest">
                <form class="form-horizontal">
                    <fieldset>

                        <div class="form-group">
                            <label for="input_modelo" class="col-md-2 control-label">Modelo</label>
                            <div class="col-md-10">
                                <input type="text" class="form-control" id="input_modelo"/>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_placa" class="col-md-2 control-label">Placa</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_placa"/>
                            </div>

                            <label for="input_cor" class="col-md-2 control-label">Cor</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_cor"/>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_kminicial" class="col-md-2 control-label">Km Inicial</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_kminicial" value="0"/>
                            </div>

                            <label for="input_combustivel" class="col-md-2 control-label">Combustível</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_combustivel">
                                    <option value="Gasolina">Gasolina</option>
                                    <option value="Álcool">Álcool</option>
                                    <option value="Diesel">Diesel</option>
                                    <option value="Gás Natural">Gás Natural</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_proprietario" class="col-md-2 control-label">Proprietário</label>
                            <div class="col-md-10">
                                <input type="text" class="form-control" id="input_proprietario"/>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_obs" class="col-md-2 control-label">Observação</label>
                            <div class="col-md-10">
                                <input type="text" class="form-control" id="input_obs"/>
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

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
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
    <script type="text/javascript" src="Scripts/codeVeiculos_Novo.js"></script>

</body>
</html>