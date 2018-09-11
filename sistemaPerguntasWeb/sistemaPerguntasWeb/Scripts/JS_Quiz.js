
$(document).ready(function () {
    $('#exampleModalCenter').modal('show');
    $(".modal-body").html(
        "<h1> Legislação </h1>"
        + "<p>Uma pequena prova para treinar seus conhecimentos</p>"
        + "<h2>Instruções:</h2>"
        + "<p>Ao clicar no botão iniciar, você terá 60 minutos para completar a prova. "
        + "São quatro opções por pergunta, sendo uma resposta correta. Ao finalizar, clique no respectivo botão para encerrar a prova.</p>"
        + "<p>Boa sorte!</p>");

    $("#btnIniciar").click(function () {
        $(this).attr("data-dismiss", "modal")
        var tempo = new Number();
        tempo = 3600;
        setInterval(function startCountdown() {

            if ((tempo - 1) >= 0) {
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
                alert("Tempo expirado, você foi reprovado!");
            }
        }, 1000)
    })
});