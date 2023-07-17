<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyAssignEngine.ascx.vb" Inherits="TCRCWebV2.AssemblyAssignEngine" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Assign Assembly Template Engine</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="mb-3">
                    <label class="form-label" for="default-input">Work Order</label>
                    <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control form-control-sm" ID="modWONo"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label" for="default-input">Work Order Description</label>
                    <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control form-control-sm" ID="modWODesc"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label" for="default-input">Assembly Template</label>
                    <asp:DropDownList runat="server" CssClass="form-select form-select-sm" ID="modDDTemplate"></asp:DropDownList>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bassign" OnClick="bassign_Click">Assign</asp:LinkButton>
                <button type="button" class="btn btn-light" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>