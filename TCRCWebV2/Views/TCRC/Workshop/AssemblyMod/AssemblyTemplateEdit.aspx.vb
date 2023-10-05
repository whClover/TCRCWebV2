Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports Microsoft.SqlServer.Server

Public Class AssemblyTemplateEdit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            bindingdata()
            loadpicture()
            bindingdataspec()
        End If
    End Sub

    Sub bindingdata()
        Dim dt As New DataTable
        Dim eid As String = Request.QueryString("id")
        Dim eidgp As String = Request.QueryString("idgp")
        If eidgp <> String.Empty Then GoTo newdata
        If eid = String.Empty Then Exit Sub
        Dim query As String = "select *,convert(varchar,registerdate,103) as frmregdate, convert(varchar,moddate,103) as frmmoddate
        from v_assemblytemplatedetailRev where IDTemplateAssembly=" & evar(eid, 0)
        dt = GetDataTable(query)

        sTemplateName.InnerText = GetDataFromColumn(dt, "AssemblyGroupName")
        sIDGP.InnerText = GetDataFromColumn(dt, "IDTemplateAssemblyGroup")
        sIDDetal.InnerText = GetDataFromColumn(dt, "IDTemplateAssembly")

        tRegBy.InnerText = GetDataFromColumn(dt, "RegisterBy")
        tRegDate.InnerText = GetDataFromColumn(dt, "frmregdate")
        tModBy.InnerText = GetDataFromColumn(dt, "ModBy")
        tModDate.InnerText = GetDataFromColumn(dt, "frmmoddate")

        tsection.Text = GetDataFromColumn(dt, "AssemblySection")
        tseq.Text = GetDataFromColumn(dt, "Sequence")
        summernote.InnerHtml = GetDataFromColumn(dt, "AssemblyDesc")
        ddvaltype.SelectedValue = GetDataFromColumn(dt, "ValType")
        ddInstrucType.SelectedValue = GetDataFromColumn(dt, "InstructionType")

        If ddvaltype.SelectedValue <> "2" Then
            baddpec.Visible = False
        End If
        Exit Sub

newdata:
        Dim esection As String = Request.QueryString("section")
        Dim dtnew As New DataTable
        Dim querynew As String = "select * from v_assemblytemplatedetailRev where IDTemplateAssemblyGroup=" & eidgp & " and AssemblySection=" & evar(esection, 1)
        dtnew = GetDataTable(querynew)
        sIDGP.InnerText = GetDataFromColumn(dtnew, "IDTemplateAssemblyGroup")
        tsection.Text = esection
    End Sub

    Sub bindingdataspec()
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        Dim eidgp As String = sIDGP.InnerText
        Dim query As String = "Select IDSpec,Spec,Tolerance,Unit,case when UnitType=1 then 'Metrik' else 'US' end As UnitType from 
            tbl_AssemblySpec where IDTemplateAssemblyGroup=" & eidgp & " and IDTemplateAssembly=" & eid & " and Active=1"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        gvspec.DataSource = dt
        gvspec.DataBind()
    End Sub

    Sub loadpicture()
        Dim eid As String = Request.QueryString("id")
        Dim eidgp As String = sIDGP.InnerText
        Dim esection As String = tsection.Text
        If eid = String.Empty Then Exit Sub

        'Picture Group
        Dim query As String = "select case when('../../../../' + dbo.RemapPicW(PicturePath)) is null then '../../../../assets/images/NoPicture.png' 
            else ('../../../../' + dbo.RemapPicW(PicturePath)) end as PicturePathGroup from v_AssemblyTemplateDetailRev 
            where AssemblySection=" & evar(esection, 1) & " and IDTemplateAssemblyGroup=" & eidgp
        Dim dt As New DataTable
        dt = GetDataTable(query)
        imgGp.Src = GetDataFromColumn(dt, "PicturePathGroup")
        '++###################

        'Sub-Picture
        Dim query2 As String = "select case when('../../../../' + dbo.RemapPicW(SubPicture)) is null then '../../../../assets/images/NoPicture.png' 
            else ('../../../../' + dbo.RemapPicW(SubPicture)) end as SubPicture from v_AssemblyTemplateDetailRev where IDTemplateAssembly=" & eid
        Dim dt2 As New DataTable
        dt2 = GetDataTable(query2)
        img1.Src = GetDataFromColumn(dt2, "SubPicture")
    End Sub

    Protected Sub bclose_Click(sender As Object, e As EventArgs)
        Dim eidgp As String = sIDGP.InnerText
        Response.Redirect(urlAssemblyTemplateDetails & "?id=" & eidgp)
    End Sub

    Protected Sub bsave_Click(sender As Object, e As EventArgs)
        Dim eid As String = Request.QueryString("id")
        Dim eidgp As String = sIDGP.InnerText
        Dim ins As String
        If eid = String.Empty Then
            ins = "'Add'"
            eid = "0"
        Else
            ins = "'Edit'"
        End If

        If tseq.Text = String.Empty Then
            genSwalAlert("warning", "Please fill Sequence", Me)
            Exit Sub
        End If

        If tsection.Text = String.Empty Then
            genSwalAlert("warning", "Please fill Section", Me)
            Exit Sub
        End If

        If summernote.InnerHtml = String.Empty Then
            genSwalAlert("warning", "Please fill Section", Me)
            Exit Sub
        End If

        If ddvaltype.Text = String.Empty Then
            genSwalAlert("warning", "Please Select Value Type", Me)
            Exit Sub
        End If

        Dim eseq, esection, edesc, evaltype, einsttype, espec, easmunit, etolerance As String
        eseq = evar(tseq.Text, 1)
        esection = evar(tsection.Text,1)
        edesc = evar(summernote.Value, 1)
        evaltype = evar(ddvaltype.SelectedValue, 1)
        einsttype = evar(ddInstrucType.SelectedValue, 1)
        espec = evar("NULL", 0)
        easmunit = evar("NULL", 0)
        etolerance = evar("NULL", 0)

        Dim query As String = "exec dbo.AssemblyTemplateSubmitRev " & eid & "," & eidgp & ",
        " & eseq & "," & esection & "," & edesc & "," & evaltype & ",
        " & espec & "," & easmunit & "," & etolerance & ",NULL," & eByName() & "," & ins & ",1," & einsttype & ""

        'qrychk.InnerText = query
        'qrychk.Visible = True
        executeQuery(query)
        genSwalAlert("success", "Saved", Me)

        bindingdata()
        loadpicture()
    End Sub

    Protected Sub bdelspec_Click(sender As Object, e As EventArgs)
        Dim eidspec As String = CType(sender, LinkButton).CommandArgument
        Dim query As String = "update tbl_AssemblySpec set Active=0 where IDSpec=" & eidspec
        executeQuery(query)

        genSwalAlert("success", "Data Spec has been delete", Me)
        bindingdataspec()
    End Sub

    Protected Sub baddpec_Click(sender As Object, e As EventArgs)
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        Dim eidgp As String = sIDGP.InnerText

        If ddunittype.Text = String.Empty Then
            genSwalAlert("warning", "Please select unit type", Me)
            Exit Sub
        End If

        If tspec.Text = String.Empty Then
            genSwalAlert("warning", "Please Fill Spec", Me)
            Exit Sub
        End If

        If ttolerance.Text = String.Empty Then
            genSwalAlert("warning", "Please Fill Tolerance", Me)
            Exit Sub
        End If

        If tunit.Text = String.Empty Then
            genSwalAlert("warning", "Please Fill Unit", Me)
            Exit Sub
        End If

        Dim eunittype, espec, etolerance, eunit As String
        eunittype = evar(ddunittype.SelectedValue, 1)
        espec = evar(tspec.Text, 1)
        etolerance = evar(ttolerance.Text, 1)
        eunit = evar(tunit.Text, 1)
        Dim query As String = "exec dbo.AssemblySpecSubmit " & eidgp & "," & eid & "," & eUnitType & "," & eSpec & "," & eTolerance & "," & eUnit & "," & eByName() & ""
        executeQuery(query)

        genSwalAlert("success", "Saved", Me)
        bindingdataspec()
    End Sub

    Protected Sub bupload_Click(sender As Object, e As EventArgs)
        Dim eid As String = Request.QueryString("id")
        If eid = String.Empty Then Exit Sub
        Dim eidgp As String = sIDGP.InnerText
        If eidgp = String.Empty Then Exit Sub
        Dim fs = CreateObject("Scripting.FileSystemObject")
        Dim fpath As String = PICTAssemblyTemplate & "\" & eidgp

        If fileupload.HasFiles Then
            Dim fname As String = fileupload.FileName
            Dim fext As String = fs.GetExtensionName(fname)

            If fext = "JPG" Or fext = "jpg" Or fext = "png" Or fext = "JPEG" Then
                If Not System.IO.Directory.Exists(fpath) Then
                    System.IO.Directory.CreateDirectory(fpath)
                End If

                Dim newfile As String = fpath + fname
                fileupload.SaveAs(newfile)
                Dim query_upload As String = "update tbl_AssemblyTemplateRev set PicturePath=" & evar(newfile, 1) & " where IDTemplateAssembly=" & eid
                executeQuery(query_upload)
            End If
        End If

        genSwalAlert("success", "Picture has been uploaded", Me)
        loadpicture()
    End Sub
End Class