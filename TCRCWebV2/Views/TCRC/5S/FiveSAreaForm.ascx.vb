Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class FiveSAreaForm
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bsave_Click(sender As Object, e As EventArgs)
        Dim earea, eseq As String
        If tSeq.Text <> String.Empty Then eseq = evar(tSeq.Text, 1) Else eseq = "NULL"
        If tArea.Text <> String.Empty Then earea = evar(tArea.Text, 1) Else earea = "NULL"

        Dim query As String
        If hidarea.Value = String.Empty Then
            query = "insert into tbl_5SArea(IDLocation,Seq,AreaDesc,Deactive) values 
                    (" & hidlocation.Value & "," & eseq & "," & earea & ",0)"
        Else
            query = "update tbl_5SArea set Seq=" & eseq & ",AreaDesc=" & earea & " where IDArea=" & hidarea.Value
        End If
        executeQuery(query)
        DirectCast(Page, FiveSArea).bindingdata()
    End Sub
End Class