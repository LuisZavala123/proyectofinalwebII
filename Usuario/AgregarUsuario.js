
$(document).ready(function () {

    if (sessionStorage.getItem('User') != "1") {
        debugger;
        location.href = "../Publico/Principal.aspx";
    }

    $('#contenido_btnAceptar').click(function (e) {
        e.preventDefault();

        debugger;

        var Nombre = $('#contenido_txtNombre').val();
        var ApellidoP = $('#contenido_txtApellidoP').val();
        var ApellidoM = $('#contenido_txtApellidoM').val();
        var Password = $('#contenido_txtPassword').val();
        var Correo = $('#contenido_txtEmail').val();
        var tipo = $('#contenido_CboxTipo').val();

        if (exprn.test(Nombre)) {
            ready += 1;
        } else {
            ready = 0;
        }
        if (exprn.test(ApellidoP)) {
            ready += 1;
        } else {
            ready = 0;
        }
        if (exprn.test(ApellidoM)) {
            ready += 1;
        } else {
            ready = 0;
        }
        if (expr.test(Correo)) {
            ready += 1;
        } else {
            ready = 0;
        }
        var exa2 = $('#contenido_txtPassword').val();
        if (Password = exa2) {
            ready += 1;
        } else {
            ready = 0;
        }
        console.log(ready);
        if (ready == 5) {
            console.log("Si");
            ready = 0;
            $.ajax({
                url: '../WS/WSUsuario.asmx/Agregar',
                data: '{ "nom":"' + Nombre + '", "primer_apellido":"' + ApellidoP + '", "segundo_apellido":"' + ApellidoM + '", "contraseña": "' + Password + '", "Correo": "' + Correo + '", "Tipo":"' + tipo + '"}',
                contentType: 'application/json; utf-8',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    location.href = "../Publico/Principal.aspx";
                    console.log(data);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        } else {
            ready = 0;
            console.log("Verifique los datos");
        }
    });
});
var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;
var exprn = /^[A-ZÁÉÍÓÚ][a-záéíúó]+$/;
var ready = 0;
