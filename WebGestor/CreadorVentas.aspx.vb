Imports NegocioGestor
Imports DominioGestor

Public Class CreadorVentas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnFiltrar_Click(sender As Object, e As EventArgs)

        Dim datosClientes As New ClienteDatos
        dgvClientes.Visible = True
        dgvClientes.DataSource = datosClientes.Filtrar("Nombre", "", txtNombreCliente.Text)
        dgvClientes.DataBind()

    End Sub

    Protected Sub dgvClientes_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim datosClientes As New ClienteDatos
        Dim venta As New Venta

        Dim indiceSeleccionado As Integer = dgvClientes.SelectedIndex
        If indiceSeleccionado >= 0 Then
            Dim idCliente As Integer = Convert.ToInt32(dgvClientes.DataKeys(indiceSeleccionado).Value)

            Dim clienteSeleccionado As Cliente = datosClientes.listarPorId(idCliente)
            venta.Cliente = clienteSeleccionado
        End If

        txtNombreCliente.Text = venta.Cliente.Nombre

    End Sub

    Protected Sub btnCrearVenta_Click(sender As Object, e As EventArgs)
        Dim venta As New Venta
        Dim datosCliente As New ClienteDatos
        Dim datosVenta As New VentasDatos

        For Each cliente As Cliente In datosCliente.Listar()
            If cliente.Nombre = txtNombreCliente.Text Then
                venta.Cliente = cliente
            End If
        Next

        venta.Fecha = DateTime.Today

        datosVenta.Agregar(venta)

        Response.Redirect("Ventas.aspx", False)

    End Sub
End Class