Imports TCRCWebV2.Utility
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString

Public Class MeaInspBeforeAdd1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            generateWO()
        End If
    End Sub

    Sub generateWO()
        Dim query As String = "select (WONO + ' - ' + WODesc) as WONoComp,WONo from v_intJobDetailRev3 where JobStatusID not in('C','X','O')"
        'BindDataDropDown(ddWONo, query, "WONoComp", "WONo")
    End Sub

    Protected Sub bsearch_Click(sender As Object, e As EventArgs)
        Dim ewo As String = two.Text
        Dim dt As New DataTable
        dt = GetDataTable("select left(MaintType,5) as MaintID,dbo.GetComponentName(left(MaintType,5)) as CompName, 
                            UnitDescription,WODesc from v_intJobDetailRev3 where wono=" & evar(ewo, 1))
        If dt.Rows.Count > 0 Then
            twodesc.InnerText = dt.Rows(0)("WODesc")
            generateTemplate(dt.Rows(0)("UnitDescription"), dt.Rows(0)("MaintID"))
        Else
            twodesc.InnerText = "Work Order Number Not Found !"
        End If

    End Sub

    Sub generateTemplate(ByVal unitDesc As String, ByVal MaintID As String)
        Dim query As String = "select IDGroup,TemplateDesc from tbl_InspTemplateGroup where UnitDesc=" & evar(unitDesc, 1) & " and MaintID=" & evar(MaintID, 1)
        BindDataDropDown(ddInspTemp, query, "TemplateDesc", "IDGroup")
    End Sub

    Protected Sub bSave_Click(sender As Object, e As EventArgs)
        Dim ewono As String = two.Text
        Dim eIDGroup As String = evar(ddInspTemp.SelectedValue, 0)
        Dim query As String = "exec dbo.[InspAssignWORev] " & eIDGroup & "," & evar(ewono, 1) & "," & eByName()
        executeQuery(query)
        Response.Redirect(urlMeasureWorksheetDetails & "?wo=" & ewono & "&type=0")
    End Sub

    Protected Sub bClose_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlMeasureWorksheet)
    End Sub
End Class