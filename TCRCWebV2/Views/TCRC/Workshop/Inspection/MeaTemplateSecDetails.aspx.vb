Imports System.Security.Cryptography
Imports DocumentFormat.OpenXml.EMMA
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaTemplateSecDetails
    Inherits System.Web.UI.Page
    Dim utility As New Utility(Me)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ss_userid") = "" Then
            Response.Redirect(urlTCRCLogin)
        End If

        If IsPostBack = False Then
            bindingHeader()
            GenerateSubSection()
            GeneratePicture()
        End If
    End Sub

    Public Sub BindingData()
        bindingHeader()
        GenerateSubSection()
        GeneratePicture()
    End Sub

    Sub refreshModal()
        Dim Action As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("Action"), HiddenField)
        Dim TypeID As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("TypeID"), HiddenField)
        Dim IDGroup As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tIDGroup"), TextBox)
        Dim IDDetail As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tIDDetail"), TextBox)
        Dim lIDDetail As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lIDDetail"), HtmlGenericControl)
        Dim Sequence As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSeq"), TextBox)
        Dim Section As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSec"), TextBox)
        Dim SubSection As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSubSec"), TextBox)
        Dim curSubSection As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tcurSubSec"), HiddenField)
        Dim ItemDesc As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tItem"), TextBox)
        Dim lItemDesc As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lItem"), HtmlGenericControl)
        Dim RowCount As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tRowCount"), TextBox)
        Dim lRowCount As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lRowCount"), HtmlGenericControl)
        Dim ValType As DropDownList = DirectCast(MeaTemplateSecDetailsEdit.FindControl("ddValType"), DropDownList)
        Dim lValType As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lddValType"), HtmlGenericControl)
        Dim CostumeColumn As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tCostCol"), TextBox)
        Dim lCostumeColumn As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lCostCol"), HtmlGenericControl)

        Action.Value = String.Empty
        TypeID.Value = String.Empty
        IDGroup.Text = String.Empty
        IDDetail.Text = String.Empty
        Sequence.Text = String.Empty
        Section.Text = String.Empty
        SubSection.Text = String.Empty
        curSubSection.Value = String.Empty
        ItemDesc.Text = String.Empty
        RowCount.Text = String.Empty
        ValType.SelectedValue = ""
        CostumeColumn.Text = String.Empty
    End Sub

#Region "Get Data"
    Sub bindingHeader()
        Dim eid As String = Request.QueryString("id")
        Dim dt As New DataTable
        dt = GetDataTable("select * from v_InspTemplateList where IDGroup=" & eid)

        tID.Text = dt.Rows(0)(0)
        tUnitDesc.Text = dt.Rows(0)(1)
        tComp.Text = dt.Rows(0)(2)
        tDesc.Text = dt.Rows(0)(3)
        tRegBy.Text = dt.Rows(0)(4)
        tRegDate.Text = dt.Rows(0)(5)
    End Sub

    Sub GenerateSubSection()
        Dim eid As String = Request.QueryString("id")
        Dim esection As String = Request.QueryString("section")
        TitleSection.InnerText = "Section: " & esection

        Dim query As String = "select distinct(SubSectionName),SeqSubSection,SectionName from v_InspDetailRev where IDGroup=" & eid & " and SectionName=" & evar(esection, 1) & " order by SeqSubSection"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        rpt_SubSection.DataSource = dt
        rpt_SubSection.DataBind()
    End Sub

    Public Sub GeneratePicture()
        Dim eid As String = Request.QueryString("id")
        Dim esec As String = Request.QueryString("section")
        Dim eimg As String = String.Empty

        Dim query As String = "select top 1 PictureSection from v_InspDetailRev where IDGroup=" & eid & " and SectionName=" & evar(esec, 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            eimg = CheckDBNull(dt.Rows(0)(0))
            imgSection.Src = eimg
        Else
            imgSection.Src = "~/assets/images/NoPicture.png"
        End If
    End Sub

    Protected Sub rpt_SubSection_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Dim eid As String = Request.QueryString("id")
        Dim esection As String = Request.QueryString("section")
        Dim esubsection As String = DataBinder.Eval(e.Item.DataItem, "SubSectionName").ToString
        Dim ecolumn As String = "ItemDesc,LoopCount, SectionName, Case when ValType=1 then 'Checked' 
                                when ValType=2 then 'Number' 
                                when ValType=3 then 'Free Text' 
                                when ValType=4 then 'Reuse/Replace' end as ValType,Active,IDDetail,SeqItem,
                                RegisterBy,convert(varchar, RegisterDate, 103) as RegisterDate"

        Dim query As String = "select " & ecolumn & " from v_InspDetailRev where IDGroup=" & eid & " and SectionName=" & evar(esection, 1) & " and SubSectionName=" & evar(esubsection, 1) & "
                            and ValType not in(0) order by SeqItem"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        Dim gv_item As GridView = e.Item.FindControl("gv_item")
        gv_item.DataSource = dt
        gv_item.DataBind()

        Dim query2 As String = "select ItemDesc from v_InspDetailRev where IDGroup=" & eid & " and SectionName=" & evar(esection, 1) & " and SubSectionName=" & evar(esubsection, 1) & " and ValType=0"
        Dim dt2 As New DataTable
        dt2 = GetDataTable(query2)

        If dt2.Rows.Count > 0 Then
            Dim dPassive As HtmlGenericControl = e.Item.FindControl("dPassive")
            dPassive.InnerHtml = CheckDBNull(dt2.Rows(0)(0))
        End If
    End Sub
#End Region

#Region "Action Bar"
    Protected Sub bAdd_Click(sender As Object, e As EventArgs)
        refreshModal()
        Dim eid As String = Request.QueryString("id")
        Dim esec As String = Request.QueryString("section")

        Dim Action As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("Action"), HiddenField)
        Dim TypeID As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("TypeID"), HiddenField)
        Dim IDGroup As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tIDGroup"), TextBox)
        Dim IDDetail As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tIDDetail"), TextBox)
        Dim lIDDetail As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lIDDetail"), HtmlGenericControl)
        Dim Sequence As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSeq"), TextBox)
        Dim Section As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSec"), TextBox)
        Dim SubSection As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSubSec"), TextBox)
        'Dim curSubSection As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tcurSubSec"), HiddenField)
        Dim ItemDesc As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tItem"), TextBox)
        Dim lItemDesc As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lItem"), HtmlGenericControl)
        Dim RowCount As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tRowCount"), TextBox)
        Dim lRowCount As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lRowCount"), HtmlGenericControl)
        Dim ValType As DropDownList = DirectCast(MeaTemplateSecDetailsEdit.FindControl("ddValType"), DropDownList)
        Dim lValType As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lddValType"), HtmlGenericControl)
        Dim CostumeColumn As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tCostCol"), TextBox)
        Dim lCostumeColumn As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lCostCol"), HtmlGenericControl)

        'just for add
        Action.Value = "Add"
        IDDetail.Visible = False
        lIDDetail.Visible = False
        ItemDesc.Visible = False
        lItemDesc.Visible = False
        RowCount.Visible = False
        lRowCount.Visible = False
        ValType.Visible = False
        lValType.Visible = False
        CostumeColumn.Visible = False
        lCostumeColumn.Visible = False

        IDGroup.Text = eid
        Section.Text = esec

        'curSubSection.Value = esec
        SubSection.Text = String.Empty
        Sequence.Text = String.Empty
        SubSection.ReadOnly = False

        utility.ModalV2("MainContent_MeaTemplateSecDetailsEdit_panel1")
    End Sub

    Protected Sub bAddRef_Click(sender As Object, e As EventArgs)
        Dim eid As String = Request.QueryString("id")
        Dim esec As String = Request.QueryString("section")

        Dim Action As HiddenField = DirectCast(MeaInspTemplateRef.FindControl("hAction"), HiddenField)
        Dim Section As TextBox = DirectCast(MeaInspTemplateRef.FindControl("tSec"), TextBox)
        Dim Sequence As TextBox = DirectCast(MeaInspTemplateRef.FindControl("tSeq"), TextBox)
        Dim summernote As HtmlTextArea = DirectCast(MeaInspTemplateRef.FindControl("summernote"), HtmlTextArea)

        'reset
        Action.Value = String.Empty
        Sequence.Text = String.Empty

        'set value
        summernote.Value = "" '--set value summmer note JGN DIHAPUS LAGI NDRA...
        Action.Value = "Add"
        Section.Text = esec

        utility.ModalV2("MainContent_MeaInspTemplateRef_panel1")
    End Sub

    Protected Sub bUploadPict_Click(sender As Object, e As EventArgs)
        utility.ModalV2("MainContent_MeaTemplatePicUpload_panel1")
    End Sub

    Protected Sub bBack_Click(sender As Object, e As EventArgs)
        Dim eid As String = Request.QueryString("id")
        Response.Redirect(urlMeasureTemplateSec & "?id=" & eid)
    End Sub
#End Region

#Region "SubSection Edit/Remove"
    Protected Sub bAddItem_Click(sender As Object, e As EventArgs)
        refreshModal()
        Dim linkbutton As LinkButton = CType(sender, LinkButton)
        Dim esubsection As String = linkbutton.Attributes("subsection")
        Dim eseqsubsection As String = linkbutton.Attributes("seqsubsection")

        Dim eid As String = Request.QueryString("id")
        Dim esec As String = Request.QueryString("section")

        Dim Action As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("Action"), HiddenField)
        Dim TypeID As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("TypeID"), HiddenField)
        Dim IDGroup As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tIDGroup"), TextBox)
        Dim IDDetail As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tIDDetail"), TextBox)
        Dim lIDDetail As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lIDDetail"), HtmlGenericControl)
        Dim Sequence As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSeq"), TextBox)
        Dim Section As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSec"), TextBox)
        Dim SubSection As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSubSec"), TextBox)
        Dim curSubSection As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tcurSubSec"), HiddenField)
        Dim ItemDesc As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tItem"), TextBox)
        Dim lItemDesc As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lItem"), HtmlGenericControl)
        Dim RowCount As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tRowCount"), TextBox)
        Dim lRowCount As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lRowCount"), HtmlGenericControl)
        Dim ValType As DropDownList = DirectCast(MeaTemplateSecDetailsEdit.FindControl("ddValType"), DropDownList)
        Dim lValType As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lddValType"), HtmlGenericControl)
        Dim CostumeColumn As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tCostCol"), TextBox)
        Dim lCostumeColumn As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lCostCol"), HtmlGenericControl)

        Action.Value = "Add"

        IDDetail.Visible = True
        lIDDetail.Visible = True
        ItemDesc.Visible = True
        lItemDesc.Visible = True
        RowCount.Visible = True
        lRowCount.Visible = True
        ValType.Visible = True
        lValType.Visible = True
        CostumeColumn.Visible = True
        lCostumeColumn.Visible = True

        TypeID.Value = "2"
        IDGroup.Text = eid
        Section.Text = esec
        SubSection.Text = esubsection

        utility.ModalV2("MainContent_MeaTemplateSecDetailsEdit_panel1")
    End Sub

    Protected Sub bEditSub_Click(sender As Object, e As EventArgs)
        refreshModal()
        Dim linkbutton As LinkButton = CType(sender, LinkButton)
        Dim esubsection As String = linkbutton.Attributes("subsection")
        Dim eseqsubsection As String = linkbutton.Attributes("seqsubsection")

        Dim eid As String = Request.QueryString("id")
        Dim esec As String = Request.QueryString("section")

        Dim Action As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("Action"), HiddenField)
        Dim TypeID As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("TypeID"), HiddenField)
        Dim IDGroup As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tIDGroup"), TextBox)
        Dim IDDetail As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tIDDetail"), TextBox)
        Dim lIDDetail As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lIDDetail"), HtmlGenericControl)
        Dim Sequence As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSeq"), TextBox)
        Dim Section As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSec"), TextBox)
        Dim SubSection As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSubSec"), TextBox)
        Dim curSubSection As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tcurSubSec"), HiddenField)
        Dim ItemDesc As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tItem"), TextBox)
        Dim lItemDesc As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lItem"), HtmlGenericControl)
        Dim RowCount As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tRowCount"), TextBox)
        Dim lRowCount As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lRowCount"), HtmlGenericControl)
        Dim ValType As DropDownList = DirectCast(MeaTemplateSecDetailsEdit.FindControl("ddValType"), DropDownList)
        Dim lValType As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lddValType"), HtmlGenericControl)
        Dim CostumeColumn As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tCostCol"), TextBox)
        Dim lCostumeColumn As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lCostCol"), HtmlGenericControl)

        'just for Edit
        Action.Value = "Edit"

        IDDetail.Visible = False
        lIDDetail.Visible = False
        ItemDesc.Visible = False
        lItemDesc.Visible = False
        RowCount.Visible = False
        lRowCount.Visible = False
        ValType.Visible = False
        lValType.Visible = False
        CostumeColumn.Visible = False
        lCostumeColumn.Visible = False

        TypeID.Value = "1"
        IDGroup.Text = eid
        Section.Text = esec
        Sequence.Text = eseqsubsection
        curSubSection.Value = esubsection
        SubSection.Text = esubsection
        SubSection.ReadOnly = False

        utility.ModalV2("MainContent_MeaTemplateSecDetailsEdit_panel1")
    End Sub

    Protected Sub bRemoveSub_Click(sender As Object, e As EventArgs)
        Dim eid As String = Request.QueryString("id")
        Dim linkbutton As LinkButton = CType(sender, LinkButton)
        Dim esubsection As String = linkbutton.Attributes("subsection")

        If CheckGroup(45) = True Then
            Dim query As String = "Update tbl_InspTemplateDetailRev set [Active]=0 where SubSectionName=" & evar(esubsection, 1) & " and IDGroup=" & eid
            executeQuery(query)
            BindingData()
        Else
            utility.showAlert(
                templateNotif(1, 45)
            )
        End If
    End Sub
#End Region

#Region "Item Desc Edit/Remove"
    Protected Sub bEdit_Click(sender As Object, e As EventArgs)
        refreshModal()
        Dim button As Button = CType(sender, Button)
        Dim eIDDetails As String = button.Attributes("iddata")
        Dim dt As New DataTable
        dt = GetDataTable("select * from tbl_InspTemplateDetailRev where IDDetail=" & eIDDetails)

        Dim Action As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("Action"), HiddenField)
        Dim TypeID As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("TypeID"), HiddenField)
        Dim IDGroup As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tIDGroup"), TextBox)
        Dim IDDetail As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tIDDetail"), TextBox)
        Dim lIDDetail As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lIDDetail"), HtmlGenericControl)
        Dim Sequence As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSeq"), TextBox)
        Dim Section As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSec"), TextBox)
        Dim SubSection As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tSubSec"), TextBox)
        Dim curSubSection As HiddenField = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tcurSubSec"), HiddenField)
        Dim ItemDesc As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tItem"), TextBox)
        Dim lItemDesc As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lItem"), HtmlGenericControl)
        Dim RowCount As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tRowCount"), TextBox)
        Dim lRowCount As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lRowCount"), HtmlGenericControl)
        Dim ValType As DropDownList = DirectCast(MeaTemplateSecDetailsEdit.FindControl("ddValType"), DropDownList)
        Dim lValType As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lddValType"), HtmlGenericControl)
        Dim CostumeColumn As TextBox = DirectCast(MeaTemplateSecDetailsEdit.FindControl("tCostCol"), TextBox)
        Dim lCostumeColumn As HtmlGenericControl = DirectCast(MeaTemplateSecDetailsEdit.FindControl("lCostCol"), HtmlGenericControl)

        'just for Edit
        Action.Value = "Edit"

        IDDetail.Visible = True
        lIDDetail.Visible = True
        ItemDesc.Visible = True
        lItemDesc.Visible = True
        RowCount.Visible = True
        lRowCount.Visible = True
        ValType.Visible = True
        lValType.Visible = True
        CostumeColumn.Visible = True
        lCostumeColumn.Visible = True

        TypeID.Value = "2"
        IDDetail.Text = CheckDBNull(dt.Rows(0)(0))
        IDGroup.Text = CheckDBNull(dt.Rows(0)(1))
        Section.Text = CheckDBNull(dt.Rows(0)(2))
        SubSection.Text = CheckDBNull(dt.Rows(0)(3))
        ItemDesc.Text = CheckDBNull(dt.Rows(0)(4))
        RowCount.Text = CheckDBNull(dt.Rows(0)(5))
        ValType.Text = CheckDBNull(dt.Rows(0)(6))
        CostumeColumn.Text = CheckDBNull(dt.Rows(0)(7))
        Sequence.Text = CheckDBNull(dt.Rows(0)(16))

        utility.ModalV2("MainContent_MeaTemplateSecDetailsEdit_panel1")
    End Sub

    Protected Sub bRemove_Click(sender As Object, e As EventArgs)
        Dim button As Button = CType(sender, Button)
        Dim eIDDetails As String = button.Attributes("iddata")

        If CheckGroup(45) = True Then
            Try
                Dim query As String = "Update tbl_InspTemplateDetailRev set [Active]=0 where IDDetail=" & eIDDetails
                executeQuery(query)
                BindingData()
            Catch ex As Exception
                err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
            End Try
        Else
            utility.showAlert(
                templateNotif(1, 45)
            )
        End If
    End Sub
#End Region

End Class