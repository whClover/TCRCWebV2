Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString
Imports System.Data.SqlClient
Imports DocumentFormat.OpenXml.Office.CustomUI
Imports System.Windows

Public Class AssemblyLinerProj
	Inherits System.Web.UI.Page

	Dim ewo As String
	Dim utility As New Utility(Me)
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		ewo = Request.QueryString("wo")

		If IsPostBack = False Then
			load_head()
			load_1()
			load_2()
			load_3()
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

	Sub load_1()
		If ewo = String.Empty Then Exit Sub

		Dim dt As New DataTable
		Dim query As String = "select CylinderNo,case when LPA is null then 0 else convert(float,LPA) end as LPA," _
			& "case when LPB is null then 0 else convert(float,LPB) end as LPB," _
			& "case when LPC is null then 0 else convert(float,LPC) end as LPC," _
			& "case when LPD is null then 0 else convert(float,LPD) end as LPD," _
			& "case when SumLP is null then 0 else convert(float,SumLP) end as SumLP," _
			& "case when AvgLP is null then 0 else convert(float,AVGLP) end as AVGLP," _
			& "case when MaxVal is null then 0 else convert(float,MaxVal) end as MaxVal," _
			& "case when MinVal is null then 0 else convert(float,MinVal) end as MinVal," _
			& "case when VarValue is null then 0 else convert(float,VarValue) end as VarValue," _
			& "case when LPMinUS is null then 0 else convert(float,LPMinUS) end as LPMinUS," _
			& "case when LPMinUnitUS is null then '' else LPMinUnitUS end as LPMinUnitUS," _
			& "case when LPMaxUS is null then 0 else convert(float,LPMaxUS) end as LPMaxUS," _
			& "case when LPMaxUnitUS is null then '' else LPMaxUnitUS end as LPMaxUnitUS," _
			& "case when LPMinMetric is null then 0 else convert(float,LPMinMetric) end as LPMinMetric," _
			& "case when LPMinUnitMetric is null then '' else LPMinUnitMetric end as LPMinUnitMetric," _
			& "case when LPMaxMetric is null then 0 else convert(float,LPMaxMetric) end as LPMaxMetric," _
			& "case when LPMaxUnitMetric is null then '' else LPMaxUnitMetric end as LPMaxUnitMetric from 
			v_AssemblyLinerProj where wono=" & evar(ewo, 1)
		dt = GetDataTable(query)
		If dt.Rows.Count > 0 Then
			rpt_liner.DataSource = dt
			rpt_liner.DataBind()
		End If
	End Sub

	Protected Sub rpt_liner_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
		If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
			'Buat ngambil datanya...
			Dim dataItem As DataRowView = CType(e.Item.DataItem, DataRowView)

			'deklarasi Object
			Dim lCylNo As HtmlGenericControl = CType(e.Item.FindControl("lCylNo"), HtmlGenericControl)
			Dim lSpec As HtmlGenericControl = CType(e.Item.FindControl("lSpec"), HtmlGenericControl)

			Dim tA As TextBox = CType(e.Item.FindControl("tA"), TextBox)
			Dim tB As TextBox = CType(e.Item.FindControl("tB"), TextBox)
			Dim tC As TextBox = CType(e.Item.FindControl("tC"), TextBox)
			Dim tD As TextBox = CType(e.Item.FindControl("tD"), TextBox)
			Dim tSum As TextBox = CType(e.Item.FindControl("tSum"), TextBox)
			Dim tAvg As TextBox = CType(e.Item.FindControl("tAvg"), TextBox)
			Dim tMax As TextBox = CType(e.Item.FindControl("tMax"), TextBox)
			Dim tMin As TextBox = CType(e.Item.FindControl("tMin"), TextBox)
			Dim tVar As TextBox = CType(e.Item.FindControl("tVar"), TextBox)

			'input data ke object
			lCylNo.InnerText = "Cylinder No." & dataItem("CylinderNo").ToString()
			Dim especUS As String = dataItem("LPMinUS").ToString() & dataItem("LPMinUnitUS").ToString() & " - " & dataItem("LPMaxUS").ToString() & dataItem("LPMaxUnitUS").ToString()
			Dim eSpecMetric As String = dataItem("LPMinMetric").ToString() & dataItem("LPMinUnitMetric").ToString() & " - " & dataItem("LPMaxMetric").ToString() & dataItem("LPMaxUnitMetric").ToString()
			lSpec.InnerHtml = "Spesifications: <br />" & especUS & "<br />" & eSpecMetric

			tA.Text = dataItem("LPA").ToString()
			tB.Text = dataItem("LPB").ToString()
			tC.Text = dataItem("LPC").ToString()
			tD.Text = dataItem("LPD").ToString()
			tSum.Text = dataItem("SumLP").ToString()
			tAvg.Text = dataItem("AVGLP").ToString()
			tMax.Text = dataItem("MaxVal").ToString()
			tMin.Text = dataItem("MinVal").ToString()
			tVar.Text = dataItem("VarValue").ToString()

			';later...
		End If
	End Sub

	Sub load_2()
		If ewo = String.Empty Then Exit Sub

		Dim html As New StringBuilder()
		Dim datastring As String = ""
		Dim datastringsub As String = ""
		Dim fullhtml As String = ""
		Dim stringhtml As String = ""
		Dim fID As String
		Dim eSpecUS As String
		Dim eSpecMetric As String
		Dim i As Integer = 0
		Dim ic As Integer = 0
		Dim ib As Integer = 0
		Dim query As String = "with tempQuery as" _
		& "(" _
			& "select ROW_NUMBER() over (PARTITION BY v_AssemblyLinerProj.WONO ORDER BY CylinderNo) row,wono," _
			& "CylinderNo,LPA,LPB,LPC,LPD,MaxVal,MinVal,VarValue,SumLP,AvgLP,LPMinUS,LPMaxUS,LPMaxAVGUS,LPMaxAVGUnitUS,LPMaxAVGMetric,LPMAXAVGUnitMetric from v_AssemblyLinerProj where wono=" & evar(ewo, 1) & "" _
		& ") " _
		& "select " _
			& "a.wono," _
			& "a.CylinderNo," _
			& "case when a.avgLP is null then '' else a.AvgLP end as AVGLP," _
			& "case when (b.AvgLp - isnull(a.avgLp,0)) is null then '' else round((b.AvgLp - isnull(a.avgLp,0)),4) end as VarAVGLP," _
			& "a.LPMaxAVGUS,a.LPMaxAVGUnitUS,a.LPMaxAVGMetric,a.LPMAXAVGUnitMetric " _
		& "from " _
			& "tempQuery a " _
			& "left join tempQuery b " _
			& "on " _
			& "a.wono=b.wono and " _
			& "a.row=b.row+1"
		Dim connstr As String = connString
		Dim cn As New SqlConnection(connString)
		Dim cn2 As New SqlConnection(connString)
		cn.Open()
		cn2.Open()
		Dim cm As New SqlCommand(query, cn)
		Dim cm2 As New SqlCommand(query, cn2)
		Dim rd As SqlDataReader = cm.ExecuteReader
		Dim rd2 As SqlDataReader = cm2.ExecuteReader

		While rd.Read()
			ic = ic + 1
		End While

		ib = 0
		While rd2.Read()
			i = i + 1
			ib = ib + 1

			eSpecUS = rd2.Item("LPMaxAVGUS").ToString + rd2.Item("LPMaxAVGUnitUS").ToString
			eSpecMetric = rd2.Item("LPMaxAVGMetric").ToString + rd2.Item("LPMAXAVGUnitMetric").ToString

			datastring = "<tr>" _
							& "<td style=""vertical-align:middle"">AVG " & rd2.Item("CylinderNo").ToString & "</td>" _
							& "<td style=""vertical-align:middle""><input ReadOnly=""True"" type=""number"" class=""form-control form-control-sm"" value=""" + rd2.Item("AVGLP").ToString + """></td>" _
						& "</tr>"

			If i = 2 Then
				datastringsub = datastring
				If ib = ic Then
					datastring = datastring _
							& "<tr style=""font-weight:bold;"">" _
								& "<td style=""vertical-align:middle"">Variation</td>" _
								& "<td style=""vertical-align:middle""><input ReadOnly=""True"" type=""number"" class=""form-control form-control-sm"" value=""" + rd2.Item("VARAVGLP").ToString + """></td>" _
							& "</tr>"
				Else
					datastring = datastring _
							& "<tr style=""font-weight:bold;"">" _
								& "<td style=""vertical-align:middle"">Variation</td>" _
								& "<td style=""vertical-align:middle""><input ReadOnly=""True"" type=""number"" class=""form-control form-control-sm"" value=""" + rd2.Item("VARAVGLP").ToString + """></td>" _
							& "</tr>" _
							& datastringsub
				End If

				i = 1
				datastringsub = ""
			End If

			stringhtml = String.Concat(stringhtml, datastring)
		End While

		fullhtml = "<table class=""table table-condensed font-size-10 gridview"">" & stringhtml & "</table>"
		html.Append(fullhtml)
		ph.Controls.Add(New Literal() With {
			.Text = html.ToString()
		})

		cn.Close()
		cm.Connection.Close()
		cm.Connection.Dispose()
		cn2.Close()
		cm2.Connection.Close()
		cm2.Connection.Dispose()
	End Sub

	Sub load_3()
		If ewo = String.Empty Then Exit Sub

		Dim html As New StringBuilder()
		Dim datastring As String = ""
		Dim fullhtml As String = ""
		Dim stringhtml As String = ""
		Dim fID As String
		Dim eSpecUS As String
		Dim eSpecMetric As String
		Dim ic As Integer = 0

		Dim query As String = "select CylinderNo,LPMaxFinalUS,LPMaxFinalUnitUS,LPMaxFinalMetric,LPMaxFinalUnitMetric from v_AssemblyLinerProj where wono=" & evar(ewo, 1) & ""

		Dim query2 As String = "with tempQuery as" _
								& "(" _
									& "select ROW_NUMBER() over (PARTITION BY v_AssemblyLinerProj.WONO ORDER BY CylinderNo) row,wono," _
									& "CylinderNo,LPA,LPB,LPC,LPD,MaxVal,MinVal,VarValue,SumLP,AvgLP,LPMinUS,LPMaxUS from v_AssemblyLinerProj where wono=" & evar(ewo, 1) & "" _
								& ") " _
								& "select " _
									& "case when max(b.AvgLp - isnull(a.avgLp,0)) is null then '' else max(b.AvgLp - isnull(a.avgLp,0)) end as MaxAVGLP," _
									& "case when min(b.AvgLp - isnull(a.avgLp,0)) is null then '' else min(b.AvgLp - isnull(a.avgLp,0)) end as MinAVGLP," _
									& "case when ((max(b.AvgLp - isnull(a.avgLp,0))) - (min(b.AvgLp - isnull(a.avgLp,0)))) is null then '' else ((max(b.AvgLp - isnull(a.avgLp,0))) - (min(b.AvgLp - isnull(a.avgLp,0)))) end as Variation " _
								& "from " _
									& "tempQuery a " _
									& "left join tempQuery b " _
									& "on " _
									& "a.wono=b.wono and " _
									& "a.row=b.row+1"

		Dim connstr As String = connString
		Dim cn As New SqlConnection(connString)
		Dim cn2 As New SqlConnection(connString)
		cn.Open()
		cn2.Open()
		Dim cm As New SqlCommand(query, cn)
		Dim cm2 As New SqlCommand(query2, cn2)
		Dim rd As SqlDataReader = cm.ExecuteReader
		Dim rd2 As SqlDataReader = cm2.ExecuteReader

		While rd.Read()
			ic = ic + 1
			eSpecUS = rd.Item("LPMaxFinalUS").ToString + rd.Item("LPMaxFinalUnitUS").ToString
			eSpecMetric = rd.Item("LPMaxFinalMetric").ToString + rd.Item("LPMaxFinalUnitMetric").ToString
		End While

		While rd2.Read()

			datastring = "<tr>" _
							& "<td style=""vertical-align:middle"">Max AVG 1 - " + ic.ToString + "</td>" _
							& "<td style=""vertical-align:middle""><input ReadOnly=""True"" type=""number"" class=""form-control input-sm"" value=""" + rd2.Item("MaxAVGLP").ToString + """></td>" _
						& "</tr>" _
						& "<tr>" _
							& "<td style=""vertical-align:middle"">Min AVG 1 - " + ic.ToString + "</td>" _
							& "<td style=""vertical-align:middle""><input ReadOnly=""True"" type=""number"" class=""form-control input-sm"" value=""" + rd2.Item("MinAVGLP").ToString + """></td>" _
						& "</tr>" _
						& "<tr style=""font-weight:bold;"">" _
							& "<td style=""vertical-align:middle"">Variation</td>" _
							& "<td style=""vertical-align:middle""><input ReadOnly=""True"" type=""number"" class=""form-control input-sm"" value=""" + rd2.Item("Variation").ToString + """></td>" _
						& "</tr>"

			stringhtml = String.Concat(stringhtml, datastring)
		End While

		fullhtml = "<table class=""table table-condensed font-size-10 gridview"">" & stringhtml & "</table>"
		html.Append(fullhtml)
		ph1.Controls.Add(New Literal() With {
			.Text = html.ToString()
		})

		cn.Close()
		cm.Connection.Close()
		cm.Connection.Dispose()
		cn2.Close()
		cm2.Connection.Close()
		cm2.Connection.Dispose()
	End Sub

	Sub load_progress()
		If ewo = String.Empty Then Exit Sub

		Dim dt As New DataTable
		Dim query As String = "select LP_Perc from tmp_InsPartassemblycount where wono=" & evar(ewo, 1)
		dt = GetDataTable(query)
		If dt.Rows.Count > 0 Then
			pSectionProg.Style("width") = dt.Rows(0)("LP_Perc") & "%"
			lSectionProg.InnerText = "Overall Progress (" & dt.Rows(0)("LP_Perc") & "%)"
		End If
	End Sub

	Protected Sub bSave_Click(sender As Object, e As EventArgs)
		If ewo = String.Empty Then Exit Sub

		Dim bSave As LinkButton = DirectCast(sender, LinkButton)
		Dim cylinderNo As String = CType(sender, LinkButton).CommandArgument
		Dim item As RepeaterItem = DirectCast(bSave.NamingContainer, RepeaterItem)

	End Sub

	Protected Sub rpt_liner_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
		If e.CommandName = "Update" Then
			Dim cylinderNo As String = Convert.ToString(e.CommandArgument)
			Dim tA As String = CType(e.Item.FindControl("tA"), TextBox).Text
			Dim tB As String = CType(e.Item.FindControl("tB"), TextBox).Text
			Dim tC As String = CType(e.Item.FindControl("tC"), TextBox).Text
			Dim tD As String = CType(e.Item.FindControl("tD"), TextBox).Text

			Dim query_A As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'LPA'," & evar(tA, 1) & "," & eByName()
			executeQuery(query_A)

			Dim query_B As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'LPB'," & evar(tB, 1) & "," & eByName()
			executeQuery(query_B)

			Dim query_C As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'LPC'," & evar(tC, 1) & "," & eByName()
			executeQuery(query_C)

			Dim query_D As String = "exec AssemblyUpdateEngineInput " & evar(ewo, 1) & "," & evar(cylinderNo, 1) & ",'LPD'," & evar(tD, 1) & "," & eByName()
			executeQuery(query_D)

			showAlert("success", "Data Saved Successfully")
			load_1()
			load_2()
			load_3()
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