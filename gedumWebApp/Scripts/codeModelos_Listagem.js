function NovoRegistro() {
    window.location.href = "Modelos_Novo.aspx";  // <!--*******Customização*******-->
}

function ExcluirRegistro() {

    var idRegistro = document.getElementById('HiddenID').value;

    // <!--*******Customização*******-->
    $.ajax({
        type: "POST",
        url: "WebService.asmx/ModelosExcluir",
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




