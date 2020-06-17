var tabla = null;
function otro() {
    sessionStorage.setItem("indx", "5");
    location.href = "index.html";
}

$('#contenido_contenido_btnGenerar').click(function (e) {
    e.preventDefault();
    debugger;
    let fech = $('#Fecha').val();
    debugger;
    $.ajax({
        url: 'WS/WSVenta.asmx/GetallDetalles',
        data: '{ "fecha":"' + fech + '"}',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        type: 'POST',
        success: function (data) {
            debugger;

            $('#grvLista').empty();
            $('#grvLista thead').remove();
            $('#grvLista tbody').remove();
            $('#grvLista tr').remove();
            $('#grvLista td').remove();
            let tabla = $('#grvLista');
            let encabezado = $("<thead/>").append("<tr><th>Producto</th><th>Tipo</th><th>Cantidad</th><th>Total</th>");
            $(tabla).append(encabezado);
            $(tabla).append("<tbody/>");

            let fila;
            for (var i = 0; i < data.d.length; i++) {
                fila = document.createElement("tr");
                let cosa = '<td>' + data.d[i].Nombre + '</td>' +
                    '<td>' + data.d[i].Tipo + '</td>' +
                    '<td>' + data.d[i].Cantidad.toString() + '</td>' +
                    '<td>' + data.d[i].Total.toString() + '</td>';
                fila.innerHTML = cosa;
                $(tabla).children('tbody').append(fila);

            }
            debugger;
            
            $('#grvLista thead tr th').each(function (i) {
                var title = $(this).text();
                debugger;
                $(this).html('<input type="text" placeholder="Search ' + title + '" />');
                debugger;
                $('input', this).on('keyup change', function(e) {
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
            
            
            
            console.log(data);
        },
        error: function (err) {
            console.log(err);
        }
    });
});