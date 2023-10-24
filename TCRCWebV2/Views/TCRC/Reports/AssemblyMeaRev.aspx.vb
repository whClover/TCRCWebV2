Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class AssemblyMeaRev
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            getHeader()
            bindingdata()
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

    Sub bindingdata()
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub

        Dim dt As New DataTable
        Dim query As String = "select distinct(AssemblySection),case when('../../../../' + dbo.RemapPicW(PicturePath)) is null then '~/images/NoPicture.png' else ('../../../../' + dbo.RemapPicW(PicturePath)) end as PicturePathGroup
                from v_AssemblySectionPicture where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        rpt_section.DataSource = dt
        rpt_section.DataBind()
    End Sub

    Protected Sub rpt_section_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)
            Dim esection As String = dataItem("AssemblySection").ToString()

            Dim rpt_details As Repeater = CType(e.Item.FindControl("rpt_details"), Repeater)
            Dim dt As New DataTable
            Dim ecol As String = "IDAssemblyInput,[Sequence],Replace(AssemblyDesc,CHAR(13)+CHAR(10),'<br />') as AssemblyDesc,case when UnitType=1 then 'Metric' else 'US' end as UnitTypeDesc,ValType,Unit,IDAssemblyInput,UnitType,
                            isnull((isnull(convert(varchar(10),Spec),'') + ' ± ' + isnull(convert(varchar(10),Tolerance),'') + ' ' + convert(varchar(10), Unit)),'-') as SpecFull,'../../../../' + dbo.RemapPicW(PicturePath) as PicturePath,
                            case when AssemblyVal is null then '-' else isnull((AssemblyVal + ' ' + Unit),AssemblyVal) end as AssemblyVal,isnull(ModBy,'-') as ModBy,isnull(convert(varchar, ModDate,103),'-') as ModDate,isnull(ApprovedBy,'-') as ApprovedBy,InstructionType"
            Dim query As String = "select " & ecol & " from v_AssemblyDetailInputRev2 where wono=" & evar(Request.QueryString("wo"), 1) & " and AssemblySection=" & evar(esection, 1) & "
                                order by AssemblySection, dbo.SequenceNum(Sequence),dbo.SequenceAlpha(Sequence),dbo.getsortval(Sequence,30,10)"
            dt = GetDataTable(query)
            rpt_details.DataSource = dt
            rpt_details.DataBind()
        End If
    End Sub

    Protected Sub rpt_details_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            Dim sseq As HtmlGenericControl = CType(e.Item.FindControl("sseq"), HtmlGenericControl)
            Dim sactivity As HtmlGenericControl = CType(e.Item.FindControl("sactivity"), HtmlGenericControl)
            Dim smeatype As HtmlGenericControl = CType(e.Item.FindControl("smeatype"), HtmlGenericControl)
            Dim sspec As HtmlGenericControl = CType(e.Item.FindControl("sspec"), HtmlGenericControl)
            Dim svalue As HtmlGenericControl = CType(e.Item.FindControl("svalue"), HtmlGenericControl)
            Dim smodby As HtmlGenericControl = CType(e.Item.FindControl("smodby"), HtmlGenericControl)
            Dim sapvby As HtmlGenericControl = CType(e.Item.FindControl("sapvby"), HtmlGenericControl)
            Dim imgdet As Image = CType(e.Item.FindControl("imgdet"), Image)

            If IsDBNull(dataItem("PicturePath")) = True Then
                imgdet.Visible = False
            End If

            sseq.InnerText = dataItem("Sequence").ToString()
            sactivity.InnerHtml = dataItem("AssemblyDesc").ToString()
            smeatype.InnerHtml = dataItem("UnitTypeDesc").ToString()
            sspec.InnerHtml = dataItem("SpecFull").ToString()
            svalue.InnerHtml = dataItem("AssemblyVal").ToString()
            smodby.InnerHtml = dataItem("ModBy").ToString()
            sapvby.InnerHtml = dataItem("ApprovedBy").ToString()
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