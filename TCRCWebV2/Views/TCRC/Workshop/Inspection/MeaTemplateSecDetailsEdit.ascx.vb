Imports DocumentFormat.OpenXml.Wordprocessing
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaTemplateSecDetailsEdit
    Inherits System.Web.UI.UserControl
    Dim currentPage As MeaTemplateSecDetailsEdit = Me

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lNotif.Visible = False
        If Session("ss_userid") = "" Then
            Response.Redirect(urlTCRCLogin)
        End If
    End Sub

    Protected Sub bSave_Click(sender As Object, e As EventArgs)
        Dim eaction As String = String.Empty
        Dim eidGroup As String = String.Empty
        Dim eidDetail As String = String.Empty
        Dim eseq As String = String.Empty
        Dim esectionName As String = String.Empty
        Dim esubsectionname As String = String.Empty
        Dim ecursubsectionname As String = String.Empty
        Dim eitemdesc As String = String.Empty
        Dim erowcount As String = String.Empty
        Dim evaltype As String = String.Empty
        Dim ecostumecol As String = String.Empty

        Dim query As String = String.Empty
        Select Case TypeID.Value
            Case "1"
                eidGroup = Request.QueryString("id")
                esectionName = evar(tSec.Text, 1)
                eaction = evar(Action.Value, 1)

                If tIDDetail.Text = String.Empty Then
                    eidDetail = "0"
                Else
                    eidDetail = evar(tIDDetail.Text, 0)
                End If

                If tSeq.Text = String.Empty Then
                    showAlert("warning", "Please Fill Sequence")
                    Exit Sub
                Else
                    eseq = evar(tSeq.Text, 1)
                End If

                If tSubSec.Text = String.Empty Then
                    showAlert("warning", "Please Sub Section Name")
                    Exit Sub
                Else
                    ecursubsectionname = evar(tcurSubSec.Value, 1)
                    esubsectionname = evar(tSubSec.Text, 1)
                End If

                Try
                    query = "exec dbo.[TCRCMeaInspItemSubmit] " & eaction & "," & TypeID.Value & "," & eidGroup & "," & eidDetail & "," _
                    & esectionName & "," & eseq & "," & esubsectionname & "," & ecursubsectionname & "," _
                    & "1,'...',1,1,null," & eByName()
                    executeQuery(query)
                    showAlert("success", "Saved !")
                    DirectCast(Page, MeaTemplateSecDetails).BindingData()
                Catch ex As Exception
                    err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
                End Try
            Case "2"
                eidGroup = Request.QueryString("id")
                eaction = evar(Action.Value, 1)

                If tIDDetail.Text = String.Empty Then
                    eidDetail = "0"
                Else
                    eidDetail = evar(tIDDetail.Text, 0)
                End If

                If tSeq.Text = String.Empty Then
                    showAlert("warning", "Please Fill Sequence")
                    Exit Sub
                Else
                    eseq = evar(tSeq.Text, 1)
                End If

                If tSec.Text = String.Empty Then
                    showAlert("warning", "Please Fill Section Name")
                    Exit Sub
                Else
                    esectionName = evar(tSec.Text, 1)
                End If

                If tSubSec.Text = String.Empty Then
                    showAlert("warning", "Please fill Sub Section Name")
                    Exit Sub
                Else
                    ecursubsectionname = evar(tcurSubSec.Value, 1)
                    esubsectionname = evar(tSubSec.Text, 1)
                End If

                If tItem.Text = String.Empty Then
                    showAlert("warning", "Please fill Item Description")
                    Exit Sub
                Else
                    eitemdesc = evar(tItem.Text, 1)
                End If

                If tRowCount.Text = String.Empty Then
                    showAlert("warning", "Please fill Row Count")
                    Exit Sub
                Else
                    erowcount = evar(tRowCount.Text, 1)
                End If

                If ddValType.SelectedValue = String.Empty Then
                    showAlert("warning", "Please Choose Value Type")
                    Exit Sub
                Else
                    evaltype = evar(ddValType.SelectedValue, 1)
                End If

                ecostumecol = evar(tCostCol.Text, 1)

                Try
                    query = "exec dbo.[TCRCMeaInspItemSubmit] " & eaction & "," & TypeID.Value & "," & eidGroup & "," & eidDetail & "," _
                    & esectionName & "," & eseq & "," & esubsectionname & "," & ecursubsectionname & "," _
                    & eseq & "," & eitemdesc & "," & erowcount & "," & evaltype & "," & ecostumecol & "," & eByName()
                    executeQuery(query)
                    showAlert("success", "Saved !")
                    DirectCast(Page, MeaTemplateSecDetails).BindingData()
                Catch ex As Exception
                    err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
                End Try
            Case Else
                Exit Sub
        End Select
    End Sub

    Sub showAlert(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toastrMessage", script, True)
    End Sub
End Class