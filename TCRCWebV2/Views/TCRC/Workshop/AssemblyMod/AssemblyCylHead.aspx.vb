Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports System.Windows

Public Class AssemblyCylHead
    Inherits System.Web.UI.Page

    Dim ewo As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ewo = Request.QueryString("wo")

        If IsPostBack = False Then
            load_head()
            load_data()
            load_progress()
        End If
    End Sub

    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If Session("ScrollPosition") IsNot Nothing Then
            Dim scrollPosition As Integer = Integer.Parse(Session("ScrollPosition"))
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "setScrollPosition", "setTimeout(function() { window.scrollTo(0, " & scrollPosition & "); }, 100);", True)
        End If

        load_progress()
    End Sub

    Sub getcurrentScrollPos()
        Dim currentScrollPosition As Integer = Integer.Parse(ScrollPosition.Value)
        Session("ScrollPosition") = currentScrollPosition
    End Sub

    Sub load_head()
        lwono.InnerText = "WO." & ewo

        Dim query As String = "select WODesc from v_IntJobDetailRev3 where wono=" & evar(ewo, 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            lwodesc.InnerText = dt.Rows(0)("WODesc")
        End If
    End Sub

    Sub load_progress()
        If ewo = String.Empty Then Exit Sub

        Dim dt As New DataTable
        Dim query As String = "select dbo.PercentCalc(sum(case when Value is null then 0 else 1 end),
            count(IDEngineInput)) as PercComp from tbl_AssemblyEngineInput where wono=" & evar(ewo, 1) & " and 
            CylinderDesc in('IntakeValveA','IntakeValveB','ExhaustValveA','ExhaustValveB','CylRec','WOCylHead') group by value"
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            pSectionProg.Style("width") = dt.Rows(0)("PercComp") & "%"
            lSectionProg.InnerText = "Overall Progress (" & dt.Rows(0)("PercComp") & "%)"
        End If
    End Sub

    Sub load_data()
        Dim dt As New DataTable
        Dim query As String = "select CylinderNo,IntakeValveA,IntakeValveB,ExhaustValveA,ExhaustValveB,CylRec,WOCylHead,
        [IntakeValveA_InsBore],[IntakeValveB_InsBore],[ExhaustValveA_InsBore],[ExhaustValveB_InsBore]
            from fr_AssemblyEngineInput() where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            rpt_cylhead.DataSource = dt
            rpt_cylhead.DataBind()
        End If
    End Sub

    Protected Sub rpt_cylhead_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            'ambil data
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            'Declare Object
            Dim H2 As HtmlGenericControl = CType(e.Item.FindControl("H2"), HtmlGenericControl)
            Dim ddCylRec As DropDownList = CType(e.Item.FindControl("ddCylRec"), DropDownList)

            Dim tIntakeA As TextBox = CType(e.Item.FindControl("tIntakeA"), TextBox)
            Dim tIntakeB As TextBox = CType(e.Item.FindControl("tIntakeA"), TextBox)
            Dim tExhaustA As TextBox = CType(e.Item.FindControl("tExhaustA"), TextBox)
            Dim tExhaustB As TextBox = CType(e.Item.FindControl("tExhaustB"), TextBox)

            Dim ddIntakeA As DropDownList = CType(e.Item.FindControl("ddIntakeA"), DropDownList)
            Dim ddIntakeB As DropDownList = CType(e.Item.FindControl("ddIntakeB"), DropDownList)
            Dim ddExhaustA As DropDownList = CType(e.Item.FindControl("ddExhaustA"), DropDownList)
            Dim ddExhaustB As DropDownList = CType(e.Item.FindControl("ddExhaustB"), DropDownList)

            'insert data to object
            H2.InnerHtml = "Cylinder No.<span class=""text-muted fw-normal font-size-22 ms-2"">#" & dataItem("CylinderNo").ToString() & "</span>"
            ddCylRec.SelectedValue = dataItem("CylRec").ToString()

            tIntakeA.Text = CheckDBNull(dataItem("IntakeValveA").ToString())
            tIntakeB.Text = CheckDBNull(dataItem("IntakeValveB").ToString())
            tExhaustA.Text = CheckDBNull(dataItem("ExhaustValveA").ToString())
            tExhaustB.Text = CheckDBNull(dataItem("ExhaustValveB").ToString())

            ddIntakeA.SelectedValue = dataItem("IntakeValveA_InsBore").ToString()
            ddIntakeB.SelectedValue = dataItem("IntakeValveB_InsBore").ToString()
            ddExhaustA.SelectedValue = dataItem("ExhaustValveA_InsBore").ToString()
            ddExhaustB.SelectedValue = dataItem("ExhaustValveB_InsBore").ToString()
        End If
    End Sub

    Protected Sub rpt_cylhead_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If e.CommandName = "Save" Then
            Dim cylinderNo As String = Convert.ToString(e.CommandArgument)
            Dim ddCylRec As DropDownList = CType(e.Item.FindControl("ddCylRec"), DropDownList)

            Dim tIntakeA As TextBox = CType(e.Item.FindControl("tIntakeA"), TextBox)
            Dim tIntakeB As TextBox = CType(e.Item.FindControl("tIntakeB"), TextBox)
            Dim tExhaustA As TextBox = CType(e.Item.FindControl("tExhaustA"), TextBox)
            Dim tExhaustB As TextBox = CType(e.Item.FindControl("tExhaustB"), TextBox)

            Dim ddIntakeA As DropDownList = CType(e.Item.FindControl("ddIntakeA"), DropDownList)
            Dim ddIntakeB As DropDownList = CType(e.Item.FindControl("ddIntakeB"), DropDownList)
            Dim ddExhaustA As DropDownList = CType(e.Item.FindControl("ddExhaustA"), DropDownList)
            Dim ddExhaustB As DropDownList = CType(e.Item.FindControl("ddExhaustB"), DropDownList)

            Dim query_1 As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'IntakeValveA'," & evar(tIntakeA.Text, 1) & "," & eByName()
            Dim query_2 As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'IntakeValveB'," & evar(tIntakeB.Text, 1) & "," & eByName()
            Dim query_3 As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'ExhaustValveA'," & evar(tExhaustA.Text, 1) & "," & eByName()
            Dim query_4 As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'ExhaustValveB'," & evar(tExhaustB.Text, 1) & "," & eByName()

            Dim query_5 As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'IntakeValveA_InsBore'," & evar(ddIntakeA.SelectedValue, 1) & "," & eByName()
            Dim query_6 As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'IntakeValveB_InsBore'," & evar(ddIntakeB.SelectedValue, 1) & "," & eByName()
            Dim query_7 As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'ExhaustValveA_InsBore'," & evar(ddExhaustA.SelectedValue, 1) & "," & eByName()
            Dim query_8 As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'ExhaustValveB_InsBore'," & evar(ddExhaustB.SelectedValue, 1) & "," & eByName()
            executeQuery(query_1)
            executeQuery(query_2)
            executeQuery(query_3)
            executeQuery(query_4)
            executeQuery(query_5)
            executeQuery(query_6)
            executeQuery(query_7)
            executeQuery(query_8)

            showAlert("success", "Data Saved Successfully")

            load_data()
            load_progress()
            getcurrentScrollPos()
        End If
    End Sub

    Sub showAlert(ByVal type As String, ByVal msg As String)
        Dim optsc As String = "toastr.options = {
          ""closeButton"": false,
          ""debug"": false,
          ""newestOnTop"": false,
          ""progressBar"": false,
          ""positionClass"": ""toast-top-center"",
          ""preventDuplicates"": false,
          ""onclick"": null,
          ""showDuration"": ""300"",
          ""hideDuration"": ""1000"",
          ""timeOut"": ""5000"",
          ""extendedTimeOut"": ""1000"",
          ""showEasing"": ""swing"",
          ""hideEasing"": ""linear"",
          ""showMethod"": ""fadeIn"",
          ""hideMethod"": ""fadeOut""
        };"

        Dim script As String
        script = optsc & "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toastrMessage", script, True)
    End Sub
End Class