Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class IndexWS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ss_userid") = "" Then
            Response.Redirect(urlTCRCLogin)
        Else
            loadUser()
        End If
    End Sub

    Sub loadUser()
        Dim query As String = "select *,dbo.GetSupvName(" & evar(Session("ss_userid"), 1) & ") as SupvName from tbl_user where userid=" & evar(Session("ss_userid"), 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count = 0 Then Exit Sub
        hFullName.InnerText = dt.Rows(0)("FullName").ToString()
        hTitle.InnerText = dt.Rows(0)("JobTitle").ToString()
        hEmail.InnerText = dt.Rows(0)("Email").ToString()
        hSupv.InnerText = dt.Rows(0)("SupvName").ToString()
        hJobCost.InnerText = dt.Rows(0)("JobCost").ToString()
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