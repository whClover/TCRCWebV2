<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FiveSDetailsForm.ascx.vb" Inherits="TCRCWebV2.FiveSDetailsForm" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header bg-soft-primary">
                <h5 class="modal-title text-muted">Register Finding</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <asp:HiddenField runat="server" ID="hidarea" />
                <asp:HiddenField runat="server" ID="hidfinding" />
                <asp:HiddenField runat="server" ID="hidfindingGP" />
                <div class="mb-3">
                    <h6>Nama Area</h6>
                    <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="tArea"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <h6>Temuan</h6>
                    <asp:TextBox runat="server" CssClass="form-control" ID="tfinding" AutoCompleteType="none"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <h6>Action yang dilakukan</h6>
                    <asp:TextBox runat="server" CssClass="form-control" ID="taction" AutoCompleteType="none"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <div class="row mb-2">
                        <div class="col-md-8">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" ToolTip="Choose Picture to upload" AllowMultiple="true" />
                        </div>
                        <div class="col-md-4">
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-light" ID="bupload" OnClick="bupload_Click">
                                <i class="fa fa-upload"></i>
                            </asp:LinkButton>
                        </div>
                    </div>
                    <asp:ListBox runat="server" CssClass="form-control" ID="pictlist"></asp:ListBox>
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