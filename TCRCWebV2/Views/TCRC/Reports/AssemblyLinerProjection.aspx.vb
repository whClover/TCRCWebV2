Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports System.Data.SqlClient

Public Class AssemblyLinerProjection
    Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If IsPostBack = False Then
			getHeader()
			bindingdata()
		End If
	End Sub

	Sub getHeader()
		Dim ewo As String = Request.QueryString("wo")
		If ewo = String.Empty Then Exit Sub

		Dim dt As New DataTable
		Dim query As String = "select * from v_IntJobDetailRev3 where wono=" & evar(ewo, 1)
		dt = GetDataTable(query)
		If dt.Rows.Count > 0 Then
			lwono.Text = CheckDBNull(dt.Rows(0)("WONo"))
			lunitno.Text = CheckDBNull(dt.Rows(0)("UnitNumber"))
			lwodesc.Text = CheckDBNull(dt.Rows(0)("WODesc"))
			lunitdesc.Text = CheckDBNull(dt.Rows(0)("UnitDescription"))
			lcomp.Text = CheckDBNull(dt.Rows(0)("ComponentGroup"))
		End If
	End Sub

	Sub bindingdata()
		Dim ewo As String = Request.QueryString("wo")
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
			& "case when LPMaxUnitMetric is null then '' else LPMaxUnitMetric end as LPMaxUnitMetric from" _
			& " v_AssemblyLinerProj where wono=" & evar(ewo, 1) & " order by CylinderNo"
		dt = GetDataTable(query)
		rpt_liner.DataSource = dt
		rpt_liner.DataBind()
	End Sub

	Protected Function getLastModBy(ByVal CylinderDesc As String, ByVal CylinderNo As String)
		Dim ewo As String = Request.QueryString("wo")
		If ewo = String.Empty Then Exit Function

		Dim res As String = "#"
		Dim dt As New DataTable
		Dim query As String = "select dbo.GetAssemblyByEngine(" & evar(ewo, 1) & "," & evar(CylinderNo, 1) & "," & evar(CylinderDesc, 1) & ") as res"
		dt = GetDataTable(query)
		res = GetDataFromColumn(dt, "res")

		Return res
	End Function
End Class