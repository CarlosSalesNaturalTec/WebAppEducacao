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

    <!-- Menu -->
    <div>
        <div class="w3-bar w3-black">

            <a href="#" class="w3-bar-item w3-btn w3-hover-green w3-right" onclick="sair()">Sair <i class="fa fa-sign-out"></i></a>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-line-chart"></i>&nbsp;Estatísticas</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="#" class="w3-bar-item w3-button">Gráficos</a>
                    <a href="#" class="w3-bar-item w3-button">Relatórios</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-university"></i>&nbsp;Instituições</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="CADInstituicoes_Listagem.aspx" target="iframe" class="w3-bar-item w3-button">Cadastro</a>
                    <a href="#" class="w3-bar-item w3-button">Pesquisa</a>
                </div>
            </div>

            <a href="Home.aspx" target="iframe" class="w3-bar-item w3-btn w3-hover-green w3-right"><i class="fa fa-home"></i>&nbsp;Home</a>

        </div>
    </div>



    <!-- page content -->
    <div>
        <iframe src="Home.aspx" width="100%" height="550px" frameborder="0" name="iframe">Atualize seu Navegador!</iframe>
    </div>



    <!-- Footer -->
    <div class="w3-bottom">
        <div class="w3-bar w3-black">
            <div class="w3-left">
                <h6 class="w3-small"><i class="fa fa-user w3-small w3-text-green"></i>&nbsp;Usuário: <asp:Label ID="lblUser" runat="server" CssClass="w3-text-green"></asp:Label></h6>
            </div>
            <div class="w3-right">
                <h6 class="w3-small">Powered by:&nbsp;<img src="Imagens/inxell.jpg" /></h6>
            </div>
        </div>
    </div>

    <!-- Scripts Diversos -->
    <script type="text/javascript" src="Scripts/codePainel.js"></script>

</body>
</html>
