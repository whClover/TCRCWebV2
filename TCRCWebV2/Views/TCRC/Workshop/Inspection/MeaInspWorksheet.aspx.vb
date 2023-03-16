Imports System.Web.DynamicData
Imports Org.BouncyCastle.Asn1.Cms
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaInspWorksheet
    Inherits System.Web.UI.Page
    Dim utility As New Utility(Me)
    Dim tempfilter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bSearch_Click(sender As Object, e As EventArgs)
        BindingData()
    End Sub

    Sub filtering()
        Try
            If tWONo.Text <> String.Empty Then tempfilter = " and WONO like " & evar(tWONo.Text, 1)

            If Len(tempfilter) <= 0 Then
                tempfilter = ""
            Else
                tempfilter = " where " & Right(tempfilter, Len(tempfilter) - 4)
            End If
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try
    End Sub

    Public Sub BindingData()
        Try
            filtering()
            Dim dt As New DataTable
            dt = GetDataTable("select * from v_inspListInput" & tempfilter & " Order By InspCompletion")
            gvInsp.DataSource = dt
            gvInsp.DataBind()
            bCount.Text = "Total Data: " & dt.Rows.Count
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try
    End Sub

    Protected Sub bAddInsp_Click(sender As Object, e As EventArgs)
        'utility.ModalV2("MainContent_MeaInspBeforeAdd_Panel1")
        Response.Redirect(urlInspection & "MeaInspBeforeAdd.aspx")
    End Sub

    Protected Sub bDetailsTemp_Click(sender As Object, e As EventArgs)
        Dim linkedbutton As LinkButton = TryCast(sender, LinkButton)
        Dim etype As String = DirectCast(sender, LinkButton).Attributes("name")
        Dim ewo As String = linkedbutton.CommandArgument
        Response.Redirect(urlMeasureWorksheetDetails & "?wo=" & ewo & "&type=" & etype)
    End Sub

    Sub filteringAft()
        Try
            If tWONoAft.Text <> String.Empty Then tempfilter = " and WONo like " & evar(tWONoAft.Text, 1)

            If Len(tempfilter) <= 0 Then
                tempfilter = ""
            Else
                tempfilter = " where " & Right(tempfilter, Len(tempfilter) - 4)
            End If
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try
    End Sub

    Public Sub BindingDataAft()
        Try
            filteringAft()
            Dim dt As New DataTable
            Dim query As String = "select * from v_InspListInputAft" & tempfilter & " order by wono"
            dt = GetDataTable(query)
            gvInspAft.DataSource = dt
            gvInspAft.DataBind()
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try
    End Sub

    Protected Sub bSearchAft_Click(sender As Object, e As EventArgs)
        BindingDataAft()
    End Sub
End Class