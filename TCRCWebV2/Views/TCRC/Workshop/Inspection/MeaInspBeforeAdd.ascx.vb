Imports Microsoft.SqlServer.Server
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaInspBeforeAdd
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            generateWO()
        End If
    End Sub

    Protected Sub bSave_Click(sender As Object, e As EventArgs)
        Dim ewono As String = ddWONo.SelectedValue.ToString()
        Dim eIDGroup As String = evar(ddInspTemp.SelectedValue, 0)

        'Try
        Dim query As String = "exec dbo.[InspAssignWORev] " & eIDGroup & "," & evar(ewono, 1) & "," & eByName()
        executeQuery(query)
        Response.Redirect(urlMeasureWorksheetDetails & "?wo=" & ewono)
        'Catch ex As Exception
        'err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        'End Try
    End Sub

    Sub generateWO()
        Dim query As String = "select (WONO + ' - ' + WODesc) as WONoComp,WONo from v_intJobDetailRev3 where JobStatusID not in('C','X','O')"
        BindDataDropDown(ddWONo, query, "WONoComp", "WONo")
    End Sub

    Protected Sub ddWONo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim selectedVal As String = ddWONo.SelectedValue
        Dim dt As New DataTable
        Dim query As String = "select left(MaintType,5) as MaintID,dbo.GetComponentName(left(MaintType,5)) as CompName, 
            UnitDescription from v_intJobDetailRev3 where wono=" & evar(selectedVal, 1)
        dt = GetDataTable(query)

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "updateUnit", "updateUnit('" & dt.Rows(0)(2) & "');", True)
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "updateComp", "updateComp('" & dt.Rows(0)(1) & "');", True)
        generateTemplate(dt.Rows(0)(2), dt.Rows(0)(0))
    End Sub

    Sub generateTemplate(ByVal unitDesc As String, ByVal MaintID As String)
        Dim query As String = "select IDGroup,TemplateDesc from tbl_InspTemplateGroup where UnitDesc=" & evar(unitDesc, 1) & " and MaintID=" & evar(MaintID, 1)
        BindDataDropDown(ddInspTemp, query, "TemplateDesc", "IDGroup")
    End Sub
End Class