Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class FiveSAssignArea
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            loadDropDown()
        End If
    End Sub

    Sub loadDropDown()
        BindDataDropDown(ddArea, "select * from tbl_5SLocation where Deactive=0", "LocationDesc", "IDLocation")
    End Sub

    Protected Sub bsave_Click(sender As Object, e As EventArgs)
        Dim eidlocation As String = ddArea.Text
        If eidlocation = String.Empty Then
            Exit Sub
        Else
            eidlocation = evar(ddArea.SelectedValue, 0)
        End If

        Dim query As String = "insert into tbl_5SFindingGP(IDLocation,JobNumber,RegisterBy,RegisterDate) values 
                                (" & eidlocation & ",'501037'," & eByName() & ",getdate())"
        executeQuery(query)

        'get last ID
        Dim query2 As String = "select top 1 * from tbl_5SFindingGP order by IDFindingGP desc"
        Dim dt As New DataTable
        dt = GetDataTable(query2)
        Dim eidgp As String = dt.Rows(0)("IDFindingGP")

        Response.Redirect(url5sDetails & "?id=" & eidgp)
    End Sub
End Class