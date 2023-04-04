<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MeaTemplateEdit.ascx.vb" Inherits="TCRCWebV2.MeaTemplateEdit" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="myExtraLargeModalLabel">Template Add / Edit</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal"
                    aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="col-md-12">
                    <asp:HiddenField runat="server" ID="IDGroup" />
                    <div class="mb-3 row">
                        <label class="col-md-2 col-form-label">Unit Description</label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" data-trigger ID="ddUnitDesc" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <label class="col-md-2 col-form-label">Component</label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" data-trigger ID="ddComp" CssClass="form-control form-control-sm"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <label class="col-md-2 col-form-label">Description</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" CssClass="form-control" ID="tDesc"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <span runat="server" id="lNotif" class="alert alert-warning" visible="false"></span>
                <asp:Button ID="bSaveTemplate" runat="server" Text="Save" CssClass="btn btn-soft-purple btn-sm" OnClick="bSaveTemplate_Click"/>
                <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-soft-purple btn-sm" data-dismiss="modal" />
            </div>
        </div>
    </div>
</div>