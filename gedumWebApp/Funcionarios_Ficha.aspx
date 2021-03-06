﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Funcionarios_Ficha.aspx.cs" Inherits="Funcionarios_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <title>Cadastro de Funcionário</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
   
     <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <style>
        body {
            background-image: url("Images/fundo.jpg");
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

        #result_Digitaliza {
            margin: 5px;
            padding: 5px;
        }
    </style>

</head>
<body>
    <!--*******MENU LATERAL*******-->
    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 180px">
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
        <button id="bt10" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo10')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Fardamento</button>
        <button id="bt11" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo11')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Digitalizações</button>
        <button id="bt12" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo12')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Gratificações</button>
        <button id="bt13" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo13')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Formação</button>
        <hr />

    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 - Dados Pessoais -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">
            
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Dados Pessoais</h3>
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
                            <label for="input_sexo" class="col-md-2 control-label">Sexo</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_sexo">
                                    <option value="Masculino">Masculino</option>
                                    <option value="Feminino">Feminino</option>
                                </select>
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
                                <input type="text" class="form-control" id="input_nacionalid" value="Brasileira">
                            </div>
                        </div>

                        <div class="form-group">
                            <input type="hidden" class="form-control" id="input_escolaridade" value="XXX">
                            <label for="input_civil" class="col-md-2 control-label">Estado Civil</label>
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
                            <label for="input_Etnia" class="col-md-2 control-label">Etnia</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_Etnia">
                                    <option value="Branco">Branco</option>
                                    <option value="Negro">Negro</option>
                                    <option value="Pardo">Pardo</option>
                                    <option value="Mulato">Mulato</option>
                                    <option value="Amarelo">Amarelo</option>
                                    <option value="Indígena">Indígena</option>
                                    <option value="Quilombola">Quilombola</option>
                                </select>
                            </div>

                            <label for="input_tiposangue" class="col-md-2 control-label">Tipo Sanguínio</label>
                            <div class="col-md-3">
                                <select class="form-control" id="input_tiposangue">
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
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <!-- Camera -->
            <div class="w3-quarter">
                <div id="results"></div>
                <div id="my_camera"></div>
                <input id="Hidden1" name="fotouri" type="hidden" />
            </div>
            <!-- Camera -->

        </div>


        <!-- GRUPO 2 - Endereço -->
        <div id="grupo2" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Endereço</h3>
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
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <div class="w3-quarter">
                <div class="w3-container">
                </div>
            </div>
        </div>


        <!-- GRUPO 3 - Documentação -->
        <div id="grupo3" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Documentação</h3>
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
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar2()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt4()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>
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

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Dependentes</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <!-- GRID Dependentes -->
                        <div class="form-group">
                            <div class="col-md-2"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table id="MyTable" class="w3-table-all w3-hoverable">
                                    <thead>
                                        <tr class="w3-grey">
                                            <th>Nome</th>
                                            <th>Parentesco</th>
                                            <th>Nascimento</th>
                                        </tr>
                                    </thead>
                                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
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
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar3()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt5()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>
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

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Benefícios</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <!-- GRID Beneficios -->
                        <div class="form-group">
                            <div class="col-md-2"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table id="TableBenef" class="w3-table-all w3-hoverable">
                                    <thead>
                                        <tr class="w3-grey">
                                            <th>Benefício</th>
                                            <th>Situação</th>
                                            <th>Início</th>
                                        </tr>
                                    </thead>
                                    <asp:Literal ID="Literal3" runat="server"></asp:Literal>
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
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar4()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt6()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

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
            
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Situação</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>

                        <div class="form-group">
                            <label for="input_vinculo" class="col-md-2 control-label">Vínculo</label>
                            <div class="col-md-3">
                                <select class="form-control" id="input_vinculo">
                                    <option value="Cargo Comissionado">Cargo Comissionado</option>
                                    <option value="Contratado">Contratado</option>
                                    <option value="Estatutário">Estatutário</option>
                                    <option value="Estagiário">Estagiário</option>
                                    <option value="Outros">Outros</option>
                                </select>
                            </div>
                            <label for="input_qual" class="col-md-2 control-label">Situação</label>
                            <div class="col-md-5">
                                <select class="form-control" id="input_situac">
                                    <option value="Em atividade">Em atividade</option>
                                    <option value="Aposentado">Aposentado</option>
                                    <option value="Exonerado">Exonerado</option>
                                    <option value="Transferido a outra Secretaria">Transferido a outra Secretaria</option>
                                    <option value="Afastado">Afastado</option>
                                    <option value="INSS">INSS</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_funcao" class="col-md-2 control-label">Função</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_funcao">
                            </div>
                            <label for="input_tabelaSal" class="col-md-2 control-label">Tabela Salarial</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_tabelaSal">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_bruto" class="col-md-2 control-label">Salário Bruto</label>
                            <div class="col-md-3">
                                <input type="number" class="form-control" id="input_bruto" value="0">
                            </div>
                            <label for="input_SalInvest" class="col-md-3 control-label">Salário Investimento</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_SalInvest">
                                    <option value="Federal">Federal</option>
                                    <option value="Estadual">Estadual</option>
                                    <option value="Municipal">Municipal</option>
                                    <option value="Convênio">Convênio</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_fliadoSind" class="col-md-2 control-label">Sindicalizado</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_fliadoSind">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                            <label for="input_Sindqual" class="col-md-2 control-label">Qual</label>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="input_Sindqual">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_lotado" class="col-md-2 control-label">Lotado Em</label>
                            <div class="col-md-7">
                                <select class="form-control" id="input_lotado">
                                    <option value="Secretaria Municipal de Turismo">Secretaria Municipal de Turismo</option>
                                    <option value="Secretaria Municipal de Saúde">Secretaria Municipal de Saúde</option>
                                    <option value="Secretaria Municipal de Obras">Secretaria Municipal de Obras</option>
                                    <option value="Secretaria Municipal de Meio Ambiente">Secretaria Municipal de Meio Ambiente</option>
                                    <option value="Secretaria Municipal de Educação">Secretaria Municipal de Educação</option>
                                    <option value="Secretaria Municipal de Finanças">Secretaria Municipal de Finanças</option>
                                    <option value="Secretaria Municipal de Assistência Social">Secretaria Municipal de Assistência Social</option>
                                    <option value="Secretaria Municipal de Agricultura">Secretaria Municipal de Agricultura</option>
                                    <option value="Secretaria Municipal de Administração">Secretaria Municipal de Administração</option>
                                    <option value="Gabinete do Prefeito">Gabinete do Prefeito</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_matricula" class="col-md-2 control-label">Matrícula</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_matricula">
                            </div>
                            <label for="input_admissao" class="col-md-2 control-label">Admissão</label>
                            <div class="col-md-4">
                                <input type="date" class="form-control" id="input_admissao">
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

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar5()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt7()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

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

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Carga Horária</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <!-- GRID Carga Horária- -->
                        <div class="form-group">
                            <div class="col-md-2"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table id="TableCargaH" class="w3-table-all w3-hoverable">
                                    <thead>
                                        <tr class="w3-grey">
                                            <th>Instituição</th>
                                            <th>Carga Horária</th>
                                        </tr>
                                    </thead>
                                    <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                                </table>
                            </div>
                        </div>
                        <!-- GRID Carga Horária--->

                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round">
                        <p>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar6()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt8()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

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
            
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Dados Bancários</h3>
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
                            <label for="input_contaTipo" class="col-md-2 control-label">Tipo de Conta</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_contaTipo">
                                    <option value="Corrente">Corrente</option>
                                    <option value="Poupança">Poupança</option>
                                    <option value="Salário">Salário</option>
                                </select>
                            </div>
                            <label for="input_conta" class="col-md-2 control-label">Número Conta</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_conta">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_operacao" class="col-md-2 control-label">Operação</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_operacao">
                            </div>
                        </div>

                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round ">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar7()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt9()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

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

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Dados de Saúde</h3>
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

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar8()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt10()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <div class="w3-quarter">
            </div>
        </div>


        <!-- GRUPO 10 - Fardamento -->
        <div id="grupo10" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Fardamento</h3>
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

                        <div class="form-group">
                            <label for="input_cracha" class="col-md-2 control-label">Emitir Crachá</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_cracha">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
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

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar9()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt11()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                            </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

            <div class="w3-quarter">
            </div>
        </div>


        <!-- GRUPO 11 - Digitalizações -->
        <div id="grupo11" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Digitalizações</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <!-- GRID Digitalizações -->
                        <div class="form-group">
                            <div class="col-md-2"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table id="tableDigitaliz" class="w3-table-all">
                                    <thead>
                                        <tr class="w3-grey">
                                            <th>-</th>
                                            <th>Documento</th>
                                            <th>Observações</th>
                                        </tr>
                                    </thead>
                                    <asp:Literal ID="Literal_Digita" runat="server"></asp:Literal>
                                </table>
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

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar10()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt12()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                         </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

        </div>


        <!-- GRUPO 12 - Gratificações -->
        <div id="grupo12" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Gratificações</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <!-- GRID Gratificações -->
                        <div class="form-group">
                            <div class="col-md-2"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table id="tableGratifica" class="w3-table-all w3-hoverable">
                                    <thead>
                                        <tr class="w3-grey">
                                            <th>Gratificação</th>
                                            <th>Percentual(%)</th>
                                            <th>Observações</th>
                                        </tr>
                                    </thead>
                                    <asp:Literal ID="Literal_Gratifica" runat="server"></asp:Literal>
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
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar11()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt13()">
                                <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                          </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

        </div>


        <!-- GRUPO 13 - Formações-->
        <div id="grupo13" class="w3-container grupo w3-animate-left" style="display: none">

            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Ficha de Funcionário - Formações</h3>
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">
                    <fieldset>
                        <!-- GRID Formações -->
                        <div class="form-group">
                            <div class="col-md-2"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table id="tableFormacao" class="w3-table-all w3-hoverable">
                                    <thead>
                                        <tr class="w3-grey">
                                            <th>Tipo</th>
                                            <th>Ano Conclusão</th>
                                        </tr>
                                    </thead>
                                    <asp:Literal ID="Literal_formacoes" runat="server"></asp:Literal>
                                </table>
                            </div>
                        </div>
                        <!-- GRID Formações-->
                    </fieldset>
                </form>

                <!-- Botões Controle -->
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-10 w3-border w3-padding w3-round">
                        <p>
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar12()">
                                <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>
                        </p>
                    </div>
                </div>
                <!-- Botões Controle -->

            </div>

        </div>


        <!-- Modal Digitalização -->
        <div id="div_Digitaliza" class="w3-modal">
            <div class="w3-modal-content w3-card-4 w3-animate-top">

                <header class="w3-container w3-blue w3-center">
                    <span onclick="document.getElementById('div_Digitaliza').style.display='none'"
                        class="w3-button w3-display-topright">&times;</span>
                    <h4>Digitalização</h4>
                </header>

                <form class="w3-container">
                    <div class="w3-section">
                        <div id="result_Digitaliza"></div>
                    </div>
                </form>

                <div class="w3-container w3-center">
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="DigitalizacaoIncluir()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Salvar&nbsp;
                      <i id="btCog" style="display: none" class="fa fa-cog fa-2x fa-spin fa-fw w3-right"></i>
                    </button>
                    &nbsp;&nbsp;

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles"
                        onclick="document.getElementById('div_Digitaliza').style.display='none'">
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Cancelar</button>
                    <p>&nbsp;</p>
                </div>

            </div>
        </div>

        <!-- Modal Vizualizar Digitalização -->
        <div id="div_Digitaliza1" class="w3-modal">
            <div class="w3-modal-content w3-card-4 w3-animate-top">

                <form class="w3-container">
                    <div class="w3-section">
                        <div id="result_Digitaliza1"></div>
                    </div>
                </form>

                <div class="w3-container w3-center">
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles"
                        onclick="document.getElementById('div_Digitaliza1').style.display='none'">
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Fechar</button>
                    <p>&nbsp;</p>
                </div>

            </div>
        </div>

    </div>

    <!-- auxiliares -->
    <input id="IDHidden" type="hidden" />
    <asp:Literal ID="Literal_IDInst" runat="server"></asp:Literal>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeFuncionarios_Novo.js"></script>
    <script type="text/javascript" src="Scripts/webcam.js"></script>
 
</body>
</html>
