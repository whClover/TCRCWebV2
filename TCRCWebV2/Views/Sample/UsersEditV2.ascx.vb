Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Public Class UsersEditV2
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lNotif.Visible = False
        End If
    End Sub

    Protected Sub bSave_Click(sender As Object, e As EventArgs)
        Dim eUserID, eUsername, eFullName, eMail, eJobTitle As String

        eUserID = userid.Value
        If eUserID = String.Empty Then
            lNotif.InnerText = "Please Check UserID"
            lNotif.Visible = True
            Exit Sub
        End If

        If tUsername.Text = String.Empty Then
            lNotif.InnerText = "Please Fill Username"
            lNotif.Visible = True
            Exit Sub
        Else
            eUsername = evar(tUsername.Text, 1)
        End If

        If tFullname.Text = String.Empty Then
            lNotif.InnerText = "Please Fill FullName"
            lNotif.Visible = True
            Exit Sub
        Else
            eFullName = evar(tFullname.Text, 1)
        End If

        If tEmailAddress.Text = String.Empty Then
            lNotif.InnerText = "Please Fill Email Address"
            lNotif.Visible = True
            Exit Sub
        Else
            eMail = evar(tEmailAddress.Text, 1)
        End If

        If tJobTitle.Text = String.Empty Then
            lNotif.InnerText = "Please Fill Email Address"
            lNotif.Visible = True
            Exit Sub
        Else
            eJobTitle = evar(tJobTitle.Text, 1)
        End If

        'lanjutin yaa untuk masuk query insert nya....
        '.....

        'buat manggil "Public" sub GenerateData di form Users.aspx
        DirectCast(Page, Users).GenerateData()

    End Sub
End Class