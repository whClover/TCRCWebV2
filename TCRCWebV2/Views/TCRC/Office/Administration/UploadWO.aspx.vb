Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports Newtonsoft.Json
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility
Imports TCRCWebV2.SQLFunction

Public Class UploadWO1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <WebMethod>
    Public Shared Function GetSomeData() As String
        'Melakukan pengolahan data
        Dim result As String = "Data yang dikembalikan dari server"

        'Mengembalikan nilai ke JavaScript
        Return result
    End Function
End Class