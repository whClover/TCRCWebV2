Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports DocumentFormat.OpenXml.Drawing
Imports Org.BouncyCastle.Math.EC
Imports System.Security.Cryptography
Imports System.Windows
Imports DocumentFormat.OpenXml.Vml.Spreadsheet

Public Class PrelimTemplateDetailsEdit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingdata()
            BindDataDropDown(ddsection, "SELECT PictureSection FROM tbl_InsPartListSection", "PictureSection", "PictureSection")
        End If
    End Sub

    Sub bindingdata()
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub

        Dim dt As New DataTable
        Dim ecolumn As String = "IDTemplateDetail,IDTemplateGroup,IDPartList,PartNumber,PartDesc,PartRemark,Specification,Sequence,Qty,Deactive,
                                convert(varchar,createdate,103) as createdate,createby,convert(varchar,moddate,103) as moddate,modby,
                                unitdesc,sheetname,serialglobalpn,NewPicturePath,SectionPart,NormalCondition,NoPict,NDT"
        Dim query As String = "select " & ecolumn & " from v_InsPartListTemplateDetail where IDTemplateDetail=" & eid
        dt = GetDataTable(query)

        sid.InnerText = GetDataFromColumn(dt, "IDTemplateDetail")
        spn.InnerText = GetDataFromColumn(dt, "PartNumber")
        spndesc.InnerText = GetDataFromColumn(dt, "PartDesc")
        tpartremark.Text = GetDataFromColumn(dt, "PartRemark")
        tspec.Text = GetDataFromColumn(dt, "Specification")

        'Try
        '    ddsection.Text = GetDataFromColumn(dt, "SectionPart")
        'Catch ex As Exception
        '    ddsection.Items.Insert(0, New ListItem(GetDataFromColumn(dt, "SectionPart")))
        'End Try
        ddsection.Text = GetDataFromColumn(dt, "SectionPart")

        tseq.Text = GetDataFromColumn(dt, "Sequence")
        tnopict.Text = GetDataFromColumn(dt, "NoPict")
        tqty.Text = GetDataFromColumn(dt, "Qty")
        ddndt.Text = GetDataFromColumn(dt, "NDT")
        ddnormalcondition.Text = GetDataFromColumn(dt, "NormalCondition")
        dddeactive.Text = GetDataFromColumn(dt, "Deactive")
        sidgp.InnerText = GetDataFromColumn(dt, "IDTemplateGroup")
        sunitdesc.InnerText = GetDataFromColumn(dt, "unitdesc")
        ssheetname.InnerText = GetDataFromColumn(dt, "sheetname")
        sglobalpn.InnerText = GetDataFromColumn(dt, "serialglobalpn")
        sregdate.InnerText = GetDataFromColumn(dt, "createdate")
        sregby.InnerText = GetDataFromColumn(dt, "createby")
        smoddate.InnerText = GetDataFromColumn(dt, "moddate")
        smodby.InnerText = GetDataFromColumn(dt, "modby")
        hidpartlist.Value = GetDataFromColumn(dt, "IDPartList")
    End Sub

    Protected Sub bback_Click(sender As Object, e As EventArgs)
        Dim eidgp As String
        Select Case sidgp.InnerText
            Case "#"
                eidgp = Request.QueryString("idgp")
            Case Else
                eidgp = sidgp.InnerText
        End Select
        Response.Redirect(urlPreliminaryTemplateDetail & "?idgp=" & eidgp)
    End Sub
    Protected Sub bsave_Click(sender As Object, e As EventArgs)
        Dim eidgp, eidpartlist, epartremark, esection, espec, eseq, endt, enopict, enormal, eqty, edelet, edata As String

        If hidpartlist.Value = String.Empty Then
            genSwalAlert("warning", "Please Fill Part Description", Me)
            Exit Sub
        End If

        If tqty.Text = String.Empty Then
            genSwalAlert("warning", "Please Fill Part Qty", Me)
            Exit Sub
        End If

        eidgp = evar(sidgp.InnerText, 0)
        eidpartlist = evar(hidpartlist.Value, 0)
        epartremark = evar(tpartremark.Text, 1)
        esection = evar(ddsection.Text, 1)
        espec = evar(tspec.Text, 1)
        eseq = evar(tseq.Text, 1)
        endt = evar(ddndt.SelectedValue, 0)
        enopict = evar(tnopict.Text, 1)
        enormal = evar(ddnormalcondition.Text, 1)
        eqty = evar(tqty.Text, 0)
        edelet = evar(dddeactive.SelectedValue, 0)
        edata = "NULL"

        Dim query As String = "exec SaveInsPartListTemplateDetail " & eidgp & "," & eidpartlist & "," & epartremark & "," & esection & "," & espec & "," & eseq & "," &
            endt & "," & enopict & "," & enormal & "," & eqty & ",'" & edelet & "'," & edata & "," & edata & "," & eByName()
        executeQuery(query)
        genSwalAlert("success", "Data has been save", Me)
    End Sub
End Class