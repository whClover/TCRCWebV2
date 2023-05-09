Imports System.IO

Public Class UploadWO
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs)
        Dim fileName As String = Path.GetFileName(uploadfiles1.FileName)
        uploadfiles1.SaveAs(Server.MapPath("~/uploads/") & fileName)
        lblMsg.Text = "File Uploaded Successfully"
        System.Threading.Thread.Sleep(2000)
    End Sub
End Class