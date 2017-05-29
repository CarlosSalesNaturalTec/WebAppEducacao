document.getElementById('inputUser').focus();

function TentarLogin() {

    document.getElementById("btLogin").style.cursor = "progress";

    var v1 = document.getElementById("inputUser").value;
    var v2 = document.getElementById("inputPwd").value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Identificador",
        data: '{user: "' + v1 + '", pwd: "' + v2 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function () {
        }
    });
}

function OnSuccess(response) {

    document.getElementById("btLogin").style.cursor = "default";

    switch (response.d) {
        case "0":
            document.getElementById('lblMsgRetorno').innerText = "Usuário Não Cadastrado.";
            document.getElementById('divRetornoSenha').style.display = "block";
            document.getElementById('divLogin').style.display = "none";
            break;
        case "2":
            document.getElementById('lblMsgRetorno').innerText = "Senha Incorreta.";
            document.getElementById('divRetornoSenha').style.display = "block";
            document.getElementById('divLogin').style.display = "none";
            break;
        default:
            window.location.href = response.d;
            break;
    }

}

function LoginVoltar() {
    document.getElementById('divRetornoSenha').style.display = "none";
    document.getElementById('divLogin').style.display = "block";
}