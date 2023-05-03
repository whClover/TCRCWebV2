Imports TCRCWebV2.GlobalString
Public Class IndexWS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub showAlert(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toastrMessage", script, True)
    End Sub

    Protected Sub comingsoon()
        showAlert("info", "Coming soon")
    End Sub

    Protected Sub bMeaWorksheet_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlMeasureWorksheet)
    End Sub

    Protected Sub bMeaTemplate_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlMeasureTemplate)
    End Sub

    Protected Sub bPrelimWorksheet_Click(sender As Object, e As EventArgs)
        comingsoon()
    End Sub

    Protected Sub bPrelimTemplate_Click(sender As Object, e As EventArgs)
        comingsoon()
    End Sub

    Protected Sub bCompRelease_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlComponentRelease)
    End Sub

    Protected Sub bassm_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlAssemblyList)
    End Sub
End Class