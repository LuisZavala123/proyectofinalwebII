<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ventas.aspx.cs" Inherits="proyectofinalwebII.ventas" %>
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
                        <asp:TextBox runat="server" id="txtCantidad" type="number" class="form-control"></asp:TextBox>
                    </div>
                        <div class="form-group">
                        <asp:Label runat="server" Text="Total: $"></asp:Label>
                        <asp:Label runat="server" Text="0" id="lbltotal"></asp:Label>
                    </div>
                        <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-success mybtn btn-primary tx-tfm" Text="Agregar" OnClick="btnAgregar_Click"/>
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-success mybtn btn-primary tx-tfm" Text="Aceptar"  OnClick="btnAceptar_Click"/>
                    </div>
                    </div>
                </div>
            </div>
            </div>
            <div class="form-group">
                <asp:GridView CssClass="table table-bordered table-striped" ID="grvLista" runat="server"
             OnRowCommand="grvLista_RowCommand" DataKeyNames="IdVenta" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="producto" HeaderText="Producto" />
                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="total" HeaderText="Total" />
                <asp:ButtonField CommandName="Eliminar" Text="Eliminar" />
            </Columns>
        </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src="datatables.min.js">
        
        $(document).ready(function () {
            $('#grvLista').DataTable();
        });
    </script>
    //no se que pase aqui :'c
    <script type="text/javascript">
        var expr = /^[0-9]+[.][0-9]?[1-9]$/;
        var ready = 0;
        $(document).ready(function () {
            
            $('#contenido_txtCantidad').keypress(function (e) {
                e.preventDefault();
                var exa = $('#contenido_txtCantidad').val();
                if (expr.test(exa)) {
                    ready += 1;
                } else {
                    ready = 0;
                }
            });
            if (ready = 1) {
                //Poner lo que quieras que haga si es cierto
            }

        });
    </script>
</asp:Content>
