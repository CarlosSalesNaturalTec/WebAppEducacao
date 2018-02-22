$('#input_periodo').focus();

function cancelar() {
    var url = "PeriodoAvaliacao_Listagem.aspx";
    window.location.href = url;
}

function SalvarRegistro() {
    if(document.getElementById('input_periodo') == " "){
        $('#input_periodo').focus(function(){
            alert("Selecione o Periodo");
            return;
    
        });
    }

    var x, i, strLine = "";
    x = document.getElementsByClassName('form-control');
    for (i = 0; i < x.length ; i++ ){
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    var vID = document.getElementById("IDInstHidden").value;
    strLine = strLine + "param" + i + ":'" + vID + "'";

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

function AlterarRegistro() {
    if (document.getElementById('input_periodo') == " ") {
        $('#input_periodo').focus(function () {
            alert("Selecione o Periodo");
            return;

        });
    }

    var x, i, strLine = "";
    x = document.getElementsByClassName('form-control');
    for (i = 0; i < x.length ; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    var vID = document.getElementById("IDInstHidden").value;
    strLine = strLine + "param" + i + ":'" + vID + "'";

    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/PeriodoAlterar",
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
