function cancelar() {

    $("body").css("cursor", "progress");
    document.getElementById("bt_saida").disabled = true;

    var linkurl = "home.aspx";
    window.location.href = linkurl;
}

function Adicionar() {

    var v = document.getElementById("select_aluno")
    var v1 = v.options[v.selectedIndex].value   // ID do Aluno
    var v2 = v.options[v.selectedIndex].text   // Nome do Aluno
    if (v1 == "0") {
        alert("Informe Aluno");
        document.getElementById("select_aluno").focus();
        return;
    }

    var e = document.getElementById("select_disciplina")
    var v3 = e.options[e.selectedIndex].value           // ID da Disciplina
    var v4 = e.options[e.selectedIndex].text            // Nome da Disciplina
    if (v3 == "0") {
        alert("Informe Disciplina");
        document.getElementById("select_disciplina").focus();
        return;
    }


    //var combo1 = document.getElementById("input_curso")
    //var combo2 = combo1.options[combo1.selectedIndex].value;    //ID

    var cobUnd = document.getElementById("input_Unidade")
    var v5 = cobUnd.options[cobUnd.selectedIndex].text;

    var cobTipoAvaliacao = document.getElementById("input_TipoAvaliacao")
    var v6 = cobTipoAvaliacao.options[cobTipoAvaliacao.selectedIndex].text;

    var v7 = document.getElementById("input_dataavaliacao").value;
    var v8 = document.getElementById("input_anoletivo").value;
    var v9 = document.getElementById("input_nota").value;

    $("body").css("cursor", "progress");
    // document.getElementById("BTEstoque_Entrada").disabled = true;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Inseri_Boletim",
        data: '{param1: "' + v1 + '", param2: "' + v3 + '", param3: "' + v5 + '", param4: "' + v6 + '", param5: "' + v7 +
            '", param6: "' + v8 + '", param7: "' + v9 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var urlAux = "Boletins.aspx?v1=" + v1;
            window.location.href = urlAux;
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
