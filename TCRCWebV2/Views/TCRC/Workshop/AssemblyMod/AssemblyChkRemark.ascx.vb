Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class AssemblyChkRemark
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bsave_Click(sender As Object, e As EventArgs)
        Dim eremark As String
        Dim eid As String
        Dim ewo As String
        ewo = hwono.Value
        If tRemark.Text <> String.Empty Then
            eid = hidinsdetail.Value
            eremark = evar(tRemark.Text, 1)
            Dim query As String = "exec dbo.AssemblyAddRemark '" & eid & "'," & eByName() & "," & eremark
            executeQuery(query)
            showAlertV2("success", "Your remark has been saved successfully")
        End If

        Response.Redirect(urlAssemblyMea & "?wo=" & ewo)
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub
End Class