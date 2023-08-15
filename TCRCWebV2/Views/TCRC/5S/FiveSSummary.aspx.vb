Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class FiveSSummary
    Inherits System.Web.UI.Page

    Dim tempfilter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingdata()
        End If
    End Sub

    Sub filterdata()
        'Date
        If tStart.Value <> String.Empty Then
            tempfilter = " AND RegisterBy >= " & evar(tStart.Value, 2) & tempfilter
        End If
        If tEnd.Value <> String.Empty Then
            tempfilter = " AND RegisterBy <= " & evar(tEnd.Value, 2) & tempfilter
        End If
        'End: Date

        If Len(tempfilter) > 0 Then
            tempfilter = varfilter(tempfilter)
        End If
    End Sub

    Sub bindingdata()
        filterdata()
        Dim ecolumn As String = "RegisterBy,convert(varchar,RegisterDate,103) as RegisterDate,FindingDesc,FindingAct,AreaDesc,dbo.RemapPict5S(PicturePath) as rmPict,
                                AssignTo,InspectStatus"
        Dim query As String = "select " & ecolumn & " from v_5SSummary" & tempfilter
        Dim dt As New DataTable
        dt = GetDataTable(query)
        gv5sSummary.DataSource = dt
        gv5sSummary.DataBind()
    End Sub

    Protected Sub bsearch_Click(sender As Object, e As EventArgs)
        bindingdata()
    End Sub
End Class