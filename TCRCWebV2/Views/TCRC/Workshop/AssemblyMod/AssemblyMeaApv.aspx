<%@ Page Title="Assembly Measure Approval" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyMeaApv.aspx.vb" Inherits="TCRCWebV2.AssemblyMeaApv" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyMenu.ascx" TagPrefix="uc1" TagName="AssemblyMenu" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title" runat="server" id="lwono">WO.</h5>
                    <small class="card-title-desc" runat="server" id="lwodesc">WO Desc.</small>
                </div>
                <div class="card-body">
                    <div class="row">
                        <uc1:AssemblyMenu runat="server" ID="AssemblyMenu" />
                        <div class="col-md-12">
                            <div class="tab-content text-muted mt-4 mt-md-0" id="v-pills-tabContent">
                                <div class="tab-pane fade show active">
                                    <ul class="nav nav-tabs nav-tabs-custom mb-3" role="tablist">
                                        <li class="nav-item" role="presentation">
                                            <asp:LinkButton runat="server" CssClass="nav-link" ID="bMea" OnClick="bMea_Click">
                                                <span class="d-block d-sm-none"><i class="far fa-user"></i></span>
                                                <span class="d-none d-sm-block">Measurement List</span> 
                                            </asp:LinkButton>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <asp:LinkButton runat="server" CssClass="nav-link active" ID="bSupvApv" OnClick="bSupvApv_Click">
                                                <span class="d-block d-sm-none"><i class="far fa-user"></i></span>
                                                <span class="d-none d-sm-block">Supervisor Approval</span> 
                                            </asp:LinkButton>
                                        </li>
                                    </ul>

                                    <div class="tab-content p-3 text-muted">
                                        <div class="tab-pane active" id="supvapv" role="tabpanel">
                                            <asp:GridView runat="server" CssClass="table table-bordered table-striped" ID="gv_supv" AutoGenerateColumns="false" OnRowDataBound="gv_supv_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField HeaderText="AssemblySection" DataField="AssemblySection" />
                                                    <asp:BoundField HeaderText="Measure %" DataField="Perc" />
                                                    <asp:BoundField HeaderText="LH Approval %" DataField="PercApproval" />
                                                    <asp:TemplateField HeaderText="Assigned To">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddSupv" 
                                                                OnSelectedIndexChanged="ddSupv_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Supv Approved By">
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" ID="bApv" OnClick="bApv_Click">Approve</asp:LinkButton>
                                                            <asp:Label runat="server" CssClass="form-label" ID="lApv"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
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