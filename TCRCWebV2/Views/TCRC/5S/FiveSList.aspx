<%@ Page Title="5S List" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="FiveSList.aspx.vb" Inherits="TCRCWebV2.FiveSList" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/5S/FiveSAssignArea.ascx" TagPrefix="uc1" TagName="FiveSAssignArea" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row p-0">
        <div class="col-md-12">
            <div class="card">
                <uc1:FiveSAssignArea runat="server" ID="FiveSAssignArea" />
                <div class="card-header justify-content-between d-flex align-items-center">
                    <h5 class="card-title">5S Register</h5>
                    <div>
                        <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="badd" OnClick="badd_Click">
                            <i class="fa fa-plus me-2"></i> Add New Inspect
                        </asp:LinkButton>
                        <button class="btn btn-soft-light btn-sm" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight" aria-controls="offcanvasRight">
                            <i class="fa fa-filter me-2"></i> Filter Data
                        </button>
                    </div>
                    

                    <!-- right offcanvas -->
                    <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
                        <div class="offcanvas-header">
                            <h5 id="offcanvasRightLabel">Filter Data</h5>
                            <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                        </div>
                        <div class="offcanvas-body">
                            <div class="mb-3">
                                <h6>Tanggal Inspect</h6>
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
                                <h6>Location</h6>
                                <asp:DropDownList runat="server" ID="ddLocation" CssClass="form-select"></asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <h6>Inspector</h6>
                                <asp:DropDownList runat="server" ID="ddInspector" CssClass="form-select"></asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <h6>Assign To</h6>
                                <asp:DropDownList runat="server" ID="ddassignto" CssClass="form-select"></asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <h6>Supervisor</h6>
                                <asp:DropDownList runat="server" ID="ddsupv" CssClass="form-select"></asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <div class="d-grid">
                                    <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm" ID="bsearch" OnClick="bsearch_Click">
                                        <i class="fa fa-search me-2"></i> Search
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-body p-0">
                    <asp:GridView runat="server" CssClass="table table-borderles p-0 table-sm" ID="gv5SList" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderStyle-CssClass="bg-light" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="bshow" OnClick="bshow_Click" CommandArgument='<%# Eval("IDFindingGP") %>'>
                                        <i class="fa fa-eye"></i> 
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="ID" DataField="IDFindingGP" HeaderStyle-CssClass="text-center bg-light" ItemStyle-CssClass="text-center" />
                            <asp:BoundField HeaderText="Location Description" DataField="LocationDesc" HeaderStyle-CssClass="bg-light" />
                            <asp:BoundField HeaderText="Inspector" DataField="FullName" HeaderStyle-CssClass="bg-light" />
                            <asp:BoundField HeaderText="Date" DataField="formatDate" HeaderStyle-CssClass="bg-light" />
                            <asp:BoundField HeaderText="Assign To" DataField="AssignTo" HeaderStyle-CssClass="bg-light" />
                            <asp:BoundField HeaderText="Supervisor" DataField="SupvApprovedBy" HeaderStyle-CssClass="bg-light" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>