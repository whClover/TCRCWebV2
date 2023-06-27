<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyAssign.ascx.vb" Inherits="TCRCWebV2.AssemblyAssign" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Assign Assembly Template to Checksheet</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="mb-3">
                    <label class="form-label" for="default-input">Work Order Number</label>
                    <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control form-control-sm" ID="modWONO"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label" for="default-input">WO Descriptions</label>
                    <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control form-control-sm" ID="modWODesc"></asp:TextBox>
                </div>
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label class="form-label" for="default-input">Unit Descriptions</label>
                        <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control form-control-sm" ID="modWOUnitDesc"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label" for="default-input">MaintID</label>
                        <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control form-control-sm" ID="modMaintID"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label" for="default-input">Component Name</label>
                        <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control form-control-sm" ID="modCompName"></asp:TextBox>
                    </div>
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