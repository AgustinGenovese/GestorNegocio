<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreadorVentas.aspx.vb" Inherits="WebGestor.CreadorVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-6">
                <!-- Contenido del lado izquierdo -->
                <h2 style="margin-top: 3%; margin-bottom: 3%">Seleccione el cliente</h2>

                <div class="mb-3">
                    <label for="txtNombreCliente" class="form-label">Cliente</label>
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="txtNombreCliente" CssClass="form-control" />
                        <div class="input-group-append" style="margin-left: 3%">
                            <asp:Button runat="server" ID="btnFiltrar" CssClass="btn btn-outline-secondary" Text="Filtrar" OnClick="btnFiltrar_Click" />
                        </div>
                    </div>
                </div>
                <div class="mt-3">
                    <div class="col-9">
                        <asp:GridView ID="dgvClientes" runat="server" CssClass="table table-striped"
                            AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField HeaderText="Cliente" DataField="Nombre" />
                                <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Seleccionar" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <asp:Button Text="Crear Venta" CssClass="btn btn-primary" ID="btnCrearVenta" runat="server" OnClick="btnCrearVenta_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
