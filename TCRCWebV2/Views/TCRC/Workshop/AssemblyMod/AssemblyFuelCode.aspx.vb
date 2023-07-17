Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports System.Windows

Public Class AssemblyFuelCode
    Inherits System.Web.UI.Page

    Dim ewo As String
    Dim utility As New Utility(Me)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ewo = Request.QueryString("wo")

        If IsPostBack = False Then
            load_head()
            load_data()
            load_progress()
            check_templateEngine()
        End If
    End Sub

    Sub check_templateEngine()
        Dim ewo As String = Request.QueryString("wo")
        Dim query As String = "select * from tbl_AssemblyEngineInput where wono=" & evar(ewo, 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count = 0 Then
            Dim query2 As String = "select * from v_Intjobdetailrev3 where wono=" & evar(ewo, 1)
            Dim dt2 As New DataTable
            dt2 = GetDataTable(query2)
            Dim modWONO As TextBox = DirectCast(AssemblyAssignEngine.FindControl("modWONO"), TextBox)
            Dim modWODesc As TextBox = DirectCast(AssemblyAssignEngine.FindControl("modWODesc"), TextBox)
            modWONO.Text = ewo
            modWODesc.Text = dt2.Rows(0)("WODesc")

            utility.ModalV2("MainContent_AssemblyAssignEngine_Panel1")
        End If
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
            count(IDEngineInput)) as PercComp from tbl_AssemblyEngineInput where wono=" & evar(ewo, 1) & " and CylinderDesc in('TrimCode','InjctIdentication')"
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            pSectionProg.Style("width") = dt.Rows(0)("PercComp") & "%"
            lSectionProg.InnerText = "Overall Progress (" & dt.Rows(0)("PercComp") & "%)"
        End If
    End Sub

    Sub load_data()
        If ewo = String.Empty Then Exit Sub

        Dim dt As New DataTable
        Dim query As String = "select * from v_AssemblyTrimCode where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            rpt_FuelCode.DataSource = dt
            rpt_FuelCode.DataBind()
        End If
    End Sub

    Protected Sub rpt_FuelCode_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            'ambil data
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            Dim pNo As HtmlGenericControl = CType(e.Item.FindControl("pNo"), HtmlGenericControl)
            Dim tCode As TextBox = CType(e.Item.FindControl("tCode"), TextBox)
            Dim ddInjIden As DropDownList = CType(e.Item.FindControl("ddInjIden"), DropDownList)
            Dim eCylinderNo As String = dataItem("CylinderNo").ToString()

            pNo.InnerText = "#" & dataItem("CylinderNo").ToString()
            tCode.Text = dataItem("TrimCode").ToString()
            ddInjIden.SelectedValue = dataItem("InjctIdentication").ToString()
        End If
    End Sub

    Protected Sub rpt_FuelCode_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If e.CommandName = "Save" Then
            Dim cylinderNo As String = Convert.ToString(e.CommandArgument)
            Dim tCode As TextBox = CType(e.Item.FindControl("tCode"), TextBox)
            Dim ddInjIden As DropDownList = CType(e.Item.FindControl("ddInjIden"), DropDownList)

            Dim query_1 As String = "update tbl_AssemblyEngineInput set Value=" & evar(tCode.Text, 1) & ",ModDate=GetDate(),ModBy=" & eByName() & " 
                where wono=" & evar(ewo, 1) & " and CylinderDesc='TrimCode' and CylinderNo=" & evar(cylinderNo, 1)
            Dim query_2 As String = "update tbl_AssemblyEngineInput set Value=" & evar(ddInjIden.SelectedValue, 1) & ",ModDate=GetDate(),ModBy=" & eByName() & " 
                where wono=" & evar(ewo, 1) & " and CylinderDesc='InjctIdentication' and CylinderNo=" & evar(cylinderNo, 1)
            executeQuery(query_1)
            executeQuery(query_1)
            showAlert("success", "Data Saved Successfully")

            load_data()
            load_progress()
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