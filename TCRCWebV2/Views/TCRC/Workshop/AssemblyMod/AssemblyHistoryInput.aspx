<%@ Page Title="Assembly History Input" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyHistoryInput.aspx.vb" Inherits="TCRCWebV2.AssemblyHistoryInput" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="alert alert-warning alert-dismissible fade show" role="alert">
                <i class="fa fa-clock me-2"></i>
                History Input
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-6">
                            <dl class="dl-horizontal">
                                <dt>Assembly Section</dt>
                                <dd runat="server" id="sSection">#</dd>
                                <dt>Assembly Descriptions</dt>
                                <dd runat="server" id="sDesc">#</dd>
                            </dl>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <asp:LinkButton runat="server" CssClass="btn btn-soft-primary mb-3 btn-sm" ID="bexport" OnClick="bexport_Click">
                        <i class="fa fa-download"></i> Export Data
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-soft-primary mb-3 btn-sm" ID="bback" OnClick="bback_Click">
                        <i class="fa fa-reply"></i> Back
                    </asp:LinkButton>
                    <div class="table-responsive">
                        <asp:GridView runat="server" CssClass="table table-hover table-bordered align-middle table-check table-sm" ID="gvhist" AutoGenerateColumns="false" EmptyDataText="No Records Found...">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="bg-light text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="WONo" DataField="WONo" HeaderStyle-CssClass="bg-light" />
                                <asp:BoundField HeaderText="Assembly Value" DataField="AssemblyVal" HeaderStyle-CssClass="bg-light" />
                                <asp:BoundField HeaderText="Input By" DataField="ModBy" HeaderStyle-CssClass="bg-light" />
                                <asp:BoundField HeaderText="Input Date" DataField="ModDate" HeaderStyle-CssClass="bg-light" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>