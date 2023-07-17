<%@ Page Title="Workshop Page" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="indexWS.aspx.vb" Inherits="TCRCWebV2.indexWS" %>

<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <div class="mx-n4 mt-n4">
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-0">
                    <div class="card-body p-0">
                        <div class="profile-bg position-relative overflow-hidden">
                            <div class="bg-overlay bg-dark bg-gradient"></div>
                        </div>
                    </div>
                </div>
                <!-- end card -->
            </div>
        </div>
        <!-- end row -->
    </div>

    <div class="row">
        <div class="col-xl-3">
            <div class="card mt-n5">
                <div class="card-body text-center">
                    <div class="text-end">
                        <div class="dropdown">
                            <a class="btn btn-link text-dark font-size-16 p-1 dropdown-toggle shadow-none" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                <i class="uil uil-ellipsis-h"></i>
                            </a>
                        </div>
                    </div>
                    <div class="avatar-xl mx-auto mb-4">
                        <img runat="server" src="~/images/logo-tcrc.png" alt="" class="img-fluid rounded-circle">
                    </div>
                    <h5 class="mb-1" runat="server" id="hFullName">Katie Sharpe</h5>
                    <p class="text-muted" runat="server" id="hTitle">Full Stack Developer</p>
                </div>
            </div>
            <!-- end card -->

            <div class="card">
                <div class="card-body">
                    <ul class="list-unstyled mb-0">
                        <li class="py-3">
                            <div class="d-flex align-items-center">
                                <div class="font-size-20 text-primary flex-shrink-0 me-3">
                                    <i class="fas fa-envelope"></i>    
                                </div>
                                <div class="flex-grow-1">
                                    <p class="text-muted mb-1 font-size-13">E-mail</p>
                                    <h5 class="mb-0 font-size-14" runat="server" id="hEmail">katie@dashonic.com</h5>
                                </div>
                            </div>
                        </li>
                        <!-- end li -->
                        <li class="py-3">
                            <div class="d-flex align-items-center">
                                <div class="font-size-20 text-primary flex-shrink-0 me-3">
                                    <i class="fas fa-user-alt"></i>
                                </div>
                                <div class="flex-grow-1">
                                    <p class="text-muted mb-1 font-size-13">Supervisor</p>
                                    <h5 class="mb-0 font-size-14" runat="server" id="hSupv">California, United States</h5>
                                </div>
                            </div>
                        </li>
                        <!-- end li -->
                        <li class="pt-3">
                            <div class="d-flex align-items-center">
                                <div class="font-size-20 text-primary flex-shrink-0 me-3">
                                    <i class="fas fa-home"></i>
                                </div>
                                <div class="flex-grow-1">
                                    <p class="text-muted mb-1 font-size-13">Job Cost</p>
                                    <h5 class="mb-0 font-size-14" runat="server" id="hJobCost">4 Years</h5>
                                </div>
                            </div>
                        </li>
                        <!-- end li -->
                    </ul>
                </div>
                <!-- end card body -->
            </div>
            <!-- end card -->

        </div>
        <!-- end col -->

        <div class="col-xl-9">
            <div class="mt-4">
                <div class="row">
                    <div class="col-lg-8">
                        <div class="card">
                            <div class="card-header bg-primary">
                                <h4 class="card-title text-white"># Module Inspection</h4>
                            </div>
                            <div class="card-body">
                                <div class="d-flex flex-wrap gap-2">
                                    <asp:LinkButton runat="server" CssClass="text-body btn btn-light col-md-4" ID="bMeaWorksheet" OnClick="bMeaWorksheet_Click">
                                        <i class="fas fa-book fa-2x"></i> <hr /> <span class="me-auto fw-bold">Measure Worksheet</span> 
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="text-body btn btn-light col-md-4" ID="bMeaTemplate" OnClick="bMeaTemplate_Click">
                                        <i class="fas fa-archive fa-2x"></i> <hr /> <span class="me-auto fw-bold">Measure Template</span> 
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="text-body btn btn-light col-md-4" ID="bPrelimWorksheet" OnClick="bPrelimWorksheet_Click">
                                        <i class="fas fa-book fa-2x"></i> <hr /> <span class="me-auto fw-bold">Preliminary Worksheet</span> 
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="text-body btn btn-light col-md-4" ID="bPrelimTemplate" OnClick="bPrelimTemplate_Click">
                                        <i class="fas fa-archive fa-2x"></i> <hr /> <span class="me-auto fw-bold">Preliminary Template</span> 
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>

                        <div class="card">
                            <div class="card-header bg-primary">
                                <h4 class="card-title text-white"># Module Assembly</h4>
                            </div>
                            <div class="card-body">
                                <div class="d-flex flex-wrap gap-2">
                                    <asp:LinkButton runat="server" CssClass="text-body btn btn-light col-md-4" ID="bassm" OnClick="bassm_Click">
                                        <i class="fas fa-book fa-2x"></i> <hr /> <span class="me-auto fw-bold">Worksheet</span> 
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="text-body btn btn-light col-md-4">
                                        <i class="fas fa-archive fa-2x"></i> <hr /> <span class="me-auto fw-bold">Template</span> 
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>

                        <div class="card">
                            <div class="card">
                                <div class="card-header bg-primary">
                                    <h4 class="card-title text-white"># Module Timesheet</h4>
                                </div>
                                <div class="card-body">
                                    <div class="d-flex flex-wrap gap-2">
                                        <asp:LinkButton runat="server" CssClass="text-body btn btn-light col-md-4">
                                            <i class="fas fa-clock fa-2x"></i> <hr /> <span class="me-auto fw-bold">Work Order Activity</span> 
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="text-body btn btn-light col-md-4">
                                            <i class="fas fa-user-clock fa-2x"></i> <hr /> <span class="me-auto fw-bold">Timesheet Mechanic</span> 
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end card -->
                    </div>

                    <div class="col-lg-4">
                        <div class="card">
                            <div class="card-header bg-primary">
                                <h4 class="card-title text-white"># Other Module</h4>
                            </div>
                            <div class="card-body">
                                <div class="d-flex flex-wrap gap-2">
                                    <asp:LinkButton runat="server" CssClass="text-body btn btn-light col-md-5">
                                        <i class="fas fa-toolbox fa-2x"></i> <hr /> <span class="me-auto fw-bold">Part List</span> 
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="text-body btn btn-light col-md-5">
                                        <i class="fas fa-wrench fa-2x"></i> <hr /> <span class="me-auto fw-bold">Part Kit</span> 
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="text-body btn btn-light col-md-5" ID="bCompRelease" OnClick="bCompRelease_Click">
                                        <i class="fas fa-truck-loading fa-2x"></i> <hr /> <span class="me-auto fw-bold">Component Release</span> 
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <!-- end card -->
                    </div>
                </div><!-- end row -->
            </div>
        </div><!-- end col -->
    </div>
</asp:Content>