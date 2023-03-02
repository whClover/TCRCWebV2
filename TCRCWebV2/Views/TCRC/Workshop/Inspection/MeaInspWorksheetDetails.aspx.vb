Imports System.Data.SqlClient
Imports DocumentFormat.OpenXml.Drawing.Diagrams
Imports DocumentFormat.OpenXml.Office2010.PowerPoint
Imports Newtonsoft.Json.Serialization
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaInspWorksheetDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack = True Then
            first_load()
            generateProgress()
        End If
    End Sub

    Sub first_load()
        Dim ewo As String = Request.QueryString("wo")
        Dim etype As String = Request.QueryString("type")
        Dim query As String = "select distinct top 1(SectionName),SeqSection,PictureSection from v_InspDetail where wono=" & evar(ewo, 1) & " order by SeqSection"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            lTitle.Text = dt.Rows(0)(0)
            img.ImageUrl = dt.Rows(0)(2)
        End If

        If lTitle.Text = String.Empty Then Exit Sub
        Dim html As New StringBuilder
        Dim query2 As String = "exec dbo.[InspDetailSection] " & evar(ewo, 1) & "," & evar(lTitle.Text, 1) & "," & evar(etype, 1) & ""
        Dim dt2 As New DataTable
        dt2 = GetDataTable(query2)

        If dt2.Rows.Count > 0 Then
            html.Append(dt2.Rows(0)(0))
            ph_detail.Controls.Add(New Literal() With {
                .Text = html.ToString
            })
        End If

        load_Remark()
    End Sub

    Sub load_Section(ByVal SectionName)
        Dim ewo As String = Request.QueryString("wo")
        Dim etype As String = Request.QueryString("type")
        If ewo = String.Empty Then Exit Sub

        Dim dt As New DataTable
        Dim query As String = "select distinct top 1(SectionName),SeqSection,PictureSection from v_InspDetail where wono=" & evar(ewo, 1) & " and 
                            SectionName=" & evar(SectionName, 1) & " order by SeqSection"
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            img.ImageUrl = dt.Rows(0)(2)
            lTitle.Text = dt.Rows(0)(0)
        End If

        Dim dt2 As New DataTable
        Dim html As New StringBuilder
        Dim query2 As String = "exec dbo.[InspDetailSection] " & evar(ewo, 1) & "," & evar(SectionName, 1) & "," & evar(etype, 1) & ""
        dt2 = GetDataTable(query2)
        If dt2.Rows.Count > 0 Then
            html.Append(dt2.Rows(0)(0))
        End If

        ph_detail.Controls.Add(New Literal() With {
            .Text = html.ToString
        })

        load_Remark()
    End Sub

    Sub load_Remark()
        Dim ewo As String = Request.QueryString("wo")
        Dim esection As String = lTitle.Text

        Dim dt As New DataTable
        Dim query As String = "select Remark from v_InspRemark where wono=" & evar(ewo, 1) & " and InspSection=" & evar(esection, 1)
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            tRemark.Text = CheckDBNull(dt.Rows(0)(0))
        End If
    End Sub

    Sub generateProgress()
        Dim dt As New DataTable
        Dim eid As String = Request.QueryString("wo")
        Dim etype As String = Request.QueryString("type")
        If eid = String.Empty Then Exit Sub
        lhWO.InnerText = "WO." & eid
        lwo.InnerText = "WO." & eid

        Dim dt2 As New DataTable
        dt2 = GetDataTable("select WODesc from v_IntJobDetailRev3 where wono=" & evar(eid, 1))
        If dt2.Rows.Count > 0 Then
            lWODesc.InnerText = dt2.Rows(0)(0)
        End If

        'Dim query As String = "select dbo.CheckInspCompletion(" & evar(eid, 1) & ") as progWO"
        Dim query As String = "select * from tblv_InspSectionProgress(" & evar(eid, 1) & ")"
        dt = GetDataTable(Query)
        If dt.Rows.Count > 0 Then
            rptProgress.DataSource = dt
            rptProgress.DataBind()
        End If
    End Sub

    Protected Sub bShow_Click(sender As Object, e As EventArgs)
        Dim linkbutton As LinkButton = TryCast(sender, LinkButton)
        Dim SectionName As String = linkbutton.CommandArgument
        load_Section(SectionName)
    End Sub

    Protected Sub bBack_Click(sender As Object, e As EventArgs)
        Response.Redirect(urlMeasureWorksheet)
    End Sub

#Region "Action JS"
    <System.Web.Services.WebMethod()>
    Shared Function UpdateCheck(ByVal IDInsp As String) As Integer
        Try
            Dim query As String = "update tbl_InspInput set InspValue='Check',ModBy=" & eByName() & ",ModDate=GetDate() where IDInsp=" & IDInsp
            executeQuery(query)
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try

        Return 0
    End Function

    <System.Web.Services.WebMethod()>
    Shared Function fillJS(ByVal IDInsp As String, ByVal value As String) As Integer
        Try
            Dim query As String = "update tbl_InspInput set InspValue='" & value & "',ModBy=" & eByName() & ",ModDate=GetDate() where IDInsp=" & IDInsp
            executeQuery(query)
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try

        Return 0
    End Function


#End Region

    Protected Sub bSaveRemark_Click(sender As Object, e As EventArgs)
        'Dim ewo As String = Request.QueryString("wo")
        'Dim esection As String = evar(lTitle.Text, 1)
        'Dim eremark As String
        'If tRemark.Text = String.Empty Then
        '    showAlert("warning", "Please Input Remark")
        '    Exit Sub
        'Else
        '    eremark = evar(tRemark.Text, 1)
        'End If

        'Try
        '    'Dim query As String = "update tbl_InspSectionRemark set Remark=" & eremark & ",ModBy=" & eByName() & ",ModDate=GetDate()  
        '    '        where IDInspRemark=(select IDInspRemark from v_InspRemark where wono=" & evar(ewo, 1) & "
        '    '        and InspSection=" & esection & ")"
        '    'executeQuery(query)
        '    showAlert("success", "Remark Has Been Recorded")
        'Catch ex As Exception
        '    err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        'End Try
    End Sub

    Sub showAlert(ByVal type As String, ByVal msg As String)
        Dim script As String
        script = "toastr[""" & type & """](""" & msg & """);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "toamsg", script, True)
    End Sub

    Protected Sub rmksave_Click(sender As Object, e As EventArgs)
        Dim ewo As String = Request.QueryString("wo")
        Dim esection As String = evar(lTitle.Text, 1)
        Dim eremark As String
        If tRemark.Text = String.Empty Then
            showAlert("warning", "Please Input Remark")
            Exit Sub
        Else
            eremark = evar(tRemark.Text, 1)
        End If

        Try
            Dim query As String = "update tbl_InspSectionRemark set Remark=" & eremark & ",ModBy=" & eByName() & ",ModDate=GetDate()  
                    where IDInspRemark=(select IDInspRemark from v_InspRemark where wono=" & evar(ewo, 1) & "
                    and InspSection=" & esection & ")"
            executeQuery(query)
            showAlert("success", "Remark Has Been Recorded")
        Catch ex As Exception
            err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        End Try
    End Sub

    Protected Sub bMeaPrint_Click(sender As Object, e As EventArgs)
        Dim ewo As String = Request.QueryString("wo")
        Response.Redirect(urlMeasurePrint & "?wo=" & ewo)
    End Sub
End Class