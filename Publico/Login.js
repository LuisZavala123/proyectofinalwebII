﻿

$(document).ready(function () {

    function popear(c) {

    }
    popear(1);
    $('#contenido_btnLogin').click(function (e) {
        debugger;
        e.preventDefault();
        var Password = $('#contenido_txtPassword').val();
        var Correo = $('#contenido_txtEmail').val();
        debugger;
        if (expr.test(Correo)) {
            $.ajax({
                url: '../WS/WSUsuario.asmx/Confirmar',
                data: '{ "correo":"' + Correo + '", "pw":"' + Password + '"}',
                contentType: 'application/json; utf-8',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    debugger;
                    if (data.d) {
                        location.href = "Principal.aspx";
                    } else {
                        $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                            '<strong> Los datos son incorrectos  </strong >');
                        $("#mensaje").show();
                    }

                },
                error: function (err) {
                    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                        '<strong > a acurrido un error </strong >');
                    $("#mensaje").show();
                    console.log(err);
                }
            });
        } else {
            $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                '<strong > Los datos son incorrectos  </strong > Correo invalido');
            $("#mensaje").show();
            console.log("Correo invalido");
        }
    });
});
var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;