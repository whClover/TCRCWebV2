Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class AssemblyMea2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        load_data()
    End Sub

    Sub load_data()
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub

        Dim dt As New DataTable
        Dim query As String = "select distinct(AssemblySection) from v_AssemblySectionPicture where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            rpt_section.DataSource = dt
            rpt_section.DataBind()
        End If
    End Sub

    Protected Sub rpt_section_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ewo As String = Request.QueryString("wo")
            If ewo = String.Empty Then Exit Sub

            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)
            Dim esection As String = dataItem("AssemblySection").ToString()

            Dim gv_table As GridView = CType(e.Item.FindControl("gv_table"), GridView)

            Dim dt As New DataTable
            Dim ecol As String = "IDAssemblyInput,[Sequence],Replace(AssemblyDesc,CHAR(13)+CHAR(10),'<br />') as AssemblyDesc,case when UnitType=1 then 'Metric' else 'US' end as UnitTypeDesc,ValType,Unit,IDAssemblyInput,UnitType,
                            isnull((isnull(convert(varchar(10),Spec),'') + ' ± ' + isnull(convert(varchar(10),Tolerance),'') + ' ' + convert(varchar(10), Unit)),'-') as SpecFull,
                            case when AssemblyVal is null then '-' else isnull((AssemblyVal + ' ' + Unit),AssemblyVal) end as AssemblyVal,isnull(ModBy,'-') as ModBy,isnull(convert(varchar, ModDate,103),'-') as ModDate,isnull(ApprovedBy,'-') as ApprovedBy,InstructionType"
            Dim query As String = "select " & ecol & " from v_AssemblyDetailInputRev2 where wono=" & evar(ewo, 1) & " and AssemblySection=" & evar(esection, 1) & "
                                order by AssemblySection, dbo.SequenceNum(Sequence),dbo.SequenceAlpha(Sequence),dbo.getsortval(Sequence,30,10)"
            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                gv_table.DataSource = dt
                gv_table.DataBind()
            End If

        End If
    End Sub

    Protected Sub gv_table_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dataItem As DataRowView = CType(e.Row.DataItem, DataRowView)

            Dim evaltype As String = dataItem("ValType")
            Select Case evaltype
                Case "1"
                    e.Row.Cells(2).Visible = False
                    e.Row.Cells(3).Visible = False
                    e.Row.Cells(4).ColumnSpan = 3
                    e.Row.Cells(4).Style("text-align") = "center"
                    e.Row.Cells(4).Style("vertical-align") = "middle"
                Case "3"
                    e.Row.Cells(2).Visible = False
                    e.Row.Cells(3).Visible = False
                    e.Row.Cells(4).ColumnSpan = 3
                    e.Row.Cells(4).Style("text-align") = "center"
                    e.Row.Cells(4).Style("vertical-align") = "middle"
            End Select
        End If
    End Sub
End Class