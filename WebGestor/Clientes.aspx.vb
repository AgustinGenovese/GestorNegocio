Imports DominioGestor
Imports NegocioGestor

Public Class Clientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim datosClientes As New ClienteDatos()
        Dim listaClientes As New List(Of Cliente)()
        listaClientes = datosClientes.Listar()

        dgvClientes.DataSource = listaClientes
        dgvClientes.DataBind()

        If Not IsPostBack Then
            ddlCriterio.Items.Add("Contiene")
            ddlCriterio.Items.Add("Comienza con")
            ddlCriterio.Items.Add("Termina con")
        End If

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs)
        Try
            Dim datosClientes As New ClienteDatos()
            dgvClientes.DataSource = datosClientes.Filtrar(
                ddlCampo.SelectedItem.ToString(),
                ddlCriterio.SelectedItem.ToString(),
                txtFiltro.Text)
            dgvClientes.DataBind()

        Catch ex As Exception
            Session.Add("error", ex.ToString())
            Response.Redirect("Error.aspx")
        End Try

    End Sub

    Protected Sub dgvClientes_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ID As String = dgvClientes.SelectedDataKey.Value.ToString()
        Response.Redirect("AdministracionClientes.aspx?id=" + ID)

    End Sub

End Class