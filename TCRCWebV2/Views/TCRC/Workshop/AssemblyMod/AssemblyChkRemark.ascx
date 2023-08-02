<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyChkRemark.ascx.vb" Inherits="TCRCWebV2.AssemblyChkRemark" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog modal-dialog-centered modal-lg">
        <div class="modal-content">
            <div class="modal-header bg-soft-primary">
                <h5 class="modal-title text-muted">Assembly Remark</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <asp:HiddenField runat="server" ID="hidinsdetail" />
                <asp:HiddenField runat="server" ID="hwono" />
                <div class="mb-3">
                    <h6>Remark</h6>
                    <asp:TextBox runat="server" CssClass="form-control" ID="tRemark" Rows="3"></asp:TextBox>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-light" data-dismiss="modal">Close</button>
                <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="bsave" OnClick="bsave_Click">
                    Save & Close
                </asp:LinkButton>
            </div>
        </div>
    </div>
</div>