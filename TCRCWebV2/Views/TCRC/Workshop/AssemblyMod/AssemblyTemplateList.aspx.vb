Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString
Imports Microsoft.SqlServer.Server

Public Class AssemblyTemplateList
    Inherits System.Web.UI.Page

    Dim utility As New Utility(Me)
    Dim tempfilter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            BindDataDropDown(ddunitdesc, "SELECT UnitDescID, UnitDesc FROM tbl_UnitDesc ORDER BY UnitDesc", "UnitDesc", "UnitDescID")
            bindingheader()
            bindingdata()
        End If
    End Sub

    Sub filtering()
        If ddunitdesc.Text <> String.Empty Then tempfilter = " and UnitDesc=" & evar(ddunitdesc.Text, 1) & tempfilter
        If tDesc.Text <> String.Empty Then tempfilter = " and AssemblyGroupName like " & evar(tDesc.Text, 11) & tempfilter
        If ddActive.Text <> String.Empty Then tempfilter = " and Active=" & evar(ddActive.SelectedValue, 1) & tempfilter

        If Len(tempfilter) <= 0 Then
            tempfilter = ""
        Else
            tempfilter = " where " & Right(tempfilter, Len(tempfilter) - 4)
        End If
    End Sub

    Sub bindingheader()
        Dim q_total, q_totala, qtotalin As String

        q_total = "select count(*) as c from v_AssemblyTemplateGroup"
        Dim dt_total As New DataTable
        dt_total = GetDataTable(q_total)
        htotalall.InnerText = dt_total.Rows(0)("c").ToString()

        q_totala = "select count(*) as c from v_AssemblyTemplateGroup where Active=1"
        Dim dt_totala As New DataTable
        dt_totala = GetDataTable(q_totala)
        htotalactive.InnerText = dt_totala.Rows(0)("c").ToString()

        qtotalin = "select count(*) as c from v_AssemblyTemplateGroup where Active=0"
        Dim dt_totalin As New DataTable
        dt_totalin = GetDataTable(qtotalin)
        htotalinactive.InnerText = dt_totalin.Rows(0)("c").ToString()
    End Sub

    Sub bindingdata()
        filtering()
        'bind-unitdesc
        Dim dt_unit As New DataTable
        Dim query_unit As String = "select distinct(UnitDesc) from v_AssemblyTemplateGroup" & tempfilter
        dt_unit = GetDataTable(query_unit)
        rpt_udesc.DataSource = dt_unit
        rpt_udesc.DataBind()
    End Sub

    Protected Sub rpt_udesc_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)
            Dim hunitdesc As HtmlGenericControl = CType(e.Item.FindControl("hunitdesc"), HtmlGenericControl)
            Dim eunitdesc As String = dataItem("UnitDesc").ToString()
            hunitdesc.InnerText = eunitdesc

            Dim gv_list As GridView = CType(e.Item.FindControl("gv_list"), GridView)
            Dim dt As New DataTable

            Dim query As String
            query = "select *,Convert(varchar,CreateDate,103) as formCreateDate from v_AssemblyTemplateGroup where UnitDesc=" & evar(eunitdesc, 1) & " Order By MaintIDDesc"

            dt = GetDataTable(query)
            gv_list.DataSource = dt
            gv_list.DataBind()
        End If
    End Sub

    Protected Sub bsearch_Click(sender As Object, e As EventArgs)
        bindingdata()
    End Sub

    Protected Sub bedit_Click(sender As Object, e As EventArgs)
        Dim eid As String = CType(sender, LinkButton).CommandArgument

        'load dropdown
        Dim hid As HiddenField = DirectCast(AssemblyTemplateForm.FindControl("hid"), HiddenField)
        Dim ddunitdesc As DropDownList = DirectCast(AssemblyTemplateForm.FindControl("ddunitdesc"), DropDownList)
        Dim tTemplateName As TextBox = DirectCast(AssemblyTemplateForm.FindControl("tTemplateName"), TextBox)
        Dim ddMaintID As DropDownList = DirectCast(AssemblyTemplateForm.FindControl("ddMaintID"), DropDownList)
        Dim ddActive As DropDownList = DirectCast(AssemblyTemplateForm.FindControl("ddActive"), DropDownList)

        BindDataDropDown(ddunitdesc, "SELECT UnitDescID, UnitDesc FROM tbl_UnitDesc ORDER BY UnitDesc", "UnitDesc", "UnitDescID")
        BindDataDropDown(ddMaintID, "SELECT MaintID, MaintIDDesc, TCRP FROM tbl_MaintBase WHERE TCRP=1 ORDER BY MaintIDDesc", "MaintIDDesc", "MaintID")

        Dim dt As New DataTable
        dt = GetDataTable("select * from tbl_AssemblyTemplateGroup where IDTemplateAssemblyGroup=" & eid)

        hid.Value = eid
        ddunitdesc.SelectedValue = dt.Rows(0)("UnitDescID").ToString()
        tTemplateName.Text = dt.Rows(0)("AssemblyGroupName").ToString()
        ddMaintID.SelectedValue = dt.Rows(0)("MaintID").ToString()
        ddActive.SelectedValue = dt.Rows(0)("Active").ToString()

        utility.ModalV2("MainContent_AssemblyTemplateForm_Panel1")
    End Sub

    Protected Sub badd_Click(sender As Object, e As EventArgs)
        Dim hid As HiddenField = DirectCast(AssemblyTemplateForm.FindControl("hid"), HiddenField)
        Dim ddunitdesc As DropDownList = DirectCast(AssemblyTemplateForm.FindControl("ddunitdesc"), DropDownList)
        Dim tTemplateName As TextBox = DirectCast(AssemblyTemplateForm.FindControl("tTemplateName"), TextBox)
        Dim ddMaintID As DropDownList = DirectCast(AssemblyTemplateForm.FindControl("ddMaintID"), DropDownList)
        Dim ddActive As DropDownList = DirectCast(AssemblyTemplateForm.FindControl("ddActive"), DropDownList)
        BindDataDropDown(ddunitdesc, "SELECT UnitDescID, UnitDesc FROM tbl_UnitDesc ORDER BY UnitDesc", "UnitDesc", "UnitDescID")
        BindDataDropDown(ddMaintID, "SELECT MaintID, MaintIDDesc, TCRP FROM tbl_MaintBase WHERE TCRP=1 ORDER BY MaintIDDesc", "MaintIDDesc", "MaintID")

        hid.Value = ""
        ddunitdesc.SelectedValue = ""
        tTemplateName.Text = ""
        ddMaintID.SelectedValue = ""
        ddActive.SelectedValue = "1"

        utility.ModalV2("MainContent_AssemblyTemplateForm_Panel1")
    End Sub

    Protected Sub bshow_Click(sender As Object, e As EventArgs)
        Dim eid As String = CType(sender, LinkButton).CommandArgument
        Response.Redirect(urlAssemblyTemplateDetails & "?id=" & eid)
    End Sub
End Class