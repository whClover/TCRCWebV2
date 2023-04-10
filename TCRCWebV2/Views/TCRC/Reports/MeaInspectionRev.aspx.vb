Imports System.IO

Public Class MeaInspectionRev
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim filePath As String = Server.MapPath("~/Files/tes.html")
        Dim htmlCode As String = File.ReadAllText(filePath)
        'cover.InnerHtml = htmlCode
    End Sub

End Class