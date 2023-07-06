<%@ Page Title="Assembly List" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyList.aspx.vb" Inherits="TCRCWebV2.AssemblyList" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyAssign.ascx" TagPrefix="uc1" TagName="AssemblyAssign" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <uc1:AssemblyAssign runat="server" id="AssemblyAssign" />
    <div class="row">
        <div class="col-md-3">
            <div class="card">
                <div class="card-header">
                    <h4 class="card-title">Assembly Supv Dashboard (On Trial)</h4>
                </div>
                <div class="card-body">
                    <ul class="list-unstyled categories-list">
                        <li>
                            <div class="custom-accordion">
                                <a class="text-body fw-medium py-1 d-flex align-items-center" data-bs-toggle="collapse" href="#PT-collapse" role="button" aria-expanded="true" aria-controls="PT-collapse">
                                    <i class="fas fa-folder text-warning font-size-13 me-2"></i> Powertrain <i class="mdi mdi-chevron-up accor-down-icon ms-auto"></i>
                                </a>
                                <div class="collapse show" id="PT-collapse" style="">
                                    <div class="card border-0 shadow-none ps-2 mb-0">
                                        <ul class="list-unstyled mb-0">
                                            <asp:Repeater runat="server" ID="rpt_supvouts_PT">
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:LinkButton runat="server" CssClass="d-flex align-items-center" ID="bDshPT" OnClick="bDshPT_Click" CommandArgument='<%# Eval("AssignedTo").ToString() %>'>
                                                            <span class="me-auto"><%# Eval("AssignedTo").ToString() %></span> 
                                                            <span class="ms-auto"><%# Eval("c").ToString() %></span> 
                                                        </asp:LinkButton>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="custom-accordion">
                                <a class="text-body fw-medium py-1 d-flex align-items-center" data-bs-toggle="collapse" href="#Engine-collapse" role="button" aria-expanded="true" aria-controls="Engine-collapse">
                                    <i class="fas fa-folder text-warning font-size-13 me-2"></i> Engine <i class="mdi mdi-chevron-up accor-down-icon ms-auto"></i>
                                </a>
                                <div class="collapse show" id="Engine-collapse" style="">
                                    <div class="card border-0 shadow-none ps-2 mb-0">
                                        <ul class="list-unstyled mb-0">
                                            <asp:Repeater runat="server" ID="rpt_spvouts_E">
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:LinkButton runat="server" CssClass="d-flex align-items-center" ID="bDshE" OnClick="bDshE_Click">
                                                            <span class="me-auto"><%# Eval("AssignedTo").ToString() %></span> 
                                                            <span class="ms-auto"><%# Eval("c").ToString() %></span>
                                                        </asp:LinkButton>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-9">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title">Assembly List</h5>
                            <small class="card-title-desc">List of Work Order Progress on Assembly</small>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="mb-3">
                                        <label>Work Order Number</label>
                                        <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tWONo" AutoCompleteType="disabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="mb-3">
                                        <label>Workshop</label>
                                        <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddWs">
                                            <asp:ListItem Text="Powertrain" Value="Powertrain"></asp:ListItem>
                                            <asp:ListItem Text="Engine" Value="Engine"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="mb-3">
                                        <label>Assembly Status</label>
                                        <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddStatus">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Waiting Submit Template" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="In progress" Value="1" Selected></asp:ListItem>
                                            <asp:ListItem Text="Waiting LH Approval" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Waiting Supv Approval" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Complete" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="mb-3">
                                        <label>Year</label>
                                        <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddYear">
                                            <asp:ListItem Text="> 2023" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="< 2023" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="btn-group mt-4 mt-md-0" role="group" aria-label="Basic example">
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bSearch" OnClick="bSearch_Click">
                                    <i class="fa fa-search"></i> Search
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Repeater runat="server" ID="rpt_Assembly" OnItemDataBound="rpt_Assembly_ItemDataBound">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header bg-light">
                                    <div class="d-flex justify-content-between">
                                        <div>
                                            <h5 class="card-title" runat="server" id="hWONo">WO.123456</h5>
                                            <small class="card-title-desc" runat="server" id="hWODesc">TCRC-DZ1581-CAT D8R-REPAIR TRANSMISSION(CONTINUE LIFE)</small> <br />
                                            <small class="card-title-desc" runat="server" id="hAssemblyStat">Assembly Status:</small> <br />
                                            <small class="card-title-desc" runat="server" id="hJobStatus">Job Status:</small>
                                        </div>
                                        <div>
                                            <asp:LinkButton OnClientClick="return confirm('Are you sure?');" runat="server" ID="bUpload" CssClass="btn btn-sm btn-soft-primary" CommandArgument='<%# Eval("WONo") %>' OnClick="bUpload_Click">
                                                <i class="fa fa-upload"></i> Upload
                                            </asp:LinkButton>
                                            <asp:LinkButton OnClientClick="return confirm('Are you sure?');" runat="server" ID="bprint" CssClass="btn btn-sm btn-soft-primary" CommandArgument='<%# Eval("WONo") %>' OnClick="bprint_Click">
                                                <i class="fa fa-print"></i> Print
                                            </asp:LinkButton>
                                            <asp:LinkButton OnClientClick="return confirm('Are you sure?');" runat="server" ID="bsync" CssClass="btn btn-sm btn-soft-primary" CommandArgument='<%# Eval("WONo") %>' OnClick="bsync_Click">
                                                <i class="fas fa-history"></i> Sync Progress
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="bassign" CssClass="btn btn-sm btn-soft-primary" CommandArgument='<%# Eval("WONo") %>' OnClick="bassign_Click">
                                                <i class="fas fa-edit"></i> Assign Template
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div class="card-body" runat="server" id="bProgress">
                                    <ul class="list-inline main-chart mb-0">
                                        <li class="list-inline-item chart-border-left me-0 border-0" runat="server" id="liMea"> 
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">Measurement</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hMea">24.03 %</h4>
                                            <div class="text-center">
                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' ID="bMea" OnClick="bMea_Click">
                                                    <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </li>
                                        <li class="list-inline-item chart-border-left me-0" runat="server" id="leChk">
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">Checksheet</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hChk">24.03 %</h4>
                                            <div class="text-center">
                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' ID="bChk" OnClick="bChk_Click">
                                                    <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </li>
                                        <li class="list-inline-item chart-border-left me-0" runat="server" id="liLP">
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">Liner Projection</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hLP">24.03 %</h4>
                                            <div class="text-center">
                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' ID="bLP" OnClick="bLP_Click">
                                                    <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </li>
                                        <li class="list-inline-item chart-border-left me-0" runat="server" id="liULB">
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">Upper Liner Bore</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hULB">24.03 %</h4>
                                            <div class="text-center">
                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' ID="bULB" OnClick="bULB_Click">
                                                    <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </li>
                                        <li class="list-inline-item chart-border-left me-0" runat="server" id="liPPC">
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">Pin Piston Clearance</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hPPC">24.03 %</h4>
                                            <div class="text-center">
                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' ID="bPPC" OnClick="bPPC_Click">
                                                    <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </li>
                                        <li class="list-inline-item chart-border-left me-0" runat="server" id="liVLA">
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">Valve Lash Adjustment</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hVLA">24.03 %</h4>
                                            <div class="text-center">
                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' ID="bVLA" OnClick="bVLA_Click">
                                                    <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </li>
                                        <li class="list-inline-item chart-border-left me-0" runat="server" id="liFuel">
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">Fuel Inj. Trim Code</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hFuelInj">24.03 %</h4>
                                            <div class="text-center">
                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' ID="bFuel" OnClick="bFuel_Click">
                                                    <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </li>
                                        <li class="list-inline-item chart-border-left me-0" runat="server" id="liPR">
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">Piston Recommendation</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hRC">24.03 %</h4>
                                            <div class="text-center">
                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' ID="bPR" OnClick="bPR_Click">
                                                    <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </li>
                                        <li class="list-inline-item chart-border-left me-0" runat="server" id="liCH">
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">Cylinder Head</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hCH">24.03 %</h4>
                                            <div class="text-center">
                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' ID="bCH" OnClick="bCH_Click">
                                                    <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </li>
                                        <li class="list-inline-item chart-border-left me-0" runat="server" id="liDyno">
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">Dyno Check</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hDyno">24.03 %</h4>
                                            <div class="text-center">
                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' ID="bDyno" OnClick="bDyno_Click">
                                                    <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </li>
                                        <li class="list-inline-item chart-border-left me-0" runat="server" id="liLH">
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">LH Approval</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hLH">24.03 %</h4>
                                        </li>
                                        <li class="list-inline-item chart-border-left me-0" runat="server" id="liSpv">
                                            <span class="text-muted fw-normal font-size-11 ms-2 text-center">Supv Approval</span>
                                            <h4 class="my-1 text-center text-primary" runat="server" id="hSupv">24.03 %</h4>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>