<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Ventas.aspx.vb" Inherits="WebGestor.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2 style="margin-top: 2%; margin-bottom: 2%" class="mb-4">Registro de Ventas</h2>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="ID" />
                        <asp:ListItem Text="Cliente" />
                        <asp:ListItem Text="Fecha" />
                        <asp:ListItem Text="Total" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" ID="lblCriterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                        <asp:ListItem Text="Contiene" />
                        <asp:ListItem Text="Comienza con" />
                        <asp:ListItem Text="Termina con" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" ID="lblFiltro" />
                    <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Seleccione la fecha de venta" ID="lblFecha" runat="server" />
                    <asp:Calendar runat="server" ID="calendario"></asp:Calendar>
                </div>
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-12">
                <asp:GridView ID="dgvVentas" runat="server" CssClass="table table-striped"
                    AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombre" />
                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                        <asp:BoundField HeaderText="Total" DataField="Total" />
                        <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Seleccionar" />
                    </Columns>
                </asp:GridView>
            </div>
            <a href="CreadorVentas.aspx" cssclass="btn btn-primary">Agregar</a>
        </div>
    </div>

</asp:Content>
