﻿document.getElementById("input_nome").focus();

function SalvarRegistro() {

    //validações
    if (document.getElementById('input_nome').value == "") {
        alert("Informe Nome do Aluno");  
        openLink(event, 'grupo1')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input_nome").focus();
        return;
    }
    var e = document.getElementById("input_Curnome");
    var v6 = e.options[e.selectedIndex].text;
    if (v6 == "") {
        alert("Informe Curso");
        openLink(event, 'grupo2')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input_Curnome").focus();
        return;
    }
    e = document.getElementById("input_Turma");
    v6 = e.options[e.selectedIndex].text;
    if (v6 == "") {
        alert("Informe Turma");
        openLink(event, 'grupo2')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input_Turma").focus();
        return;
    }


    //pega o valor de cada campo e constroi string com todos
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }
    
    //id isntituição
    var idInst = document.getElementById('IDHidden').value;
    strLine = strLine + "param" + i + ":'" + idInst + "',";

    // foto
    var foto = document.getElementById('Hidden1').value;
    i++;
    strLine = strLine + "param" + i + ":'" + foto + "'";

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/AlunosSalvar",
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
        alert("Informe Nome do Aluno");   
        openLink(event, 'grupo1')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input_nome").focus();
        return;
    }
    var e = document.getElementById("input_Curnome");
    var v6 = e.options[e.selectedIndex].text;
    if (v6 == "") {
        alert("Informe Curso");
        openLink(event, 'grupo1')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input_Curnome").focus();
        return;
    }
    e = document.getElementById("input_Turma");
    v6 = e.options[e.selectedIndex].text;
    if (v6 == "") {
        alert("Informe Turma");
        openLink(event, 'grupo2')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input_Turma").focus();
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

    // id aluno
    var vID = document.getElementById("IDHidden").value;
    i++;
    strLine = strLine + "param" + i + ":'" + vID + "'";
    
    //exibir animações - aguarde...
    UIAguardar();
    
    $.ajax({
        type: "POST",
        url: "WebService.asmx/AlunosAlterar",
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
    var linkurl = "Alunos_Listagem.aspx";   
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