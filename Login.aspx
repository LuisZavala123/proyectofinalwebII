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
                        <asp:Label runat="server" Text="Correo Electronico"></asp:Label>
                        <asp:TextBox runat="server" id="txtEmail" type="email" class="form-control" placeholder="Ingresa tu Correo Electronico"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox runat="server" id="txtPassword" type="password" class="form-control" placeholder="Ingresa tu contraseña"></asp:TextBox>
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-block mybtn btn-primary tx-tfm" Text="Login" OnClick="btnLogin_Click"/>
                    </div>
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript">
        var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;
        var ready = 0;
        $(document).ready(function () {
            
            $('#contenido_txtEmail').keypress(function (e) {
                e.preventDefault();
                var exa = $('#contenido_txtEmail').val();
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
