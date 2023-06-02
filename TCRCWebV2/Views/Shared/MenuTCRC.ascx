<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MenuTCRC.ascx.vb" Inherits="TCRCWebV2.MenuTCRC1" %>

<div class="topnav" runat="server" >
    <nav class="navbar navbar-expand-lg topnav-menu">
        <div class="collapse navbar-collapse" id="topnav-menu-content" style="z-index:1">
            <ul class="navbar-nav">
                <li class="nav-item dropdown">
                    <a class="nav-link" href="~/Views/TCRC/Index.aspx" runat="server">
                        <i class="fas fa-laptop text-secondary"></i>
                        <span class="text-secondary">Dashboard</span>
                    </a>
                </li>
                <li class="nav-item dropdown">
                    <asp:LinkButton CssClass="nav-link" runat="server" ID="bOffice" OnClick="bOffice_Click">
                        <i class="fas fa-building text-secondary"></i>
                        <span class="text-secondary">Office</span>
                    </asp:LinkButton>
                </li>
                <li class="nav-item dropdown">
                    <asp:LinkButton CssClass="nav-link" runat="server" ID="bWS" OnClick="bWS_Click">
                        <i class="fas fa-place-of-worship text-secondary"></i>
                        <span class="text-secondary">Workshop</span>
                    </asp:LinkButton>
                </li>
                <li class="nav-item dropdown">
                    <asp:LinkButton CssClass="nav-link" runat="server" ID="bLogout" OnClick="bLogout_Click">
                        <i class="fas fa-lock text-secondary"></i>
                        <span class="text-secondary">Logout</span>
                    </asp:LinkButton>
                </li>
            </ul>
        </div>
    </nav>
</div>