Imports System.IO
Imports Org.BouncyCastle.Crypto.Agreement
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaInspectionRev
    Inherits System.Web.UI.Page

    Dim ewo As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ewo = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub
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
        from v_InspDetail where wono=" & evar(ewo, 1) & " and AftInput=0 order by SeqSection"
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
            Session("ss_Section") = SectionName

            Dim dt As New DataTable
            Dim query As String = "select distinct(SubSectionName),SeqSubSection from v_InspDetail where wono=" & evar(ewo, 1) & " 
                                and SectionName=" & evar(SectionName, 1) & " and AftInput=0 Order By SeqSubSection"
            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                subsection.DataSource = dt
                subsection.DataBind()
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
					where wono=" & evar(ewo, 1) & " and SectionName=" & evar(sectionName, 1) & " and SubSectionName=" & evar(subsectionName, 1) & " and valType not in(0)
                    and AftInput=0 Order By SeqItem"
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
                        and AftInput=0
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

            Dim query As String = "select IDInsp,StepDesc,ItemDesc,InspValue,ValType from v_InspDetail 
                where wono=" & evar(ewo, 1) & " and SectionName=" & evar(sectionname, 1) & " and SubSectionName=" & evar(subsectionname, 1) & " and StepDesc=" & evar(stepdesc, 1) & " and valType not in(0)
                and AftInput=0
                group by StepDesc,ItemDesc,StepDesc,InspValue,IDInsp,ValType"
            Dim dt As New DataTable
            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                Dim erow As New StringBuilder()
                For Each row As DataRow In dt.Rows
                    If row("ValType") = "1" Then
                        erow.Append("<td><button type=""button"" class=""btn btn-soft-primary"" value=""ok""/></td>")
                    ElseIf row("ValType") = "2" Then
                        erow.Append("<td><input id=""" & row("IDInsp") & """ runat=""server"" name=""txtValue"" type=""number"" Class=""form-control form-control-sm"" value=""" & row("InspValue") & """ /></td>")
                    ElseIf row("ValType") = "3" Then
                        erow.Append("<td><input id=""" & row("IDInsp") & """ runat=""server"" name=""txtValue"" class=""form-control form-control-sm"" value=""" & row("InspValue") & """ /></td>")
                    End If
                Next
                placeholder.Controls.Add(New Literal() With {
                    .Text = erow.ToString()
                })
            End If
        End If
    End Sub
End Class