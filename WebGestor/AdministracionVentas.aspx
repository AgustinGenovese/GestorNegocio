<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AdministracionVentas.aspx.vb" Inherits="WebGestor.AdministracionVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-6">
                <h2 style="margin-top: 3%; margin-bottom: 3%">Detalle de Venta</h2>
                <div class="mb-3">
                    <label for="txtID" class="form-label">ID</label>
                    <asp:TextBox runat="server" ID="txtID" CssClass="form-control" ClientIDMode="Static" Enabled="False" />
                </div>
                <div class="mb-3">
                    <label for="txtTotal" class="form-label">Total</label>
                    <asp:TextBox runat="server" ID="txtTotal" CssClass="form-control" ClientIDMode="Static" Enabled="False" />
                </div>
                <div class="mb-3">
                    <label for="inputFecha">Fecha de Venta:</label>
                    <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="txtNombreCliente" class="form-label">Cliente</label>
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="txtNombreCliente" CssClass="form-control" />
                        <div class="input-group-append" style="margin-left: 3%">
                            <asp:Button runat="server" ID="btnTilde" CssClass="btn btn-outline-secondary" Text="✔️" OnClick="btnTilde_Click" />
                        </div>
                    </div>
                </div>
                <div class="mt-5">
                    <asp:Button Text="Eliminar Venta" ID="btnEliminar" CssClass="btn btn-danger" runat="server" OnClick="btnEliminar_Click" />
                </div>
            </div>

            <div class="col-md-6">
                <h3 style="margin-top: 7%; margin-bottom: 3%">Agregar Productos a venta</h3>

                <div class="row mb-3">
                    <div class="col-6">
                        <label for="txtProducto" class="form-label">Producto</label>
                        <asp:TextBox runat="server" ID="txtProducto" CssClass="form-control" ClientIDMode="Static" />
                    </div>
                    <div class="col-6">
                        <label for="txtCantidad" class="form-label">Cantidad</label>
                        <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" ClientIDMode="Static" />
                    </div>
                </div>

                <div class="mb-1">
                    <asp:GridView ID="dgvProductos" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField HeaderText="Producto" DataField="Nombre" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Seleccionar" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="row mb-5">
                    <div class="col-9"></div>
                    <div class="col-3 text-end">
                        <asp:Button Text="Agregar" CssClass="btn btn-primary" ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" />
                    </div>
                </div>

                <asp:GridView ID="dgvVentas" runat="server" CssClass="table table-striped"
                    AutoGenerateColumns="false" DataKeyNames="Id" >
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
                        <asp:BoundField HeaderText="Precio" DataField="PrecioUnitario" />
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                        <asp:BoundField HeaderText="Total" DataField="PrecioTotal" />
                    </Columns>
                </asp:GridView>

                <div class="row mb-3">
                    <div class="col-9"></div>
                    <div class="col-3 text-end">
                        <div class=" row mb-1">
                            <asp:TextBox Text="ID" ID="txtIDEliminar" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class=" row mb-5">
                            <asp:Button Text="Eliminar" CssClass="btn btn-danger" ID="btnEliminarVentaItem" runat="server" OnClick="btnEliminarVentaItem_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
