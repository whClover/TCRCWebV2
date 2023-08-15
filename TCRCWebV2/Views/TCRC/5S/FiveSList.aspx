<%@ Page Title="5S List" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="FiveSList.aspx.vb" Inherits="TCRCWebV2.FiveSList" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/5S/FiveSAssignArea.ascx" TagPrefix="uc1" TagName="FiveSAssignArea" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row p-0">
        <div class="col-md-4">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Search Data</h5>
                </div>
                <div class="card-body">
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
                        <h6>Assign To</h6>
                        <asp:DropDownList runat="server" ID="ddassignto" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <h6>Supervisor</h6>
                        <asp:DropDownList runat="server" ID="ddsupv" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <div class="d-grid">
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bsearch" OnClick="bsearch_Click">
                                <i class="fa fa-search"></i> Search
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-8">
            <div class="card">
                <uc1:FiveSAssignArea runat="server" ID="FiveSAssignArea" />
                <div class="card-header justify-content-between d-flex align-items-center">
                    <h5 class="card-title">5S Register</h5>
                    <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="badd" OnClick="badd_Click">
                        <i class="fa fa-plus"></i> Add New Inspect
                    </asp:LinkButton>
                </div>
                <div class="card-body p-0">
                    <asp:GridView runat="server" CssClass="table table-bordered p-0 table-sm" ID="gv5SList" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="IDFindingGP" HeaderStyle-CssClass="text-center bg-soft-primary" ItemStyle-CssClass="text-center" />
                            <asp:BoundField HeaderText="Location Description" DataField="LocationDesc" HeaderStyle-CssClass="bg-soft-primary" />
                            <asp:BoundField HeaderText="Inspector" DataField="FullName" HeaderStyle-CssClass="bg-soft-primary" />
                            <asp:BoundField HeaderText="Date" DataField="formatDate" HeaderStyle-CssClass="bg-soft-primary" />
                            <asp:BoundField HeaderText="Assign To" DataField="AssignTo" HeaderStyle-CssClass="bg-soft-primary" />
                            <asp:BoundField HeaderText="Supervisor" DataField="SupvApprovedBy" HeaderStyle-CssClass="bg-soft-primary" />
                            <asp:TemplateField HeaderStyle-CssClass="bg-soft-primary" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="bshow" OnClick="bshow_Click" CommandArgument='<%# Eval("IDFindingGP") %>'>
                                        <i class="fa fa-eye"></i> 
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>