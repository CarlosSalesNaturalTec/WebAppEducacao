<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CADInstituicoes_Ficha.aspx.cs" Inherits="CADInstituicoes_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Ficha de Instituição</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
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
        body{
            background-image: url("Imagens/fundo1.jpg");
        }
    </style>

</head>

<body>

    <div>
        <header class="w3-container w3-green w3-center w3-padding-small">
            <h4><strong>Ficha de Instituição</strong></h4>
        </header>
    </div>

    <br />

    <form class="form-horizontal">
        <fieldset>

            <legend></legend>

            <div class="form-group">
                <label for="input1" class="col-md-1 control-label">Nome</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="input1" disabled>
                </div>
            </div>

            <div class="form-group">
                <label for="input2" class="col-md-1 control-label">Diretor</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="input2" disabled>
                </div>
            </div>

            <div class="form-group">
                <label for="input3" class="col-md-1 control-label">E-mail</label>
                <div class="col-md-5">
                    <input type="email" class="form-control" id="input3" disabled>
                </div>

                <label for="input4" class="col-md-1 control-label">Telefone</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="input4" disabled>
                </div>
            </div>

            <div class="form-group">
                <label for="input5" class="col-md-1 control-label">UF</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="input5" disabled>
                </div>
                <label for="input6" class="col-md-1 control-label">Cidade</label>
                <div class="col-md-6">
                    <input type="text" class="form-control" id="input6" disabled>
                </div>
            </div>

            <hr />

            <div class="form-group">
                <div id="btsDefault" class="col-md-6 col-md-offset-1">
                    <button type="button" class="w3-btn w3-red w3-round-large w3-border" onclick="cancelar()">CANCELAR</button>&nbsp;&nbsp;&nbsp;
                    <button type="button" class="w3-btn w3-blue w3-round-large w3-border" onclick="" id="btSenha">ALTERAR SENHA</button>&nbsp;&nbsp;&nbsp;
                    <button type="button" class="w3-btn w3-green w3-round-large w3-border" onclick="AlterarREgistro()" id="btSalvar">&nbsp;&nbsp;&nbsp;ALTERAR&nbsp;&nbsp;&nbsp;</button>&nbsp;&nbsp;&nbsp;
                </div>

                <div id="btsALterar" style="display: none" class="col-md-6 col-md-offset-1">
                    <button type="button" class="w3-btn w3-gray w3-round-large" onclick="cancelar()">CANCELAR</button>&nbsp;&nbsp;&nbsp;
                    <button type="button" class="w3-btn w3-green w3-round-large" onclick="AlterarSalvar()" id="btSalvarAltera">&nbsp;&nbsp;&nbsp;SALVAR&nbsp;&nbsp;&nbsp;</button>
                </div>

            </div>

            <hr />


        </fieldset>
    </form>

     <!-- auxiliares -->
    <input id="IDHidden" name="IDHidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts diversos  -->
    <script type="text/javascript" src="Scripts/codeInstituicaoNova.js"></script>

</body>

</html>
