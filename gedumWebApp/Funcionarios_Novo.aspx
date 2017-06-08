<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Funcionarios_Novo.aspx.cs" Inherits="Funcionarios_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Funcionário - GEDUM</title>
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
            background-image: url("Images/fundo.jpg");
            background-repeat: repeat;
        }
        #results {
            float: right;
            margin: 5px;
            padding: 5px;
            border: 1px solid;
            background: #ccc;
        }
    </style>

</head>
<body>



    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 150px">
        <br />
        <br />
        <br />
        <button class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-user-o" aria-hidden="true"></i>&nbsp;Dados Pessoais</button>
        <button class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo2')"><i class="fa fa-book" aria-hidden="true"></i>&nbsp;Documentos</button>
        <button class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo3')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Histórico</button>
        <hr />
        <div class="w3-center">
            <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-red" onclick="cancelar()"><i class="fa fa-undo"></i>&nbsp;CANCELAR</button>
            <p></p>
            <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-blue" onclick="SalvarRegistro()" id="btSalvar"><i class="fa fa-save"></i>&nbsp;&nbsp;&nbsp;SALVAR&nbsp;&nbsp;&nbsp;&nbsp;</button>
        </div>
    </div>

    <div style="margin-left: 150px">

        <div>
            <header class="w3-container w3-green w3-center w3-padding-small">
                <h4><strong>Novo Funcionário</strong></h4>
            </header>
        </div>



        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">
            <h3><i class="fa fa-user-o" aria-hidden="true"></i>&nbsp;Dados Pessoais</h3>
            <hr />

            <div class="w3-twothird">
                <form class="form-horizontal">

                    <fieldset>

                        <div class="form-group">
                            <label for="input_nome" class="col-md-2 control-label">Nome</label>
                            <div class="col-md-8">
                                <input type="text" class="form-control" id="input_nome">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_apelido" class="col-md-2 control-label">Função</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_apelido">
                            </div>

                            <label for="input_posicao" class="col-md-2 control-label">Setor</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_posicao">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_local" class="col-md-2 control-label">Telefone</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_local">
                            </div>

                            <label for="input_nascimento" class="col-md-2 control-label">Nascimento</label>
                            <div class="col-md-3">
                                <input type="date" class="form-control" id="input_nascimento">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_nacionalidade" class="col-md-2 control-label">Nacionalidade</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_nacionalidade">
                            </div>

                            <label for="input_idioma" class="col-md-2 control-label">Naturalidade</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_idioma">
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>

            <!-- Camera -->
            <div class="w3-third">
                <div id="results"></div>
                <div id="my_camera"></div>

                <div class="row">
                    <label for="filePicker">Carregar Foto:</label><br>
                    <input type="file" id="filePicker">
                </div>
                <input id="Hidden1" name="fotouri" type="hidden" />
            </div>
            <!-- Camera -->

        </div>



        <div id="grupo2" class="w3-container grupo w3-animate-left" style="display: none">
            <h3><i class="fa fa-book" aria-hidden="true"></i>&nbsp;Documentação</h3>
            <hr />
            <form class="form-horizontal">

                <fieldset>

                    <div class="form-group">
                        <label for="input6" class="col-md-2 control-label">RG</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="input_clube">
                        </div>
                    </div>

                    <div class="form-group">

                        <label for="input7" class="col-md-2 control-label">CPF</label>
                        <div class="col-md-3">
                            <input type="text" class="form-control" id="input_inicio">
                        </div>

                        <label for="input8" class="col-md-2 control-label">PIS</label>
                        <div class="col-md-3">
                            <input type="text" class="form-control" id="input_final">
                        </div>

                    </div>

                </fieldset>
            </form>
        </div>

        <div id="grupo3" class="w3-container grupo w3-animate-left" style="display: none">
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Histórico</h3>
            <hr />
            <form class="form-horizontal">
                <fieldset>
                                        
                    <div class="form-group">
                        <label for="input_chute" class="col-md-2 control-label">Observações</label>
                        <div class="col-md-8">
                             <textarea class="form-control" rows="5" id="input_carac"></textarea>
                        </div>                      
                    </div>

                </fieldset>
            </form>
        </div>

    </div>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeFuncionarios_Novo.js"></script>
    <script type="text/javascript" src="Scripts/webcam.js"></script>

</body>
</html>