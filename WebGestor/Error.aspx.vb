Public Class _Error
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("error") IsNot Nothing Then
            lblMensaje.Text = Session("error").ToString()
        End If
    End Sub

End Class