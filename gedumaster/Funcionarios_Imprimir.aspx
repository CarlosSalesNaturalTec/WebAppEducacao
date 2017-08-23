<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Funcionarios_Imprimir.aspx.cs" Inherits="Funcionarios_Imprimir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Protocolo de Comparecimento</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Styles: W3, BootsStrap, Font-Awesome -->
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

</head>
<body style="margin-left: 2%; margin-right: 2%">

    <div class="w3-row w3-container w3-border w3-round w3-padding-16 w3-light-gray">
        <div id="Bloco1" class="w3-col s12 m12 l12 w3-padding">
            <div class="panel panel-success">
                <div class="panel-heading text-center">
                    <div id="logomarca"></div>
                    <br />
                    <p><b><span id="txtMunicipio"></span></b></p>
                    <p>Protocolo de Comparecimento</p>
                </div>
                <div class="panel-body" style="width: 100%; height: 250px; margin: 0 auto">
                    <p>
                        Certifico que o(a) servidor<b><span id="txtNome"></span></b>, portador(a) do cpf nº
                        <b><span id="txtCPF"></span></b> compareceu nesta data a fim de efetuar o seu recadastramento,
                        conforme determinação do Sr. Prefeito Municipal, cumprindo assim com todas as etapas
                        exigidas pela administração.
                    </p>
                    <br>
                    <p><span id="txtMunicipio2"></span>, <span id="txtData"></span></p> 
                    <br>
                    <p>__________________________________</p>
                    <p class="w3-small">Responsavel pelo recadastramento</p>
                </div>
            </div>
        </div>
    </div>

    <br /><br />

    <div class="w3-row w3-container w3-border w3-round w3-padding-16 w3-light-gray">
        <div id="Bloco1a" class="w3-col s12 m12 l12 w3-padding">
            <div class="panel panel-success">
                <div class="panel-heading text-center">
                    <div id="logomarca1a"></div>
                    <br />
                    <p><b><span id="txtMunicipio1a"></span></b></p>
                    <p>Protocolo de Comparecimento</p>
                </div>
                <div class="panel-body" style="width: 100%; height: 200px; margin: 0 auto">
                    <p>
                        Certifico que o(a) servidor<b><span id="txtNome1a"></span></b>, portador(a) do cpf nº
                        <b><span id="txtCPF1a"></span></b> compareceu nesta data a fim de efetuar o seu recadastramento,
                        conforme determinação do Sr. Prefeito Municipal, cumprindo assim com todas as etapas
                        exigidas pela administração.
                    </p>
                    <br>
                    <p><span id="txtMunicipio21a"></span>, <span id="txtData1a"></span></p> 
                    <br>
                    <p>__________________________________</p>
                    <p class="w3-small">Responsavel pelo recadastramento</p>
                </div>
            </div>
        </div>
    </div>

    <!-- auxiliares -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

</body>
</html>
