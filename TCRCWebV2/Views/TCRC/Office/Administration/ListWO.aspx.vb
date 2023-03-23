Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.Utility
Imports TCRCWebV2.GlobalString

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

    Protected Sub bUpload_Click(sender As Object, e As EventArgs)
        utility.ModalV2("MainContent_UploadWO_Panel1")
    End Sub

    Protected Sub bUpdate_Click(sender As Object, e As EventArgs)
        Dim script As String
        script = "const progressBar = document.getElementById(""bProg"");const width = parseInt(progressBar.style.width) || 0;progressBar.style.width = `${width + 10}%`;"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "tes", Script, True)
    End Sub
End Class