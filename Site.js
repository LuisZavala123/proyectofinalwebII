$(document).ready(function () {

    if (sessionStorage.getItem('User') == "1") {
        $("#agUsuario").show();
        $("#Reporte").show();
        $("#agProducto").show();
        $("#exit").show();
        $("#orden").show();
        $("#Login").hide();
    } else {
        $("#agUsuario").hide();
        $("#Reporte").hide();
        $("#agProducto").hide();
        $("#exit").hide();
        $("#orden").hide();
        $("#Login").show();
    }

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
        e.preventDefault();
        sessionStorage.setItem('User', null);
        location.href = "../Publico/Principal.aspx";
    });
});