<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="proyectofinalwebII.AgregarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
            <div id="primero">
                <div class="myform form">
                    <div class="logo mb-3">
                        <div class="col-md-12 text-center">
                            <h1>Nuevo Producto</h1>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox runat="server" id="txtNombre" type="text" class="form-control" placeholder="Ingresa el nombre del producto"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Costo"></asp:Label>
                        <asp:TextBox runat="server" id="txtCosto" type="text" class="form-control" placeholder="Ingresa el precio del producto"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Descripcion"></asp:Label>
                        <asp:TextBox runat="server" id="txtDescripcion" type="text" class="form-control" placeholder="Ingresa Descripcion el producto"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Tipo"></asp:Label>
                            <asp:DropDownList ID="CboxTipo" CssClass="form-control" runat="server">
                                <asp:ListItem>Hamburguesa</asp:ListItem>
                                <asp:ListItem>Pizza</asp:ListItem>
                                <asp:ListItem>Bebida</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-success mybtn btn-primary tx-tfm" Text="Aceptar" ID="btnAceptar"/>
                    </div>
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    
    <script type="text/javascript">
        var expr = /^[0-9]+[.][0-9]?[1-9]$/;
        var exprn = /^[A-ZÁÉÍÓÚ][a-záéíúó]+$/;
        $(document).ready(function () {
            
            if (sessionStorage.getItem('User') != "1") {
                debugger;
                location.href = "Principal.aspx";
            }
            $('#contenido_txtNombre').keypress(function (e) {
                e.preventDefault();
                var exa = $('#contenido_txtNombre').val();
                if (exprn.test(exa)) {
                    ready += 1;
                } else {
                    ready = 0;
                }
            });
            $('#contenido_txtCosto').keypress(function (e) {
                e.preventDefault();
                var exa = $('#contenido_txtCosto').val();
                if (expr.test(exa)) {
                    ready += 1;
                } else {
                    ready = 0;
                }
            });

            $('#contenido_btnAceptar').click(function (e) {
                if (ready = 2) {
                    e.preventDefault();
                    var Nombre = $('#contenido_txtNombre').val();
                    var Costo = $('#contenido_txtCosto').val();
                    var Desc = $('#contenido_txtDescripcion').val();
                    var tipo = $('#contenido_CboxTipo').val();
                    $.ajax({
                        url: 'WS/WSArticulos.asmx/Agregar',
                        data: '{ "nom":"' + Nombre + '", "costo":"' + Costo + '", "Descripcion":"' + Desc + '", "Tipo": "' + tipo + '" }',
                        contentType: 'application/json; utf-8',
                        dataType: 'json',
                        type: 'POST',
                        success: function (data) {
                            location.href ="Principal.aspx";
                        },
                        error: function (err) {
                            console.log(err);
                        }
                    });
                }
            });
        });
    </script>
</asp:Content>
