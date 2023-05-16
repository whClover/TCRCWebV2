<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyMenu.ascx.vb" Inherits="TCRCWebV2.AssemblyMenu" %>

<div class="col-md-3">
    <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
        <asp:LinkButton runat="server" CssClass="nav-link active" ID="n1" OnClick="n1_Click">Measurement</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n2" OnClick="n2_Click">Checksheet</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n3" OnClick="n3_Click">Liner Projection</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n4">Upper Liner Bore</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n5">Pin Pistion Clearance</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n6">Valve Lash Adjustment</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n7">Fuel Inj. Trim Code</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n8">Piston Recommendation</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n9">Cylinder Head</asp:LinkButton>
    </div>
</div>