Imports DominioGestor
Imports NegocioGestor

Public Class AdministracionProductos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim id As String = If(Request.QueryString("id") IsNot Nothing, Request.QueryString("id").ToString(), "")

        If id <> "" AndAlso Not IsPostBack Then
            Dim datosProducto As New ProductoDatos()
            Dim seleccionado As Producto = datosProducto.listarPorId(id)

            txtID.Text = seleccionado.Id
            txtNombre.Text = seleccionado.Nombre
            txtCategoria.Text = seleccionado.Categoria
            txtPrecio.Text = seleccionado.Precio

            txtID.ReadOnly = True
        Else
            btnEliminar.Visible = False
        End If

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs)

        Dim producto As New Producto()
        producto.Nombre = txtNombre.Text
        producto.Categoria = txtCategoria.Text
        producto.Precio = txtPrecio.Text

        Dim datosProducto As New ProductoDatos()

        Dim id As String = If(Request.QueryString("id") IsNot Nothing, Request.QueryString("id").ToString(), "")
        If id = "" Then
            Agregar(producto, datosProducto)
        Else
            producto.Id = id
            Modificar(producto, datosProducto)
        End If
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs)

        Dim datosProducto As New ProductoDatos()
        Dim id As Integer = Integer.Parse(txtID.Text)

        Try
            datosProducto.Eliminar(id)
            Response.Redirect("Productos.aspx", False)
        Catch ex As Exception
            Session("error") = ex.ToString()
            Response.Redirect("Error.aspx")
        End Try

    End Sub

    Protected Sub Agregar(producto As Producto, datosProducto As ProductoDatos)

        Try
            datosProducto.Agregar(producto)
            Response.Redirect("Productos.aspx", False)
        Catch ex As Exception
            Session("error") = ex.ToString()
            Response.Redirect("Error.aspx")
        End Try
    End Sub

    Protected Sub Modificar(producto As Producto, datosProducto As ProductoDatos)

        Try
            datosProducto.Modificar(producto)
            Response.Redirect("Productos.aspx", False)
        Catch ex As Exception
            Session("error") = ex.ToString()
            Response.Redirect("Error.aspx")
        End Try

    End Sub
End Class