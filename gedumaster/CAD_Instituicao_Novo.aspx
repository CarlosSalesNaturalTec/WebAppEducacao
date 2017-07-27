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
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Pessoa Jurídica - Nova Instituição</h3>
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

                        <div class="form-group">
                            <label for="input_invest" class="col-md-2 control-label">Investimento</label>
                            <div class="col-md-9">
                                <select class="form-control" id="input_invest">
                                    <option value="Federal">Federal</option>
                                    <option value="Estadual">Estadual</option>
                                    <option value="Municipal">Municipal</option>
                                    <option value="Convênio">Convênio</option>
                                </select>
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
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt2()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
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
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp; Endereço - Nova Instituição</h3>
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
                            <label for="input_zona" class="col-md-2 control-label">Zona</label>
                            <div class="col-md-3">
                                <select class="form-control" id="input_zona">
                                    <option value="Urbana">Urbana</option>
                                    <option value="Rural">Rural</option>
                                </select>
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
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar1()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt3()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
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
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Diretoria - Nova Instituição</h3>
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
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar2()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt4()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
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
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Estrutura - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                        <br />

                        <div class="form-group">
                            <label for="input_inep" class="col-md-2 control-label">Código INEP</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_inep">
                            </div>
                            <label for="input_UE" class="col-md-2 control-label">Código UE</label>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="input_UE">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_porte" class="col-md-2 control-label">Porte</label>
                            <div class="col-md-3">
                                <select class="form-control" id="input_porte">
                                    <option value="Pequeno">Pequeno</option>
                                    <option value="Médio">Médio</option>
                                    <option value="Grande">Grande</option>
                                </select>
                            </div>
                            <label for="input_modalid" class="col-md-2 control-label">Modalidade</label>
                            <div class="col-md-4">
                                <select class="form-control" id="input_modalid">
                                    <option value="Creche">Creche</option>
                                    <option value="Pré-Escola">Pré-Escola</option>
                                    <option value="Educação Especial">Educação Especial</option>
                                    <option value="Educação Infantil">Educação Infantil</option>
                                    <option value="Educação de Jovens e Adultos">Educação de Jovens e Adultos</option>
                                    <option value="Ensino Regular">Ensino Regular</option>
                                    <option value="Ensino Fundamental I">Ensino Fundamental I</option>
                                    <option value="Ensino Fundamental II">Ensino Fundamental II</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_decreto" class="col-md-2 control-label">Decreto Criação</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="input_decreto">
                            </div>
                            <label for="input_criacao" class="col-md-2 control-label">Data Criação</label>
                            <div class="col-md-3">
                                <input type="date" class="form-control" id="input_criacao">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_matutino" class="col-md-2 control-label">Funcionamento Maturino</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_matutino">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                            <label for="input_Verpertino" class="col-md-2 control-label">Verpertino</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_Verpertino">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                            <label for="input_Noturno" class="col-md-1 control-label">Noturno</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_Noturno">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_anexo" class="col-md-2 control-label">Com Anexo</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_anexo">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                            <label for="input_Transporte" class="col-md-2 control-label">Com Transporte</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_Transporte">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                            <label for="input_lixo" class="col-md-1 control-label">Coleta de Lixo</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_lixo">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_Biblioteca" class="col-md-2 control-label">Com Biblioteca</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_Biblioteca">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                            <label for="input_Ginasio" class="col-md-2 control-label">Com Ginásio</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_Ginasio">
                                    <option value="Não">Não</option>
                                    <option value="Sim">Sim</option>
                                </select>
                            </div>
                            <label for="input_Assentamento" class="col-md-1 control-label">Assentamento</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_Assentamento">
                                    <option value="Sim">Sim</option>
                                    <option value="Não">Não</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_cercado" class="col-md-2 control-label">Tipo Cercado</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_cercado">
                                    <option value="Muro">Muro</option>
                                    <option value="Cerca">Cerca</option>
                                    <option value="Nenhum">Nenhum</option>
                                    <option value="Outros">Outros</option>
                                </select>
                            </div>
                            <label for="input_esgoto" class="col-md-2 control-label">Tipo Esgoto</label>
                            <div class="col-md-3">
                                <select class="form-control" id="input_esgoto">
                                    <option value="Rede Pública">Rede Pública</option>
                                    <option value="Rede Privada">Rede Privada</option>
                                    <option value="Outros">Outros</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_energia" class="col-md-2 control-label">Energia Elétrica</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_energia">
                                    <option value="Monofásica">Monofásica</option>
                                    <option value="Bifásica">Bifásica</option>
                                    <option value="Trifásica">Trifásica</option>
                                    <option value="Outros">Outros</option>
                                </select>
                            </div>
                            <label for="input_imovel" class="col-md-2 control-label">Prédio/Imóvel</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_imovel">
                                    <option value="Alugado">Alugado</option>
                                    <option value="Próprio">Próprio</option>
                                    <option value="Outros">Outros</option>
                                </select>
                            </div>
                            <label for="input_uso" class="col-md-1 control-label">Uso Prédio</label>
                            <div class="col-md-2">
                                <select class="form-control" id="input_uso">
                                    <option value="Compartilhado">Compartilhado</option>
                                    <option value="Exclusivo">Exclusivo</option>
                                    <option value="Outros">Outros</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_quant" class="col-md-2 control-label">Quant.Prédios</label>
                            <div class="col-md-2">
                                <input type="number" class="form-control" id="input_quant">
                            </div>
                            <label for="input_salasadm" class="col-md-2 control-label">Qtd.Salas Adm.</label>
                            <div class="col-md-2">
                                <input type="number" class="form-control" id="input_salasadm">
                            </div>
                            <label for="input_salasapoio" class="col-md-1 control-label">Salas Apoio</label>
                            <div class="col-md-2">
                                <input type="number" class="form-control" id="input_salasapoio">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input_bmasc" class="col-md-2 control-label">Quant. Banheiros Masc.</label>
                            <div class="col-md-2">
                               <input type="number" class="form-control" id="input_bmasc">
                            </div>
                            <label for="input_bfem" class="col-md-2 control-label">Quant. Banheiros Fem.</label>
                            <div class="col-md-2">
                                <input type="number" class="form-control" id="input_bfem">
                            </div>
                        </div>
                      
                        <div class="form-group">
                            <label for="input_Diretor" class="col-md-2 control-label">Quant.Salas</label>
                            <div class="col-md-2">
                                <input type="number" class="form-control" id="input_salas">
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
                            <label for="input_areaInfo" class="col-md-2 control-label">Área Informática</label>
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

                    </fieldset>
                </form>
            </div>

            <!-- Botões Controle -->
            <div class="col-md-9 w3-border w3-round w3-light-gray w3-padding" style="margin-top: 10px">
                <br />
                <div class="col-md-2"></div>
                <p>
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar3()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt5()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
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
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp; Imagens - Nova Instituição</h3>
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
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar4()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt6()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
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
                                <input type="text" id="input_userNome" class="w3-input w3-border w3-round">
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
                                    onclick="alert('Necessário Salvar Instituição primeiro!')">
                                    <i class="fa fa-plus"></i>&nbsp;Adicionar</button>
                            </div>

                        </div>


                        <!-- GRID Usuarios -->
                        <div class="form-group">
                            <div class="col-md-1"></div>
                            <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                                <table class="w3-table-all w3-hoverable">
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
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

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
    <input id="IDMunicipio" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeInstituicao_Novo.js"></script>

    <!--*******Customização somente se for usar mapa*******
    <script type="text/javascript" src="Scripts/codeInstituicao_Mapa.js"></script> 
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&libraries=places&callback=initMap" async defer></script>
    -->

</body>
</html>
