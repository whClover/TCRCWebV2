Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString
Public Class CompRelForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GenerateData()
    End Sub

    Private Sub GenerateData()
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub
        Dim dt As New DataTable
        Dim query As String = "select * from v_TCRCReleaseForm where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            lWO.Text = CheckDBNull(dt.Rows(0)("WONo"))
            lCompPn.Text = CheckDBNull(dt.Rows(0)("TCIPartNo"))
            lUnitNo.Text = CheckDBNull(dt.Rows(0)("UnitNumber"))
            lCompReg.Text = CheckDBNull(dt.Rows(0)("CompID"))
            lUnitModel.Text = CheckDBNull(dt.Rows(0)("UnitDescription"))
            lDateHead.Text = CheckDBNull(dt.Rows(0)("RegisterDate"))
            lCompDesc.Text = CheckDBNull(dt.Rows(0)("CompName"))

            If (CheckDBNull(dt.Rows(0)("VisInsp1")) = "1") Then chkVisInsp1.Checked = True Else chkVisInsp1.Checked = False
            If (CheckDBNull(dt.Rows(0)("VisInsp2")) = "1") Then chkVisInsp2.Checked = True Else chkVisInsp2.Checked = False
            If (CheckDBNull(dt.Rows(0)("VisInsp3")) = "1") Then chkVisInsp3.Checked = True Else chkVisInsp3.Checked = False
            If (CheckDBNull(dt.Rows(0)("VisInsp4")) = "1") Then chkVisInsp4.Checked = True Else chkVisInsp4.Checked = False
            If (CheckDBNull(dt.Rows(0)("VisInsp5")) = "1") Then chkVisInsp5.Checked = True Else chkVisInsp5.Checked = False
            If (CheckDBNull(dt.Rows(0)("VisInsp6")) = "1") Then chkVisInsp6.Checked = True Else chkVisInsp6.Checked = False
            If (CheckDBNull(dt.Rows(0)("AsmChk")) = "1") Then chkAsmChk.Checked = True Else chkAsmChk.Checked = False
            If (CheckDBNull(dt.Rows(0)("TstPerform")) = "1") Then chkTstPerform.Checked = True Else chkTstPerform.Checked = False
            If (CheckDBNull(dt.Rows(0)("PhotoComp")) = "1") Then chkPhotoComp.Checked = True Else chkPhotoComp.Checked = False
            If (CheckDBNull(dt.Rows(0)("AntiRust")) = "1") Then chkAntiRust.Checked = True Else chkAntiRust.Checked = False
            If (CheckDBNull(dt.Rows(0)("PaintQuality")) = "1") Then chkPaintQuality.Checked = True Else chkPaintQuality.Checked = False
            If (CheckDBNull(dt.Rows(0)("Wrapping")) = "1") Then chkWrapping.Checked = True Else chkWrapping.Checked = False
            If (CheckDBNull(dt.Rows(0)("EnSealIns")) = "1") Then chkEnSealIns.Checked = True Else chkEnSealIns.Checked = False
            If (CheckDBNull(dt.Rows(0)("EnInstChk")) = "1") Then chkInstChk.Checked = True Else chkInstChk.Checked = False

            tRemarks.Text = CheckDBNull(dt.Rows(0)("Remarks"))
            If CheckDBNull(dt.Rows(0)("ReleaseStatus")) = "1" Then
                chkStatRjt.Checked = True
                chkStatAcc.Checked = False
            ElseIf CheckDBNull(dt.Rows(0)("ReleaseStatus")) = "2" Then
                chkStatRjt.Checked = False
                chkStatAcc.Checked = True
            Else
                chkStatRjt.Checked = False
                chkStatAcc.Checked = False
            End If

            InspBy.Text = "Inspect By: " & CheckDBNull(dt.Rows(0)("RegisterBy"))
            InspDate.Text = "Date: " & CheckDBNull(dt.Rows(0)("RegisterDate"))

        End If
    End Sub
End Class