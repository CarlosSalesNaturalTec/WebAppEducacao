var itens;
var itensLen = 0;
var ic = 0;
var idaula;

function ApagarAnterior() {

    var conf = confirm("Confirma ?");
    if (conf == false) {
        return;
    }

    idaula = document.getElementById("IDAuxHidden").value;     //ID da Aula

    var strLine = "";
    strLine = strLine + "param1" + ":'" + idaula + "'";

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Frequencia_Alunos_Excluir",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, status) {
            Limpar_Tabela();
            IniciarFrequencias();
        },
        failure: function (response) {
            alert('Não foi possível excluir anterior');
        }
    });

}

function Limpar_Tabela() {

    //apaga todas as linhas da tabela, inclusive Header
    $("#tabela tr").remove();

    //inclui novamente o header
    var table = document.getElementById("tabela");
    var header = table.createTHead();
    var row = header.insertRow(0);

    var cell0 = row.insertCell(0);
    var cell1 = row.insertCell(1);

    cell0.innerHTML = "<b>ALUNO</b>";
    cell1.innerHTML = "<b>STATUS</b>";

}

function IniciarFrequencias() {

    // retorna JSON COM TODOS OS ALUNOS DA TURMA

    //parametros
    var strLine = "";
    var v1 = document.getElementById("IDAuxHidden2").value;     //ID da Turma
    strLine = strLine + "param1" + ":'" + v1 + "'";

    // Aguarde
    UI_Aguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Frequencia_Aulas_Listar_Alunos",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, status) {
            itens = $.parseJSON(data.d);
            itensLen = itens.length;
            lancar();
        },
        failure: function (response) {
            alert('Não foi possível carregar itens');
        }
    });

}

function lancar() {
    LancarFrequencias_Indiv(idaula, itens[ic].ID_Aluno, '1');
}

function LancarFrequencias_Indiv(idaula, idaluno, presenca) {

    var strLine = "";
    strLine = strLine + "param1" + ":'" + idaula + "',";
    strLine = strLine + "param2" + ":'" + idaluno + "',";
    strLine = strLine + "param3" + ":'" + presenca + "'";
    
    $.ajax({
        type: "POST",
        url: "WebService.asmx/Frequencia_Aluno_Lancar_Indiv",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            ic++;
            if (ic < itensLen ) {
                lancar();
            } else {
                verificar_aulas();
            }
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function AlterarStatus(idfreq,statusAnterior) {

    var strLine = "";
    strLine = strLine + "param1" + ":'" + idfreq + "',";

    var novoStatus;
    if (statusAnterior == "True") {
        novoStatus = "0";
    } else {
        novoStatus = "1";
    }
    strLine = strLine + "param2" + ":'" + novoStatus + "'";

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Frequencia_Alunos_Alterar_Status",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            Limpar_Tabela();
            verificar_aulas();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function verificar_aulas() {

    //parametros
    var strLine = "";
    var v1 = document.getElementById("IDAuxHidden").value;     //ID da Aula
    strLine = strLine + "param1" + ":'" + v1 + "'";

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Frequencia_Aulas_Listar_Indiv",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, status) {
            var itens = $.parseJSON(data.d);
            for (var i = 0; i < itens.length; i++) {
                adiciona_Linha(itens[i].ID_freq, itens[i].Aluno, itens[i].presenca);
            }
            formatar_Tabela();
            UI_Aguardar_Concluido();
        },
        failure: function (response) {
            UI_Aguardar_Concluido();
            alert('Não foi possível carregar imagens');
        }
    });

}

function adiciona_Linha(freqID, aluno, presenca) {

    var table = document.getElementById("tabela");
    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);

    var presenca1 = "";

    if (presenca == 'True') {
        presenca1 = "Presente";
    } else {
        presenca1 = "Ausente";
    }

    var bt1 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='AlterarStatus(\"" + freqID + "\",\"" + presenca + "\")'><i class='fa fa-user' aria-hidden='true'></i></a>&nbsp;&nbsp;";

    cell1.innerHTML = bt1 + aluno;
    cell2.innerHTML = presenca1;

}

function formatar_Tabela() {
    $("#tabela").addClass("table table-striped table-hover");
}

function UI_Aguardar() {

    $("body").css("cursor", "progress");

    document.getElementById("bt_iniciar").disabled = true;
    document.getElementById("bt_iniciar").style.cursor = "progress";

}

function UI_Aguardar_Concluido() {

    $("body").css("cursor", "default");
    document.getElementById("bt_iniciar").style.cursor = "default";
}
