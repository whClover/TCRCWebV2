<%@ Page Title="Measure Inspection Worksheet" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="MeaInspWorksheet.aspx.vb" Inherits="TCRCWebV2.MeaInspWorksheet" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/Inspection/MeaInspBeforeAdd.ascx" TagPrefix="uc1" TagName="MeaInspBeforeAdd" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <!-- start page title -->
    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-flex align-items-center justify-content-between">
                <h4 class="mb-0">Measurement Inspection Worksheet</h4>

                <div class="page-title-right">
                    <ol class="breadcrumb m-0">
                        <li class="breadcrumb-item"><a href="javascript: void(0);">Workshop Page</a></li>
                        <li class="breadcrumb-item active">Measurement Inspection Worksheet</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <!-- end page title -->

    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                    <uc1:MeaInspBeforeAdd runat="server" ID="MeaInspBeforeAdd" />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                                <a class="nav-link mb-2 active" id="v-pills-home-tab" data-bs-toggle="pill" href="#v-pills-before" role="tab" aria-controls="v-pills-before" aria-selected="true">Before Inspection</a>
                                <a class="nav-link mb-2" id="v-pills-profile-tab" data-bs-toggle="pill" href="#v-pills-after" role="tab" aria-controls="v-pills-after" aria-selected="false">After Inspection</a>
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="tab-content text-muted mt-4 mt-md-0" id="v-pills-tabContent">

                                <%--Tab: Before Inspection--%>
                                <div class="tab-pane fade show active" id="v-pills-before" role="tabpanel" aria-labelledby="v-pills-before-tab">                              
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="mb-3">
                                                <label for="tWONo">WONo.</label>
                                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tWONo" AutoCompleteType="disabled"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="btn-group mt-4 mt-md-0" role="group" aria-label="Basic example">
                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-purple btn-sm mb-2" ID="bSearch" OnClick="bSearch_Click">
                                            <i class="fa fa-search"></i> Search
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-purple btn-sm mb-2" ID="bAddInsp" OnClick="bAddInsp_Click">
                                            <i class="fa fa-plus"></i> Add Inspection
                                        </asp:LinkButton>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            <asp:label runat="server" ID="bCount" CssClass="badge badge-soft-purple mb-3"></asp:label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="table-responsive">
                                                <asp:GridView runat="server" ID="gvInsp" CssClass="table table-striped table-bordered gridview" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="bDetailsTemp" CssClass="btn btn-link btn-sm text-purple" 
                                                                    CommandArgument='<%# Eval("WONo") %>' OnClick="bDetailsTemp_Click">
                                                                    Details
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="WONo" HeaderText="WONo" />
                                                        <asp:BoundField DataField="WODesc" HeaderText="Work Order Descriptions" />
                                                        <asp:BoundField DataField="UnitDescription" HeaderText="Unit Descriptions" />
                                                        <asp:BoundField DataField="ComponentName" HeaderText="Component" />
                                                        <asp:TemplateField HeaderText="Progress">
                                                            <ItemTemplate>
                                                                <div class="progress" style="height: 20px;">
                                                                    <div class="progress-bar bg-soft-purple" role="progressbar" style='<%# "width: " & Eval("InspCompletion") & "%" %>' 
                                                                        aria-valuenow='<%# Eval("InspCompletion") %>' aria-valuemin="0" 
                                                                        aria-valuemax="100"><%# Eval("InspCompletion") %>%</div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--Tab: After Inspection--%>
                                <div class="tab-pane fade" id="v-pills-after" role="tabpanel" aria-labelledby="v-pills-after-tab">
                                    
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="mb-3">
                                                <label for="tWONo">WONo.</label>
                                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tWONoAft" AutoCompleteType="disabled"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="btn-group mt-4 mt-md-0" role="group" aria-label="Basic example">
                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-purple btn-sm mb-2" ID="bSearchAft" OnClick="bSearchAft_Click">
                                            <i class="fa fa-search"></i> Search
                                        </asp:LinkButton>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            <asp:label runat="server" ID="bCountAft" CssClass="badge badge-soft-primary mb-3"></asp:label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="table-responsive">
                                                <asp:GridView runat="server" ID="gvInspAft" CssClass="table table-striped table-bordered gridview" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="bDetailsTemp" CssClass="btn btn-link btn-sm text-purple" 
                                                                    CommandArgument='<%# Eval("WONo") %>' OnClick="bDetailsTemp_Click">
                                                                    Details
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="WONo" HeaderText="WONo" />
                                                        <asp:BoundField DataField="WODesc" HeaderText="Work Order Descriptions" />
                                                        <asp:BoundField DataField="SectionName" HeaderText="Unit Descriptions" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div><!-- end col -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>