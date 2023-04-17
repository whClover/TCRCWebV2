<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UploadWO.aspx.vb" Inherits="TCRCWebV2.UploadWO1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tab-Delimited File Reader with Progress Bar</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div>
            <asp:Button ID="btnStart" runat="server" Text="Start Long Process" OnClick="btnStart_Click" />
        </div>

        <div>
            <asp:UpdateProgress ID="updProgress" runat="server" AssociatedUpdatePanelID="upnlMain">
                <ProgressTemplate>
                    <div>
                        <asp:Image ID="imgProgress" runat="server" ImageUrl="~/Images/Spinner.gif" />
                        <span>Processing...</span>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>

        <asp:UpdatePanel ID="upnlMain" runat="server">
            <ContentTemplate>
                <div id="divResults" runat="server"></div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>