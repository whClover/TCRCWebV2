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
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bsearch" OnClick="bsearch_Click">
                                <i class="fa fa-search"></i> Search
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bgenPT" OnClick="bgenPT_Click">
                                <i class="fa fa-download"></i> Generate Report
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <style>
                        .imgku {
                            height: 100px;
                            width: 200px;
                            object-fit: contain;
                        }
                    </style>
                    <div class="table-responsive">
                        <asp:GridView runat="server" CssClass="table table-hover align-middle table-check" ID="gv5sSummary" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="RegisterBy" HeaderText="Inspector" HeaderStyle-CssClass="bg-light rounded-start" />
                                <asp:BoundField DataField="RegisterDate" HeaderText="Date" HeaderStyle-CssClass="bg-light" />
                                <asp:BoundField DataField="FindingDesc" HeaderText="Finding" HeaderStyle-CssClass="bg-light" />
                                <asp:BoundField DataField="FindingAct" HeaderText="Action Required" HeaderStyle-CssClass="bg-light" />
                                <asp:BoundField DataField="AreaDesc" HeaderText="Area" HeaderStyle-CssClass="bg-light" />
                                <asp:TemplateField HeaderText="Picture" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="bg-light">
                                    <ItemTemplate>
                                        <%--<img src='<%# Eval("rmPict") %>' class="imgku" data-lightbox="image" onclick="" />--%>
                                        <a href='<%# Eval("rmPict") %>' class="img-link" rel="image-gallery">
                                            <img src='<%# Eval("rmPict") %>' class="imgku" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="AssignTo" HeaderText="Assign To" HeaderStyle-CssClass="bg-light" />
                                <asp:BoundField DataField="InspectStatus" HeaderText="Status" HeaderStyle-CssClass="bg-light rounded-end" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $(".img-link").colorbox({
                rel: "image-gallery",
                maxWidth: "90%",
                maxHeight: "90%"
            });
        });
    </script>
</asp:Content>