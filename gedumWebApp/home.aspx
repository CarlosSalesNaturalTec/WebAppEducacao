<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Home</title>
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
        }
    </style>

</head>
<body>

    <br />

    <!--  LINHA 01 -->
    <div class="w3-container">
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
                        <button class="w3-btn w3-round">INSTITUIÇÃO</button>
                        <div class="w3-dropdown-content w3-bar-block w3-card-4">
                            <a href="Cursos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-university"></i>&nbsp;Cursos</a>
                            <a href="Disciplinas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-university"></i>&nbsp;Disciplinas</a>
                            <a href="Salas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-university"></i>&nbsp;Salas</a>
                            <a href="Turmas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-university"></i>&nbsp;Turmas</a>
                            <a href="Patrimonio_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-university"></i>&nbsp;Patrimônio</a>
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
                        <button class="w3-btn w3-round">OPERACIONAL</button>
                        <div class="w3-dropdown-content w3-bar-block w3-card-4">
                            <a href="Funcionarios_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-list-alt"></i>&nbsp;Funcionários</a>
                            <a href="FornecedorAlimentos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-list-alt"></i>&nbsp;Fornecedores</a>
                            <a href="Veiculos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-list-alt"></i>&nbsp;Veículos</a>
                            <a href="Viagens_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-list-alt"></i>&nbsp;Viagens</a>
                            <a href="Visitas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-list-alt"></i>&nbsp;Visitas</a>
                        </div>
                    </div>
                </p>
            </footer>
            <br />
        </div>

        <!-- coluna divisória -->
        <div class="col-md-1"></div>

        <!-- ALIMENTOS -->
        <div class="w3-card-4 col-md-3">
            <br />
            <div class="w3-container w3-center">
                <p><i class="fa fa-5x fa-cutlery" aria-hidden="true"></i></p>
            </div>
            <footer class="w3-container w3-center w3-light-green">
                <p>
                    <div class="w3-dropdown-hover">
                        <button class="w3-btn w3-round">ESTOQUE</button>
                        <div class="w3-dropdown-content w3-bar-block w3-card-4">
                            <a href="Produtos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-cutlery"></i>&nbsp;Produtos</a>
                            <a href="Receitas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-cutlery"></i>&nbsp;Receitas</a>
                        </div>
                    </div>
                </p>
            </footer>
            <br />
        </div>

    </div>

    <!--  LINHA 02 -->
    <div class="w3-container">

        <br />

        <!-- BIBLIOTECA -->
        <div class="w3-card-4 col-md-3">
            <br />
            <div class="w3-container w3-center">
                <p><i class="fa fa-5x fa-book" aria-hidden="true"></i></p>
            </div>
            <footer class="w3-container w3-center w3-light-green">
                <p>
                    <div class="w3-dropdown-hover">
                        <button class="w3-btn w3-round">BIBLIOTECA</button>
                        <div class="w3-dropdown-content w3-bar-block w3-card-4">
                            <a href="Livros_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-book"></i>&nbsp;Livros</a>
                            <a href="Emprestimos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-book"></i>&nbsp;Empréstimos</a>
                        </div>
                    </div>
                </p>
            </footer>
            <br />
        </div>

        <!-- coluna divisória -->
        <div class="col-md-1"></div>

        <!-- MATRICULAS -->
        <div class="w3-card-4 col-md-3">
            <br />
            <div class="w3-container w3-center">
                <p><i class="fa fa-5x fa-calendar-check-o" aria-hidden="true"></i></p>
            </div>
            <footer class="w3-container w3-center w3-light-green">
                <p>
                    <div class="w3-dropdown-hover">
                        <button class="w3-btn w3-round">MATRÍCULAS</button>
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
                        <button class="w3-btn w3-round">ALUNOS</button>
                        <div class="w3-dropdown-content w3-bar-block w3-card-4">
                            <a href="Alunos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">FICHA</a>
                            <a href="Boletins.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">BOLETINS</a>
                            <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">FREQUÊNCIA</a>
                            <a href="Ocorrencias_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">OCORRÊNCIAS</a>
                            <a href="Atestados_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">ATESTADOS</a>
                            <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">HISTÓRICO</a>
                        </div>
                    </div>
                </p>
            </footer>
            <br />
        </div>

    </div>

    <!--  LINHA 03 -->
    <div class="w3-container">
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
                        <button class="w3-btn w3-round">SUPORTE</button>
                        <div class="w3-dropdown-content w3-bar-block w3-card-4">
                            <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">EXPORTAÇÕES</a>
                            <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">SUPORTE</a>
                            <a href="#" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">SOBRE</a>
                        </div>
                    </div>
                </p>
            </footer>
            <br />
        </div>
    </div>

</body>
</html>
