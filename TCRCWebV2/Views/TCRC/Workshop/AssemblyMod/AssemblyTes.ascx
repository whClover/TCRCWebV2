<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyTes.ascx.vb" Inherits="TCRCWebV2.AssemblyTes" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog modal-dialog-centered modal-lg">
        <div class="modal-content">
            <div class="modal-header bg-soft-primary">
                <h5 class="modal-title text-muted">Assembly Gallery</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <asp:HiddenField runat="server" ID="hwono" />
                <div class="mb-3">
                    <h6>Assembly Section</h6>
                </div>
                <hr />
                <asp:Label CssClass="text-muted text-center" runat="server" ID="lna" Text="No Picture" Visible="false"></asp:Label>

            </div>
        </div>
    </div>
</div>