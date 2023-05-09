Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class index1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        check_GPA()
    End Sub

    Sub check_GPA()
        'checking group access
        Dim string_lock As String = "<i class=""fa fa-lock""></i> Locked"
        Dim string_unlock As String = "<i class=""fa fa-unlock""></i> Open"

        'administration
        If CheckGroup(25) = True Then
            bWODetails.Enabled = True
            tagWODetails.InnerHtml = string_unlock
            tagWODetails.Attributes("class") = "text-success"
        Else
            bWODetails.Enabled = False
            tagWODetails.InnerHtml = string_lock
            tagWODetails.Attributes("class") = "text-danger"
        End If
    End Sub

    Sub showAlert(ByVal type As String, ByVal msg As String)
        Dim optsc As String = "toastr.options = {
          ""closeButton"": false,
          ""debug"": false,
          ""newestOnTop"": false,
          ""progressBar"": false,
          ""positionClass"": ""toast-top-center"",
          ""preventDuplicates"": false,
          ""onclick"": null,
          ""showDuration"": ""300"",
          ""hideDuration"": ""1000"",
          ""timeOut"": ""5000"",
          ""extendedTimeOut"": ""1000"",
          ""showEasing"": ""swing"",
          ""hideEasing"": ""linear"",
          ""showMethod"": ""fadeIn"",
          ""hideMethod"": ""fadeOut""
        };"

        Dim script As String
        script = optsc & "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toastrMessage", script, True)
    End Sub

    Protected Sub bWODetails_Click(sender As Object, e As EventArgs)
        If CheckGroup(25) = False Then
            showAlert("warning", "You dont have access into this module(25), Please Contact System Administrator.")
            Exit Sub
        Else
            Response.Redirect(urlWODetails)
        End If

    End Sub
End Class