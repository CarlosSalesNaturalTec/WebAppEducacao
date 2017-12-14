document.getElementById("input_aluno").focus();

function SalvarRegistro() {

    var cobAluno = document.getElementById("input_aluno")
    var v1 = cobAluno.options[cobAluno.selectedIndex].value     // ID do Aluno
    // var v2 = e.options[e.selectedIndex].text            // Nome do Aluno
    if (v1 == "0") {
        alert("Informe Nome do Aluno");
        document.getElementById("input_aluno").focus();
        return;
    }

    var v2 = document.getElementById("input_dataAtestado").value;
    var v3 = document.getElementById("input_obs").value;
    var v4 = document.getElementById("IDInstHidden").value;     //ID Indtituição

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/AtestadosSalvar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '"}',
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

    var cobAluno = document.getElementById("input_aluno")
    var v1 = cobAluno.options[cobAluno.selectedIndex].value     // ID do Aluno
    // var v2 = e.options[e.selectedIndex].text            // Nome do Aluno
    if (v1 == "0") {
        alert("Informe Nome do Aluno");
        document.getElementById("input_aluno").focus();
        return;
    }

    var v2 = document.getElementById("input_dataAtestado").value;
    var v3 = document.getElementById("input_obs").value;
    // var v4 = document.getElementById("IDInstHidden").value;     //ID Indtituição
    var v4 = document.getElementById("IDAuxHidden").value;      // ID Atestados

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/AtestadosAlterar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '"}',
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
    var linkurl = "Atestados_Listagem.aspx";   
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
