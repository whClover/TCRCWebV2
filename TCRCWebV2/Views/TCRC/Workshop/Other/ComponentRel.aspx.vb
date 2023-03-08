Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports System.IO
Imports DocumentFormat.OpenXml.Office2016.Excel
Imports Org.BouncyCastle.Asn1.Ocsp
Imports System.Drawing
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports iTextSharp.text

Public Class ComponentRel
    Inherits System.Web.UI.Page

    Dim utility As New Utility(Me)
    Dim tempfilter As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Render halaman ascx ke HtmlTextWriter
            Dim ascxPage As Control = Page.LoadControl("~/Views/TCRC/Reports/CompRelForm.ascx")
            Dim stringWriter As New StringWriter()
            Dim htmlTextWriter As New HtmlTextWriter(stringWriter)
            ascxPage.RenderControl(htmlTextWriter)
            ViewState("HtmlContent") = stringWriter.ToString()
        End If
    End Sub

    Sub generatedata()
        filtering()
        Dim dt As New DataTable
        Dim query As String = "select * from v_TCRCReleaseForm" & tempfilter
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            lcount.Text = "Total Rows: " & dt.Rows.Count
            gv_comprel.DataSource = dt
            gv_comprel.DataBind()
        End If
    End Sub

    Sub filtering()
        Try
            If tWONo.Text <> String.Empty Then tempfilter = " and WONo like " & evar(tWONo.Text, 11) & tempfilter

            If Len(tempfilter) <= 0 Then
                tempfilter = ""
            Else
                tempfilter = " where  " & Right(tempfilter, Len(tempfilter) - 4)
            End If
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try
    End Sub

    Protected Sub bSearch_Click(sender As Object, e As EventArgs)
        generatedata()
    End Sub

    Protected Sub bEdit_Click(sender As Object, e As EventArgs)
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        'check already add or not ?
        Dim query As String = "exec dbo.TCRCSubmitCompRelease " & evar(ewo, 1) & ",'check',null,null,null,
        null,null,null,null,null,null,null,null,null,null,null,null,null,null," & eByName()
        executeQuery(query)

        'parsing into modal
        Dim dt As New DataTable
        Dim qry As String = "select * from v_TCRCReleaseForm where wono=" & evar(ewo, 1)
        dt = GetDataTable(qry)
        If dt.Rows.Count > 0 Then
            'form header
            Dim tWO As TextBox = DirectCast(ComponentRelEdit.FindControl("tWONo"), TextBox)
            Dim tCompPN As TextBox = DirectCast(ComponentRelEdit.FindControl("tCompPN"), TextBox)
            Dim tUnitNo As TextBox = DirectCast(ComponentRelEdit.FindControl("tUnitNo"), TextBox)
            Dim tCompReg As TextBox = DirectCast(ComponentRelEdit.FindControl("tCompReg"), TextBox)
            Dim tUnitModel As TextBox = DirectCast(ComponentRelEdit.FindControl("tUnitModel"), TextBox)
            Dim tDate As TextBox = DirectCast(ComponentRelEdit.FindControl("tDate"), TextBox)
            Dim tCompDesc As TextBox = DirectCast(ComponentRelEdit.FindControl("tCompDesc"), TextBox)

            'form input
            Dim chkVisInsp1 As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkVisInsp1"), CheckBox)
            Dim chkVisInsp2 As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkVisInsp2"), CheckBox)
            Dim chkVisInsp3 As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkVisInsp3"), CheckBox)
            Dim chkVisInsp4 As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkVisInsp4"), CheckBox)
            Dim chkVisInsp5 As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkVisInsp5"), CheckBox)
            Dim chkVisInsp6 As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkVisInsp6"), CheckBox)
            Dim chkAsmChk As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkAsmChk"), CheckBox)
            Dim chkTstPerform As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkTstPerform"), CheckBox)
            Dim chkPhotoComp As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkPhotoComp"), CheckBox)
            Dim chkAntiRust As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkAntiRust"), CheckBox)
            Dim chkPaintQuality As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkPaintQuality"), CheckBox)
            Dim chkWrapping As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkWrapping"), CheckBox)
            Dim chkEnSealIns As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkEnSealIns"), CheckBox)
            Dim chkInstChk As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkInstChk"), CheckBox)

            'form footer
            Dim tRemarks As TextBox = DirectCast(ComponentRelEdit.FindControl("tRemarks"), TextBox)
            Dim chkStatAcc As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkStatAcc"), CheckBox)
            Dim chkStatRjt As CheckBox = DirectCast(ComponentRelEdit.FindControl("chkStatRjt"), CheckBox)
            Dim InspBy As Label = DirectCast(ComponentRelEdit.FindControl("InspBy"), Label)
            Dim InspDate As Label = DirectCast(ComponentRelEdit.FindControl("InspDate"), Label)

            'parsing value
            tWO.Text = CheckDBNull(dt.Rows(0)("WONo"))
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

            utility.ModalV2("Panel1")
        End If
    End Sub

    Protected Sub bSendJP_Click(sender As Object, e As EventArgs)
        PrintPage()
    End Sub

    Private Sub PrintPage()
        ' Buat instance Document dan PdfWriter
        Dim document As New Document()
        Dim output As New MemoryStream()
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, output)

        ' Buka dokumen
        document.Open()

        ' Ambil html dari ViewState
        Dim htmlContent As String = ViewState("HtmlContent").ToString()

        ' Konversi html ke pdf
        Dim htmlParser As New HTMLWorker(document)
        htmlParser.Parse(New StringReader(htmlContent))

        ' Tutup dokumen dan output stream
        document.Close()
        output.Close()

        ' Set response header untuk download file pdf
        Response.ContentType = "application/pdf"
        Response.AddHeader("Content-Disposition", "attachment;filename=YourFileName.pdf")
        Response.BinaryWrite(output.ToArray())
        Response.Flush()
        Response.End()
    End Sub
End Class