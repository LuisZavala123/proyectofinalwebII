let nom = 0;
let cos = 0;
function popear() {
    if (nom == 1) {
        var popup = document.getElementById("popt1");
        popup.classList.toggle("show");
    }
    if (cos == 1) {
        var popup = document.getElementById("popt2");
        popup.classList.toggle("show");
    }



}
var expr = /^[0-9]+\.[0-9]?[0-9]$/;
var exprn = /^[A-ZÁÉÍÓÚ][a-záéíúó]+$/;
var ready = 0;
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
        }
        debugger;
        if (expr.test(Costo)) {
            ready += 1;
            cos = 0;
        } else {
            ready = 0;
            cos = 1;
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
                    console.log(err);
                }
            });
        } else {
            ready = 0;
            popear();
            console.log("Verifique Datos");
        }
    });
});