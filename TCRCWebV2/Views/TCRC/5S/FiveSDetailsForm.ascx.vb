Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports DocumentFormat.OpenXml.Wordprocessing
Imports System.Reflection.Emit
Imports System.IO

Public Class FiveSDetailsForm
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bsave_Click(sender As Object, e As EventArgs)
        Dim eidfindinggp As String = hidfindingGP.Value
        Dim eidfinding As String = hidfinding.Value
        Dim eidarea As String = hidarea.Value

        Dim etemuan, eaction As String
        If tfinding.Text <> String.Empty Then etemuan = evar(tfinding.Text, 1) Else Exit Sub
        If taction.Text <> String.Empty Then eaction = evar(taction.Text, 1) Else eaction = "NULL"

        Dim query As String
        If eidfinding = String.Empty Then
            query = "insert into tbl_5SFindingDetails(IDFindingGP,IDArea,FindingDesc,FindingAct,FindingStatus,RegisterBy,RegisterDate) values 
                    (" & eidfindinggp & "," & eidarea & "," & etemuan & "," & eaction & ",NULL," & eByName() & ",getdate())"
        Else
            query = "update tbl_5SFindingDetails set FindingDesc=" & etemuan & ",FindingAct=" & eaction & ",
                    ModBy=" & eByName() & ",ModDate=GetDate() where IDFinding=" & eidfinding
        End If

        executeQuery(query)
        DirectCast(Page, FiveSDetails).bindingdata()
    End Sub

    Protected Sub bupload_Click(sender As Object, e As EventArgs)
        Dim newfile As String
        Dim eidfinding As String = Request.QueryString("id")
        Dim epathpict As String = Picture5S & eidfinding & "\"
        If FileUpload1.HasFiles Then
            Dim allowedExtensions As String() = {".jpg", ".jpeg", ".png"}
            For Each uploadedFile As HttpPostedFile In FileUpload1.PostedFiles
                Dim fileExtension As String = System.IO.Path.GetExtension(uploadedFile.FileName)
                If allowedExtensions.Contains(fileExtension) Then
                    If Not System.IO.Directory.Exists(epathpict) Then
                        System.IO.Directory.CreateDirectory(epathpict)
                    End If

                    Dim fileName As String = Path.GetFileName(uploadedFile.FileName)
                    newfile = epathpict & "\" & fileName

                    'Dim filePath As String = Server.MapPath("~/uploads/" + fileName)
                    uploadedFile.SaveAs(newfile)

                    Dim eidarea As String = hidarea.Value
                    Dim query As String = "insert into tbl_5SPicture(IDFinding,IDArea,PicturePath) values(
                                            " & eidfinding & "," & eidarea & "," & evar(newfile, 1) & ")"
                    executeQuery(query)
                    ' File adalah gambar, lakukan sesuatu di sini
                Else
                    ' File bukan gambar, tampilkan pesan kesalahan
                    MsgBox("File " + uploadedFile.FileName + " tidak diizinkan. Hanya diperbolehkan mengunggah file gambar (JPG, JPEG, PNG).<br />")
                End If
            Next
        End If
    End Sub
End Class