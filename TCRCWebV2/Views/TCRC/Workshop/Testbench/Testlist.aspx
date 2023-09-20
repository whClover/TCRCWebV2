<%@ Page Title="Test List" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="Testlist.aspx.vb" Inherits="TCRCWebV2.Testlist" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h4 class="card-title">Worksheet Testing</h4>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="mb-3">
                                <label>Work Order Number</label>
                                <asp:TextBox runat="server" CssClass="form-control form-control-sm mb-3" ID="tWONo" AutoCompleteType="disabled"></asp:TextBox>
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bsearch" OnClick="bsearch_Click">
                                    <i class="fa fa-search"></i> Search
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView runat="server" CssClass="table table-hover align-middle table-check table-sm" ID="gvTest" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="bg-light text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="WONo" HeaderStyle-CssClass="bg-light text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" CssClass="btn btn-link" ID="bedit" OnClick="bedit_Click" CommandArgument='<%# Eval("WONo").ToString() %>'>
                                            <%# Eval("WONo") %>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                <asp:BoundField HeaderText="WO Description" DataField="WODesc" HeaderStyle-CssClass="bg-light" />
                                <asp:BoundField HeaderText="Percent Progress" DataField="PercProg" HeaderStyle-CssClass="bg-light text-center" ItemStyle-CssClass="text-center" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>