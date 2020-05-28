

$(document).ready(function () {
    
    function popear(c) {
        if (c == 1) {
            var popup = document.getElementById("popt1");
            popup.classList.toggle("show");
        } else if (c == 2) {
            var popup = document.getElementById("popt2");
            popup.classList.toggle("show");
        }
            
        

    }
    $('#contenido_btnLogin').click(function (e) {
        debugger;
        e.preventDefault();
        var Password = $('#contenido_txtPassword').val();
        var Correo = $('#contenido_txtEmail').val();
        debugger;
        if (expr.test(Correo)) {
            $.ajax({
                url: '../WS/WSUsuario.asmx/Confirmar',
                data: '{ "correo":"' + Correo + '", "pw":"' + Password + '"}',
                contentType: 'application/json; utf-8',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    debugger;
                    if (data.d) {
                        sessionStorage.setItem('User', '1');
                        location.href = "Principal.aspx";
                    } else {
                        popear(2);
                    }

                },
                error: function (err) {
                    console.log(err);
                }
            });
        } else {

            popear(1);
            console.log("Correo invalido");
        }
    });
});
var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;