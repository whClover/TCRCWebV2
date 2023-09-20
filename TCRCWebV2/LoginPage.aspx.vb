Imports System.Data.SqlClient
Imports Microsoft.Ajax.Utilities
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class LoginPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub login()
        Session.RemoveAll()
        Dim eusername As String = evar(tjdeuser.Text, 1)
        Dim ePass As String = evar(tpass.Text, 1)

        Dim query As String = "select userid, dbo.decryptpass(pass) as dbpass, Username, FullName, Previllege, ActiveStatus, email from tbl_user where userid=" + eusername + " or Username=" + eusername
        Dim dt As New DataTable
        dt = GetDataTable(query)

        If dt.Rows.Count = 0 Then
            showAlertV2("warning", "Username/JDE is not found on system.")
            Exit Sub
        Else
            For Each row As DataRow In dt.Select()
                Dim currpass = evar(row("dbpass"), 1)
                If (row("ActiveStatus")) = 0 Then
                    showAlertV2("warning", "Username/JDE is not active. Please contact system administrator to re-active.")
                    Exit Sub
                ElseIf ePass <> currpass Then
                    showAlertV2("warning", "Password incorrect")
                    Exit Sub
                Else
                    Session("ss_userid") = row("userid")
                    Session("ss_username") = row("username")
                    Session("ss_fullname") = row("fullname")
                    Session("ss_priv") = row("Previllege")
                    Session("ss_email") = row("Email")
                    Response.Redirect("~/Views/TCRC/index.aspx")
                End If
            Next
        End If
    End Sub

    Protected Sub bLogin_Click(sender As Object, e As EventArgs)
        login()
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub
End Class