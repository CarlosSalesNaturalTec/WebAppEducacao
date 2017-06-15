<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Funcionarios_Novo.aspx.cs" Inherits="Funcionarios_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Funcionário</title>  <!--*******Customização*******-->
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

    <!--*******MENU LATERAL - Customização*******-->
    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 180px">
        <br /><br /><br />

        <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Pessoais</button>
        <button id="bt2" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo2')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Documentação</button>
        <button id="bt4" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo3')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dependentes</button>        
        <button id="bt5" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo4')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Benefícios</button>
        <button id="bt6" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo5')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Situação</button>
        <button id="bt7" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo6')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Carga Horária</button>
        <button id="bt8" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo7')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Bancários</button>
        <button id="bt9" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo8')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados de Saúde</button>

        <hr />
        <div class="w3-center">
            <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-red" onclick="cancelar()"><i class="fa fa-undo"></i>&nbsp;CANCELAR</button>
            <p></p>
            <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-blue" onclick="SalvarRegistro()" id="btSalvar"><i class="fa fa-save"></i>&nbsp;&nbsp;&nbsp;SALVAR&nbsp;&nbsp;&nbsp;&nbsp;</button>
            <p></p>
            <div id="divhidden" class="w3-container w3-padding w3-center" style="display: none">
                <i class="fa fa-cog fa-spin fa-2x fa-fw"></i>
            </div>
        </div>
    </div>

    <div style="margin-left: 180px">

        <div>
            <header class="w3-container w3-green w3-center w3-padding-small">
                <h4><strong>Novo Funcionário</strong></h4>  <!--*******Customização*******-->
            </header>
        </div>


        <!-- GRUPO 1 -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Pessoais</h3> <!--*******Customização*******-->
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

                    </fieldset>
                </form>
                <div>
                    <div class="col-md-2"></div>
                    <div class="col-md-2">
                        <button class="w3-btn w3-light-green w3-hover-green" onclick="classeBt2()">AVANÇAR</button>
                    </div>
                </div>


            </div>

            <!-- Camera -->
            <div class="w3-third">
                <div id="results"></div>
                <div id="my_camera"></div>

                <div class="row">
                    <label for="filePicker">Foto ( 200x300pixels - Tam.Máx.:75Kb )</label><br>
                    <input type="file" id="filePicker">
                </div>

                <input id="Hidden1" name="fotouri" type="hidden" />

            </div>
            <!-- Camera -->

        </div>


        <!-- GRUPO 2 -->
        <div id="grupo2" class="w3-container grupo w3-animate-left" style="display: none">
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Documentação</h3> <!--*******Customização*******-->
            <hr />
            <form class="form-horizontal">

                <fieldset>

                
                </fieldset>
            </form>

            <div>
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="btvoltar1()">VOLTAR</button>
                </div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="classeBt3()">AVANÇAR</button>
                </div>
            </div>
        </div>


        <!-- GRUPO 3-->
        <div id="grupo3" class="w3-container grupo w3-animate-left" style="display: none">
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dependentes</h3> <!--*******Customização*******-->
            <hr />
            <form class="form-horizontal">
                <fieldset>
                </fieldset>
            </form>

            <div>
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="btvoltar2()">VOLTAR</button>
                </div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="classeBt4()">AVANÇAR</button>
                </div>
            </div>

        </div>


         <!-- GRUPO 4-->
        <div id="grupo4" class="w3-container grupo w3-animate-left" style="display: none">
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;XXX</h3> <!--*******Customização*******-->
            <hr />
            <form class="form-horizontal">
                <fieldset>

                </fieldset>
            </form>

            <div>
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="btvoltar3()">VOLTAR</button>
                </div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="classeBt5()">AVANÇAR</button>
                </div>
            </div>
        </div>


        <!-- GRUPO 5-->
        <div id="grupo5" class="w3-container grupo w3-animate-left" style="display: none">
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;xxxx</h3> <!--*******Customização*******-->
            <hr />
            <form class="form-horizontal">
                <fieldset>

                </fieldset>
            </form>
            <div>
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="btvoltar4()">VOLTAR</button>
                </div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="classeBt6()">AVANÇAR</button>
                </div>
            </div>
        </div>


        <!-- GRUPO 6-->
        <div id="grupo6" class="w3-container grupo w3-animate-left" style="display: none">
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;xxxx</h3> <!--*******Customização*******-->
            <hr />
            <form class="form-horizontal">
                <fieldset>

                </fieldset>
            </form>
            <div>
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="btvoltar5()">VOLTAR</button>
                </div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="classeBt7()">AVANÇAR</button>
                </div>
            </div>
        </div>


        <!-- GRUPO 7-->
        <div id="grupo7" class="w3-container grupo w3-animate-left" style="display: none">
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;xxxx</h3> <!--*******Customização*******-->
            <hr />
            <form class="form-horizontal">
                <fieldset>

                </fieldset>
            </form>
            <div>
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="btvoltar6()">VOLTAR</button>
                </div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="classeBt8()">AVANÇAR</button>
                </div>
            </div>
        </div>


        <!-- GRUPO 8-->
        <div id="grupo8" class="w3-container grupo w3-animate-left" style="display: none">
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;xxxx</h3> <!--*******Customização*******-->
            <hr />
            <form class="form-horizontal">
                <fieldset>

                </fieldset>
            </form>
            <div>
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-green w3-hover-green" onclick="btvoltar7()">VOLTAR</button>
                </div>
                <div class="col-md-1">
                    <button id="btConcluir" class="w3-btn w3-light-green w3-hover-green" onclick="SalvarRegistro()">CONCLUIR</button>
                </div>
            </div>
        </div>


    </div>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeFuncionarios_Novo.js"></script>
    <script type="text/javascript" src="Scripts/webcam.js"></script>

</body>
</html>
