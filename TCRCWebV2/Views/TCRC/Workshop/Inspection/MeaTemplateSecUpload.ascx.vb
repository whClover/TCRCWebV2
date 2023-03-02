Imports System.IO
Imports DocumentFormat.OpenXml.Wordprocessing
Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility

Public Class MeaTemplateSecUpload
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bUpload_Click(sender As Object, e As EventArgs)
        Dim eid As String = Request.QueryString("id")

        If eid = String.Empty Then
            Exit Sub
        End If

        Dim extension As String = System.IO.Path.GetExtension(Me.dUpload.FileName)
        If extension = ".txt" Then
        Else
            'showtoast(Page, "Please select text files (*.txt)", "Notification", "warning", False, "toast-bottom-full-width", False)
            Exit Sub
        End If

        Dim filenum As Integer = FreeFile()
        Dim kSectionName As String = String.Empty
        Dim kSubSectionName As String = String.Empty
        Dim kItemDesc As String = String.Empty
        Dim kLoopCount As String = String.Empty
        Dim kValType As String = String.Empty
        Dim kSeqSection As String = String.Empty
        Dim kSeqSubSection As String = String.Empty
        Dim kSeqItem As String = String.Empty
        Dim kCostumColumn As String = String.Empty

        Dim esectionname As String = String.Empty
        Dim esubsectionname As String = String.Empty
        Dim eitemdesc As String = String.Empty
        Dim eloopcount As String = String.Empty
        Dim evaltype As String = String.Empty
        Dim eSeqSection As String = String.Empty
        Dim eSeqSubSection As String = String.Empty
        Dim eSeqItem As String = String.Empty
        Dim eCostumColumn As String = String.Empty

        Dim curtime = CStr(DateTime.Now.ToString("yyyyMMddhhmmss"))
        Dim savepath As String = Environ("temp") + "\Insp" + curtime + ".txt"

        'Try
        If dUpload.HasFile = False Then
            Exit Sub
        Else
            Me.dUpload.SaveAs(savepath)
        End If

        FileOpen(filenum, savepath, OpenMode.Input)
        Dim i As Integer = 0

        Dim eLineInput As String = String.Empty
        Dim eLa As String = String.Empty
        Do Until EOF(filenum)
            eLineInput = LineInput(filenum)
            eLa = eLineInput
            If i = 0 Then
                Dim hea As String() = eLa.Split(New Char() {vbTab})
                For h = 0 To UBound(hea)

                    If hea(h) = "SectionName" Then
                        kSectionName = h
                    ElseIf hea(h) = "SubSectionName" Then
                        kSubSectionName = h
                    ElseIf hea(h) = "ItemDesc" Then
                        kItemDesc = h
                    ElseIf hea(h) = "LoopCount" Then
                        kLoopCount = h
                    ElseIf hea(h) = "ValType" Then
                        kValType = h
                    ElseIf hea(h) = "SeqSection" Then
                        kSeqSection = h
                    ElseIf hea(h) = "SeqSubSection" Then
                        kSeqSubSection = h
                    ElseIf hea(h) = "SeqItem" Then
                        kSeqItem = h
                    ElseIf hea(h) = "CostumeColumn" Then
                        kCostumColumn = h
                    End If

                Next

                If kSectionName = String.Empty Then
                    'showtoast(Page, "Not Valid Format. Column ""SectionName"" is Not Found", "Notification", "warning", False, "toast-bottom-full-width", False)
                    lerror.Text = "Not Valid Format. Column ""SectionName"" is Not Found"
                    Exit Sub
                End If

                If kSubSectionName = String.Empty Then
                    'showtoast(Page, "Not Valid Format. Column ""SubSectionName"" is Not Found", "Notification", "warning", False, "toast-bottom-full-width", False)
                    lerror.Text = "Not Valid Format. Column ""SubSectionName"" is Not Found"
                    Exit Sub
                End If

                If kItemDesc = String.Empty Then
                    'showtoast(Page, "Not Valid Format. Column ""ItemDesc"" is Not Found", "Notification", "warning", False, "toast-bottom-full-width", False)
                    lerror.Text = "Not Valid Format. Column ""ItemDesc"" is Not Found"
                    Exit Sub
                End If

                If kLoopCount = String.Empty Then
                    'showtoast(Page, "Not Valid Format. Column ""LoopCount"" is Not Found", "Notification", "warning", False, "toast-bottom-full-width", False)
                    lerror.Text = "Not Valid Format. Column ""LoopCount"" is Not Found"
                    Exit Sub
                End If

                If kValType = String.Empty Then
                    'showtoast(Page, "Not Valid Format. Column ""ValType"" is Not Found", "Notification", "warning", False, "toast-bottom-full-width", False)
                    lerror.Text = "Not Valid Format. Column ""ValType"" is Not Found"
                    Exit Sub
                End If

                If kSeqSection = String.Empty Then
                    'showtoast(Page, "Not Valid Format. Column ""SeqSection"" is Not Found", "Notification", "warning", False, "toast-bottom-full-width", False)
                    lerror.Text = "Not Valid Format. Column ""SeqSection"" is Not Found"
                    Exit Sub
                End If

                If kSeqSubSection = String.Empty Then
                    'showtoast(Page, "Not Valid Format. Column ""SeqSubSection"" is Not Found", "Notification", "warning", False, "toast-bottom-full-width", False)
                    lerror.Text = "Not Valid Format. Column ""SeqSubSection"" is Not Found"
                    Exit Sub
                End If

                If kSeqItem = String.Empty Then
                    'showtoast(Page, "Not Valid Format. Column ""SeqItem"" is Not Found", "Notification", "warning", False, "toast-bottom-full-width", False)
                    lerror.Text = "Not Valid Format. Column ""SeqItem"" is Not Found"
                    Exit Sub
                End If

                If kCostumColumn = String.Empty Then
                    lerror.Text = "Not Valid Format. Column ""CostumeColumn"" is Not Found"
                    Exit Sub
                End If
            Else
                Dim data As String() = eLa.Split(New Char() {vbTab})

                If kSectionName = String.Empty Then
                    GoTo skipp
                Else
                    esectionname = Utility.evar(data(kSectionName), 1)
                End If
                If kSubSectionName = String.Empty Then esubsectionname = "NULL" Else esubsectionname = Utility.evar(data(kSubSectionName), 1)
                If kItemDesc = String.Empty Then eitemdesc = "NULL" Else eitemdesc = Utility.evar(data(kItemDesc), 1)
                If kLoopCount = String.Empty Then eloopcount = "NULL" Else eloopcount = Utility.evar(data(kLoopCount), 1)
                If kValType = String.Empty Then evaltype = "NULL" Else evaltype = Utility.evar(data(kValType), 1)
                If kSeqSection = String.Empty Then eSeqSection = "NULL" Else eSeqSection = Utility.evar(data(kSeqSection), 1)
                If kSeqSubSection = String.Empty Then eSeqSubSection = "NULL" Else eSeqSubSection = Utility.evar(data(kSeqSubSection), 1)
                If kSeqItem = String.Empty Then eSeqItem = "NULL" Else eSeqItem = Utility.evar(data(kSeqItem), 1)
                If kCostumColumn = String.Empty Then eCostumColumn = "NULL" Else eCostumColumn = Utility.evar(data(kCostumColumn), 1)

                Dim tempstring = "exec dbo.InspUploadTemplate " & eid & "," & esectionname & "," & esubsectionname _
                                    & "," & eitemdesc & "," & eloopcount & "," & evaltype & "," & eSeqSection & "," & eSeqSubSection _
                                    & "," & eSeqItem & "," & eCostumColumn & "," & eByName()
                MsgBox(tempstring)

                Try
                    executeQuery(tempstring)
                Catch ex As Exception
                    'showtoast(Page, ex.Message & " (line " & CType(i, String) & ")", "Notification", "warning", False, "toast-bottom-full-width", False)
                    Exit Sub
                End Try
            End If

skipp:
            i = i + 1
        Loop

        FileClose(filenum)
        File.Delete(savepath)
        'load_Section()
        'Catch ex As Exception
        'err_handler(GetCurrentPageName(), GetCurrentMethodName, ex.Message)
        'End Try
    End Sub
End Class