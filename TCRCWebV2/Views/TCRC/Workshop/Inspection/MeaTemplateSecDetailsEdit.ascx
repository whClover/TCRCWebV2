<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MeaTemplateSecDetailsEdit.ascx.vb" Inherits="TCRCWebV2.MeaTemplateSecDetailsEdit" %>

<div runat="server" class="modal fade" id="panel1" data-bs-backdrop="static"
    data-bs-keyboard="false" tabindex="-1" role="dialog"
    aria-labelledby="staticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="myExtraLargeModalLabel">Template Items Add / Edit</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="col-md-12">
                    <asp:HiddenField runat="server" ID="IDDetail" />
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-floating mb-3">
                                <asp:HiddenField runat="server" ID="Action" />
                                <asp:HiddenField runat="server" ID="TypeID" />
                                <asp:TextBox ID="tIDGroup" runat="server" CssClass="form-control" placeholder="ID Group" ReadOnly="true"></asp:TextBox>
                                <label for="input-username">ID Group</label>
                            </div>
                        </div>
                        <div class="col-md-4" id="dIDDetails" runat="server">
                            <div class="form-floating mb-3">                                                       
                                <asp:TextBox ID="tIDDetail" runat="server" CssClass="form-control" placeholder="ID Details" ReadOnly="true"></asp:TextBox>
                                <label runat="server" ID="lIDDetail" for="input-username">ID Details</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating mb-3">                                                       
                                <asp:TextBox ID="tSeq" runat="server" CssClass="form-control" placeholder="Sequence" AutoCompleteType="disabled"></asp:TextBox>
                                <label for="input-username">Sequence</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-floating mb-3">                                                       
                                <asp:TextBox ID="tSec" runat="server" CssClass="form-control" placeholder="Section Name" AutoCompleteType="disabled" ReadOnly="true"></asp:TextBox>
                                <label for="input-username">Section Name</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-floating mb-3">
                                <asp:HiddenField runat="server" ID="tcurSubSec" />
                                <asp:TextBox ID="tSubSec" runat="server" CssClass="form-control" placeholder="Sub-Section Name" AutoCompleteType="disabled" ReadOnly="true"></asp:TextBox>
                                <label for="input-username">Sub-Section Name</label>
                            </div>
                        </div>
                        <div class="col-md-12" id="dItem" runat="server">
                            <div class="form-floating mb-3">                                                       
                                <asp:TextBox ID="tItem" runat="server" CssClass="form-control" placeholder="Item Desc" AutoCompleteType="disabled"></asp:TextBox>
                                <label runat="server" ID="lItem" for="input-username">Item Description</label>
                            </div>
                        </div>
                        <div class="col-md-6" id="dRowCount" runat="server">
                            <div class="form-floating mb-3">                                                       
                                <asp:TextBox ID="tRowCount" runat="server" CssClass="form-control" placeholder="Row Count" AutoCompleteType="disabled"></asp:TextBox>
                                <label runat="server" ID="lRowCount" for="input-username">Row Count</label>
                            </div>
                        </div>
                        <div class="col-md-6" id="dValType" runat="server">
                            <div class="form-floating mb-3">                                                       
                                <asp:DropDownList runat="server" CssClass="form-control" placeholder="Value Type" ID="ddValType">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Checked" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Number" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Free Text" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Reuse/Replace" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                                <label runat="server" ID="lddValType" for="input-username">Value Type</label>
                            </div>
                        </div>
                        <div class="col-md-12" id="dCostCol" runat="server">
                            <div class="form-floating mb-3">                                                       
                                <asp:TextBox ID="tCostCol" runat="server" CssClass="form-control" placeholder="Costume Column" AutoCompleteType="disabled"></asp:TextBox>
                                <label runat="server" ID="lCostCol" for="input-username">Costume Column</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">                
                <asp:Button ID="bSave" runat="server" Text="Save" CssClass="btn btn-soft-purple btn-sm" OnClick="bSave_Click" />
                <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-soft-purple btn-sm" data-dismiss="modal" />
            </div>
        </div>
    </div>
</div>