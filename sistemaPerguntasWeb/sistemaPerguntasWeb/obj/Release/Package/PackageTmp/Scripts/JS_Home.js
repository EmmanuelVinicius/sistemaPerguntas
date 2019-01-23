$(function () {
    $('[data-toggle="tooltip"]').tooltip();
    $(".side-nav .collapse").on("hide.bs.collapse", function () {
        $(this).prev().find(".fa").eq(1).removeClass("fa-angle-right").addClass("fa-angle-down");
    });
    $('.side-nav .collapse').on("show.bs.collapse", function () {
        $(this).prev().find(".fa").eq(1).removeClass("fa-angle-down").addClass("fa-angle-right");
    });
    $(".imodal").click(function () {
        $(this).attr("data-toggle", "modal").attr("data-target", "#exampleModalCenter");
        $(".modal-title").text($(this).text())
        $(".modal-body").text();
    });
    $("#consulta").on('keyup', function () {
        var value = $(this).val().toLowerCase();
        $("table tbody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });
    $("#txtBusca").keyup(function () {
        var texto = $(this).val();

        $("#ulItens li").css("display", "block");
        $("#ulItens li").each(function () {
            if ($(this).text().toUpperCase().indexOf(texto.toUpperCase()) < 0)
                $(this).css("display", "none");
        });
    });

    $('.btn').on('click', function () {
        var $this = $(this);
       $this.button('loading')
    });

    $(".AulaLeg").change(function (ev) {
        var servico = $(ev.target).parents(".input-group").find(".form-control");  
        if (servico.attr('disabled') == 'disabled') {
            servico.removeAttr('disabled')
        } else {
            servico.attr('disabled', 'disabled')

        }
            console.log(servico.attr("placeholder"))
    })
})
