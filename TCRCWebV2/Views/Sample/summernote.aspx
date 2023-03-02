<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="summernote.aspx.vb" Inherits="TCRCWebV2.summernote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <asp:PlaceHolder runat="server">
        <%: Styles.Render("~/Css") %>
    </asp:PlaceHolder>

    <asp:PlaceHolder runat="server">
        <%= Scripts.Render("~/buatmodal") %>
    </asp:PlaceHolder>

    <asp:PlaceHolder runat="server">
        <%= Scripts.Render("~/summernote") %>
    </asp:PlaceHolder>
</head>
    <%--  --%>
<body>
    <form id="form1" runat="server">
        <div id="summernote"></div>
    <script>
        $('#summernote').summernote({
            toolbar: [
                ['font', ['bold', 'underline', 'clear']],
                ['color', ['color']],
                ['table', ['table']]
            ]
        });

    </script>
    </form>

<asp:PlaceHolder runat="server">
    <%= Scripts.Render("~/Scripts") %>
</asp:PlaceHolder>
</body>
</html>
