Imports System.Security.Cryptography
Imports DocumentFormat.OpenXml.Office.CustomUI
Imports DocumentFormat.OpenXml.Presentation
Imports DocumentFormat.OpenXml.Spreadsheet
Imports DocumentFormat.OpenXml.Wordprocessing
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaInspTemplate
    Inherits System.Web.UI.Page

    Dim utility As New Utility(Me)
    Dim tempfilter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ss_userid") = "" Then
            Response.Redirect(urlTCRCLogin)
        End If

        If IsPostBack = False Then
            load_dropdown()
            BindingData()
        End If
    End Sub

    Sub filtering()
        Try
            If tDesc.Text <> String.Empty Then tempfilter = " and TemplateDesc like " & evar(tDesc.Text, 11) & tempfilter
            If ddComp.SelectedValue <> String.Empty Then tempfilter = " and MaintID=" & evar(ddComp.SelectedValue, 1) & tempfilter
            If ddUnitDesc.SelectedValue <> String.Empty Then tempfilter = " and UnitDesc=" & evar(ddUnitDesc.SelectedValue, 1) & tempfilter

            If Len(tempfilter) <= 0 Then
                tempfilter = ""
            Else
                tempfilter = " where  " & Right(tempfilter, Len(tempfilter) - 4)
            End If
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try
    End Sub

    Public Sub BindingData()
        Try
            filtering()
            Dim dt As New DataTable
            dt = GetDataTable("select * from v_InspTemplateList" & tempfilter & " Order By IDGroup")
            Me.gvInsp.DataSource = dt
            Me.gvInsp.DataBind()
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try
    End Sub

    Sub load_dropdown()
        BindDataDropDown(ddComp, "select MaintIDDesc,MaintID from tbl_MaintBase where TCRP=1", "MaintIDDesc", "MaintID")
        BindDataDropDown(ddUnitDesc, "select UnitDesc from tbl_UnitDesc where MainTCR=1", "UnitDesc", "UnitDesc")
    End Sub

    Protected Sub bSearch_Click(sender As Object, e As EventArgs)
        BindingData()
    End Sub

    Protected Sub bDetailsTemp_Click(sender As Object, e As EventArgs)
        Dim eid As String = CType(sender, LinkButton).CommandArgument
        Response.Redirect(urlMeasureTemplateSec & "?id=" & eid)
    End Sub

    Protected Sub bEditTemp_Click(sender As Object, e As EventArgs)
        Dim eid As String = CType(sender, LinkButton).CommandArgument

        Dim dt As New DataTable
        dt = GetDataTable("select IDGroup,UnitDesc,MaintID,TemplateDesc from tbl_InspTemplateGroup where IDGroup=" & eid)
        Dim eIDGroup As HiddenField = DirectCast(MeaTemplateEdit.FindControl("IDGroup"), HiddenField)
        Dim eUnitDesc As DropDownList = DirectCast(MeaTemplateEdit.FindControl("ddUnitDesc"), DropDownList)
        Dim eComponent As DropDownList = DirectCast(MeaTemplateEdit.FindControl("ddComp"), DropDownList)
        Dim eDesc As TextBox = DirectCast(MeaTemplateEdit.FindControl("tDesc"), TextBox)

        eIDGroup.Value = eid
        eUnitDesc.SelectedValue = dt.Rows(0)(1)
        eComponent.SelectedValue = dt.Rows(0)(2)
        eDesc.Text = dt.Rows(0)(3)

        utility.ModalV2("MainContent_MeaTemplateEdit_Panel1")
    End Sub

    Protected Sub bAdd_Click(sender As Object, e As EventArgs)
        Dim eIDGroup As HiddenField = DirectCast(MeaTemplateEdit.FindControl("IDGroup"), HiddenField)
        Dim eUnitDesc As DropDownList = DirectCast(MeaTemplateEdit.FindControl("ddUnitDesc"), DropDownList)
        Dim eComponent As DropDownList = DirectCast(MeaTemplateEdit.FindControl("ddComp"), DropDownList)
        Dim eDesc As TextBox = DirectCast(MeaTemplateEdit.FindControl("tDesc"), TextBox)

        eIDGroup.Value = "0"
        eUnitDesc.SelectedValue = ""
        eComponent.SelectedValue = ""
        eDesc.Text = String.Empty

        utility.ModalV2("MainContent_MeaTemplateEdit_Panel1")
    End Sub
End Class