﻿Imports Microsoft.SqlServer.Server

Public Class GlobalString
    Public Shared popupsize As String = "'width=1200,height=800,left=200,top=200,resizable=yes'"

    'defaultpath
    Public Shared server As String = "bpnaps07"
    Public Shared PictSTG As String = "\\" & server & "\Database\Plant_Component\PictInspection\"
    Public Shared MeaInspPict As String = PictSTG & "InspectionTemplate\"
    Public Shared JobPck As String = "\\" & server & "\Database\Plant_Component\JobPackage\"
    Public Shared asmpict As String = PictSTG & "AssemblyPicture\"
    Public Shared Picture5S As String = "\\" & server & "\dbattachcomp$\Picture5S\"
    Public Shared JobIDAttachment As String = "\\bpnaps07\dbattachcomp$\JobID\"
    Public Shared PICTAssemblyTemplate As String = PictSTG & "AssemblyTemplatePIC\"
    '=============

    'DataPath
    Public Shared DataLabourAvg As String = "..\..\..\data\LabourAvg.txt"
    '==============================================================

    'variabel untuk link web-nya,
    Public Shared urlMainMenu As String = "~/"
    Public Shared urlError As String = "~/Views/Shared/ErrorPage.aspx"
    Public Shared urlPrint As String = "~/Views/TCRC/Reports/"

    Public Shared urlTCRCLogin As String = "~/LoginPage.aspx?id=1"
    Public Shared urlTCRC As String = "~/Views/TCRC/"
    Public Shared urlTCRCIx As String = urlTCRC & "Index.aspx"
    Public Shared urlTCRCWorkshop As String = urlTCRC & "Workshop/"
    Public Shared urlTCRCWorkshopIx As String = urlTCRCWorkshop & "IndexWS.aspx"
    Public Shared urlTCRCOffice As String = urlTCRC & "Office/"
    Public Shared urlTCRCOfficeIx As String = urlTCRCOffice & "Index.aspx"
    Public Shared urlTCRCOfficeAdm As String = urlTCRCOffice & "Administration/"

    'TCRC: Measurement Inspection Module
    Public Shared urlInspection As String = urlTCRCWorkshop & "/Inspection/"
    Public Shared urlMeasureTemplate As String = urlInspection & "MeaInspTemplate.aspx"
    Public Shared urlMeasureTemplateSec As String = urlInspection & "MeaInspTemplateSec.aspx"
    Public Shared urlMeasureTemplateSecDetails As String = urlInspection & "MeaTemplateSecDetails.aspx"
    Public Shared urlMeasureTemplateShow As String = urlInspection & "MeaTemplateShow.aspx"
    Public Shared urlMeasureWorksheet As String = urlInspection & "MeaInspWorksheet.aspx"
    Public Shared urlMeasureWorksheetRev As String = urlInspection & "MeaInspWorksheetRev.aspx"
    Public Shared urlMeasureWorksheetDetails As String = urlInspection & "MeaInspWorksheetDetails.aspx"
    Public Shared urlMeasurePrint As String = urlPrint & "MeaInspection.aspx"

    'TCRC: Assembly Module
    Public Shared urlAssembly As String = urlTCRCWorkshop & "/AssemblyMod/"
    Public Shared urlAssemblyList As String = urlAssembly & "AssemblyList.aspx"
    Public Shared urlAssemblyMea As String = urlAssembly & "AssemblyMea.aspx"
    Public Shared urlAssemblyMeaApv As String = urlAssembly & "AssemblyMeaApv.aspx"
    Public Shared urlAssemblyChk As String = urlAssembly & "AssemblyChk.aspx"
    Public Shared urlAssemblyLinerProj As String = urlAssembly & "AssemblyLinerProj.aspx"
    Public Shared urlAssemblyUpperLiner As String = urlAssembly & "AssemblyLinerBore.aspx"
    Public Shared urlAssemblyPinPiston As String = urlAssembly & "AssemblyPinPiston.aspx"
    Public Shared urlAssemblyValveLashAdj As String = urlAssembly & "AssemblyValLashAdj.aspx"
    Public Shared urlAssemblyFuelInjTrom As String = urlAssembly & "AssemblyFuelCode.aspx"
    Public Shared urlAssemblyPistonRec As String = urlAssembly & "AssemblyPistonRec.aspx"
    Public Shared urlAssemblyCylinderHead As String = urlAssembly & "AssemblyCylHead.aspx"
    Public Shared urlAssemblyDyno As String = urlAssembly & "AssemblyDyno.aspx"
    Public Shared urlAssemblyTemplate As String = urlAssembly & "AssemblyTemplateList.aspx"
    Public Shared urlAssemblyTemplateDetails As String = urlAssembly & "AssemblyTemplateDetails.aspx"
    Public Shared urlAssemblyTemplateEdit As String = urlAssembly & "AssemblyTemplateEdit.aspx"
    Public Shared urlAssemblyHistory As String = urlAssembly & "AssemblyHistoryInput.aspx"

    'TCRC: Other Module
    Public Shared urlOtherModule As String = urlTCRCWorkshop & "Other/"
    Public Shared urlComponentRelease As String = urlOtherModule & "ComponentRel.aspx"
    Public Shared urlComponentReleaseForm As String = urlPrint & "CompRelForm.aspx"
    Public Shared urlComponentReleaseEdit As String = urlOtherModule & "ComponenRelEdit.aspx"

    'TCRC: Administration Module
    Public Shared urlWODetails As String = urlTCRCOfficeAdm & "ListWO.aspx"

    'TCRC: 5S Module
    Public Shared url5SLocation As String = urlTCRC & "5S/FiveSLocation.aspx"
    Public Shared url5SArea As String = urlTCRC & "5S/FiveSArea.aspx"
    Public Shared url5SRegister As String = urlTCRC & "5S/FiveSList.aspx"
    Public Shared url5sDetails As String = urlTCRC & "5S/FiveSDetails.aspx"
    Public Shared url5sForm As String = urlTCRC & "5S/FiveSDetailsForm.aspx"
    Public Shared url5sSummary As String = urlTCRC & "5S/FiveSSummary.aspx"
    Public Shared url5sApv As String = urlTCRC & "5S/FiveSApv.aspx"

    'TCRC: Component Testing
    Public Shared urlTestWS As String = urlTCRCWorkshop & "TestBench/"
    Public Shared urlTestWSIndex As String = urlTestWS & "TestList.aspx"

    'ReportsPath
    Public Shared RptAssemblyMea As String = urlPrint & "AssemblyMea.aspx"
    Public Shared Rpt5S As String = urlPrint & "FiveS.aspx"

    'temp
    Public Shared urlTemp As String = "~/temp/"

    'TMRP - Timesheet
    Public Shared urlTMRP As String = "~/Views/TMRP/"
    Public Shared urlTMRP_Timesheet As String = urlTMRP & "Timesheet/"
    Public Shared urlTMRP_TimesheetForm As String = urlTMRP_Timesheet & "TimesheetModule.aspx"
    Public Shared urlTMRP_Revisuname As String = urlTMRP_Timesheet & "RevisedUsername.aspx"

    'TCRC: Preliminary
    Public Shared urlPreliminary As String = urlTCRCWorkshop & "PreliminaryInspect/"
    Public Shared urlPreliminaryTemplateList As String = urlPreliminary & "PrelimTemplateList.aspx"
    Public Shared urlPreliminaryTemplateDetail As String = urlPreliminary & "PrelimTemplateDetails.aspx"
    Public Shared urlPreliminaryTemplateEdit As String = urlPreliminary & "PrelimTemplateDetailsEdit.aspx"
    'END
End Class
