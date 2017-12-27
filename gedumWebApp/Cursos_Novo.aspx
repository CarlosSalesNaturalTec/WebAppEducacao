﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cursos_Novo.aspx.cs" Inherits="Cursos_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Cursos</title>
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

        <!-- GRUPO 1 - Dados Cursos -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">

            <div class="w3-threequarter">
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Novo Curso</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <hr />

                        <div class="form-group">
                            <label for="input_nome" class="col-md-2 control-label">Nome</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_nome">
                            </div>
                        </div>

                        <div class="form-group">

                            <label for="input_sigla" class="col-md-2 control-label">Sigla</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_sigla">
                            </div>

                            <label for="input_equivalencia" class="col-md-2 control-label">Equivalência</label>
                            <div class="col-md-5">
                                <select class="form-control" id="input_equivalencia">
                                    <option value="1a. SÉRIE ORGANIZAÇÃO SERIADA">1a. SÉRIE ORGANIZAÇÃO SERIADA</option>
                                    <option value="2a. SÉRIE ORGANIZAÇÃO SERIADA">2a. SÉRIE ORGANIZAÇÃO SERIADA</option>
                                    <option value="3a. SÉRIE ORGANIZAÇÃO SERIADA">3a. SÉRIE ORGANIZAÇÃO SERIADA</option>
                                    <option value="4a. SÉRIE ORGANIZAÇÃO SERIADA">4a. SÉRIE ORGANIZAÇÃO SERIADA</option>
                                    <option value="5a. SÉRIE ORGANIZAÇÃO SERIADA">5a. SÉRIE ORGANIZAÇÃO SERIADA</option>
                                    <option value="6a. SÉRIE ORGANIZAÇÃO SERIADA">6a. SÉRIE ORGANIZAÇÃO SERIADA</option>
                                    <option value="7a. SÉRIE ORGANIZAÇÃO SERIADA">7a. SÉRIE ORGANIZAÇÃO SERIADA</option>
                                    <option value="8a. SÉRIE ORGANIZAÇÃO SERIADA">8a. SÉRIE ORGANIZAÇÃO SERIADA</option>
                                </select>
                            </div>

                        </div>

                        <div class="form-group">

                            <label for="input_modalidade" class="col-md-2 control-label">Modalidade Educacional</label>
                            <div class="col-md-9">
                                <select class="form-control" id="input_modalidade">
                                    <option value="ENSINO FUNDAMENTAL II">ENSINO FUNDAMENTAL II</option>
                                    <option value="ENSINO FUNDAMENTAL I">ENSINO FUNDAMENTAL I</option>
                                    <option value="EDUCAÇÃO INFANFIL">EDUCAÇÃO INFANFIL</option>
                                    <option value="EDUCAÇÃO DE JOVENS E ADULTOS">EDUCAÇÃO DE JOVENS E ADULTOS</option>
                                    <option value="CRECHE">CRECHE</option>
                                    <option value="PRÉ ESCOLA">PRÉ ESCOLA</option>
                                    <option value="EDUCAÇÃO ESPECIAL">EDUCAÇÃO ESPECIAL</option>
                                    <option value="ENSINO REGULAR">ENSINO REGULAR</option>
                                </select>
                            </div>
                        </div>


                        <div class="form-group">
                            <label for="input_faixaetaria_ini" class="col-md-2 control-label">Faixa Etária de</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_faixaetaria_ini">
                            </div>

                            <label for="input_faixaetaria_fim" class="col-md-1 control-label">Até</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_faixaetaria_fim">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_anterior" class="col-md-2 control-label">Curso Anterior</label>
                            <div class="col-md-3">
                                <select class="form-control" id="input_anterior">
                                    <option value="1a. SÉRIE">1a. SÉRIE</option>
                                    <option value="1° ANO">1° ANO</option>
                                    <option value="2a. SÉRIE">2a. SÉRIE</option>
                                    <option value="2° ANO">2° ANO</option>
                                    <option value="3a. SÉRIE">3a. SÉRIE</option>
                                    <option value="3° ANO">3° ANO</option>
                                    <option value="4a. SÉRIE">4a. SÉRIE</option>
                                    <option value="4° ANO">4° ANO</option>
                                    <option value="5a. SÉRIE">5a. SÉRIE</option>
                                    <option value="5° ANO">5° ANO</option>
                                    <option value="6a. SÉRIE">6a. SÉRIE</option>
                                    <option value="6° ANO">6° ANO</option>
                                    <option value="7a. SÉRIE">7a. SÉRIE</option>
                                    <option value="8a. SÉRIE">8a. SÉRIE</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_obs" class="col-md-2 control-label">Observ.:</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_obs">
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
    <script type="text/javascript" src="Scripts/codeCursos_Novo.js"></script>

</body>
</html>
