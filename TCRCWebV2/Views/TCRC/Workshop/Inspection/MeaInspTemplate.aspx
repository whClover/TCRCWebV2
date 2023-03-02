<%@ Page Title="Measure Inspection Template" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="MeaInspTemplate.aspx.vb" Inherits="TCRCWebV2.MeaInspTemplate" %>
<%@ Register Src="~/Views/TCRC/Workshop/Inspection/MeaTemplateEdit.ascx" TagPrefix="uc1" TagName="MeaTemplateEdit" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" id="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <!-- start page title -->
    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-flex align-items-center justify-content-between">
                <h4 class="mb-0">Measurement Inspection List</h4>

                <div class="page-title-right">
                    <ol class="breadcrumb m-0">
                        <li class="breadcrumb-item"><a href="javascript: void(0);">Workshop Page</a></li>
                        <li class="breadcrumb-item active">Measurement Inspection Template</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <!-- end page title -->

    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-header justify-content-between d-flex align-items-center">
                    <%--<h4 class="card-title">User Table</h4>--%>
                    <div class="btn-group mt-4 mt-md-0" role="group" aria-label="Basic example">
                        <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="bSearch" OnClick="bSearch_Click">
                            <i class="fa fa-search"></i> Search
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="bAdd" OnClick="bAdd_Click">
                            <i class="fa fa-plus"></i> Add
                        </asp:LinkButton>
                    </div>
                </div><!-- end card header -->
                <div class="card-body">
                    <uc1:MeaTemplateEdit runat="server" id="MeaTemplateEdit" />
                    <div class="row">
                        <div class="col-md-4">
                            <div class="mb-3">
                                <label for="tDesc">Description</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="tDesc" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>                                
                        </div>
                        <div class="col-md-4">
                            <div class="mb-3">
                                <label for="tUserID">Component</label>
                                <asp:DropDownList runat="server" data-trigger ID="ddComp" CssClass="form-control form-control-sm"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label for="ddTitle">Unit Description</label>
                            <asp:DropDownList runat="server" data-trigger ID="ddUnitDesc" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>
                    <asp:Label runat="server" ID="lcount" CssClass="badge badge-soft-primary"></asp:Label>
                    <asp:Label runat="server" ID="lerror" CssClass="badge badge-soft-danger" style="text-align:left !important"></asp:Label>
                </div>
                <div class="card-footer">
                    <div class="pb-4">
                        <asp:Label runat="server" ID="tes"></asp:Label>
                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="gvInsp" AutoGenerateColumns="false" CssClass="table table-striped table-bordered gridview">
                                <Columns>
                                    <asp:TemplateField ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="bDetailsTemp" CssClass="btn btn-link btn-sm text-purple" CommandArgument='<%# Eval("IDGroup") %>' OnClick="bDetailsTemp_Click">
                                                Details
                                            </asp:LinkButton> | 
                                            <asp:LinkButton runat="server" ID="bEditTemp" CssClass="btn btn-link btn-sm text-purple" CommandArgument='<%# Eval("IDGroup") %>' OnClick="bEditTemp_Click">
                                                Edit
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IDGroup" HeaderText="ID" />
                                    <asp:BoundField DataField="UnitDesc" HeaderText="Unit Description" />
                                    <asp:BoundField DataField="ComponentName" HeaderText="Component" />
                                    <asp:BoundField DataField="TemplateDesc" HeaderText="Description" />
                                    <asp:BoundField DataField="RegisterBy" HeaderText="Register By" />
                                    <asp:BoundField DataField="RegisterDate" HeaderText="Register Date" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
