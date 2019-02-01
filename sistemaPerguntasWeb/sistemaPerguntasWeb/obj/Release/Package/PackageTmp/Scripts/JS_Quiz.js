
$(document).ready(function () {
    $('#exampleModalCenter').modal('show');
    $(".modal-body").html(
        "<h1> Legislação </h1>"
        + "<p>Uma pequena prova para treinar seus conhecimentos</p>"
        + "<h2>Instruções:</h2>"
        + "<p>Ao clicar no botão iniciar, você terá 60 minutos para completar a prova. "
        + "São quatro opções por pergunta, sendo uma resposta correta. Ao finalizar, clique no respectivo botão para encerrar a prova.</p>"
        + "<p>Boa sorte!</p>");
    $(".modal-footer").html(
        "<input class='btn btn-danger' type='button' value='Sair' id='btnVoltar' onclick='history.back()' />"
        + "<input class='btn btn-success' type='button' value='Iniciar' id='btnIniciar' />"
    );


    $("#btnIniciar").click(function () {
        $(this).attr("data-dismiss", "modal")
        var tempo = new Number();
        tempo = 3600;
        setInterval(function startCountdown() {

            if ((tempo - 1) >= -1) {
                var min = parseInt(tempo / 60);
                var seg = tempo % 60;

                if (min < 10) {
                    min = "0" + min;
                    min = min.substr(0, 2);
                }
                if (seg <= 9) {
                    seg = "0" + seg;
                }

                horaImprimivel = min + ':' + seg;
                $("#sessao").html(horaImprimivel);
                tempo--;
            } else {
                $('#exampleModalCenter').modal('show');
                $(".modal-body").html(
                    "<h1>Tempo expirado</h1>"
                    + "<p>Desculpe, Você foi reprovado!</p>");
                $(".modal-footer").html(
                    "<input class='btn btn-danger' type='button' value='Voltar' id='btnVoltar' onclick='history.back()' />"
                    + "<input class='btn btn-info' type='button' value='Refazer' id='btnVoltar' onclick='location.reload()' />"
                );
            }
        }, 1000)
    })
    $("form").submit((e) => {
        if ($('input:radio', this).is(':checked')) {
        } else {
            alert('Por favor, responda a prova por completo!');
            return false;
        }
        var inputs = new Array();
        $("input:checked").each(function () {
            inputs.push(this.value);
        });
        $.ajax({
            url: "/Perguntas/Legislacao",
            type: "POST",
            dataType: "json",
            data: {
                inputs: JSON.stringify(inputs)
            },
            async: false,
            cache: false,
            timeout: 30000,
            success: function (result) {
                if (result) {
                    $('#exampleModalCenter').modal('show');
                    $(".modal-body").css("background-color", "#baed91").html(
                        "<h1>Parabéns</h1>"
                        + "<p>Você foi aprovado(a)!</p>");
                    $(".modal-footer").html(
                        "<input class='btn btn-danger' type='button' value='Voltar' id='btnVoltar' onclick='history.back()' />"
                        + "<input class='btn btn-info' type='button' value='Refazer' id='btnVoltar' onclick='location.reload()' />"
                    );
                    return false;
                }
                else {
                    $('#exampleModalCenter').modal('show');
                    $(".modal-body").css("background-color", "#fea3aa").html(
                        "<h1>Desculpe</h1>"
                        + "<p>Você foi reprovado(a)!</p>");
                    $(".modal-footer").html(
                        "<input class='btn btn-danger' type='button' value='Voltar' id='btnVoltar' onclick='history.back()' />"
                        + "<input class='btn btn-info' type='button' value='Refazer' id='btnVoltar' onclick='location.reload()' />"
                    );
                    return false;
                }
            },

        });
        e.preventDefault();
    })
});