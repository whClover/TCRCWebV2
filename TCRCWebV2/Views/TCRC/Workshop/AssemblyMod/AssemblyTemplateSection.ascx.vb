Imports TCRCWebV2.SQLFunction
Imports TCRCWebV2.GlobalString
Imports TCRCWebV2.Utility

Public Class AssemblyTemplateSection
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bsave_Click(sender As Object, e As EventArgs)
        Dim eidgp As String = gidgp.Value
        If eidgp = String.Empty Then Exit Sub
        Dim esection As String = evar(tsection.Text, 1)
        If esection = String.Empty Then Exit Sub
        Dim query As String = "insert into tbl_AssemblyTemplateRev(Sequence,AssemblySection,AssemblyDesc,RegisterBy,RegisterDate,ValType,Active,IDTemplateAssemblyGroup,InstructionType,SeqType) values(
            '...'," & esection & ",'...'," & eByName() & ",getdate(),1,1," & eidgp & ",'Info',1
        )"
        executeQuery(query)
        DirectCast(Page, AssemblyTemplateDetails).bindingsection()
    End Sub
End Class