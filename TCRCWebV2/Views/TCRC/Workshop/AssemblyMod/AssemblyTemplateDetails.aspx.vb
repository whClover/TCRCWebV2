Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class AssemblyTemplateDetails
    Inherits System.Web.UI.Page

    Dim tempfilter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            loaddropdown()
            bindingheader()
            bindingsection()
        End If
    End Sub

    Sub loaddropdown()
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        BindDataDropDown(ddsection, "select distinct(AssemblySection) from v_AssemblyTemplateDetailRev where IDTemplateAssemblyGroup=" & eid, "AssemblySection", "AssemblySection")
    End Sub

    Sub filtering()
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        If ddsection.Text <> String.Empty Then tempfilter = " and AssemblySection=" & evar(ddsection.Text, 1) & tempfilter
        If tDesc.Text <> String.Empty Then tempfilter = " and AssemblyDesc like " & evar(tDesc.Text, 11) & tempfilter
        If tseq.Text <> String.Empty Then tempfilter = " and Sequence like " & evar(tseq.Text, 11) & tempfilter
        If ddactive.Text <> String.Empty Then tempfilter = " and Active=" & evar(ddactive.SelectedValue, 0) & tempfilter
        tempfilter = " and IDTemplateAssemblyGroup=" & eid & tempfilter

        If Len(tempfilter) <= 0 Then
            tempfilter = ""
        Else
            tempfilter = " where " & Right(tempfilter, Len(tempfilter) - 4)
        End If
    End Sub

    Sub bindingheader()
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        Dim dt As New DataTable
        Dim query As String = "select * from v_AssemblyTemplateGroup where IDTemplateAssemblyGroup=" & eid
        dt = GetDataTable(query)
        tunitdesc.Text = dt.Rows(0)("UnitDesc")
        tTemplateName.Text = dt.Rows(0)("AssemblyGroupName")
    End Sub

    Sub bindingsection()
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        filtering()
        Dim dt As New DataTable
        Dim query As String = "select distinct(AssemblySection),
            case when('../../../../' + dbo.RemapPicW(PicturePath)) is null then '../../../../assets/images/NoPicture.png' 
            else ('../../../../' + dbo.RemapPicW(PicturePath)) end as PicturePathGroup from v_AssemblyTemplateDetailRev" & tempfilter
        dt = GetDataTable(query)
        rpt_section.DataSource = dt
        rpt_section.DataBind()
    End Sub

    Protected Sub rpt_section_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            Dim esection As String = dataItem("AssemblySection").ToString()
            Dim hsection As HtmlGenericControl = CType(e.Item.FindControl("hsection"), HtmlGenericControl)
            Dim rpt_details As Repeater = CType(e.Item.FindControl("rpt_details"), Repeater)

            hsection.InnerText = dataItem("AssemblySection").ToString()
            Dim dt As New DataTable

            Dim query As String
            If tempfilter <> String.Empty Then
                tempfilter = Replace(tempfilter, "where", " and ")
                query = "select *,convert(varchar,registerdate,103) as formregdate,convert(varchar,moddate,103) as formmoddate, 
                case when('../../../../' + dbo.RemapPicW(SubPicture)) is null then null else ('../../../../' + dbo.RemapPicW(SubPicture)) end as SubPictureForm
                from v_AssemblyTemplateDetailRev where IDTemplateAssemblyGroup=" & Request.QueryString("id") & " and AssemblySection=" & evar(esection, 1) & tempfilter &
                " order by AssemblySection, dbo.SequenceNum(Sequence),dbo.SequenceAlpha(Sequence),dbo.getsortval(Sequence,30,10)"
            Else
                query = "select *,convert(varchar,registerdate,103) as formregdate,convert(varchar,moddate,103) as formmoddate from v_AssemblyTemplateDetailRev where IDTemplateAssemblyGroup=" & Request.QueryString("id") & " and AssemblySection=" & evar(esection, 1) &
                " order by AssemblySection, dbo.SequenceNum(Sequence),dbo.SequenceAlpha(Sequence),dbo.getsortval(Sequence,30,10)"
            End If

            dt = GetDataTable(query)
            rpt_details.DataSource = dt
            rpt_details.DataBind()
        End If
    End Sub

    Protected Sub bsearch_Click(sender As Object, e As EventArgs)
        bindingsection()
    End Sub

    Protected Sub rpt_details_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            Dim sSeq As HtmlGenericControl = CType(e.Item.FindControl("sSeq"), HtmlGenericControl)
            Dim imgdet As Image = CType(e.Item.FindControl("imgdet"), Image)
            Dim sDesc As HtmlGenericControl = CType(e.Item.FindControl("sDesc"), HtmlGenericControl)
            Dim sRegBy As HtmlGenericControl = CType(e.Item.FindControl("sRegBy"), HtmlGenericControl)
            Dim sRegDate As HtmlGenericControl = CType(e.Item.FindControl("sRegDate"), HtmlGenericControl)
            Dim sModBy As HtmlGenericControl = CType(e.Item.FindControl("sModBy"), HtmlGenericControl)
            Dim sModDate As HtmlGenericControl = CType(e.Item.FindControl("sModDate"), HtmlGenericControl)

            sSeq.InnerText = dataItem("Sequence").ToString()
            If CheckDBNull(dataItem("SubPictureForm").ToString()) = "" Then
                imgdet.Visible = False
            Else
                imgdet.ImageUrl = CheckDBNull(dataItem("SubPictureForm").ToString())
            End If

            sDesc.InnerHtml = dataItem("AssemblyDesc").ToString()
            sRegBy.InnerText = dataItem("RegisterBy").ToString()
            sRegDate.InnerText = dataItem("formregdate").ToString()
            sModBy.InnerText = dataItem("ModBy").ToString()
            sModDate.InnerText = dataItem("formmoddate").ToString()
        End If
    End Sub

    Protected Sub bedit_Click(sender As Object, e As EventArgs)
        Dim eid As String = CType(sender, LinkButton).CommandArgument
        Response.Redirect(urlAssemblyTemplateEdit & "?id=" & eid)
    End Sub

    Protected Sub baddstep_Click(sender As Object, e As EventArgs)
        Dim eidgp As String = Request.QueryString("id")
        Dim esection As String = CType(sender, LinkButton).CommandArgument
        Response.Redirect(urlAssemblyTemplateEdit & "?idgp=" & eidgp & "&section=" & esection)
    End Sub
End Class