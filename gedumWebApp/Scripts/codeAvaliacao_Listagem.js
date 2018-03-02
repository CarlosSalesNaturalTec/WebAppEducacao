function NovoRegistro() {
    var url = "Avaliacao_Novo.aspx";
    window.location.href = url;
}

function Excluir(IDExc) {
    document.getElementById('HiddenID').value = IDExc;
    document.getElementById('DivModal').style.display = "block";
}

function Excluir_cancel() {
    document.getElementById('DivModal').style.display = 'none';
}