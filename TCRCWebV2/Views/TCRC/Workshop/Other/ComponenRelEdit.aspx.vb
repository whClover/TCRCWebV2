Imports TCRCWebV2.Utility
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString

Public Class ComponenRelEdit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingdata()

        End If
    End Sub

    Sub loadpicture()
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub
        Dim query As String = "select IDPict,'../../../../' + dbo.RemapPicW(PicturePath) as PicturePath from 
            tbl_GeneralPicture where JobID=(select ID from tbl_IntJobDetailx where wono=" & evar(ewo, 1) & ") and ModuleID=2 and PictureStatus=1"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        rpt_pict.DataSource = dt
        rpt_pict.DataBind()
    End Sub

    Sub bindingdata()
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub
        Dim query As String = "exec dbo.TCRCSubmitCompRelease " & evar(ewo, 1) & ",'check',null,null,null,
        null,null,null,null,null,null,null,null,null,null,null,null,null,null," & eByName()
        executeQuery(query)

        Dim dt As New DataTable
        Dim qry As String = "select * from v_TCRCReleaseForm where wono=" & evar(ewo, 1)
        dt = GetDataTable(qry)
        If dt.Rows.Count > 0 Then
            'parsing value
            tWONo.Text = CheckDBNull(dt.Rows(0)("WONo"))
            tCompPN.Text = CheckDBNull(dt.Rows(0)("TCIPartNo"))
            tUnitNo.Text = CheckDBNull(dt.Rows(0)("UnitNumber"))
            tCompReg.Text = CheckDBNull(dt.Rows(0)("CompID"))
            tUnitModel.Text = CheckDBNull(dt.Rows(0)("UnitDescription"))
            tDate.Text = CheckDBNull(dt.Rows(0)("RegisterDate"))
            tCompDesc.Text = CheckDBNull(dt.Rows(0)("CompName"))

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

        loadpicture()
    End Sub

    Protected Sub bsave_Click(sender As Object, e As EventArgs)
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
            showAlertV2("warning", "Please Input Component Register")
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
        showAlertV2("success", "Saved !")
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub

    Protected Sub bclose_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlComponentRelease)
    End Sub

    Protected Sub buploadpoct_Click(sender As Object, e As EventArgs)
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub

        Dim foldername As String = "PhotoCompletion"
        Dim dt As New DataTable
        Dim query As String = "select ID from tbL_IntJobDetailx where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        Dim eidjob As String = GetDataFromColumn(dt, "ID")
        Dim fs = CreateObject("Scripting.FileSystemObject")
        Dim epathattachment As String = JobIDAttachment & eidjob & "\" & foldername & "\"

        If FileUpload.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUpload.PostedFiles
                Dim fname As String = uploadedFile.FileName
                Dim fext As String = fs.GetExtensionName(fname)

                If fext = "JPG" Or fext = "jpg" Or fext = "png" Or fext = "JPEG" Then
                    'esection = ddsection.Text
                    If Not System.IO.Directory.Exists(epathattachment) Then
                        System.IO.Directory.CreateDirectory(epathattachment)
                    End If

                    Dim newfile As String = epathattachment + fname
                    uploadedFile.SaveAs(newfile)

                    Dim query_upload As String = "Insert into tbl_GeneralPicture(PictureSection,PicturePath,PictureStatus,ModuleID,JobID) values" _
                                        & "('" + foldername + "','" + newfile + "','1','2','" + eidjob + "')"
                    executeQuery(query_upload)
                End If
            Next
        End If

        'reload picture
        loadpicture()
    End Sub

    Protected Sub bdel_Click(sender As Object, e As EventArgs)
        Dim eidpict As String = CType(sender, LinkButton).CommandArgument
        Dim query As String = "update tbl_GeneralPicture set PictureStatus=0 where IDPict=" & eidpict
        executeQuery(query)
        loadpicture()
    End Sub

    Protected Sub bprint_Click(sender As Object, e As EventArgs)
        Dim ewo As String = Request.QueryString("wo")
        Dim namafile As String
        Dim namafile2 As String
        Dim fs = CreateObject("Scripting.FileSystemObject")
        Dim savePath As String = Server.MapPath("~/") & "temp/"
        If Not System.IO.Directory.Exists(savePath) Then
            System.IO.Directory.CreateDirectory(savePath)
        End If
        namafile = savePath & ewo & "_CompRelForm_17.pdf"
        Dim p As Process = New Process()
        p.StartInfo.FileName = "C:\webroot\TCRC Web\Rotativa\wkhtmltopdf.exe"
        'p.StartInfo.FileName = "C:\Rotativa\wkhtmltopdf.exe" 'local indra
        p.StartInfo.Arguments = "http://bpnaps07:88/Views/TCRC/Reports/CompRelForm.aspx?wo=" & ewo & " " & "--footer-html http://bpnaps07:88/Views/TCRC/Reports/CompRelFooter.aspx" & " " & namafile
        p.Start()
        p.WaitForExit()

        namafile2 = Server.MapPath("~/") & "temp/" & ewo & "_CompRelForm_17.pdf"
        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("Content-Disposition", "inline;filename=" & namafile2)
        Response.TransmitFile(namafile2)
        Response.Flush()
        Response.End()
    End Sub
End Class