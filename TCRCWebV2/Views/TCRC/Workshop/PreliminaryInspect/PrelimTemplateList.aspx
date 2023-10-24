<%@ Page Title="Preliminary Template List" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="PrelimTemplateList.aspx.vb" Inherits="TCRCWebV2.PrelimTemplateList" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Preliminary Template List</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="alert alert-primary alert-dismissible fade show" role="alert" runat="server" id="cdata">
                            #
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="col-md-12">
                            <div class="d-flex flex-wrap gap-2">
                                <button class="btn btn-soft-light btn-sm" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight" aria-controls="offcanvasRight">
                                    <i class="fa fa-filter"></i> Filter Data
                                </button>
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light" ID="bexport" OnClick="bexport_Click">
                                    <i class="fa fa-download"></i> Export Data
                                </asp:LinkButton>
                            </div>
                            <!-- top offcanvas -->
                            <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
                                <div class="offcanvas-header bg-light">
                                    <h5 id="offcanvasTopLabel me-2">Filter Data</h5>
                                    <button type="button" class="btn-close text-reset btn-sm" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                                </div>
                                <div class="offcanvas-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <dl class="dl-horizontal">
                                                <dt>Unit Description</dt>
                                                <dd>
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddunitdesc"></asp:DropDownList>
                                                </dd>
                                                <dt>Sheet Name</dt>
                                                <dd>
                                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tsheetname" AutoCompleteType="Disabled"></asp:TextBox>
                                                </dd>
                                            </dl>
                                        </div>
                                        <div class="col-md-12">
                                            <dl class="dl-horizontal">
                                                <dt>Global Serial Number</dt>
                                                <dd>
                                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tGlobalSN" AutoCompleteType="Disabled"></asp:TextBox>
                                                </dd>
                                            </dl>
                                            <dl class="dl-horizontal">
                                                <dt>Deactive</dt>
                                                <dd>
                                                    <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="dddeactive">
                                                        <asp:ListItem Text="False" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="True" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </dd>
                                            </dl>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="bsearch" OnClick="bsearch_Click">
                                                <i class="fa fa-search"></i> Search
                                            </asp:LinkButton>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <asp:GridView runat="server" CssClass="table table-hover table-bordered align-middle table-check table-sm" ID="gvPrelim" AutoGenerateColumns="false" EmptyDataText="No Records Founds...">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-CssClass="bg-light">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="bdetails" OnClick="bdetails_Click" CommandArgument='<%# Eval("IDTemplateGroup") %>'>
                                                    <i class="fa fa-eye"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="bg-light" HeaderText="Unit Description">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" CssClass="btn btn-link btn-sm">
                                                    <%# Eval("UnitDesc").ToString() %>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Sheet Name" DataField="SheetName" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Maint ID" DataField="MaintID" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Global Component Serial Number" DataField="SerialGlobalPN" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Create By" DataField="CreateBy" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Create Date" DataField="CreateDate" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Modify By" DataField="ModBy" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Modify Date" DataField="ModDate" HeaderStyle-CssClass="bg-light" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>