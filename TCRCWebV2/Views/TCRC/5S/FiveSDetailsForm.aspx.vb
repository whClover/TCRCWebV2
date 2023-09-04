Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports System.IO

Public Class FiveSDetailsForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingData()
        End If
    End Sub

    Sub bindingData()
        Dim eidinspection As String = Request.QueryString("id")
        If eidinspection = String.Empty Then eidinspection = "0"
        Dim query As String = "select * from tbl_5SFindingDetails where IDFinding=" & eidinspection
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count <> 0 Then
            eTitle.InnerText = "Edit Findings"
            hidfindingGP.Value = dt.Rows(0)("IDFindingGP")
            hidfinding.Value = dt.Rows(0)("IDFinding")
            hidarea.Value = dt.Rows(0)("IDArea")
            tfinding.Text = dt.Rows(0)("FindingDesc")
            taction.Text = CheckDBNull(dt.Rows(0)("FindingAct"))
            ddnilai.SelectedValue = IIf(IsDBNull(dt.Rows(0)("NilaiFinding")) = True, "", dt.Rows(0)("NilaiFinding"))

            'get area
            Dim query2 As String = "select * from tbl_5SArea where IDArea=" & dt.Rows(0)("IDArea")
            Dim dt2 As New DataTable
            dt2 = GetDataTable(query2)
            tArea.Text = dt2.Rows(0)("AreaDesc")
            'end get area

            loadpicture()
        Else
            Dim eidarea As String = Request.QueryString("idarea")
            Dim query2 As String = "select * from tbl_5SArea where IDArea=" & eidarea
            Dim dt2 As New DataTable
            dt2 = GetDataTable(query2)
            tArea.Text = dt2.Rows(0)("AreaDesc")
            hidarea.Value = dt2.Rows(0)("IDArea")
            hidfindingGP.Value = Request.QueryString("idgp")
            eTitle.InnerText = "Register Findings"
            dupload.Visible = False
            rupload.Visible = False
        End If


    End Sub

    Sub loadpicture()
        Dim eidfinding As String = hidfinding.Value
        Dim eidarea As String = hidarea.Value
        Dim query As String = "select *,dbo.RemapPict5S(PicturePath) as remap from tbl_5SPicture where IDFinding=" & eidfinding & " and IDArea=" & eidarea
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count = 0 Then Exit Sub
        rpt_pict.DataSource = dt
        rpt_pict.DataBind()
    End Sub

    Protected Sub bupload_Click(sender As Object, e As EventArgs)
        Dim newfile As String
        Dim eidfinding As String = Request.QueryString("id")
        Dim epathpict As String = Picture5S & eidfinding & "\"
        If FileUpload1.HasFiles Then
            Dim allowedExtensions As String() = {".jpg", ".jpeg", ".png", ".JPG", ".JPEG", ".PNG"}
            For Each uploadedFile As HttpPostedFile In FileUpload1.PostedFiles
                Dim fileExtension As String = System.IO.Path.GetExtension(uploadedFile.FileName)
                If allowedExtensions.Contains(fileExtension) Then
                    If Not System.IO.Directory.Exists(epathpict) Then
                        System.IO.Directory.CreateDirectory(epathpict)
                    End If

                    Dim fileName As String = Path.GetFileName(uploadedFile.FileName)
                    newfile = epathpict & fileName

                    'Dim filePath As String = Server.MapPath("~/uploads/" + fileName)
                    uploadedFile.SaveAs(newfile)

                    Dim eidarea As String = hidarea.Value
                    Dim query As String = "insert into tbl_5SPicture(IDFinding,IDArea,PicturePath) values(
                                            " & eidfinding & "," & eidarea & "," & evar(newfile, 1) & ")"
                    executeQuery(query)
                    ' File adalah gambar, lakukan sesuatu di sini
                Else
                    ' File bukan gambar, tampilkan pesan kesalahan
                    showAlertV2("warning", "File " + uploadedFile.FileName + " tidak diizinkan. Hanya diperbolehkan mengunggah file gambar (JPG, JPEG, PNG).<br />")
                    'MsgBox("File " + uploadedFile.FileName + " tidak diizinkan. Hanya diperbolehkan mengunggah file gambar (JPG, JPEG, PNG).<br />")
                End If
            Next
        End If

        bindingData()
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub

    Protected Sub bsave_Click(sender As Object, e As EventArgs)
        Dim eidfindinggp As String = hidfindingGP.Value
        Dim eidfinding As String = hidfinding.Value
        Dim eidarea As String = hidarea.Value

        Dim etemuan, eaction, enilai As String
        If tfinding.Text <> String.Empty Then etemuan = evar(tfinding.Text, 1) Else Exit Sub
        If taction.Text <> String.Empty Then eaction = evar(taction.Text, 1) Else eaction = "NULL"
        If ddnilai.Text <> String.Empty Then enilai = evar(ddnilai.SelectedValue, 0) Else enilai = "NULL"

        Dim query As String
        If eidfinding = String.Empty Then
            query = "insert into tbl_5SFindingDetails(IDFindingGP,IDArea,FindingDesc,FindingAct,FindingStatus,NilaiFinding,RegisterBy,RegisterDate) values 
                    (" & eidfindinggp & "," & eidarea & "," & etemuan & "," & eaction & ",NULL," & enilai & "," & eByName() & ",getdate())"
        Else
            query = "update tbl_5SFindingDetails set FindingDesc=" & etemuan & ",NilaiFinding=" & enilai & ",FindingAct=" & eaction & ",
                    ModBy=" & eByName() & ",ModDate=GetDate() where IDFinding=" & eidfinding
        End If

        'MsgBox(query)
        executeQuery(query)
        Response.Redirect(url5sDetails & "?id=" & eidfindinggp)
    End Sub

    Protected Sub bclose_Click(sender As Object, e As EventArgs)
        Dim eidfindinggp As String = hidfindingGP.Value
        If eidfindinggp = String.Empty Then eidfindinggp = Request.QueryString("idgp")

        Response.Redirect(url5sDetails & "?id=" & eidfindinggp)
    End Sub

    Protected Sub delpict_Click(sender As Object, e As EventArgs)
        Dim eid As String = CType(sender, LinkButton).CommandArgument
        Dim query As String = "delete from tbl_5SPicture where ID5SPict=" & eid
        executeQuery(query)
        bindingData()
    End Sub
End Class