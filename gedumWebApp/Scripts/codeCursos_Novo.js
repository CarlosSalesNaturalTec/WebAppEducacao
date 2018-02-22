﻿document.getElementById("input_nome").focus();

function SalvarRegistro() {

    //validações
    if (document.getElementById('input_nome').value == "") {
        alert("Informe Nome do Curso");
        document.getElementById("input_nome").focus();
        return;
    }

    //pega o valor de cada campo e constroi string com todos
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    // id
    var vID = document.getElementById("IDInstHidden").value;
    strLine = strLine + "param" + i + ":'" + vID + "'";

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/CursosSalvar",
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
    if (document.getElementById('input_nome').value == "") {
        alert("Informe Nome do Curso");
        document.getElementById("input_nome").focus();
        return;
    }

    //pega o valor de cada campo e constroi string com todos
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    // id
    var vID = document.getElementById("IDInstHidden").value;
    strLine = strLine + "param" + i + ":'" + vID + "'";

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/CursosAlterar",
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
    var linkurl = "Cursos_Listagem.aspx";
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


function btvoltar1() {
    openLink(event, 'grupo1')
    $('#bt1').addClass(' w3-blue');
}




function IncluirDisciplina() {

    if (document.getElementById('input_disc').value == " ") {
        alert("Informe Nome da Disciplina");
        document.getElementById("input_disc").focus();
        return;
    }

    var v1 = document.getElementById('IDInstHidden').value; // id_curso
    var v2 = document.getElementById("input_disc").value;   // id_disciplina

    $.ajax({
        type: "POST",
        url: "WebService.asmx/IncluiDisc",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '"}',
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
        
        var table = document.getElementById("MyTable");

        var row = table.insertRow(-1);
        var cell1 = row.insertCell(0);
        
        cell1.innerHTML = col1;
        
        //apaga formulario
        document.getElementById('input_disc').text = "";
        
    }


    function ExcluirDisc(r, USerID) {

        var conf = confirm("Confirma Exclusão da Disciplina?");
        if (conf == false) {
            return;
        }

        $.ajax({
            type: "POST",
            url: "WebService.asmx/ExcluirDisc",  //<!--*******Customização*******-->
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



