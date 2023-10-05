<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyTemplateSection.ascx.vb" Inherits="TCRCWebV2.AssemblyTemplateSection" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Assembly Section Add</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="mb-3">
                    <label class="form-label" for="default-input">Assembly Section</label>
                    <asp:HiddenField runat="server" ID="gidgp" />
                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tsection" AutoCompleteType="Disabled"></asp:TextBox>
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