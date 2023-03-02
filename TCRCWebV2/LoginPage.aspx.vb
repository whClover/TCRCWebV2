Imports System.Data.SqlClient
Imports Microsoft.Ajax.Utilities
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class LoginPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim eid As String = Request.QueryString("id")
            Select Case eid
                Case 1
                    webapp.Text = "TCRC"
                Case 2
                    webapp.Text = "PER"
                Case 3
                    webapp.Text = "TMRP"
                Case 4
                    webapp.Text = "Fabshop"
            End Select
        End If
    End Sub

    Sub login()
        Session.RemoveAll()
        Dim eWebApp As String = evar(webapp.Text, 1)
        Dim eusername As String = evar(tjdeuser.Text, 1)
        Dim ePass As String = evar(tpass.Text, 1)

        Dim query As String = "select userid, dbo.decryptpass(pass) as dbpass, Username, FullName, Previllege, ActiveStatus, email from tbl_user where userid=" + eusername + " or Username=" + eusername
        Dim dt As New DataTable
        dt = GetDataTable(query)

        If dt.Rows.Count = 0 Then
            eNotif.Style.Add("display", "Block")
            eTxtNofif.InnerHtml = "<i class=""fas fa-exclamation-circle""></i> User/JDE " + eusername + " is Not Registered"
        Else
            eNotif.Style.Add("display", "none")
            For Each row As DataRow In dt.Select()
                Dim currpass = evar(row("dbpass"), 1)
                If (row("ActiveStatus")) = 0 Then
                    eNotif.Style.Add("display", "Block")
                    eTxtNofif.InnerHtml = "<i class=""fas fa-exclamation-circle""></i> User/JDE " + eusername + " No Longer Active"
                ElseIf ePass <> currpass Then
                    eNotif.Style.Add("display", "Block")
                    eTxtNofif.InnerHtml = "<i class=""fas fa-exclamation-circle""></i> Password did not Match"
                Else
                    Session("ss_userid") = row("userid")
                    Session("ss_username") = row("username")
                    Session("ss_fullname") = row("fullname")
                    Session("ss_priv") = row("Previllege")
                    Session("ss_email") = row("Email")

                    Dim eweb As String = webapp.Text
                    Select Case eweb
                        Case "TCRC"
                            Response.Redirect("~/Views/TCRC/index.aspx")
                    End Select
                End If
            Next
        End If
    End Sub

    Protected Sub bLogin_Click(sender As Object, e As EventArgs)
        login()
    End Sub
End Class