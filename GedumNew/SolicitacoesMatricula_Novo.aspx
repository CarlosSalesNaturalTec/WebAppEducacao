<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SolicitacoesMatricula_Novo.aspx.cs" Inherits="SolicitacoesMatricula_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>GEDUM - Painel de Controle</title>
    <meta charset="utf-8" />
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
            background-image: url("img/fundo.jpg");
            background-repeat: repeat;
        }
    </style>


</head>

<body>

    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 180px">
        <div class="w3-padding w3-center">
            <img src="Images/brasaobahiacolorsmall.png" />
        </div>
        <hr />

    </div>


    <div style="margin-left: 180px">

        <!-- Instituição -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Solicitação de Matrícula</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="select_inst" class="col-md-2 control-label">Instituicão</label>
                            <div class="col-md-7">
                                <select id="select_inst" class="w3-input w3-border w3-round">
                                    <asp:Literal ID="literal_inst" runat="server"></asp:Literal>
                                </select>
                            </div>
                        </div>
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-9 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="voltar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair
                            </button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles " onclick="avancar()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar
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
    <input id="IDHidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="scripts/SolicitacoesMatricula.js"></script>

</body>


</html>

