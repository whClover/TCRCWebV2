Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaTemplateSecEdit
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'aftInsp.Checked = False
    End Sub

    Protected Sub bSave_Click(sender As Object, e As EventArgs)
        Dim eseq, ecursection, esection, eaftinsp As String

        Dim eid As String = IDGroup.Value
        'If eid = String.Empty Then
        '    lNotif.InnerText = "ID Not Founds !"
        '    Exit Sub
        'End If

        If tSeq.Text = String.Empty Then
            showAlertv2("warning", "Please Fill Sequence")
            Exit Sub
        Else
            eseq = evar(tSeq.Text, 0)
        End If

        If tSection.Text = String.Empty Then
            showAlertv2("warning", "Please Fill Section Name")
            Exit Sub
        Else
            ecursection = evar(cursection.Value, 1)
            esection = evar(tSection.Text, 1)
        End If

        If ddAftInsp.SelectedValue = True Then
            eaftinsp = 1
        Else
            eaftinsp = 0
        End If

        Dim query As String = "exec dbo.InspSubmitTemplateSec " & eid & "," & eseq & "," & ecursection & "," & esection & "," & eaftinsp & "," & eByName()
        executeQuery(query)
        DirectCast(Page, MeaInspTemplateSec).bindingData()
    End Sub

    Sub showAlertv2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toastrMessage", script, True)
    End Sub
End Class