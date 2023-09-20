Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class IndexWS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ss_userid") = "" Then
            'Response.Redirect(urlTCRCLogin)
        Else
        End If
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

    Protected Sub b5sapv_Click(sender As Object, e As EventArgs)
        Dim dt As New DataTable
        Dim ename As String = Session("ss_username")
        Dim query As String = "select * from v_5SRegister where AssignTo=" & evar(ename, 1) & " and SupvApprovedBy is null"
        dt = GetDataTable(query)
        If dt.Rows.Count = 0 Then
            showAlertV2("info", "There are no oustanding inspection to approve")
            Exit Sub
        End If

        Response.Redirect(url5sApv)
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub

    Protected Sub bwstesting_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlTestWSIndex)
    End Sub
End Class