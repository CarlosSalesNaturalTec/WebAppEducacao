document.getElementById("select_Turma").focus();

function lancar_freq() {

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
    if (document.getElementById('input_Data').value == "") {
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
    strLine = strLine + "param3" + ":'" + v1 + "'";

    // Aguarde
    $("body").css("cursor", "progress");
    document.getElementById("lancar_Freq").disabled = true;
    document.getElementById("lancar_Freq").style.cursor = "progress";

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Lancar_Frequencia_Aula",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            //window.location.href = response.d;
            alert(response.d);
        },
        failure: function (response) {
            alert(response.d);
        }
    });

    
}