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
        ScriptManager1.RegisterAsyncPostBackControl(btnStart)
    End Sub

    Protected Sub btnStart_Click(sender As Object, e As EventArgs)
        updProgress.Visible = True
        divResults.InnerHtml = ""


        'Simulate a long process.
        Thread.Sleep(5000)

        divResults.InnerHtml = "Long process completed."
        updProgress.Visible = False
    End Sub
End Class