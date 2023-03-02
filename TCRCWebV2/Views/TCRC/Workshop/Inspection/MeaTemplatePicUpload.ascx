<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MeaTemplatePicUpload.ascx.vb" Inherits="TCRCWebV2.MeaTemplatePicUpload" %>

<div id="panel1" runat="server" class="modal fade" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog modal-sm">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalFullscreenLabel">Upload Picture</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <asp:FileUpload ID="mod_upload" runat="server" />
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" CssClass="btn btn-soft-purple" Text="Upload" ID="bUpload" OnClick="bUpload_Click" />
                <button type="button" class="btn btn-soft-purple" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>