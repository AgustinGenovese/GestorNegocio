Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub IngresarButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("Clientes.aspx")
    End Sub
End Class