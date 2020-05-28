function popear() {
    var popup = document.getElementById("popt1");
    popup.classList.toggle("show");
}
function eliminar(dato) {
    dato.preventDefault;

    $.ajax({
        url: '../WS/WSVenta.asmx/quitarDetalle',
        data: { id: dato },
        contentType: 'application/json; utf-8',
        dataType: 'json',
        type: 'POST',
        success: function (data) {
            $('#grvLista tbody').remove();
            $('#grvLista tr').remove();
            $('#grvLista td').remove();
            let tabla = $('#grvLista');
            let encabezado = $("<thead/>").append("<tr><th>Producto</th><th>Cantidad</th><th>Total</th><td></td>");
            $(tabla).append(encabezado);
            $(tabla).append("<tbody/>");

            let fila;
            for (var i = 0; i < data.d.length; i++) {
                fila = document.createElement("tr");
                let cosa = '<td>' + data.d[i].Tipo + '</td>' +
                    '<td>' + data.d[i].cantidad + '</td>' +
                    '<td>' + data.d[i].total + '</td>' +
                    '<td>' +
                    '<button type="button" onclick="eliminar(' + data.d[i].producto + ')" class="btn btn-danger">Eliminar</button>'
                    + '</td>';
                fila.innerHTML = cosa;
                $(tabla).children('tbody').append(fila);

            }
            location.href = "../Publico/Principal.aspx";
            console.log(data);
        },
        error: function (err) {
            console.log(err);
        }
    });
}
$(document).ready(function nombres(e) {
    e.preventDefault;
    $.ajax({
        url: '../WS/WSArticulos.asmx/GetNombres',
        data: {},
        contentType: 'application/json; utf-8',
        dataType: 'json',
        type: 'POST',
        success: function (data) {
            var models = (typeof data.d) == 'string' ? eval('(' + data.d + ') ') : data.d;
            $('#contenido_CboxProducto').get(0).options.length = 0;

            for (var i = 0; i < models.length; i++) {

                var val = models[i];

                $('#contenido_CboxProducto').get(0).options[$('#contenido_CboxProducto').get(0).options.length] = new Option(val);

            }
            console.log(data);
        },
        error: function (err) {
            console.log(err);
        }
    });

});
$(document).ready(function () {
    if (sessionStorage.getItem('User') != "1") {
        debugger;
        location.href = "../Publico/Principal.aspx";
    }
    $('#contenido_btnAgregar').click(function (e) {
        e.preventDefault();
        var prod = $('#contenido_CboxProducto').val();
        var cant = $('#contenido_txtCantidad').val();
        $.ajax({
            url: '../WS/WSVenta.asmx/detalle',
            data: '{ "producto":"' + prod + '", "Cantidad": "' + cant + '"}',
            contentType: 'application/json; utf-8',
            dataType: 'json',
            type: 'POST',
            success: function (data) {

                $('#grvLista tbody').remove();
                $('#grvLista tr').remove();
                $('#grvLista td').remove();
                let tabla = $('#grvLista');
                let encabezado = $("<thead/>").append("<tr><th>Producto</th><th>Cantidad</th><th>Total</th><td></td>");
                $(tabla).append(encabezado);
                $(tabla).append("<tbody/>");
                debugger;
                let fila;
                let to = 0;
                for (var i = 0; i < data.d.length; i++) {


                    to = to + data.d[i].total;
                    fila = document.createElement("tr");
                    let cosa = '<td>' + data.d[i].Tipo + '</td>' +
                        '<td>' + data.d[i].cantidad + '</td>' +
                        '<td>' + data.d[i].total + '</td>' +
                        '<td>' +
                        '<button type="button" OnClick="eliminar(' + data.d[i].producto + ')" class="btn btn-danger">Eliminar</button>'
                        + '</td>';
                    fila.innerHTML = cosa;
                    $(tabla).children('tbody').append(fila);

                }
                $('#contenido_lbltotal').html(to);
                console.log(data);
            },
            error: function (err) {
                popear();
                console.log(err);
            }
        });
    });
});
$(document).ready(function () {
    $('#contenido_btnAceptar').click(function (e) {
        e.preventDefault();

        var desc = $('#contenido_txtDescripcion').val();
        var Total = $('#contenido_lbltotal').html();
        debugger;
        $.ajax({
            url: '../WS/WSVenta.asmx/Agregar',
            data: '{"Total":"' + Total + '", "Descripcion": "' + desc + '"}',
            contentType: 'application/json; utf-8',
            dataType: 'json',
            type: 'POST',
            success: function (data) {
                debugger;
                location.href = "../Publico/Principal.aspx";
                console.log(data);
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
});