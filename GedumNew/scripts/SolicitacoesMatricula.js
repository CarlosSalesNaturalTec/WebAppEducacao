function SalvarRegistro() {

    if (document.getElementById('input.nome') == "") {
        $('input_nome').focus();
        alert("Digite o nome do Aluno");
    }

    var x, i;
    var strLine="";
    x = document.getElementsByClassName('form-control');

    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    strLine = strLine + "param" + i + ":'" + document.getElementById("IDHidden").value + "'";

    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/AlunosSoliSalvar",
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


function voltar() {
    var url = "index.html";
    window.location.href = url;
}

function classeBt2() {
    openLink(event, 'grupo2')
    $('#bt2').addClass(' w3-blue');
}


function btvoltar1() {
    openLink(event, 'grupo1')
    $('#bt1').addClass(' w3-blue');
}


function avancar() {

    var e = document.getElementById("select_inst")
    var p1 = e.options[e.selectedIndex].value
    var p2 = e.options[e.selectedIndex].text

    var url = "SolicitacoesMatricula_Novo2.aspx?v1=" + p1 + "&v2=" + p2;
    window.location.href = url;

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

