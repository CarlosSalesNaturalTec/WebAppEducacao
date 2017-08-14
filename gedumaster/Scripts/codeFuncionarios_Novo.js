﻿document.getElementById("input_nome").focus();

function SalvarRegistro() {

    //validações
    if (document.getElementById('input_nome').value == "") {
        alert("Informe Nome do Funcionário");   //<!--*******Customize AQUI*******-->
        openLink(event, 'grupo1')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input_nome").focus();
        return;
    }

    //pega o valor de cada campo e constroi string com todos
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }
    
    //id Municipio
    var idInst = document.getElementById('IDInstHidden').value;
    strLine = strLine + "param" + i + ":'" + idInst + "',";

    // foto
    var foto = document.getElementById('Hidden1').value;
    i++;
    strLine = strLine + "param" + i + ":'" + foto + "'";

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/FuncionariosSalvar",
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
        alert("Informe Nome do Funcionário");   //<!--*******Customize AQUI*******-->
        openLink(event, 'grupo1')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input_nome").focus();
        return;
    }

    //pega o valor de cada campo e constroi string com todos
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }
    
    // foto
    var foto = document.getElementById('Hidden1').value;
    strLine = strLine + "param" + i + ":'" + foto + "',";

    // id funcionario
    var vID = document.getElementById("IDHidden").value;
    i++;
    strLine = strLine + "param" + i + ":'" + vID + "'";
    
    //exibir animações - aguarde...
    UIAguardar();
    
    $.ajax({
        type: "POST",
        url: "WebService.asmx/FuncionariosAlterar",
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

function DependenteIncluir() {

    //validações
    //<!--*******Customização*******-->
    if (document.getElementById('input_DEPNome').value == "") {
        alert("Informe Nome do Dependente");  
        document.getElementById("input_DEPNome").focus(); 
        return;
    }

    var v1 = document.getElementById('IDHidden').value;
    var v2 = document.getElementById("input_DEPNome").value;
    var v3 = document.getElementById("input_DEPparent").value;
    var v4 = document.getElementById("input_DEPNasc").value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/FuncionariosNewDep",  //<!--*******Customização*******-->
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            DependenteInsertLinha();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function DependenteExcluir(r, USerID) {

    var conf = confirm("Confirma Exclusão de Dependente?");
    if (conf == false) {
        return;
    }

    $.ajax({
        type: "POST",
        url: "WebService.asmx/FuncionariosDelDep",  //<!--*******Customização*******-->
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

function DependenteInsertLinha() {

    var col1 = document.getElementById('input_DEPNome').value;
    var col2 = document.getElementById('input_DEPparent').value;
    var col3 = document.getElementById('input_DEPNasc').value;

    var table = document.getElementById("MyTable");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);

    cell1.innerHTML = col1;
    cell2.innerHTML = col2;
    cell3.innerHTML = col3;

    //apaga formulario
    document.getElementById('input_DEPNome').value = "";
    document.getElementById('input_DEPparent').value = "";
    document.getElementById('input_DEPNasc').value = "";

}

function BeneficioIncluir() {

    //validações
    //<!--*******Customização*******-->
    if (document.getElementById('input_BEnefNome').value == "") {
        alert("Informe nome do Beneficio");
        document.getElementById("input_BEnefNome").focus();
        return;
    }

    var v1 = document.getElementById('IDHidden').value;
    var v2 = document.getElementById("input_BEnefNome").value;
    var v3 = document.getElementById("input_BenefSituac").value;
    var v4 = document.getElementById("input_BenefInicio").value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/FuncionariosNewBenef",  //<!--*******Customização*******-->
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            BeneficioInsertLinha();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function BeneficioExcluir(r, USerID) {

    var conf = confirm("Confirma Exclusão de Benefício?");
    if (conf == false) {
        return;
    }

    $.ajax({
        type: "POST",
        url: "WebService.asmx/FuncionariosDelBenef",  
        data: '{param1: "' + USerID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // excluir linha do Table
            var i = r.parentNode.parentNode.rowIndex;
            document.getElementById("TableBenef").deleteRow(i);
        },
        failure: function (response) {
            alert(response.d);
        }
    });


}

function BeneficioInsertLinha() {

    var col1 = document.getElementById('input_BEnefNome').value;
    var col2 = document.getElementById('input_BenefSituac').value;
    var col3 = document.getElementById('input_BenefInicio').value;

    var table = document.getElementById("TableBenef");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);

    cell1.innerHTML = col1;
    cell2.innerHTML = col2;
    cell3.innerHTML = col3;

    //apaga formulario
    document.getElementById('input_BEnefNome').value = "";
    document.getElementById('input_BenefSituac').value = "";
    document.getElementById('input_BenefInicio').value = "";

}

function CargaHIncluir() {

    //validações
    //<!--*******Customização*******-->
    if (document.getElementById('input_DiaSem').value == "") {
        alert("Informe Dia da Semana");
        document.getElementById("input_DiaSem").focus();
        return;
    }

    var v1 = document.getElementById('IDHidden').value;
    var v2 = document.getElementById("input_DiaSem").value;
    var v3 = document.getElementById("input_Turno").value;
    var v4 = document.getElementById("input_Entrada").value;
    var v5 = document.getElementById("input_Saida").value;
    var v6 = document.getElementById("input_Descanso").value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/FuncionariosNewCargaH",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            CargaHInsertLinha();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function CargaHExcluir(r, USerID) {

    var conf = confirm("Confirma Exclusão de Carga Horária?");
    if (conf == false) {
        return;
    }

    $.ajax({
        type: "POST",
        url: "WebService.asmx/FuncionariosDelCargaH",
        data: '{param1: "' + USerID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // excluir linha do Table
            var i = r.parentNode.parentNode.rowIndex;
            document.getElementById("TableCargaH").deleteRow(i);
        },
        failure: function (response) {
            alert(response.d);
        }
    });

}

function CargaHInsertLinha() {

    var col1 = document.getElementById('input_DiaSem').value;
    var col2 = document.getElementById('input_Turno').value;
    var col3 = document.getElementById('input_Entrada').value;
    var col4 = document.getElementById('input_Saida').value;
    var col5 = document.getElementById('input_Descanso').value;

    var table = document.getElementById("TableCargaH");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);
    var cell4 = row.insertCell(3);
    var cell5 = row.insertCell(4);

    cell1.innerHTML = col1;
    cell2.innerHTML = col2;
    cell3.innerHTML = col3;
    cell4.innerHTML = col4;
    cell5.innerHTML = col5;

    //apaga formulario
    document.getElementById('input_DiaSem').value = "";
    document.getElementById('input_Turno').value = "";
    document.getElementById('input_Entrada').value = "";
    document.getElementById('input_Saida').value = "";
    document.getElementById('input_Descanso').value = "";

}

function cancelar() {
    var linkurl = "Funcionarios_Listagem.aspx";   //<!--*******Customização*******-->
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



//Menu

//imagens - foto
var handleFileSelect = function (evt) {
    var files = evt.target.files;
    var file = files[0];
    if (files && file) {
        var reader = new FileReader();
        reader.onload = function (readerEvt) {
            var binaryString = readerEvt.target.result;
            var data_uri = "data:image/png;base64," + btoa(binaryString);
            document.getElementById('results').innerHTML = '<img src="' + data_uri + '"/>';
            document.getElementById("Hidden1").value = data_uri
        };
        reader.readAsBinaryString(file);
    }
};

if (window.File && window.FileReader && window.FileList && window.Blob) {
    document.getElementById('filePicker').addEventListener('change', handleFileSelect, false);
} else {
    alert('The File APIs are not fully supported in this browser.');
}

function AtivarWebCam() {
    Webcam.set({
        width: 160,
        height: 120,
        image_format: 'png'
    });
    Webcam.attach('#my_camera');
}
function take_snapshot() {
    // take snapshot and get image data
    Webcam.snap(function (data_uri) {
        // display results in page
        document.getElementById('results').innerHTML = '<img src="' + data_uri + '"/>';
        document.getElementById("Hidden1").value = data_uri
    });
    Webcam.reset()
}