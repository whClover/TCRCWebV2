<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyTemplateGPPict.ascx.vb" Inherits="TCRCWebV2.AssemblyTemplateGPPict" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Section Picture Upload</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="mb-3">
                    <label class="form-label" for="default-input">Assembly Section Upload</label>
                    <asp:HiddenField runat="server" ID="gidgp" />
                    <asp:HiddenField runat="server" ID="gsection" />
                    <asp:FileUpload runat="server" CssClass="form-control" ID="fileupload" />
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bupload" OnClick="bupload_Click">
                    <i class="fa fa-upload"></i> Upload
                </asp:LinkButton>
            </div>
        </div>
    </div>
</div>