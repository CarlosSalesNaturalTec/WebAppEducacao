<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Funcionarios_Novo.aspx.cs" Inherits="Funcionarios_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--*******Customização*******-->
    <title>Cadastro de Funcionário</title>
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
    <!--*******MENU LATERAL - Customização*******-->
    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 180px">
        <div class="w3-padding w3-center">
            <img src="Images/brasaobahiacolorsmall.png" />
        </div>
        <hr />

        <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Pessoais</button>
        <button id="bt2" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo2')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Endereço</button>
        <button id="bt3" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo3')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Documentação</button>
        <button id="bt4" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo4')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dependentes</button>
        <button id="bt5" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo5')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Benefícios</button>
        <button id="bt6" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo6')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Situação</button>
        <button id="bt7" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo7')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Carga Horária</button>
        <button id="bt8" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo8')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Bancários</button>
        <button id="bt9" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo9')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados de Saúde</button>
        <hr />

    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 - Dados Pessoais -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">

            <!--*******Customização*******-->
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Pessoais - Novo Funcionário</h3>
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
                            <label for="input_prof" class="col-md-2 control-label">Profissão</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_prof">
                            </div>

                            <label for="input_nasc" class="col-md-2 control-label">Nascimento</label>
                            <div class="col-md-3">
                                <input type="date" class="form-control" id="input_nasc">
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
                            <label for="input_prof" class="col-md-2 control-label">Naturalidade</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_natural">
                            </div>

                            <label for="input_nacionalid" class="col-md-2 control-label">Nacionalidade</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_nacionalid">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_civil" class="col-md-2 control-label">Estado Civil</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_civil">
                                    <option value="Solteiro(a)">Solteiro(a)</option>
                                    <option value="Casado(a)">Casado(a)</option>
                                    <option value="Divorciado(a)">Divorciado(a)</option>
                                    <option value="Viúvo(a)">Viúvo(a)</option>
                                </select>
                            </div>

                            <label for="input_escolaridade" class="col-md-2 control-label">Escolaridade</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_escolaridade">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_Etnia" class="col-md-2 control-label">Etnia</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_Etnia">
                            </div>

                            <label for="input_tiposangue" class="col-md-2 control-label">Tipo Sanguínio</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_tiposangue">
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

            <!-- Camera -->
            <div class="w3-quarter">
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


        <!-- GRUPO 2 - Endereço -->
        <div id="grupo2" class="w3-container grupo w3-animate-left" style="display: none">

            <!--*******Customização*******-->
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Endereço - Novo Funcionário</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="input_end" class="col-md-2 control-label">Endereço</label>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="input_end">
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
                            <label for="input_uf" class="col-md-2 control-label">UF</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_uf">
                            </div>
                            <label for="input_cidade" class="col-md-1 control-label">Cidade</label>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="input_cidade">
                            </div>

                        </div>

                        <div class="form-group">
                            <label for="input_celular" class="col-md-2 control-label">Telefones</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_telefones">
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

            <div class="w3-quarter">
                <div id="map"></div>
                <div class="w3-container">
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d248922.6766195409!2d-38.55767179513302!3d-12.880897633835406!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x716037ca23ca5b3%3A0x1b9fc7912c226698!2sSalvador+-+BA!5e0!3m2!1spt-BR!2sbr!4v1497576846388" width="100%" height="400" frameborder="0" style="border: 0" allowfullscreen></iframe>
                </div>
            </div>
        </div>


        <!-- GRUPO 3 - Documentação -->
        <div id="grupo3" class="w3-container grupo w3-animate-left" style="display: none">

            <!--*******Customização*******-->
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Documentação - Novo Funcionário</h3>
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


        <!-- GRUPO 4 - Dependentes -->
        <div id="grupo4" class="w3-container grupo w3-animate-left" style="display: none">
            <!--*******Customização*******-->
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dependentes - Novo Funcionário</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="input_DEPNome" class="col-md-2 control-label">Nome</label>
                            <div class="col-md-10">
                                <input type="text" class="form-control" id="input_DEPNome">
                            </div>

                        </div>

                        <div class="form-group">
                            <label for="input_DEPparent" class="col-md-2 control-label">Parentesco</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_DEPparent">
                            </div>
                            <label for="input_DEPNasc" class="col-md-2 control-label">Nascimento</label>
                            <div class="col-md-3">
                                <input type="date" class="form-control" id="input_DEPNasc">
                            </div>
                            <div class="col-md-2">
                                <button class="w3-btn w3-border w3-round w3-hover-green"><i class="fa fa-plus"></i>&nbsp;Adicionar</button>
                            </div>
                        </div>


                        <!-- GRID Dependentes -->
                        <div class="form-group">
                            <div class="col-md-2"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table class="w3-table-all w3-hoverable">
                                    <thead>
                                        <tr class="w3-grey">
                                            <th>Nome</th>
                                            <th>Parentesco</th>
                                            <th>Nascimento</th>
                                        </tr>
                                    </thead>
                                    <tr>
                                        <td>-</td>
                                        <td>-</td>
                                        <td>-</td>
                                    </tr>
                                    <tr>
                                        <td>-</td>
                                        <td>-</td>
                                        <td>-</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <!-- GRID Dependentes -->

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


        <!-- GRUPO 5 - Benefícios-->
        <div id="grupo5" class="w3-container grupo w3-animate-left" style="display: none">

            <!--*******Customização*******-->
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Benefícios - Novo Funcionário</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="input_BEnefNome" class="col-md-2 control-label">Benefício</label>
                            <div class="col-md-10">
                                <input type="text" class="form-control" id="input_BEnefNome">
                            </div>

                        </div>

                        <div class="form-group">
                            <label for="input_BenefSituac" class="col-md-2 control-label">Situação</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_BenefSituac">
                            </div>
                            <label for="input_BenefInicio" class="col-md-2 control-label">Inicio</label>
                            <div class="col-md-3">
                                <input type="date" class="form-control" id="input_BenefInicio">
                            </div>
                            <div class="col-md-2">
                                <button class="w3-btn w3-border w3-round w3-hover-green"><i class="fa fa-plus"></i>&nbsp;Adicionar</button>
                            </div>
                        </div>

                        <!-- GRID Beneficios -->
                        <div class="form-group">
                            <div class="col-md-2"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table class="w3-table-all w3-hoverable">
                                    <thead>
                                        <tr class="w3-grey">
                                            <th>Benefício</th>
                                            <th>Situação</th>
                                            <th>Início</th>
                                        </tr>
                                    </thead>
                                    <tr>
                                        <td>-</td>
                                        <td>-</td>
                                        <td>-</td>
                                    </tr>
                                    <tr>
                                        <td>-</td>
                                        <td>-</td>
                                        <td>-</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <!-- GRID Beneficios-->

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


        <!-- GRUPO 6 - Situação -->
        <div id="grupo6" class="w3-container grupo w3-animate-left" style="display: none">
            <!--*******Customização*******-->
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Situação - Novo Funcionário</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="input_situac" class="col-md-2 control-label">Situação</label>
                            <div class="col-md-3">
                                <select class="form-control" id="input_situac">
                                    <option value="Funcionário Público">Funcionário Público</option>
                                    <option value="REDA">REDA</option>
                                    <option value="Cargo de Comissionado">Cargo de Comissionado</option>
                                    <option value="Outros">Outros</option>
                                </select>
                            </div>
                            <label for="input_qual" class="col-md-2 control-label">Outros, qual</label>
                            <div class="col-md-5">
                                <input type="text" class="form-control" id="input_qual">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input_fliadoSind" class="col-md-2 control-label">Filiado Sindicato</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_fliadoSind">
                                    <option value="Sim">Sim</option>
                                    <option value="Não">Não</option>
                                </select>
                            </div>
                            <label for="input_Sindqual" class="col-md-2 control-label">Qual</label>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="input_Sindqual">
                            </div>
                        </div>
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-9 w3-border w3-padding w3-round w3-light-gray">
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


        <!-- GRUPO 7 - Carga Horária-->
        <div id="grupo7" class="w3-container grupo w3-animate-left" style="display: none">
            <!--*******Customização*******-->
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Carga Horária - Novo Funcionário</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <!-- GRID Carga Horária -->
                        <div class="form-group">
                            <div class="col-md-2"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table class="w3-table-all w3-hoverable">
                                    <thead>
                                        <tr class="w3-grey">
                                            <th>Dia Semana</th>
                                            <th>Turno</th>
                                            <th>Entrada</th>
                                            <th>Saida</th>
                                            <th>Descanso</th>
                                        </tr>
                                    </thead>
                                    <tr>
                                        <td>-</td>
                                        <td>-</td>
                                        <td>-</td>
                                        <td>-</td>
                                        <td>-</td>
                                    </tr>
                                    <tr>
                                        <td>-</td>
                                        <td>-</td>
                                        <td>-</td>
                                        <td>-</td>
                                        <td>-</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <!-- GRID Carga Horária -->
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-9 w3-border w3-padding w3-round">
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


        <!-- GRUPO 8 - Dados Bancários -->
        <div id="grupo8" class="w3-container grupo w3-animate-left" style="display: none">
            <!--*******Customização*******-->
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Bancários - Novo Funcionário</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="input_banco" class="col-md-2 control-label">Banco</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_banco">
                            </div>
                            <label for="input_agencia" class="col-md-2 control-label">Agência</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_agencia">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_conta" class="col-md-2 control-label">Conta</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_conta">
                            </div>
                            <label for="input_contaTipo" class="col-md-2 control-label">Tipo</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_contaTipo">
                                    <option value="Corrente">Corrente</option>
                                    <option value="Poupança">Poupança</option>
                                    <option value="Salário">Salário</option>
                                </select>
                            </div>
                        </div>
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


        <!-- GRUPO 9 - Dados de Saúde -->
        <div id="grupo9" class="w3-container grupo w3-animate-left" style="display: none">

            <!--*******Customização*******-->
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados de Saúde - Novo Funcionário</h3>
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

                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-3"></div>
                    <div class="col-md-9 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar8()">
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

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeFuncionarios_Novo.js"></script>
    <script type="text/javascript" src="Scripts/webcam.js"></script>
    <script type="text/javascript" src="Scripts/codeFuncionarios_Mapa.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&libraries=places&callback=initMap" async defer></script>

</body>
</html>
