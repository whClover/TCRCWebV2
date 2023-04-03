Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports DocumentFormat.OpenXml.Office2013.Excel

Public Class MeaInspWorksheetRev
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack = True Then
            LoadSection()
            LoadUI()
        End If
    End Sub

    Sub LoadSection()
        Dim ewo As String = Request.QueryString("wo")
        Dim etype As String = Request.QueryString("type")
        If ewo = String.Empty Then Exit Sub

        Dim query As String = "select distinct(SectionName),SeqSection from v_InspDetail where wono=" & evar(ewo, 1) & " and AftInput=" & etype & " Order By SeqSection"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            rpt_section.DataSource = dt
            rpt_section.DataBind()
        End If
    End Sub

    Sub LoadUI()
        Dim ewo As String = Request.QueryString("wo")
        Dim etype As String = Request.QueryString("type")
        Dim esection As String = Request.QueryString("section")
        Dim esubsection As String = Request.QueryString("subsection")
        If ewo = String.Empty Then Exit Sub
        If esubsection = String.Empty Then Exit Sub

        'Load Dynamic Table Header !!!
        LoadItemHeader(esection, esubsection)
        LoadItemBody(esection, esubsection)

        'next-load
        MainDiv.Style("display") = "Block"
        lSectionName.InnerText = "Section: " & esection
        lSubSection.InnerText = "Sub-Section: " & esubsection

        lhWO.InnerText = "WO." & ewo
        Dim dt As New DataTable()
        dt = GetDataTable("select WODesc from v_IntJobDetailRev3 where wono=" & evar(ewo, 1))
        If dt.Rows.Count > 0 Then
            lWODesc.InnerText = dt.Rows(0)("WODesc")
        End If

        Dim dt_img As New DataTable()
        Dim query As String = "select PictureSection from v_InspDetail where wono=" & evar(ewo, 1) & " 
        and SectionName=" & evar(esection, 1) & " and SubSectionName=" & evar(esubsection, 1)
        dt_img = GetDataTable(query)
        If dt_img.Rows.Count > 0 Then
            imgSection.Src = dt_img.Rows(0)("PictureSection")
        End If
    End Sub

    Sub LoadItemHeader(ByVal sectionName As String, ByVal subsectionName As String)
        Dim ewo As String = Request.QueryString("wo")
        Dim etype As String = Request.QueryString("type")
        If ewo = String.Empty Then Exit Sub

        Dim query As String = "select distinct(ItemDesc),SeqItem,ValType from v_InspDetail 
					where wono=" & evar(ewo, 1) & " and SectionName=" & evar(sectionName, 1) & " and SubSectionName=" & evar(subsectionName, 1) & " and valType not in(0)
                    and AftInput=" & evar(etype, 0) & " Order By SeqItem"
        Dim dt As New DataTable
        dt = GetDataTable(query)

        'Add Null Value into Header
        Dim StepDesc As DataRow = dt.NewRow()
        StepDesc("ItemDesc") = ""
        StepDesc("SeqItem") = Integer.Parse("1")
        StepDesc("ValType") = Integer.Parse("1")
        dt.Rows.InsertAt(StepDesc, 0)
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        If dt.Rows.Count > 0 Then
            rptHeader.DataSource = dt
            rptHeader.DataBind()
        End If
    End Sub

    Sub LoadItemBody(ByVal sectionName As String, ByVal subsectionName As String)
        Dim ewo As String = Request.QueryString("wo")
        Dim etype As String = Request.QueryString("type")
        If ewo = String.Empty Then Exit Sub

        Dim query As String = "select distinct StepDesc,dbo.SequenceNum(StepDesc) from v_InspDetail 
                        where wono=" & evar(ewo, 1) & " and SectionName=" & evar(sectionName, 1) & " and SubSectionName=" & evar(subsectionName, 1) & " and valType not in(0)
                        and AftInput=" & evar(etype, 0) & "
                        group by StepDesc,ItemDesc,StepDesc,InspValue,IDInsp
                        order by dbo.SequenceNum(StepDesc)"
        Dim dt As New DataTable
        dt = GetDataTable(query)

        If dt.Rows.Count > 0 Then
            rptItem.DataSource = dt
            rptItem.DataBind()
        End If
    End Sub

    Protected Sub rpt_section_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SectionName As String = DirectCast(e.Item.DataItem, DataRowView)("SectionName").ToString()
            Dim innerRepeater As Repeater = DirectCast(e.Item.FindControl("rpt_subsection"), Repeater)
            Dim mySpan As HtmlGenericControl = DirectCast(e.Item.FindControl("SecName"), HtmlGenericControl)
            mySpan.InnerText = SectionName
            Session("ss_Section") = SectionName
            Session("ss_type") = Request.QueryString("type")

            Dim dt As New DataTable
            Dim ewo As String = Request.QueryString("wo")
            Dim etype As String = Request.QueryString("type")
            If ewo = String.Empty Then Exit Sub

            Dim query As String = "select distinct(SubSectionName),SeqSubSection from v_InspDetail where wono=" & evar(ewo, 1) & " 
                                and SectionName=" & evar(SectionName, 1) & " and AftInput=" & etype & " Order By SeqSubSection"
            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                innerRepeater.DataSource = dt
                innerRepeater.DataBind()
            End If
        End If
    End Sub

    Protected Sub rpt_subsection_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ewo As String = Request.QueryString("wo")
            Dim esection As String = Session("ss_Section")
            Dim etype As String = Session("ss_type")

            Dim SubSectionName As String = DirectCast(e.Item.DataItem, DataRowView)("SubSectionName").ToString()
            Session("ss_SubSection") = SubSectionName

            Dim MyAnchor As HtmlAnchor = DirectCast(e.Item.FindControl("subsecname"), HtmlAnchor)
            MyAnchor.InnerText = SubSectionName
            MyAnchor.HRef = urlMeasureWorksheetRev & "?wo=" & ewo & "&section=" & esection & "&subsection=" & SubSectionName & "&type=" & etype
        End If
    End Sub

    Protected Sub rptItem_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ewo As String = Request.QueryString("wo")
            Dim esection As String = Request.QueryString("section")
            Dim esubsection As String = Request.QueryString("subsection")
            Dim etype As String = Request.QueryString("type")
            Dim estepdesc As String = DirectCast(e.Item.DataItem, DataRowView)("StepDesc").ToString()
            'Dim rptStepValue As Repeater = DirectCast(e.Item.FindControl("rptStepValue"), Repeater)

            Dim query As String = "select IDInsp,StepDesc,ItemDesc,InspValue,ValType from v_InspDetail 
                where wono=" & evar(ewo, 1) & " and SectionName=" & evar(esection, 1) & " and SubSectionName=" & evar(esubsection, 1) & " and StepDesc=" & evar(estepdesc, 1) & " and valType not in(0)
                and AftInput=" & etype & "
                group by StepDesc,ItemDesc,StepDesc,InspValue,IDInsp,ValType"
            Dim dt As New DataTable
            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                Dim erow As New StringBuilder()
                For Each row As DataRow In dt.Rows
                    If row("ValType") = "1" Then
                        erow.Append("<td><button type=""button"" class=""btn btn-soft-primary"" value=""ok""/></td>")
                    ElseIf row("ValType") = "2" Then
                        erow.Append("<td><input id=""" & row("IDInsp") & """ runat=""server"" name=""txtValue"" type=""number"" Class=""form-control"" value=""" & row("InspValue") & """ /></td>")
                    ElseIf row("ValType") = "3" Then
                        erow.Append("<td><input id=""" & row("IDInsp") & """ runat=""server"" name=""txtValue"" class=""form-control"" value=""" & row("InspValue") & """ /></td>")
                    End If
                Next
                Dim placeholder As PlaceHolder = DirectCast(e.Item.FindControl("placeholder1"), PlaceHolder) ' Ganti placeholder1 dengan ID placeholder Anda
                placeholder.Controls.Add(New Literal() With {
                    .Text = erow.ToString()
                })
            End If
        End If
    End Sub

    <System.Web.Services.WebMethod()>
    Shared Function UpdateInput(ByVal IDInsp As String, ByVal value As String) As Integer
        If String.IsNullOrEmpty(eByName()) Then
            HttpContext.Current.Response.Redirect(urlTCRCLogin)
        End If

        Try
            Dim query As String = "update tbl_InspInput set InspValue='" & value & "',ModBy=" & eByName() & ",ModDate=GetDate() where IDInsp=" & IDInsp
            executeQuery(query)
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try

        Return 0
    End Function
End Class