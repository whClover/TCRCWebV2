<%@ Page Title="Timesheet Index" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="TimesheetIndex.aspx.vb" Inherits="TCRCWebV2.TimesheetIndex" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <div class="d-flex justify-content-between">
                        <h6 class="card-title">Timesheet Summary</h6>
                        <div>
                            <button class="btn btn-light btn-sm" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight" aria-controls="offcanvasRight">
                                <i class="fa fa-filter me-2"></i>Filter
                            </button>
                            <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
                                <div class="offcanvas-header">
                                    <h5 id="offcanvasRightLabel">Filter</h5>
                                    <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                                </div>
                                <div class="offcanvas-body">
                                    <div class="mb-3">
                                        <h6>Date Range</h6>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <input type="text" class="form-control form-control-sm datepicker-basic" runat="server" id="tStart">
                                            </div>
                                            <div class="col-md-6">
                                                <input type="text" class="form-control form-control-sm datepicker-basic" runat="server" id="tEnd">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="mb-3">
                                        <h6>User ID</h6>
                                        <asp:TextBox runat="server" CssClass="form-control form-control-sm" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                    <div class="mb-3">
                                        <h6>Full Name</h6>
                                        <asp:TextBox runat="server" CssClass="form-control form-control-sm" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                    <div class="mb-3">
                                        <h6>Crew</h6>
                                        <asp:DropDownList runat="server" CssClass="form-control form-control-sm">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                            <asp:ListItem Text="B" Value="B"></asp:ListItem>
                                            <asp:ListItem Text="C" Value="C"></asp:ListItem>
                                            <asp:ListItem Text="D" Value="D"></asp:ListItem>
                                            <asp:ListItem Text="S" Value="S"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="mb-3">
                                        <h6>Job</h6>
                                        <asp:TextBox runat="server" CssClass="form-control form-control-sm" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                    <div class="mb-3">
                                        <h6>Validation</h6>
                                        <asp:DropDownList runat="server" CssClass="form-control form-control-sm">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="mb-3">
                                        <h6>Supervisor Name</h6>
                                        <asp:TextBox runat="server" CssClass="form-control form-control-sm" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                    <div class="mb-3">
                                        <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm">
                                            <i class="fa fa-search"></i> Search
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm">
                                <i class="fa fa-check-circle me-2"></i>Validate
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table table-sm">
                            <thead>
                                <tr>
                                    <th>User ID</th>
                                    <th>Full Name</th>
                                    <th>Job Title</th>
                                    <th>Crew</th>
                                    <th>Labour Job Cost</th>
                                    <th>Job</th>
                                    <th>Job Source</th>
                                    <th>Shift</th>
                                    <th>Date</th>
                                    <th>Time</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpt_TS">
                                    <ItemTemplate>
                                        <tr>
                                            <td><span class="form-label" runat="server" id="suserid"></span></td>
                                            <td><span class="form-label" runat="server" id="sfullname"></span></td>
                                            <td><span class="form-label" runat="server" id="sjobtitle"></span></td>
                                            <td><span class="form-label" runat="server" id="screw"></span></td>
                                            <td><span class="form-label" runat="server" id="slabjobcost"></span></td>
                                            <td><span class="form-label" runat="server" id="sjob"></span></td>
                                            <td><span class="form-label" runat="server" id="sjobsource"></span></td>
                                            <td><span class="form-label" runat="server" id="sshift"></span></td>
                                            <td><span class="form-label" runat="server" id="sdate"></span></td>
                                            <td><span class="form-label" runat="server" id="stime"></span></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>