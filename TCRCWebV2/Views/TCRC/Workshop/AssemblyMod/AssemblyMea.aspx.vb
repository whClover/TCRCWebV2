Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString
Imports DocumentFormat.OpenXml.Spreadsheet
Imports Org.BouncyCastle.Tsp
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class AssemblyMea
    Inherits System.Web.UI.Page

    Dim ewo As String
    Dim utility As New Utility(Me)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ss_userid") = "" Then
            Response.Redirect(urlTCRCLogin)
        End If

        ewo = Request.QueryString("wo")
        Session("ss_assembly") = "n1"
        If IsPostBack = False Then
            load_head()
            load_data()
            Bindingsection()
            load_supvSection()
        End If
    End Sub

    Sub load_supvSection()
        Dim query As String = "select * from v_AssemblySectionApproval where wono=" & evar(ewo, 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            gv_supv.DataSource = dt
            gv_supv.DataBind()
        End If
    End Sub

    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If Session("ScrollPosition") IsNot Nothing Then
            Dim scrollPosition As Integer = Integer.Parse(Session("ScrollPosition"))
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "setScrollPosition", "setTimeout(function() { window.scrollTo(0, " & scrollPosition & "); }, 100);", True)
        End If

        getProgress(1)
        getProgress(2)
    End Sub

    Sub load_head()
        lwono.InnerText = "WO." & ewo

        Dim query As String = "select WODesc from v_IntJobDetailRev3 where wono=" & evar(ewo, 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            lwodesc.InnerText = dt.Rows(0)("WODesc")
        End If
    End Sub

    Sub Bindingsection()
        Dim query As String = "select AssemblySection,(AssemblySection + ' (Progress: ' + Try_CAST(Perc as varchar) + '%,LH: ' + Try_Cast(PercApproval as varchar) + '%)') as AssemblyDesc, 
                    Perc, PercApproval,SupvApprovedBy from v_AssemblySectionApproval where wono=" & evar(ewo, 1) & " order by AssemblySection"
        BindDataDropDown(ddsection, query, "AssemblyDesc", "AssemblySection")
    End Sub

    Sub load_data()
        Dim dt2 As New DataTable
        Dim esection As String = String.Empty
        Dim query2 As String = "select Distinct top 1 AssemblySection, case when('../../../../' + dbo.RemapPicW(PicturePath)) is null then '' else ('../../../../' + dbo.RemapPicW(PicturePath)) end as PicturePathGroup " _
                                & "from v_AssemblySectionPicture where wono=" & evar(ewo, 1)
        dt2 = GetDataTable(query2)
        If dt2.Rows.Count > 0 Then
            esection = dt2.Rows(0)("AssemblySection")
            ddsection.Text = esection
            lsection.InnerText = esection
            imgGp.Src = dt2.Rows(0)("PicturePathGroup")
        End If

        Dim dt As New DataTable
        Dim ecol As String = "IDAssemblyInput,[Sequence],Replace(AssemblyDesc,CHAR(13)+CHAR(10),'<br />') as AssemblyDesc,case when UnitType=1 then 'Metric' else 'US' end as UnitTypeDesc,ValType,Unit,IDAssemblyInput,UnitType,
                            isnull((isnull(convert(varchar(10),Spec),'') + ' ± ' + isnull(convert(varchar(10),Tolerance),'') + ' ' + convert(varchar(10), Unit)),'-') as SpecFull,
                            case when AssemblyVal is null then '-' else isnull((AssemblyVal + ' ' + Unit),AssemblyVal) end as AssemblyVal,isnull(ModBy,'-') as ModBy,isnull(convert(varchar, ModDate,103),'-') as ModDate,isnull(ApprovedBy,'-') as ApprovedBy,InstructionType"
        Dim query As String = "select " & ecol & " from v_AssemblyDetailInputRev2 where wono=" & evar(ewo, 1) & " and AssemblySection=" & evar(esection, 1) & "
                                order by AssemblySection, dbo.SequenceNum(Sequence),dbo.SequenceAlpha(Sequence),dbo.getsortval(Sequence,30,10)"
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            rpt_mea.DataSource = dt
            rpt_mea.DataBind()
        End If
    End Sub

    Protected Sub rpt_mea_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            'Buat ngambil datanya...
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            'Deklarasi Objectnya...
            Dim pSeq As HtmlGenericControl = CType(e.Item.FindControl("pSeq"), HtmlGenericControl)
            Dim pDesc As HtmlGenericControl = CType(e.Item.FindControl("pDesc"), HtmlGenericControl)
            Dim pSpec As HtmlGenericControl = CType(e.Item.FindControl("pSpec"), HtmlGenericControl)
            Dim pMeaType As HtmlGenericControl = CType(e.Item.FindControl("pMeaType"), HtmlGenericControl)
            Dim pVal As HtmlGenericControl = CType(e.Item.FindControl("pVal"), HtmlGenericControl)
            Dim pModBy As HtmlGenericControl = CType(e.Item.FindControl("pModBy"), HtmlGenericControl)
            Dim pModDate As HtmlGenericControl = CType(e.Item.FindControl("pModDate"), HtmlGenericControl)
            Dim pApvBy As HtmlGenericControl = CType(e.Item.FindControl("pApvBy"), HtmlGenericControl)

            'UI Object
            Dim pBorder As HtmlGenericControl = CType(e.Item.FindControl("pBorder"), HtmlGenericControl)
            Dim pStatus As HtmlGenericControl = CType(e.Item.FindControl("pStatus"), HtmlGenericControl)
            Dim pComp As HtmlGenericControl = CType(e.Item.FindControl("pComp"), HtmlGenericControl)
            Dim bLH As Button = CType(e.Item.FindControl("bLH"), Button)

            'Input Data to Object
            pSeq.InnerText = "Sequence: " & dataItem("Sequence").ToString()
            pDesc.InnerHtml = dataItem("AssemblyDesc").ToString()
            pSpec.InnerText = dataItem("SpecFull").ToString()
            pMeaType.InnerText = dataItem("UnitTypeDesc").ToString()
            pVal.InnerText = dataItem("AssemblyVal").ToString()
            pModBy.InnerText = dataItem("ModBy").ToString()
            pModDate.InnerText = dataItem("ModDate").ToString()
            pApvBy.InnerText = dataItem("ApprovedBy").ToString()

            'costumize UI
            Select Case dataItem("AssemblyVal").ToString()
                Case "-"
                    pBorder.Attributes("class") = "card border border-secondary"
                    pStatus.Attributes("class") = "badge rounded-pill bg-warning just"
                    pStatus.InnerText = "NC"
                    pComp.Style("display") = "none"
                Case Else
                    pBorder.Attributes("class") = "card border border-primary"
                    pStatus.Attributes("class") = "badge rounded-pill bg-success just"
                    pStatus.InnerText = "C"
                    pComp.Style("display") = "block"
            End Select

            If dataItem("AssemblyVal") = "-" And dataItem("ApprovedBy") = "-" Then
                bLH.Visible = False
            ElseIf dataItem("AssemblyVal") <> "-" And dataItem("ApprovedBy") = "-" Then
                bLH.Visible = True
            Else
                bLH.Visible = False
            End If
        End If
    End Sub

    Protected Sub bChangeSpec_Click(sender As Object, e As EventArgs)
        Dim arr As String() = CType(sender, LinkButton).CommandArgument.Split(",")
        Dim eidinput As String = arr(0)
        Dim eunittype As String = arr(1)

        If eunittype = "1" Then
            eunittype = 2
        ElseIf eunittype = "2" Then
            eunittype = 1
        End If

        Dim query As String = "update tbl_AssemblyInput set UnitType=" & eunittype & " where IDAssemblyInput=" & eidinput
        executeQuery(query)
        getcurrentScrollPos()
    End Sub

    Sub getcurrentScrollPos()
        Dim currentScrollPosition As Integer = Integer.Parse(ScrollPosition.Value)
        Session("ScrollPosition") = currentScrollPosition
    End Sub

    Sub showAlert(ByVal type As String, ByVal msg As String)
        Dim optsc As String = "toastr.options = {
          ""closeButton"": false,
          ""debug"": false,
          ""newestOnTop"": false,
          ""progressBar"": false,
          ""positionClass"": ""toast-top-center"",
          ""preventDuplicates"": false,
          ""onclick"": null,
          ""showDuration"": ""300"",
          ""hideDuration"": ""1000"",
          ""timeOut"": ""5000"",
          ""extendedTimeOut"": ""1000"",
          ""showEasing"": ""swing"",
          ""hideEasing"": ""linear"",
          ""showMethod"": ""fadeIn"",
          ""hideMethod"": ""fadeOut""
        };"

        Dim script As String
        script = optsc & "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toastrMessage", script, True)
    End Sub

    Protected Sub bedit_Click(sender As Object, e As EventArgs)
        Dim eid As String = CType(sender, LinkButton).CommandArgument

        Dim dt As New DataTable
        Dim ecol As String = "IDAssemblyInput,[Sequence],Replace(AssemblyDesc,CHAR(13)+CHAR(10),'<br />') as AssemblyDesc,case when UnitType=1 then 'Metric' else 'US' end as UnitTypeDesc,ValType,Unit,IDAssemblyInput,UnitType,
                            isnull((isnull(convert(varchar(10),Spec),'') + ' ± ' + isnull(convert(varchar(10),Tolerance),'') + ' ' + convert(varchar(10), Unit)),'-') as SpecFull,
                            case when AssemblyVal is null then '-' else isnull((AssemblyVal + ' ' + Unit),AssemblyVal) end as AssemblyVal,isnull(ModBy,'-') as ModBy,isnull(convert(varchar, ModDate,103),'-') as ModDate,isnull(ApprovedBy,'-') as ApprovedBy,InstructionType"
        Dim query As String = "select " & ecol & " from v_AssemblyDetailInputRev2 where IDAssemblyInput=" & eid
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            Dim eid_obj As HiddenField = DirectCast(AssemblyMea.FindControl("eid"), HiddenField)
            Dim evaltype As HiddenField = DirectCast(AssemblyMea.FindControl("evaltype"), HiddenField)
            Dim lActitivty As Label = DirectCast(AssemblyMea.FindControl("lActitivty"), Label)
            Dim lMeaType As Label = DirectCast(AssemblyMea.FindControl("lMeaType"), Label)
            Dim lSpec As Label = DirectCast(AssemblyMea.FindControl("lSpec"), Label)
            Dim lunit As HtmlGenericControl = DirectCast(AssemblyMea.FindControl("lunit"), HtmlGenericControl)
            Dim lvalue As Label = DirectCast(AssemblyMea.FindControl("lvalue"), Label)

            Dim mea1 As HtmlGenericControl = DirectCast(AssemblyMea.FindControl("mea1"), HtmlGenericControl)
            Dim mea2 As HtmlGenericControl = DirectCast(AssemblyMea.FindControl("mea2"), HtmlGenericControl)
            Dim mea3 As HtmlGenericControl = DirectCast(AssemblyMea.FindControl("mea3"), HtmlGenericControl)

            Dim bsave As LinkButton = DirectCast(AssemblyMea.FindControl("bsave"), LinkButton)

            eid_obj.Value = dt.Rows(0)("IDAssemblyInput")
            evaltype.Value = dt.Rows(0)("ValType")
            lActitivty.Text = dt.Rows(0)("AssemblyDesc")
            lMeaType.Text = dt.Rows(0)("UnitTypeDesc")
            lSpec.Text = dt.Rows(0)("SpecFull")
            lunit.InnerText = CheckDBNull(dt.Rows(0)("Unit"))
            lvalue.Text = dt.Rows(0)("AssemblyVal")

            Select Case dt.Rows(0)("ValType")
                Case 1
                    mea1.Style("display") = "block"
                    mea2.Style("display") = "none"
                    mea3.Style("display") = "none"
                Case 2
                    mea1.Style("display") = "none"
                    mea2.Style("display") = "block"
                    mea3.Style("display") = "none"
                Case 3
                    mea1.Style("display") = "none"
                    mea2.Style("display") = "none"
                    mea3.Style("display") = "block"
            End Select

            Select Case CheckDBNull(dt.Rows(0)("ApprovedBy"))
                Case "-"
                    lvalue.Style("display") = "none"
                    bsave.Visible = True
                Case Else
                    mea1.Style("display") = "none"
                    mea2.Style("display") = "none"
                    mea3.Style("display") = "none"
                    lvalue.Style("display") = "block"
                    bsave.Visible = False
            End Select
        End If

        'open modal and get position
        utility.ModalV2("MainContent_AssemblyMea_Panel1")
        getcurrentScrollPos()
    End Sub

    Protected Sub ddsection_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim esection As String = ddsection.Text
        lsection.InnerText = esection
        If esection = String.Empty Then
            Exit Sub
        End If
        Session("ScrollPosition") = Integer.Parse("0")

        load_section(esection)
    End Sub

    Sub load_section(ByVal esection As String)
        If esection = String.Empty Then
            Exit Sub
        End If

        'load picture group
        Dim dt As New DataTable
        Dim query As String = "select case when('../../../../' + dbo.RemapPicW(PicturePath)) is null then '' else ('../../../../' + dbo.RemapPicW(PicturePath)) end as PicturePathGroup
        from v_AssemblySectionPicture where wono=" & evar(ewo, 1) & " and AssemblySection=" & evar(esection, 1)
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            imgGp.Src = dt.Rows(0)("PicturePathGroup")
        End If

        'load section data
        Dim dt2 As New DataTable
        Dim ecol As String = "IDAssemblyInput,[Sequence],Replace(AssemblyDesc,CHAR(13)+CHAR(10),'<br />') as AssemblyDesc,case when UnitType=1 then 'Metric' else 'US' end as UnitTypeDesc,ValType,Unit,IDAssemblyInput,UnitType,
                            isnull((isnull(convert(varchar(10),Spec),'') + ' ± ' + isnull(convert(varchar(10),Tolerance),'') + ' ' + convert(varchar(10), Unit)),'-') as SpecFull,
                            case when AssemblyVal is null then '-' else isnull((AssemblyVal + ' ' + Unit),AssemblyVal) end as AssemblyVal,isnull(ModBy,'-') as ModBy,isnull(convert(varchar, ModDate,103),'-') as ModDate,isnull(ApprovedBy,'-') as ApprovedBy,InstructionType"
        Dim query2 As String = "select " & ecol & " from v_AssemblyDetailInputRev2 where wono=" & evar(ewo, 1) & " and AssemblySection=" & evar(esection, 1) & "
                                order by AssemblySection, dbo.SequenceNum(Sequence),dbo.SequenceAlpha(Sequence),dbo.getsortval(Sequence,30,10)"
        dt2 = GetDataTable(query2)
        If dt2.Rows.Count > 0 Then
            rpt_mea.DataSource = dt2
            rpt_mea.DataBind()
        End If

        getProgress(1)
        getProgress(2)
    End Sub

    Sub getProgress(ByVal type As Integer)
        Dim query As String = String.Empty
        Dim dt As New DataTable

        If type = 1 Then
            query = "select " _
                + "AssemblySection, " _
                + "dbo.PercentCalc(SUM(CASE WHEN AssemblyVal IS NOT NULL THEN 1 ELSE 0 END), COUNT(IDAssemblyInput)) as Perc " _
                + "from v_AssemblyDetailInputRev2 Group By WONO, AssemblySection " _
                + "Having wono=" & evar(ewo, 1) & " and AssemblySection=" & evar(ddsection.Text, 1)

            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                pSectionProg.Style("width") = dt.Rows(0)("Perc") & "%"
                lSectionProg.InnerText = "Section Progress (" & dt.Rows(0)("Perc") & "%)"
            End If
        ElseIf type = 2 Then
            query = "select " _
                + "AssemblySection, " _
                + "dbo.PercentCalc(SUM(CASE WHEN ApprovedBy IS NOT NULL THEN 1 ELSE 0 END), COUNT(IDAssemblyInput)) as Perc " _
                + "from v_AssemblyDetailInputRev2 Group By WONO, AssemblySection " _
                + "Having wono=" & evar(ewo, 1) & " and AssemblySection=" & evar(ddsection.Text, 1)

            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                pSectionLH.Style("width") = dt.Rows(0)("Perc") & "%"
                lSectionLH.InnerText = "Leading Hand Approval Progress (" & dt.Rows(0)("Perc") & "%)"
            End If
        End If
    End Sub

    Protected Sub bLH_Click(sender As Object, e As EventArgs)
        Dim eid As String = CType(sender, LinkButton).CommandArgument
        Dim query As String = "update tbl_AssemblyInput set ApprovedBy=" & eByName() & " where IDAssemblyInput=" & eid
        executeQuery(query)
        showAlert("success", "ID: " & eid & " has been approved")
    End Sub

    Protected Sub bgallery_Click(sender As Object, e As EventArgs)
        Dim hwono As HiddenField = DirectCast(AssemblyGallery.FindControl("hwono"), HiddenField)
        hwono.Value = ewo

        utility.ModalV2("MainContent_AssemblyGallery_Panel1")
    End Sub

    Protected Sub bswp_Click(sender As Object, e As EventArgs)
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub

        Dim eunitid As String = String.Empty
        Dim query As String = "select UnitDescription,Left(MaintType,5) as MaintType from v_IntJobDetailRev3 where wono=" & evar(ewo, 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            Dim eunitdesc As String = dt.Rows(0)("UnitDescription")
            Dim emainttype As String = dt.Rows(0)("MaintType")

            Dim query2 As String = "select unitDescID from tbl_UnitDesc where UnitDesc=" & evar(eunitdesc, 1)
            Dim dt2 As DataTable
            dt2 = GetDataTable(query2)
            If dt2.Rows.Count > 0 Then
                eunitid = dt2.Rows(0)("unitDescID")
            Else
                showAlert("warning", "Module SWP/WI Not Found !, Please Contact Team QC")
                Exit Sub
            End If

            Dim elinkfile As String
            Dim query3 As String = "select LinkFile from tbl_GeneralFiles where UnitID=" & eunitid & " and ModuleID=2 and MaintType=" & evar(emainttype, 1)
            Dim dt3 As DataTable
            dt3 = GetDataTable(query3)
            If dt3.Rows.Count > 0 Then
                elinkfile = dt3.Rows(0)("LinkFile")
            Else
                Exit Sub
            End If
            Dim filePath As String = elinkfile

            Response.Clear()
            Response.ContentType = "application/pdf"
            Response.AddHeader("Content-Disposition", "inline; filename=" & elinkfile)
            Response.WriteFile(filePath)
            Response.Flush()
            Response.End()

            Dim script As String = "window.open('" & filePath & "', '_blank');"
            ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "OpenPDF", script, True)
        End If
    End Sub

    Protected Sub bprint_Click(sender As Object, e As EventArgs)
        Dim ewo As String = Request.QueryString("wo")
        If ewo = String.Empty Then Exit Sub

        Dim query As String = "select * from v_AssemblySectionApproval where wono=" & evar(ewo, 1) & " and Perc=100 and PercApproval=100 and SupvApprovedBy is not null"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If Not dt.Rows.Count > 0 Then
            showAlert("warning", "Please Complete Assembly Checksheet Before Printing Process !")
            Exit Sub
        End If

        Dim fs = CreateObject("Scripting.FileSystemObject")
        Dim savepath As String = Server.MapPath("~/temp/")

        If Not System.IO.Directory.Exists(savepath) Then
            System.IO.Directory.CreateDirectory(savepath)
        End If

        Dim namafile As String = savepath & "AssemblyMea_" & ewo & ".pdf"
        Dim p As Process = New Process()
        p.StartInfo.FileName = "C:\webroot\TCRC Web\Rotativa\wkhtmltopdf.exe"
        'p.StartInfo.FileName = "C:\Rotativa\wkhtmltopdf.exe"
        p.StartInfo.Arguments = "http://bpnaps07:9191/Views/TCRC/Reports/AssemblyMea.aspx?wo=" & ewo & " " & namafile & ""
        p.Start()
        p.WaitForExit()

        ' System.Threading.Thread.Sleep(5000)

        Dim filepath As String = namafile

        'Response.Redirect(RptAssemblyMea & "?wo=" & ewo)
        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("Content-Disposition", "inline; filename=" & filepath)
        Response.WriteFile(filepath)
        Response.Flush()
        Response.End()

        Dim script As String = "window.open('" & filepath & "', '_blank');"
        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "OpenPDF", script, True)

    End Sub

    Protected Sub gv_supv_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dataItem As DataRowView = CType(e.Row.DataItem, DataRowView)
            Dim bapv As LinkButton = CType(e.Row.FindControl("bApv"), LinkButton)
            Dim lApv As Label = CType(e.Row.FindControl("lApv"), Label)
            Dim ddSupv As DropDownList = CType(e.Row.FindControl("ddSupv"), DropDownList)

            Dim asectionValue As String = DataBinder.Eval(e.Row.DataItem, "AssemblySection").ToString()
            ddSupv.Attributes("asection") = asectionValue
            bapv.Attributes("asection") = asectionValue

            Dim esupvby As String = CheckDBNull(dataItem("SupvApprovedBy"))

            Dim qry_supv As String = "select * from vw_UserPrivilegesEmailNotif where EmailTypeDesc='Supervisory' and EmailTypeID=43 and ActiveStatus=-1 order by FullName"
            BindDataDropDown(ddSupv, qry_supv, "FullName", "UserName")

            lApv.Text = esupvby
            If esupvby = "-" Then
                lApv.Visible = False
                bapv.Visible = True
            Else
                ddSupv.SelectedValue = esupvby
                ddSupv.Enabled = False
                bapv.Visible = False
                lApv.Visible = True
            End If
        End If
    End Sub

    Protected Sub ddSupv_SelectedIndexChanged(sender As Object, e As EventArgs)

        If CheckGroup(44) = False Then
            showAlert("warning", "You dont have access supervisor approval")
            Exit Sub
        End If

        Dim ddl As DropDownList = DirectCast(sender, DropDownList)

        Dim esection As String = ddl.Attributes("asection")
        Dim query As String = "update tbl_AssemblySectionApproval set AssignedTo=" & eByName() & "
                AssignedDate=GetDate() where AssemblySection=" & evar(esection, 1) & " and wono=" & evar(ewo, 1)
        executeQuery(query)
        load_supvSection()
    End Sub

    Protected Sub bApv_Click(sender As Object, e As EventArgs)

        If CheckGroup(43) = False Then
            showAlert("warning", "You dont have access supervisor approval")
            Exit Sub
        End If

        Dim bapv As LinkButton = DirectCast(sender, LinkButton)

        Dim esection As String = bapv.Attributes("asection")
        Dim query As String = "update tbl_AssemblySectionApproval set SupvApprovedBy=" & eByName() & "
                SupvApprovedDate=GetDate() where AssemblySection=" & evar(esection, 1) & " and wono=" & evar(ewo, 1)
        executeQuery(query)
        load_supvSection()
    End Sub

    Protected Sub bBack_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlAssemblyList)
    End Sub
End Class