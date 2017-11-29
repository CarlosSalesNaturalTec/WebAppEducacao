<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Patrimonio_Novo.aspx.cs" Inherits="Patrimonio_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--*******Customização*******-->
    <title>Cadastro de Patrimônio</title>
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

        <!-- GRUPO 1 - Dados Salas -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Gerais - Novo Patrimônio</h3>
            <hr />

            <div class="w3-rest">
                <form class="form-horizontal">
                    <fieldset>

                        <div class="form-group">
                            <label for="input_nome" class="col-md-2 control-label">Descrição</label>
                            <div class="col-md-10">
                                <input type="text" class="form-control" id="input_nome">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_tombo" class="col-md-2 control-label">Tombo</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_tombo">
                            </div>

                            <label for="input_dimens" class="col-md-2 control-label">Tipo de Bem</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_tipo">
                                    <option value="AR CONDICIONADO">AR CONDICIONADO</option>
                                    <option value="ARMÁRIO">ARMÁRIO</option>
                                    <option value="BANDEIRA">BANDEIRA</option>
                                    <option value="BOLA">BOLA</option>
                                    <option value="CADEIRA">CADEIRA</option>
                                    <option value="CARTEIRA">CARTEIRA</option>
                                    <option value="CARTEIRA UNIVERSITÁRIA">CARTEIRA UNIVERSITÁRIA</option>
                                    <option value="COMPUTADOR">COMPUTADOR</option>
                                    <option value="DATASHOW">DATASHOW</option>
                                    <option value="EQUIPAMENTO DE SOM">EQUIPAMENTO DE SOM</option>
                                    <option value="ESTABILIZADOR">ESTABILIZADOR</option>
                                    <option value="FILMADORA">FILMADORA</option>
                                    <option value="MESA">MESA</option>
                                    <option value="MICROFONE">MICROFONE</option>
                                    <option value="MODEM">MODEM</option>
                                    <option value="NOTEBOOK">NOTEBOOK</option>
                                    <option value="QUADRO">QUADRO</option>
                                    <option value="RETROPROJETOR">RETROPROJETOR</option>
                                    <option value="ROTEADOR">ROTEADOR</option>
                                    <option value="TELEFONE">TELEFONE</option>
                                    <option value="TELEVISÃO">TELEVISÃO</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_sit" class="col-md-2 control-label">Situação</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_sit">
                                    <option value="EM USO">EM USO</option>
                                    <option value="EM DESUSO">EM DESUSO</option>
                                    <option value="IMPRESTÁVEL">IMPRESTÁVEL</option>
                                    <option value="OBSOLETO">OBSOLETO</option>
                                </select>
                            </div>

                            <label for="input_valor" class="col-md-2 control-label">Valor do Bem</label>
                            <div class="col-md-4">
                                <input type="number" class="form-control" id="input_valor" value="0">
                            </div>

                        </div>

                        <div class="form-group">
                            <label for="input_incorp_tipo" class="col-md-2 control-label">Tipo Incorporação</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_incorp_tipo">
                                    <option value="AQUISIÇÃO">AQUISIÇÃO</option>
                                    <option value="DOAÇÃO">DOAÇÃO</option>
                                </select>
                            </div>

                            <label for="input_incorp_data" class="col-md-2 control-label">Data Incorporação</label>
                            <div class="col-md-4">
                                <input type="date" class="form-control" id="input_incorp_data">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_nf_num" class="col-md-2 control-label">N° Nota Fiscal</label>
                            <div class="col-md-4">
                                <input type="number" class="form-control" id="input_nf_num">
                            </div>

                            <label for="input_nf_data" class="col-md-2 control-label">Data Nota Fiscal</label>
                            <div class="col-md-4">
                                <input type="date" class="form-control" id="input_nf_data">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_forn" class="col-md-2 control-label">Fornecedor</label>
                            <div class="col-md-10">
                                <input type="text" class="form-control" id="input_forn">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_forn" class="col-md-2 control-label">Sala</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_sala">
                            </div>

                            <label for="input_deprec" class="col-md-2 control-label">Depeciação Anual (%)</label>
                            <div class="col-md-4">
                                <input type="number" class="form-control" id="input_deprec" value="0">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_obs" class="col-md-2 control-label">Observações</label>
                            <div class="col-md-10">
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
    <script type="text/javascript" src="Scripts/codePatrimonio_Novo.js"></script>

</body>
</html>

