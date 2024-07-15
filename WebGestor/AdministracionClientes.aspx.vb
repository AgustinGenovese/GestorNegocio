Imports DominioGestor
Imports NegocioGestor

Public Class AdministracionClientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim id As String = If(Request.QueryString("id") IsNot Nothing, Request.QueryString("id").ToString(), "")

        If id <> "" AndAlso Not IsPostBack Then
            Dim datosCliente As New ClienteDatos()
            Dim seleccionado As Cliente = datosCliente.listarPorId(id)

            txtID.Text = seleccionado.Id
            txtNombre.Text = seleccionado.Nombre
            txtCorreo.Text = seleccionado.Correo
            txtTelefono.Text = seleccionado.Telefono

            txtID.ReadOnly = True
        Else
            btnEliminar.Visible = False
        End If

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs)

        Dim cliente As New Cliente()
        cliente.Nombre = txtNombre.Text
        cliente.Telefono = txtTelefono.Text
        cliente.Correo = txtCorreo.Text

        Dim datosCliente As New ClienteDatos()

        Dim id As String = If(Request.QueryString("id") IsNot Nothing, Request.QueryString("id").ToString(), "")
        If id = "" Then
            Agregar(cliente, datosCliente)
        Else
            cliente.Id = id
            Modificar(cliente, datosCliente)
        End If

    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs)
        Dim datosCliente As New ClienteDatos()
        Dim id As Integer = Integer.Parse(txtID.Text)

        Try
            datosCliente.Eliminar(id)
            Response.Redirect("Clientes.aspx", False)
        Catch ex As Exception
            Session("error") = ex.ToString()
            Response.Redirect("Error.aspx")
        End Try
    End Sub

    Protected Sub Agregar(cliente As Cliente, datosCliente As ClienteDatos)

        Try
            datosCliente.Agregar(cliente)
            Response.Redirect("Clientes.aspx", False)
        Catch ex As Exception
            Session("error") = ex.ToString()
            Response.Redirect("Error.aspx")
        End Try
    End Sub

    Protected Sub Modificar(cliente As Cliente, datosCliente As ClienteDatos)

        Try
            datosCliente.Modificar(cliente)
            Response.Redirect("Clientes.aspx", False)
        Catch ex As Exception
            Session("error") = ex.ToString()
            Response.Redirect("Error.aspx")
        End Try

    End Sub

End Class