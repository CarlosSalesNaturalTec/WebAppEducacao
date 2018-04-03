<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SolicitacoesMatricula_Novo2.aspx.cs" Inherits="SolicitacoesMatricula_Novo2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>GEDUM - Solicitação de Matrícula</title>
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

    <!--******* LATERAL*******-->
    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 180px">
        <div class="w3-padding w3-center">
            <img src="Images/brasaobahiacolorsmall.png" />
        </div>
        <hr />

        <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Pessoais</button>
        <button id="bt2" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo2')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Endereço</button>
        <hr />

    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 - Dados Pessoais -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Solicitação de Matrícula - <asp:Label ID="lbl_inst1" runat="server"></asp:Label> </h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>

                        <div class="form-group">
                            <label for="input_curso" class="col-md-2 control-label">Curso</label>

                            <div class="col-md-9">
                                <select id="input_curso" class="form-control w3-input w3-border w3-round">
                                    <asp:Literal ID="literal_curso" runat="server"></asp:Literal>
                                </select>   
                            </div>
                        </div>                        

                        <div class="form-group">
                            <label for="input_nome" class="col-md-2 control-label">Nome</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_nome">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_nasc" class="col-md-2 control-label">Nascimento</label>
                            <div class="col-md-3">
                                <input type="date" class="form-control" id="input_nasc">
                            </div>
                            <label for="input_civil" class="col-md-2 control-label">Estado Civil</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_civil">
                                    <option value="Solteiro(a)">Solteiro(a)</option>
                                    <option value="Casado(a)">Casado(a)</option>
                                    <option value="Divorciado(a)">Divorciado(a)</option>
                                    <option value="Viúvo(a)">Viúvo(a)</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_pai" class="col-md-2 control-label">Filiação Pai</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_pai">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_mae" class="col-md-2 control-label">Filiação Mãe</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_mae">
                            </div>
                        </div>



                        <div class="form-group">
                            <label for="input_resp" class="col-md-2 control-label">Responsável</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_resp">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_cpfresp" class="col-md-2 control-label">CPF Respons.</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_cpfresp">
                            </div>
                            <label for="input_telresp" class="col-md-2 control-label">TEL. Respons.</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_telresp">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_email" class="col-md-2 control-label">E-mail Responsavel</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_email">
                            </div>
                        </div>


                        <div class="form-group">
                            <label for="input_prof" class="col-md-2 control-label">Naturalidade</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_natural">
                            </div>

                            <label for="input_nacionalid" class="col-md-2 control-label">Nacionalidade</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_nacionalid" value="Brasileira">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_Etnia" class="col-md-2 control-label">Etnia</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_Etnia">
                                    <option value="Branco">Branco</option>
                                    <option value="Negro">Negro</option>
                                    <option value="Pardo">Pardo</option>
                                    <option value="Mulato">Mulato</option>
                                    <option value="Amarelo">Amarelo</option>
                                    <option value="Indígena">Indígena</option>
                                    <option value="Indígena">Quilombola</option>
                                </select>
                            </div>


                        </div>

                        <div class="form-group">
                            <label for="input_Etnia" class="col-md-2 control-label">Deficiente</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_deficiente">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>

                            <label for="input_deficiencia" class="col-md-2 control-label">Tipo Deficiência</label>
                            <div class="col-md-3">
                                <select class="form-control" id="input_deficiencia">
                                    <option value="Nenhuma">Nenhuma</option>
                                    <option value="Física">Física</option>
                                    <option value="Visual">Visual</option>
                                    <option value="Mental">Mental</option>
                                    <option value="Intelectual">Intelectual</option>
                                    <option value="Reabilitado">Reabilitado</option>
                                    <option value="Readaptado">Readaptado</option>
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

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt2()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar
                            </button>

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

        <!-- GRUPO 2- Endereço -->
        <div id="grupo2" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Solicitacão de Matrícula - <asp:Label ID="lbl_inst2" runat="server" ></asp:Label></h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="input_end" class="col-md-2 control-label">Endereço</label>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="input_end">
                                <input type="hidden" class="form-control" id="input_lat">
                                <input type="hidden" class="form-control" id="input_lng">
                            </div>
                            <label for="input_num" class="col-md-1 control-label">Número</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_num">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_end" class="col-md-2 control-label">Bairro</label>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="input_bairro">
                            </div>
                            <label for="input_cep" class="col-md-1 control-label">CEP</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_cep">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_cidade" class="col-md-2 control-label">Cidade</label>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="input_cidade">
                            </div>

                            <label for="input_uf" class="col-md-1 control-label">UF</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_uf" value="BA">
                            </div>

                        </div>

                        <div class="form-group">
                            <label for="input_fixo" class="col-md-2 control-label">Telefone Fixo</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_fixo">
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

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar1()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar
                            </button>


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
                <div class="w3-container">
                    <iframe name="MapFrame" src="MapaAuxiliar.aspx?lat=0&lng=0" width="100%" height="400" frameborder="0" style="border: 0" allowfullscreen></iframe>
                </div>
            </div>
        </div>

    </div>

    <!-- auxiliares -->
    <input id="IDHidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="scripts/SolicitacoesMatricula.js"></script>
    <script type="text/javascript" src="scripts/codeMatriculas_Solicita_Mapa.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDhhdJ8S6LYpsu33sFG26cWSUN3V9Qrorw&libraries=places&callback=initMap" async defer></script>

</body>


</html>
