<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyMenu.ascx.vb" Inherits="TCRCWebV2.AssemblyMenu" %>

<div class="col-md-12 mb-3">
    <div class="nav nav-pills nav-justified bg-light" role="tablist">
        <asp:LinkButton runat="server" CssClass="nav-link active" ID="n1" OnClick="n1_Click">Measurement</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n2" OnClick="n2_Click">Checksheet</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n3" OnClick="n3_Click">Liner Projection</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n4" OnClick="n4_Click">Upper Liner Bore</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n5" OnClick="n5_Click">Pin Piston Clearance</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n6" OnClick="n6_Click">Valve Lash Adjustment</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n7" OnClick="n7_Click">Fuel Inj. Trim Code</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n8" OnClick="n8_Click">Piston Recommendation</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="nav-link" ID="n9" OnClick="n9_Click">Cylinder Head</asp:LinkButton>
    </div>
</div>