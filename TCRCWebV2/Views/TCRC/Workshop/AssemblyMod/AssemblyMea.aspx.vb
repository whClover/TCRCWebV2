Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString
Imports DocumentFormat.OpenXml.Spreadsheet

Public Class AssemblyMea
    Inherits System.Web.UI.Page

    Dim ewo As String
    Dim utility As New Utility(Me)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ss_userid") = "" Then
            Response.Redirect(urlTCRCLogin)
        End If

        ewo = Request.QueryString("wo")
        load_data()
    End Sub

    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If Session("ScrollPosition") IsNot Nothing Then
            Dim scrollPosition As Integer = Integer.Parse(Session("ScrollPosition"))
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "setScrollPosition", "setTimeout(function() { window.scrollTo(0, " & scrollPosition & "); }, 100);", True)
        End If
    End Sub

    Sub load_data()
        Dim dt2 As New DataTable
        Dim esection As String = String.Empty
        Dim query2 As String = "select Distinct top 1 AssemblySection, case when('../' + dbo.RemapPicW(PicturePath)) is null then '' else ('../' + dbo.RemapPicW(PicturePath)) end as PicturePathGroup " _
                                & "from v_AssemblySectionPicture where wono=" & evar(ewo, 1)
        dt2 = GetDataTable(query2)
        If dt2.Rows.Count > 0 Then
            esection = dt2.Rows(0)("AssemblySection")
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
        Dim script As String
        script = "toastr[""" & type & """](""" & msg & """);"
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
End Class