function cancelar() {
    var linkurl = "Produtos_Listagem.aspx";
    window.location.href = linkurl;
}

function Estoque_Entrada() {
    
    var v1 = document.getElementById("IDProdutoHidden").value;   // id do produto

    var e = document.getElementById("select_fornec")
    var v2 = e.options[e.selectedIndex].value           // ID do Fornecedor
    var v3 = e.options[e.selectedIndex].text            // Nome do FOrnecedor

    var v4 = document.getElementById("input_data").value;
    var v5 = document.getElementById("input_doc").value;
    var v6 = document.getElementById("input_quant").value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Estoque_Entrada",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            window.location.href = response.d;
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}