Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class FiveSArea
    Inherits System.Web.UI.Page

    Dim utility As New Utility(Me)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            GetHeader()
            bindingdata()
        End If
    End Sub

    Sub GetHeader()
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        Dim query As String = "select * from tbl_5SLocation where IDLocation=" & eid
        Dim dt As New DataTable
        dt = GetDataTable(query)
        hLocation.InnerText = dt.Rows(0)("LocationDesc")
    End Sub

    Sub bindingdata()
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        Dim query As String = "select * from tbl_5SArea where IDLocation=" & eid & " and Deactive=0 order by Seq"
        Dim dt As New DataTable

        dt = GetDataTable(query)
        gv5SArea.DataSource = dt
        gv5SArea.DataBind()
    End Sub

    Protected Sub gv5SArea_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblNo As Label = CType(e.Row.FindControl("lblNo"), Label)
            lblNo.Text = (e.Row.RowIndex + 1).ToString()
        End If
    End Sub

    Protected Sub bedit_Click(sender As Object, e As EventArgs)
        Dim hidlocation As HiddenField = DirectCast(FiveSAreaForm.FindControl("hidlocation"), HiddenField)
        Dim hidarea As HiddenField = DirectCast(FiveSAreaForm.FindControl("hidarea"), HiddenField)
        Dim tSeq As TextBox = DirectCast(FiveSAreaForm.FindControl("tSeq"), TextBox)
        Dim tArea As TextBox = DirectCast(FiveSAreaForm.FindControl("tArea"), TextBox)
        Dim eidarea As String = CType(sender, LinkButton).CommandArgument

        hidlocation.Value = Request.QueryString("id")
        hidarea.Value = eidarea

        'call data
        Dim dt As New DataTable
        Dim query As String = "select * from tbl_5SArea where IDArea=" & eidarea
        dt = GetDataTable(query)
        tSeq.Text = dt.Rows(0)("Seq").ToString()
        tArea.Text = dt.Rows(0)("AreaDesc").ToString()

        utility.ModalV2("MainContent_FiveSAreaForm_Panel1")
    End Sub

    Protected Sub badd_Click(sender As Object, e As EventArgs)
        Dim hidlocation As HiddenField = DirectCast(FiveSAreaForm.FindControl("hidlocation"), HiddenField)
        Dim hidarea As HiddenField = DirectCast(FiveSAreaForm.FindControl("hidarea"), HiddenField)
        Dim tSeq As TextBox = DirectCast(FiveSAreaForm.FindControl("tSeq"), TextBox)
        Dim tArea As TextBox = DirectCast(FiveSAreaForm.FindControl("tArea"), TextBox)
        Dim eidarea As String = CType(sender, LinkButton).CommandArgument
        hidlocation.Value = Request.QueryString("id")

        hidarea.Value = ""
        tSeq.Text = ""
        tArea.Text = ""

        utility.ModalV2("MainContent_FiveSAreaForm_Panel1")
    End Sub

    Protected Sub bdeactive_Click(sender As Object, e As EventArgs)
        Dim eidarea As String = CType(sender, LinkButton).CommandArgument
        Dim query As String = "update tbl_5SArea set Deactive=1,DeactiveBy=" & eByName() & ",DeactiveDate=Getdate() where IDArea=" & eidarea
        executeQuery(query)
        bindingdata()
    End Sub

    Protected Sub bback_Click(sender As Object, e As EventArgs)
        Response.Redirect(url5SLocation)
    End Sub
End Class