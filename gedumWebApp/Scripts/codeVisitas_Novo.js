﻿document.getElementById("input1").focus();

function SalvarRegistro() {

    //validações
    if (document.getElementById('input1').value == "") {
        alert("Informe Nome do Visitante");   //<!--*******Customização*******-->
        openLink(event, 'grupo1')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input1").focus();  //<!--*******Customização*******-->
        return;
    }

    //pega o valor de cada campo e constroi string com todos  
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    var idPai = document.getElementById('IDAuxHidden').value;
    strLine = strLine + "param" + i + ":'" + idPai + "'";

    //UI - exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/VisitasSalvar",  //<!--*******Customização*******-->
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

    //validações
    if (document.getElementById('input1').value == "") {
        alert("Informe Nome do Visitante");   //<!--*******Customização******-->
        openLink(event, 'grupo1')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input1").focus();  //<!--*******Customização******-->
        return;
    }

    //pega o valor de cada campo e constroi string com todos  
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    var idAux = document.getElementById('IDAuxHidden').value;
    strLine = strLine + "param" + i + ":'" + idAux + "'";

    //UI - exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/VisitasAlterar",   //<!--*******Customização*******-->
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
    var linkurl = "Visitas_Listagem.aspx";   //<!--*******Customização*******-->
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

function classeBt2() {
    openLink(event, 'grupo2')
    $('#bt2').addClass(' w3-blue');
}
function classeBt3() {
    openLink(event, 'grupo3')
    $('#bt3').addClass(' w3-blue');
}
function classeBt4() {
    openLink(event, 'grupo4')
    $('#bt4').addClass(' w3-blue');
}
function classeBt5() {
    openLink(event, 'grupo5')
    $('#bt5').addClass(' w3-blue');
}
function classeBt6() {
    openLink(event, 'grupo6')
    $('#bt6').addClass(' w3-blue');
}
function classeBt7() {
    openLink(event, 'grupo7')
    $('#bt7').addClass(' w3-blue');
}
function classeBt8() {
    openLink(event, 'grupo8')
    $('#bt8').addClass(' w3-blue');
}
function classeBt9() {
    openLink(event, 'grupo9')
    $('#bt9').addClass(' w3-blue');
}
function classeBt10() {
    openLink(event, 'grupo10')
    $('#bt10').addClass(' w3-blue');
}

function btvoltar1() {
    openLink(event, 'grupo1')
    $('#bt1').addClass(' w3-blue');
}
function btvoltar2() {
    openLink(event, 'grupo2')
    $('#bt2').addClass(' w3-blue');
}
function btvoltar3() {
    openLink(event, 'grupo3')
    $('#bt3').addClass(' w3-blue');
}
function btvoltar4() {
    openLink(event, 'grupo4')
    $('#bt4').addClass(' w3-blue');
}
function btvoltar5() {
    openLink(event, 'grupo5')
    $('#bt5').addClass(' w3-blue');
}
function btvoltar6() {
    openLink(event, 'grupo6')
    $('#bt6').addClass(' w3-blue');
}
function btvoltar7() {
    openLink(event, 'grupo7')
    $('#bt7').addClass(' w3-blue');
}
function btvoltar8() {
    openLink(event, 'grupo8')
    $('#bt8').addClass(' w3-blue');
}
function btvoltar9() {
    openLink(event, 'grupo9')
    $('#bt9').addClass(' w3-blue');
}