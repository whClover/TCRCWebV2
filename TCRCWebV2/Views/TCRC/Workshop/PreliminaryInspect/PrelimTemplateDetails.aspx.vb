Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports ClosedXML.Excel

Public Class PrelimTemplateDetails
    Inherits System.Web.UI.Page

    Dim tempfilter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingheader()
            bindingdata()
            loaddata()
        End If
    End Sub

    Sub bindingheader()
        Dim dt As New DataTable
        Dim eidgp As String = Request.QueryString("idgp")
        If eidgp = String.Empty Then Exit Sub
        Dim query As String = "select UnitDesc,SheetName,MaintID,SerialGlobalPN,CreateBy,convert(varchar,createdate,103) as createdate, 
                               ModBy,convert(varchar,moddate,103) as moddate,IDTemplateGroup,Deactive from vw_InsPartListTemplateGroupEdit where IDTemplateGroup=" & eidgp
        dt = GetDataTable(query)
        sidgp.InnerText = GetDataFromColumn(dt, "IDTemplateGroup")
        sunitdesc.InnerText = GetDataFromColumn(dt, "UnitDesc")
        ssheetname.InnerText = GetDataFromColumn(dt, "SheetName")
        sglobalpn.InnerText = GetDataFromColumn(dt, "SerialGlobalPN")
        smainid.InnerText = GetDataFromColumn(dt, "MaintID")

        Select Case GetDataFromColumn(dt, "Deactive")
            Case 1 : sdeactive.InnerText = "In-Active"
            Case Else : sdeactive.InnerText = "Active"
        End Select

        screateby.InnerText = GetDataFromColumn(dt, "CreateBy")
        screatedate.InnerText = GetDataFromColumn(dt, "createdate")
        smodby.InnerText = GetDataFromColumn(dt, "ModBy")
        smoddate.InnerText = GetDataFromColumn(dt, "moddate")
    End Sub

    Sub bindingdata()
        filtering()
        Dim dt As New DataTable
        Dim eidgp As String = Request.QueryString("idgp")
        If eidgp = String.Empty Then Exit Sub
        Dim query As String = "select distinct(SectionPart),PicturePath from vw_InsPartListTemplateDetailAll" & tempfilter & " Order by SectionPart"
        dt = GetDataTable(query)
        rptPrelim.DataSource = dt
        rptPrelim.DataBind()

        Dim dt2 As New DataTable
        Dim query2 As String = "select Section,'../../../../' + dbo.RemapPicW(PicturePath) as PicturePath from 
            tbl_InsPartListTemplateGroupPic where IDTemplateGroup=" & eidgp & " Order by Section"
        dt2 = GetDataTable(query2)
        rpt_pict.DataSource = dt2
        rpt_pict.DataBind()
    End Sub

    Sub loaddata()
        Dim eidgp As String = Request.QueryString("idgp")
        If eidgp = String.Empty Then Exit Sub
        Dim query As String = "select distinct(SectionPart) from vw_InsPartListTemplateDetailAll where IDTemplateGroup=" & eidgp & " Order by SectionPart"
        BindDataDropDown(ddsection, query, "SectionPart", "SectionPart")
    End Sub

    Protected Sub rptPrelim_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)
            Dim gvPrelim As GridView = CType(e.Item.FindControl("gvPrelim"), GridView)

            Dim dt As New DataTable
            Dim ecolumn As String = "IDTemplateDetail,Sequence,NoPict,PartNumber,PartDesc,Qty,PartDesc,NDT,NormalCondition,Deactive,CreateBy,convert(varchar,CreateDate,103) CreateDate,
                                    ModBy,convert(varchar,ModDate,103) ModDate"
            Dim query As String = "select " & ecolumn & " from vw_InsPartListTemplateDetailAll" & tempfilter & " Order By SectionPart,Sequence asc"
            dt = GetDataTable(query)
            gvPrelim.DataSource = dt
            gvPrelim.DataBind()
        End If
    End Sub

    Protected Sub bexport_Click(sender As Object, e As EventArgs)
        Dim dt As New DataTable
        Dim eidgp As String = Request.QueryString("idgp")
        If eidgp = String.Empty Then Exit Sub
        Dim query As String = "select distinct(SectionPart),PicturePath from vw_InsPartListTemplateDetailAll where IDTemplateGroup=" & eidgp & " Order by SectionPart"
        dt = GetDataTable(query)
        ExportData(dt, "Preliminary Template Details")
    End Sub

    Private Function ExportData(ByVal dt As DataTable, ByVal filename As String)
        Dim workbook As New ClosedXML.Excel.XLWorkbook()
        Dim worksheet = workbook.Worksheets.Add("Data")
        Dim headerRow = worksheet.Row(1)
        headerRow.Style.Fill.BackgroundColor = XLColor.FromHtml("#2596be")
        headerRow.Style.Font.FontColor = XLColor.White
        headerRow.Style.Font.Bold = True
        Dim columnNumber As Integer = 1
        For Each column As DataColumn In dt.Columns
            worksheet.Cell(1, columnNumber).Value = column.ColumnName
            columnNumber += 1
        Next
        Dim rowNumber As Integer = 2
        For Each row As DataRow In dt.Rows
            columnNumber = 1
            For Each column As DataColumn In dt.Columns
                Dim value As Object = row(column.ColumnName)
                If column.DataType Is GetType(Integer) Then
                    If Not IsDBNull(value) Then
                        worksheet.Cell(rowNumber, columnNumber).Value = Convert.ToInt32(value)
                    End If
                Else
                    If Not IsDBNull(value) Then
                        worksheet.Cell(rowNumber, columnNumber).Value = value.ToString()
                    End If
                End If
                columnNumber += 1
            Next
            rowNumber += 1
        Next
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.AddHeader("content-disposition", "attachment;filename=" & filename & ".xlsx")
        Using memoryStream As New System.IO.MemoryStream()
            workbook.SaveAs(memoryStream)
            memoryStream.WriteTo(Response.OutputStream)
            memoryStream.Close()
        End Using
        Response.Flush()
        Response.End()
    End Function

    Protected Sub bclose_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlPreliminaryTemplateList)
    End Sub

    Protected Sub bsearch_Click(sender As Object, e As EventArgs)
        bindingdata()
    End Sub

    Sub filtering()
        Dim eidgp As String = Request.QueryString("idgp")
        If eidgp = String.Empty Then Exit Sub

        If ddsection.Text <> String.Empty Then tempfilter = " And SectionPart like " & evar(ddsection.Text, 11) & tempfilter
        If tPN.Text <> String.Empty Then tempfilter = " And PartNumber like " & evar(tPN.Text, 11) & tempfilter
        If tpartdesc.Text <> String.Empty Then tempfilter = " And PartDesc like " & evar(tpartdesc.Text, 11) & tempfilter
        If ddndt.Text <> String.Empty Then tempfilter = " And NDT=" & evar(ddndt.SelectedValue, 0) & tempfilter
        If ddcondition.Text <> String.Empty Then tempfilter = " And NormalCondition=" & evar(ddcondition.Text, 1) & tempfilter
        If dddeactive.Text <> String.Empty Then tempfilter = " And Deactive=" & evar(dddeactive.SelectedValue, 0) & tempfilter
        tempfilter = " And IDTemplateGroup=" & eidgp & tempfilter

        If Len(tempfilter) <= 0 Then
            tempfilter = ""
        Else
            tempfilter = " where " & Right(tempfilter, Len(tempfilter) - 4)
        End If
    End Sub

    Protected Sub bedit_Click(sender As Object, e As EventArgs)
        Dim eid As String = CType(sender, LinkButton).CommandArgument
        Response.Redirect(urlPreliminaryTemplateEdit & "?id=" & eid)
    End Sub

    Protected Sub badd_Click(sender As Object, e As EventArgs)
        Dim eidgp As String = Request.QueryString("idgp")
        Dim esection As String = CType(sender, LinkButton).CommandArgument
        Response.Redirect(urlPreliminaryTemplateEdit & "?idgp=" & eidgp & "&section=" & esection)
    End Sub
End Class