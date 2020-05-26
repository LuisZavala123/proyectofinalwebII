<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="proyectofinalwebII.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="row justify-content-center my-2">
        <asp:Calendar ID="Calendario" CssClass="card" runat="server"></asp:Calendar>   
        </div>
    <div class="row justify-content-center my-2">
            <asp:Button ID="btnGenerar" CssClass="btn btn-success mybtn btn-primary tx-tfm" runat="server" Text="Generar Reporte" />
        </div>
        <table id="grvLista" class="table table-striped table-bordered" ></table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src="datatables.min.js">
     $(document).ready(function () {
        $('#grvLista').DataTable();
     });
   </script>

    <script type="text/javascript">
       
        $(document).ready(function () {
          
            if (sessionStorage.getItem('User') != "1") {
                debugger;
                location.href = "Principal.aspx";
            }
            $('#contenido_btnGenerar').click(function (e) {
                e.preventDefault();
                let fecha = '<%= Calendario.SelectedDate.Day+"-"+Calendario.SelectedDate.Month+"-"+Calendario.SelectedDate.Year %>'; 
                debugger;
                $.ajax({
                    url: 'WS/WSVenta.asmx/GetallDetalles',
                    data: '{ "fecha":"' + fecha + '"}',
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
                                '<td>' + data.d[i].Total + '</td>' ;
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
        });
    </script>
</asp:Content>
