<%@ Page Title="Assembly List" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyList.aspx.vb" Inherits="TCRCWebV2.AssemblyList" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Assembly List</h5>
                    <small class="card-title-desc">List of Work Order Progress on Assembly</small>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="mb-3">
                                <label for="tWONo">Work Order Number</label>
                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tWONo" AutoCompleteType="disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-3">
                                <label for="tWONo">Workshop</label>
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddWs">
                                    <asp:ListItem Text="Powertrain" Value="Powertrain"></asp:ListItem>
                                    <asp:ListItem Text="Engine" Value="Engine"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-3">
                                <label for="tWONo">Status</label>
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddStatus">
                                    <asp:ListItem Text="Waiting Assign" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="In-progress" Value="1" Selected></asp:ListItem>
                                    <asp:ListItem Text="LH Approval" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Supv Approval" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Complete" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-3">
                                <label for="tWONo">Year</label>
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddYear">
                                    <asp:ListItem Text="> 2023" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="< 2023" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="btn-group mt-4 mt-md-0" role="group" aria-label="Basic example">
                        <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bSearch" OnClick="bSearch_Click">
                            <i class="fa fa-search"></i> Search
                        </asp:LinkButton>
                    </div>
                    <hr />
                    <div class="table-responsive">
                        <asp:GridView runat="server" CssClass="table table-hover table-nowrap table-check" AutoGenerateColumns="false" ID="gv_asm" OnRowDataBound="gv_asm_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderStyle-CssClass="bg-light text-center fw-bold text-muted" HeaderText="#">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandArgument='<%# Eval("WONo") %>' runat="server" ID="bedit" CssClass="btn btn-sm" OnClick="bedit_Click">
                                            <i class="fa fa-eye text-muted"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="bupload" CssClass="btn btn-sm" OnClick="bupload_Click">
                                            <i class="fa fa-upload text-muted"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="bprint" CssClass="btn btn-sm" OnClick="bprint_Click">
                                            <i class="fa fa-print text-muted"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bassign">
                                            Assign
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderStyle-CssClass="bg-light" DataFormatString="#{0}" ItemStyle-CssClass="fw-bold" HeaderText="WONo" DataField="WONo" />
                                <asp:BoundField HeaderStyle-CssClass="bg-light" ItemStyle-CssClass="text-muted" HeaderText="WO Descriptions" DataField="WODesc" />
                                <asp:BoundField HeaderStyle-CssClass="bg-light" HeaderText="Measurement" DataField="MeasurementCompletion" />
                                <asp:BoundField HeaderStyle-CssClass="bg-light" HeaderText="Checksheet" DataField="CheckSheetCompletion" />
                                <asp:BoundField HeaderStyle-CssClass="bg-light" HeaderText="LH Approval" DataField="AsmLH_Perc" />
                                <asp:BoundField HeaderStyle-CssClass="bg-light" HeaderText="Total Completion" DataField="AssemblyCompletion" />
                                <asp:BoundField HeaderStyle-CssClass="bg-light" HeaderText="Supv Approval" DataField="AsmSPV_Perc" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>