Imports DominioGestor
Imports NegocioGestor

Public Class Ventas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim datosVentas As New VentasDatos()
        Dim listaVentas As New List(Of Venta)()
        listaVentas = datosVentas.Listar()

        dgvVentas.DataSource = listaVentas
        dgvVentas.DataBind()

        If Not IsPostBack Then
            ddlCampo.SelectedIndex = 0
            calendario.Visible = False
            lblFecha.Visible = False
        End If

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs)

        Dim datosVentas As New VentasDatos()

        If ddlCampo.SelectedItem.ToString() = "Fecha" Then

            Dim fechaSeleccionada As DateTime = calendario.SelectedDate
            dgvVentas.DataSource = datosVentas.FiltrarPorFecha(fechaSeleccionada)
            dgvVentas.DataBind()
        Else
            Try
                dgvVentas.DataSource = datosVentas.Filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltro.Text)
                dgvVentas.DataBind()

            Catch ex As Exception
                Session.Add("error", ex.ToString())
                Response.Redirect("Error.aspx")
            End Try
        End If

    End Sub

    Protected Sub dgvVentas_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ID As String = dgvVentas.SelectedDataKey.Value.ToString()
        Response.Redirect("AdministracionVentas.aspx?id=" + ID)

    End Sub

    Protected Sub ddlCampo_SelectedIndexChanged(sender As Object, e As EventArgs)

        ddlCriterio.Items.Clear()

        If ddlCampo.SelectedItem.ToString() = "Total" Then
            ActivarDesactivarComponentes(True)
            ddlCriterio.Items.Add("Igual a")
            ddlCriterio.Items.Add("Mayor a")
            ddlCriterio.Items.Add("Menor a")

        ElseIf ddlCampo.SelectedItem.ToString() = "Fecha" Then
            ActivarDesactivarComponentes(False)

        Else
            ActivarDesactivarComponentes(True)
            ddlCriterio.Items.Add("Contiene")
            ddlCriterio.Items.Add("Comienza con")
            ddlCriterio.Items.Add("Termina con")

        End If

    End Sub

    Private Sub ActivarDesactivarComponentes(valor As Boolean)

        If valor = True Then
            lblCriterio.Visible = True
            lblFiltro.Visible = True
            ddlCriterio.Visible = True
            txtFiltro.Visible = True
            calendario.Visible = False
            lblFecha.Visible = False
        Else
            lblCriterio.Visible = False
            lblFiltro.Visible = False
            ddlCriterio.Visible = False
            txtFiltro.Visible = False
            calendario.Visible = True
            lblFecha.Visible = True
        End If

    End Sub

End Class