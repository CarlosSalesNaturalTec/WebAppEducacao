<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Painel.aspx.cs" Inherits="Painel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>GEDUM - Painel de Controle</title>
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
            background-image: url("Images/fundo.jpg");
            background-repeat: repeat;
        }
    </style>

</head>

<body>

    <!-- Corpo -->
    <div>

        <!-- Menu -->
        <div class="w3-bar w3-black">

            <a href="#" class="w3-bar-item w3-btn w3-hover-green w3-right" onclick="sair()">Sair <i class="fa fa-sign-out"></i></a>

            <a href="Suporte.aspx" target="iframe" class="w3-bar-item w3-btn w3-hover-green w3-right">Suporte <i class="fa fa-cog"></i></a>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-upload" aria-hidden="true"></i>&nbsp;Exportações </button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button w3-hover-green">Exportação INEP</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-book" aria-hidden="true"></i>&nbsp;Livros </button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button w3-hover-green">Cadastro</a>
                     <a href="#" class="w3-bar-item w3-button w3-hover-green">Controle de Entregas</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-user" aria-hidden="true"></i>&nbsp;Alunos </button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="Alunos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-green">Ficha do Aluno</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-green">Boletins</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-green">Frequência</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-green">Ocorrências</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-green">Atestados</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-green">Histórico Escolar</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-address-card-o" aria-hidden="true"></i>&nbsp;Matrículas</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Pré-Matrículas</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Matriculados</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Formulários</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-users" aria-hidden="true"></i>&nbsp;RH</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Funcionários</a>                 
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-car" aria-hidden="true"></i>&nbsp;Transportes</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Modelo</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Veículos</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Viagem</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-cutlery" aria-hidden="true"></i>&nbsp;Alimentos</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">                
                    <a href="Produtos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">Produtos</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Fornecedores</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Estoque Alimentos</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Receitas</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-calendar-check-o" aria-hidden="true"></i>&nbsp;Patrimônio</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="Patrimonio_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">Bens</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Fornecedores</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-university" aria-hidden="true"></i>&nbsp;Instituição</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="Cursos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">Cursos</a>
                    <a href="Disciplinas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">Disciplinas</a>
                    <a href="Salas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">Salas</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green">Vagas</a>
                    <a href="Turmas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">Turmas</a>
                    <a href="Visitas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green">Visitas</a>
                </div>
            </div>

            <a href="home.aspx" target="iframe" class="w3-bar-item w3-btn w3-hover-green w3-right"><i class="fa fa-home"></i>&nbsp;Home</a>

        </div>

    </div>

    <!-- page content -->
    <div>
        <iframe src="home.aspx" width="100%" height="600px" frameborder="0" name="iframe">Atualize seu Navegador!</iframe>
    </div>
    <!-- page content -->

    <!-- Footer -->
    <div class="w3-bottom">
        <div class="w3-bar w3-black">
            <div class="w3-right">
                <h6 class="w3-small" style="margin-left: 14px"><a href="http://inxell.com.br/" target="_blank">
                    <img src="Images/logor_inxellsmall.png" class="w3-animate-fading" /></a>
                    &nbsp;&nbsp;&nbsp;<i class="fa fa-user w3-small"></i>
                    &nbsp;<asp:Label ID="lblUSer" CssClass="w3-text-green" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;<i class="fa fa-university w3-small"></i>
                    &nbsp;<asp:Label ID="lblInst" CssClass="w3-text-green" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                </h6>
            </div>
        </div>
    </div>

    <!-- Modal LogOff -->
    <div id="DivLogOut" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 400px">

            <form class="w3-container">
                <div class="w3-section w3-center">
                    <header class="w3-container w3-green w3-center">
                        <h4><strong>Atenção</strong></h4>
                    </header>
                    <br />
                    <i class="fa fa-3x fa-exclamation-triangle" aria-hidden="true"></i>
                    <br />
                    <h3><strong>Confirma Saida?</strong> </h3>
                    <br />
                    <p>
                        <button type="button" class="w3-button w3-round w3-border w3-light-green w3-hover-green" onclick="sair_cancel()">Não</button>&nbsp;&nbsp;&nbsp;
                        <button type="button" class="w3-button w3-round w3-border w3-light-green w3-hover-red" onclick="sair_exit()">Sim</button>
                    </p>
                    <br />
                </div>
            </form>
        </div>
    </div>
    <!-- Modal LogOff -->

    <!-- Scripts -->
    <script type="text/javascript" src="Scripts/codePainel.js"></script>

</body>
</html>
