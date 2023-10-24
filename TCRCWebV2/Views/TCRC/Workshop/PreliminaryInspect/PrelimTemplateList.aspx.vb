Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports ClosedXML.Excel

Public Class PrelimTemplateList
    Inherits System.Web.UI.Page

    Dim tempfilter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            loaddata()
            bindingdata()
        End If
    End Sub

    Sub loaddata()
        BindDataDropDown(ddunitdesc, "Select Distinct [UnitDesc] from vw_InsPartListTemplateGroupEdit order by [UnitDesc] asc", "UnitDesc", "UnitDesc")
    End Sub

    Sub filtering()
        If ddunitdesc.Text <> String.Empty Then tempfilter = " and UnitDesc=" & evar(ddunitdesc.Text, 1) & tempfilter
        If tsheetname.Text <> String.Empty Then tempfilter = " and SheetName like " & evar(tsheetname.Text, 11) & tempfilter
        If tGlobalSN.Text <> String.Empty Then tempfilter = " and SerialGlobalPN like " & evar(tGlobalSN.Text, 11) & tempfilter
        If dddeactive.SelectedValue <> String.Empty Then tempfilter = " and Deactive=" & evar(dddeactive.SelectedValue, 0) & tempfilter

        If Len(tempfilter) <= 0 Then
            tempfilter = ""
        Else
            tempfilter = " where " & Right(tempfilter, Len(tempfilter) - 4)
        End If
    End Sub

    Sub bindingdata()
        filtering()
        Dim dt As New DataTable
        Dim query As String = "select UnitDesc,SheetName,MaintID,SerialGlobalPN,CreateBy,convert(varchar,createdate,103) as createdate, 
                               ModBy,convert(varchar,moddate,103) as moddate,IDTemplateGroup from vw_InsPartListTemplateGroupEdit" & tempfilter & " Order By UnitDesc"
        dt = GetDataTable(query)
        cdata.InnerHtml = "<i class=""fa fa-info-circle me-2""></i>" & dt.Rows.Count & " Records Found"
        gvPrelim.DataSource = dt
        gvPrelim.DataBind()
    End Sub

    Protected Sub bexport_Click(sender As Object, e As EventArgs)
        filtering()
        Dim dt As New DataTable
        Dim query As String = "select UnitDesc,SheetName,MaintID,SerialGlobalPN,CreateBy,convert(varchar,createdate,103) as createdate, 
                               ModBy,convert(varchar,moddate,103) as moddate,IDTemplateGroup from vw_InsPartListTemplateGroupEdit" & tempfilter
        dt = GetDataTable(query)
        ExportData(dt, "Preliminary Inspection Template List")
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

    Protected Sub bsearch_Click(sender As Object, e As EventArgs)
        bindingdata()
    End Sub

    Protected Sub bdetails_Click(sender As Object, e As EventArgs)
        Dim eid As String = CType(sender, LinkButton).CommandArgument
        Response.Redirect(urlPreliminaryTemplateDetail & "?idgp=" & eid)
    End Sub
End Class