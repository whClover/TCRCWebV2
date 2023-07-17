Imports TCRCWebV2.Utility
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports Microsoft.SqlServer.Server

Public Class AssemblyAssignEngine
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        load_template()
    End Sub

    Sub load_template()
        Dim query As String = "select IDTemplateEngineGroup,Case when PartNumber is not null then EngineSeries + '-P/N:'  + PartNumber else EngineSeries end as EngineSeries from  tbl_AssemblyEngineTemplateGroup where Active=1"
        BindDataDropDown(modDDTemplate, query, "EngineSeries", "IDTemplateEngineGroup")
    End Sub

    Protected Sub bassign_Click(sender As Object, e As EventArgs)
        Dim ewo As String = evar(Me.modWONo.Text, 1)
        Dim eIDTemplate As String = modDDTemplate.SelectedValue
        Dim query As String = "exec dbo.AssemblyTemplateEngineSubmit " + ewo + "," + eIDTemplate + "," + eByName()
        executeQuery(query)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Refresh", "window.location.reload();", True)
    End Sub
End Class