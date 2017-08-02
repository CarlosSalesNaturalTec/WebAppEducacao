<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Painel.aspx.cs" Inherits="Painel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GEDUM - Painel de Controle</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        body {
            background-image: url("Images/fundo.jpg");
            background-repeat: repeat;
        }
    </style>

</head>
<body>

    <!-- Menu -->
    <div>
        <div class="w3-bar w3-black">

            <a href="#" class="w3-bar-item w3-btn w3-hover-green w3-right" onclick="sair()">Sair <i class="fa fa-sign-out"></i></a>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-upload" aria-hidden="true"></i>&nbsp;Exportações </button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button w3-hover-green">Exportação SIOPE</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-line-chart"></i>&nbsp;Estatísticas</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button">Gráficos</a>
                    <a href="#" class="w3-bar-item w3-button">Relatórios</a>
                </div>
            </div>

             <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-file"></i>&nbsp;Relatórios</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button">Cursos</a>
                    <a href="#" class="w3-bar-item w3-button">Instituições</a>
                    <a href="#" class="w3-bar-item w3-button">Histórico Matrícula</a>
                    <a href="#" class="w3-bar-item w3-button">Evolução Matrícula</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-university"></i>&nbsp;Cadastro</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="CAD_Municipio_Listagem.aspx" target="iframe" class="w3-bar-item w3-button">Municípios</a>
                    <a href="CAD_Instituicao_Listagem.aspx" target="iframe" class="w3-bar-item w3-button">Instituições</a>
                </div>
            </div>

            <a href="Home.aspx" target="iframe" class="w3-bar-item w3-btn w3-hover-green w3-right"><i class="fa fa-home"></i>&nbsp;Home</a>

        </div>
    </div>


    <!-- page content -->
    <div>
        <iframe src="Home.aspx" width="100%" height="1024px" frameborder="0" name="iframe">Atualize seu Navegador!</iframe>
    </div>

    <!-- Footer -->
    <div class="w3-bottom">
        <div class="w3-bar w3-black">
            <div class="w3-right">
                <h6 class="w3-small" style="margin-left: 14px"><a href="http://inxell.com.br/" target="_blank">
                    <img src="Images/logor_inxellsmall.png" class="w3-animate-fading" /></a>
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblWelcome" CssClass="w3-text-green" runat="server"></asp:Label>&nbsp;&nbsp;
                    <i class="fa fa-user w3-small"></i>&nbsp;&nbsp;
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

    <!-- Scripts Diversos -->
    <script type="text/javascript" src="Scripts/codePainel.js"></script>

</body>
</html>
