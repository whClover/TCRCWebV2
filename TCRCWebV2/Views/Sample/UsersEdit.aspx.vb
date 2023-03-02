Imports utility
Public Class UsersEdit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bClose_Click(sender As Object, e As EventArgs)
        Dim utility As New Utility(Me)
        utility.closeMe()
    End Sub
End Class