Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports DocumentFormat.OpenXml.Office.Word
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
End Class
