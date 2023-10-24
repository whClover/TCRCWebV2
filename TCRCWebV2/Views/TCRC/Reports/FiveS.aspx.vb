Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString
Imports DocumentFormat.OpenXml.Spreadsheet

Public Class FiveS
    Inherits System.Web.UI.Page

    Dim tempfilter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingdata()
        End If
    End Sub

    Sub bindingdata()
        Dim dt As New DataTable
        Dim elocation As String = Request.QueryString("idloc")
        Dim estart As String = Request.QueryString("start")
        Dim eend As String = Request.QueryString("end")
        Dim einspector As String = Request.QueryString("insp")

        If elocation <> String.Empty Then tempfilter = " and IDLocation=" & evar(elocation, 0) & tempfilter
        If estart <> String.Empty Then tempfilter = " and convert(date,RegisterDate,103) >=" & evar(estart, 2) & tempfilter
        If eend <> String.Empty Then tempfilter = " and convert(date,RegisterDate,103) <=" & evar(eend, 2) & tempfilter
        If einspector <> String.Empty Then tempfilter = " and RegisterBy=" & evar(einspector, 1) & tempfilter

        tempfilter = varfilter(tempfilter)

        Dim ecolumn As String = "RegisterBy,convert(varchar,RegisterDate,103) as RegisterDate,FindingDesc,FindingAct,AreaDesc,AssignTo,InspectStatus,dbo.RemapPict5S(PicturePath) as rmPict"
        Dim query As String = "select " & ecolumn & " from v_5SSummary" & tempfilter & " order by RegisterDate"
        dt = GetDataTable(query)

        rpt_5s.DataSource = dt
        rpt_5s.DataBind()

        If elocation = String.Empty Then Exit Sub
        Dim dt2 As New DataTable
        Dim query2 As String = "select * from tbl_5SLocation where IDLocation=" & elocation
        dt2 = GetDataTable(query2)
        htitle.InnerHtml = "5S Report | " & dt2.Rows(0)("LocationDesc").ToString()
    End Sub

    Protected Sub rpt_5s_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            Dim linsp As HtmlGenericControl = CType(e.Item.FindControl("linsp"), HtmlGenericControl)
            Dim linspdate As HtmlGenericControl = CType(e.Item.FindControl("linspdate"), HtmlGenericControl)
            Dim lfinding As HtmlGenericControl = CType(e.Item.FindControl("lfinding"), HtmlGenericControl)
            Dim lactionreq As HtmlGenericControl = CType(e.Item.FindControl("lactionreq"), HtmlGenericControl)
            Dim larea As HtmlGenericControl = CType(e.Item.FindControl("larea"), HtmlGenericControl)
            Dim lassignto As HtmlGenericControl = CType(e.Item.FindControl("lassignto"), HtmlGenericControl)
            Dim lstatus As HtmlGenericControl = CType(e.Item.FindControl("lstatus"), HtmlGenericControl)
            Dim linspimg As Image = CType(e.Item.FindControl("linspimg"), Image)
            Dim tmprow As HtmlTableRow = CType(e.Item.FindControl("tmprow"), HtmlTableRow)

            linsp.InnerText = dataItem("RegisterBy").ToString()
            linspdate.InnerText = dataItem("RegisterDate").ToString()
            lfinding.InnerText = dataItem("FindingDesc").ToString()
            lactionreq.InnerText = dataItem("FindingAct").ToString()
            larea.InnerText = dataItem("AreaDesc").ToString()
            lassignto.InnerText = dataItem("AssignTo").ToString()
            lstatus.InnerText = dataItem("InspectStatus").ToString()
            linspimg.ImageUrl = dataItem("rmPict").ToString()

            If dataItem("InspectStatus") <> "Complete" Then
                tmprow.Attributes.Add("class", "bg-warning")
            End If
        End If
    End Sub
End Class