Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Public Class MeaTemplatePicUpload
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bUpload_Click(sender As Object, e As EventArgs)
        Dim eid As String = Request.QueryString("id")
        Dim esec As String = Request.QueryString("section")

        If mod_upload.HasFile = True Then
            Dim fname As String = mod_upload.FileName
            Dim f As String = mod_upload.PostedFile.ContentType

            Dim fileName As String = eid & "_" & fname
            Dim savepath As String = MeaInspPict & eid & "\"
            If Not System.IO.Directory.Exists(savepath) Then
                System.IO.Directory.CreateDirectory(savepath)
            End If

            Dim fullpath As String = savepath & fileName
            mod_upload.SaveAs(fullpath)

            Dim query As String = "exec dbo.InspSubmitPictureGroup " + eid + ",'" + esec + "','" + fullpath + "',1," & eByName()
            executeQuery(query)
            DirectCast(Page, MeaTemplateSecDetails).BindingData()
        End If
    End Sub
End Class