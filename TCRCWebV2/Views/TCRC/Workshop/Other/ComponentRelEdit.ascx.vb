Imports TCRCWebV2.Utility
Imports TCRCWebV2.SQLFunction
Public Class ComponentRelEdit
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bSave_Click(sender As Object, e As EventArgs)
        Dim echkVisInsp1 As String
        Dim echkVisInsp2 As String
        Dim echkVisInsp3 As String
        Dim echkVisInsp4 As String
        Dim echkVisInsp5 As String
        Dim echkVisInsp6 As String
        Dim echkAsmChk As String
        Dim echkTstPerform As String
        Dim echkPhotoComp As String
        Dim echkAntiRust As String
        Dim echkPaintQuality As String
        Dim echkWrapping As String
        Dim echkEnSealIns As String
        Dim echkInstChk As String
        Dim eRelStat As String

        Dim ewo As String = tWONo.Text
        Dim compID As String = tCompReg.Text
        If compID = String.Empty Then
            showAlert("warning", "Please Input Component Register")
            Exit Sub
        End If

        Dim eRemarks As String = tRemarks.Text
        If chkVisInsp1.Checked Then echkVisInsp1 = "1"
        If chkVisInsp2.Checked Then echkVisInsp2 = "1"
        If chkVisInsp3.Checked Then echkVisInsp3 = "1"
        If chkVisInsp4.Checked Then echkVisInsp4 = "1"
        If chkVisInsp5.Checked Then echkVisInsp5 = "1"
        If chkVisInsp6.Checked Then echkVisInsp6 = "1"
        If chkAsmChk.Checked Then echkAsmChk = "1"
        If chkTstPerform.Checked Then echkTstPerform = "1"
        If chkPhotoComp.Checked Then echkPhotoComp = "1"
        If chkAntiRust.Checked Then echkAntiRust = "1"
        If chkPaintQuality.Checked Then echkPaintQuality = "1"
        If chkWrapping.Checked Then echkWrapping = "1"
        If chkEnSealIns.Checked Then echkEnSealIns = "1"
        If chkInstChk.Checked Then echkInstChk = "1"

        If chkStatAcc.Checked = True Then
            eRelStat = "2"
        Else
            eRelStat = "1"
        End If

        Dim query As String = "exec dbo.TCRCSubmitCompRelease " & evar(ewo, 1) & ",'edit'," & evar(echkVisInsp1, 1) _
            & "," & evar(echkVisInsp2, 1) & "," & evar(echkVisInsp3, 1) & "," & evar(echkVisInsp4, 1) & "," & evar(echkVisInsp5, 1) _
            & "," & evar(echkVisInsp6, 1) & "," & evar(echkAsmChk, 1) & "," & evar(echkTstPerform, 1) & "," & evar(echkPhotoComp, 1) _
            & "," & evar(echkAntiRust, 1) & "," & evar(echkPaintQuality, 1) & "," & evar(echkWrapping, 1) & "," & evar(echkEnSealIns, 1) _
            & "," & evar(echkInstChk, 1) & "," & evar(eRemarks, 1) & "," & evar(eRelStat, 1) & "," & evar(compID, 1) & "," & eByName()
        executeQuery(query)
        showAlert("success", "Saved !")
        DirectCast(Page, ComponentRel).generatedata()
    End Sub

    Sub showAlert(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toastrMessage", script, True)
    End Sub
End Class