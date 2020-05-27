var expr = /^[0-9]+[.][0-9]?[0-9]$/;
var exprn = /^[A-ZÁÉÍÓÚ][a-záéíúó]+$/;
var ready = 0;
$(document).ready(function () {

    if (sessionStorage.getItem('User') != "1") {
        debugger;
        location.href = "../Publico/Principal.aspx";
    }

    $('#contenido_btnAceptar').click(function (e) {
        e.preventDefault();
        var Nombre = $('#contenido_txtNombre').val();
        var Costo = $('#contenido_txtCosto').val();
        var Desc = $('#contenido_txtDescripcion').val();
        var tipo = $('#contenido_CboxTipo').val();

        if (exprn.test(Nombre)) {
            ready += 1;
        } else {
            ready = 0;
        }
        if (expr.test(Costo)) {
            ready += 1;
        } else {
            ready = 0;
        }
        console.log(ready);
        if (ready = 2) {
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
                    console.log(err);
                }
            });
        } else {
            console.log("Verifique Datos");
        }
    });
});