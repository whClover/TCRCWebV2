Public Class ErrorPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bindingDataFromURL()
    End Sub

    Sub bindingDataFromURL()
        Dim eusername As String = Session("ss_username")
        Dim epage As String = Request.QueryString("page")
        Dim esubfun As String = Request.QueryString("subfun")
        Dim eErr As String = Request.QueryString("err")

        username.InnerText = eusername
        Dim currentDateTimeUTC As DateTime = DateTime.UtcNow
        tErrorTime.InnerText = currentDateTimeUTC.ToLocalTime().ToString("dd-MM-yyyy HH:mm:ss")
        page.InnerText = epage
        subfun.InnerText = esubfun
        [error].InnerText = eErr
    End Sub
End Class