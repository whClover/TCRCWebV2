<%@ Page Title="Workshop Page" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="indexWS.aspx.vb" Inherits="TCRCWebV2.indexWS" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <a href="#" class="list-group-item list-group-item-action">
                        <div class="d-flex align-items-center">
                            <div class="avatar">
                                <div class="avatar-title bg-primary text-white font-size-18 rounded">
                                    <i class="fas fa-address-card"></i>
                                </div>
                            </div>
                            <div class="flex-grow-1 ms-3">
                                <div>
                                    <h5 class="font-size-14 mb-1" runat="server" id="hFullName">Esther James</h5>
                                    <p class="font-size-13 text-muted mb-0" runat="server" id="hTitle">Frontend Developer</p>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="card">
                <div class="card-body">
                    <div class="text-center">
                        <h5 class="font-size-15 mb-4">Inspection</h5>
                    </div>
                    <hr />

                    <div class="mt-4">
                        <span class="form-label fw-bold">Measure Inspection</span>
                        <div class="card border shadow-none mb-2">
                            <asp:LinkButton runat="server" CssClass="text-body" ID="bMeaWorksheet" OnClick="bMeaWorksheet_Click">
                                <div class="p-2">
                                    <div class="d-flex">
                                        <div class="avatar-sm align-self-center me-2">
                                            <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                                <i class="fas fa-file-signature"></i>
                                            </div>
                                        </div>
    
                                        <div class="overflow-hidden me-auto">
                                            <h5 class="font-size-13 text-truncate mb-1">Measure Worksheet</h5>
                                            <p class="text-muted text-truncate mb-0">Unlocked</p>
                                        </div>

                                        <div class="ms-2">
                                            <i class="fa fa-unlock text-muted"></i>
                                        </div>
                                    </div>
                                </div>
                            </asp:LinkButton>
                        </div><!-- end card -->

                        <div class="card border shadow-none mb-2">
                            <asp:LinkButton runat="server" CssClass="text-body" ID="bMeaTemplate" OnClick="bMeaTemplate_Click">
                                <div class="p-2">
                                    <div class="d-flex">
                                        <div class="avatar-sm align-self-center me-2">
                                            <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                                <i class="fa fa-book"></i>
                                            </div>
                                        </div>

                                        <div class="overflow-hidden me-auto">
                                            <h5 class="font-size-13 text-truncate mb-1">Measure Template</h5>
                                            <p class="text-muted text-truncate mb-0">Unlocked</p>
                                        </div>

                                        <div class="ms-2">
                                            <i class="fa fa-unlock text-muted"></i>
                                        </div>
                                    </div>
                                </div>
                            </asp:LinkButton>
                        </div><!-- end card -->

                    </div>

                    <div class="mt-4">
                        <span class="form-label fw-bold">Preliminary Inspection</span>
                        <div class="card border shadow-none mb-2">
                            <a href="javascript: void(0);" class="text-body">
                                <div class="p-2">
                                    <div class="d-flex">
                                        <div class="avatar-sm align-self-center me-2">
                                            <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                                <i class="fas fa-file-signature"></i>
                                            </div>
                                        </div>
    
                                        <div class="overflow-hidden me-auto">
                                            <h5 class="font-size-13 text-truncate mb-1">Preliminary Worksheet</h5>
                                            <p class="text-muted text-truncate mb-0">Unlocked</p>
                                        </div>

                                        <div class="ms-2">
                                            <i class="fa fa-unlock text-muted"></i>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div><!-- end card -->

                        <div class="card border shadow-none mb-2">
                            <a href="javascript: void(0);" class="text-body">
                                <div class="p-2">
                                    <div class="d-flex">
                                        <div class="avatar-sm align-self-center me-2">
                                            <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                                <i class="fa fa-book"></i>
                                            </div>
                                        </div>

                                        <div class="overflow-hidden me-auto">
                                            <h5 class="font-size-13 text-truncate mb-1">Preliminary Template</h5>
                                            <p class="text-muted text-truncate mb-0">Unlocked</p>
                                        </div>

                                        <div class="ms-2">
                                            <i class="fa fa-unlock text-muted"></i>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div><!-- end card -->
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card">
                <div class="card-body">
                    <div class="text-center">
                        <h5 class="font-size-15 mb-4">Assembly</h5>
                    </div>
                    <hr />
                    <div class="mt-4">

                        <div class="card border shadow-none mb-2">
                            <asp:LinkButton runat="server" CssClass="text-body" ID="basm" OnClick="basm_Click">
                                <div class="p-2">
                                    <div class="d-flex">
                                        <div class="avatar-sm align-self-center me-2">
                                            <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                                <i class="fas fa-file-signature"></i>
                                            </div>
                                        </div>
    
                                        <div class="overflow-hidden me-auto">
                                            <h5 class="font-size-13 text-truncate mb-1">Assembly Worksheet</h5>
                                            <p class="text-muted text-truncate mb-0">Unlocked</p>
                                        </div>

                                        <div class="ms-2">
                                            <i class="fa fa-unlock text-muted"></i>
                                        </div>
                                    </div>
                                </div>
                            </asp:LinkButton>
                        </div><!-- end card -->

                        <div class="card border shadow-none mb-2">
                            <a href="javascript: void(0);" class="text-body">
                                <div class="p-2">
                                    <div class="d-flex">
                                        <div class="avatar-sm align-self-center me-2">
                                            <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                                <i class="fa fa-book"></i>
                                            </div>
                                        </div>

                                        <div class="overflow-hidden me-auto">
                                            <h5 class="font-size-13 text-truncate mb-1">Assembly Template</h5>
                                            <p class="text-muted text-truncate mb-0">Unlocked</p>
                                        </div>

                                        <div class="ms-2">
                                            <i class="fa fa-unlock text-muted"></i>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div><!-- end card -->

                    </div>

                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card">
                <div class="card-body">
                    <div class="text-center">
                        <h5 class="font-size-15 mb-4">5S Module</h5>
                    </div>
                    <hr />
                    <div class="mt-4">

                        <div class="card border shadow-none mb-2">
                            <asp:LinkButton runat="server" CssClass="text-body" ID="LinkButton1">
                                <div class="p-2">
                                    <div class="d-flex">
                                        <div class="avatar-sm align-self-center me-2">
                                            <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                                <i class="fas fa-user"></i>
                                            </div>
                                        </div>
    
                                        <div class="overflow-hidden me-auto">
                                            <h5 class="font-size-13 text-truncate mb-1">My Outstanding Approval</h5>
                                            <p class="text-muted text-truncate mb-0">Unlocked</p>
                                        </div>

                                        <div class="ms-2">
                                            <i class="fa fa-unlock text-muted"></i>
                                        </div>
                                    </div>
                                </div>
                            </asp:LinkButton>
                        </div><!-- end card -->

                        <div class="card border shadow-none mb-2">
                            <asp:LinkButton runat="server" CssClass="text-body" ID="fivesummary" OnClick="fivesummary_Click">
                                <div class="p-2">
                                    <div class="d-flex">
                                        <div class="avatar-sm align-self-center me-2">
                                            <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                                <i class="fas fa-atlas"></i>
                                            </div>
                                        </div>
    
                                        <div class="overflow-hidden me-auto">
                                            <h5 class="font-size-13 text-truncate mb-1">5S Summary</h5>
                                            <p class="text-muted text-truncate mb-0">Unlocked</p>
                                        </div>

                                        <div class="ms-2">
                                            <i class="fa fa-unlock text-muted"></i>
                                        </div>
                                    </div>
                                </div>
                            </asp:LinkButton>
                        </div><!-- end card -->

                        <div class="card border shadow-none mb-2">
                            <asp:LinkButton runat="server" CssClass="text-body" ID="fivesreg" OnClick="fivesreg_Click">
                                <div class="p-2">
                                    <div class="d-flex">
                                        <div class="avatar-sm align-self-center me-2">
                                            <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                                <i class="fas fa-search"></i>
                                            </div>
                                        </div>
    
                                        <div class="overflow-hidden me-auto">
                                            <h5 class="font-size-13 text-truncate mb-1">5S Register</h5>
                                            <p class="text-muted text-truncate mb-0">Unlocked</p>
                                        </div>

                                        <div class="ms-2">
                                            <i class="fa fa-unlock text-muted"></i>
                                        </div>
                                    </div>
                                </div>
                            </asp:LinkButton>
                        </div><!-- end card -->

                        <div class="card border shadow-none mb-2">
                            <asp:LinkButton runat="server" CssClass="text-body" ID="fivesloc" OnClick="fivesloc_Click">
                                <div class="p-2">
                                    <div class="d-flex">
                                        <div class="avatar-sm align-self-center me-2">
                                            <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                                <i class="fas fa-location-arrow"></i>
                                            </div>
                                        </div>
    
                                        <div class="overflow-hidden me-auto">
                                            <h5 class="font-size-13 text-truncate mb-1">Location Register</h5>
                                            <p class="text-muted text-truncate mb-0">Unlocked</p>
                                        </div>

                                        <div class="ms-2">
                                            <i class="fa fa-unlock text-muted"></i>
                                        </div>
                                    </div>
                                </div>
                            </asp:LinkButton>
                        </div><!-- end card -->
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card">
                <div class="card-body">
                    <div class="text-center">
                        <h5 class="font-size-15 mb-4">Other Module</h5>
                    </div>
                    <hr />
                    <div class="mt-4">

                        <div class="card border shadow-none mb-2">
                            <asp:LinkButton runat="server" CssClass="text-body" ID="bCompRelease" OnClick="bCompRelease_Click">
                                <div class="p-2">
                                    <div class="d-flex">
                                        <div class="avatar-sm align-self-center me-2">
                                            <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                                <i class="fas fa-truck-loading"></i>
                                            </div>
                                        </div>
    
                                        <div class="overflow-hidden me-auto">
                                            <h5 class="font-size-13 text-truncate mb-1">Component Release</h5>
                                            <p class="text-muted text-truncate mb-0">Unlocked</p>
                                        </div>

                                        <div class="ms-2">
                                            <i class="fa fa-unlock text-muted"></i>
                                        </div>
                                    </div>
                                </div>
                            </asp:LinkButton>
                        </div><!-- end card -->
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>