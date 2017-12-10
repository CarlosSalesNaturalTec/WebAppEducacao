document.getElementById("input_aluno").focus();

function SalvarRegistro() {

    var e = document.getElementById("input_aluno")
    var v1 = e.options[e.selectedIndex].value           // ID do Aluno
    var v2 = e.options[e.selectedIndex].text            // Nome do Aluno
    if (v1 == "0") {
        alert("Informe Nome do Aluno");
        document.getElementById("input_aluno").focus();
        return;
    }

    var e = document.getElementById("input_livro")
    var v3 = e.options[e.selectedIndex].value           // ID do Livro
    var v4 = e.options[e.selectedIndex].text            // Nome do Livro
    if (v3 == "0") {
        alert("Informe Nome do Livro");
        document.getElementById("input_livro").focus();
        return;
    }

    var v5 = "0";                                                   //ID Funcionario
    var v6 = document.getElementById("input_funcionario").value;    // Nome Funcionario
    if (v6 == "") {
        alert("Informe Nome do Funcionário");
        document.getElementById("input_funcionario").focus();
        return;
    }

    var v7 = document.getElementById("input_data").value;

    var v8 = document.getElementById("IDInstHidden").value;     //ID Indtituição

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/EmprestimosSalvar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
            '", param6: "' + v6 + '", param7: "' + v7 + '", param8: "' + v8 + '"}',
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

    var e = document.getElementById("input_aluno")
    var v1 = e.options[e.selectedIndex].value           // ID do Aluno
    var v2 = e.options[e.selectedIndex].text            // Nome do Aluno
    if (v1 == "0") {
        alert("Informe Nome do Aluno");
        document.getElementById("input_aluno").focus();
        return;
    }

    var e = document.getElementById("input_livro")
    var v3 = e.options[e.selectedIndex].value           // ID do Livro
    var v4 = e.options[e.selectedIndex].text            // Nome do Livro
    if (v3 == "0") {
        alert("Informe Nome do Livro");
        document.getElementById("input_livro").focus();
        return;
    }

    var v5 = "0";                                                   //ID Funcionario
    var v6 = document.getElementById("input_funcionario").value;    // Nome Funcionario
    if (v6 == "") {
        alert("Informe Nome do Funcionário");
        document.getElementById("input_funcionario").focus();
        return;
    }

    var v7 = document.getElementById("input_data").value;           // Data do emprestimo
    var v8 = document.getElementById("input_data_dev").value;       // Data Devolucao

    var v9 = document.getElementById("IDAuxHidden").value;      // ID Emprestimo

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/EmprestimosAlterar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
             '", param6: "' + v6 + '", param7: "' + v7 + '", param8: "' + v8 + '", param9: "' + v9 + '"}',
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
    var linkurl = "Emprestimos_Listagem.aspx";   
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
