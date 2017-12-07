﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receitas_Ficha.aspx.cs" Inherits="Receitas_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Cadastro de Receita</title>
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
    <!--*******MENU LATERAL*******-->
    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 180px">
        <div class="w3-padding w3-center">
            <img src="Images/brasaobahiacolorsmall.png" />
        </div>
        <hr />
            <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Gerais</button>
            <button id="bt2" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo2')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ingrediente</button>
        <hr />

    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 - Dados Receitas -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Receita</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>

                        <div class="form-group">
                            <label for="input_nome" class="col-md-2 control-label">Nome</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_nome">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_modo_preparo" class="col-md-2 control-label">Modo de Preparo</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_modo_preparo">
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
        

        <!-- GRUPO 2 Ingredientes --> 
        <div id="grupo2" class="w3-container grupo w3-animate-left" style="display: none">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
           
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ingredientes</h3>
            </div>

            <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
                <form class="form-horizontal">
                    <fieldset>

                        <br /> 

                        <div class="form-group">
                            
                            <label for="input_ingrediente" class="col-md-2 control-label">Ingrediente</label>
                            <div class="col-md-9">
                                <asp:Literal ID="Literal_Produto" runat="server"></asp:Literal>
                            </div>
                        </div>                            


                        <div class="form-group">
                            <label for="input_qtde" class="col-md-2 control-label">Quantidade</label>
                            <div class="col-md-2">
                                <input type="number" id="input_qtde" class="w3-input w3-border w3-round"/>
                            </div>

                            <label for="input_und" class="col-md-2 control-label">Unidade</label>
                            <div class="col-md-3">
                                <input type="text" id="input_und" class="w3-input w3-border w3-round"/>
                            </div>

                            <div class="col-md-2">
                                <button type="button" class="w3-btn w3-border w3-round w3-light-green w3-hover-green"
                                    onclick="SalvarItemRegistro()">
                                    <i class="fa fa-plus"></i>&nbsp;Adicionar</button>
                            </div>
                        </div>


                        <!-- GRID Ingredientes -->
                        <div class="form-group">
                            <div class="col-md-1"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table id="MyTable" class="w3-table-all w3-hoverable">
                                    <thead>
                                        <tr class="w3-grey">
                                            <th>Código</th>
                                            <th>Produto</th>
                                            <th>Qtde</th>
                                            <th>Und</th>
                                        </tr>
                                    </thead>
                                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                </table>
                            </div>
                        </div>
                        <!-- GRID Ingredientes -->

                    </fieldset>
                </form>
            </div>

            <!-- Botões Controle -->
            <div class="col-md-9 w3-border w3-round w3-light-gray w3-padding" style="margin-top: 10px">
                <br />
                <div class="col-md-2"></div>
                <p>
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar1()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt3()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->
        </div>

    </div>

    <!-- auxiliares -->
    <input id="IDHidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeReceitas_Novo.js"></script>

</body>
</html>