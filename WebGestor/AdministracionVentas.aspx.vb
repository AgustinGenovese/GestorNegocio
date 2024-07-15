Imports System.Globalization
Imports DominioGestor
Imports NegocioGestor

Public Class AdministracionVentas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarProductos()
            Dim id As String = Request.QueryString("id")
            If Not String.IsNullOrEmpty(id) Then
                CargarVenta(id)
            Else
                ConfigurarModoCreacion()
            End If
        End If
    End Sub

    Private Sub CargarProductos()
        Dim datosProductos As New ProductoDatos()
        dgvProductos.DataSource = datosProductos.Listar()
        dgvProductos.DataBind()
    End Sub

    Private Sub CargarVenta(ByVal id As String)
        Dim datosVentas As New VentasDatos()
        Dim venta As Venta = datosVentas.listarPorId(id)

        txtID.Text = venta.Id

        txtNombreCliente.Text = venta.Cliente.Nombre
        txtFecha.Text = venta.Fecha.ToString("yyyy-MM-dd")

        CargarVentaItems(id, venta)
    End Sub

    Private Sub CargarVentaItems(ByVal id As String, venta As Venta)
        Dim datosVentasItems As New VentasItemDatos()
        Dim listaVentaItems As List(Of VentaItem) = datosVentasItems.listarPorId(id)
        dgvVentas.DataSource = listaVentaItems
        dgvVentas.DataBind()

        For Each ventaItem As VentaItem In listaVentaItems
            venta.Items.Add(ventaItem)
        Next

        txtTotal.Text = venta.CalcularTotal()

    End Sub

    Private Sub ConfigurarModoCreacion()
        btnEliminar.Visible = False
        btnTilde.Visible = False
    End Sub

    Protected Sub btnTilde_Click(sender As Object, e As EventArgs)

        Dim idVenta = txtID.Text
        Dim datosProducto As New VentasDatos()
        Dim seleccionado As Venta = datosProducto.listarPorId(idVenta)
        seleccionado.Cliente.Nombre = txtNombreCliente.Text

        Dim datosCliente As New ClienteDatos()

        Try
            datosCliente.Modificar(seleccionado.Cliente)
            Response.Redirect("AdministracionVentas.aspx?id=" + idVenta, False)
        Catch ex As Exception
            Session("error") = ex.ToString()
            Response.Redirect("Error.aspx")
        End Try

    End Sub

    Protected Sub dgvProductos_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim datosProducto As New ProductoDatos
        Dim producto As New Producto

        Dim indiceSeleccionado As Integer = dgvProductos.SelectedIndex
        If indiceSeleccionado >= 0 Then
            Dim idProducto As Integer = Convert.ToInt32(dgvProductos.DataKeys(indiceSeleccionado).Value)

            Dim productoSeleccionado As Producto = datosProducto.listarPorId(idProducto)
            txtProducto.Text = productoSeleccionado.Nombre
        End If

    End Sub


    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs)

        Dim datosProducto As New ProductoDatos
        Dim datosVenta As New VentasDatos
        Dim datosVentasItems As New VentasItemDatos()
        Dim ventaItem As New VentaItem()

        For Each venta As Venta In datosVenta.Listar()
            If venta.Id = txtID.Text Then
                ventaItem.VentaAsociada = venta
            End If
        Next

        For Each producto As Producto In datosProducto.Listar()
            If producto.Nombre = txtProducto.Text Then
                ventaItem.Producto = producto
                ventaItem.PrecioUnitario = producto.Precio
                ventaItem.Cantidad = Convert.ToInt32(txtCantidad.Text)
                ventaItem.CalcularTotal()
                datosVentasItems.Agregar(ventaItem, txtTotal.Text)

            End If
        Next

        Dim listaVentaItems As New List(Of VentaItem)()
        listaVentaItems = datosVentasItems.listarPorId(txtID.Text)
        dgvVentas.DataSource = listaVentaItems
        dgvVentas.DataBind()

        Response.Redirect("AdministracionVentas.aspx?id=" + txtID.Text, False)

    End Sub

    Protected Sub btnEliminarVentaItem_Click(sender As Object, e As EventArgs)

        Dim datosVentasItems As New VentasItemDatos
        datosVentasItems.Eliminar(txtIDEliminar.Text)

        Dim listaVentaItems As New List(Of VentaItem)()
        listaVentaItems = datosVentasItems.listarPorId(txtID.Text)
        dgvVentas.DataSource = listaVentaItems
        dgvVentas.DataBind()

    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs)
        Dim datosVenta As New VentasDatos
        datosVenta.Eliminar(txtID.Text)

        Dim datosVentasItems As New VentasItemDatos
        datosVentasItems.EliminarPorIdVentaGeneral(txtID.Text)

        Response.Redirect("Ventas.aspx", False)

    End Sub
End Class