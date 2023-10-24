<%@ Page Title="5S Summary" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="FiveSSummary.aspx.vb" Inherits="TCRCWebV2.FiveSSummary" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header justify-content-between d-flex align-items-center">
                    <h5 class="card-title">5S Summary</h5>
                    <div>
                        <button class="btn btn-light btn-sm" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight" aria-controls="offcanvasRight">
                            <i class="fa fa-filter me-2"></i> Filter Data
                        </button>
                        <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm" ID="bgenPT" OnClick="bgenPT_Click">
                            <i class="fa fa-download me-2"></i> Generate Report
                        </asp:LinkButton>
                    </div>
                    <!-- right offcanvas -->
                    <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
                        <div class="offcanvas-header">
                            <h5 id="offcanvasRightLabel">Filter Data</h5>
                            <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                        </div>
                        <div class="offcanvas-body">
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
                            <div class="mb-3">
                                <h6>Locations</h6>
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddLoc"></asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <h6>Inspector</h6>
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddInspector"></asp:DropDownList>
                            </div>
                            <div class="row">
                                <div class="mt-2">
                                    <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm" ID="bsearch" OnClick="bsearch_Click">
                                        <i class="fa fa-search me-2"></i> Search
                                    </asp:LinkButton>
                                </div>
                            </div>
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
                        <asp:GridView runat="server" CssClass="table table-hover align-middle table-check table-sm" ID="gv5sSummary" AutoGenerateColumns="false">
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