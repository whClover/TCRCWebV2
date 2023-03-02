Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("ss_userid")) Then
            Dim fullname As String = Session("ss_fullname").ToString
            Dim email As String = Session("ss_Email").ToString
            sFullName.InnerText = fullname
            sEmail.InnerText = email
        End If

        If Session("startTime") Is Nothing Then
            Session("startTime") = DateTime.Now
        End If
    End Sub

    Public Sub RefreshMST()
        Dim script As String = "location.reload();"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Refresh", script, True)
    End Sub

End Class