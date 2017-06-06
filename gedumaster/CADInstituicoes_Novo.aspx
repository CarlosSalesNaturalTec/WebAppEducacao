﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CADInstituicoes_Novo.aspx.cs" Inherits="CADInstituicoes_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Cadastro de Nova Instituição</title>
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
        body {
            background-image: url("Imagens/fundo1.jpg");
        }
    </style>

</head>

<body>

    <div>
        <header class="w3-container w3-green w3-center w3-padding-small">
            <h4><strong>Nova Instituição</strong></h4>
        </header>
    </div>

    <br />

    <form class="form-horizontal">
        <fieldset>

            <div class="form-group">
                <label for="input1" class="col-md-1 control-label">Nome</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="input1">
                </div>
            </div>

            <div class="form-group">
                <label for="input2" class="col-md-1 control-label">Diretor</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="input2">
                </div>
            </div>

            <div class="form-group">
                <label for="input3" class="col-md-1 control-label">E-mail</label>
                <div class="col-md-5">
                    <input type="email" class="form-control" id="input3">
                </div>

                <label for="input4" class="col-md-1 control-label">Telefone</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="input4">
                </div>
            </div>

            <div class="form-group">
                <label for="input5" class="col-md-1 control-label">UF</label>
                <div class="col-md-2">
                    <select id="input5" class="w3-select w3-border" name="option">
                        <option value="" disabled selected>Selecione</option>
                        <option value="1">BA</option>
                        <option value="2">PE</option>
                        <option value="3">SP</option>
                    </select>
                </div>
                <label for="input6" class="col-md-1 control-label">Cidade</label>
                <div class="col-md-6">
                    <input type="text" class="form-control" id="input6">
                </div>
            </div>

            <div class="form-group">
                <label for="input7" class="col-md-1 control-label">Usuario</label>
                <div class="col-md-5">
                    <input type="text" class="form-control" id="input7" placeholder="Acesso ao Painel de Controle">
                </div>

                <label for="input8" class="col-md-1 control-label">Senha</label>
                <div class="col-md-3">
                    <input type="password" class="form-control" id="input8">
                </div>
            </div>

            <hr />

            <div class="form-group">
                <div class="col-md-3 col-md-offset-1">
                    <button type="button" class="w3-btn w3-red w3-round-large" onclick="cancelar()">CANCELAR</button>&nbsp;&nbsp;&nbsp;
                    <button type="button" class="w3-btn w3-green w3-round-large" onclick="SalvarRegistro()" id="btSalvar">&nbsp;&nbsp;&nbsp;SALVAR&nbsp;&nbsp;&nbsp;</button>
                </div>
            </div>

            <hr />


        </fieldset>
    </form>

    <!-- Scripts diversos  -->
    <script type="text/javascript" src="Scripts/codeInstituicaoNova.js"></script>

</body>

</html>
