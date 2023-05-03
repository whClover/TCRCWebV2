Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports Microsoft.SqlServer.Server

Public Class AssemblyList
    Inherits System.Web.UI.Page

    Dim tempfilter As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub filtering()
        If tWONo.Text <> String.Empty Then tempfilter = " and WONo like " & evar(tWONo.Text, 11) & tempfilter
        If ddWs.SelectedValue <> String.Empty Then tempfilter = " and ComppGroup=" & evar(ddWs.SelectedValue, 1) & tempfilter

        Select Case ddStatus.SelectedValue
            Case "0"
                tempfilter = " and AssignTemplate=0"
            Case "1"
                tempfilter = " and AssignTemplate=1 and AssemblyCompletion<>100" & tempfilter
            Case "2"
                tempfilter = " and AssignTemplate=1 and AsmLH_Perc<>100" & tempfilter
            Case "3"
                tempfilter = " and AssignTemplate=1 and AsmSPV_Perc<>100" & tempfilter
            Case "4"
                tempfilter = " and AssignTemplate=1 and AssemblyCompletion=100 and 
                MeasurementCompletion=100 and ChecksheetCompletion=100 and AsmLH_Perc=100
                and AsmSPV_Perc=100" & tempfilter
        End Select

        Select Case ddYear.SelectedValue
            Case "1" : tempfilter = " and DocDate >= '2023-01-01'" & tempfilter
            Case "2" : tempfilter = " and DocDate <= '2023-01-01'" & tempfilter
        End Select

        If Len(tempfilter) <= 0 Then
            tempfilter = ""
        Else
            tempfilter = " where " & Right(tempfilter, Len(tempfilter) - 4)
        End If
    End Sub

    Sub load_Data()
        filtering()
        Dim dt As New DataTable
        Dim query As String = "select * from v_AssemblyGroupRev3" & tempfilter
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            gv_asm.DataSource = dt
            gv_asm.DataBind()
        End If
    End Sub

    Protected Sub bSearch_Click(sender As Object, e As EventArgs)
        load_Data()
    End Sub

    Protected Sub gv_asm_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim eassign As String = DirectCast(e.Row.DataItem, DataRowView)("AssignTemplate").ToString()
            If eassign = "False" Then
                e.Row.FindControl("bassign").Visible = True
                e.Row.FindControl("bedit").Visible = False
                e.Row.FindControl("bupload").Visible = False
                e.Row.FindControl("bprint").Visible = False
            Else
                e.Row.FindControl("bassign").Visible = False
                e.Row.FindControl("bedit").Visible = True
                e.Row.FindControl("bupload").Visible = True
                e.Row.FindControl("bprint").Visible = True
            End If
        End If
    End Sub

    Sub showAlert(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toastrMessage", script, True)
    End Sub

    Protected Sub bedit_Click(sender As Object, e As EventArgs)
        'showAlert("warning", "This Function Will be Active soon !")
        Dim ewono As String = CType(sender, LinkButton).CommandArgument

        Response.Redirect(urlAssemblyMea & "?wo=" & ewono)
    End Sub

    Protected Sub bupload_Click(sender As Object, e As EventArgs)
        showAlert("warning", "This Function Will be Active soon !")
    End Sub

    Protected Sub bprint_Click(sender As Object, e As EventArgs)
        showAlert("warning", "This Function Will be Active soon !")
    End Sub
End Class