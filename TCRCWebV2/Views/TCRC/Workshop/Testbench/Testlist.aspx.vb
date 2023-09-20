Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class Testlist
    Inherits System.Web.UI.Page

    Dim tempfilter As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingdata()
        End If
    End Sub

    Sub filtering()
        If tWONo.Text <> String.Empty Then tempfilter = " and WONo like " & evar(tWONo.Text, 11) & tempfilter

        If Len(tempfilter) <= 0 Then
            tempfilter = ""
        Else
            tempfilter = " where " & Right(tempfilter, Len(tempfilter) - 4)
        End If
    End Sub

    Sub bindingdata()
        filtering()
        Dim dt As New DataTable
        Dim query As String = "select * from v_TCRCTesting" & tempfilter & " order by wono desc"
        dt = GetDataTable(query)
        gvTest.DataSource = dt
        gvTest.DataBind()
    End Sub

    Protected Sub bsearch_Click(sender As Object, e As EventArgs)
        bindingdata()
    End Sub

    Protected Sub bedit_Click(sender As Object, e As EventArgs)
        Dim dt As New DataTable
        Dim ewo As String = CType(sender, LinkButton).CommandArgument
        Dim ec As String
        Dim query_count As String = "select count(*) as c from tbl_AssemblyDynoInput where wono=" & evar(ewo, 1)
        dt = GetDataTable(query_count)
        ec = dt.Rows(0)("c").ToString()

        If ec = "0" Then
            showAlertV2("info", "Dyno Checksheet/Template not found for this WO, Please contact workshop supervisor")
            Exit Sub
        End If

        Session("ss_assembly") = "n10"
        Response.Redirect(urlAssemblyDyno & "?wo=" & ewo)
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub
End Class