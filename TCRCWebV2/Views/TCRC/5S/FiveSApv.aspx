<%@ Page Title="5S Oustanding Approval" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="FiveSApv.aspx.vb" Inherits="TCRCWebV2.FiveSApv" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row justify-content-center">
        <div class="col-md-8">
            <h5>My Outstanding Approval</h5>

            <asp:Repeater runat="server" ID="rpt_5s" OnItemDataBound="rpt_5s_ItemDataBound">
                <ItemTemplate>
                    <div class="card">
                        <div class="card-header d-flex align-items-start">
                            <div class="flex-grow-1">
                                <h6 class="card-title" runat="server" id="linspection">--</h6>
                                <span class="card-title-desc" runat="server" id="lsub"></span>
                            </div>
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="bapprove" OnClick="bapprove_Click" OnClientClick="return confirm('Anda yakin?')"> 
                                <i class="fa fa-check-circle text-success"></i> Approve
                            </asp:LinkButton>
                        </div>
                        <div class="card-body">
                            <div class="alert alert-warning" role="alert" id="lcount" runat="server">
                                A simple secondary alert—check it out!
                            </div>
                            <div class="table-responsive">
                                <asp:GridView runat="server" AutoGenerateColumns="false" ID="gv_apv" ShowHeaderWhenEmpty="true" EmptyDataText="Records tidak ditemukan.." CssClass="table table-hover align-middle table-check">
                                    <Columns>
                                        <asp:TemplateField HeaderText="#">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="bg-light text-center" />
                                            <ItemStyle Width="5" CssClass="text-center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Area" DataField="AreaDesc" ItemStyle-Width="40" HeaderStyle-CssClass="bg-light rounded-start" />
                                        <asp:BoundField HeaderText="Temuan" DataField="FindingDesc" ItemStyle-Width="40" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Action" DataField="FindingAct" ItemStyle-Width="40" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="RegisterBy" DataField="RegisterBy" ItemStyle-Width="10" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="RegisterDate" DataField="RegisterDate" ItemStyle-Width="10" HeaderStyle-CssClass="bg-light rounded-end" />
                                    </Columns>
                                </asp:GridView> 
                            </div> 
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater> 
        </div>
    </div>
</asp:Content>