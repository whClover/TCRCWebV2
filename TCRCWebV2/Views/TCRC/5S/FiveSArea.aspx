<%@ Page Title="5S Area" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="FiveSArea.aspx.vb" Inherits="TCRCWebV2.FiveSArea" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/5S/FiveSAreaForm.ascx" TagPrefix="uc1" TagName="FiveSAreaForm" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <uc1:FiveSAreaForm runat="server" id="FiveSAreaForm" />
                <div class="card-header">
                    <h4 class="card-title">5S Area Register</h4>
                    <span class="card-title-desc" runat="server" id="hLocation">Test</span>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm" ID="badd" OnClick="badd_Click">
                            <i class="fa fa-plus"></i> Add Area
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm" ID="bback" OnClick="bback_Click">
                            <i class="fa fa-reply"></i> Back
                        </asp:LinkButton>
                    </div>
                    <asp:GridView runat="server" ID="gv5SArea" AutoGenerateColumns="false" CssClass="table table-bordered table-sm" OnRowDataBound="gv5SArea_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderStyle-CssClass="text-center bg-light" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="bedit" OnClick="bedit_Click" CommandArgument='<%# Eval("IDArea") %>'>
                                        <i class="fa fa-edit"></i>
                                    </asp:LinkButton>
                                    <%--<asp:LinkButton runat="server" CssClass="btn btn-soft-light" ID="bdeactive" OnClick="bdeactive_Click" CommandArgument='<%# Eval("IDArea") %>' OnClientClick="return confirm('Are you sure?')">
                                        <i class="fa fa-trash"></i>
                                    </asp:LinkButton>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No" HeaderStyle-CssClass="text-center bg-light" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblNo" CssClass="text-center" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Sequence" DataField="Seq" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center bg-light" />
                            <asp:BoundField HeaderText="Area Desc" DataField="AreaDesc" HeaderStyle-CssClass="bg-light" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>