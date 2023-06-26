<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyAssign.ascx.vb" Inherits="TCRCWebV2.AssemblyAssign" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Assign Assembly Template to Checksheet</h5>
            </div>
            <div class="modal-body">
                <div class="mb-3">
                    <label class="form-label" for="default-input">Work Order Number</label>
                    <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label" for="default-input">WO Descriptions</label>
                    <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label" for="default-input">Assembly Template</label>
                    <asp:DropDownList runat="server" CssClass="form-select form-select-sm"></asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
</div>