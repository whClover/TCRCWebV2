<%@ Page Title="Edit Users" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="UsersEdit.aspx.vb" Inherits="TCRCWebV2.UsersEdit" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <form runat="server">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h4 class="card-title">Add/Edit User</h4>
                </div>
                <div class="card-body">
                    <div class="col-md-12">
                        <div class="mb-3">
                            <label for="tUserID">User ID</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tUserID" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="mb-3">
                            <label for="tUserName">Username</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tUserName"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="mb-3">
                            <label for="tFullName">Full Name</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tFullName"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="mb-3">
                            <label for="tEmail">Email Address</label>
                            <asp:TextBox TextMode="Email" runat="server" CssClass="form-control" ID="tEmail"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="mb-3">
                            <label for="tTitle">Job Title</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tTitle"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <div class="d-flex flex-wrap gap-2">
                        <asp:Button runat="server" CssClass="btn btn-soft-primary" Text="Save" />
                        <asp:Button runat="server" CssClass="btn btn-soft-primary" ID="bClose" OnClick="bClose_Click" Text="Close" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>