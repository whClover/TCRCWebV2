Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

Public Class AssemblyChk
    Inherits System.Web.UI.Page

    Dim ewo As String
    Dim utility As New Utility(Me)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ewo = Request.QueryString("wo")

        If IsPostBack = False Then
            loaddata()
            getsection()
            load_head()
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

    Sub loaddata()
        Dim firstSection As String = getfirst_Section()

        Dim dt2 As New DataTable
        Dim esection As String = String.Empty
        Dim query2 As String = "select SectionPart, case when('../../../../' + dbo.RemapPicW(PicturePath)) is null then '' else ('../../../../' + dbo.RemapPicW(PicturePath)) end as PicturePathGroup " _
                                & "from v_AssemblyCheckList where wono=" & evar(ewo, 1) & " and SectionPart=" & evar(firstSection, 1)
        dt2 = GetDataTable(query2)
        If dt2.Rows.Count > 0 Then
            imgGp.Src = dt2.Rows(0)("PicturePathGroup")
        End If

        lsection.InnerText = firstSection
        Dim dt As New DataTable
        Dim query As String = "select * from v_AssemblyCheckList where wono=" & evar(ewo, 1) & " and SectionPart=" & evar(firstSection, 1) & " Order By dbo.SequenceNum(Sequence),dbo.SequenceAlpha(Sequence),dbo.getsortval(Sequence,30,10), NoPict"
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            gv_chk.DataSource = dt
            gv_chk.DataBind()
        End If
        getPercProgress()
    End Sub

    Sub loadSection(ByVal sectionPart As String)
        lsection.InnerText = sectionPart

        'load picture group
        Dim dt_pict As New DataTable
        Dim querypict As String = "select case when('../../../../' + dbo.RemapPicW(PicturePath)) is null then '' else ('../../../../' + dbo.RemapPicW(PicturePath)) end as PicturePathGroup
        from v_AssemblyCheckList where wono=" & evar(ewo, 1) & " and SectionPart=" & evar(sectionPart, 1) & " Order By dbo.SequenceNum(Sequence),dbo.SequenceAlpha(Sequence),dbo.getsortval(Sequence,30,10), NoPict"
        dt_pict = GetDataTable(querypict)
        If dt_pict.Rows.Count > 0 Then
            imgGp.Src = dt_pict.Rows(0)("PicturePathGroup")
        End If

        Dim dt As New DataTable

        Dim query As String = "select * from v_AssemblyCheckList where wono=" & evar(ewo, 1) & " and SectionPart=" & evar(sectionPart, 1) & " Order By dbo.SequenceNum(Sequence),dbo.SequenceAlpha(Sequence),dbo.getsortval(Sequence,30,10), NoPict"
        dt = GetDataTable(query)
        gv_chk.DataSource = dt
        gv_chk.DataBind()
        getPercProgress()
    End Sub

    Function getfirst_Section()
        Dim firstSection As String
        Dim query As String = "Select top 1 SectionPart from v_AssemblyCheckList where wono=" & evar(ewo, 1)
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            firstSection = dt.Rows(0)("SectionPart")
        End If

        Return firstSection
    End Function

    Sub getsection()
        Dim query As String = "select SectionPart,SectionPart + ' = ' + convert(varchar(10),dbo.PercentCalc(SUM(CASE WHEN AssemblyBY IS NOT NULL THEN 1 ELSE 0 END), COUNT(IDInsDetail))) + '%' as SectionPartFull" _
                            & " from v_AssemblyCheckList Group By SectionPart,WONO Having wono=" & evar(ewo, 1) & " Order By dbo.PercentCalc(SUM(CASE WHEN AssemblyBY IS NOT NULL THEN 1 ELSE 0 END), COUNT(IDInsDetail)) Asc, SectionPart"
        BindDataDropDown(ddsection, query, "SectionPartFull", "SectionPart")
    End Sub

    Protected Sub ddsection_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim sectionName As String = ddsection.SelectedValue
        Dim dt As New DataTable
        lsection.InnerText = ddsection.SelectedValue
        Dim query As String = "select * from v_AssemblyCheckList where wono=" & evar(ewo, 1) & " and SectionPart=" & evar(sectionName, 1) & " Order By dbo.SequenceNum(Sequence),dbo.SequenceAlpha(Sequence),dbo.getsortval(Sequence,30,10), NoPict"
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            gv_chk.DataSource = dt
            gv_chk.DataBind()
        End If

        Dim dt2 As New DataTable
        Dim esection As String = String.Empty
        Dim query2 As String = "select SectionPart, case when('../../../../' + dbo.RemapPicW(PicturePath)) is null then '' else ('../../../../' + dbo.RemapPicW(PicturePath)) end as PicturePathGroup " _
                                & "from v_AssemblyCheckList where wono=" & evar(ewo, 1) & " and SectionPart=" & evar(sectionName, 1)
        dt2 = GetDataTable(query2)
        If dt2.Rows.Count > 0 Then
            imgGp.Src = dt2.Rows(0)("PicturePathGroup")
        End If
    End Sub

    Protected Sub bchk_Click(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gv_chk.Rows
            Dim cb As CheckBox = TryCast(row.FindControl("CheckBox1"), CheckBox)
            If cb IsNot Nothing AndAlso cb.Checked Then
                ' Do something with the checked checkbox
                Dim IDInsDetail As String = row.Cells(1).Text
                Dim query As String = "exec UpdateAssemblyCheckList " & IDInsDetail & "," & eByName()
                executeQuery(query)
            End If
        Next
        loadSection(ddsection.SelectedValue)
    End Sub

    Protected Sub bna_Click(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gv_chk.Rows
            Dim cb As CheckBox = TryCast(row.FindControl("CheckBox1"), CheckBox)
            If cb IsNot Nothing AndAlso cb.Checked Then
                ' Do something with the checked checkbox
                Dim IDInsDetail As String = row.Cells(1).Text
                Dim query As String = "exec UpdateAssemblyNA " & IDInsDetail & "," & eByName()
                executeQuery(query)
            End If
        Next
        loadSection(ddsection.SelectedValue)
    End Sub

    Sub getPercProgress()
        Dim dt As New DataTable
        Dim query As String = "Select * from tv_InsPartAssemblyCountRev() where wono=" & evar(ewo, 1)
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            pSectionProg.Style("width") = dt.Rows(0)("CheckSheetCompletion") & "%"
            lSectionProg.InnerText = "Overall Progress (" & dt.Rows(0)("CheckSheetCompletion") & "%)"
        End If
    End Sub

    Protected Sub gv_chk_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim assemblyBy As Object = DataBinder.Eval(e.Row.DataItem, "AssemblyBy")
                If assemblyBy IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(assemblyBy) Then
                    'e.Row.BackColor = System.Drawing.Color.White
                Else
                    e.Row.CssClass = "bg-soft-secondary"
                    'e.Row.BackColor = System.Drawing.Color.Red
                End If
            End If
        End If

        'If e.Row.RowType = DataControlRowType.Header Then
        '    For Each cell As TableCell In e.Row.Cells
        '        ' Hanya tambahkan filter jika kolom bukan kolom pertama (checkbox)
        '        If cell.Controls.Count > 0 AndAlso TypeOf cell.Controls(0) Is CheckBox Then
        '            Continue For
        '        End If

        '        ' Mendapatkan indeks kolom berdasarkan nama header
        '        Dim columnIndex As Integer = e.Row.Cells.GetCellIndex(cell)

        '        ' Tambahkan filter TextBox di atas setiap kolom
        '        Dim filterTextBox As New TextBox()
        '        filterTextBox.CssClass = "form-control form-control-sm"
        '        filterTextBox.Attributes("placeholder") = "Filter..."
        '        filterTextBox.Attributes("onkeyup") = "applyFilter(this, " & columnIndex & ");"

        '        ' Buat div kontainer untuk filter TextBox
        '        Dim filterContainer As New HtmlGenericControl("div")
        '        filterContainer.Attributes("style") = "position:relative;"
        '        filterContainer.Controls.Add(filterTextBox)

        '        ' Tambahkan div kontainer ke dalam sel
        '        cell.Controls.Add(filterContainer)
        '    Next
        'End If
    End Sub

    Protected Sub bremark_Click(sender As Object, e As EventArgs)
        Dim IDInsDetail As String = String.Empty
        For Each row As GridViewRow In gv_chk.Rows
            Dim cb As CheckBox = TryCast(row.FindControl("CheckBox1"), CheckBox)
            If cb IsNot Nothing AndAlso cb.Checked Then
                ' Do something with the checked checkbox
                IDInsDetail = IDInsDetail & row.Cells(1).Text & ","
            End If
        Next

        IDInsDetail = Left(IDInsDetail, Len(IDInsDetail) - 1)
        Dim hidinsdetail As HiddenField = DirectCast(AssemblyChkRemark.FindControl("hidinsdetail"), HiddenField)
        Dim hwono As HiddenField = DirectCast(AssemblyChkRemark.FindControl("hwono"), HiddenField)
        hidinsdetail.Value = IDInsDetail
        hwono.Value = Request.QueryString("wo")

        utility.ModalV2("MainContent_AssemblyChkRemark_Panel1")
    End Sub
End Class