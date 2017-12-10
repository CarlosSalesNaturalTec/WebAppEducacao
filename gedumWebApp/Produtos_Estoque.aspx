<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Produtos_Estoque.aspx.cs" Inherits="Produtos_Estoque" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Estoque de Produto</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- Paginação -->
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css" />

    <style>
        body {
            background-image: url("images/fundo.jpg");
            background-repeat: repeat;
            height: 100%;
        }
    </style>

</head>
<body>

    <!-- detalhes do Produto -->
    <div class="w3-container">
        <form class="form-horizontal">
            <fieldset>

                <!-- nome do Produto -->
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">
                    <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;<asp:Literal ID="Literal_Produto" runat="server"></asp:Literal></h3>
                        </div>
                </div>

                <div class="form-group">
                    <label for="input_tipo" class="col-md-1 control-label">Tipo</label>
                    <div class="col-md-3">
                        <input type="text" class="form-control" id="input_tipo" disabled>
                    </div>

                    <label for="input_und1" class="col-md-1 control-label">Unidade</label>
                    <div class="col-md-1">
                        <input type="text" class="form-control" id="input_und1" disabled>
                    </div>

                    <label for="input_estoqueAtual" class="col-md-1 control-label">Estoque Atual</label>
                    <div class="col-md-1">
                        <input type="number" class="w3-input w3-border w3-roud" id="input_estoqueAtual" disabled>
                    </div>
                    <div class="col-md-1">
                        <button type="button" class="w3-btn w3-block w3-round w3-border w3-light-green w3-hover-green" onclick="cancelar()">Voltar</button>
                    </div>
                </div>

            </fieldset>
        </form>
    </div>

    <hr />

    <!-- Lançar Movimento Entrada / Saida -->
    <div class="w3-container">
        <form class="form-horizontal">
            <fieldset>
                <div class="form-group">
                    <label for="input_data" class="col-md-1 control-label">Data</label>
                    <div class="col-md-2">
                        <input type="date" class="form-control" id="input_data">
                    </div>

                    <label for="input_quant" class="col-md-1 control-label">Quant.</label>
                    <div class="col-md-1">
                        <input type="number" class="form-control" id="input_quant">
                    </div>

                    <label for="input_doc" class="col-md-2 control-label">Documento</label>
                    <div class="col-md-2">
                        <input type="text" class="form-control" id="input_doc">
                    </div>
                </div>

                <div class="form-group">
                    <label for="select_fornec" class="col-md-1 control-label">ENTRADA</label>
                    <div class="col-md-4">
                        <select id="select_fornec" class="w3-select w3-round w3-border">
                            <asp:Literal ID="Literal_Fornec" runat="server"></asp:Literal>
                        </select>
                    </div>
                    <div class="col-md-1">
                        <button id="BTEstoque_Entrada" type="button" class="w3-btn w3-block w3-round w3-border w3-light-green w3-hover-green btcontroles" 
                            onclick="Estoque_Entrada()">Entrada</button>
                    </div>

                    <label for="input_func" class="col-md-1 control-label">SAÍDA</label>
                    <div class="col-md-4">
                        <input type="text" class="form-control" id="input_func" placeholder="Informe o Responsável pela Saida">
                    </div>
                    <div class="col-md-1">
                        <button type="button" id="bt_saida" class="w3-btn w3-block w3-round w3-border w3-light-green w3-hover-green btcontroles" 
                            onclick="Estoque_Saida()">Saida</button>
                    </div>

                </div>

            </fieldset>


        </form>
    </div>

    <hr />

    <!-- GRID Histórico Entradas e Saidas -->
    <div class="w3-container">
        <form class="form-horizontal">
            <fieldset>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">
                        <table id="tabela" class="w3-table-all w3-hoverable">
                            <thead>
                                <tr class="w3-grey">
                                    <th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data</th>
                                    <th>Documento</th>
                                    <th>Fornecedor/Responsável</th>
                                    <th>Entrada</th>
                                    <th>Saida</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="Literal_historico" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
            </fieldset>
        </form>
    </div>

    <!-- auxiliares -->
    <input id="IDProdutoHidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeProdutos_Estoque.js"></script>

    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script>

</body>
</html>
