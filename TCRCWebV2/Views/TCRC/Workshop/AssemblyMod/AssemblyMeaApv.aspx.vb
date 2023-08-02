Imports System.Web.DynamicData
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class AssemblyMeaApv
    Inherits System.Web.UI.Page

    Dim ewo As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            ewo = Request.QueryString("wo")
            load_head()
            load_supvSection()
        End If
    End Sub

    Sub load_supvSection()
        Dim query As String = "select * from v_AssemblySectionApproval where wono=" & evar(ewo, 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            gv_supv.DataSource = dt
            gv_supv.DataBind()
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
    End Sub

    Protected Sub gv_supv_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dataItem As DataRowView = CType(e.Row.DataItem, DataRowView)
            Dim bapv As LinkButton = CType(e.Row.FindControl("bApv"), LinkButton)
            Dim lApv As Label = CType(e.Row.FindControl("lApv"), Label)
            Dim ddSupv As DropDownList = CType(e.Row.FindControl("ddSupv"), DropDownList)

            Dim asectionValue As String = DataBinder.Eval(e.Row.DataItem, "AssemblySection").ToString()
            Dim cMea As String = DataBinder.Eval(e.Row.DataItem, "Perc").ToString()
            Dim cLH As String = DataBinder.Eval(e.Row.DataItem, "PercApproval").ToString()
            ddSupv.Attributes("asection") = asectionValue
            ddSupv.Attributes("amea") = cMea
            ddSupv.Attributes("aLH") = cLH

            bapv.Attributes("asection") = asectionValue
            bapv.Attributes("amea") = cMea
            bapv.Attributes("aLH") = cLH

            Dim esupvby As String = CheckDBNull(dataItem("SupvApprovedBy"))
            Dim eassignto As String = CheckDBNull(dataItem("AssignedTo"))

            Dim qry_supv As String = "select * from vw_UserPrivilegesEmailNotif where EmailTypeDesc='Supervisory' and EmailTypeID=43 and ActiveStatus=-1 order by FullName"
            BindDataDropDown(ddSupv, qry_supv, "FullName", "UserName")

            lApv.Text = esupvby
            If esupvby = "-" Then
                lApv.Visible = False
                bapv.Visible = True
                ddSupv.SelectedValue = eassignto
            Else
                ddSupv.Text = esupvby
                ddSupv.Enabled = False
                bapv.Visible = False
                lApv.Visible = True
            End If
        End If
    End Sub

    Protected Sub bApv_Click(sender As Object, e As EventArgs)
        ewo = Request.QueryString("wo")
        If CheckGroup(43) = False Then
            'showAlert("warning", "You dont have access supervisor approval")
            showAlertV2("warning", "You dont have access supervisor approval")
            Exit Sub
        End If

        Dim bapv As LinkButton = DirectCast(sender, LinkButton)

        Dim esection As String = bapv.Attributes("asection")
        Dim eMea As String = bapv.Attributes("amea")
        Dim eLH As String = bapv.Attributes("aLH")

        If eMea <> "100" Then
            showAlertV2("warning", "Please complete measurement before approve this section !")
            Exit Sub
        End If

        If eLH <> "100" Then
            showAlertV2("warning", "Please complete Leading Hand Approval before approve this section !")
            Exit Sub
        End If

        Dim query As String = "exec dbo.AssemblyApprovalFix " & evar(ewo, 1) & "," & evar(esection, 1) & "," & eByName()
        executeQuery(query)
        load_supvSection()
        showAlertV2("success", "This Section Has Been Approve")
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub

    Protected Sub ddSupv_SelectedIndexChanged(sender As Object, e As EventArgs)

        'If CheckGroup(44) = False Then
        'showAlert("warning", "You dont have access supervisor approval")
        'showAlertV2("warning", "You dont have access supervisor approval")
        'Exit Sub
        'End If

        ewo = Request.QueryString("wo")
        Dim ddl As DropDownList = DirectCast(sender, DropDownList)
        Dim eMea As String = ddl.Attributes("amea")
        Dim eLH As String = ddl.Attributes("aLH")

        If eMea <> "100" Then
            showAlertV2("warning", "Please complete measurement before approve this section !")
            Exit Sub
        End If

        If eLH <> "100" Then
            showAlertV2("warning", "Please complete Leading Hand Approval before approve this section !")
            Exit Sub
        End If

        Dim esection As String = ddl.Attributes("asection")
        Dim query As String = "update tbl_AssemblySectionApproval set AssignedTo=" & evar(ddl.SelectedValue, 1) & ",
                AssignedDate=GetDate() where AssemblySection=" & evar(esection, 1) & " and wono=" & evar(ewo, 1)
        executeQuery(query)
        showAlertV2("success", "This Section Has Been Assign to " & ddl.Text)
        load_supvSection()
    End Sub

    Protected Sub bMea_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlAssemblyMea & "?wo=" & Request.QueryString("wo"))
    End Sub

    Protected Sub bSupvApv_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlAssemblyMeaApv & "?wo=" & Request.QueryString("wo"))
    End Sub
End Class