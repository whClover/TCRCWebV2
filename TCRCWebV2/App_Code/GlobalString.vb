Public Class GlobalString
    Public Shared popupsize As String = "'width=1200,height=800,left=200,top=200,resizable=yes'"

    'defaultpath
    Public shared server As String = "bpnaps07"
    Public Shared PictSTG As String = "\\" & server & "\Database\Plant_Component\PictInspection\"
    Public Shared MeaInspPict As String = PictSTG & "InspectionTemplate\"
    Public Shared JobPck As String = "\\" & server & "\Database\Plant_Component\JobPackage\"
    Public Shared asmpict As String = PictSTG & "AssemblyPicture\"
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
    Public Shared urlAssemblyChk As String = urlAssembly & "AssemblyChk.aspx"
    Public Shared urlAssemblyLinerProj As String = urlAssembly & "AssemblyLinerProj.aspx"
    Public Shared urlAssemblyUpperLiner As String = urlAssembly & "AssemblyLinerBore.aspx"
    Public Shared urlAssemblyPinPiston As String = urlAssembly & "AssemblyPinPiston.aspx"

    'TCRC: Other Module
    Public Shared urlOtherModule As String = urlTCRCWorkshop & "Other/"
    Public Shared urlComponentRelease As String = urlOtherModule & "ComponentRel.aspx"
    Public Shared urlComponentReleaseForm As String = urlPrint & "CompRelForm.aspx"

    'TCRC: Administration Module
    Public Shared urlWODetails As String = urlTCRCOfficeAdm & "ListWO.aspx"

    'ReportsPath
    Public Shared RptAssemblyMea As String = urlPrint & "AssemblyMea.aspx"

    'END
End Class
