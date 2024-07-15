<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="WebGestor.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2 style="margin-top: 2%; margin-bottom: 2%" class="mb-4">Registro de Clientes</h2>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo">
                        <asp:ListItem Text="ID" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Telefono" />
                        <asp:ListItem Text="Correo" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-12">
                <asp:GridView ID="dgvClientes" runat="server" CssClass="table table-striped"
                    AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                        <asp:BoundField HeaderText="Correo" DataField="Correo" />
                        <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Seleccionar" />
                    </Columns>
                </asp:GridView>
            </div>
            <a href="AdministracionClientes.aspx" cssclass="btn btn-primary">Agregar</a>
        </div>
    </div>

</asp:Content>
