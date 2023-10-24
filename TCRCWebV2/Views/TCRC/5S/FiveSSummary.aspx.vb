Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports System.Globalization

Public Class FiveSSummary
    Inherits System.Web.UI.Page

    Dim tempfilter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            loaddata()
            bindingdata()
        End If
    End Sub

    Sub loaddata()
        BindDataDropDown(ddLoc, "select IDLocation,LocationDesc from tbl_5SLocation", "LocationDesc", "IDLocation")

        Dim query As String = "select username,fullname from tbl_user where username in(select distinct(RegisterBy) from tbl_5SFindingDetails) order by fullname"
        BindDataDropDown(ddInspector, query, "fullname", "username")
    End Sub

    Sub filterdata()
        'Date
        If tStart.Value <> String.Empty Then
            tempfilter = " AND convert(date,RegisterDate,103) >= " & evar(tStart.Value, 2) & tempfilter
        End If
        If tEnd.Value <> String.Empty Then
            tempfilter = " AND convert(date,RegisterDate,103) <= " & evar(tEnd.Value, 2) & tempfilter
        End If
        'End: Date

        If ddLoc.SelectedValue <> String.Empty Then
            tempfilter = " AND IDLocation=" & evar(ddLoc.SelectedValue, 0) & tempfilter
        End If

        If ddInspector.SelectedValue <> String.Empty Then
            tempfilter = " AND RegisterBy=" & evar(ddInspector.SelectedValue, 1) & tempfilter
        End If

        If Len(tempfilter) > 0 Then
            tempfilter = varfilter(tempfilter)
        End If
    End Sub

    Sub bindingdata()
        filterdata()
        Dim ecolumn As String = "RegisterBy,convert(varchar,RegisterDate,103) as RegisterDate,FindingDesc,FindingAct,AreaDesc,dbo.RemapPict5S(PicturePath) as rmPict,
                                AssignTo,InspectStatus"
        Dim query As String = "select " & ecolumn & " from v_5SSummary" & tempfilter & " order by RegisterDate"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        gv5sSummary.DataSource = dt
        gv5sSummary.DataBind()
    End Sub

    Protected Sub bsearch_Click(sender As Object, e As EventArgs)
        bindingdata()
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub

    Protected Sub bgenPT_Click(sender As Object, e As EventArgs)

        Dim eidloc, estart, eend, einsp As String
        If ddLoc.Text = String.Empty Then
            showAlertV2("info", "Please select at least 1 Location")
            Exit Sub
        Else
            eidloc = ddLoc.SelectedValue
        End If


        If tStart.Value = String.Empty Then
            showAlertV2("info", "Please fill start date")
            Exit Sub
        Else
            estart = tStart.Value
        End If

        If tEnd.Value = String.Empty Then
            showAlertV2("info", "Please fill end date")
            Exit Sub
        Else
            eend = tEnd.Value
        End If

        If ddInspector.Text <> String.Empty Then
            einsp = ddInspector.SelectedValue
        End If

        'Response.Redirect(Rpt5S & "?idloc=" & eidloc & "&start=" & estart & "&end=" & eend)
        'Exit Sub

        Dim namafile, namafile2 As String
        Dim randomstring As String = generateRandom()
        'Rpt5S
        Dim fs = CreateObject("Scripting.FileSystemObject")
        Dim savepath As String = Server.MapPath("~/") & "temp/"
        If Not System.IO.Directory.Exists(savepath) Then
            System.IO.Directory.CreateDirectory(savepath)
        End If
        'MsgBox(generateRandom())
        namafile = savepath & randomstring & "_5S.pdf"
        Dim p As Process = New Process()
        p.StartInfo.FileName = "C:\webroot\TCRC Web\Rotativa\wkhtmltopdf.exe"
        'p.StartInfo.FileName = "C:\Rotativa\wkhtmltopdf.exe" 'local indra
        p.StartInfo.Arguments = "--orientation Landscape http://bpnaps07:88/Views/TCRC/Reports/FiveS.aspx?idloc=" & eidloc & "&start=" & estart & "&end=" & eend & "&insp=" & einsp & " " & namafile
        p.Start()
        p.WaitForExit()

        namafile2 = Server.MapPath("~/") & "temp/" & randomstring & "_5S.pdf"
        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("Content-Disposition", "inline;filename=" & namafile2)
        Response.TransmitFile(namafile2)
        Response.Flush()
        Response.End()
    End Sub
End Class