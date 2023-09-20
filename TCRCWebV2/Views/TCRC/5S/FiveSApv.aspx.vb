Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class FiveSApv
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ss_userid") = "" Then
            Response.Redirect(urlTCRCLogin)
        End If

        If IsPostBack = False Then
            couts()
            bindingdata()
        End If
    End Sub

    Sub couts()
        Dim dt As New DataTable
        Dim ename As String = Session("ss_username")
        Dim query As String = "select * from v_5SRegister where AssignTo=" & evar(ename, 1) & " and SupvApprovedBy is null"
        dt = GetDataTable(query)
        If dt.Rows.Count = 0 Then
            Response.Redirect(urlTCRCWorkshopIx)
        End If
    End Sub

    Sub bindingdata()
        Dim dt As New DataTable
        Dim esupvname As String = Session("ss_username")
        Dim query As String = "select IDFindingGP,LocationDesc,convert(varchar,RegisterDate,103) as RegisterDate,RegisterBy from v_5SRegister where AssignTo=" & evar(esupvname, 1) & " and SupvApprovedBy is null"
        dt = GetDataTable(query)
        rpt_5s.DataSource = dt
        rpt_5s.DataBind()
    End Sub

    Protected Sub rpt_5s_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            Dim eidgp As String = dataItem("IDFindingGP").ToString()
            Dim linspection As HtmlGenericControl = CType(e.Item.FindControl("linspection"), HtmlGenericControl)
            Dim lsub As HtmlGenericControl = CType(e.Item.FindControl("lsub"), HtmlGenericControl)
            Dim lcount As HtmlGenericControl = CType(e.Item.FindControl("lcount"), HtmlGenericControl)
            Dim gv_apv As GridView = CType(e.Item.FindControl("gv_apv"), GridView)
            Dim dt As New DataTable
            Dim query As String = "select AreaDesc,FindingDesc,FindingAct,RegisterBy,convert(varchar,registerdate,103) as registerdate from v_5SSummary where IDFIndingGP=" & eidgp
            linspection.InnerText = "#" & dataItem("IDFindingGP") & " | " & dataItem("LocationDesc").ToString()
            lsub.InnerHtml = "<hr />Inspection Date: " & dataItem("RegisterDate").ToString() & "<br />" _
                            & "Inspection By:" & dataItem("RegisterBy").ToString()

            dt = GetDataTable(query)
            lcount.InnerText = "There are " & dt.Rows.Count & " Findings on this Inspection !"

            gv_apv.DataSource = dt
            gv_apv.DataBind()
        End If
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub

    Protected Sub bapprove_Click(sender As Object, e As EventArgs)
        If CheckGroup(43) = False Then
            showAlertV2("warning", "You dont have access supervisor approval")
            Exit Sub
        End If

        Dim eidgp As String = CType(sender, LinkButton).CommandArgument
        Dim query As String = "update tbl_5SFindingGP set SupvApprovedBy=" & eByName() & ",SupvApprovedDate=GetDate() where IDFindingGP=" & eidgp
        executeQuery(query)
        showAlertV2("success", "Approved")

        bindingdata()
    End Sub
End Class