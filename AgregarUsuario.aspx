<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="proyectofinalwebII.AgregarUsuario" %>
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
                            <h1>Nuevo Usuario</h1>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox runat="server" id="txtNombre" type="text" class="form-control" placeholder="Ingresa tu Nombre"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Apellido Paterno"></asp:Label>
                        <asp:TextBox runat="server" id="txtApellidoP" type="text" class="form-control" placeholder="Ingresa tu Apellido Paterno"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Apellido Materno"></asp:Label>
                        <asp:TextBox runat="server" id="txtApellidoM" type="text" class="form-control" placeholder="Ingresa tu Materno"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Correo Electronico"></asp:Label>
                        <asp:TextBox runat="server" id="txtEmail" type="email" class="form-control" placeholder="Ingresa tu Correo Electronico"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox runat="server" id="txtPassword" type="password" class="form-control" placeholder="Ingresa tu contraseña"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Repite Contraseña"></asp:Label>
                        <asp:TextBox runat="server" id="txtRPassword" type="password" class="form-control" placeholder="Ingresa tu contraseña"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Tipo"></asp:Label>
                            <asp:DropDownList ID="CboxTipo" CssClass="form-control" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-danger mybtn btn-primary tx-tfm" Text="Cancelar" OnClick="btnCancelar_Click" />
                        <asp:Button runat="server" class=" btn btn-success mybtn btn-primary tx-tfm" Text="Aceptar" ID="btnAceptar" />
                    </div>
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            
            if (sessionStorage.getItem('User') != "1") {
                debugger;
                location.href = "Principal.aspx";
            }

            $('#contenido_btnAceptar').click(function (e) {
                e.preventDefault();

                debugger;

                var Nombre = $('#contenido_txtNombre').val();
                var ApellidoP = $('#contenido_txtApellidoP').val();
                var ApellidoM = $('#contenido_txtApellidoM').val();
                var Password = $('#contenido_txtPassword').val();
                var Correo = $('#contenido_txtEmail').val();
                var tipo = $('#contenido_CboxTipo').val();

                if (exprn.test(Nombre)) {
                    ready += 1;
                } else {
                    ready = 0;
                }
                if (exprn.test(ApellidoP)) {
                    ready += 1;
                } else {
                    ready = 0;
                }
                if (exprn.test(ApellidoM)) {
                    ready += 1;
                } else {
                    ready = 0;
                }
                if (expr.test(Correo)) {
                    ready += 1;
                } else {
                    ready = 0;
                }
                var exa2 = $('#contenido_txtPassword').val();
                if (Password = exa2) {
                    ready += 1;
                } else {
                    ready = 0;
                }
                console.log(ready);
                if (ready == 5) {
                    console.log("Si");
                    ready = 0;
                    $.ajax({
                        url: 'WS/WSUsuario.asmx/Agregar',
                        data: '{ "nom":"' + Nombre + '", "primer_apellido":"' + ApellidoP + '", "segundo_apellido":"' + ApellidoM + '", "contraseña": "' + Password + '", "Correo": "' + Correo + '", "Tipo":"' + tipo + '"}',
                        contentType: 'application/json; utf-8',
                        dataType: 'json',
                        type: 'POST',
                        success: function (data) {
                            console.log(data);
                        },
                        error: function (err) {
                            console.log(err);
                        }
                    });
                } else {
                    console.log("Verifique los datos");
                } 
            });
        });
        var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;
        var exprn = /^[A-ZÁÉÍÓÚ][a-záéíúó]+$/;
        var ready = 0;
        
    </script>
</asp:Content>
