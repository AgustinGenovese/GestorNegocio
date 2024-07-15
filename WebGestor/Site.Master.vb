Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("error") Is Nothing Then
                Session("error") = String.Empty ' Inicializa la sesión si está vacía
            End If
        End If

    End Sub
End Class