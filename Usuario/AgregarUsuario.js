﻿var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;
var exprn = /^[A-ZÁÉÍÓÚ][a-záéíúó]+$/;
var ready = 0;
let nom = 0;
let ap = 0;
let cor = 0;
var mensj = "";



$(document).ready(function () {

    

    $('#contenido_contenido_btnAceptar').click(function (e) {
        e.preventDefault();

        debugger;

        var Nombre = $('#contenido_contenido_txtNombre').val();
        var ApellidoP = $('#contenido_contenido_txtApellidoP').val();
        var ApellidoM = $('#contenido_contenido_txtApellidoM').val();
        var Password = $('#contenido_contenido_txtPassword').val();
        var Correo = $('#contenido_contenido_txtEmail').val();
        var tipo = $('#contenido_contenido_CboxTipo').val();

        if (exprn.test(Nombre)) {
            ready += 1;
            nom = 0;
        } else {
            nom = 1;
            ready = 0;
            mensj = mens + "Nombre, ";
        }
        if (exprn.test(ApellidoP)) {
            ready += 1;
            ap = 0;
        } else {
            ap = 1;
            ready = 0;
            mensj = mens + "Apellido Paterno, ";
        }
        debugger;
        if (exprn.test(ApellidoM)) {
            ready += 1;
        } else {
            ready = 0;
        }
        if (expr.test(Correo)) {
            ready += 1;
            cor = 0;
        } else {
            cor = 1;
            ready = 0;
            mensj = mens + "Correo, ";
        }
        var exa2 = $('#contenido_contenido_txtPassword').val();
        if (Password = exa2) {
            ready += 1;
        } else {
            ready = 0;
            mensj = mens + "Contraseña ";
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
                    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                        '<strong > a acurrido un error </strong >');
                    console.log(err);
                }
            });
        } else {
            ready = 0;
            $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                '<strong > Verifique los datos en: </strong >' + mensj);
            console.log("Verifique los datos");
        }
    });
});