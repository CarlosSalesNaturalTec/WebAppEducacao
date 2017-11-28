<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FornecedorAlimentos_Ficha.aspx.cs" Inherits="FornecedorAlimentos_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--*******Customização*******-->
    <title>Cadastro de Fornecedor Alimentos</title>
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
    <!--*******MENU LATERAL - Customização*******-->
    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 180px">
        <div class="w3-padding w3-center">
            <img src="Images/brasaobahiacolorsmall.png" />
        </div>
        <hr />
            <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Gerais</button>
        <hr />

    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 - Dados Fornecedor Alimentos -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">

            <!--*******Customização*******-->
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Gerais - Novo Fornecedor Alimentos</h3>
            <hr />

            <div class="w3-rest">
                <form class="form-horizontal">
                    <fieldset>

                        <div class="form-group">
                            <label for="input_nome" class="col-md-2 control-label">Nome</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_nome">
                            </div>
                        </div>

                        <div class="form-group">

                            <label for="input_cpfcnpj" class="col-md-2 control-label">CPF/CNPJ</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_cpfcnpj">
                            </div>

                            <label for="input_cep" class="col-md-2 control-label">CEP</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_cep">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_rua" class="col-md-2 control-label">Rua</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_rua">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_numero" class="col-md-2 control-label">Numero</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_numero">
                            </div>

                            <label for="input_complemento" class="col-md-2 control-label">Complemento</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_complemento">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_bairro" class="col-md-2 control-label">Bairro</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_bairro">
                            </div>

                            <label for="input_cidade" class="col-md-2 control-label">Cidade</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_cidade">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_uf" class="col-md-2 control-label">Estado</label>
                            <div class="col-md-1">
                                <input type="text" class="form-control" id="input_uf">
                            </div>

                            <label for="input_fone1" class="col-md-2 control-label">Telefone 1</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_fone1">
                            </div>

                            <label for="input_fone2" class="col-md-2 control-label">Telefone 2</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_fone2">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_email" class="col-md-2 control-label">Email</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_email">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_homepage" class="col-md-2 control-label">Home Page</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_homepage">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_obs" class="col-md-2 control-label">Observacao</label>
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
    <input id="IDFornecedorAlimentoHidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeFornecedorAlimentos_Novo.js"></script>

</body>
</html>