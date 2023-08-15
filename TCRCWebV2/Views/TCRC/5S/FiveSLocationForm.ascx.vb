Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class FiveSLocationForm
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bsave_Click(sender As Object, e As EventArgs)
        Dim elocation As String
        If tLocation.Text <> String.Empty Then elocation = evar(tLocation.Text, 1) Else elocation = "NULL"

        Dim query As String
        If hidlocation.Value = String.Empty Then
            query = "insert into tbl_5SLocation(LocationDesc,Deactive) values 
                    (" & elocation & ",0)"
        Else
            query = "update tbl_5SLocation set LocationDesc=" & elocation & " where IDLocation=" & hidlocation.Value
        End If
        executeQuery(query)
        DirectCast(Page, _5SLocation).bindingData()
    End Sub
End Class