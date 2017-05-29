<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Painel.aspx.cs" Inherits="Painel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GEDUM - Painel de Controle</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body>

    <!-- Corpo -->
    <div class="w3-container">
        <img src="Images/alianca.jpg" class="w3-display-middle w3-animate-fading" />

        <!-- Menu -->
        <div class="w3-bar w3-light-grey">

            <a href="#" class="w3-bar-item w3-button w3-right" onclick="sair()">Sair <i class="fa fa-sign-out"></i></a>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-button">Alunos </button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button">Ficha do Aluno</a>
                    <a href="#" class="w3-bar-item w3-button">Boletins</a>
                    <a href="#" class="w3-bar-item w3-button">Frequência</a>
                    <a href="#" class="w3-bar-item w3-button">Ocorrências</a>
                    <a href="#" class="w3-bar-item w3-button">Atestados</a>
                    <a href="#" class="w3-bar-item w3-button">Histórico Escolar</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-button">Matrículas</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button">Pré-Matrículas</a>
                    <a href="#" class="w3-bar-item w3-button">Matriculados</a>
                    <a href="#" class="w3-bar-item w3-button">Formulários</a>
                </div>
            </div>


            <div class="w3-dropdown-hover w3-right">
                <button class="w3-button">Equipe</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button">Professores</a>
                    <a href="#" class="w3-bar-item w3-button">Funcionários</a>
                    <a href="#" class="w3-bar-item w3-button">Frequência</a>
                    <a href="#" class="w3-bar-item w3-button">Atestados</a>
                </div>
            </div>


            <div class="w3-dropdown-hover w3-right">
                <button class="w3-button">Instituição</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button">Cursos</a>
                    <a href="#" class="w3-bar-item w3-button">Disciplinas</a>
                    <a href="#" class="w3-bar-item w3-button">Salas</a>
                    <a href="#" class="w3-bar-item w3-button">Vagas</a>
                    <a href="#" class="w3-bar-item w3-button">Turmas</a>
                </div>
            </div>

        </div>

    </div>

    <!-- Footer -->
    <div class="w3-container w3-bottom">
        <div class="w3-bar w3-center w3-bottom w3-animate-left">
            <h6 class="w3-small">Powered by &nbsp;
                <img src="Images/inxellsmall.jpg" />
            </h6>
        </div>
    </div>

    <script type="text/javascript">

        function sair() {
            var r = confirm("SAIR ?");
            if (r == true) {
                window.open('Default.aspx', '_parent');
            }
        }
    </script>

</body>
</html>
