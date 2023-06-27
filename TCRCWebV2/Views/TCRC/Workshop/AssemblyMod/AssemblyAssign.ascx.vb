Imports TCRCWebV2.Utility
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString

Public Class AssemblyAssign
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bassign_Click(sender As Object, e As EventArgs)
        Dim ewo As String = evar(Me.modWONO.Text, 1)
        Dim eidtemplate As String = evar(Me.modDDTemplate.SelectedValue, 1)
        Dim query As String = "exec dbo.AssignAssemblyTemplateRev " + ewo + "," + eidtemplate + ",1," & eByName() & ""
        executeQuery(query)
        Response.Redirect(urlAssemblyMea & "?wo=" & modWONO.Text)
    End Sub
End Class