Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class AssemblyMenu
    Inherits System.Web.UI.UserControl

    Dim ewo As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ewo = Request.QueryString("wo")
        loadmenu()

        Dim eactive = "nav-link active"
        Dim enonactive = "nav-link"
        n1.CssClass = enonactive
        n2.CssClass = enonactive
        n3.CssClass = enonactive
        n4.CssClass = enonactive
        n5.CssClass = enonactive
        n6.CssClass = enonactive
        n7.CssClass = enonactive
        n8.CssClass = enonactive
        n9.CssClass = enonactive

        Dim linkb As String
        linkb = Session("ss_assembly")

        If linkb = "n1" Then
            n1.CssClass = eactive
        ElseIf linkb = "n2" Then
            n2.CssClass = eactive
        ElseIf linkb = "n3" Then
            n3.CssClass = eactive
        ElseIf linkb = "n4" Then
            n4.CssClass = eactive
        ElseIf linkb = "n5" Then
            n5.CssClass = eactive
        ElseIf linkb = "n6" Then
            n6.CssClass = eactive
        ElseIf linkb = "n7" Then
            n7.CssClass = eactive
        ElseIf linkb = "n8" Then
            n8.CssClass = eactive
        End If
    End Sub

    Sub loadmenu()
        Dim dt As New DataTable
        Dim query As String = "select dbo.[CompGroupByWONo](" & evar(ewo, 1) & ") as workshop"
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then

            Select Case dt.Rows(0)("workshop")
                Case "Powertrain"
                    n3.Visible = False
                    n4.Visible = False
                    n5.Visible = False
                    n6.Visible = False
                    n7.Visible = False
                    n8.Visible = False
                    n9.Visible = False
                Case "Engine"
                    n1.Visible = True
                    n2.Visible = True
                    n3.Visible = True
                    n4.Visible = True
                    n5.Visible = True
                    n6.Visible = True
                    n7.Visible = True
                    n8.Visible = True
                    n9.Visible = True
            End Select

        End If
    End Sub

    Protected Sub n1_Click(sender As Object, e As EventArgs)
        reactive_nav(n1)
    End Sub

    Protected Sub n2_Click(sender As Object, e As EventArgs)
        reactive_nav(n2)
    End Sub

    Protected Sub n3_Click(sender As Object, e As EventArgs)
        reactive_nav(n3)
    End Sub

    Protected Sub n4_Click(sender As Object, e As EventArgs)
        reactive_nav(n4)
    End Sub

    Protected Sub n5_Click(sender As Object, e As EventArgs)
        reactive_nav(n5)
    End Sub

    Protected Sub n6_Click(sender As Object, e As EventArgs)
        reactive_nav(n6)
    End Sub

    Protected Sub n7_Click(sender As Object, e As EventArgs)
        reactive_nav(n7)
    End Sub

    Protected Sub n8_Click(sender As Object, e As EventArgs)
        reactive_nav(n8)
    End Sub

    Sub reactive_nav(ByVal linkb As LinkButton)
        Dim eactive = "nav-link active"
        Dim enonactive = "nav-link"

        n1.CssClass = enonactive
        n2.CssClass = enonactive
        n3.CssClass = enonactive
        n4.CssClass = enonactive
        n5.CssClass = enonactive
        n6.CssClass = enonactive
        n7.CssClass = enonactive
        n8.CssClass = enonactive
        n9.CssClass = enonactive

        If linkb Is n1 Then
            'n1.CssClass = eactive
            Session("ss_assembly") = "n1"
            Response.Redirect(urlAssemblyMea & "?wo=" & ewo)
        ElseIf linkb Is n2 Then
            'n2.CssClass = eactive
            Session("ss_assembly") = "n2"
            Response.Redirect(urlAssemblyChk & "?wo=" & ewo)
        ElseIf linkb Is n3 Then
            'n3.CssClass = eactive
            Session("ss_assembly") = "n3"
            Response.Redirect(urlAssemblyLinerProj & "?wo=" & ewo)
        ElseIf linkb Is n4 Then
            'n4.CssClass = eactive
            Session("ss_assembly") = "n4"
            Response.Redirect(urlAssemblyUpperLiner & "?wo=" & ewo)
        ElseIf linkb Is n5 Then
            'n5.CssClass = eactive
            Session("ss_assembly") = "n5"
            Response.Redirect(urlAssemblyPinPiston & "?wo=" & ewo)
        ElseIf linkb Is n6 Then
            'n6.CssClass = eactive
            Session("ss_assembly") = "n6"
            Response.Redirect(urlAssemblyValveLashAdj & "?wo=" & ewo)
        ElseIf linkb Is n7 Then
            'n7.CssClass = eactive
            Session("ss_assembly") = "n7"
            Response.Redirect(urlAssemblyFuelInjTrom & "?wo=" & ewo)
        ElseIf linkb Is n8 Then
            'n8.CssClass = eactive
            Session("ss_assembly") = "n8"
            Response.Redirect(urlAssemblyPistonRec & "?wo=" & ewo)
        ElseIf linkb Is n9 Then
            n9.CssClass = eactive
        End If
    End Sub


End Class