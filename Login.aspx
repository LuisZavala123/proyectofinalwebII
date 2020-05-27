<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="proyectofinalwebII.Login" %>
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
                            <h1>Login</h1>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Correo Electronico" ID="label1"></asp:Label>
                        <asp:TextBox runat="server" id="txtEmail" type="email" class="form-control" placeholder="Ingresa tu Correo Electronico"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox runat="server" id="txtPassword" type="password" class="form-control" placeholder="Ingresa tu contraseña"></asp:TextBox>
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-block mybtn btn-primary tx-tfm" Text="Login"  id="btnLogin"/>
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
            $('#contenido_btnLogin').click(function (e) {
                e.preventDefault();
                var Password = $('#contenido_txtPassword').val();
                var Correo = $('#contenido_txtEmail').val();
                
                if (expr.test(Correo)) {
                    $.ajax({
                        url: 'WS/WSUsuario.asmx/Confirmar',
                        data: '{ "correo":"' + Correo + '", "pw":"' + Password + '"}',
                        contentType: 'application/json; utf-8',
                        dataType: 'json',
                        type: 'POST',
                        success: function (data) {
                            debugger;
                            if (data.d) {
                                sessionStorage.setItem('User', '1');
                            } else {

                            }

                            location.href = "Principal.aspx";

                        },
                        error: function (err) {
                            console.log(err);
                        }
                    });
                } else {
                    console.log("Correo invalido");
                }
            });
        });
        var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;
        
    </script>
</asp:Content>
