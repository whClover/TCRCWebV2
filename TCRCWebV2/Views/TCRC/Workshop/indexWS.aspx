<%@ Page Title="Workshop Page" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="indexWS.aspx.vb" Inherits="TCRCWebV2.indexWS" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row mb-3">
        <div class="col-md-4">
            <div class="">
                <h6 class="mb-2 text-decoration-underline">Measure Inspection</h6>
            </div>

            <div class="card mb-1">
                <div class="card-body p-2">
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
                                    <small class="badge badge-soft-success font-13">Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
            </div>

            <div class="card mb-3">
                <div class="card-body p-2">
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
                                    <small class="badge badge-soft-success font-13">Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
            </div>

            <div class="">
                <h6 class="mb-2 text-decoration-underline">Preliminary Inspection</h6>
            </div>

            <div class="card mb-1">
                <div class="card-body p-2">
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
                                    <small class="badge badge-soft-danger font-13">In-Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
            </div>

            <div class="card mb-1">
                <div class="card-body p-2">
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
                                    <small class="badge badge-soft-danger font-13">In-Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="">
                <h6 class="mb-2 text-decoration-underline">Component Assembly</h6>
            </div>

            <div class="card mb-1">
                <div class="card-body p-2">
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
                                    <small class="badge badge-soft-success font-13">Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
            </div>

            <div class="card mb-3">
                <div class="card-body p-2">
                    <asp:linkbutton runat="server" CssClass="text-body" ID="basmtemplate" OnClick="basmtemplate_Click">
                        <div class="p-2">
                            <div class="d-flex">
                                <div class="avatar-sm align-self-center me-2">
                                    <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                        <i class="fa fa-book"></i>
                                    </div>
                                </div>

                                <div class="overflow-hidden me-auto">
                                    <h5 class="font-size-13 text-truncate mb-1">Assembly Template</h5>
                                    <small class="badge badge-soft-success font-13">Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </asp:linkbutton>
                </div>
            </div>

            <div class="">
                <h6 class="mb-2 text-decoration-underline">Component Testing</h6>
            </div>

            <div class="card mb-1">
                <div class="card-body p-2">
                    <asp:LinkButton runat="server" CssClass="text-body" ID="bwstesting" OnClick="bwstesting_Click">
                        <div class="p-2">
                            <div class="d-flex">
                                <div class="avatar-sm align-self-center me-2">
                                    <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                        <i class="fas fa-file-signature"></i>
                                    </div>
                                </div>
    
                                <div class="overflow-hidden me-auto">
                                    <h5 class="font-size-13 text-truncate mb-1">Testing Worksheet</h5>
                                    <small class="badge badge-soft-success font-13">Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
            </div>

        </div>

        <div class="col-md-4">
            <div class="">
                <h6 class="mb-2 text-decoration-underline">5S Module</h6>
            </div>

            <div class="card mb-1">
                <div class="card-body p-2">
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
                                    <small class="badge badge-soft-success font-13">Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
            </div>

            <div class="card mb-1">
                <div class="card-body p-2">
                    <asp:LinkButton runat="server" CssClass="text-body" ID="b5sapv" OnClick="b5sapv_Click">
                        <div class="p-2">
                            <div class="d-flex">
                                <div class="avatar-sm align-self-center me-2">
                                    <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                        <i class="fas fa-user"></i>
                                    </div>
                                </div>
    
                                <div class="overflow-hidden me-auto">
                                    <h5 class="font-size-13 text-truncate mb-1">My Outstanding Approval</h5>
                                    <small class="badge badge-soft-success font-13">Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
            </div>
             
            <div class="card mb-1">
                <div class="card-body p-2">
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
                                    <small class="badge badge-soft-success font-13">Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
            </div>

            <div class="card mb-1">
                <div class="card-body p-2">
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
                                    <small class="badge badge-soft-success font-13">Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
            </div>
        </div>

        
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="">
                <h6 class="mb-2 text-decoration-underline">Other Module</h6>
            </div>
            <div class="card">
                <div class="card-body p-2">
                    <asp:LinkButton runat="server" CssClass="text-body bg-white" ID="bCompRelease" OnClick="bCompRelease_Click">
                        <div class="p-2">
                            <div class="d-flex">
                                <div class="avatar-sm align-self-center me-2">
                                    <div class="avatar-title rounded bg-transparent text-secondary font-size-18">
                                        <i class="fas fa-truck-loading"></i>
                                    </div>
                                </div>
    
                                <div class="overflow-hidden me-auto">
                                    <h5 class="font-size-13 text-truncate mb-1">Component Release</h5>
                                    <small class="badge badge-soft-success font-13">Active</small>
                                </div>

                                <div class="ms-2">
                                    <i class="fa fa-unlock text-muted"></i>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>