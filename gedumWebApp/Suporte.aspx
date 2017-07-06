<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Suporte.aspx.cs" Inherits="Suporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Suporte - Formulário de Contato</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</head>
<body>
    <br />
    <div class="w3-container w3-border w3-round w3-padding w3-center w3-light-green" style="margin-left: 2%; margin-right: 2%">
        <p><strong>Suporte - Entre em Contato</strong> </p>
    </div>
    <br />

    <form class="form-horizontal">
        <fieldset>
            <div class="form-group">
                <label for="input_nome" class="col-md-2 control-label">Nome</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="input_nome">
                </div>
            </div>

            <div class="form-group">
                <label for="input_nome" class="col-md-2 control-label">e-mail</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="input_email">
                </div>
            </div>

            <div class="form-group">
                <label for="input_nome" class="col-md-2 control-label">Mensagem</label>
                <div class="col-md-9">
                    <textarea class="form-control" rows="5" id="input_mensagem"></textarea>
                </div>
            </div>

            <!-- Botões Controle -->
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-9 w3-border w3-padding w3-round">
                    <p>
                        <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles">
                            <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Enviar</button>
                    </p>
                </div>
            </div>
            <!-- Botões Controle -->

        </fieldset>
    </form>


</body>
</html>
