function ExcluirRegistro() {

    var idRegistro = document.getElementById('HiddenID').value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/SolicitacoesMatriculas_Excluir",
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

function Excluir(IDExc) {
    document.getElementById('HiddenID').value = IDExc;
    document.getElementById('DivModal').style.display = "block";
}

function Excluir_cancel() {
    document.getElementById('DivModal').style.display = 'none';
}



function Confirmar(IDConf, NomeConf) {
    document.getElementById('HiddenConf').value = IDConf;
    document.getElementById('lbl_nome_Conf').value = NomeConf;
    document.getElementById('DivModal1').style.display = "block";
}

function Confirmar_cancel() {
    document.getElementById('DivModal1').style.display = 'none';
}

function Confirmar_Matricula() {

    var strLine = "";

    // id da solicitação de matricula
    var v1 = document.getElementById("HiddenConf").value;
    strLine = strLine + "param1" + ":'" + v1 + "',";

    //id da instituição
    var v2 = document.getElementById("IDInstAux").value;
    strLine = strLine + "param2" + ":'" + v2 + "'";

    $.ajax({
        type: "POST",
        url: "WebService.asmx/SolicitacoesMatriculas_Confirmar",
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