function login_master() {
    document.getElementById('divHeader').style.display = "none";
    document.getElementById('divLogin').style.display = "block";
    document.getElementById('divOper').style.display = "none";
    document.getElementById('divAlunos').style.display = "none";
    document.getElementById('divRetornoSenha').style.display = "none";

    document.getElementById('inputUser').focus();
}

function login_Oper() {
    document.getElementById('divHeader').style.display = "none";
    document.getElementById('divLogin').style.display = "none";
    document.getElementById('divOper').style.display = "block";
    document.getElementById('divAlunos').style.display = "none";
    document.getElementById('divRetornoSenha').style.display = "none";

    document.getElementById('inputUserOper').focus();

}

function login_Alunos() {
    document.getElementById('divHeader').style.display = "none";
    document.getElementById('divLogin').style.display = "none";
    document.getElementById('divOper').style.display = "none";
    document.getElementById('divAlunos').style.display = "block";
    document.getElementById('divRetornoSenha').style.display = "none";

    document.getElementById('inputUserAluno').focus();

}

function header() {
    document.getElementById('divHeader').style.display = "block";
    document.getElementById('divLogin').style.display = "none";
    document.getElementById('divOper').style.display = "none";
    document.getElementById('divAlunos').style.display = "none";
    document.getElementById('divRetornoSenha').style.display = "none";
}

function TentarLogin() {

    var v1 = document.getElementById("inputUser").value;
    var v2 = document.getElementById("inputPwd").value;
    document.getElementById("btLogin").style.cursor = "progress";

    $.ajax({
        type: "POST",
        url: "WebService.asmx/TentaLogin",
        data: '{user: "' + v1 + '", pwd: "' + v2 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function () {
        }
    });
}

function TentarLoginOper() {

    var v1 = document.getElementById("inputUserOper").value;
    var v2 = document.getElementById("inputPwdOper").value;
    document.getElementById("btLoginOper").style.cursor = "progress";

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
            document.getElementById('divLogin').style.display = "none";
            document.getElementById('divOper').style.display = "none";
            document.getElementById('divAlunos').style.display = "none";
            document.getElementById('lblMsgRetorno').innerText = "Usuário Não Cadastrado.";
            document.getElementById('divRetornoSenha').style.display = "block";
            break;
        case "1":
            document.getElementById('divLogin').style.display = "none";
            document.getElementById('divOper').style.display = "none";
            document.getElementById('divAlunos').style.display = "none";
            document.getElementById('lblMsgRetorno').innerText = "Acesso não permitido a este módulo.";
            document.getElementById('divRetornoSenha').style.display = "block";
            break;
        case "2":
            document.getElementById('divLogin').style.display = "none";
            document.getElementById('divOper').style.display = "none";
            document.getElementById('divAlunos').style.display = "none";
            document.getElementById('lblMsgRetorno').innerText = "Senha Incorreta.";
            document.getElementById('divRetornoSenha').style.display = "block";
            break;
        default:
            window.location.href = response.d;
            break;
    }

}

function LoginVoltar() {
    document.getElementById('divRetornoSenha').style.display = "none";
    header();
}