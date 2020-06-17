var si = 0;
function eliminar(dato) {
    dato.preventDefault;
    debugger;
    $.ajax({
        url: 'WS/WSVenta.asmx/quitarDetalle',
        data: '{ "id":"' + dato + '"}',
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
            $('#contenido_contenido_lbltotal').html(to);
            $('#grvLista').DataTable();
            console.log(data);
        },
        error: function (err) {

            console.log(err);
        }
    });
}


$(document).ready(function nombres(e) {

    $('#frm').validate({
        rules: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: true
            }
        },
        messages: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: 'Por favor, ingrese una Cantidad'
            }
        }
    });
    e.preventDefault;
    $.ajax({
        url: 'WS/WSArticulos.asmx/GetNombres',
        data: {},
        contentType: 'application/json; utf-8',
        dataType: 'json',
        type: 'POST',
        success: function (data) {
            var models = (typeof data.d) == 'string' ? eval('(' + data.d + ') ') : data.d;
            $('#contenido_contenido_CboxProducto').get(0).options.length = 0;

            for (var i = 0; i < models.length; i++) {

                var val = models[i];

                $('#contenido_contenido_CboxProducto').get(0).options[$('#contenido_contenido_CboxProducto').get(0).options.length] = new Option(val);

            }
            console.log(data);
        },
        error: function (err) {
            console.log(err);
        }
    });

});
$(document).ready(function () {
    $('#frm').validate({
        rules: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: true
            }
        },
        messages: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: 'Por favor, ingrese una Cantidad'
            }
        }
    });
    $('#contenido_contenido_btnAgregar').click(function (e) {
        e.preventDefault();
        var prod = $('#contenido_contenido_CboxProducto').val();
        var cant = $('#contenido_contenido_txtCantidad').val();
        if (cant > 0) {
            $.ajax({
                url: 'WS/WSVenta.asmx/detalle',
                data: '{ "producto":"' + prod + '", "Cantidad": "' + cant + '"}',
                contentType: 'application/json; utf-8',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    if (data != null) {
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
                        $('#grvLista thead tr th').each(function (i) {
                            var title = $(this).text();
                            $(this).html('<input type="text" placeholder="Search ' + title + '" />');
                            
                            $('input', this).on('keyup change', function () {
                                if (table.column(i).search() !== this.value) {
                                    table
                                        .destroy()
                                        .column(i)
                                        .search(this.value)
                                        .draw();
                                }
                            });
                        });
                        debugger;
                        $('#grvLista thead tr th').each(function (i) {
                            var title = $(this).text();
                            debugger;
                            $(this).html('<input type="text" placeholder="Search ' + title + '" />');
                            debugger;
                            $('input', this).on('keyup change', function (e) {
                                if ($('#grvLista').DataTable().column(i).search() !== this.value && (e.keyCode == 13)) {
                                    debugger;
                                    $('#grvLista').DataTable({
                                        destroy: true,
                                        orderCellsTop: true,
                                        fixedHeader: true
                                    })
                                        .column(i)
                                        .search(this.value)
                                        .draw();
                                    console.log("fun");
                                    debugger;
                                }
                            });
                        });
                        debugger;

                        $('#grvLista').DataTable({
                            destroy: true,
                            orderCellsTop: true,
                            fixedHeader: true
                        });


                        $('#contenido_contenido_lbltotal').html(to);
                        console.log(data);
                    } else {
                        $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                            '<strong > revise los datos </strong >');
                        $("#mensaje").show();
                    }
                },
                error: function (err) {
                    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                        '<strong > revise los datos </strong >');
                    $("#mensaje").show();
                    console.log(err);
                }
            });
        } else {
            $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                '<strong > la cantidad debe ser mayor a 0 </strong >');
            $("#mensaje").show();
        }
        
    });
});
$(document).ready(function () {
    $('#frm').validate({
        rules: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: true
            }
        },
        messages: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: 'Por favor, ingrese una Cantidad'
            }
        }
    });
    $('#contenido_contenido_btnAceptar').click(function (e) {
        e.preventDefault();

        var desc = $('#contenido_contenido_txtDescripcion').val();
        var Total = $('#contenido_contenido_lbltotal').html();
        debugger;
        $.ajax({
            url: 'WS/WSVenta.asmx/Agregar',
            data: '{"Total":"' + Total + '", "Descripcion": "' + desc + '"}',
            contentType: 'application/json; utf-8',
            dataType: 'json',
            type: 'POST',
            success: function (data) {
                debugger;
                sessionStorage.setItem("indx", null);
                sessionStorage.setItem("accion", "Venta");
                location.href = "index.html";
                console.log(data);
            },
            error: function (err) {
                $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                    '<strong > a acurrido un error </strong >');
                $("#mensaje").show();
                console.log(err);
            }
        });
    });
});
