document.getElementById("select_Turma").focus();

function verificar_aulas() {

    //validações
    if (document.getElementById('select_Turma').value == "0") {
        alert("Informe Turma");
        document.getElementById("select_Turma").focus();
        return;
    }
    if (document.getElementById('select_Disc').value == "0") {
        alert("Informe Disciplina");
        document.getElementById("select_Disc").focus();
        return;
    }

    //parametros
    var strLine = "";
    var v1 = document.getElementById("select_Turma").value;
    strLine = strLine + "param1" + ":'" + v1 + "',";
    v1 = document.getElementById("select_Disc").value;
    strLine = strLine + "param2" + ":'" + v1 + "'";

    // Aguarde
    UI_Aguardar();

    //limpar tabela (excluir linhas)
    Limpar_Tabela();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Frequencia_Aulas_Listar",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, status) {
            var itens = $.parseJSON(data.d);
            for (var i = 0; i < itens.length; i++) {
                adiciona_Linha(itens[i].ID_Aula, itens[i].Data_Aula, itens[i].Observ);
            }
            UI_Aguardar_Concluido();
        },
        failure: function (response) {
            UI_Aguardar_Concluido();
            alert('Não foi possível carregar imagens');
        }
    });

}

function Limpar_Tabela() {

    //apaga todas as linhas da tabela, inclusive Header
    $("#tabela_aulas tr").remove();

    //inclui novamente o header
    var table = document.getElementById("tabela_aulas");
    var header = table.createTHead();
    var row = header.insertRow(0);

    var cell0 = row.insertCell(0);
    var cell1 = row.insertCell(1);
    var cell2 = row.insertCell(2);

    cell0.innerHTML = "<b>Cod.</b>";
    cell1.innerHTML = "<b>Data</b>";
    cell2.innerHTML = "<b>Observações</b>";

}

function adiciona_Linha(AulaID, AulaData, AulaObs) {

    var table = document.getElementById("tabela_aulas");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);

    cell1.innerHTML = AulaID;
    cell2.innerHTML = AulaData;
    cell3.innerHTML = AulaObs;

}



function Lancar_aulas() {
    document.getElementById('DivModal').style.display = "block";
}

function Lancar_Cancel() {
    document.getElementById('DivModal').style.display = "none";
}

function Lancar_aulas_Confirma() {

    //validações
    if (document.getElementById("input_Data").value == "") {
        alert("Informe Data");
        document.getElementById("input_Data").focus();
        return;
    }

    //parametros
    var strLine = "";
    var v1 = document.getElementById("select_Turma").value;
    strLine = strLine + "param1" + ":'" + v1 + "',";
    v1 = document.getElementById("select_Disc").value;
    strLine = strLine + "param2" + ":'" + v1 + "',";
    v1 = document.getElementById("input_Data").value;
    strLine = strLine + "param3" + ":'" + v1 + "',";
    v1 = document.getElementById("input_Obs").value;
    strLine = strLine + "param4" + ":'" + v1 + "'";

    // Aguarde
    UI_Aguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Frequencia_Aula_Lancar",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            //alert(response.d);

            UI_Aguardar_Concluido();
            document.getElementById("DivModal").style.display = "none";

        },
        failure: function (response) {
            alert(response.d);
        }
    });


}



function UI_Aguardar() {

    $("body").css("cursor", "progress");

    document.getElementById("Ver_aulas").disabled = true;
    document.getElementById("Ver_aulas").style.cursor = "progress";

    document.getElementById("lancar_Aula").disabled = true;
    document.getElementById("lancar_Aula").style.cursor = "progress";
}

function UI_Aguardar_Concluido() {

    $("body").css("cursor", "default");

    document.getElementById("Ver_aulas").disabled = false;
    document.getElementById("Ver_aulas").style.cursor = "default";

    document.getElementById("lancar_Aula").disabled = false;
    document.getElementById("lancar_Aula").style.cursor = "default";
}