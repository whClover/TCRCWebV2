<%@ Page Title="5S Summary" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="FiveSSummary.aspx.vb" Inherits="TCRCWebV2.FiveSSummary" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">
                        5S Summary
                    </h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="mb-3">
                                <h6>Date</h6>
                                <div class="row">
                                    <div class="col-md-6">
                                        <input type="text" class="form-control form-control-sm datepicker-basic" runat="server" id="tStart">
                                    </div>
                                    <div class="col-md-6">
                                        <input type="text" class="form-control form-control-sm datepicker-basic" runat="server" id="tEnd">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="mb-3">
                                <h6>Locations</h6>
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddLoc"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="mb-3">
                                <h6>Inspector</h6>
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddInspector"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-2">
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bsearch" OnClick="bsearch_Click">
                                <i class="fa fa-search"></i> Search
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="card-body p-0">
                    <style>
                        .imgku {
                            height: 100px;
                            width: 200px;
                            object-fit: contain;
                        }
                    </style>
                    <asp:GridView runat="server" CssClass="table table-bordered table-sm p-0" ID="gv5sSummary" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="RegisterBy" HeaderText="Inspector" HeaderStyle-CssClass="bg-soft-primary" />
                            <asp:BoundField DataField="RegisterDate" HeaderText="Date" HeaderStyle-CssClass="bg-soft-primary" />
                            <asp:BoundField DataField="FindingDesc" HeaderText="Finding" HeaderStyle-CssClass="bg-soft-primary" />
                            <asp:BoundField DataField="FindingAct" HeaderText="Action Required" HeaderStyle-CssClass="bg-soft-primary" />
                            <asp:BoundField DataField="AreaDesc" HeaderText="Area" HeaderStyle-CssClass="bg-soft-primary" />
                            <asp:TemplateField HeaderText="Picture" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="bg-soft-primary">
                                <ItemTemplate>
                                    <img src='<%# Eval("rmPict") %>' class="imgku" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AssignTo" HeaderText="Assign To" HeaderStyle-CssClass="bg-soft-primary" />
                            <asp:BoundField DataField="InspectStatus" HeaderText="Status" HeaderStyle-CssClass="bg-soft-primary" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>