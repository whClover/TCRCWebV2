Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString
Public Class MeaTemplateShow
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ss_userid") = "" Then
            Response.Redirect(urlTCRCLogin)
        End If

        If Not IsPostBack = True Then
            GenerateDesign()
        End If
    End Sub

    Sub GenerateDesign()
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        Dim html As New StringBuilder
        Dim dt As New DataTable
        Dim query As String = "exec dbo.[InspDetails] " & evar(eid, 1) & ""
        dt = GetDataTable(query)

        If dt.Rows.Count > 0 Then
            html.Append(CheckDBNull(dt.Rows(0)(0).ToString()))
            Me.MeaTemplate.Controls.Add(New Literal() With {
                .Text = html.ToString
            })
        End If
    End Sub
End Class
