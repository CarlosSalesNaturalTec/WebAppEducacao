<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Matriculas_Solicita_Ficha.aspx.cs" Inherits="Matriculas_Solicita_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ficha de Solicitação de Matrícula</title>
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
    <!--*******MENU LATERAL *******-->
    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 180px">
        <div class="w3-padding w3-center">
            <img src="Images/brasaobahiacolorsmall.png" />
        </div>
        <hr />

        <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Pessoais</button>
        <button id="bt2" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo2')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Endereço</button>
        <button id="bt3" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo3')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Documentação</button>
        <button id="bt4" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo4')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados de Saúde</button>
        <button id="bt5" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo5')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Fardamento</button>
        <button id="bt6" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo6')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;CONFIRMAÇÃO</button>
        <hr />

    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 - Dados Pessoais -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Solicitação de Matrícula - Dados Pessoais</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>

                        <div class="form-group">
                            <label for="input_curso" class="col-md-2 control-label">Curso</label>
                            <div class="col-md-9">
                                <select class="w3-select w3-border" id="input_curso">
                                    <asp:Literal ID="Literal_Cursos" runat="server"></asp:Literal>
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
                            <label for="input_civil" class="col-md-3 control-label">Estado Civil</label>
                            <div class="col-md-3">
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
                                    <option value="Não Informada">Não Informada</option>
                                    <option value="Branco">Branco</option>
                                    <option value="Negro">Negro</option>
                                    <option value="Pardo">Pardo</option>
                                    <option value="Mulato">Mulato</option>
                                    <option value="Amarelo">Amarelo</option>
                                    <option value="Indígena">Indígena</option>
                                    <option value="Indígena">Quilombola</option>
                                </select>
                            </div>

                            <label for="input_tiposangue" class="col-md-2 control-label">Tipo Sanguínio</label>
                            <div class="col-md-3">
                                <select class="form-control" id="input_tiposangue">
                                    <option value="Não Informado">Não Informado</option>
                                    <option value="O+">O+</option>
                                    <option value="O-">O-</option>
                                    <option value="A+">A+</option>
                                    <option value="A-">A-</option>
                                    <option value="B+">B+</option>
                                    <option value="B-">B-</option>
                                    <option value="AB+">AB+</option>
                                    <option value="AB-">AB-</option>
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
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt2()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Salvar&nbsp;&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <!-- Camera -->
            <div class="w3-quarter">
                <div id="results"></div>
                <div id="my_camera"></div>
                <div class="row">
                    <label for="filePicker">Foto ( 200x300pixels - Tam.Máx.:75Kb )</label><br>
                    <input type="file" id="filePicker">
                </div>
                <div class="row">
                    <label for="btwebcam">WebCam:</label><br>
                    <input id="btwebcam" type="button" value="Ativar WebCam" onclick="AtivarWebCam()">
                    <input type="button" value="Capturar imagem WebCam" onclick="take_snapshot()">
                </div>
                <input id="Hidden1" name="fotouri" type="hidden" />
            </div>
            <!-- Camera -->

        </div>


        <!-- GRUPO 2 - Endereço -->
        <div id="grupo2" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Endereço</h3>
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
                            <label for="input_celular1" class="col-md-2 control-label">Celular 1</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_celular1">
                            </div>
                            <label for="input_celular2" class="col-md-1 control-label">Cel. 2</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_celular2">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_fixo" class="col-md-2 control-label">Telefone Fixo</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_fixo">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_email" class="col-md-2 control-label">E-mail</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_email">
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

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar1()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt3()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Salvar&nbsp;
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


        <!-- GRUPO 3 - Documentação -->
        <div id="grupo3" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Documentação</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="input_pis" class="col-md-2 control-label">PIS</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_pis">
                            </div>
                            <label for="input_cpf" class="col-md-2 control-label">CPF</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_cpf">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_RG" class="col-md-2 control-label">RG</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_RG">
                            </div>
                            <label for="input_RGExped" class="col-md-1 control-label">Órgão</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_RGExped">
                            </div>
                            <label for="input_RGEmiss" class="col-md-1 control-label">Emissão</label>
                            <div class="col-md-3">
                                <input type="date" class="form-control" id="input_RGEmiss">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_CTPS" class="col-md-2 control-label">CTPS</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_CTPS">
                            </div>
                            <label for="input_CTPSSerie" class="col-md-1 control-label">Série</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_CTPSSerie">
                            </div>
                            <label for="input_CTPSEmiss" class="col-md-1 control-label">Emissão</label>
                            <div class="col-md-3">
                                <input type="date" class="form-control" id="input_CTPSEmiss">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_Titulo" class="col-md-2 control-label">Titulo</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_Titulo">
                            </div>
                            <label for="input_Zona" class="col-md-1 control-label">Zona</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_Zona">
                            </div>
                            <label for="input_Secao" class="col-md-1 control-label">Seção</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_Secao">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_CNH" class="col-md-2 control-label">Habilitação</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_CNH">
                            </div>
                            <label for="input_Passaporte" class="col-md-2 control-label">Passaporte</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_Passaporte">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_CERT" class="col-md-2 control-label">Certidão Nasc.</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_CERT">
                            </div>
                        </div>

                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar2()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt4()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Salvar&nbsp;
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


        <!-- GRUPO 4 - Dados de Saúde -->
        <div id="grupo4" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados de Saúde</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="input_Alergia" class="col-md-3 control-label">Alergias</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_Alergia">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input_alergiaMed" class="col-md-3 control-label">Alergia Medicamentos</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_alergiaMed">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_conta" class="col-md-3 control-label">Em caso de acidente avisar:</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_avisar">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_SUS" class="col-md-3 control-label">Cartão SUS</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_SUS">
                            </div>
                        </div>

                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-3"></div>
                    <div class="col-md-9 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar3()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt5()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Salvar&nbsp;
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


        <!-- GRUPO 5 - Fardamento -->
        <div id="grupo5" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Fardamento</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>

                        <div class="form-group">
                            <label for="input_camisa" class="col-md-2 control-label">Camisa N°:</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_camisa">
                            </div>
                            <label for="input_camiseta" class="col-md-2 control-label">Camiseta N°:</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_camiseta">
                            </div>
                            <label for="input_calca" class="col-md-2 control-label">Calça N°:</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_calca">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_sapato" class="col-md-2 control-label">Sapato N°:</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_sapato">
                            </div>
                            <label for="input_bota" class="col-md-2 control-label">Bota N°:</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_bota">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_obs" class="col-md-2 control-label">Observ.:</label>
                            <div class="col-md-10">
                                <input type="text" class="form-control" id="input_obs">
                            </div>
                        </div>

                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar4()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt6()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Salvar&nbsp;
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


        <!-- GRUPO 6 - Confirmação -->
        <div id="grupo6" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Confirmação de Matrícula : <asp:Literal ID="Literal_nome" runat="server"></asp:Literal> </h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>

                        <div class="form-group">

                            <label for="input_Data_conf" class="col-md-2 control-label">Data Confirmação</label>
                            <div class="col-md-3">
                                <input type="date" class="form-control" id="input_Data_conf" disabled>
                            </div>

                            <label for="input_matricula" class="col-md-2 control-label">Número Matrícula</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_matricula" disabled>
                            </div>

                            <input type="hidden" class="form-control" id="input_status">

                        </div>

                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round">
                        <p>
                            <button id="bt_sair" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button id="btMat_Param" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="Confirma_matricula();">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;OBTER MATRÍCULA&nbsp;
                            </button>

                            <button id ="btSalvar2" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Salvar&nbsp;
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
    <input id="IDHidden" type="hidden" />
    <input id="ID_Inst_Hidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeMatriculas_Solicita_Novo.js"></script>
    <script type="text/javascript" src="Scripts/webcam.js"></script>
    <script type="text/javascript" src="Scripts/codeMatriculas_Solicita_Mapa.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDhhdJ8S6LYpsu33sFG26cWSUN3V9Qrorw&libraries=places&callback=initMap" async defer></script>

</body>
</html>
