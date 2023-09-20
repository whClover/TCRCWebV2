<%@ Page Title="Assembly Dyno" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyDyno.aspx.vb" Inherits="TCRCWebV2.AssemblyDyno" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content ContentPlaceHolderID="MenuContent" runat="server">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title" runat="server" id="lwono">WO.</h5>
                    <small class="card-title-desc" runat="server" id="lwodesc">WO Desc.</small>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="d-flex flex-wrap gap-2 mb-2 fw-bold">
                                <u>Dyno Check</u>
                            </div>
                            <div class="mt-3 mb-3">
                                <p class="text-muted font-size-13 mb-1" runat="server" id="lSectionProg">Overall Progress (50%)</p>
                                <div class="progress animated-progess custom-progress">
                                    <div runat="server" id="pSectionProg" class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Repeater runat="server" ID="rpt_section" OnItemDataBound="rpt_section_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="mb-2">
                                                <h5 class="card-title" runat="server" id="hSection"></h5>
                                            </div>

                                            <asp:Repeater runat="server" ID="rpt_dyno" OnItemDataBound="rpt_dyno_ItemDataBound">
                                                <HeaderTemplate>
                                                    <div class="mb-5">
                                                    <table class="table table-hover mb-0 align-middle table-bordered table-sm">
                                                        <thead>
                                                            <tr class="bg-light">
                                                                <th class="text-center" style="width:3%">No</th>
                                                                <th style="width:50%">Activity</th>
                                                                <th class="text-center">Spesifications</th>
                                                                <th class="text-center">Actual Measurement</th>
                                                                <th>Mech</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <%# Container.ItemIndex + 1 %>
                                                        </td>
                                                        <td>
                                                            <span class="form-label" runat="server" id="pActivity"></span>
                                                        </td>
                                                        <td class="text-center">
                                                            <span class="form-label" runat="server" id="pSpec"></span>
                                                        </td>
                                                        <td class="text-center">
                                                            <span class="form-label" runat="server" id="pMeasurement"></span>
                                                            <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bcheck" Visible="false" OnClick="bcheck_Click" CommandArgument='<%# Eval("IDDynoInput") %>'>
                                                                <i class="fa fa-check"></i>
                                                            </asp:LinkButton>
                                                            <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tVal" Visible="false" OnTextChanged="tVal_TextChanged"
                                                            IDDyno='<%# Eval("IDDynoInput") %>' ValType='<%# Eval("ValType") %>' AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <span class="form-label" runat="server" id="pMech"></span>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                        </tbody>
                                                    </table>
                                                    </div>
                                                    <hr />
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="mb-2">
                                        <h5 class="card-title" runat="server">Dyno Remark</h5>
                                    </div>
                                    <div class="mb-2">
                                        <textarea runat="server" class="form-control" id="tRemark" style="height:120px"></textarea>
                                    </div>
                                    <div class="mb-2">
                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bsaverem" OnClick="bsaverem_Click">
                                            <i class="fa fa-save"></i> Save Remark
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>