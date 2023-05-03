Imports System.IO
Imports DocumentFormat.OpenXml.Office2019.Excel.RichData2
Imports Org.BouncyCastle.Crypto.Agreement
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaInspectionRev
    Inherits System.Web.UI.Page

    Dim ewo As String
    Dim aftinput As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ewo = Request.QueryString("wo")
        aftinput = Request.QueryString("aftinput")
        If ewo = String.Empty Then Exit Sub
        If aftinput = String.Empty Then Exit Sub

        loadSection()
        loadHeader()
    End Sub

    Sub loadHeader()
        Dim query As String = "select *,dbo.GetComponentName(Left(MaintType,5)) as CompName from v_IntJobDetailRev3 where wono=" & evar(ewo, 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            lwono.Text = dt.Rows(0)("WONo")
            lunitno.Text = dt.Rows(0)("UnitNumber")
            lwodesc.Text = dt.Rows(0)("WODesc")
            lunitdesc.Text = dt.Rows(0)("UnitDescription")
            lcomp.Text = dt.Rows(0)("CompName")
        End If
    End Sub

    Sub loadSection()
        Dim dt As New DataTable
        Dim query As String = "select distinct(SectionName),PictureSection,SeqSection 
        from v_InspDetail where wono=" & evar(ewo, 1) & " and AftInput=" & aftinput & " order by SeqSection"
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            rpt_section.DataSource = dt
            rpt_section.DataBind()
        End If
    End Sub

    Protected Sub rpt_section_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SectionName As String = DirectCast(e.Item.DataItem, DataRowView)("SectionName").ToString()
            Dim subsection As Repeater = DirectCast(e.Item.FindControl("rpt_subsection"), Repeater)
            Dim tremark As HtmlGenericControl = DirectCast(e.Item.FindControl("tSectionRmk"), HtmlGenericControl)
            Dim lLHApv As Label = DirectCast(e.Item.FindControl("lLHApv"), Label)
            Session("ss_Section") = SectionName

            Dim dt As New DataTable
            Dim query As String = "select distinct(SubSectionName),SeqSubSection from v_InspDetail where wono=" & evar(ewo, 1) & " 
                                and SectionName=" & evar(SectionName, 1) & " and AftInput=" & aftinput & " Order By SeqSubSection"
            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                subsection.DataSource = dt
                subsection.DataBind()
            End If

            'load section remark
            Dim dt2 As New DataTable
            Dim query2 As String = "Select * from v_InspRemark where wono=" & evar(ewo, 1) & " And InspSection=" & evar(SectionName, 1)
            dt2 = GetDataTable(query2)
            If dt2.Rows.Count > 0 Then
                tremark.InnerHtml = CheckDBNull(dt2.Rows(0)("Remark"))
            End If

            'load section approval
            Dim dt3 As New DataTable
            Dim query3 As String = "select *,convert(varchar, LHApprovedDate, 103) as LHApvDate from v_InspApproval where wono=" & evar(ewo, 1) & " and InspSection=" & evar(SectionName, 1)
            dt3 = GetDataTable(query3)
            If dt3.Rows.Count > 0 Then
                lLHApv.Text = "Leading Hand: " & CheckDBNull(dt3.Rows(0)("LHApprovedBy")) & ", On: " & CheckDBNull(dt3.Rows(0)("LHApvDate"))
            End If
        End If
    End Sub

    Protected Sub rpt_subsection_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim subsectionname As String = DirectCast(e.Item.DataItem, DataRowView)("SubSectionName").ToString()
            Dim itemhead As Repeater = DirectCast(e.Item.FindControl("rpt_ItemHead"), Repeater)
            Dim itembody As Repeater = DirectCast(e.Item.FindControl("rpt_ItemBody"), Repeater)
            Session("ss_SubSection") = subsectionname
            Dim sectionname As String = Session("ss_Section")

            Dim dt As New DataTable
            Dim query As String = "select distinct(ItemDesc),SeqItem,ValType from v_InspDetail 
					where wono=" & evar(ewo, 1) & " and SectionName=" & evar(sectionname, 1) & " and SubSectionName=" & evar(subsectionname, 1) & " and valType not in(0)
                    and AftInput=" & aftinput & " Order By SeqItem"
            dt = GetDataTable(query)

            'Add Null Value into Header
            Dim StepDesc As DataRow = dt.NewRow()
            StepDesc("ItemDesc") = ""
            StepDesc("SeqItem") = Integer.Parse("1")
            StepDesc("ValType") = Integer.Parse("1")
            dt.Rows.InsertAt(StepDesc, 0)
            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            If dt.Rows.Count > 0 Then
                itemhead.DataSource = dt
                itemhead.DataBind()
            End If

            Dim dt2 As New DataTable
            Dim query2 As String = "select distinct StepDesc,dbo.SequenceNum(StepDesc) from v_InspDetail 
                        where wono=" & evar(ewo, 1) & " and SectionName=" & evar(sectionname, 1) & " and SubSectionName=" & evar(subsectionname, 1) & " and valType not in(0)
                        and AftInput=" & aftinput & "
                        group by StepDesc,ItemDesc,StepDesc,InspValue,IDInsp
                        order by dbo.SequenceNum(StepDesc)"
            dt2 = GetDataTable(query2)
            If dt2.Rows.Count > 0 Then
                itembody.DataSource = dt2
                itembody.DataBind()
            End If
        End If
    End Sub

    Protected Sub rpt_ItemBody_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim placeholder As PlaceHolder = DirectCast(e.Item.FindControl("ph"), PlaceHolder)
            Dim stepdesc As String = DirectCast(e.Item.DataItem, DataRowView)("StepDesc").ToString()
            Dim sectionname As String = Session("ss_Section")
            Dim subsectionname As String = Session("ss_SubSection")

            Dim query As String = "select IDInsp,StepDesc,ItemDesc,InspValue,ValType,ModBy,convert(varchar,ModDate,103) as ModDate from v_InspDetail 
                where wono=" & evar(ewo, 1) & " and SectionName=" & evar(sectionname, 1) & " and SubSectionName=" & evar(subsectionname, 1) & " and StepDesc=" & evar(stepdesc, 1) & " and valType not in(0)
                and AftInput=" & aftinput & "
                group by StepDesc,ItemDesc,StepDesc,InspValue,IDInsp,ValType,ModBy,ModDate"
            Dim dt As New DataTable
            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                Dim erow As New StringBuilder()
                For Each row As DataRow In dt.Rows
                    If row("ValType") = "1" Then
                        erow.Append("<td><button type=""button"" class=""btn btn-soft-primary"" value=""ok""/></td>")
                    ElseIf row("ValType") = "2" Then
                        erow.Append("<td>
                                        <input id=""" & row("IDInsp") & """ runat=""server"" name=""txtValue"" type=""number"" Class=""form-control form-control-sm"" value=""" & row("InspValue") & """ />
                                        <small class=""form-label text-primary"" style=""text-align:left;font-style:italic"">Input By: " & CheckDBNull(dt.Rows(0)("ModBy")) & "<br /> On: " & CheckDBNull(dt.Rows(0)("ModDate")) & "</small>
                                    </td>")
                    ElseIf row("ValType") = "3" Then
                        erow.Append("<td>
                                        <input id=""" & row("IDInsp") & """ runat=""server"" name=""txtValue"" class=""form-control form-control-sm"" value=""" & row("InspValue") & """ />
                                        <small class=""form-label text-primary"" style=""text-align:left;font-style:italic"">Input By: " & CheckDBNull(dt.Rows(0)("ModBy")) & "<br /> On: " & CheckDBNull(dt.Rows(0)("ModDate")) & "</small>
                                    </td>")
                    End If
                Next
                placeholder.Controls.Add(New Literal() With {
                    .Text = erow.ToString()
                })
            End If
        End If
    End Sub

End Class