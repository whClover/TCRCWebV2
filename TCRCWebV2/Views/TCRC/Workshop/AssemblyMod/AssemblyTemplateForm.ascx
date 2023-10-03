<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyTemplateForm.ascx.vb" Inherits="TCRCWebV2.AssemblyTemplateForm" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Assembly Template Form</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="mb-3">
                    <label class="form-label" for="default-input">Unit Description</label>
                    <asp:HiddenField runat="server" ID="hid" />
                    <asp:DropDownList runat="server" ID="ddunitdesc" CssClass="form-control form-control-sm"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label" for="default-input">Template Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="tTemplateName"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label" for="default-input">Maint ID</label>
                    <asp:DropDownList runat="server" ID="ddMaintID" CssClass="form-control form-control-sm"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label" for="default-input">Active</label>
                    <asp:DropDownList runat="server" ID="ddActive" CssClass="form-control form-control-sm">
                        <asp:ListItem Text="True" Value="1"></asp:ListItem>
                        <asp:ListItem Text="False" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bsave" OnClick="bsave_Click">
                    <i class="fa fa-save"></i> Save
                </asp:LinkButton>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
        </div>
    </div>
</div>