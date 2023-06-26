Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class AssemblyMea2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        load_data()
        getHeader()
    End Sub

    Sub load_data()
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub

        Dim dt As New DataTable
        Dim query As String = "select distinct(AssemblySection),case when('../../../../' + dbo.RemapPicW(PicturePath)) is null then '~/images/NoPicture.png' else ('../../../../' + dbo.RemapPicW(PicturePath)) end as PicturePathGroup
                from v_AssemblySectionPicture where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            rpt_section.DataSource = dt
            rpt_section.DataBind()
        End If
    End Sub

    Sub getHeader()
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub

        Dim dt As New DataTable
        Dim query As String = "select * from v_IntJobDetailRev3 where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            lwono.Text = CheckDBNull(dt.Rows(0)("WONo"))
            lunitno.Text = CheckDBNull(dt.Rows(0)("UnitNumber"))
            lwodesc.Text = CheckDBNull(dt.Rows(0)("WODesc"))
            lunitdesc.Text = CheckDBNull(dt.Rows(0)("UnitDescription"))
            lcomp.Text = CheckDBNull(dt.Rows(0)("ComponentGroup"))
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
                            isnull((isnull(convert(varchar(10),Spec),'') + ' ± ' + isnull(convert(varchar(10),Tolerance),'') + ' ' + convert(varchar(10), Unit)),'-') as SpecFull,'../../../../' + dbo.RemapPicW(PicturePath) as PicturePath,
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

    Protected Function GetSupvNameDate(ByVal SectionName As String, ByVal type As String)
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Function

        Dim res As String = ""
        Dim dt As New DataTable
        Dim query As String = "select SupvApprovedBy,convert(varchar,SupvApprovedDate,103) SupvApprovedDate from tbl_AssemblySectionApproval where wono=" & evar(ewo, 1) & " and AssemblySection=" & evar(SectionName, 1)
        dt = GetDataTable(query)

        If dt.Rows.Count > 0 Then
            Select Case type
                Case "1"
                    res = CheckDBNull(dt.Rows(0)("SupvApprovedBy"))
                Case "2"
                    res = CheckDBNull(dt.Rows(0)("SupvApprovedDate"))
            End Select
        Else
            res = "#"
        End If

        Return res
    End Function

    Protected Function GetMechNameDate(ByVal SectionName As String, ByVal type As String)
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Function

        Dim res As String = ""
        Dim dt As New DataTable
        Dim query As String = "select top 1 ModBy,convert(varchar,ModDate,103) ModDate from v_AssemblyDetailInputRev2 where wono=" & evar(ewo, 1) & " and AssemblySection=" & evar(SectionName, 1) & " Order By ModDate Desc"
        dt = GetDataTable(query)

        If dt.Rows.Count > 0 Then
            Select Case type
                Case "1"
                    res = CheckDBNull(dt.Rows(0)("ModBy"))
                Case "2"
                    res = CheckDBNull(dt.Rows(0)("ModDate"))
            End Select
        Else
            res = "#"
        End If

        Return res
    End Function
End Class