<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyMea.ascx.vb" Inherits="TCRCWebV2.AssemblyMea1" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog modal-dialog-centered modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Assembly Measurement (Edit)</h5>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="mb-3">
                        <asp:HiddenField runat="server" ID="eid" />
                        <asp:HiddenField runat="server" ID="evaltype" />
                        <label class="form-label" for="formrow-firstname-input">Activity</label><br />
                        <asp:Label runat="server" ID="lActitivty" CssClass="form-label"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label class="form-label" for="formrow-firstname-input">Measurement Type</label><br />
                                <asp:Label runat="server" ID="lMeaType" CssClass="form-label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label class="form-label" for="formrow-firstname-input">Spesification</label><br />
                                <asp:Label runat="server" ID="lSpec" CssClass="form-label"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="mb-3">
                        <label class="form-label" for="formrow-firstname-input">Values</label><br />
                        <asp:Label runat="server" ID="lvalue" CssClass="form-label"></asp:Label>
                        <div runat="server" id="mea1">
                            <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm">
                                OK
                            </asp:LinkButton>
                        </div>
                        <div runat="server" id="mea2" class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="emeanum" TextMode="Number" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                <div class="input-group-text" runat="server" id="lunit">@</div>
                            </div>
                        </div>
                        <div runat="server" id="mea3">
                            <asp:TextBox ID="emeatext" Height="150" TextMode="MultiLine" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton runat="server" OnClick="bsave_Click" ID="bsave" CssClass="btn btn-soft-light">Save Data</asp:LinkButton>
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>