<%@ Page Title="Assembly Measure Form" MasterPageFile="~/Report.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyMeaRev.aspx.vb" Inherits="TCRCWebV2.AssemblyMeaRev" %>
<%@ Register Src="~/Views/TCRC/Reports/CoverPage.ascx" TagPrefix="uc1" TagName="CoverPage" %>



<asp:Content runat="server" ContentPlaceHolderID="ReportDyn">
    <%--<uc1:CoverPage runat="server" ID="CoverPage" />--%>
    <div class="row">
        <div class="col-sm-12">
            <div class="page-title-box mb-3">
                <h4 class="mb-0 fw-bold" style="text-align:center">Digital Assembly Checksheet</h4>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <table class="table table-bordered table-sm">
                <tr>
                    <td class="bg-muted">
                        <div class="mb-0">
                            <label class="form-label fw-bold">Work Order Number</label><br />
                            <asp:Label ID="lwono" runat="server" CssClass="form-label">#</asp:Label>
                        </div>
                    </td>
                    <td class="bg-muted" colspan="2">
                        <div class="mb-0">
                            <label class="form-label fw-bold">Unit Number</label><br />
                            <asp:Label ID="lunitno" runat="server" CssClass="form-label">#</asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="bg-muted">
                        <div class="mb-0">
                            <label class="form-label fw-bold">Work Order Description</label><br />
                            <asp:Label ID="lwodesc" runat="server" CssClass="form-label">#</asp:Label>
                        </div>
                    </td>
                    <td class="bg-muted">
                        <div class="mb-0">
                            <label class="form-label fw-bold">Unit Description</label><br />
                            <asp:Label ID="lunitdesc" runat="server" CssClass="form-label">#</asp:Label>
                        </div>
                    </td>
                    <td class="bg-muted">
                        <div class="mb-0">
                            <label class="form-label fw-bold">Component</label><br />
                            <asp:Label ID="lcomp" runat="server" CssClass="form-label">#</asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    
    <asp:Repeater runat="server" ID="rpt_section" OnItemDataBound="rpt_section_ItemDataBound">
        <HeaderTemplate>
            <div class="row">
            <div class="col-xs-12">
        </HeaderTemplate>
        <ItemTemplate>
            <div id="sectionhead" style="page-break-inside: avoid !important">
                <h5 class="card-title text-primary fw-bold" style="text-align:center">
                    Section: <%# Eval("AssemblySection").ToString() %>
                </h5>
                <img class="mb-2" src='<%# Eval("PicturePathGroup") %>' style="display: block; margin-left:auto; margin-right:auto; Position:Static;"/>
            </div>
            <table class="table table-bordered table-sm">
                <thead>
                    <tr class="bg-warning">
                        <th class="text-center">No</th>
                        <th style="width:50%">Activity</th>
                        <th class="text-center">Measurement Type</th>
                        <th class="text-center">Technical Spesification</th>
                        <th>Actual Measurement</th>
                        <th>Mech</th>
                        <th>LH</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rpt_details" OnItemDataBound="rpt_details_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td class="text-center">
                                    <span runat="server" id="sseq"></span>
                                </td>
                                <td>
                                    <asp:Image runat="server" id="imgdet" src='<%# Eval("PicturePath").ToString() %>' class="img-fluid" visible="false" />
                                    <span runat="server" id="sactivity"></span>
                                </td>
                                <td class="text-center">
                                    <span runat="server" id="smeatype"></span>
                                </td>
                                <td class="text-center">
                                    <span runat="server" id="sspec"></span>
                                </td>
                                <td>
                                    <span runat="server" id="svalue"></span>
                                </td>
                                <td>
                                    <span runat="server" id="smodby"></span>
                                </td>
                                <td>
                                    <span runat="server" id="sapvby"></span>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <table class="table table-bordered" id="tApv">
                <tbody>
                    <tr>
                        <td class="bg-light fw-bold"></td>
                        <td class="bg-light fw-bold">Approved By</td>
                        <td class="bg-light fw-bold">Approved Date</td>
                    </tr>
                    <tr>
                        <td class="bg-light fw-bold">Mechanic</td>
                        <td><%# GetMechNameDate(Eval("AssemblySection"), "1") %></td>
                        <td><%# GetMechNameDate(Eval("AssemblySection"), "2") %></td>
                    </tr>
                    <tr>
                        <td class="bg-light fw-bold">Supervisor</td>
                        <td><%# GetSupvNameDate(Eval("AssemblySection"), "1") %></td>
                        <td><%# GetSupvNameDate(Eval("AssemblySection"), "2") %></td>
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
        <FooterTemplate>
            </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>