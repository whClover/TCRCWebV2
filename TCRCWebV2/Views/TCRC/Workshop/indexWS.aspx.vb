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
    End Sub

    Protected Sub bMeaWorksheet_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlMeasureWorksheet)
    End Sub

    Protected Sub bMeaTemplate_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlMeasureTemplate)
    End Sub

    Protected Sub basm_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlAssemblyList)
    End Sub

    Protected Sub bCompRelease_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlComponentRelease)
    End Sub

    Protected Sub fivesloc_Click(sender As Object, e As EventArgs)
        Response.Redirect(url5SLocation)
    End Sub

    Protected Sub fivesreg_Click(sender As Object, e As EventArgs)
        Response.Redirect(url5SRegister)
    End Sub

    Protected Sub fivesummary_Click(sender As Object, e As EventArgs)
        Response.Redirect(url5sSummary)
    End Sub
End Class