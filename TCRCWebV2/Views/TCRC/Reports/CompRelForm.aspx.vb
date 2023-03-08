Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString
Public Class CompRelForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GenerateData()
    End Sub

    Private Sub GenerateData()
        Dim ewo As String = Request.QueryString("wo")
        Dim dt As New DataTable
        Dim query As String = "select * from v_TCRCReleaseForm where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            lWO.Text = dt.Rows(0)("WONo")
            lCompPn.Text = dt.Rows(0)("TCIPartNo")
            lUnitNo.Text = dt.Rows(0)("UnitNumber")
            lCompReg.Text = dt.Rows(0)("CompID")
            lUnitModel.Text = dt.Rows(0)("UnitDescription")
            lDateHead.Text = dt.Rows(0)("RegisterDate")
            lCompDesc.Text = dt.Rows(0)("CompName")


        End If
    End Sub
End Class