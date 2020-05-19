<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="proyectofinalwebII.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="row justify-content-center my-2">
        <asp:Calendar ID="Calendario" CssClass="card" runat="server" OnSelectionChanged="Calendario_SelectionChanged"></asp:Calendar>   
        </div>
    <div class="row justify-content-center my-2">
            <asp:Button ID="btnGenerar" CssClass="btn btn-success mybtn btn-primary tx-tfm" runat="server" Text="Generar Reporte" />
        </div>
        <asp:GridView CssClass="table table-bordered table-striped" ID="grvLista" runat="server"
             DataKeyNames="Tipo">
            <Columns>
                <asp:BoundField DataField="Tipo" HeaderText="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad Vendida" />
                <asp:BoundField DataField="Total" HeaderText="Total Vendido" />
            </Columns>
        </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src="datatables.min.js">
     $(document).ready(function () {
        $('#grvLista').DataTable();
     });
   </script>
</asp:Content>
