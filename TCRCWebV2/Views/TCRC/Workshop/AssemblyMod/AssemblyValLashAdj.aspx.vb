Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports System.Windows

Public Class AssemblyValLashAdj
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
            count(IDEngineInput)) as PercComp from tbl_AssemblyEngineInput where wono=" & evar(ewo, 1) & " and CylinderDesc in('Inlet','Exhaust')"
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            pSectionProg.Style("width") = dt.Rows(0)("PercComp") & "%"
            lSectionProg.InnerText = "Overall Progress (" & dt.Rows(0)("PercComp") & "%)"
        End If
    End Sub

    Sub load_data()
        If ewo = String.Empty Then Exit Sub

        Dim dt As New DataTable
        Dim query As String = "select * from v_AssemblyLinerProj where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            rpt_valveAdj.DataSource = dt
            rpt_valveAdj.DataBind()
        End If
    End Sub

    Protected Sub rpt_valveAdj_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            'ambil data
            Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

            'deklarasi object
            Dim pNo As HtmlGenericControl = CType(e.Item.FindControl("pNo"), HtmlGenericControl)
            Dim tInlet As TextBox = CType(e.Item.FindControl("tInlet"), TextBox)
            Dim tExhaust As TextBox = CType(e.Item.FindControl("tExhaust"), TextBox)

            Dim eCylinderNo As String = dataItem("CylinderNo").ToString()
            pNo.InnerText = "#" & eCylinderNo
            tInlet.Text = dataItem("Inlet").ToString()
            tExhaust.Text = dataItem("Exhaust").ToString()
        End If
    End Sub

    Protected Sub rpt_valveAdj_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If e.CommandName = "Save" Then
            Dim cylinderNo As String = Convert.ToString(e.CommandArgument)
            Dim tInlet As TextBox = CType(e.Item.FindControl("tInlet"), TextBox)
            Dim tExhaust As TextBox = CType(e.Item.FindControl("tExhaust"), TextBox)
            Dim query_1 As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'Inlet'," & evar(tInlet.Text, 1) & "," & eByName()
            Dim query_2 As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'exhaust'," & evar(tExhaust.Text, 1) & "," & eByName()
            executeQuery(query_1)
            executeQuery(query_2)
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

    Protected Sub bna_Click(sender As Object, e As EventArgs)
        Dim query, ewono As String
        ewono = Request.QueryString("wo")
        query = "update tbl_AssemblyEngineInput set Value='n/a',ModBy=" & eByName() & ",ModDate=GetDate() where wono=" & evar(ewono, 1) & " and CylinderDesc in('Inlet','exhaust')"
        executeQuery(query)
        showAlertV2("success", "Saved")
        load_data()
        load_progress()
    End Sub

    Sub showAlertV2(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Swal", script, True)
    End Sub
End Class