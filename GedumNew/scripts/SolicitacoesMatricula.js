function SalvarRegistro() {
    if (document.getElementById('input.nome') == "") {
        $('input_nome').focus();
        alert("Digite o nome do aluno");
    }


     var x, i, strLine;
     x = document.getElementsByClassName('form-control');
        for (i = 0; i < x.length; i++) {
            strLine = strLine + "param" + i + ":'" + x[i].value + "',";

        }

        var idfoto = document.getElementById('Hidden1').value;
         strLine = strLine + "param" + i + ":'" + idInst + "',";

         UIAguardar();


         $.ajax({
             type: "POST",
             url: "WebService.asmx/SalvarRegistro",
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


function voltar() {
    var url = "index.html";
    window.location.href = url;
}


function avancar(p1) {

    

    var url = "SolicitacoesMatricula_Novo2.aspx?v1=" + p1;
    window.location.href = url;
}

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

