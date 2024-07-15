Imports DominioGestor
Imports NegocioGestor

Public Class Productos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim datosProducto As New ProductoDatos()
        Dim listaProductos As New List(Of Producto)()
        listaProductos = datosProducto.Listar()

        dgvProducto.DataSource = listaProductos
        dgvProducto.DataBind()

        If Not IsPostBack Then
            ddlCriterio.Items.Add("Contiene")
            ddlCriterio.Items.Add("Comienza con")
            ddlCriterio.Items.Add("Termina con")
        End If

    End Sub

    Protected Sub ddlCampo_SelectedIndexChanged(sender As Object, e As EventArgs)

        ddlCriterio.Items.Clear()

        If ddlCampo.SelectedItem.ToString() = "Precio" Then
            ddlCriterio.Items.Add("Igual a")
            ddlCriterio.Items.Add("Mayor a")
            ddlCriterio.Items.Add("Menor a")
        Else
            ddlCriterio.Items.Add("Contiene")
            ddlCriterio.Items.Add("Comienza con")
            ddlCriterio.Items.Add("Termina con")
        End If

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs)

        Try
            Dim datosProductos As New ProductoDatos()
            dgvProducto.DataSource = datosProductos.Filtrar(
                ddlCampo.SelectedItem.ToString(),
                ddlCriterio.SelectedItem.ToString(),
                txtFiltro.Text)
            dgvProducto.DataBind()

        Catch ex As Exception
            Session.Add("error", ex.ToString())
            Response.Redirect("Error.aspx")
        End Try

    End Sub

    Protected Sub dgvProducto_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ID As String = dgvProducto.SelectedDataKey.Value.ToString()
        Response.Redirect("AdministracionProductos.aspx?id=" + ID)

    End Sub
End Class