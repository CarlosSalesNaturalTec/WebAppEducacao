﻿document.getElementById("input_ano_letivo").focus();

function AlterarRegistro() {

    //validações
    if (document.getElementById('input_ano_letivo').value == "") {
        alert("Informe Ano Letivo");   
        document.getElementById("input_ana_letivo").focus();
        return;
    }

    var strLine = "";
    // ano_letivo
    var v1 = document.getElementById("input_ano_letivo").value;
    strLine = strLine + "param1" + ":'" + v1 + "',";

    // matrícula
    var v2 = document.getElementById("input_matricula").value;
    strLine = strLine + "param2" + ":'" + v2 + "',";

    // Pré - Matrícula
    var v3 = document.getElementById("input_permite_pre").value;
    strLine = strLine + "param3" + ":'" + v3 + "',";

    // id iNSTITUIÇÃO
    var v4 = document.getElementById("IDInstHidden").value;
    strLine = strLine + "param4" + ":'" + v4 + "'";

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/ParametroAlterar",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var linkurl = response.d;
            window.location.href = linkurl;
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}


function cancelar() {
    var linkurl = "home.aspx";   
    window.location.href = linkurl;
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
//Menu
function openLink(evt, animName) {
    var i, x, tablinks;
    x = document.getElementsByClassName("grupo");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < x.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" w3-blue", "");
    }
    document.getElementById(animName).style.display = "block";
    evt.currentTarget.className += " w3-blue";
}
