<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ModificacionProductos.aspx.vb" Inherits="WebGestor.ModificacionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">

            <h1 style="margin-bottom: 40px;">Informacion del Articulo</h1>

            <!-- Primer mitad pantalla -->

            <div class="col-6">
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Codigo</label>
                    <asp:TextBox runat="server" ID="txtCodigo" AutoPostBack="true" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" AutoPostBack="true" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripcion</label>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="TxtDescripcion" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtMarca" class="form-label">Marca</label>
                    <asp:DropDownList runat="server" CssClass="form-select" ID="ddlMarca"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="txtCategoria" class="form-label">Categoria</label>
                    <asp:DropDownList runat="server" CssClass="form-select" ID="ddlCategoria"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:TextBox runat="server" ID="TxtPrecio" AutoPostBack="true" CssClass="form-control" />
                </div>
            </div>

            <!-- Segunda mitad pantalla -->
            <div class="col-6">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtImagen" class="form-label">Imagen</label>
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control" />
                                <asp:Button Text="Cargar" CssClass="btn btn-primary" runat="server" OnClick="btnCargar_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="Button1" runat="server" OnClick="btnAceptar_Click" />
                    <a href="ListaArticulos.aspx">Cancelar</a>
                    <br />
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Button Text="Eliminar" CssClass="btn btn-danger" ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" />
                        </div>


                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmarEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" CssClass="btn btn-outline-danger" ID="btnConfirmaEliminacion" OnClick="btnConfirmaEliminacion_Click" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
