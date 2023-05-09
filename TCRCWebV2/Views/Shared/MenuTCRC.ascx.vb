Imports TCRCWebV2.GlobalString

Public Class MenuTCRC1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bLogout_Click(sender As Object, e As EventArgs)
        Session.Abandon()
        FormsAuthentication.SignOut()
        Response.Redirect(urlTCRCLogin)
    End Sub

    Protected Sub bWS_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlTCRCWorkshopIx)
    End Sub

    Protected Sub bOffice_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlTCRCOfficeIx)
    End Sub
End Class