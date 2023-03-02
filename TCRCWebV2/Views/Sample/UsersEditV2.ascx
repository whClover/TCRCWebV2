<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UsersEditV2.ascx.vb" Inherits="TCRCWebV2.UsersEditV2" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Sample Modal</h5>
                <button type="button" class="btn-close" data-bs-dismiss="moda" aria-label="close"></button>
            </div>
            <div class="modal-body">
                <div class="col-md-12">
                    <asp:HiddenField runat="server" ID="userid" />
                    <div class="mb-3 row">
                        <label class="col-md-2 col-form-label">Username</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="tUsername"></asp:TextBox>
                    </div>
                    <div class="mb-3 row">
                        <label class="col-md-2 col-form-label">FullName</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="tFullname"></asp:TextBox>
                    </div>
                    <div class="mb-3 row">
                        <label class="col-md-2 col-form-label">Email Address</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="tEmailAddress"></asp:TextBox>
                    </div>
                    <div class="mb-3 row">
                        <label class="col-md-2 col-form-label">Job Title</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="tJobTitle"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <span runat="server" id="lNotif" class="alert alert-warning" visible="false"></span>
                    <asp:Button ID="bSave" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" OnClick="bSave_Click"/>
                    <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-primary btn-sm" data-dismiss="modal" />
            </div>
        </div>
    </div>
</div>