Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class LabourHours
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        load_data()
        load_unitdesc()
    End Sub

    Sub load_unitdesc()
        BindDataDropDown(ddlItems, "select * from tbl_UnitDesc", "UnitDesc", "UnitDesc")
    End Sub

    Sub load_data()
        Dim dt As New DataTable
        Dim query As String = "select * from v_LabourHrsTarget"
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            gv_list.DataSource = dt
            gv_list.DataBind()
        End If
    End Sub

    Protected Sub bTest_Click(sender As Object, e As EventArgs)
        Dim filePath As String = Server.MapPath("~/data/DataLabourAvg.txt")

        Dim query As String = "select UnitDescription,left(MaintType,5) as MaintID,Avg(ActLabHour) as AvgHrs,RepairType from v_IntJobDetailRev3 as t2 inner join v_WOCostDetail as t3 on t2.wono=t3.wono 
                            where JobStatusID in ('C') and JDECompletedDate >= '2021-01-01' and len(MaintType) > 0 Group By UnitDescription,left(MaintType,5),RepairType"
        DataTableToTxt(query, filePath)
    End Sub
End Class