<%@ Page Title="Users Page" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="Users.aspx.vb" Inherits="TCRCWebV2.Users" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Register Src="~/Views/Sample/UsersEditV2.ascx" TagPrefix="uc1" TagName="UsersEditV2" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <!-- #include file = "~/Views/Shared/MenuTMRP.aspx" -->
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-flex align-items-center justify-content-between">
                    <h4 class="mb-0">Sample Page</h4>

                    <div class="page-title-right">
                        <ol class="breadcrumb m-0">
                            <li class="breadcrumb-item"><a href="javascript: void(0);">Site Master</a></li>
                            <li class="breadcrumb-item active">Table</li>
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
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bSearch" OnClick="bSearch_Click">
                                <i class="fa fa-search"></i> Search
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bAdd" OnClick="bAdd_Click">
                                <i class="fa fa-plus"></i> Add
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bExport" OnClick="bExport_Click" >
                                <i class="fas fa-download"></i> Export
                            </asp:LinkButton>
                        </div>
                        <asp:LinkButton runat="server" CssClass="btn btn-light" ID="bGetCheck" OnClick="bGetCheck_Click">
                            <i class="fas fa-check-circle"></i> Get-Checked
                        </asp:LinkButton>
                    </div><!-- end card header -->
                    <div class="card-body">
                        <uc1:UsersEditV2 runat="server" id="UsersEditV2" />
                        <div class="row">
                            <div class="col-md-4">
                                <div class="mb-3">
                                    <label for="tFullName">Full Name</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="tFullName" placeholder="..." AutoCompleteType="Disabled"></asp:TextBox>
                                </div>                                
                            </div>
                            <div class="col-md-4">
                                <div class="mb-3">
                                    <label for="tUserID">UserID</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="tUserID" placeholder="..." AutoCompleteType="Disabled"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label for="ddTitle">Job Title</label>
                                <asp:ListBox data-trigger id="ddTitle" runat="server" CssClass="form-control form-control-sm" Height="30px" SelectionMode="Multiple"></asp:ListBox>
                            </div>
                        </div>
                        <asp:Label runat="server" ID="lcount" CssClass="badge badge-soft-primary"></asp:Label>
                        <asp:Label runat="server" ID="lerror" CssClass="badge badge-soft-danger" style="text-align:left !important"></asp:Label>
                    </div>
                    <div class="card-footer">
                        <div class="pb-4">
                            <div data-simplebar style="max-height: 500px;">
                                <div class="table-responsive mt-2">

                                    <asp:GridView runat="server" ID="gvUser" AutoGenerateColumns="false" CssClass="table table-striped table-bordered gridview" 
                                        OnRowDataBound="gvUser_RowDataBound" ShowHeader="true">
                                        <Columns>

                                            <asp:TemplateField HeaderText="ID">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" OnCheckedChanged="chkSelectAll_CheckedChanged" AutoPostBack="true" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server"  />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="UserID">
                                                <ItemTemplate>
                                                    <asp:Button runat="server" ID="bEdit" CssClass="btn btn-link btn-sm" Text='<%# Eval("UserID") %>' OnClick="bEdit_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="UserName">
                                                <HeaderTemplate>
                                                    UserName
                                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tUsername"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("UserName") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>


			                                <asp:BoundField DataField="FullName" HeaderText="FullName" />

			                                <asp:BoundField DataField="Email" HeaderText="Email Address" />

			                                <asp:BoundField DataField="JobTitle" HeaderText="Title" />

		                                </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>        
                    </div>
                    <!-- end card body -->
                </div>
                <!-- end card -->
            </div>
        </div>
</asp:Content>