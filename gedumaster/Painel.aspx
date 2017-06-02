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
    <div>
        <!-- Menu -->
        <div class="w3-bar w3-light-grey">

            <a class="w3-bar-item w3-small w3-text-green">
                <asp:Literal ID="lblWelcome" runat="server"></asp:Literal></a>

            <a href="#" class="w3-bar-item w3-btn w3-right" onclick="sair()">Sair <i class="fa fa-sign-out"></i></a>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn"><i class="fa fa-print"></i>&nbsp;Relatórios</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button">Gráficos</a>
                    <a href="#" class="w3-bar-item w3-button">Estatísticas</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn"><i class="fa fa-building"></i>&nbsp;Instituições</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="CADInstituicoes_Listagem.aspx" target="iframe" class="w3-bar-item w3-button">Cadastro</a>
                    <a href="#" class="w3-bar-item w3-button">Pesquisa</a>
                </div>
            </div>

            <a href="Home.aspx" target="iframe" class="w3-bar-item w3-button w3-right"><i class="fa fa-home"></i></a>

        </div>
    </div>

    <!-- page content -->
    <div>
        <iframe src="Home.aspx" width="100%" height="600px" frameborder="0" name="iframe">Atualize seu Navegador!</iframe>
    </div>
    <!-- page content -->

    <!-- Footer -->
    <div class="w3-container w3-bottom">
        <div class="w3-bar w3-center w3-bottom w3-light-grey">
            <h6 class="w3-small">Powered by &nbsp;
                <img src="Imagens/inxell.jpg" />
            </h6>
        </div>
    </div>

    <!-- Scripts Diversos -->
    <script type="text/javascript" src="Scripts/codePainel.js"></script>

</body>
</html>
