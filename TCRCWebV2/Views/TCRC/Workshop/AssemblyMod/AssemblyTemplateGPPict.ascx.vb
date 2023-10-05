Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class AssemblyTemplateGPPict
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bupload_Click(sender As Object, e As EventArgs)
        Dim eidgp As String = gidgp.Value
        Dim esection As String = gsection.Value
        If eidgp = String.Empty Then Exit Sub
        If esection = String.Empty Then Exit Sub
        Dim fs = CreateObject("Scripting.FileSystemObject")
        Dim fpath As String = PICTAssemblyTemplate & "\" & eidgp & "\"

        If fileupload.HasFiles Then
            Dim fname As String = fileupload.FileName
            Dim fext As String = fs.GetExtensionName(fname)

            If fext = "JPG" Or fext = "jpg" Or fext = "png" Or fext = "JPEG" Then
                If Not System.IO.Directory.Exists(fpath) Then
                    System.IO.Directory.CreateDirectory(fpath)
                End If

                Dim newfile As String = fpath + fname
                fileupload.SaveAs(newfile)
                Dim qchk As String = "select * from tbl_assemblyTemplatePICRev where IDTemplateAssemblyGroup=" & eidgp & " and Section=" & evar(esection, 1)
                Dim dt As New DataTable
                dt = GetDataTable(qchk)
                Dim query As String
                If dt.Rows.Count > 0 Then
                    query = "update tbl_assemblyTemplatePICRev set PicturePath=" & evar(newfile, 1) & " where IDTemplateAssemblyGroup=" & eidgp & " and Section=" & evar(esection, 1)
                    executeQuery(query)
                Else
                    query = "insert tbl_assemblyTemplatePICRev(IDTemplateAssemblyGroup,Section,PicturePath,Active) values (
                            " & eidgp & "," & evar(esection, 1) & "," & evar(newfile, 1) & ",1)"
                    executeQuery(query)
                End If
            End If
        End If
        DirectCast(Page, AssemblyTemplateDetails).bindingsection()
    End Sub
End Class