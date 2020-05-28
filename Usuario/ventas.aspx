<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ventas.aspx.cs" Inherits="proyectofinalwebII.ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../css/popup.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div id="cont" onload="nombres" class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
            <div id="primero">
                <div class="myform form">
                    <div class="logo mb-3">
                        <div class="col-md-12 text-center">
                            <h1>Venta</h1>
                        </div>
                    </div>
                    <div class="row">
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Producto"></asp:Label>
                            <asp:DropDownList ID="CboxProducto" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Cantidad"></asp:Label>
                        <div class="popup"><span id="popt1" class="popuptext">X</span></div>
                        <asp:TextBox runat="server" id="txtCantidad" type="number" class="form-control"></asp:TextBox>
                    </div>
                        <div class="form-group">
                        <asp:Label runat="server" Text="Descripcion"></asp:Label>
                        <asp:TextBox runat="server" id="txtDescripcion" type="text" class="form-control"></asp:TextBox>
                    </div>
                        <div class="form-group">
                        <asp:Label runat="server" Text="Total: $"></asp:Label>
                        <asp:Label runat="server" Text="0" id="lbltotal"></asp:Label>
                    </div>
                        <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-success mybtn btn-primary tx-tfm" Text="Agregar" id="btnAgregar"/>
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-success mybtn btn-primary tx-tfm" Text="Aceptar"  id="btnAceptar"/>
                    </div>
                    </div>
                </div>
            </div>
            </div>
            <div id="gridViewDiv" class="form-group">
                <table id="grvLista" class="table table-striped table-bordered" ></table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src="../js/datatables.min.js">
     $(document).ready(function () {
        $('#grvLista').DataTable();
     });
   </script>
        <script type="text/javascript" >
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
        </script>
    
</asp:Content>
