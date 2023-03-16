<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MeaInspBeforeAdd.ascx.vb" Inherits="TCRCWebV2.MeaInspBeforeAdd" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Add Inspection</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="mb-3">
                                <label class="form-label" for="ddWONo">Work Order Number</label>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="two"></asp:TextBox>
                                        <small runat="server" id="twodesc">-</small>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="bSearch" OnClick="bSearch_Click">
                                            <i class="fa fa-search"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mb-3">
                            <label class="form-label" for="formrow-firstname-input">Inspection Template Available</label>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddInspTemp" CssClass="form-control"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="bSave" runat="server" Text="Assign Template" CssClass="btn btn-soft-purple btn-sm" OnClick="bSave_Click"/>
                <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-soft-purple btn-sm" data-dismiss="modal" />
            </div>
        </div>
    </div>
</div>