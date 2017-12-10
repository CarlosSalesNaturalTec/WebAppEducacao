function cancelar() {

    $("body").css("cursor", "progress");
    document.getElementById("bt_saida").disabled = true;

    var linkurl = "Produtos_Listagem.aspx";
    window.location.href = linkurl;
}

function Estoque_Entrada() {

    //validações
    if (document.getElementById('input_quant').value == "") {
        alert("Informe Quantidade");
        document.getElementById("input_quant").focus();
        return;
    }
    if (document.getElementById('input_doc').value == "") {
        alert("Informe Numero do Documento");
        document.getElementById("input_doc").focus();
        return;
    }

    var v1 = document.getElementById("IDProdutoHidden").value;   // id do produto

    var e = document.getElementById("select_fornec")
    var v2 = e.options[e.selectedIndex].value           // ID do Fornecedor
    var v3 = e.options[e.selectedIndex].text            // Nome do FOrnecedor

    if (v2 == "0") {
        alert("Informe Fornecedor");
        document.getElementById("select_fornec").focus();
        return;
    }

    var v4 = document.getElementById("input_data").value;
    var v5 = document.getElementById("input_doc").value;
    var v6 = document.getElementById("input_quant").value;

    $("body").css("cursor", "progress");
    document.getElementById("BTEstoque_Entrada").disabled = true;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Estoque_Entrada",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var urlAux = "Produtos_Estoque.aspx?v1=" + v1;
            window.location.href = urlAux;
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function Estoque_Saida() {

    //validações
    if (document.getElementById('input_quant').value == "") {
        alert("Informe Quantidade");
        document.getElementById("input_quant").focus();
        return;
    }
    if (document.getElementById('input_doc').value == "") {
        alert("Informe Numero do Documento");
        document.getElementById("input_doc").focus();
        return;
    }
    if (document.getElementById('input_func').value == "0") {
        alert("Informe Responsável");
        document.getElementById("input_func").focus();
        return;
    }

    var v1 = document.getElementById("IDProdutoHidden").value;      // id do produto
    var v2 = document.getElementById("input_func").value;           // Responsável

    var v3 = document.getElementById("input_data").value;
    var v4 = document.getElementById("input_doc").value;
    var v5 = document.getElementById("input_quant").value;

    $("body").css("cursor", "progress");
    document.getElementById("bt_saida").disabled = true;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Estoque_Saida",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var urlAux = "Produtos_Estoque.aspx?v1=" + v1;
            window.location.href = urlAux;
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function Estoque_Excluir(idAux) {

    var v1 = document.getElementById("IDProdutoHidden").value;   // id do produto

    $("body").css("cursor", "progress");
    document.getElementById("bt_excluirEstoque").disabled = true;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Estoque_Excluir",
        data: '{param1: "' + idAux + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var urlAux = "Produtos_Estoque.aspx?v1=" + v1;
            window.location.href = urlAux;
        },
        failure: function (response) {
            alert(response.d);
        }
    });

}

function Excluir(IDExc) {
    document.getElementById('HiddenID').value = IDExc;
    document.getElementById('DivModal').style.display = "block";
}

function Excluir_cancel() {
    document.getElementById('DivModal').style.display = 'none';
}