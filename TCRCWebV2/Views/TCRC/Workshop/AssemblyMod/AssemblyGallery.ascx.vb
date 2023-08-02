Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports Microsoft.SqlServer.Server

Public Class AssemblyGallery
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            load_data()
        End If
    End Sub

    Sub load_data()
        Dim dt As New DataTable
        Dim ewo As String = Request.QueryString("wo")
        Dim query_section As String = "select distinct(AssemblySection) from v_AssemblySectionPicture where wono=" & evar(ewo, 1)
        Dim query As String = "select distinct(SectionName) from tbl_AssemblyInputPict where wono=" & evar(ewo, 1) & "
		                    order by SectionName"

        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            rpt_sec.DataSource = dt
            rpt_sec.DataBind()
        Else
            lna.Visible = True
        End If

        BindDataDropDown(ddsection, query_section, "AssemblySection", "AssemblySection")
    End Sub

    Protected Sub rpt_sec_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)
            Dim ewo As String = Request.QueryString("wo")

            Dim rpt_pic As Repeater = CType(e.Item.FindControl("rpt_pic"), Repeater)
            Dim dt As New DataTable
            Dim query As String = "select '../../../' + dbo.ReMapPicW(PicturePath) as PicturePath from tbl_AssemblyInputPict 
			                where wono=" & evar(ewo, 1) & " and SectionName=" & evar(dataItem("SectionName").ToString(), 1) & ""
            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                rpt_pic.DataSource = dt
                rpt_pic.DataBind()
            End If
        End If
    End Sub

    Protected Sub bupload_Click(sender As Object, e As EventArgs)
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub

        Dim esection As String = String.Empty
        Dim fs = CreateObject("Scripting.FileSystemObject")
        Dim newfile As String
        Dim epathattachment As String = asmpict & ewo & "\"

        If fileupload.HasFile = True Then
            Dim fname As String = fileupload.FileName
            Dim fext As String = fs.GetExtensionName(fname)

            If fext = "JPG" Or fext = "jpg" Then
                GoTo lanjut
            End If

            If fext = "png" Then
                GoTo lanjut
            End If

            If fext = "JPEG" Then
                GoTo lanjut
            End If

lanjut:
            esection = ddsection.Text
            If Not System.IO.Directory.Exists(epathattachment + "\" + esection) Then
                System.IO.Directory.CreateDirectory(epathattachment + "\" + esection)
            End If

            newfile = epathattachment + esection + "\" + fname
            fileupload.SaveAs(newfile)

            fs = Nothing

            Dim query As String = "Insert into tbl_AssemblyInputPict(SectionName,PicturePath,Active,RegisterBy,RegisterDate,WONO) values" _
                                & "('" + esection + "','" + newfile + "','1'," + eByName() + ",GetDate(),'" + ewo + "')"
            executeQuery(query)
        End If

        Response.Redirect(urlAssemblyMea & "?wo=" & ewo)
    End Sub
End Class