Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports Microsoft.SqlServer.Server
Imports Org.BouncyCastle.Asn1.Cmp

Public Class AssemblyList
    Inherits System.Web.UI.Page

    Dim tempfilter As String = ""
    Dim utility As New Utility(Me)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadOuts_PT()
        loadOuts_E()
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub

    Sub loadOuts_PT()
        Dim query As String = "select count(DISTINCT wono) as c,t1.AssignedTo from tbl_AssemblySectionApproval as t1 inner join tbl_user t2 on t1.AssignedTo=t2.username 
                                where SupvApprovedDate is null and AssignedTo is not null and Len(WONO)=7 and dbo.WOCompGroup(WONO)='Powertrain' group by AssignedTo"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count = 0 Then Exit Sub

        rpt_supvouts_PT.DataSource = dt
        rpt_supvouts_PT.DataBind()
    End Sub

    Sub loadOuts_E()
        Dim query As String = "select count(DISTINCT wono) as c,t1.AssignedTo from tbl_AssemblySectionApproval as t1 inner join tbl_user t2 on t1.AssignedTo=t2.username 
                                where SupvApprovedDate is null and AssignedTo is not null and Len(WONO)=7 and dbo.WOCompGroup(WONO)='Engine' group by AssignedTo"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count = 0 Then Exit Sub

        rpt_spvouts_E.DataSource = dt
        rpt_spvouts_E.DataBind()
    End Sub

    Sub filtering()
        If tWONo.Text <> String.Empty Then tempfilter = " and WONo like " & evar(tWONo.Text, 11) & tempfilter
        If ddWs.SelectedValue <> String.Empty Then tempfilter = " and ComppGroup=" & evar(ddWs.SelectedValue, 1) & tempfilter

        Select Case ddStatus.SelectedValue
            Case "0"
                tempfilter = " and AssignTemplate=0" & tempfilter
            Case "1"
                tempfilter = " and AssemblyStatus='In progress'" & tempfilter
            Case "2"
                tempfilter = " and AssemblyStatus='Waiting LH Approval'" & tempfilter
            Case "3"
                tempfilter = " and AssemblyStatus='Waiting Supv Approval'" & tempfilter
            Case "4"
                tempfilter = " and AssemblyStatus='Complete'" & tempfilter
        End Select

        Select Case ddYear.SelectedValue
            Case "1" : tempfilter = " and DocDate >= '2023-01-01'" & tempfilter
            Case "2" : tempfilter = " and DocDate <= '2023-01-01'" & tempfilter
        End Select

        If Len(tempfilter) <= 0 Then
            tempfilter = ""
        Else
            tempfilter = " where " & Right(tempfilter, Len(tempfilter) - 4)
        End If
    End Sub

    Sub load_Data()
        filtering()
        Dim dt As New DataTable
        Dim query As String = "select * from v_AssemblyGroupRev4" & tempfilter
        dt = GetDataTable(query)
        rpt_Assembly.DataSource = dt
        rpt_Assembly.DataBind()
    End Sub

    Protected Sub bSearch_Click(sender As Object, e As EventArgs)
        'ClientScript.RegisterStartupScript(Me.GetType(), "ShowOverlay", "<script>document.getElementById('overlay').style.display = 'flex';</script>")

        load_Data()

        'ClientScript.RegisterStartupScript(Me.GetType(), "HideOverlay", "<script>document.getElementById('overlay').style.display = 'none';</script>")
    End Sub

    Sub showAlert(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toastrMessage", script, True)
    End Sub

    Protected Sub bedit_Click(sender As Object, e As EventArgs)
        'showAlert("warning", "This Function Will be Active soon !")
        Dim ewono As String = CType(sender, LinkButton).CommandArgument

        Response.Redirect(urlAssemblyMea & "?wo=" & ewono)
    End Sub

    Protected Sub bupload_Click(sender As Object, e As EventArgs)
        Dim mea As String
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Dim query As String = "select * from v_AssemblyGroupRev4 where wono=" & evar(ewo, 1)
        Dim namafile As String
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            mea = dt.Rows(0)("AssemblyStatus").ToString()
            Select Case mea
                Case "Complete"
                    Dim fs = CreateObject("Scripting.FileSystemObject")
                    Dim savepath As String = JobPck + ewo + "\14\"
                    If Not System.IO.Directory.Exists(savePath) Then
                        System.IO.Directory.CreateDirectory(savePath)
                    End If
                    namafile = JobPck + ewo + "\14\" + ewo + "_14_CPQC.pdf"
                    Dim p As Process = New Process()
                    p.StartInfo.FileName = "C:\webroot\TCRC Web\Rotativa\wkhtmltopdf.exe"
                    'p.StartInfo.FileName = "C:\Rotativa\wkhtmltopdf.exe" 'local indra
                    p.StartInfo.Arguments = "http://bpnaps07:88/Views/TCRC/Reports/AssemblyMea.aspx?WO=" & ewo & " " & namafile
                    p.Start()
                    p.WaitForExit()

                    Dim query_upload As String = "exec dbo.SubmitJobAttachment '" + ewo + "',14,'" + namafile + "'," + eByName() + ""
                    executeQuery(query_upload)
                    showAlertV2("success", "Checksheet has Been Uploaded")
                Case Else
                    showAlertV2("warning", "Please Complete Digital Assembly Worksheet")
                    Exit Sub
            End Select

        End If
    End Sub

    Protected Sub bprint_Click(sender As Object, e As EventArgs)
        'showAlert("warning", "This Function Will be Active soon !")
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Dim namafile As String
        Dim namafile2 As String
        Dim fs = CreateObject("Scripting.FileSystemObject")
        Dim savePath As String = Server.MapPath("~/") & "temp/"
        If Not System.IO.Directory.Exists(savePath) Then
            System.IO.Directory.CreateDirectory(savePath)
        End If
        namafile = savePath & ewo & "_dc.pdf"
        Dim p As Process = New Process()
        p.StartInfo.FileName = "C:\webroot\TCRC Web\Rotativa\wkhtmltopdf.exe"
        'p.StartInfo.FileName = "C:\Rotativa\wkhtmltopdf.exe" 'local indra
        'p.StartInfo.Arguments = "http://bpnaps07:88/Views/TCRC/Reports/AssemblyMeaRev.aspx?WO=" & ewo & " " & namafile
        p.StartInfo.Arguments = "--margin-bottom 10mm" & " " & "http://bpnaps07:88/Views/TCRC/Reports/AssemblyMeaRev.aspx?WO=" & ewo & " --footer-html ""http://bpnaps07:88/Views/TCRC/Reports/footer.html"" --footer-right ""Page [page] of [topage]"" --footer-font-size 6 --footer-spacing -3" & " " & namafile
        p.Start()
        p.WaitForExit()

        namafile2 = Server.MapPath("~/") & "temp/" & ewo & "_dc.pdf"
        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("Content-Disposition", "inline;filename=" & namafile2)
        Response.TransmitFile(namafile2)
        Response.Flush()
        Response.End()
    End Sub

    Protected Sub rpt_Assembly_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            'Ambil Data Data Source
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            Dim emaintid As String = dataItem("MaintID").ToString()

            Dim hWONo As HtmlGenericControl = CType(e.Item.FindControl("hWONo"), HtmlGenericControl)
            Dim hWODesc As HtmlGenericControl = CType(e.Item.FindControl("hWODesc"), HtmlGenericControl)
            Dim hMea As HtmlGenericControl = CType(e.Item.FindControl("hMea"), HtmlGenericControl)
            Dim hChk As HtmlGenericControl = CType(e.Item.FindControl("hChk"), HtmlGenericControl)
            Dim hLP As HtmlGenericControl = CType(e.Item.FindControl("hLP"), HtmlGenericControl)
            Dim hULB As HtmlGenericControl = CType(e.Item.FindControl("hULB"), HtmlGenericControl)
            Dim hPPC As HtmlGenericControl = CType(e.Item.FindControl("hPPC"), HtmlGenericControl)
            Dim hVLA As HtmlGenericControl = CType(e.Item.FindControl("hVLA"), HtmlGenericControl)
            Dim hFuelInj As HtmlGenericControl = CType(e.Item.FindControl("hFuelInj"), HtmlGenericControl)
            Dim hRC As HtmlGenericControl = CType(e.Item.FindControl("hRC"), HtmlGenericControl)
            Dim hCH As HtmlGenericControl = CType(e.Item.FindControl("hCH"), HtmlGenericControl)
            'Dim hDyno As HtmlGenericControl = CType(e.Item.FindControl("hDyno"), HtmlGenericControl)
            Dim hLH As HtmlGenericControl = CType(e.Item.FindControl("hLH"), HtmlGenericControl)
            Dim hSupv As HtmlGenericControl = CType(e.Item.FindControl("hSupv"), HtmlGenericControl)

            Dim bProgress As HtmlGenericControl = CType(e.Item.FindControl("bProgress"), HtmlGenericControl)

            Dim liMea As HtmlGenericControl = CType(e.Item.FindControl("liMea"), HtmlGenericControl)
            Dim leChk As HtmlGenericControl = CType(e.Item.FindControl("leChk"), HtmlGenericControl)
            Dim liLP As HtmlGenericControl = CType(e.Item.FindControl("liLP"), HtmlGenericControl)
            Dim liULB As HtmlGenericControl = CType(e.Item.FindControl("liULB"), HtmlGenericControl)
            Dim liPPC As HtmlGenericControl = CType(e.Item.FindControl("liPPC"), HtmlGenericControl)
            Dim liVLA As HtmlGenericControl = CType(e.Item.FindControl("liVLA"), HtmlGenericControl)
            Dim liFuel As HtmlGenericControl = CType(e.Item.FindControl("liFuel"), HtmlGenericControl)
            Dim liPR As HtmlGenericControl = CType(e.Item.FindControl("liPR"), HtmlGenericControl)
            Dim liCH As HtmlGenericControl = CType(e.Item.FindControl("liCH"), HtmlGenericControl)
            'Dim liDyno As HtmlGenericControl = CType(e.Item.FindControl("liDyno"), HtmlGenericControl)
            Dim liLH As HtmlGenericControl = CType(e.Item.FindControl("liLH"), HtmlGenericControl)
            Dim liSpv As HtmlGenericControl = CType(e.Item.FindControl("liSpv"), HtmlGenericControl)

            Dim hAssemblyStat As HtmlGenericControl = CType(e.Item.FindControl("hAssemblyStat"), HtmlGenericControl)
            Dim hJobStatus As HtmlGenericControl = CType(e.Item.FindControl("hJobStatus"), HtmlGenericControl)

            Dim bupload As LinkButton = CType(e.Item.FindControl("bupload"), LinkButton)
            Dim bprint As LinkButton = CType(e.Item.FindControl("bprint"), LinkButton)
            Dim bsync As LinkButton = CType(e.Item.FindControl("bsync"), LinkButton)
            Dim bassign As LinkButton = CType(e.Item.FindControl("bassign"), LinkButton)

            hAssemblyStat.InnerHtml = "<strong>Assembly Status: </strong>" & dataItem("AssemblyStatus").ToString()
            hJobStatus.InnerHtml = "<strong>Job Status: </strong>" & dataItem("JobStatus").ToString()
            hWONo.InnerHtml = "WO." & dataItem("WONo").ToString()
            hWODesc.InnerHtml = dataItem("WODesc").ToString()
            hMea.InnerHtml = IIf(CheckDBNull(dataItem("Mea_Perc").ToString() = "-"), "-", dataItem("Mea_Perc").ToString() & "%")
            hChk.InnerHtml = IIf(CheckDBNull(dataItem("Chk_Perc").ToString() = "-"), "-", dataItem("Chk_Perc").ToString() & "%")
            hLP.InnerHtml = IIf(CheckDBNull(dataItem("LP_Perc").ToString() = "-"), "-", dataItem("LP_Perc").ToString() & "%")
            hULB.InnerHtml = IIf(CheckDBNull(dataItem("ULB_Perc").ToString() = "-"), "-", dataItem("ULB_Perc").ToString() & "%")
            hPPC.InnerHtml = IIf(CheckDBNull(dataItem("PPC_Perc").ToString() = "-"), "-", dataItem("PPC_Perc").ToString() & "%")
            hVLA.InnerHtml = IIf(CheckDBNull(dataItem("VLA_Perc").ToString() = "-"), "-", dataItem("VLA_Perc").ToString() & "%")
            hFuelInj.InnerHtml = IIf(CheckDBNull(dataItem("FTC_Perc").ToString() = "-"), "-", dataItem("FTC_Perc").ToString() & "%")
            hRC.InnerHtml = IIf(CheckDBNull(dataItem("PR_Perc").ToString() = "-"), "-", dataItem("PR_Perc").ToString() & "%")
            hCH.InnerHtml = IIf(CheckDBNull(dataItem("CH_Perc").ToString() = "-"), "-", dataItem("CH_Perc").ToString() & "%")
            'hDyno.InnerHtml = IIf(CheckDBNull(dataItem("Dyno_Perc").ToString() = "-"), "-", dataItem("Dyno_Perc").ToString() & "%")
            hLH.InnerHtml = IIf(CheckDBNull(dataItem("LHApv_Perc").ToString() = "-"), "-", dataItem("LHApv_Perc").ToString() & "%")
            hSupv.InnerHtml = IIf(CheckDBNull(dataItem("SPVApv_Perc").ToString() = "-"), "-", dataItem("SPVApv_Perc").ToString() & "%")
            'hDyno.InnerHtml = IIf(CheckDBNull(dataItem("Dyno_Perc").ToString() = "-"), "-", dataItem("Dyno_Perc").ToString() & "%")

            If dataItem("ComppGroup") = "Powertrain" Then
                liMea.Visible = True
                leChk.Visible = True
                liLP.Visible = False
                liULB.Visible = False
                liPPC.Visible = False
                liVLA.Visible = False
                liFuel.Visible = False
                liPR.Visible = False
                liCH.Visible = False
                'liDyno.Visible = False
                liLH.Visible = True
                liSpv.Visible = True
            End If

            If dataItem("ComppGroup") = "Engine" And emaintid <> "N1000" Then
                liMea.Visible = True
                leChk.Visible = True
                liLP.Visible = False
                liULB.Visible = False
                liPPC.Visible = False
                liVLA.Visible = False
                liFuel.Visible = False
                liPR.Visible = False
                liCH.Visible = False
                'liDyno.Visible = False
                liLH.Visible = True
                liSpv.Visible = True
            End If

            If dataItem("AssignTemplate") = "0" Then
                bProgress.Visible = False
            End If


            If CheckDBNull(dataItem("Mea_Perc")).ToString() = "-" Then
                bupload.Visible = False
                bprint.Visible = False
                bsync.Visible = True
            Else
                bassign.Visible = False
            End If
        End If
    End Sub

    Protected Sub bMea_Click(sender As Object, e As EventArgs)
        'Dim ewo As String = CType(sender, LinkButton).CommandArgument
        'Session("ss_assembly") = "n1"
        'Response.Redirect(urlAssemblyMea & "?wo=" & ewo)

        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Session("ss_assembly") = "n1"
        Response.Write("<script>")
        Response.Write("window.open('../../../../Views/TCRC/Workshop/AssemblyMod/AssemblyMea.aspx?wo=" & ewo & "', '_blank')")
        Response.Write("</script>")
    End Sub

    Protected Sub bChk_Click(sender As Object, e As EventArgs)
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Session("ss_assembly") = "n2"
        Response.Redirect(urlAssemblyChk & "?wo=" & ewo)
    End Sub

    Protected Sub bLP_Click(sender As Object, e As EventArgs)
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Session("ss_assembly") = "n3"
        Response.Redirect(urlAssemblyLinerProj & "?wo=" & ewo)
    End Sub

    Protected Sub bULB_Click(sender As Object, e As EventArgs)
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Session("ss_assembly") = "n4"
        Response.Redirect(urlAssemblyUpperLiner & "?wo=" & ewo)
    End Sub

    Protected Sub bPPC_Click(sender As Object, e As EventArgs)
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Session("ss_assembly") = "n5"
        Response.Redirect(urlAssemblyPinPiston & "?wo=" & ewo)
    End Sub

    Protected Sub bVLA_Click(sender As Object, e As EventArgs)
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Session("ss_assembly") = "n6"
        Response.Redirect(urlAssemblyValveLashAdj & "?wo=" & ewo)
    End Sub

    Protected Sub bFuel_Click(sender As Object, e As EventArgs)
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Session("ss_assembly") = "n7"
        Response.Redirect(urlAssemblyFuelInjTrom & "?wo=" & ewo)
    End Sub

    Protected Sub bPR_Click(sender As Object, e As EventArgs)
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Session("ss_assembly") = "n8"
        Response.Redirect(urlAssemblyPistonRec & "?wo=" & ewo)
    End Sub

    Protected Sub bCH_Click(sender As Object, e As EventArgs)
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Session("ss_assembly") = "n8"
        Response.Redirect(urlAssemblyCylinderHead & "?wo=" & ewo)
    End Sub

    Protected Sub bDyno_Click(sender As Object, e As EventArgs)
        showAlertV2("info", "Coming Soon")
    End Sub

    Protected Sub bsync_Click(sender As Object, e As EventArgs)
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Dim query As String = "exec dbo.AssemblySyncProggress " & evar(ewo, 1)
        executeQuery(query)
        showAlertV2("success", "WO." & ewo & " has been sync successfully")
        load_Data()
    End Sub

    Protected Sub bDshPT_Click(sender As Object, e As EventArgs)
        Dim esupv As String = CType(sender, LinkButton).CommandArgument
        Dim query As String = "select wono from tbl_AssemblySectionApproval as t1 
        inner join tbl_user t2 on t1.AssignedTo=t2.username where SupvApprovedDate is null and AssignedTo is not null and Len(WONO)=7 and dbo.WOCompGroup(WONO)='Powertrain' and AssignedTo=" & evar(esupv, 1)
        Dim dt, dt2 As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count = 0 Then Exit Sub
        Dim wonoString As String = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            wonoString += "'" + dt.Rows(i)("wono").ToString() + "',"
        Next
        wonoString = wonoString.TrimEnd(","c)
        Dim query2 As String = "select * from v_AssemblyGroupRev4 where wono in(" & wonoString & ")"
        dt2 = GetDataTable(query2)
        rpt_Assembly.DataSource = dt2
        rpt_Assembly.DataBind()
    End Sub

    Protected Sub bDshE_Click(sender As Object, e As EventArgs)
        Dim esupv As String = CType(sender, LinkButton).CommandArgument
        Dim query As String = "select wono from tbl_AssemblySectionApproval as t1 
        inner join tbl_user t2 on t1.AssignedTo=t2.username where SupvApprovedDate is null and AssignedTo is not null and Len(WONO)=7 and dbo.WOCompGroup(WONO)='Engine' and AssignedTo=" & evar(esupv, 1)
        Dim dt, dt2 As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count = 0 Then Exit Sub
        Dim wonoString As String = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            wonoString += "'" + dt.Rows(i)("wono").ToString() + "',"
        Next
        wonoString = wonoString.TrimEnd(","c)
        Dim query2 As String = "select * from v_AssemblyGroupRev4 where wono in(" & wonoString & ")"
        dt2 = GetDataTable(query2)
        rpt_Assembly.DataSource = dt2
        rpt_Assembly.DataBind()
    End Sub

    Protected Sub bassign_Click(sender As Object, e As EventArgs)
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Dim query As String = "select *,(select UnitDescID from tbl_unitdesc where unitdesc=UnitDescription) as UnitID from v_Intjobdetailrev3 where wono=" & evar(ewo, 1) & ""
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count = 0 Then
            showAlertV2("warning", "WO Number Not Found on System, Please contact Admin")
            Exit Sub
        End If

        Dim modWONO As TextBox = DirectCast(AssemblyAssign.FindControl("modWONO"), TextBox)
        Dim modWODesc As TextBox = DirectCast(AssemblyAssign.FindControl("modWODesc"), TextBox)
        Dim modWOUnitDesc As TextBox = DirectCast(AssemblyAssign.FindControl("modWOUnitDesc"), TextBox)
        Dim modMaintID As TextBox = DirectCast(AssemblyAssign.FindControl("modMaintID"), TextBox)
        Dim modCompName As TextBox = DirectCast(AssemblyAssign.FindControl("modCompName"), TextBox)
        Dim modDDTemplate As DropDownList = DirectCast(AssemblyAssign.FindControl("modDDTemplate"), DropDownList)

        Dim eMaintID As String = Left(CheckDBNull(dt.Rows(0)("MaintType").ToString()), 5)
        Dim eunitID As String = CheckDBNull(dt.Rows(0)("UnitID").ToString())

        modWONO.Text = CheckDBNull(dt.Rows(0)("WONO").ToString())
        modWODesc.Text = dt.Rows(0)("WODesc").ToString()
        modWOUnitDesc.Text = dt.Rows(0)("UnitDescription").ToString()
        modMaintID.Text = eMaintID
        modCompName.Text = dt.Rows(0)("ComponentGroup").ToString()

        Dim q_template As String = "select IDTemplateAssemblyGroup,TemplateName from dbo.GetAssemblyTemplate(" & eunitID & "," & evar(eMaintID, 1) & ")"
        BindDataDropDown(modDDTemplate, q_template, "TemplateName", "IDTemplateAssemblyGroup")
        utility.ModalV2("MainContent_AssemblyAssign_Panel1")
    End Sub
End Class