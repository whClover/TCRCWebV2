Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports DocumentFormat.OpenXml.Office.Word
Imports DocumentFormat.OpenXml.Spreadsheet
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class SQLFunction
    Public Shared connString As String = ConfigurationManager.ConnectionStrings("ComponentString").ConnectionString


    Shared clsname As String = "SQLFunction"

    Public Shared Function GetDataTable(ByVal Query As String) As DataTable
        Dim dt As New DataTable
        Dim methodName As String = System.Reflection.MethodBase.GetCurrentMethod().Name

        Try
            Dim cn As New SqlConnection(connString)
            Dim cmd As New SqlCommand()
            Dim da As New SqlDataAdapter()
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = Query
            da.SelectCommand = cmd
            da.Fill(dt)
            cn.Close()
            cn.Dispose()
            cmd.Dispose()
            da.Dispose()
            Return dt
        Catch ex As Exception
            err_handler(clsname & "-" & GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try

        Return dt
    End Function

    Public Shared Function DataTableToTxt(ByVal query As String, ByVal fullpath As String) As Boolean
        Dim dt As New DataTable()
        Dim sb As New StringBuilder()

        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            For Each col As DataColumn In dt.Columns
                sb.Append(col.ColumnName)
                sb.Append(vbTab)
            Next
            sb.AppendLine()

            For Each row As DataRow In dt.Rows
                For Each col As DataColumn In dt.Columns
                    sb.Append(row(col))
                    sb.Append(vbTab)
                Next
                sb.AppendLine()
            Next
            File.WriteAllText(fullpath, sb.ToString())
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function GetDataTableV2(pageIndex As Integer, pageSize As Integer, ByVal Query As String, ByVal OrderBy As String) As DataTable
        Dim dt As New DataTable
        Dim cn As New SqlConnection(connString)
        Dim cmd As New SqlCommand()
        Dim da As New SqlDataAdapter()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = Query & " ORDER BY " & OrderBy & " OFFSET (@PageIndex * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY"
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex)
        cmd.Parameters.AddWithValue("@PageSize", pageSize)

        Using reader As SqlDataReader = cmd.ExecuteReader()
            dt.Load(reader)
        End Using

        Return dt
    End Function

    Public Shared Function executeQuery(ByVal Query As String) As String
        Try
            Dim cn As New SqlConnection(connString)
            cn.Open()
            Dim cm As New SqlCommand(Query, cn)
            Dim rd As SqlDataReader = cm.ExecuteReader
            rd.Read()

            cm.Connection.Close()
            cm.Connection.Dispose()
            rd.Close()
            cn.Close()


        Catch ex As Exception
            err_handler(clsname & "-" & GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try

        Return "0"
    End Function

    Public Shared Function dat_UpperLinerBore() As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow = dt.NewRow()
        dt.Columns.Add("Col1")

        dr = dt.NewRow()
        dr("Col1") = "Insert"
        dr("Col1") = "Original"

        Return dt
    End Function
End Class
