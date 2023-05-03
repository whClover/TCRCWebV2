Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class AssemblyMea1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bsave_Click(sender As Object, e As EventArgs)
        Dim eid As String = Me.eid.Value
        Dim evalue As String = String.Empty

        Select Case evaltype.Value
            Case "1"
                evalue = evar("OK", 1)
            Case "2"
                evalue = evar(emeanum.Text, 1)
            Case "3"
                evalue = evar(emeatext.Text, 1)
            Case Else
                Exit Sub
        End Select

        Dim query As String = "update tbl_AssemblyInput 
            set AssemblyVal=" & evalue & ",
            ModBy=" & eByName() & ",ModDate=GetDate() 
            where IDAssemblyInput=" & eid
        executeQuery(query)
    End Sub
End Class