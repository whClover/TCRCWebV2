Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class _5SLocation
    Inherits System.Web.UI.Page

    Dim utility As New Utility(Me)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingData()
        End If
    End Sub

    Sub bindingData()
        Dim query As String = "select * from tbl_5SLocation where Deactive=0"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        gv5SLocation.DataSource = dt
        gv5SLocation.DataBind()
    End Sub

    Protected Sub bdetails_Click(sender As Object, e As EventArgs)
        Dim eid As String = CType(sender, LinkButton).CommandArgument
        Response.Redirect(url5SArea & "?id=" & eid)
    End Sub

    Protected Sub bedit_Click(sender As Object, e As EventArgs)
        Dim hidlocation As HiddenField = DirectCast(FiveSLocationForm.FindControl("hidlocation"), HiddenField)
        Dim tLocation As TextBox = DirectCast(FiveSLocationForm.FindControl("tLocation"), TextBox)
        Dim eidlocation As String = CType(sender, LinkButton).CommandArgument

        hidlocation.Value = eidlocation

        'call data
        Dim dt As New DataTable
        Dim query As String = "select * from tbl_5SLocation where IDLocation=" & eidlocation
        dt = GetDataTable(query)
        tLocation.Text = dt.Rows(0)("LocationDesc").ToString()

        utility.ModalV2("MainContent_FiveSLocationForm_Panel1")
    End Sub

    Protected Sub badd_Click(sender As Object, e As EventArgs)
        Dim hidlocation As HiddenField = DirectCast(FiveSLocationForm.FindControl("hidlocation"), HiddenField)
        Dim tLocation As TextBox = DirectCast(FiveSLocationForm.FindControl("tLocation"), TextBox)

        hidlocation.Value = ""
        tLocation.Text = ""

        utility.ModalV2("MainContent_FiveSLocationForm_Panel1")
    End Sub
End Class