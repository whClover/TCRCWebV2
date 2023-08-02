<%@ Page Title="Assembly Piston Rec." MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyPistonRec.aspx.vb" Inherits="TCRCWebV2.AssemblyPistonRec" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyMenu.ascx" TagPrefix="uc1" TagName="AssemblyMenu" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyAssignEngine.ascx" TagPrefix="uc1" TagName="AssemblyAssignEngine" %>



<asp:Content ContentPlaceHolderID="MenuContent" runat="server">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <uc1:AssemblyAssignEngine runat="server" ID="AssemblyAssignEngine" />
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title" runat="server" id="lwono">WO.</h5>
                    <small class="card-title-desc" runat="server" id="lwodesc">WO Desc.</small>
                </div>
                <div class="card-body">
                    <div class="row">
                        <uc1:AssemblyMenu runat="server" id="AssemblyMenu" />
                        <div class="col-md-12">
                            <div class="d-flex flex-wrap gap-2 mb-2 fw-bold">
                                <u>Tools</u>
                            </div>
                            <div class="mt-3 mb-3">
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bna" OnClick="bna_Click" OnClientClick="return confirm('Are you sure?')">All n/a</asp:LinkButton>
                            </div>
                            <div class="d-flex flex-wrap gap-2 mb-2 fw-bold">
                                <u>Piston Recommendation</u>
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
                                    <div class="table-responsive">
                                        <asp:Repeater runat="server" ID="rpt_PistonRec" OnItemCommand="rpt_PistonRec_ItemCommand" OnItemDataBound="rpt_PistonRec_ItemDataBound">
                                            <HeaderTemplate>
                                                <table class="table table-hover table-nowrap mb-0 align-middle table-check">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>Recommendation</th>
                                                            <th>Bolt Recommendation</th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <span class="form-label" runat="server" id="pNo">#</span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddRec" CssClass="form-control form-control-sm">
                                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                                            <asp:ListItem Text="REUSE" Value="REUSE"></asp:ListItem>
                                                            <asp:ListItem Text="NEW" Value="NEW"></asp:ListItem>
                                                            <asp:ListItem Text="DSG" Value="DSG"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddBoldRec" CssClass="form-control form-control-sm">
                                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                                            <asp:ListItem Text="REUSE" Value="REUSE"></asp:ListItem>
                                                            <asp:ListItem Text="NEW" Value="NEW"></asp:ListItem>
                                                            <asp:ListItem Text="DSG" Value="DSG"></asp:ListItem>
                                                            <asp:ListItem Text="MCBEE" Value="MCBEE"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" CommandArgument='<%# Eval("CylinderNo") %>' CommandName="Save">
                                                            <i class="fa fa-save"></i> Save
                                                        </asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
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