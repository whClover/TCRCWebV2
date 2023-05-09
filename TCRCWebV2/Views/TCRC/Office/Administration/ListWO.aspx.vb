Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString
Imports System.IO
Imports DocumentFormat.OpenXml.Office2019.Drawing.Model3D

Public Class ListWO
    Inherits System.Web.UI.Page

    Dim utility As New Utility(Me)
    Dim tempfilter As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Initialize the page index to 0
            ViewState("PageIndex") = 0

            'Load the data for the first page
            LoadData()
            getlastupdate()
        End If
    End Sub

    Sub getlastupdate()
        Dim query As String = "select top 1 LastUpdateBy,LastUpdate from v_WODetailRev where Section='BSF.TCRP' order by LastUpdate desc"
        Dim dt As New DataTable
        dt = GetDataTable(query)
        If dt.Rows.Count > 0 Then
            pLastBy.InnerText = dt.Rows(0)("LastUpdateBy")
            pLastDate.InnerText = dt.Rows(0)("LastUpdate")
        End If
    End Sub

    Private Sub LoadData()
        filtering()
        'Set the page size to 30
        Dim pageSize As Integer = 30

        'Retrieve the data for the current page
        Dim query As String = "select * from v_WODetailRev" & tempfilter
        Dim dt As DataTable = GetDataTableV2(ViewState("PageIndex"), pageSize, query, "wono")

        'Bind the data to the GridView control
        gv_wodetails.DataSource = dt
        gv_wodetails.DataBind()

        'Enable or disable the "Previous" and "Next" buttons as appropriate
        bPrev.Enabled = (ViewState("PageIndex") > 0)
        bNext.Enabled = (dt.Rows.Count = pageSize)
    End Sub

    Private Sub filtering()
        If tWONo.Text <> String.Empty Then tempfilter = " and wono like " & evar(tWONo.Text, 11)
        If Len(tempfilter) <= 0 Then
            tempfilter = ""
        Else
            tempfilter = " where  " & Right(tempfilter, Len(tempfilter) - 4)
        End If
    End Sub

    Protected Sub bSearch_Click(sender As Object, e As EventArgs)
        filtering()
        LoadData()
    End Sub

    Protected Sub bNext_Click(sender As Object, e As EventArgs)
        'Increment the page index
        ViewState("PageIndex") = ViewState("PageIndex") + 1

        'Load the data for the new page
        LoadData()
    End Sub

    Protected Sub bPrev_Click(sender As Object, e As EventArgs)
        'Decrement the page index
        ViewState("PageIndex") = ViewState("PageIndex") - 1

        'Load the data for the new page
        LoadData()
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs)
        'Dim filename As String = Path.GetFileName(uploadfiles1.FileName)
        'uploadfiles1.SaveAs(Server.MapPath("~/uploads/") & filename)
        Dim ext As String = System.IO.Path.GetExtension(Me.uploadfiles1.FileName)
        If ext <> ".txt" Then
            showAlert("warning", "Invalid File Extension")
            Exit Sub
        End If

        Dim filenum As Integer = FreeFile()
        Dim kUnitDesc As String = String.Empty
        Dim kUnitNumber As String = String.Empty
        Dim kWONo As String = String.Empty
        Dim kWODesc As String = String.Empty
        Dim kWOStatus As String = String.Empty
        Dim kDocType As String = String.Empty
        Dim kPriority As String = String.Empty
        Dim kWOOrigin As String = String.Empty
        Dim kRepairType As String = String.Empty
        Dim kSpecRepCat As String = String.Empty
        Dim kAccDetail As String = String.Empty
        Dim kFailStatus As String = String.Empty
        Dim kSymptom As String = String.Empty
        Dim kRootCause As String = String.Empty
        Dim kLABy As String = String.Empty
        Dim kTradeGroup As String = String.Empty
        Dim kRequestedDate As String = String.Empty
        Dim kScheduleStartDate As String = String.Empty
        Dim kActualStartDate As String = String.Empty
        Dim kScheduledCompDate As String = String.Empty
        Dim kCompleteDate As String = String.Empty
        Dim kCompGroup As String = String.Empty
        Dim kMaintType As String = String.Empty
        Dim kSerialOn As String = String.Empty
        Dim kSerialOff As String = String.Empty
        Dim kCurrentMeter1 As String = String.Empty
        Dim kRepCompHours As String = String.Empty
        Dim kCostCode As String = String.Empty
        Dim kjobRepairLocation As String = String.Empty
        Dim kRepairSubLoc As String = String.Empty
        Dim kChargeToJob As String = String.Empty
        Dim kParentWO As String = String.Empty
        Dim kReference As String = String.Empty
        Dim kWarantyClaimNo As String = String.Empty
        Dim kWarrantyStatus As String = String.Empty
        Dim kWarrantySettDate As String = String.Empty
        Dim kProcStatus As String = String.Empty
        Dim kOriginator As String = String.Empty
        Dim kOriginatorDesc As String = String.Empty
        Dim kManager As String = String.Empty
        Dim kManagerDesc As String = String.Empty
        Dim kSupervisor As String = String.Empty
        Dim kSupervisorDesc As String = String.Empty
        Dim kAssignedTo As String = String.Empty
        Dim kAssignedToDesc As String = String.Empty
        Dim kCustomer As String = String.Empty
        Dim kEstLabHours As String = String.Empty
        Dim kEstDuration As String = String.Empty
        Dim kEstMatCost As String = String.Empty
        Dim kEstLaborCost As String = String.Empty
        Dim kEstOtherCost As String = String.Empty
        Dim kEstTotalCost As String = String.Empty
        Dim kActualLabHours As String = String.Empty
        Dim kActualDur As String = String.Empty
        Dim kActualMatCost As String = String.Empty
        Dim kActualLaborCost As String = String.Empty
        Dim kActualOtherCost As String = String.Empty
        Dim kActualTotalCost As String = String.Empty
        Dim kDocDate As String = String.Empty
        Dim kStatusComment As String = String.Empty
        Dim kWOType As String = String.Empty
        Dim kActualHours As String = String.Empty

        Dim eUnitDesc As String = String.Empty
        Dim eUnitNumber As String = String.Empty
        Dim eWONo As String = String.Empty
        Dim eWODesc As String = String.Empty
        Dim eWOStatus As String = String.Empty
        Dim eDocType As String = String.Empty
        Dim ePriority As String = String.Empty
        Dim eWOOrigin As String = String.Empty
        Dim eRepairType As String = String.Empty
        Dim eSpecRepCat As String = String.Empty
        Dim eAccDetail As String = String.Empty
        Dim eFailStatus As String = String.Empty
        Dim eSymptom As String = String.Empty
        Dim eRootCause As String = String.Empty
        Dim eLABy As String = String.Empty
        Dim eTradeGroup As String = String.Empty
        Dim eRequestedDate As String = String.Empty
        Dim eScheduleStartDate As String = String.Empty
        Dim eActualStartDate As String = String.Empty
        Dim eScheduledCompDate As String = String.Empty
        Dim eCompleteDate As String = String.Empty
        Dim eCompGroup As String = String.Empty
        Dim eMaintType As String = String.Empty
        Dim eSerialOn As String = String.Empty
        Dim eSerialOff As String = String.Empty
        Dim eCurrentMeter1 As String = String.Empty
        Dim eRepCompHours As String = String.Empty
        Dim eCostCode As String = String.Empty
        Dim ejobRepairLocation As String = String.Empty
        Dim eRepairSubLoc As String = String.Empty
        Dim eChargeToJob As String = String.Empty
        Dim eParentWO As String = String.Empty
        Dim eReference As String = String.Empty
        Dim eWarantyClaimNo As String = String.Empty
        Dim eWarrantyStatus As String = String.Empty
        Dim eWarrantySettDate As String = String.Empty
        Dim eProcStatus As String = String.Empty
        Dim eOriginator As String = String.Empty
        Dim eOriginatorDesc As String = String.Empty
        Dim eManager As String = String.Empty
        Dim eManagerDesc As String = String.Empty
        Dim eSupervisor As String = String.Empty
        Dim eSupervisorDesc As String = String.Empty
        Dim eAssignedTo As String = String.Empty
        Dim eAssignedToDesc As String = String.Empty
        Dim eCustomer As String = String.Empty
        Dim eEstLabHours As String = String.Empty
        Dim eEstDuration As String = String.Empty
        Dim eEstMatCost As String = String.Empty
        Dim eEstLaborCost As String = String.Empty
        Dim eEstOtherCost As String = String.Empty
        Dim eEstTotalCost As String = String.Empty
        Dim eActualLabHours As String = String.Empty
        Dim eActualDur As String = String.Empty
        Dim eActualMatCost As String = String.Empty
        Dim eActualLaborCost As String = String.Empty
        Dim eActualOtherCost As String = String.Empty
        Dim eActualTotalCost As String = String.Empty
        Dim eDocDate As String = String.Empty
        Dim eStatusComment As String = String.Empty
        Dim eWOType As String = String.Empty
        Dim eActualHours As String = String.Empty

        Dim eLastUpdate As String = "GetDate()"
        Dim eLastUpdateBy As String = eByName()

        Dim curtime = CStr(DateTime.Now.ToString("yyyyMMddhhmmss"))
        Dim savepath As String = Environ("temp") + "\Insp" + curtime + ".txt"

        If uploadfiles1.HasFile = False Then
            MsgBox("a")
            Exit Sub
        Else
            uploadfiles1.SaveAs(savepath)
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

                    If hea(h) = "Unit Number" Then
                        kUnitNumber = h
                    ElseIf hea(h) = "Asset Number Description" Then
                        kUnitDesc = h
                    ElseIf hea(h) = "Work Order No." Then
                        kWONo = h
                    ElseIf hea(h) = "Issue" Then
                        kWODesc = h
                    ElseIf hea(h) = "WO St" Then
                        kWOStatus = h
                    ElseIf hea(h) = "Doc Type" Then
                        kDocType = h
                    ElseIf hea(h) = "Priority" Then
                        kPriority = h
                    ElseIf hea(h) = "Work Order Origin" Then
                        kWOOrigin = h
                    ElseIf hea(h) = "Repair Type" Then
                        kRepairType = h
                    ElseIf hea(h) = "W.O. Type" Then
                        kWOType = h
                    ElseIf hea(h) = "Fail Stat" Then
                        kFailStatus = h
                    ElseIf hea(h) = "Symptom" Then
                        kSymptom = h
                    ElseIf hea(h) = "Root Cause" Then
                        kRootCause = h
                    ElseIf hea(h) = "Labour Actioned By" Then
                        kLABy = h
                    ElseIf hea(h) = "Trade Group" Then
                        kTradeGroup = h
                    ElseIf hea(h) = "Requested Date" Then
                        kRequestedDate = h
                    ElseIf hea(h) = "Request Date" Then
                        kRequestedDate = h
                    ElseIf hea(h) = "Planned Complete" Then
                        kScheduledCompDate = h
                    ElseIf hea(h) = "Complete Date" Then
                        kCompleteDate = h
                    ElseIf hea(h) = "Component Group" Then
                        kCompGroup = h
                    ElseIf hea(h) = "Service Type" Then
                        kMaintType = h
                    ElseIf hea(h) = "Store" Then
                        kjobRepairLocation = h
                    ElseIf hea(h) = "Parent W.O." Then
                        kParentWO = h
                    ElseIf hea(h) = "Reference" Then
                        kReference = h
                    ElseIf hea(h) = "Originator Number" Then
                        kOriginator = h
                    ElseIf hea(h) = "Manager" Then
                        kManager = h
                    ElseIf hea(h) = "Supervisor" Then
                        kSupervisor = h
                    ElseIf hea(h) = "Assigned To" Then
                        kAssignedTo = h
                    ElseIf hea(h) = "Address Number" Then
                        kCustomer = h
                    ElseIf hea(h) = "Estimated Hours" Then
                        kEstLabHours = h
                    ElseIf hea(h) = "Doc Date" Then
                        kDocDate = h
                    ElseIf hea(h) = "Actual Hours" Then
                        kActualHours = h
                    ElseIf hea(h) = "Status Comment" Then
                        kStatusComment = h
                    End If
                Next

                If kUnitNumber = String.Empty Then
                    showAlert("warning", "Not Valid Format. Column ""Unit Number"" is Not Found")
                    Exit Sub
                End If

                If kWONo = String.Empty Then
                    showAlert("warning", "Not Valid Format. Column ""Work Order Number"" is Not Found")
                    Exit Sub
                End If

                If kMaintType = String.Empty Then
                    showAlert("warning", "Not Valid Format. Column ""Maint Type"" is Not Found")
                    Exit Sub
                End If

                If kCompGroup = String.Empty Then
                    showAlert("warning", "Not Valid Format. Column ""Component Group"" is Not Found")
                    Exit Sub
                End If

                If kParentWO = String.Empty Then
                    showAlert("warning", "Not Valid Format. Column ""Parent WO"" is Not Found")
                    Exit Sub
                End If

                If kDocDate = String.Empty Then
                    showAlert("warning", "Not Valid Format. Column ""Document Date"" is Not Found")
                    Exit Sub
                End If

                If kWOType = String.Empty Then
                    showAlert("warning", "Not Valid Format. Column ""W.O. Type"" is Not Found")
                    Exit Sub
                End If

            Else
                Dim data As String() = eLa.Split(New Char() {vbTab})

                eUnitNumber = evar(data(kUnitNumber), 1)
                eUnitDesc = evar(data(kUnitNumber), 1)

                If Trim(data(kWONo)) = "" Then
                    MsgBox("b")
                    GoTo gotonext
                Else
                    eWONo = evar(data(kWONo), 1)
                End If

                'Deleted Data
                eSpecRepCat = "NULL"
                eAccDetail = "NULL"
                eScheduleStartDate = "NULL"
                eActualStartDate = "NULL"
                eSerialOn = "NULL"
                eSerialOff = "NULL"
                eCurrentMeter1 = "NULL"
                eRepCompHours = "NULL"
                eCostCode = "NULL"
                eRepairSubLoc = "NULL"
                eChargeToJob = "NULL"
                eWarantyClaimNo = "NULL"
                eWarrantyStatus = "NULL"
                eWarrantySettDate = "NULL"
                eProcStatus = "NULL"
                eOriginatorDesc = "NULL"
                eManagerDesc = "Null"
                eSupervisorDesc = "Null"
                eAssignedToDesc = "NULL"
                eEstDuration = "NULL"
                eEstMatCost = "NULL"
                eEstLaborCost = "NULL"
                eEstOtherCost = "NULL"
                eEstTotalCost = "NULL"
                eActualLabHours = "Null"
                eActualDur = "NULL"
                eActualMatCost = "Null"
                eActualLaborCost = "Null"
                eActualOtherCost = "Null"
                eActualTotalCost = "Null"
                '======

                eWODesc = evar(data(kWODesc), 1)
                eWOStatus = evar(data(kWOStatus), 1)
                eDocType = evar(data(kDocType), 1)
                ePriority = evar(data(kPriority), 1)
                eWOOrigin = evar(data(kWOOrigin), 1)
                eRepairType = evar(data(kRepairType), 1)
                eFailStatus = evar(data(kFailStatus), 1)
                eSymptom = evar(data(kSymptom), 1)
                eRootCause = evar(data(kRootCause), 1)
                eLABy = evar(data(kLABy), 1)
                eTradeGroup = evar(data(kTradeGroup), 1)
                eRequestedDate = evar(data(kRequestedDate), 2)
                eScheduledCompDate = evar(data(kScheduledCompDate), 2)
                eCompleteDate = evar(data(kCompleteDate), 2)
                eCompGroup = evar(data(kCompGroup), 1)
                eMaintType = evar(data(kMaintType), 1)
                ejobRepairLocation = evar(data(kjobRepairLocation), 1)
                eParentWO = evar(data(kParentWO), 1)
                eReference = evar(data(kReference), 1)
                eOriginator = evar(data(kOriginator), 1)
                eManager = evar(data(kManager), 1)
                eSupervisor = evar(data(kSupervisor), 1)
                eAssignedTo = evar(data(kAssignedTo), 1)
                eCustomer = evar(data(kCustomer), 1)
                eEstLabHours = evar(data(kEstLabHours), 1)
                eStatusComment = evar(data(kStatusComment), 1)
                eDocDate = evar(data(kDocDate), 2)
                eActualHours = evar(data(kActualHours), 1)

                If Trim(data(kWOType)) = "" Then
                    GoTo gotonext
                Else
                    eWOType = evar(data(kWOType), 1)
                End If

                Dim query As String = "exec dbo.UpdateWODetailInt " & eWONo & "," & eUnitNumber & "," & eUnitDesc & "," & eWODesc & "," & eWOStatus & "," & eActualHours & "," &
                    eDocType & "," & ePriority & "," & eWOOrigin & "," & eRepairType & "," & eFailStatus & "," & eSymptom & "," & eRootCause & "," &
                    eLABy & "," & eTradeGroup & "," & eRequestedDate & "," & eScheduledCompDate & "," & eCompleteDate & "," & eCompGroup & "," &
                    eMaintType & "," & ejobRepairLocation & "," & eParentWO & "," & eReference & "," & eOriginator & "," & eManager & "," & eSupervisor & "," &
                    eAssignedTo & "," & eCustomer & "," & eEstLabHours & "," & eStatusComment & "," & eDocDate & "," & eWOType & "," & eByName()
                executeQuery(query)

                Dim query2 As String = "exec dbo.InsertWODettailInt " & eWONo
                executeQuery(query2)
            End If
gotonext:
            i = i + 1
        Loop

        System.Threading.Thread.Sleep(2000)
        getlastupdate()
        showAlert("success", "Data Has Been Uploaded !")
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