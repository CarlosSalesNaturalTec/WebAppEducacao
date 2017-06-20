<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CAD_Instituicao_Novo.aspx.cs" Inherits="CAD_Instituicao_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!--*******Customização*******-->
    <title>Cadastro de Instituição</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <style>
        body {
            background-image: url("images/fundo.jpg");
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
        <hr />
        <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados P.Jurídica</button>
        <button id="bt2" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo2')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Diretoria</button>
        <button id="bt3" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo3')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Estrutura</button>
        <button id="bt4" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo4')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Imagens</button>
        <button id="bt5" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo5')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Usuários</button>
        <button id="bt6" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo6')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Suporte</button>
        <hr />
    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">

            <div class="col-md-9 w3-border w3-padding w3-round">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Pessoa Jurídica - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                        <div class="form-group">
                            <label for="input1" class="col-md-2 control-label">Nome Fantasia</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input1">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input1" class="col-md-2 control-label">Razão Social</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input2">
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
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Cancelar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt2()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <!-- FOTO -->
            <div class="w3-quarter">
                <div id="results"></div>
                <div id="my_camera"></div>
                <!--*******Customização - somente se necessitar de foto ******* 
                <div class="row">
                    <label for="filePicker">Foto ( 200x300pixels - Tam.Máx.:75Kb )</label><br>
                    <input type="file" id="filePicker">
                    
                </div>
                <input id="FotoHidden" name="fotouri" type="hidden" />
                -->
            </div>
            <!-- FOTO -->

        </div>


        <!-- GRUPO 2  -->
        <div id="grupo2" class="w3-container grupo w3-animate-left" style="display: none">
            <div class="col-md-9 w3-border w3-padding w3-round">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;XXXXXX - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-9 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar1()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt3()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <!-- Mapa -->
            <div class="w3-quarter">
                <div id="map"></div>
                <!--*******Customização - somente se necessitar de MAPA *******
                <div class="w3-container">
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d248922.6766195409!2d-38.55767179513302!3d-12.880897633835406!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x716037ca23ca5b3%3A0x1b9fc7912c226698!2sSalvador+-+BA!5e0!3m2!1spt-BR!2sbr!4v1497576846388" width="100%" height="400" frameborder="0" style="border: 0" allowfullscreen></iframe>
                </div>
                -->
            </div>
        </div>


        <!-- GRUPO 3  -->
        <div id="grupo3" class="w3-container grupo w3-animate-left" style="display: none">
            <div class="col-md-9 w3-border w3-padding w3-round">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;XXXXXX - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar2()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt4()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <div class="w3-quarter">
            </div>

        </div>


        <!-- GRUPO 4  -->
        <div id="grupo4" class="w3-container grupo w3-animate-left" style="display: none">
            <div class="col-md-9 w3-border w3-padding w3-round">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;XXXXXX - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar3()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt5()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <div class="w3-quarter">
            </div>
        </div>


        <!-- GRUPO 5 -->
        <div id="grupo5" class="w3-container grupo w3-animate-left" style="display: none">
            <div class="col-md-9 w3-border w3-padding w3-round">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;XXXXXX - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar4()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt6()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar</button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <div class="w3-quarter">
            </div>
        </div>


        <!-- GRUPO 6 -->
        <div id="grupo6" class="w3-container grupo w3-animate-left" style="display: none">
            <div class="col-md-9 w3-border w3-padding w3-round">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;XXXXXX - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar5()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt7()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <div class="w3-quarter">
            </div>
        </div>


        <!-- GRUPO 7 -->
        <div id="grupo7" class="w3-container grupo w3-animate-left" style="display: none">
            <div class="col-md-9 w3-border w3-padding w3-round">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;XXXXXX - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar6()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt8()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <div class="w3-quarter">
            </div>
        </div>


        <!-- GRUPO 8 -->
        <div id="grupo8" class="w3-container grupo w3-animate-left" style="display: none">
            <div class="col-md-9 w3-border w3-padding w3-round">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;XXXXXX - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round ">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar7()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt9()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <div class="w3-quarter">
            </div>
        </div>


        <!-- GRUPO 9 -->
        <div id="grupo9" class="w3-container grupo w3-animate-left" style="display: none">
            <div class="col-md-9 w3-border w3-padding w3-round">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;XXXXXX - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-3"></div>
                    <div class="col-md-9 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar8()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt10()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <div class="w3-quarter">
            </div>
        </div>


        <!-- GRUPO 10 -->
        <div id="grupo10" class="w3-container grupo w3-animate-left" style="display: none">
            <div class="col-md-9 w3-border w3-padding w3-round">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;XXXXXX - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar9()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <div class="w3-quarter">
            </div>
        </div>

    </div>

    <!-- auxiliares -->
    <input id="IDAuxHidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeInstituicao_Novo.js"></script>

    <!--*******Customização somente se for usar mapa*******
    <script type="text/javascript" src="Scripts/codeInstituicao_Mapa.js"></script> 
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&libraries=places&callback=initMap" async defer></script>
    -->

    <!--*******Customização somente se for usar webcam *******
    <script type="text/javascript" src="Scripts/webcam.js"></script>
    -->

</body>
</html>
