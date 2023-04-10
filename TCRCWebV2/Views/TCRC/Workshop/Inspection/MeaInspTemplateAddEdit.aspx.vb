Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class MeaInspTemplateAddEdit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ss_userid") = "" Then
            Response.Redirect(urlTCRCLogin)
        End If

        If IsPostBack = False Then
            bindingData()
        End If
    End Sub

    Sub bindingData()
        Dim eid As String = Request.QueryString("id")
        Dim eseq As String = Request.QueryString("seq")
        Dim esec As String = Request.QueryString("sec")

        If eid = "0" Then
        Else
            tSeq.Text = eseq
            tSectionName.Text = esec
        End If
    End Sub

    Protected Sub bSave_Click(sender As Object, e As EventArgs)
        Dim eid As String = Request.QueryString("id")
        Dim esec, eseq As String

        If tSeq.Text = String.Empty Then
            showAlertv2("warning", "Please Fill Sequence")
            Exit Sub
        Else
            eseq = evar(tSeq.Text, 1)
        End If

        If tSectionName.Text = String.Empty Then
            showAlertv2("warning", "Please Fill Section Name")
            Exit Sub
        Else
            esec = evar(tSectionName.Text, 1)
        End If

        Dim ecurSec As String = Request.QueryString("sec")

        Try
            Dim tempstring As String = "exec dbo.TCRCMeaInspSectionSubmit " & eid _
            & "," & evar(eseq, 1) & "," & evar(esec, 1) & "," & evar(ecurSec, 1) _
            & eByName()
            executeQuery(tempstring)
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try
    End Sub

    Protected Sub bClose_Click(sender As Object, e As EventArgs)
        Dim utility As New Utility(Me)
        utility.closeMe()
    End Sub

    Sub showAlertv2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toastrMessage", script, True)
    End Sub
End Class