Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports DocumentFormat.OpenXml.Office2010.Drawing.Charts
Imports Org.BouncyCastle.Utilities

Public Class FiveSList
    Inherits System.Web.UI.Page

    Dim utility As New Utility(Me)
    Dim tempfilter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingdata()
            loaddropdown()
        End If
    End Sub

    Sub loaddropdown()
        BindDataDropDown(ddLocation, "select * from tbl_5SLocation", "LocationDesc", "IDLocation")
        BindDataDropDown(ddInspector, "select username,fullname from tbl_user where username in(select distinct(RegisterBy) from tbl_5SFindingDetails) order by fullname", "Fullname", "Username")
        BindDataDropDown(ddassignto, "select * from vw_UserPrivilegesEmailNotif where EmailTypeDesc='Supervisory' and EmailTypeID=43 and ActiveStatus=-1 order by FullName", "FullName", "Username")
        BindDataDropDown(ddsupv, "select * from vw_UserPrivilegesEmailNotif where EmailTypeDesc='Supervisory' and EmailTypeID=43 and ActiveStatus=-1 order by FullName", "FullName", "Username")
    End Sub

    Sub bindingdata()
        filtering()
        Dim query As String = "select *,convert(varchar,RegisterDate,103) as formatDate from v_5SRegister" & tempfilter & " Order by RegisterDate"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        gv5SList.DataSource = dt
        gv5SList.DataBind()
    End Sub

    Protected Sub badd_Click(sender As Object, e As EventArgs)
        utility.ModalV2("MainContent_FiveSAssignArea_Panel1")
    End Sub

    Protected Sub bshow_Click(sender As Object, e As EventArgs)
        Dim eidgp As String = CType(sender, LinkButton).CommandArgument
        Response.Redirect(url5sDetails & "?id=" & eidgp)
    End Sub

    Sub filtering()
        'Date
        If tStart.Value <> String.Empty Then
            tempfilter = " AND convert(date,RegisterDate,103) >= " & evar(tStart.Value, 2) & tempfilter
        End If
        If tEnd.Value <> String.Empty Then
            tempfilter = " AND convert(date,RegisterDate,103) <= " & evar(tEnd.Value, 2) & tempfilter
        End If
        'End: Date

        Dim elocation As String
        If ddLocation.Text <> String.Empty Then tempfilter = " AND IDLocation=" & ddLocation.SelectedValue & tempfilter
        If ddInspector.Text <> String.Empty Then tempfilter = " AND RegisterBy=" & evar(ddInspector.SelectedValue, 1) & tempfilter
        If ddassignto.Text <> String.Empty Then tempfilter = " AND AssignTo=" & evar(ddassignto.SelectedValue, 1) & tempfilter
        If ddsupv.Text <> String.Empty Then tempfilter = " AND SupvApprovedBy=" & evar(ddsupv.SelectedValue, 1) & tempfilter

        If Len(tempfilter) > 0 Then
            tempfilter = varfilter(tempfilter)
        End If
    End Sub

    Protected Sub bsearch_Click(sender As Object, e As EventArgs)
        bindingdata()
    End Sub
End Class