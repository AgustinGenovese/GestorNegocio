<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AdministracionProductos.aspx.vb" Inherits="WebGestor.AdministracionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2 style="margin-top: 2%; margin-bottom: 2%">Información del Producto</h2>

        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtID" class="form-label">ID</label>
                    <asp:TextBox runat="server" ID="txtID" CssClass="form-control" ClientIDMode="Static" Enabled="False" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtCategoria" class="form-label">Categoria</label>
                    <asp:TextBox runat="server" ID="txtCategoria" CssClass="form-control" />
                </div>
                <div class="mb-5">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" />
                    <a href="Clientes.aspx">Cancelar</a>
                </div>
                <div class="mb-3">
                    <asp:Button Text="Eliminar" CssClass="btn btn-danger" ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" />
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <img src="https://www.questionpro.com/blog/wp-content/uploads/2022/09/Portada-administracion-de-personal.jpg" width="90%" alt="Tik Tok - TACTICA"></a>
                </div>
            </div>
        </div>
    </div>
   
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var txtID = document.getElementById("txtID");

            if (txtID.disabled) {
                btnEliminar.style.display = 'none'; // Oculta el botón eliminar al cargar la página
            }
        });
</script>

</asp:Content>
