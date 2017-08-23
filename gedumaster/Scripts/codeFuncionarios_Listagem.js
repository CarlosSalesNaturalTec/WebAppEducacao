function NovoRegistro() {
    window.location.href = "Funcionarios_Novo.aspx";  // <!--*******Customização*******-->
}

function ExcluirRegistro() {

    var idRegistro = document.getElementById('HiddenID').value;

    // <!--*******Customização*******-->
    $.ajax({
        type: "POST",
        url: "WebService.asmx/FuncionariosExcluir",
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

function Imprimir(idDig) {
    var urlURI = "Funcionarios_Imprimir.aspx?p1=" + idDig;
    window.open(urlURI, '_blank');
}