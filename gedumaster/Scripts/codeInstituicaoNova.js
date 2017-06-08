document.getElementById("input1").focus();

function cancelar() {
    var linkurl = "CADInstituicoes_Listagem.aspx";
    window.location.href = linkurl;
}

function NovaInstituicao() {
    window.location.href = "CADInstituicoes_Novo.aspx";
}

function SalvarRegistro() {

    document.getElementById("btSalvar").style.cursor = "progress";
    document.getElementById("btSalvar").disabled = true;

    var v1 = document.getElementById("input1").value        //nome
    var v2 = document.getElementById("input2").value        //diretor
    var v3 = document.getElementById("input3").value        //email
    var v4 = document.getElementById("input4").value        //telefone
    var v5 = document.getElementById("estados").value        //UF
    var v6 = document.getElementById("cidades").value        //cidad
    var v7 = document.getElementById("input7").value        //usuario
    var v8 = document.getElementById("input8").value        //senha

    if (v1 == "") {
        alert("Informe Nome da Instituição");
        document.getElementById("input1").focus();
        return;
    }

    $.ajax({
        type: "POST",
        url: "WebService.asmx/InstituicaoSalvar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
            '", param6: "' + v6 + '", param7: "' + v7 + '", param8: "' + v8 + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            document.getElementById("btSalvar").style.cursor = "default";
            var linkurl = response.d;
            window.location.href = linkurl;
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function ExcluirRegistro(idRegistro) {

    var r = confirm("CONFIRMA EXCLUSÂO ?");
    if (r == false) {
        return;
    }

    $.ajax({
        type: "POST",
        url: "WebService.asmx/InstituicaoExcluir",
        data: '{param1: "' + idRegistro + '" }',
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

function AlterarREgistro() {

    // blocos de botões
    document.getElementById('btsDefault').style.display = "none";
    document.getElementById('btsALterar').style.display = "block";
    
    // habilita campos para edição
    document.getElementById('input1').disabled = false;
    document.getElementById('input2').disabled = false;
    document.getElementById('input3').disabled = false;
    document.getElementById('input4').disabled = false;
    document.getElementById('input5').disabled = false;
    document.getElementById('input6').disabled = false;

    document.getElementById('input1').focus();

}

function AlterarSalvar() {

    document.getElementById("btSalvarAltera").style.cursor = "progress";
    document.getElementById("btSalvarAltera").disabled = true;

    var v1 = document.getElementById("input1").value        //nome
    var v2 = document.getElementById("input2").value        //diretor
    var v3 = document.getElementById("input3").value        //email
    var v4 = document.getElementById("input4").value        //telefone
    var v5 = document.getElementById("input5").value        //UF
    var v6 = document.getElementById("input6").value        //cidade

    var v7 = document.getElementById("IDHidden").value        //id 

    if (v1 == "") {
        alert("Informe Nome da Instituição");
        document.getElementById("input1").focus();
        return;
    }

    $.ajax({
        type: "POST",
        url: "WebService.asmx/InstituicaoAlterar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
            '", param6: "' + v6 + '", param7: "' + v7 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            document.getElementById("btSalvar").style.cursor = "default";
            var linkurl = response.d;
            window.location.href = linkurl;
        },
        failure: function (response) {
            alert(response.d);
        }
    });

}