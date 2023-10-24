<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FiveSAssignArea.ascx.vb" Inherits="TCRCWebV2.FiveSAssignArea" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header bg-light">
                <h5 class="modal-title text-muted">Assign - 5S Area</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="mb-3">
                    <h6>5S Area</h6>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddArea"></asp:DropDownList>
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