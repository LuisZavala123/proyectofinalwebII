

if (sessionStorage.getItem('User') != "1") {
    debugger;
    location.href = "../Publico/Principal.aspx";
}
$('#contenido_btnGenerar').click(function (e) {
    e.preventDefault();
    debugger;
    let fech = $('#Fecha').val();
    debugger;
    $.ajax({
        url: '../WS/WSVenta.asmx/GetallDetalles',
        data: '{ "fecha":"' + fech + '"}',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        type: 'POST',
        success: function (data) {
            debugger;
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
                    '<td>' + data.d[i].Cantidad + '</td>' +
                    '<td>' + data.d[i].Total + '</td>';
                fila.innerHTML = cosa;
                $(tabla).children('tbody').append(fila);

            }
            console.log(data);
        },
        error: function (err) {
            console.log(err);
        }
    });
});