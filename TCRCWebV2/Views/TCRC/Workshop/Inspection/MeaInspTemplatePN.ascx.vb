Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class MeaInspTemplatePN
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        load_data()
    End Sub

    Sub load_data()
        Dim dt As New DataTable
        Dim query As String = "select * from v_PartList"
        dt = GetDataTable(query)
        gvPN.DataSource = dt
        gvPN.DataBind()
    End Sub
End Class