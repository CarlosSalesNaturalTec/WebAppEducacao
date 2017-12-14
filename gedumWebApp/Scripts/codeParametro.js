document.getElementById("input_param").focus();

function SalvarRegistro() {

    //validações
    if (document.getElementById('input_param').value == "") {
        alert("Informe Ano Letivo");   //<!--*******Customize AQUI*******-->
        document.getElementById("input_param").focus();
        return;
    }

    // id
    var v1 = document.getElementById("input_ana_letivo").value;
    strLine = strLine + "param1" + ":'" + vID + "',";

    var v2 = document.getElementById("input_matricula").value;
    strLine = strLine + "param1" + ":'" + v2 + "'";


    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/ParametroSalvar",
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
    if (document.getElementById('input_param').value == "") {
        alert("Informe Ano Letivo");   //<!--*******Customize AQUI*******-->
        document.getElementById("input_param").focus();
        return;
    }

    var strLine = "";
    // ano_letivo
    var vID = document.getElementById("input_param").value;
    strLine = strLine + "param1" + ":'" + vID + "'";

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
