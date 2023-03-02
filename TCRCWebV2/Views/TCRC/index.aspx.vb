Imports System.ComponentModel
Imports System.IO
Imports DocumentFormat.OpenXml.Math
Imports Microsoft.SqlServer.Server
Imports SQLFunction

Public Class index
    Inherits System.Web.UI.Page
    Dim bgWorker As New BackgroundWorker()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        load_TD()
    End Sub

    Private Sub loadToCSV()
        Dim dt As New DataTable
        dt = SQLFunction.GetDataTable("select wono,dbo.GetComponentName(left(MaintType,5)) as 
                        ComponentName,UnitDescription,dbo.RunningDays(ComponentReceiveDate,DateSendAN) as Age, 
                        dbo.LastActivity(WONo) as LastActivity from v_IntJobDetailRev3 where JobStatusID not in('C','X','O')")
        Dim folderPath As String = "~/data/"
        Dim filename As String = folderPath & "WOActivity.csv"
        Dim builder As New StringBuilder()
        Dim delimiter As String = ","
        For i As Integer = 0 To dt.Columns.Count - 1
            builder.Append(dt.Columns(i).ColumnName + delimiter)
        Next
        builder.Append(Environment.NewLine)
        For Each dr As DataRow In dt.Rows
            For i As Integer = 0 To dt.Columns.Count - 1
                builder.Append(dr(i).ToString() + delimiter)
            Next
            builder.Append(Environment.NewLine)
        Next
        File.WriteAllText(Server.MapPath(filename), builder.ToString())
    End Sub

    Private Sub loadToTXT()
        Dim dt As New DataTable
        dt = SQLFunction.GetDataTable("select wono,dbo.GetComponentName(left(MaintType,5)) as 
                            ComponentName,UnitDescription,dbo.RunningDays(ComponentReceiveDate,DateSendAN) as Age, 
                            dbo.LastActivity(WONo) as LastActivity,dbo.[LabourHourofWO](WONo,'M') As ActualLabHour,
                            dbo.[LabourHourTargetofWO](WONo) as TargetLabour
                            from v_IntJobDetailRev3 where JobStatusID not in('C','X','O')")
        Dim filename As String = "WOActivity.txt"
        Dim builder As New StringBuilder()
        For i As Integer = 0 To dt.Columns.Count - 1
            builder.Append(dt.Columns(i).ColumnName & ControlChars.Tab)
        Next
        builder.Append(Environment.NewLine)
        For Each dr As DataRow In dt.Rows
            For i As Integer = 0 To dt.Columns.Count - 1
                builder.Append(dr(i).ToString() & ControlChars.Tab)
            Next
            builder.Append(Environment.NewLine)
        Next

        File.WriteAllText(Server.MapPath("~/data/" & filename), builder.ToString())
    End Sub

    Protected Sub bRefresh_Click(sender As Object, e As EventArgs)
        loadToTXT()
    End Sub

    Sub LoadDataToRepeater(ByVal Repeater As Repeater, ByVal activity As String)
        Try
            Dim filePath As String = Server.MapPath("~/data/WOActivity.txt")
            Dim tabDelimitedData As String = File.ReadAllText(filePath)

            ' Split data into rows
            Dim rows As String() = tabDelimitedData.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

            ' Create new DataTable
            Dim data As New DataTable()

            ' Adding columns to DataTable
            For Each col As String In rows(0).Split(ControlChars.Tab)
                data.Columns.Add(col)
            Next

            ' Adding all rows to DataTable
            For Each row As String In rows.Skip(1)
                data.Rows.Add(row.Split(ControlChars.Tab))
            Next

            data.Columns.Add("CombinedColumn", GetType(String), "UnitDescription")

            'filter data based on column 5 equals "teardown"
            Dim filteredData = data.AsEnumerable().Where(Function(x) x.Field(Of String)(4) = activity)
            data = filteredData.CopyToDataTable()

            'Sort data based on column 3
            data.DefaultView.Sort = "UnitDescription ASC"

            'get distinct data based on combined column
            data = data.DefaultView.ToTable(True, "CombinedColumn")

            Repeater.DataSource = data
            Repeater.DataBind()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Function bindingdata(ByVal activity As String) As DataTable
        Try
            Dim filePath As String = Server.MapPath("~/data/WOActivity.txt")
            Dim tabDelimitedData As String = File.ReadAllText(filePath)

            ' Split data into rows
            Dim rows As String() = tabDelimitedData.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

            ' Create new DataTable
            Dim data As New DataTable()

            ' Adding columns to DataTable
            For Each col As String In rows(0).Split(ControlChars.Tab)
                data.Columns.Add(col)
            Next

            ' Adding all rows to DataTable
            For Each row As String In rows.Skip(1)
                data.Rows.Add(row.Split(ControlChars.Tab))
            Next

            'Combine column 2 and column 3
            data.Columns.Add("CombinedColumn", GetType(String), "UnitDescription")

            'filter data based on column 5 equals "teardown"
            Dim filteredData = data.AsEnumerable().Where(Function(x) x.Field(Of String)(4) = activity)
            data = filteredData.CopyToDataTable()

            'Sort data based on column 3
            data.DefaultView.Sort = "UnitDescription ASC"
            Return data
        Catch ex As Exception
            Exit Function
        End Try

    End Function


#Region "Teardown"
    Sub load_TD()
        'LoadDataToRepeater(rpt_TD, "Assembly")
    End Sub

    Protected Sub rpt_TD_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Try
            Dim data As New DataTable()
            data = bindingdata("Assembly")

            'Dim filePath As String = Server.MapPath("~/data/WOActivity.txt")
            'Dim tabDelimitedData As String = File.ReadAllText(filePath)

            '' Split data into rows
            'Dim rows As String() = tabDelimitedData.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

            '' Create new DataTable
            'Dim data As New DataTable()

            '' Adding columns to DataTable
            'For Each col As String In rows(0).Split(ControlChars.Tab)
            '    data.Columns.Add(col)
            'Next

            '' Adding all rows to DataTable
            'For Each row As String In rows.Skip(1)
            '    data.Rows.Add(row.Split(ControlChars.Tab))
            'Next

            ''Combine column 2 and column 3
            'data.Columns.Add("CombinedColumn", GetType(String), "UnitDescription")

            ''filter data based on column 5 equals "teardown"
            'Dim filteredData = data.AsEnumerable().Where(Function(x) x.Field(Of String)(4) = "Assembly")
            'data = filteredData.CopyToDataTable()

            ''Sort data based on column 3
            'data.DefaultView.Sort = "UnitDescription ASC"

            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim combinedColumn As String = DirectCast(e.Item.DataItem, DataRowView)("CombinedColumn").ToString()
                Dim filteredData2 As DataTable = data.AsEnumerable().Where(Function(x) x.Field(Of String)("CombinedColumn") = combinedColumn).CopyToDataTable()

                Dim gv_TD As GridView = DirectCast(e.Item.FindControl("gv_TD"), GridView)
                gv_TD.DataSource = filteredData2
                gv_TD.DataBind()
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Protected Sub gv_TD_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim age As Integer = CInt(e.Row.Cells(2).Text)
        '    If age > 100 Then
        '        e.Row.Cells(2).ForeColor = System.Drawing.Color.Red
        '    End If
        'End If
    End Sub


#End Region

End Class