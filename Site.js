$(document).ready(function () {
    debugger;


    $("#HamBtn").click(function () {
        sessionStorage.setItem("Producto", "Hamburguesa");
        location.href = "../Publico/Mostrar1.aspx";
    });
    $("#PizBtn").click(function () {
        sessionStorage.setItem("Producto", "Pizza");
        location.href = "../Publico/Mostrar1.aspx";
    });
    $("#BebBtn").click(function () {
        sessionStorage.setItem("Producto", "Bebida");
        location.href = "../Publico/Mostrar1.aspx";
    });
    $("#lexit").click(function (e) {
        debugger;
        e.preventDefault();
        $.ajax({
            url: '../WS/WSUsuario.asmx/Salir',
            data: {},
            contentType: 'application/json; utf-8',
            dataType: 'json',
            type: 'POST',
            success: function (data) {
                debugger;
                location.href = "../Publico/Principal.aspx";

            },
            error: function (err) {
                console.log(err);
            }
        });

    });
});