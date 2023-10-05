Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports ClosedXML.Excel

Public Class AssemblyHistoryInput
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            gvhist.DataSource = New List(Of String)
            gvhist.DataBind()

            bindingdata()
        End If
    End Sub

    Sub bindingdata()
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        Dim dt As New DataTable
        Dim query As String = "select WONO,AssemblyVal,ModBy,Convert(varchar,ModDate,103) as ModDate,AssemblySection,AssemblyDesc from v_AssemblyDetailInputRev3 where IDTemplateAssembly=" & eid
        dt = GetDataTable(query)
        gvhist.DataSource = dt
        gvhist.DataBind()

        sSection.InnerText = GetDataFromColumn(dt, "AssemblySection")
        sDesc.InnerText = HttpUtility.HtmlDecode(GetDataFromColumn(dt, "AssemblyDesc"))
    End Sub

    Protected Sub bexport_Click(sender As Object, e As EventArgs)
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        Dim dt As New DataTable
        Dim query As String = "select AssemblySection,AssemblyDesc,WONO,AssemblyVal,ModBy,Convert(varchar,ModDate,103) as ModDate from v_AssemblyDetailInputRev3 where IDTemplateAssembly=" & eid
        dt = GetDataTable(query)
        ExportData(dt, "Assembly Input History")
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

    Protected Sub bback_Click(sender As Object, e As EventArgs)
        Dim eidgp As String = Request.QueryString("idgp")
        Response.Redirect(urlAssemblyTemplateDetails & "?id=" & eidgp)
    End Sub
End Class