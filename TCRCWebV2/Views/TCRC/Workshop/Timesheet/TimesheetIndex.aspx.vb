Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class TimesheetIndex
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingdata()
            tStart.Value = Now()
            tEnd.Value = Now()
        End If
    End Sub

    Sub bindingdata()
        Dim dt As New DataTable
        Dim query As String = "select * from v_TCRPDailyTimeSheet"
    End Sub
End Class