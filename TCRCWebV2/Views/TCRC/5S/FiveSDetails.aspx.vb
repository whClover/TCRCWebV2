Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports DocumentFormat.OpenXml.Office2010.Excel
Imports Org.BouncyCastle.Asn1.Crmf

Public Class FiveSDetails
    Inherits System.Web.UI.Page

    Dim utility As New Utility(Me)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingdata()
            checksupv()
            loadDropDown()
        End If
    End Sub

    Sub loadDropDown()
        Dim qry_supv As String = "select * from vw_UserPrivilegesEmailNotif where EmailTypeDesc='Supervisory' and EmailTypeID=43 and ActiveStatus=-1 order by FullName"
        BindDataDropDown(ddLeader, qry_supv, "FullName", "UserName")
    End Sub

    Sub bindingdata()
        Dim eidGP As String = Request.QueryString("id")
        Dim qry As String = "select *,convert(varchar,registerdate,103) as formdate from v_5SRegister where IDFindingGP=" & eidGP
        Dim dt2 As New DataTable
        dt2 = GetDataTable(qry)

        Dim eidlocation As String = dt2.Rows(0)("IDLocation").ToString()
        Dim eFullName As String = dt2.Rows(0)("FullName").ToString()
        Dim eDate As String = dt2.Rows(0)("formdate").ToString()
        Dim eSupvName As String = CheckDBNull(dt2.Rows(0)("SupvApprovedBy").ToString())
        Dim eassignto As String = CheckDBNull(dt2.Rows(0)("AssignTo").ToString())

        If eassignto = String.Empty Then
        Else
            ddLeader.SelectedValue = CheckDBNullv1(dt2.Rows(0)("AssignTo").ToString())
        End If


        head1.InnerHtml = "Date: " & eDate & "<br /> Inspector: " & eFullName & "<br />Approved By: " & eSupvName

        Dim dt As New DataTable
        Dim query As String = "select * from tbl_5SArea where IDLocation=" & eidlocation & " and Deactive=0 order by Seq"
        dt = GetDataTable(query)
        rptArea.DataSource = dt
        rptArea.DataBind()
    End Sub

    Protected Sub rptArea_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            Dim gvdetails As GridView = CType(e.Item.FindControl("gvdetails"), GridView)
            gvdetails.DataSource = New List(Of String)
            gvdetails.DataBind()

            Dim eidgp As String = Request.QueryString("id")

            Dim query As String = "select *
                    ,case when NilaiFinding is null then 'Belum di Nilai' when NilaiFinding=1 then 'Kurang Baik' when NilaiFinding=2 then 'Baik' else 'Sangat Baik' end as NilaiVal,
                    convert(varchar,RegisterDate,103) as RegDate 
                    from tbl_5SFindingDetails where IDFindingGP=" & eidgp & " and IDArea=" & dataItem("IDArea")
            Dim dt As New DataTable
            dt = GetDataTable(query)
            gvdetails.DataSource = dt
            gvdetails.DataBind()
        End If
    End Sub

    Protected Sub baddissue_Click(sender As Object, e As EventArgs)
        If ddLeader.SelectedValue <> "" Then
            'showAlertV2("warning", "Tidak dapat menambahkan finding/edit karna sudah di approve oleh leader")
            'Exit Sub
        End If

        Dim eidarea As String = CType(sender, LinkButton).CommandArgument
        Dim eidgroup As String = Request.QueryString("id")

        Response.Redirect(url5sForm & "?idarea=" & eidarea & "&idgp=" & eidgroup)
    End Sub

    Protected Sub bedit_Click(sender As Object, e As EventArgs)
        Dim eidfinding As String = CType(sender, LinkButton).CommandArgument
        GoTo method_2
        Dim hidfinding As HiddenField = DirectCast(FiveSDetailsForm.FindControl("hidfinding"), HiddenField)
        Dim hidarea As HiddenField = DirectCast(FiveSDetailsForm.FindControl("hidarea"), HiddenField)
        Dim tarea As TextBox = DirectCast(FiveSDetailsForm.FindControl("tArea"), TextBox)
        Dim tfinding As TextBox = DirectCast(FiveSDetailsForm.FindControl("tfinding"), TextBox)
        Dim taction As TextBox = DirectCast(FiveSDetailsForm.FindControl("taction"), TextBox)

        Dim query As String = "select * from tbl_5SFindingDetails where IDFinding=" & eidfinding
        Dim dt As New DataTable
        dt = GetDataTable(query)

        hidfinding.Value = eidfinding
        hidarea.Value = dt.Rows(0)("IDArea").ToString()
        tfinding.Text = dt.Rows(0)("FindingDesc").ToString()
        taction.Text = dt.Rows(0)("FindingAct").ToString()

        'get area
        Dim query2 As String = "select * from tbl_5SArea where IDArea=" & dt.Rows(0)("IDArea")
        Dim dt2 As New DataTable
        dt2 = GetDataTable(query2)
        tarea.Text = dt2.Rows(0)("AreaDesc")

        utility.ModalV2("MainContent_FiveSDetailsForm_Panel1")

method_2:
        'Dim query3 As String = "select * from tbl_5SFindingGP where IDFindingGP=(select top 1 IDFindingGP from tbl_5SFindingDetails where IDFinding=" & eidfinding & ")"
        'Dim dt3 As New DataTable
        'dt3 = GetDataTable(query3)
        'If CheckDBNullv1(dt3.Rows(0)("SupvApprovedBy")) = "" Then
        Response.Redirect(url5sForm & "?id=" & eidfinding)
        'Else
        'showAlertV2("warning", "Tidak dapat menambahkan finding/edit karna sudah di approve oleh leader")
        'Exit Sub
        'End If
    End Sub

    Protected Sub gvdetails_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblNo As Label = CType(e.Row.FindControl("lblNo"), Label)
            lblNo.Text = (e.Row.RowIndex + 1).ToString()
        End If
    End Sub

    Sub checksupv()
        Dim query As String = "select * from tbl_5SFindingGP where IDFindingGP=" & Request.QueryString("id")
        Dim dt As New DataTable
        dt = GetDataTable(query)
        Dim esupv As String = dt.Rows(0)("SupvApprovedBy").ToString()
        Dim eassign As String = CheckDBNull(dt.Rows(0)("AssignTo").ToString())
        If esupv <> String.Empty Then
            bSupvApv.Visible = False
        End If
        If eassign <> String.Empty Then
            bassign.Visible = False
            ddLeader.Enabled = False
        End If
    End Sub

    Protected Sub bSupvApv_Click(sender As Object, e As EventArgs)
        If CheckGroup(43) = False Then
            showAlertV2("warning", "You dont have access supervisor approval")
            Exit Sub
        End If

        Dim query As String = "update tbl_5SFindingGP set SupvApprovedBy=" & eByName() & ",SupvApprovedDate=GetDate() where IDFindingGP=" & Request.QueryString("id")
        executeQuery(query)
        bindingdata()
        checksupv()

    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub

    Protected Sub bBack_Click(sender As Object, e As EventArgs)
        Response.Redirect(url5SRegister)
    End Sub

    Protected Sub bassign_Click(sender As Object, e As EventArgs)
        Dim eleader As String = ddLeader.SelectedValue
        If eleader <> String.Empty Then
            Dim query As String = "update tbl_5SFindingGP set AssignTo=" & evar(eleader, 1) & " where IDFindingGP=" & Request.QueryString("id")
            executeQuery(query)
        End If
        bindingdata()
    End Sub
End Class