document.getElementById("input-disciplina").focus();

function SalvarRegistro() {

    //validações
    if (document.getElementById('input-disciplina').value == "0") {
        alert("Informe Nome da Disciplina");
        $("input-disciplina").focus();
        return;
    }
    if (document.getElementById('input-turma').value == "0") {
        alert("Informe Turma");
        $("input-disciplina").focus();
        return;
    }
    if (document.getElementById('input-periodo').value == "0") {
        alert("Informe Período");
        $("input-disciplina").focus();
        return;
    }
    if (document.getElementById('input_ano').value == "0") {
        alert("Ano Letivo Inválido. Verifique Parâmetros");
        $("input_ano").focus();
        return;
    }
    if (document.getElementById('input-nota').value == "0") {
        alert("Nota Máxima Inválida");
        $("input-nota").focus();
        return;
    }
    
    var strLine = "";
    var v1 = document.getElementById("IDInstHidden").value;
    strLine = strLine + "param0" + ":'" + v1 + "',";

    v1 = document.getElementById("input-disciplina").value;
    strLine = strLine + "param1" + ":'" + v1 + "',";

    v1 = document.getElementById("input-turma").value;
    strLine = strLine + "param2" + ":'" + v1 + "',";

    v1 = document.getElementById("input-periodo").value;
    strLine = strLine + "param3" + ":'" + v1 + "',";

    var e = document.getElementById("input-tipo");
    v1 = e.options[e.selectedIndex].text;
    strLine = strLine + "param4" + ":'" + v1 + "',";

    v1 = document.getElementById("input_dataAv").value;
    strLine = strLine + "param5" + ":'" + v1 + "',";

    v1 = document.getElementById("input-nota").value;
    strLine = strLine + "param6" + ":'" + v1 + "',";

    v1 = document.getElementById("input_ano").value;
    strLine = strLine + "param7" + ":'" + v1 + "'";
    
    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/AvaliacaoSalvar",
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
    if (document.getElementById('input-disciplina').value == "0") {
        alert("Informe Nome da Disciplina");
        $("input-disciplina").focus();
        return;
    }
    if (document.getElementById('input-turma').value == "0") {
        alert("Informe Turma");
        $("input-disciplina").focus();
        return;
    }
    if (document.getElementById('input-periodo').value == "0") {
        alert("Informe Período");
        $("input-disciplina").focus();
        return;
    }

    var strLine = "";
    var v1 = document.getElementById("IDAuxHidden").value;
    strLine = strLine + "param0" + ":'" + v1 + "',";

    v1 = document.getElementById("input-disciplina").value;
    strLine = strLine + "param1" + ":'" + v1 + "',";

    v1 = document.getElementById("input-turma").value;
    strLine = strLine + "param2" + ":'" + v1 + "',";

    v1 = document.getElementById("input-periodo").value;
    strLine = strLine + "param3" + ":'" + v1 + "',";

    var e = document.getElementById("input-tipo");
    v1 = e.options[e.selectedIndex].text;
    strLine = strLine + "param4" + ":'" + v1 + "',";

    v1 = document.getElementById("input_dataAv").value;
    strLine = strLine + "param5" + ":'" + v1 + "',";

    v1 = document.getElementById("input-nota").value;
    strLine = strLine + "param6" + ":'" + v1 + "'";

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/AvaliacaoAlterar",
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

function incluirNota() {

    //validações
    if (document.getElementById('input_alunos').value == "0") {
        alert("Informe Nome do Aluno");
        document.getElementById("input_alunos").focus();
        return;
    }
   
    var v1 = document.getElementById('IDAuxHidden').value;      // id_avaliacao
    var v2 = document.getElementById("input_alunos").value;     // id_aluno
    var v3 = document.getElementById("input-n").value;          // nota aluno

    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/IncluiAl",
        data: '{param0: "' + v1 + '", param1: "' + v2 + '", param2: "'  + v3 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            UIAguardar_Concluido();
            insertLinha();
        },
        failure: function (response) {
            UIAguardar_Concluido();
            alert(response.d);
        }
    });
}

function insertLinha() {

    var e = document.getElementById("input_alunos");
    var v5 = e.options[e.selectedIndex].value;
    var col1 = e.options[e.selectedIndex].text;

    var col2 = document.getElementById("input-n").value;

    var table = document.getElementById("MyTable");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);

    cell1.innerHTML = col1;
    cell2.innerHTML = col2;

    //apaga formulario
    document.getElementById('input_alunos').text = "";
    document.getElementById('input-n').valor = "";

}

function ExcluirAl(r, USerID) {

    var conf = confirm("Confirma Exclusão do Aluno?");
    if (conf == false) {
        return;
    }

    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/ExcluirAl",  
        data: '{param1: "' + USerID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // excluir linha do Table
            var i = r.parentNode.parentNode.rowIndex;
            document.getElementById("MyTable").deleteRow(i);
            UIAguardar_Concluido();
        },
        failure: function (response) {
            UIAguardar_Concluido();
            alert(response.d);
        }
    });


}


function UIAguardar() {

    var i, x;

    $("body").css("cursor", "progress");

    x = document.getElementsByClassName("btcontroles");
    for (i = 0; i < x.length; i++) {
        x[i].disabled = true;
    }

    x = document.getElementsByClassName("aguarde");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "block";
    }
}

function UIAguardar_Concluido() {

    var i, x;

    $("body").css("cursor", "default");

    x = document.getElementsByClassName("btcontroles");
    for (i = 0; i < x.length; i++) {
        x[i].disabled = false;
    }

    x = document.getElementsByClassName("aguarde");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
}

function classeBt2() {
    openLink(event, 'grupo2')
    $('#bt2').addClass(' w3-blue');
}

function btvoltar1() {
    openLink(event, 'grupo1')
    $('#bt1').addClass(' w3-blue');
}

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

function cancelar() {
    var linkurl = "Avaliacao_Listagem.aspx";
    window.location.href = linkurl;
}