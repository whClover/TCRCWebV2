Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class AssemblyTemplateForm
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bsave_Click(sender As Object, e As EventArgs)
        Dim eunitdescid, emaintid, etemplatename, eactive, query, etype, eid As String

        If ddunitdesc.Text = String.Empty Then
            showAlertV2("info", "Please select unit desc")
            Exit Sub
        End If

        If ddMaintID.Text = String.Empty Then
            showAlertV2("info", "Please select maint ID")
            Exit Sub
        End If

        If tTemplateName.Text = String.Empty Then
            showAlertV2("info", "Please Fill Template Name")
            Exit Sub
        End If

        eunitdescid = evar(ddunitdesc.SelectedValue, 0)
        emaintid = evar(ddMaintID.SelectedValue, 1)
        eactive = evar(ddActive.SelectedValue, 0)
        etemplatename = evar(tTemplateName.Text, 1)

        If hid.Value = String.Empty Then
            etype = 1
            eid = 0
        Else
            etype = 2
            eid = hid.Value
        End If

        query = "exec dbo.AssemblyTemplateGPSubmit " & eid & "," & etype & "," & eunitdescid & "," & emaintid & "," & etemplatename & "," & eactive & "," & eByName()
        executeQuery(query)
        DirectCast(Page, AssemblyTemplateList).bindingdata()
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub
End Class