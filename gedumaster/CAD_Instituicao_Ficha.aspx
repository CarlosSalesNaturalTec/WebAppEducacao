﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CAD_Instituicao_Ficha.aspx.cs" Inherits="CAD_Instituicao_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--*******Customização*******-->
    <title>Ficha de Instituição</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <style>
        body {
            background-image: url("Images/fundo.jpg");
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
        <button id="bt2" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo2')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Endereço</button>
        <button id="bt3" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo3')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Diretoria</button>
        <button id="bt4" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo4')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Estrutura</button>
        <button id="bt5" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo5')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Imagens</button>
        <button id="bt6" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo6')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Usuários</button>
        <hr />
    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Pessoa Jurídica - Ficha de Instituição</h3>
            </div>

            <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                        <br />
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

                        <div class="form-group">
                            <label for="input_CNPJ" class="col-md-2 control-label">CNPJ</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_CNPJ">
                            </div>
                            <label for="input_IE" class="col-md-2 control-label">Insc.Estadual</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_IE">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input1" class="col-md-2 control-label">Cat. Administrativa</label>
                            <div class="col-md-9">
                                <select class="form-control" id="select_CAtADm">
                                    <option value="Pública Municipal">Pública Municipal</option>
                                    <option value="Pública Estadual">Pública Estadual</option>
                                    <option value="Pública Federal">Pública Federal</option>
                                    <option value="Privada sem Fins Lucrativos">Privada sem Fins Lucrativos</option>
                                    <option value="Privada com Fins Lucrativos">Privada com Fins Lucrativos</option>
                                    <option value="Privada Beneficente">Privada Beneficente</option>
                                    <option value="Especial">Especial</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_MEC" class="col-md-2 control-label">N° Cadastro no MEC</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_MEC">
                            </div>
                        </div>

                    </fieldset>
                </form>
            </div>

            <div class="w3-quarter">
            </div>

            <!-- Botões Controle -->
            <div class="col-md-9 w3-border w3-round w3-light-gray w3-padding" style="margin-top: 10px">
                <br />
                <div class="col-md-2"></div>
                <p>
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Cancelar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt2()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->


        </div>

        <!-- GRUPO 2 -->
        <div id="grupo2" class="w3-container grupo w3-animate-left" style="display: none">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp; Endereço - Ficha de Instituição</h3>
            </div>

            <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                        <br />
                        <div class="form-group">
                            <label for="input_end" class="col-md-2 control-label">Endereço</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input_end">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input_num" class="col-md-2 control-label">Número</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_num">
                            </div>
                            <label for="input_Complemento" class="col-md-2 control-label">Complemento</label>
                            <div class="col-md-5">
                                <input type="text" class="form-control" id="input_Complemento">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_Bairro" class="col-md-2 control-label">Bairro </label>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="input_Bairro">
                            </div>
                            <label for="input_CEP" class="col-md-1 control-label">CEP</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_CEP">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_Cidade" class="col-md-2 control-label">Cidade</label>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="input_Cidade">
                            </div>
                            <label for="input_UF" class="col-md-1 control-label">UF</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_UF">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_Telefone" class="col-md-2 control-label">Telefone</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_Telefone">
                            </div>
                            <label for="input_Celular" class="col-md-2 control-label">Celular</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_Celular">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_Fax" class="col-md-2 control-label">Fax</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_Fax">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_email" class="col-md-2 control-label">E-mail</label>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="input_email">
                            </div>
                        </div>

                    </fieldset>
                </form>
            </div>

            <!-- Botões Controle -->
            <div class="col-md-9 w3-border w3-round w3-light-gray w3-padding" style="margin-top: 10px">
                <br />
                <div class="col-md-2"></div>
                <p>
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar1()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt3()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->
        </div>

        <!-- GRUPO 3 -->
        <div id="grupo3" class="w3-container grupo w3-animate-left" style="display: none">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Diretoria - Ficha de Instituição</h3>
            </div>

            <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                        <br />
                        <div class="form-group">
                            <label for="input_Diretor" class="col-md-2 control-label">Diretor(a)</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_Diretor">
                            </div>
                            <label for="input_adm" class="col-md-2 control-label">Admissão</label>
                            <div class="col-md-3">
                                <input type="date" class="form-control" id="input_adm">
                            </div>
                        </div>

                    </fieldset>
                </form>
            </div>

            <!-- Botões Controle -->
            <div class="col-md-9 w3-border w3-round w3-light-gray w3-padding" style="margin-top: 10px">
                <br />
                <div class="col-md-2"></div>
                <p>
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar2()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt4()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->
        </div>

        <!-- GRUPO 4 -->
        <div id="grupo4" class="w3-container grupo w3-animate-left" style="display: none">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Estrutura - Ficha de Instituição</h3>
            </div>

            <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                        <br />
                        <div class="form-group">
                            <label for="input_Diretor" class="col-md-2 control-label">Quant.Salas</label>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="input_salas">
                            </div>
                            <label for="input_areaJogos" class="col-md-2 control-label">Área de jogos</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_areaJogos">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_areaInfo" class="col-md-2 control-label">Área de Info.</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_areaInfo">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                            <label for="input_teatro" class="col-md-2 control-label">Possui Teatro</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_teatro">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_campofut" class="col-md-2 control-label">Campo de futebol</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_campofut">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                            <label for="input_quadraE" class="col-md-2 control-label">Quadra de Esportes</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_quadraE">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_Biblioteca" class="col-md-2 control-label">Biblioteca</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_Biblioteca">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                        </div>

                    </fieldset>
                </form>
            </div>

            <!-- Botões Controle -->
            <div class="col-md-9 w3-border w3-round w3-light-gray w3-padding" style="margin-top: 10px">
                <br />
                <div class="col-md-2"></div>
                <p>
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar3()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt5()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->
        </div>

        <!-- GRUPO 5 -->
        <div id="grupo5" class="w3-container grupo w3-animate-left" style="display: none">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp; Imagens - Ficha de Instituição</h3>
            </div>

            <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
                <form class="form-horizontal">
                    <fieldset>
                        <br />
                        <div class="col-md-2"></div>
                        <div class="col-md-8">
                            <div id="results"></div>
                            <label for="filePicker">Logomarca da Instituição ( 200x300pixels - Tam.Máx.:75Kb )</label><br>
                            <input type="file" id="filePicker">
                        </div>
                        <input id="FotoHidden" name="fotouri" type="hidden" />

                    </fieldset>
                </form>



            </div>

            <!-- Botões Controle -->
            <div class="col-md-9 w3-border w3-round w3-light-gray w3-padding" style="margin-top: 10px">
                <br />
                <div class="col-md-2"></div>
                <p>
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar4()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt6()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->
        </div>

        <!-- GRUPO 6 -->
        <div id="grupo6" class="w3-container grupo w3-animate-left" style="display: none">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp; Usuários - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
                <form class="form-horizontal">
                    <fieldset>

                        <div class="form-group">
                            <br />
                            <label for="input_userNome" class="col-md-2 control-label">Responsável</label>
                            <div class="col-md-9">
                                <input type="text" id="input_userNome"  class="w3-input w3-border w3-round">
                            </div>
                        </div>

                        <div class="form-group">

                            <label for="input_user" class="col-md-2 control-label">Usuário</label>
                            <div class="col-md-4">
                                <input type="text" id="input_user" class="w3-input w3-border w3-round">
                            </div>
                            
                            <label for="input_DEPparent" class="col-md-1 control-label">Senha</label>
                            <div class="col-md-2">
                                <input type="password" id="input_pwd" class="w3-input w3-border w3-round">
                            </div>
                            
                            <div class="col-md-2">
                                <button class="w3-btn w3-border w3-round w3-light-green w3-hover-green"
                                    onclick="IncluirUsuario()" type="button">
                                    <i class="fa fa-plus"></i>&nbsp;Adicionar</button>
                            </div>

                        </div>


                        <!-- GRID Usuarios -->
                        <div class="form-group">
                            <div class="col-md-1"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table id="MyTable" class="w3-table-all w3-hoverable">
                                    <thead>
                                        <tr class="w3-grey">
                                            <th>Nome</th>
                                            <th>Usuário</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                        <!-- GRID Usuarios -->

                    </fieldset>
                </form>
            </div>

            <!-- Botões Controle -->
            <div class="col-md-9 w3-border w3-round w3-light-gray w3-padding" style="margin-top: 10px">
                <br />
                <div class="col-md-2"></div>
                <p>
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar5()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->
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
</body>

</html>
