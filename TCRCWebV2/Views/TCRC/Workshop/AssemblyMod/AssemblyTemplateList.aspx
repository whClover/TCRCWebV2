<%@ Page Title="Assembly Template List" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyTemplateList.aspx.vb" Inherits="TCRCWebV2.AssemblyTemplateList" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyTemplateForm.ascx" TagPrefix="uc1" TagName="AssemblyTemplateForm" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <uc1:AssemblyTemplateForm runat="server" id="AssemblyTemplateForm" />
    <div class="row">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Assembly Template List</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="mb-3">
                                <label>Unit Description</label>
                                <asp:DropDownList runat="server" ID="ddunitdesc" CssClass="form-control form-control-sm"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="mb-3">
                                <label>Template Description</label>
                                <asp:TextBox runat="server" ID="tDesc" CssClass="form-control form-control-sm"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="mb-3">
                                <label>Active</label>
                                <asp:DropDownList runat="server" ID="ddActive" CssClass="form-control form-control-sm">
                                    <asp:ListItem Text="TRUE" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="FALSE" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bsearch" OnClick="bsearch_Click">
                        <i class="fa fa-search"></i> Search
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="badd" OnClick="badd_Click">
                        <i class="fa fa-plus"></i> Add Template
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card">
                <div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <div class="d-flex align-items-center">
                                <div class="flex-shrink-0 me-3">
                                    <div class="avatar-sm">
                                        <div class="avatar-title rounded-circle font-size-12">
                                            <i class="fas fa-table"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="flex-grow-1">
                                    <p class="text-muted mb-1">Total Template Registered</p>
                                    <h5 class="font-size-16 mb-0" runat="server" id="htotalall"></h5>
                                </div>
                                <div class="flex-shrink-0 align-self-end">
                                    <div class="badge badge-soft-success ms-2">Up to date</div>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="d-flex align-items-center">
                                <div class="flex-shrink-0 me-3">
                                    <div class="avatar-sm">
                                        <div class="avatar-title rounded-circle font-size-12">
                                            <i class="fas fa-link"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="flex-grow-1">
                                    <p class="text-muted mb-1">Total Template Active</p>
                                    <h5 class="font-size-16 mb-0" runat="server" id="htotalactive"></h5>
                                </div>
                                <div class="flex-shrink-0 align-self-end">
                                    <div class="badge badge-soft-success ms-2">Up to date</div>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="d-flex align-items-center">
                                <div class="flex-shrink-0 me-3">
                                    <div class="avatar-sm">
                                        <div class="avatar-title rounded-circle font-size-12">
                                            <i class="fas fa-unlink"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="flex-grow-1">
                                    <p class="text-muted mb-1">Total Template In-Active</p>
                                    <h5 class="font-size-16 mb-0" runat="server" id="htotalinactive"></h5>
                                </div>
                                <div class="flex-shrink-0 align-self-end">
                                    <div class="badge badge-soft-success ms-2">Up to date</div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater runat="server" ID="rpt_udesc" OnItemDataBound="rpt_udesc_ItemDataBound">
                <ItemTemplate>
                    <h5 class="text-muted" id="hunitdesc" runat="server"></h5>
                    <div class="card">
                        <div class="card-body p-0">
                            <style>
                                .column-width {
                                    width: 400px; /* Sesuaikan lebar kolom sesuai kebutuhan */
                                }
                            </style>
                            <asp:GridView runat="server" CssClass="table table-hover table-bordered align-middle table-check table-sm" AutoGenerateColumns="false" ID="gv_list">
                                <Columns>
                                    <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="bg-light text-center" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Component Name" HeaderStyle-CssClass="bg-light" ItemStyle-CssClass="column-width">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-link" ID="bshow" OnClick="bshow_Click" CommandArgument='<%# Eval("IDTemplateAssemblyGroup") %>'><%# Eval("MaintIDDesc").ToString() %></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Template Description" DataField="AssemblyGroupName" HeaderStyle-CssClass="bg-light" ItemStyle-CssClass="column-width" />
                                    <asp:BoundField HeaderText="Register By" DataField="CreateBy" HeaderStyle-CssClass="bg-light" ItemStyle-CssClass="column-width" />
                                    <asp:BoundField HeaderText="Register Date" DataField="formCreateDate" HeaderStyle-CssClass="bg-light" ItemStyle-CssClass="column-width" />
                                    <asp:TemplateField HeaderStyle-CssClass="bg-light text-center" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm" ID="bedit" OnClick="bedit_Click" CommandArgument='<%# Eval("IDTemplateAssemblyGroup") %>'>
                                                <i class="fa fa-edit"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>