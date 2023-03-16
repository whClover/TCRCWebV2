<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MeaTemplateSecEdit.ascx.vb" Inherits="TCRCWebV2.MeaTemplateSecEdit" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="myExtraLargeModalLabel">Template Section Add / Edit</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="col-md-12">
                    <asp:HiddenField runat="server" ID="IDGroup" />

                    <div class="mb-3 row">
                        <label class="col-md-2 col-form-label">Sequence</label>
                        <div classc="col-md-10">
                            <asp:TextBox TextMode="Number" CssClass="form-control" runat="server" ID="tSeq"></asp:TextBox>
                        </div>
                    </div>

                    <div class="mb-3 row">
                        <asp:HiddenField runat="server" ID="cursection" />
                        <label class="col-md-2 col-form-label">Section Name</label>
                        <div classc="col-md-10">
                            <asp:TextBox CssClass="form-control" runat="server" ID="tSection"></asp:TextBox>
                        </div>
                    </div>

                    <div class="mb-3 row">
                        <label class="col-md-2 col-form-label">After Inspection</label>
                        <div classc="col-md-4">
                            <asp:DropDownList runat="server" ID="ddAftInsp" CssClass="form-control">
                                <asp:ListItem Value="" Text=""></asp:ListItem>
                                <asp:ListItem Value="0" Text="False"></asp:ListItem>
                                <asp:ListItem Value="1" Text="True"></asp:ListItem>                              
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <span runat="server" id="lNotif" class="alert alert-warning" visible="false"></span>
                <asp:Button ID="bSave" runat="server" Text="Save" CssClass="btn btn-soft-purple btn-sm" OnClick="bSave_Click"/>
                <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-soft-purple btn-sm" data-dismiss="modal" />
            </div>
        </div>
    </div>
</div>