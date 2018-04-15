
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
            formatar_Tabela();
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

    cell0.innerHTML = "<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Comandos</b>";
    cell1.innerHTML = "<b>Data</b>";
    cell2.innerHTML = "<b>Observações</b>";

}

function adiciona_Linha(AulaID, AulaData, AulaObs) {

    var e = document.getElementById("select_Turma")
    var idTurma = e.options[e.selectedIndex].value
    var nomeTurma = e.options[e.selectedIndex].text

    e = document.getElementById("select_Disc")
    var nomeDisc = e.options[e.selectedIndex].text

    var table = document.getElementById("tabela_aulas");
    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);

    var bt1 = "";
    var bt2 = "";

    if (AulaID != 9999) {
        bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='Alunos_Frequencia_Presencas.aspx"+
            "?v1=" + AulaID +
            "&v2=" + idTurma +
            "&v3=" + nomeTurma +
            "&v4=" + nomeDisc +
            "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
        bt2 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick=''><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";
    }

    cell1.innerHTML = bt1 + bt2;
    cell2.innerHTML = AulaData;
    cell3.innerHTML = AulaObs;

}

function formatar_Tabela() {
    $("#tabela_aulas").addClass("table table-striped table-hover");
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

            Limpar_Tabela();
            verificar_aulas();
            UI_Aguardar_Concluido();

            document.getElementById("DivModal").style.display = "none";

        },
        failure: function (response) {
            alert(response.d);
        }
    });


}



function IncluirAluno(statusAula) {

    if (document.getElementById('select_Aluno').value == " ") {
        alert("Selecione o Aluno");
        document.getElementById("select_Aluno").focus();
        return;
    }

    //parametros
    var strLine = "";

    var v1 = document.getElementById("IDAuxHidden").value;
    strLine = strLine + "param1" + ":'" + v1 + "',";                // ID da Aula

    v1 = document.getElementById("select_Aluno").value;
    strLine = strLine + "param2" + ":'" + v1 + "',";                // ID do ALuno

    strLine = strLine + "param3" + ":'" + statusAula + "'";         // 1-Presente ou 0-Ausente

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Frequencia_Aluno_Lancar",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            insertLinha(statusAula);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function insertLinha(statusPresenca) {

    var e = document.getElementById("select_Aluno");
    var v5 = e.options[e.selectedIndex].value;
    var col1 = e.options[e.selectedIndex].text;
    var col2 = statusPresenca;

    var table = document.getElementById("tabela");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);

    cell1.innerHTML = col1;
    cell2.innerHTML = col2;

    document.getElementById('input_aluno').focus();

}

function ExcluirAluno(r, USerID) {

    var conf = confirm("Confirma Exclusão do Status de Presença?");
    if (conf == false) {
        return;
    }

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Frequencia_Aluno_Lancar_Excluir",
        data: '{param1: "' + USerID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // excluir linha do Table
            var i = r.parentNode.parentNode.rowIndex;
            document.getElementById("tabela").deleteRow(i);
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

function paginacao() {

    $(document).ready(function () {
        $('#tabela_aulas').DataTable({
            "order": [[0, "desc"]],
            "language": {
                "emptyTable": "Sem dados",
                "info": "Exibindo _START_ a _END_ de _TOTAL_ registros",
                "infoEmpty": "Exibindo 0 a 0 de 0 registros",
                "infoFiltered": "(Filtrado de _MAX_ registros)",
                "lengthMenu": "Exibindo _MENU_ registros",
                "loadingRecords": "Carregando...",
                "processing": "Processando...",
                "search": "Pesquisa:",
                "zeroRecords": "Sem Registros",
                "paginate": {
                    "first": "Primeiro",
                    "last": "Último",
                    "next": "Próximo",
                    "previous": "Anterior"
                }
            }
        });
    });

}