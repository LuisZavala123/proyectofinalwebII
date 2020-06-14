let nom = 0;
let cos = 0;

var expr = /^[0-9]+\.[0-9]?[0-9]$/;
var exprn = /^[A-ZÁÉÍÓÚ][a-záéíúó]+$/;
var ready = 0;
var mensj = "";
$(document).ready(function () {



    $('#contenido_contenido_btnAceptar').click(function (e) {
        e.preventDefault();
        var Nombre = $('#contenido_contenido_txtNombre').val();
        var Costo = $('#contenido_contenido_txtCosto').val();
        var Desc = $('#contenido_contenido_txtDescripcion').val();
        var tipo = $('#contenido_contenido_CboxTipo').val();

        if (exprn.test(Nombre)) {
            ready += 1;
            nom = 0;
        } else {
            ready = 0;
            nom = 1;
            mensj = mens + "Nombre, ";

        }
        debugger;
        if (expr.test(Costo)) {
            ready += 1;
            cos = 0;
        } else {
            ready = 0;
            cos = 1;
            mensj = mens + "Costo";
        }
        console.log(ready);
        if (ready == 2) {
            $.ajax({
                url: '../WS/WSArticulos.asmx/Agregar',
                data: '{ "nom":"' + Nombre + '", "costo":"' + Costo + '", "Descripcion":"' + Desc + '", "Tipo": "' + tipo + '" }',
                contentType: 'application/json; utf-8',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    location.href = "../Publico/Principal.aspx";
                },
                error: function (err) {
                    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                        '<strong > a acurrido un error </strong >');
                    console.log(err);
                }
            });
        } else {
            ready = 0;
            $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                '<strong > Verifique los datos en: </strong >' + mensj);
            console.log("Verifique Datos");
        }
    });
});