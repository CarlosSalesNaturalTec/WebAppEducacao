document.getElementById("input_nome").focus();

function SalvarRegistro() {

    //validações
    if (document.getElementById('input_nome').value == "") {
        alert("Informe Nome da Receita");   //<!--*******Customize AQUI*******-->
        document.getElementById("input_nome").focus();
        return;
    }

    //pega o valor de cada campo e constroi string com todos
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    // id
    var vID = document.getElementById("IDInstHidden").value;
    strLine = strLine + "param" + i + ":'" + vID + "'";

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/ReceitasSalvar",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            window.location.href = response.d;
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function AlterarRegistro() {

    //validações
    if (document.getElementById('input_nome').value == "") {
        alert("Informe Nome da Receita");   //<!--*******Customize AQUI*******-->
        document.getElementById("input_nome").focus();
        return;
    }

    //pega o valor de cada campo e constroi string com todos
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    // id
    var vID = document.getElementById("IDInstHidden").value;
    strLine = strLine + "param" + i + ":'" + vID + "'";

    //exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/ReceitasAlterar",
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



function SalvarItemRegistro() {

    //validações
    if (document.getElementById('input_ingrediente').value == "") {
        alert("Informe Nome do Ingrediente");   //<!--*******Customização*******-->
        document.getElementById("input_ingrediente").focus();  //<!--*******Customização*******-->
        return;
    }

    var v1 = document.getElementById('IDInstHidden').value;
    var v2 = document.getElementById("input_ingrediente").value;
    var v3 = document.getElementById("input_qtde").value;
    var v4 = document.getElementById("input_und").value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/ReceitasItensSalvar",  //<!--*******Customização*******-->
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            insertLinha();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}


function ExcluirReceitasItens(r, ReceitaItemID) {

    var conf = confirm("Confirma Exclusão de Receitas Itens?");
    if (conf == false) {
        return;
    }

    $.ajax({
        type: "POST",
        url: "WebService.asmx/ReceitasItensExcluir",  //<!--*******Customização*******-->
        data: '{param1: "' + ReceitaItemID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // excluir linha do Table
            var i = r.parentNode.parentNode.rowIndex;
            document.getElementById("MyTable").deleteRow(i);
        },
        failure: function (response) {
            alert(response.d);
        }
    });


}




function insertLinha() {

    var col1 = document.getElementById('input_ingrediente').value;
    var col2 = document.getElementById('input_qtde').value;

    var table = document.getElementById("MyTable");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);

    cell1.innerHTML = col1;
    cell2.innerHTML = col2;

    //apaga formulario
    document.getElementById('input_ingrediente').value = "";
    document.getElementById('input_qtde').value = "";
    document.getElementById('input_und').value = "";

}



function cancelar() {
    var linkurl = "Receitas_Listagem.aspx";   //<!--*******Customização*******-->
    window.location.href = linkurl;
}

function UIAguardar() {
    var i, x;

    x = document.getElementsByClassName("btcontroles");
    for (i = 0; i < x.length; i++) {
        x[i].disabled = true;
    }

    x = document.getElementsByClassName("aguarde");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "block";
    }
}
//Menu
function openLink(evt, animName) {
    var i, x, tablinks;
    x = document.getElementsByClassName("grupo");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < x.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" w3-blue", "");
    }
    document.getElementById(animName).style.display = "block";
    evt.currentTarget.className += " w3-blue";
}
