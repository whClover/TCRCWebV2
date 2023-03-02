Imports System.Security.Cryptography
Imports DocumentFormat.OpenXml.Spreadsheet
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaTemplateEdit
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lNotif.Visible = False
            load_dropdown()
        End If
    End Sub

    Sub load_dropdown()
        BindDataDropDown(ddComp, "select MaintIDDesc,MaintID from tbl_MaintBase where TCRP=1", "MaintIDDesc", "MaintID")
        BindDataDropDown(ddUnitDesc, "select UnitDesc from tbl_UnitDesc where MainTCR=1", "UnitDesc", "UnitDesc")
    End Sub

    Protected Sub bSave_Click(sender As Object, e As EventArgs)
        Dim eUnitDesc, eComp, eDesc As String

        Dim eid As String = IDGroup.Value
        If eid = String.Empty Then
            eid = "0"
        End If

        If ddUnitDesc.SelectedValue = String.Empty Then
            lNotif.InnerText = "Please Choose Unit Description"
            lNotif.Visible = True
        Else
            eUnitDesc = evar(ddUnitDesc.SelectedValue, 1)
        End If

        If ddComp.SelectedValue = String.Empty Then
            lNotif.InnerText = "Please Choose Component"
            lNotif.Visible = True
        Else
            eComp = evar(ddComp.SelectedValue, 1)
        End If

        If tDesc.Text = String.Empty Then
            lNotif.InnerText = "Please Fill Template Description"
            lNotif.Visible = True
        Else
            eDesc = evar(tDesc.Text, 1)
        End If

        Dim query As String = "exec dbo.InspSubmitTemplateGP " & eid & "," & eDesc & "," & eUnitDesc & "," & eComp & "," & eByName()
        executeQuery(query)
        DirectCast(Page, MeaInspTemplate).BindingData()
    End Sub
End Class