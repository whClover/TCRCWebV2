Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Policy
Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Math
Imports DocumentFormat.OpenXml.VariantTypes
Imports Microsoft.Reporting.Map.WebForms.BingMaps
Imports Microsoft.Reporting.WebForms
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.SQLFunction

Public Class Utility
    Public Shared Function evar(ByVal val As Object, ByVal valtype As Integer, Optional vallen As Integer = 255) As String
        Dim eval As String

        val = Replace(val, """", "")
        val = Replace(val, "#N/A", "")
        val = LTrim(val)
        val = RTrim(val)


        If val Is vbNullString Then
            eval = "NULL"
        ElseIf CStr(val) = "" Then
            eval = "NULL"
        ElseIf CStr(val) = " " Then
            eval = "NULL"
        ElseIf CStr(val) = String.Empty Then
            eval = "NULL"
        Else
            val = Trim(val)
            Select Case valtype
                Case 0
                    'eval = val
                    If IsNumeric(val) = True Then
                        eval = val
                    Else
                        eval = "NULL"
                    End If
                Case 2
                    If IsDate(val) = False Then
                        eval = "NULL"
                    Else
                        val = CDate(val)
                        eval = "'" & DatePart("yyyy", val) & "-" & DatePart("m", val) & "-" & DatePart("d", val) & "'"
                    End If
                Case 3
                    If IsDate(val) = False Then
                        eval = "NULL"
                    Else
                        val = CDate(val)
                        eval = "'" & DatePart("yyyy", val) & "-" & DatePart("m", val) & "-" & DatePart("d", val) & " " & DatePart("h", val) & ":" & DatePart("n", val) & ":" & DatePart("s", val) & "'"
                    End If

                Case 4 : eval = "'" & Left(val, 3750) & "'"

                Case 11 : eval = "'%" & Left(val, vallen) & "%'"
                Case 12 : eval = "'" & Replace(val, ",", "','") & "'"
                Case 13 : eval = "'%," & Left(val, vallen) & ",%'"
                Case 14 : eval = "" & val & ""

                Case Else : eval = "'" & Left(val, vallen) & "'"


            End Select


        End If

        Return eval

    End Function

    Public Shared Sub BindDataDropDown(ByVal ObjName As DropDownList, ByVal query As String, ByVal ObjText As String, ByVal ObjVal As String)
        Dim dt As New DataTable
        dt = SQLFunction.GetDataTable(query)
        If dt.Rows.Count = 0 Then
            ObjName.Items.Clear()
            ObjName.Items.Insert(0, New ListItem("No Data Available !"))
        Else
            ObjName.DataSource = dt
            ObjName.DataTextField = ObjText
            ObjName.DataValueField = ObjVal
            Try
                ObjName.DataBind()
            Catch ex As Exception
                ObjName.Items.Insert(0, New ListItem(ObjText))
            End Try
            ObjName.Items.Insert(0, New ListItem(""))
        End If
    End Sub

    Public Shared Sub BindDataDropDownV2(ByVal ObjName As DropDownList, ByVal dt As DataTable, ByVal ObjText As String, ByVal ObjVal As String)
        If dt.Rows.Count = 0 Then
            ObjName.Items.Clear()
            ObjName.Items.Insert(0, New ListItem("No Data Available !"))
        Else
            ObjName.DataSource = dt
            ObjName.DataTextField = ObjText
            ObjName.DataValueField = ObjVal
            ObjName.DataBind()
            ObjName.Items.Insert(0, New ListItem(""))
        End If
    End Sub

    Public Shared Sub BindDataListBox(ByVal ObjName As ListBox, ByVal query As String, ByVal ObjText As String, ByVal ObjVal As String)
        Dim dt As New DataTable
        dt = SQLFunction.GetDataTable(query)
        ObjName.DataSource = dt
        ObjName.DataTextField = ObjText
        ObjName.DataValueField = ObjVal
        ObjName.DataBind()
    End Sub

    Public Shared Function ExportToExcelXML(ByVal str As String, ByVal title As String)

        Dim t As String = ""

        Try
            Dim dt As DataTable = SQLFunction.GetDataTable(str)
            Dim thetitle As String = title + ".xlsx"
            Using wb As New XLWorkbook()
                wb.Worksheets.Add(dt, title)
                HttpContext.Current.Response.Clear()
                HttpContext.Current.Response.Buffer = True
                HttpContext.Current.Response.Charset = ""
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + thetitle)

                Using MyMemoryStream As New MemoryStream()
                    wb.SaveAs(MyMemoryStream)
                    MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream)
                    HttpContext.Current.Response.Flush()
                    HttpContext.Current.Response.End()
                End Using
            End Using

        Catch ex As Exception
            t = ex.Message
        End Try

        Return t

    End Function

    'Private Function ExportData(ByVal dt As DataTable, ByVal filename As String)
    '    Dim workbook As New ClosedXML.Excel.XLWorkbook()
    '    Dim worksheet = workbook.Worksheets.Add("Data")
    '    Dim headerRow = worksheet.Row(1)
    '    headerRow.Style.Fill.BackgroundColor = XLColor.FromHtml("#2596be")
    '    headerRow.Style.Font.FontColor = XLColor.White
    '    headerRow.Style.Font.Bold = True
    '    Dim columnNumber As Integer = 1
    '    For Each column As DataColumn In dt.Columns
    '        worksheet.Cell(1, columnNumber).Value = column.ColumnName
    '        columnNumber += 1
    '    Next
    '    Dim rowNumber As Integer = 2
    '    For Each row As DataRow In dt.Rows
    '        columnNumber = 1
    '        For Each column As DataColumn In dt.Columns
    '            Dim value As Object = row(column.ColumnName)
    '            If column.DataType Is GetType(Integer) Then
    '                If Not IsDBNull(value) Then
    '                    worksheet.Cell(rowNumber, columnNumber).Value = Convert.ToInt32(value)
    '                End If
    '            Else
    '                If Not IsDBNull(value) Then
    '                    worksheet.Cell(rowNumber, columnNumber).Value = value.ToString()
    '                End If
    '            End If
    '            columnNumber += 1
    '        Next
    '        rowNumber += 1
    '    Next
    '    Response.Clear()
    '    Response.Buffer = True
    '    Response.Charset = ""
    '    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    '    Response.AddHeader("content-disposition", "attachment;filename=" & filename & ".xlsx")
    '    Using memoryStream As New System.IO.MemoryStream()
    '        workbook.SaveAs(memoryStream)
    '        memoryStream.WriteTo(Response.OutputStream)
    '        memoryStream.Close()
    '    End Using
    '    Response.Flush()
    '    Response.End()
    'End Function

    Public Shared Function errPicker(ByVal filename As String, ByVal errormsg As String)
        Dim str_Return As String

        str_Return = "<strong>Error Occured. Please Capture This Error and Send to TRahayu@thiess.co.id and MISetiawan@thiess.co.id</strong><br/> " _
                    & "Page: " & filename & "<br />" _
                    & "Error: " & errormsg

        Return str_Return
    End Function

    Private _page As Page
    Public Sub New(ByVal currentPage As Page)
        _page = currentPage
    End Sub
    Public Function ModalV1(ByVal url As String, Optional param1 As String = "", Optional param2 As String = "")
        Try
            Dim eParam As String = ""
            If param1 <> String.Empty Then eParam = eParam & "?" & param1
            If param2 <> String.Empty Then eParam = eParam & "&" & param2

            If Len(eParam) > 0 Then
                url = url & eParam
            End If

            Dim eJScript As String = "window.open('" & url & "','_blank'," & GlobalString.popupsize & ")"
            _page.ClientScript.RegisterStartupScript(_page.GetType(), "script", eJScript, True)
            Return 0
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ModalV2(ByVal fileName As String)
        _page.ClientScript.RegisterStartupScript(_page.GetType(), "showmodal", "$('#" & fileName & "').modal('show');", True)
        Return 0
    End Function

    Public Shared Function err_handler(ByVal pageName As String, ByVal subFun As String, ByVal err As String)
        HttpContext.Current.Response.Redirect(urlError & "?page=" & pageName & "&subfun=" & subFun & "&err=" & err)
    End Function

    Public Function ModalV1Error(ByVal pageName As String, ByVal subfun As String, ByVal errDesc As String)
        Try
            Dim modErorr As String = "~/Views/Shared/ErrorPage.aspx?page=" & pageName & "&err=" & errDesc & "subfun=" & subfun
            Dim eJScript As String = "window.open('" & modErorr & "','_blank'," & GlobalString.popupsize & ")"
            _page.ClientScript.RegisterStartupScript(_page.GetType(), "script", eJScript, True)
            Return 0
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function closeMe()
        Try
            _page.ClientScript.RegisterStartupScript(Me.GetType(), "closeTab", "window.close();", True)
            Return 0
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Shared Function IsSessionExist(ByVal sessionName As String) As Boolean
        If HttpContext.Current.Session(sessionName) Is Nothing Then
            HttpContext.Current.Response.Redirect(GlobalString.urlTCRCLogin)
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function eByName() As String
        Dim isDebug As String = "0"

        If IsSessionExist("ss_userid") Then
            eByName = evar(HttpContext.Current.Session("ss_username").ToString, 1)
            Return eByName
        Else
            Select Case isDebug
                Case "1"
                    eByName = evar("sys", 1)
                    Return eByName
                Case Else
                    HttpContext.Current.Response.Redirect(GlobalString.urlTCRCLogin)
                    Return 0
            End Select
        End If
    End Function

    Public Shared Function CheckDBNull(ByVal value As Object) As String
        If value Is DBNull.Value OrElse value Is Nothing Then
            Return "-"
        Else
            Return value
        End If
    End Function

    Public Shared Function CheckDBNullv1(ByVal value As Object) As String
        If value Is DBNull.Value OrElse value Is Nothing Then
            Return ""
        Else
            Return value
        End If
    End Function

    Public Shared Function GetCurrentPageName() As String
        Dim currentPage As Page = DirectCast(HttpContext.Current.Handler, Page)
        Return Path.GetFileName(currentPage.AppRelativeVirtualPath)
    End Function

    Public Shared Function GetCurrentMethodName() As String
        Dim st As New System.Diagnostics.StackTrace()
        Dim sf As System.Diagnostics.StackFrame = st.GetFrame(1)
        Return sf.GetMethod().Name
    End Function

    Public Shared Function CheckGroup(ByVal EmailTypeID As String) As Boolean
        CheckGroup = False

        Dim query, username As String

        If IsSessionExist("ss_username") = False Then
            HttpContext.Current.Response.Redirect(GlobalString.urlTCRCLogin)
            Return 0
        Else
            username = evar(HttpContext.Current.Session("ss_username").ToString, 1)
        End If

        If username = "'sys'" Then
            CheckGroup = True
            Exit Function
        End If

        query = "select ID,EmailTypeDesc from vw_UserPrivilegesEmailNotif where username=" & username & " and EmailTypeID=" & evar(EmailTypeID, 1) & ""

        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            CheckGroup = True
        Else
            CheckGroup = False
        End If
    End Function

    Public Shared Function templateNotif(ByVal caseID As Integer, ByVal val1 As String) As String
        templateNotif = ""
        Dim query As String = ""

        Select Case caseID
            'Check Email Group - Refer CheckGroup Function
            Case 1
                query = "select Description from tbl_EmailType where EmailTypeID=" & evar(val1, 1)
                Dim dt As New DataTable
                dt = GetDataTable(query)
                templateNotif = "You dont have access " & dt.Rows(0)(0)
            Case Else
                templateNotif = ""
        End Select
    End Function

    Public Function showAlert(ByVal msg As String)
        _page.ClientScript.RegisterStartupScript(_page.GetType, "closeTab", "alertify
        .alert(""" & msg & """, function(){});", True)

        Return 0
    End Function

    Public Shared Function IsLoggedIn(ByVal session As HttpSessionState, ByVal user As System.Security.Principal.IPrincipal) As Boolean
        'Check if session variable is set
        If session("UserID") IsNot Nothing AndAlso session("UserName") IsNot Nothing Then
            Return True
        End If

        'If session variable is not set, check if user is already authenticated
        If user.Identity.IsAuthenticated Then
            'Set session variables
            session("UserID") = user.Identity.Name
            session("UserName") = user.Identity.Name
            Return True
        End If

        Return False
    End Function

    Public Shared Function varfilter(F As String) As String
        If Len(F) > 0 Then varfilter = " WHERE " & Right(F, Len(F) - 4)
    End Function

    Public Shared Function generateRandom() As String
        Dim random As New Random()
        Dim length As Integer = 10 ' Panjang string yang diinginkan
        Dim sb As New StringBuilder()

        Dim possibleChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"

        For i As Integer = 0 To length - 1
            ' Mengambil karakter acak dari kumpulan karakter yang mungkin
            Dim randomChar As Char = possibleChars(random.Next(possibleChars.Length))
            sb.Append(randomChar)
        Next

        Dim randomString As String = sb.ToString()

        Return randomString
    End Function

    Public Shared Function genSwalAlert(ByVal type As String, ByVal msg As String, ByVal vpage As Page)
        Dim script As String
        script = "Swal.fire('','" & msg & "','" & type & "')"
        ScriptManager.RegisterStartupScript(vpage, vpage.GetType(), "Swal", script, True)
    End Function

    Public Shared Function StartWorkNoWO(ByVal eWorkStatusID As Integer, ByVal eShift As Integer, ByVal euserid As String, ByVal eJobNo As String)
        Dim dt As New DataTable
        Dim query As String = "Select WorkStatus,ISNULL(CostCode,0) as CostCode from tbl_TCRPWorkStatusSheet Where WOrkStatusID=" & eWorkStatusID
        dt = GetDataTable(query)

        Dim ecostcode As String = GetDataFromColumn(dt, "CostCode")
        Dim eActivityID As String = "NULL"
        Dim eIDWorkOrder As String = "NULL"
        Dim eSubCompID As String = "NULL"
        Dim eSubActivityID As String = "NULL"
        Dim eNote As String = "NULL"
        Dim eCLockType As String = "Web Apps"

        StartWorkAct(eWorkStatusID, euserid, eShift, ecostcode, eIDWorkOrder, eActivityID, eJobNo, eSubActivityID, eNote, eCLockType)
    End Function

    Public Shared Function StartWorkAct(ByVal eWorkStatusID As String, ByVal eUserID As String, ByVal eShift As String, ByVal eCostCode As String, ByVal eIDWorkOrder As String,
                                    ByVal eActivityID As String, ByVal ejobno As String, ByVal eSubActivityID As String, ByVal eNote As String, ByVal eCLockType As String)

        Dim query As String = "exec dbo.ClockInLabour1 " _
                                & evar(eUserID, 1) & "," _
                                & evar(eShift, 0) & "," _
                                & eWorkStatusID _
                                & "," & evar(eCostCode, 1) & "," _
                                    & eIDWorkOrder _
                                    & "," & eActivityID & "," _
                                    & evar(ejobno, 1) _
                                    & "," & eSubActivityID & "," _
                                    & eNote _
                                    & "," & evar(eCLockType, 1) _
                                    & "," & evar(eusername, 1)
        executeQuery(query)

    End Function

    Public Shared Function eusername() As String
        Dim t As String = HttpContext.Current.Request.LogonUserIdentity.Name.ToString()
        Dim n As String = InStr(t, "\")
        t = Right(t, Len(t) - n)

        Return t
    End Function
End Class