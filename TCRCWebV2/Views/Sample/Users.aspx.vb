Imports System.Security.Cryptography
Imports System.Web.DynamicData
Imports System.Web.UI
Imports Microsoft.Ajax.Utilities
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class Users
    Inherits System.Web.UI.Page

    Public tempfilter As String = ""
    Dim utility As New Utility(Me)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("checkboxList") Is Nothing Then
                Session("checkboxList") = New List(Of Boolean)
            End If
            GenerateJobTitle()
            GenerateData()
        End If
    End Sub

    Private Sub filtering()
        tempfilter = ""
        Dim title As String = ""
        For Each item As ListItem In ddTitle.Items
            If item.Selected Then
                'message += item.Text + " " + item.Value + "\n"
                title += evar(item.Value, 1) + ","
            End If
        Next
        If title <> String.Empty Then
            title = Left(title, Len(title) - 1)
        End If

        If tFullName.Text <> String.Empty Then tempfilter = tempfilter + " and FullName like" + evar(tFullName.Text, 11)
        If tUserID.Text <> String.Empty Then tempfilter = tempfilter + " and UserID like" + evar(tUserID.Text, 11)

        'special buat yang didalam
        If Not gvUser.HeaderRow Is Nothing Then
            Dim tUsername As TextBox = gvUser.HeaderRow.FindControl("tUsername")
            Dim username As String = tUsername.Text
            If username <> String.Empty Then tempfilter = tempfilter + " and Username like " + evar(username, 11)
        End If
        '===

        'If tJobTitle.Text <> String.Empty Then tempfilter = tempfilter + " and JobTitle like" + evar(tJobTitle.Text, 11)
        If title <> String.Empty Then tempfilter = " and JobTitle in(" & title & ")" & tempfilter

        If Len(tempfilter) > 0 Then
            tempfilter = " where " + Right(tempfilter, Len(tempfilter) - 4)
        End If
    End Sub

    Public Sub GenerateData()
        Try
            filtering()
            Dim dt As New DataTable
            Dim query As String = "select * from tbl_user" & tempfilter
            dt = GetDataTable(query)
            gvUser.DataSource = dt
            gvUser.DataBind()
            lcount.Text = gvUser.Rows.Count.ToString() + " Records Found"
        Catch ex As Exception
            Dim currentPageName As String = System.IO.Path.GetFileName(Request.Url.AbsolutePath) & ".aspx"
            lerror.Text = errPicker(currentPageName, ex.Message)
        End Try
    End Sub

    Sub GenerateJobTitle()
        Dim query As String = "select distinct(JobTitle) from tbl_user"
        BindDataListBox(ddTitle, query, "JobTitle", "JobTitle")
    End Sub

    Protected Sub gvUser_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
        ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then
            e.Row.Cells(0).Text = "No data available"
            e.Row.Cells(0).ForeColor = System.Drawing.Color.Red
            Exit Sub
        End If
    End Sub

    Protected Sub bSearch_Click(sender As Object, e As EventArgs)
        GenerateData()
    End Sub

    Protected Sub chkSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim headerCheckBox As CheckBox = DirectCast(sender, CheckBox)
        Dim chkAll As CheckBox = DirectCast(gvUser.HeaderRow.FindControl("chkSelectAll"), CheckBox)
        Session("CheckAll") = chkAll.Checked

        For Each row As GridViewRow In gvUser.Rows
            Dim cell As TableCell = row.Cells(0)
            Dim chkSelect As CheckBox = DirectCast(cell.FindControl("chkSelect"), CheckBox)
            chkSelect.Checked = headerCheckBox.Checked
        Next
    End Sub


    Protected Sub bGetCheck_Click(sender As Object, e As EventArgs)
        Dim selectData As String = ""
        For i As Integer = 0 To gvUser.Rows.Count - 1
            Dim cb As CheckBox = DirectCast(gvUser.Rows(i).FindControl("chkSelect"), CheckBox)
            If cb IsNot Nothing AndAlso cb.Checked Then
                Dim euserid As String = gvUser.Rows(i).Cells(2).Text
                selectData += evar(euserid, 1) + ","
            End If
        Next
        If selectData <> String.Empty Then
            selectData = Left(selectData, Len(selectData) - 1)
        End If
        MsgBox(selectData)
        'lanjutkan sendiri yah... :P
    End Sub

    Protected Sub bExport_Click(sender As Object, e As EventArgs)
        filtering()
        Dim str As String = "select * from tbl_User" & tempfilter

        ExportToExcelXML(str, "sample")
    End Sub

    Protected Sub bAdd_Click(sender As Object, e As EventArgs)
        utility.ModalV2("MainContent_UsersEditV2_Panel1")
    End Sub

    Protected Sub bEdit_Click(sender As Object, e As EventArgs)
        Dim button As Button = CType(sender, Button)
        Dim eid As String = button.Text

        Dim dt As New DataTable
        dt = GetDataTable("select UserID,Username,FullName,Email,JobTitle from tbl_user where UserID=" & evar(eid, 1))
        Dim eUserID As HiddenField = DirectCast(UsersEditV2.FindControl("userid"), HiddenField)
        Dim eUsername As TextBox = DirectCast(UsersEditV2.FindControl("tUsername"), TextBox)
        Dim eFullName As TextBox = DirectCast(UsersEditV2.FindControl("tFullname"), TextBox)
        Dim eEmail As TextBox = DirectCast(UsersEditV2.FindControl("tEmailAddress"), TextBox)
        Dim eJobTitle As TextBox = DirectCast(UsersEditV2.FindControl("tJobTitle"), TextBox)

        eUserID.Value = eid
        eUsername.Text = CheckDBNull(dt.Rows(0)(1))
        eFullName.Text = CheckDBNull(dt.Rows(0)(2))
        eEmail.Text = CheckDBNull(dt.Rows(0)(3))
        eJobTitle.Text = CheckDBNull(dt.Rows(0)(4))

        utility.ModalV2("MainContent_UsersEditV2_Panel1")
    End Sub
End Class