$('#input_periodo').focus();

function cancelar() {
    var url = "PeriodoAvaliacao_Listagem.aspx";
    window.location.href = url;
}

function SalvarRegistro() {

    if (document.getElementById('input_periodo') == "") {
        $('#input_periodo').focus(function () {
            alert("Selecione o Periodo");
            return;
        });
    }

    var strLine = "";
    var v1 = document.getElementById("input_periodo").value;
    strLine = strLine + "param0" + ":'" + v1 + "',";

    var vID = document.getElementById("IDInstHidden").value;
    strLine = strLine + "param1" + ":'" + vID + "'";

    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/PeriodoSalvar",
        data: '{' + strLine + '}',
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


function UIAguardar() {
    var i, x;

    x = document.getElementsByClassName("btcontroles");
    for (i = 0; i < x.length; i++) {
        x[i].disabled = true;
    }

    x = document.getElementsByClassName("aguarde");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "block";
    }
}


