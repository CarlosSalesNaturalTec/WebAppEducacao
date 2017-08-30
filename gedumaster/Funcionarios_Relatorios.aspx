<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Funcionarios_Relatorios.aspx.cs" Inherits="Funcionarios_Relatorios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Relatório de Funcionários</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Styles: W3, BootsStrap, Font-Awesome -->
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body style="margin-left: 2%; margin-right: 2%">
    <br />

    <!-- Linha 1-->
    <div class="w3-row w3-container w3-border w3-round w3-padding-16 w3-light-gray">

        <!-- Bloco 1 -->
        <div id="Bloco1" class="w3-col s12 m12 l12 w3-padding">
            <div class="panel panel-success">
                <div class="panel-heading text-center">
                    <h4 class="panel-title w3-small">RELATÓRIO DE FUNCIONÁRIOS</h4>
                </div>

                <div class="panel-body">

                    <div class="form-group">
                        <label for="input_lotado" class="col-md-1 control-label">Secretaria</label>
                        <div class="col-md-6">
                            <select class="form-control" id="input_lotado">
                                <option value="Todas">Todas</option>
                                <option value="Secretaria Municipal de Turismo">Secretaria Municipal de Turismo</option>
                                <option value="Secretaria Municipal de Saúde">Secretaria Municipal de Saúde</option>
                                <option value="Secretaria Municipal de Obras">Secretaria Municipal de Obras</option>
                                <option value="Secretaria Municipal de Meio Ambiente">Secretaria Municipal de Meio Ambiente</option>
                                <option value="Secretaria Municipal de Educação">Secretaria Municipal de Educação</option>
                                <option value="Secretaria Municipal de Finanças">Secretaria Municipal de Finanças</option>
                                <option value="Secretaria Municipal de Assistência Social">Secretaria Municipal de Assistência Social</option>
                                <option value="Secretaria Municipal de Agricultura">Secretaria Municipal de Agricultura</option>
                                <option value="Secretaria Municipal de Administração">Secretaria Municipal de Administração</option>
                                <option value="Gabinete do Prefeito">Gabinete do Prefeito</option>
                            </select>
                        </div>
                        <div class="col-md-1">
                            <a href="#" onclick="window.open('Funcionarios_Relatorios_PDF','_blank');" class="btn btn-block btn-default"><i class="fa fa-print"></i></a>
                        </div>
                    </div>

                     <br />

                    <div class="form-group">
                        <label for="input_Inst" class="col-md-1 control-label">Instituição</label>
                        <div class="col-md-6">
                            <select class="form-control" id="input_Inst">
                                <option value="Todas">Todas</option>
                            </select>
                        </div>
                        <div class="col-md-1">
                            <a href="#" onclick="" class="btn btn-block btn-default"><i class="fa fa-print"></i></a>
                        </div>
                    </div>

                    <br />

                    <div class="form-group">
                        <label for="input_etnia" class="col-md-1 control-label">Etnia</label>
                        <div class="col-md-6">
                            <select class="form-control" id="input_etnia">
                                <option value="Todas">Todas</option>
                                <option value="Branco">Branco</option>
                                <option value="Negro">Negro</option>
                                <option value="Pardo">Pardo</option>
                                <option value="Mulato">Mulato</option>
                                <option value="Amarelo">Amarelo</option>
                                <option value="Indígena">Indígena</option>
                                <option value="Quilombola">Quilombola</option>
                            </select>
                        </div>
                        <div class="col-md-1">
                            <a href="#" onclick="" class="btn btn-block btn-default"><i class="fa fa-print"></i></a>
                        </div>
                    </div>

                    <br />

                </div>
            </div>
        </div>
    </div>

</body>


</html>
