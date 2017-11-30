document.getElementById("input_veiculo").focus();

function SalvarRegistro() {

    //validações
    if (document.getElementById('input_veiculo').value == "") {
        alert("Informe Nome da Veículo");   //<!--*******Customize AQUI*******-->
        document.getElementById("input_veiculo").focus();
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
    strLine = strLine + "param" + i + ":'" + vID + "',";

    // id_veiculo
    var vIDVeiculo = '0'; //document.getElementById("IDInstHidden").value;
    i++;
    strLine = strLine + "param" + i + ":'" + vIDVeiculo + "',";

    // id_modelo
    var vIDMotorista = '0'; //document.getElementById("IDInstHidden").value;
    i++;
    strLine = strLine + "param" + i + ":'" + vIDMotorista + "'";

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/ViagensSalvar",
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
    if (document.getElementById('input_veiculo').value == "") {
        alert("Informe Nome do Veículo");   //<!--*******Customize AQUI*******-->
        document.getElementById("input_veiculo").focus();
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
    strLine = strLine + "param" + i + ":'" + vID + "',";

    // id_veiculo
    var vIDVeiculo = '0'; //document.getElementById("IDInstHidden").value;
    i++;
    strLine = strLine + "param" + i + ":'" + vIDVeiculo + "',";

    // id_modelo
    var vIDMotorista = '0'; //document.getElementById("IDInstHidden").value;
    i++;
    strLine = strLine + "param" + i + ":'" + vIDMotorista + "'";


    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/ViagensAlterar",
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
    var linkurl = "Viagens_Listagem.aspx";   //<!--*******Customização*******-->
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
