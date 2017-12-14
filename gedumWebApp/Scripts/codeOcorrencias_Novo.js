document.getElementById("input_funcionario").focus();

function SalvarRegistro() {

    var cobFunc = document.getElementById("input_funcionario")
    var v1 = cobFunc.options[cobFunc.selectedIndex].value;
    // var v2 = document.getElementById("input_funcionario").value;    // Nome Funcionario
    if (v1 == "") {
        alert("Informe Nome do Funcionário");
        document.getElementById("input_funcionario").focus();
        return;
    }

    var cobAluno = document.getElementById("input_aluno")
    var v2 = cobAluno.options[cobAluno.selectedIndex].value           // ID do Aluno
    //var v2 = e.options[e.selectedIndex].text            // Nome do Aluno
    if (v2 == "0") {
        alert("Informe Nome do Aluno");
        document.getElementById("input_aluno").focus();
        return;
    }

    var v3 = document.getElementById("input_data_ocorrencia").value;
    var v4 = document.getElementById("input_tipo_ocorrencia").value;
    var v5 = document.getElementById("input_desc_ocorrencia").value;
    var v6 = document.getElementById("IDInstHidden").value;     //ID Indtituição

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/OcorrenciasSalvar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
            '", param6: "' + v6 + '"}',
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

    var cobFunc = document.getElementById("input_funcionario")
    var v1 = cobFunc.options[cobFunc.selectedIndex].value;
    // var v2 = document.getElementById("input_funcionario").value;    // Nome Funcionario
    if (v1 == "") {
        alert("Informe Nome do Funcionário");
        document.getElementById("input_funcionario").focus();
        return;
    }

    var cobAluno = document.getElementById("input_aluno")
    var v2 = cobAluno.options[cobAluno.selectedIndex].value           // ID do Aluno
    //var v2 = e.options[e.selectedIndex].text            // Nome do Aluno
    if (v2 == "0") {
        alert("Informe Nome do Aluno");
        document.getElementById("input_aluno").focus();
        return;
    }

    var v3 = document.getElementById("input_data_ocorrencia").value;
    var v4 = document.getElementById("input_tipo_ocorrencia").value;
    var v5 = document.getElementById("input_desc_ocorrencia").value;
    //var v6 = document.getElementById("IDInstHidden").value;     //ID Indtituição
    var v6 = document.getElementById("IDAuxHidden").value;      // ID Emprestimo

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/OcorrenciasAlterar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
             '", param6: "' + v6 + '"}',
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
    var linkurl = "Ocorrencias_Listagem.aspx";
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
