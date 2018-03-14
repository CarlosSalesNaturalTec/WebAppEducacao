document.getElementById("input-disciplina").focus();



function cancelar() {
    var linkurl = "Avaliacao_Listagem.aspx";
    window.location.href = linkurl;
}

function SalvarRegistro() {

    //validações
    if (document.getElementById('input-disciplina').value == "") {
        alert("Informe Nome do Curso");
        $("input_disciplina").focus();
        return;
    }

    var e = document.getElementById("input-disciplina");
    var v1 = e.options[e.selectedIndex].value;
    var v2 = e.options[e.selectedIndex].text;

    var Z = document.getElementById("input-turma");
    var v3 = Z.options[Z.selectedIndex].value;
    var v4 = Z.options[Z.selectedIndex].text;

    var v5 = document.getElementById('input-tipo').value;

    var d = document.getElementById('input-periodo');
    var v61 = d.options[d.selectedIndex].value;
    var v6 = d.options[d.selectedIndex].text;

    var v7 = document.getElementById('input_dataAv').value;

    var v8 = document.getElementById('input-nota').value;

    var vID = document.getElementById("IDInstHidden").value;
    
    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/AvaliacaoSalvar",
        data: '{param0: "' + v2 + '", param1: "' + v4 + '", param2: "' + v5 + '", param3: "' + v6 + '", param4: "' + v7 +
            '", param5: "' + v8 + '", param6: "' + vID + '"}',
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
    if (document.getElementById('input-disciplina').value == "") {
        alert("Informe Nome do Curso");
        $("input_disciplina").focus();
        return;
    }

    var e = document.getElementById("input-disciplina");
    var v1 = e.options[e.selectedIndex].value;
    var v2 = e.options[e.selectedIndex].text;

    var Z = document.getElementById("input-turma");
    var v3 = Z.options[Z.selectedIndex].value;
    var v4 = Z.options[Z.selectedIndex].text;

    var v5 = document.getElementById('input-tipo').value;

    
    var d = document.getElementById('input-periodo');
    var v61 = d.options[d.selectedIndex].value;
    var v6 = d.options[d.selectedIndex].text;

    var v7 = document.getElementById('input_dataAv').value;

    var v8 = document.getElementById('input-nota').value;

    var vID = document.getElementById("IDInstHidden").value;

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/AvaliacaoAlterar",
        data: '{param0: "' + v2 + '", param1: "' + v4 + '", param2: "' + v5 + '", param3: "' + v6 + '", param4: "' + v7 +
            '", param5: "' + v8 + '", param6: "' + vID + '"}',
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

    if (document.getElementById('input_alunos').value == " ") {
        alert("Informe Nome do Aluno");
        document.getElementById("input_alunos").focus();
        return;
    }

    var v1 = document.getElementById('IDInstHidden').value; // id_avaliacao
    var v2 = document.getElementById("input_alunos").value;   // id_aluno
    var v3 = document.getElementById("input-n").value; // nota_aluno

    $.ajax({
        type: "POST",
        url: "WebService.asmx/IncluiAl",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "'  + v3 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            insertLinha();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function insertLinha() {


    var e = document.getElementById("input_disc");
    var v5 = e.options[e.selectedIndex].value;
    var col1 = e.options[e.selectedIndex].text;

    var col2 = document.getElementById("input-n")

    var table = document.getElementById("MyTable");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);

    cell1.innerHTML = col1;
    cell2.innerHTML = col2;

    //apaga formulario
    document.getElementById('input_disc').text = "";
    document.getElementById('input-n').text = "";

}


function ExcluirDisc(r, USerID) {

    var conf = confirm("Confirma Exclusão do Aluno?");
    if (conf == false) {
        return;
    }

    $.ajax({
        type: "POST",
        url: "WebService.asmx/ExcluirAl",  //<!--*******Customização*******-->
        data: '{param1: "' + USerID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // excluir linha do Table
            var i = r.parentNode.parentNode.rowIndex;
            document.getElementById("MyTable").deleteRow(i);
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

