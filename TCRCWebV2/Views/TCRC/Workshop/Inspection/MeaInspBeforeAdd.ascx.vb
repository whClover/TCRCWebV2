Imports Microsoft.SqlServer.Server
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaInspBeforeAdd
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bSave_Click(sender As Object, e As EventArgs)
        'Dim eIDGroup As String = evar(ddInspTemp.SelectedValue, 0)

        ''Try
        'Dim query As String = "exec dbo.[InspAssignWORev] " & eIDGroup & "," & evar(ewono, 1) & "," & eByName()
        'MsgBox(query)
        ''executeQuery(query)
        'Response.Redirect(urlMeasureWorksheetDetails & "?wo=" & ewono)
        ''Catch ex As Exception
        ''err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        ''End Try
    End Sub

    Protected Sub bSearch_Click(sender As Object, e As EventArgs)
        Dim ewo As String = two.Text
        Dim dt As New DataTable
        dt = GetDataTable("select wono,wodesc from v_intJobDetailRev3 where wono=" & evar(ewo, 1))
        If dt.Rows.Count > 0 Then
            twodesc.InnerText = dt.Rows(0)("wodesc")
        End If
    End Sub
End Class