﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Home</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Styles: W3, BootsStrap, Font-Awesome -->
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <style>
        body {
            background-image: url("Images/fundo.jpg");
            background-repeat: repeat;
        }
    </style>

</head>
<body>

    <br />

    <!--  LINHA 01 -->
    <div class="panel panel-success">
        <div class="panel-body">
            <br />

            <!-- INSTITUIÇÃO -->
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p><i class="fa fa-5x fa-university" aria-hidden="true"></i></p>
                </div>
                <footer class="w3-container w3-center w3-light-green">
                    <p>
                        <div class="w3-dropdown-hover">
                            <button class="w3-btn">INSTITUIÇÃO</button>
                            <div class="w3-dropdown-content w3-bar-block w3-card-4">
                                <a href="Cursos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">CURSOS</a>
                                <a href="Disciplinas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">DISCIPLINAS</a>
                                <a href="Salas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">SALAS</a>
                                <a href="Turmas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">TURMAS</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">FUNCIONÁRIOS</a>
                            </div>
                        </div>
                    </p>
                </footer>
                <br />
            </div>

            <!-- coluna divisória -->
            <div class="col-md-1"></div>

            <!-- CADASTROS -->
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p><i class="fa fa-5x fa-list-alt" aria-hidden="true"></i></p>
                </div>
                <footer class="w3-container w3-center w3-light-green">
                    <p>
                        <div class="w3-dropdown-hover">
                            <button class="w3-btn">CADASTROS</button>
                            <div class="w3-dropdown-content w3-bar-block w3-card-4">
                                <a href="FornecedorAlimentos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">FORNECEDORES</a>
                                <a href="Patrimonio_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">BENS</a>
                                <a href="Veiculos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">VEÍCULOS</a>
                                <a href="Viagens_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">VIAGENS</a>
                                <a href="Visitas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">VISITAS</a>
                            </div>
                        </div>
                    </p>
                </footer>
                <br />
            </div>

            <!-- coluna divisória -->
            <div class="col-md-1"></div>

            <!-- PRODUTOS -->
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p><i class="fa fa-5x fa-cutlery" aria-hidden="true"></i></p>
                </div>
                <footer class="w3-container w3-center w3-light-green">
                    <p>
                        <div class="w3-dropdown-hover">
                            <button class="w3-btn">PRODUTOS</button>
                            <div class="w3-dropdown-content w3-bar-block w3-card-4">
                                <a href="Produtos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">ESTOQUE</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">RECEITAS</a>
                            </div>
                        </div>
                    </p>
                </footer>
                <br />
            </div>

        </div>
    </div>

    <!--  LINHA 02 -->
    <div class="panel panel-success">

        <div class="panel-body">
            <br />

            <!-- MATRICULAS -->
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p><i class="fa fa-5x fa-calendar-check-o" aria-hidden="true"></i></p>
                </div>
                <footer class="w3-container w3-center w3-light-green">
                    <p>
                        <div class="w3-dropdown-hover">
                            <button class="w3-btn">MATRÍCULAS</button>
                            <div class="w3-dropdown-content w3-bar-block w3-card-4">
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">PRÉ-MATRICULA</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">MATRICULADOS</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">FORMULÁRIOS</a>
                            </div>
                        </div>
                    </p>
                </footer>
                <br />
            </div>

            <!-- coluna divisória -->
            <div class="col-md-1"></div>

            <!-- ALUNOS -->
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p><i class="fa fa-5x fa-address-card-o" aria-hidden="true"></i></p>
                </div>
                <footer class="w3-container w3-center w3-light-green">
                    <p>
                        <div class="w3-dropdown-hover">
                            <button class="w3-btn">ALUNOS</button>
                            <div class="w3-dropdown-content w3-bar-block w3-card-4">
                                <a href="Alunos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">FICHA</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">BOLETINS</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">FREQUÊNCIA</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">OCORRÊNCIAS</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">ATESTADOS</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">HISTÓRICO</a>
                            </div>
                        </div>
                    </p>
                </footer>
                <br />
            </div>

            <!-- coluna divisória -->
            <div class="col-md-1"></div>

            <!-- BIBLIOTECA -->
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p><i class="fa fa-5x fa-book" aria-hidden="true"></i></p>
                </div>
                <footer class="w3-container w3-center w3-light-green">
                    <p>
                        <div class="w3-dropdown-hover">
                            <button class="w3-btn">BIBLIOTECA</button>
                            <div class="w3-dropdown-content w3-bar-block w3-card-4">
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">LIVROS</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">EMPRÉSTIMOS</a>
                            </div>
                        </div>
                    </p>
                </footer>
                <br />
            </div>

        </div>

    </div>

    <!--  LINHA 03 -->
    <div class="panel panel-success">
        <div class="panel-body">
            <br />

            <!-- SUPORTE -->
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p>
                        <img src="Images/logoaliancasmall1.png" />
                    </p>
                </div>
                <footer class="w3-container w3-center w3-light-green">
                    <p>
                        <div class="w3-dropdown-hover">
                            <button class="w3-btn">SUPORTE</button>
                            <div class="w3-dropdown-content w3-bar-block w3-card-4">
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">EXPORTAÇÃO INEP</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">SUPORTE</a>
                                <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">SOBRE</a>
                            </div>
                        </div>
                    </p>
                </footer>
                <br />
            </div>

        </div>
    </div>

</body>
</html>
