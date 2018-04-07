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

            <!-- Sair -->
            <a href="#" class="w3-bar-item w3-btn w3-hover-green w3-right" onclick="sair()">Sair <i class="fa fa-sign-out"></i></a>

            <!-- Suporte -->
            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-upload" aria-hidden="true"></i>&nbsp;Suporte</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button w3-hover-green"><i class="fa fa-share-alt"></i>&nbsp;Exportação INEP</a>
                    <a href="Parametro.aspx" target="iframe" class="w3-bar-item w3-btn w3-hover-green w3-right"><i class="fa fa-cog"></i>&nbsp;Parâmetros</a>
                    <a href="Suporte.aspx" target="iframe" class="w3-bar-item w3-btn w3-hover-green w3-right"><i class="fa fa-cog"></i>&nbsp;Suporte</a>
                </div>
            </div>

            <!-- Alunos -->
            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-address-card-o" aria-hidden="true"></i>&nbsp;Alunos</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="SolicitacoesMatriculas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-green"><i class="fa fa-address-card-o"></i>&nbsp;Solicitações de Matrícula</a>
                    <a href="Alunos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-green"><i class="fa fa-address-card-o"></i>&nbsp;Alunos Matriculados</a>
                    <a href="Boletins.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-green"><i class="fa fa-address-card-o"></i>&nbsp;Boletins</a>
                    <a href="Avaliacao_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-green"><i class="fa fa-address-card-o"></i>&nbsp;Avaliações</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-green"><i class="fa fa-address-card-o"></i>&nbsp;Frequência</a>
                    <a href="Ocorrencias_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-green"><i class="fa fa-address-card-o"></i>&nbsp;Ocorrências</a>
                    <a href="Atestados_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-green"><i class="fa fa-address-card-o"></i>&nbsp;Atestados</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-green"><i class="fa fa-address-card-o"></i>&nbsp;Histórico Escolar</a>
                </div>
            </div>

            <!-- Matrículas 
            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-calendar-check-o" aria-hidden="true"></i>&nbsp;Matrículas</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="Matriculas_Solicita_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-calendar-check-o"></i>&nbsp;Solicitações</a>
                    <a href="#" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-calendar-check-o"></i>&nbsp;Formulários</a>
                </div>
            </div>
            -->
            <!-- Biblioteca -->
            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-book" aria-hidden="true"></i>&nbsp;Biblioteca</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="Livros_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-green"><i class="fa fa-book"></i>&nbsp;Livros</a>
                    <a href="Emprestimos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-green"><i class="fa fa-book"></i>&nbsp;Empréstimos</a>
                </div>
            </div>

            <!-- Estoque -->
            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-cutlery" aria-hidden="true"></i>&nbsp;Estoque</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="Produtos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-cutlery"></i>&nbsp;Produtos</a>
                    <a href="Receitas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-cutlery"></i>&nbsp;Receitas</a>
                </div>
            </div>


            <!-- Operacional  -->
            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-list-alt" aria-hidden="true"></i>&nbsp;Operacional</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="Funcionarios_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-list-alt"></i>&nbsp;Funcionários</a>
                    <a href="FornecedorAlimentos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-list-alt"></i>&nbsp;Fornecedores</a>
                    <a href="Veiculos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-list-alt"></i>&nbsp;Veículos</a>
                    <a href="Viagens_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-list-alt"></i>&nbsp;Veículos - Controle de Viagens</a>
                    <a href="Visitas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-list-alt"></i>&nbsp;Controle de Visitas</a>
                </div>
            </div>

            <!-- Instituição -->
            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-university" aria-hidden="true"></i>&nbsp;Instituição</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="Patrimonio_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-university"></i>&nbsp;Patrimônio</a>
                    <a href="PeriodoAvaliacao_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-university"></i>&nbsp;Periodos</a>
                    <a href="Disciplinas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-university"></i>&nbsp;Disciplinas</a>
                    <a href="Cursos_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-university"></i>&nbsp;Cursos</a>
                    <a href="Salas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-university"></i>&nbsp;Salas</a>
                    <a href="Turmas_Listagem.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-light-green"><i class="fa fa-university"></i>&nbsp;Turmas</a>
                  </div>
            </div>

            <!-- Home -->
            <a href="home.aspx" target="iframe" class="w3-bar-item w3-btn w3-hover-green w3-right"><i class="fa fa-home"></i>&nbsp;Home</a>

            <div class="w3-left">
                <h6 class="w3-small" style="margin-left: 14px"><a href="http://inxell.com.br/" target="_blank">
                    <img src="Images/logor_inxellsmall.png" /></a>
                    &nbsp;&nbsp;&nbsp;<i class="fa fa-university w3-small"></i>
                    &nbsp;<asp:Label ID="lblInst" CssClass="w3-text-green" runat="server"></asp:Label>
                </h6>
            </div>

        </div>

    </div>

    <!-- page content -->
    <div>
        <iframe src="home.aspx" width="100%" height="880px" frameborder="0" name="iframe">Atualize seu Navegador!</iframe>
    </div>
    <!-- page content -->

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
