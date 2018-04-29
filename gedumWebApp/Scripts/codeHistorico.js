function verificar() {

    //validações
    if (document.getElementById('select_Aluno').value == "0") {
        alert("Selecione um Aluno");
        document.getElementById("select_Aluno").focus();
        return;
    }
    if (document.getElementById('input_ano').value == "0") {
        alert("Informe Ano Letivo");
        document.getElementById("input_ano").focus();
        return;
    }

    //parametros
    var strLine = "";
    var v1 = document.getElementById('select_Aluno').value;     // ID do Aluno
    strLine = strLine + "param1" + ":'" + v1 + "'";

    $.ajax({
        type: "POST",
        url: "WebService.asmx/Historico",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, status) {

            var itens = $.parseJSON(data.d);

            var param1 = v1;                    // ID do Aluno
            var param2 = itens[0].NomeCurso;    // Nome do Curso
            var param3 = itens[0].NomeTurma;    // Nome da Turma
            var param4 = itens[0].IDTurma;      // ID da Turma
            var param5 = document.getElementById('input_ano').value;    // Ano LEtivo
            var param6 = "2";       // 1 = bOLETIM ESCOLAR   2= HISTÓRICO ESCOLAR

            var linkurl = "Boletins_Ficha.aspx" +
                "?v1=" + param1 +      
                "&v2=" + param2 +      
                "&v3=" + param3 +      
                "&v4=" + param4 +       
                "&v5=" + param5;
                "&v6=" + param6;
            window.location.href = linkurl;

        },
        failure: function (response) {
            alert('Não foi possível carregar Histórico');
        }
    });


}

