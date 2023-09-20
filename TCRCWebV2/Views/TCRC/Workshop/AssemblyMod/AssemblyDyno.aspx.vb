Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class AssemblyDyno
    Inherits System.Web.UI.Page

    Dim ewo As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ewo = Request.QueryString("wo")

        If IsPostBack = False Then
            GetSection()
            load_head()
        End If
    End Sub

    Sub load_head()
        lwono.InnerText = "WO." & ewo

        Dim query As String = "select WODesc from v_IntJobDetailRev3 where wono=" & evar(ewo, 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            lwodesc.InnerText = dt.Rows(0)("WODesc")
        End If

        Dim queryrem As String = "select * from tbl_AssemblyEngineInputGP where wono=" & evar(ewo, 1)
        Dim dtrem As New DataTable
        dtrem = GetDataTable(queryrem)
        tRemark.InnerText = dtrem.Rows(0)("DynoRemark").ToString()
    End Sub

    Sub getProgress()
        Dim query As String = "select " _
            + "dbo.PercentCalc(SUM(CASE WHEN DynoValue IS NOT NULL THEN 1 ELSE 0 END), COUNT(IDDynoInput)) as Perc " _
            + "from v_AssemblyDynoDetail where wono=" & evar(ewo, 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            pSectionProg.Style("width") = dt.Rows(0)("Perc") & "%"
            lSectionProg.InnerText = "Leading Hand Approval Progress (" & dt.Rows(0)("Perc") & "%)"
        End If
    End Sub

    Sub GetSection()
        Dim dt As New DataTable
        Dim query As String = "select distinct(DynoSection) from v_AssemblyDynoDetail where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        rpt_section.DataSource = dt
        rpt_section.DataBind()

        getProgress()
    End Sub

    Protected Sub rpt_section_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)
            Dim hSection As HtmlGenericControl = CType(e.Item.FindControl("hSection"), HtmlGenericControl)
            Dim rpt_dyno As Repeater = CType(e.Item.FindControl("rpt_dyno"), Repeater)

            hSection.InnerHtml = "<h5 class=""card-title"">" & dataItem("DynoSection") & "</h5>"

            Dim section As String = dataItem("DynoSection").ToString()
            Dim query As String = "select *,case when (isnull(convert(varchar(10),DynoSpec),'') + ' ± ' + isnull(convert(varchar(10),DynoTolerance),'') + ' ' + convert(varchar(10), DynoUnit)) is null then '' else (isnull(convert(varchar(10),DynoSpec),'') + ' ± ' + isnull(convert(varchar(10),DynoTolerance),'') + ' ' + convert(varchar(10), DynoUnit)) end as DynoFullSpec from v_AssemblyDynoDetail where wono=" & evar(ewo, 1) & " and DynoSection=" & evar(section, 1)
            Dim dt As New DataTable
            dt = GetDataTable(query)
            rpt_dyno.DataSource = dt
            rpt_dyno.DataBind()
        End If
    End Sub

    Protected Sub rpt_dyno_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            Dim pActivity As HtmlGenericControl = CType(e.Item.FindControl("pActivity"), HtmlGenericControl)
            Dim pSpec As HtmlGenericControl = CType(e.Item.FindControl("pSpec"), HtmlGenericControl)
            Dim pMeasurement As HtmlGenericControl = CType(e.Item.FindControl("pMeasurement"), HtmlGenericControl)
            Dim pMech As HtmlGenericControl = CType(e.Item.FindControl("pMech"), HtmlGenericControl)
            Dim bcheck As LinkButton = CType(e.Item.FindControl("bcheck"), LinkButton)
            Dim tVal As TextBox = CType(e.Item.FindControl("tVal"), TextBox)

            Dim eValType As String = dataItem("ValType").ToString()
            Dim eVal As String = dataItem("DynoValue").ToString()

            If eValType = 1 Then

                Select Case eVal
                    Case ""
                        pMeasurement.Visible = False
                        bcheck.Visible = True
                    Case Else
                        pMeasurement.Visible = True
                End Select

            ElseIf eValType = 2 Then

                Select Case eVal
                    Case ""
                        pMeasurement.Visible = False
                        tVal.Visible = True
                    Case Else
                        pMeasurement.Visible = True
                End Select

            End If

            pActivity.InnerHtml = dataItem("DynoDesc").ToString()
            pSpec.InnerText = dataItem("DynoFullSpec").ToString()
            pMeasurement.InnerText = dataItem("DynoValue").ToString()
            pMech.InnerText = dataItem("ModBy").ToString()
        End If
    End Sub

    Protected Sub bcheck_Click(sender As Object, e As EventArgs)
        Dim eid As String = String.Empty
        eid = CType(sender, LinkButton).CommandArgument
        Dim query As String = "update tbl_AssemblyDynoInput set DynoValue='OK',ModBy=" & eByName() & ",ModDate=GetDate() where IDDynoInput=" & eid
        executeQuery(query)
        Response.Redirect(urlAssemblyDyno & "?wo=" & Request.QueryString("WO"))
    End Sub

    Protected Sub tVal_TextChanged(sender As Object, e As EventArgs)
        Dim eid As String = String.Empty
        Dim txt_val As TextBox = CType(sender, TextBox)
        Dim rpt As RepeaterItem = CType(txt_val.NamingContainer, RepeaterItem)
        txt_val = CType(rpt.FindControl("tVal"), TextBox)
        eid = txt_val.Attributes("IDDyno").ToString()
        Dim query As String = "update tbl_AssemblyDynoInput set DynoValue=" & evar(txt_val.Text, 1) & ",ModBy=" & eByName() & ",ModDate=GetDate() where IDDynoInput=" & eid
        executeQuery(query)
        Response.Redirect(urlAssemblyDyno & "?wo=" & Request.QueryString("WO"))
    End Sub

    Protected Sub bsaverem_Click(sender As Object, e As EventArgs)
        If tRemark.InnerText = String.Empty Then
            showAlertV2("info", "Please fill Dyno Remark")
            Exit Sub
        End If

        Dim query As String = "update tbl_AssemblyEngineInputGP set DynoRemark=" & evar(tRemark.InnerText, 1) & " where wono=" & evar(Request.QueryString("wo"), 1)
        executeQuery(query)
        showAlertV2("success", "Dyno Remark has been Saved")
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub
End Class