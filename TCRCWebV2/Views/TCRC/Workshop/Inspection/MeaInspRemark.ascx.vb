Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class MeaInspRemark
    Inherits System.Web.UI.UserControl


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bSave_Click(sender As Object, e As EventArgs)
        Dim ewo As String = Request.QueryString("wo")
        Dim esection As String = Request.QueryString("section")
        Dim eremark As String = evar(summernote.Value, 1)

        Dim query As String = "update tbl_InspSectionRemark set Remark=" & eremark & ",ModBy=" & eByName() & ",ModDate=GetDate()  
                    where IDInspRemark=(select IDInspRemark from v_InspRemark where wono=" & evar(ewo, 1) & "
                    and InspSection=" & evar(esection, 1) & ")"
        executeQuery(query)
        DirectCast(Page, MeaInspWorksheetRev).LoadUI()
    End Sub
End Class