Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Public Class MeaInspTemplateRef
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bSave_Click(sender As Object, e As EventArgs)
        Dim eid As String = Request.QueryString("id")
        Dim esec As String = evar(tSec.Text, 1)
        Dim editorData As String = evar(summernote.Value, 1)

        Dim eAction As String = evar(hAction.Value, 1)
        Dim eSubSec As String = String.Empty
        If tSubSec.Text = String.Empty Then
            showAlert("warning", "Please Fill Sub Section")
            Exit Sub
        Else
            eSubSec = evar(tSubSec.Text, 1)
        End If

        Dim eSeqSubSec As String = String.Empty
        If tSeq.Text = String.Empty Then
            showAlert("warning", "Please Fill Sequence")
            Exit Sub
        Else
            eSeqSubSec = evar(tSeq.Text, 1)
        End If


        editorData = Replace(editorData, "<table class=table table-bordered>", "<table class=""table table-bordered table-striped gridview"">")
        Try
            Dim query As String = "exec dbo.TCRCMeaInspRefSubmit " & eAction & "," & eid & "," & esec & "," & eSeqSubSec & "," & eSubSec & "," & editorData & "," & eByName()
            executeQuery(query)
            showAlert("success", "Saved")
            DirectCast(Page, MeaTemplateSecDetails).BindingData()
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try
    End Sub

    Sub showAlert(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toastrMessage", script, True)
    End Sub
End Class