<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MeaInspRemark.ascx.vb" Inherits="TCRCWebV2.MeaInspRemark" %>

<div id="panel1" runat="server" class="modal fade" tabindex="-1"
    aria-labelledby="exampleModalFullscreenLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalFullscreenLabel">Edit Remark</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <p class="text-muted mb-2">Section Remark</p>
                <textarea runat="server" id="summernote" name="editordata"></textarea>
                <script>
                    $('#MainContent_MeaInspRemark_summernote').summernote({
                        toolbar: false,
                        height: 200,
                        disableResizeEditor: true,
                    });
                </script>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" CssClass="btn btn-soft-purple" ID="bSave" Text="Save" OnClick="bSave_Click"/> 
                <button type="button" class="btn btn-soft-purple" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>