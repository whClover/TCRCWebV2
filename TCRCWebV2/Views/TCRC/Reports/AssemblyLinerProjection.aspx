<%@ Page Title="Assembly Liner Projection" MasterPageFile="~/Report.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyLinerProjection.aspx.vb" Inherits="TCRCWebV2.AssemblyLinerProjection" %>

<asp:Content runat="server" ContentPlaceHolderID="ReportDyn">
    <div class="row">
        <div class="col-sm-12">
            <div class="page-title-box mb-3">
                <h4 class="mb-0 fw-bold" style="text-align:center">Digital Assembly Checksheet - Liner Projection</h4>
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
    <div class="alert alert-primary alert-dismissible fade show" role="alert">
        <i class="fa fa-info me-2"></i>
        Details Informations
    </div>

    <asp:Repeater runat="server" ID="rpt_liner">
        <ItemTemplate>
            <div class="row mb-3" style="page-break-inside: avoid !important">
                <div class="col-xs-12">
                    <div class="card border border-primary">
                        <div class="card-body">
                            <div class="d-flex justify-content-between">
                                <div>
                                    <h6 class="font-size-xs text-primary fw-bold">Cylinder No.<%# Eval("CylinderNo").ToString() %></h6>
                                    <div class="text-muted" style="font-size:12px">
                                        Spesifications:
                                        <%# Eval("LPMinUS") & Eval("LPMinUnitUS") & " - " & Eval("LPMaxUS") & Eval("LPMaxUnitUS") & "(US) | " %>
                                        <%# Eval("LPMinMetric") & Eval("LPMinUnitMetric") & " - " & Eval("LPMaxMetric") & Eval("LPMaxUnitMetric") & "(Metric)" %>
                                    </div>
                                </div>
                                <div>
                                    <span>Variations: <%# Eval("VarValue").ToString() %></span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="table-responsive">
                                        <table class="table table-borderless table-sm">
                                            <tr>
                                                <td class="fw-bold bg-light" style="text-align:left">A</td>
                                                <td><%# Eval("LPA").ToString() %></td>
                                                <td class="fw-bold bg-light" style="text-align:left">C</td>
                                                <td><%# Eval("LPC").ToString() %></td>
                                                <td rowspan="2" class="fw-bold text-primary" style="text-align:right">SUM A-D :</td>
                                                <td rowspan="2"><%# Eval("SumLP").ToString() %></td>
                                                <td rowspan="2" class="fw-bold text-primary" style="text-align:right">MIN A-D :</td>
                                                <td rowspan="2"><%# Eval("MinVal").ToString() %></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-size:11px">Input by <%# getLastModBy("LPA", Eval("CylinderNo")) %></td>
                                                <td colspan="2" style="font-size:11px">Input by <%# getLastModBy("LPC", Eval("CylinderNo")) %></td>
                                            </tr>
                                            <tr>
                                                <td class="fw-bold bg-light" style="text-align:left">B</td>
                                                <td><%# Eval("LPB").ToString() %></td>
                                                <td class="fw-bold bg-light" style="text-align:left">D</td>
                                                <td><%# Eval("LPD").ToString() %></td>
                                                <td rowspan="2" class="fw-bold text-primary" style="text-align:right">AVG A-D :</td>
                                                <td rowspan="2"><%# Eval("AVGLP").ToString() %></td>
                                                <td rowspan="2" class="fw-bold text-primary" style="text-align:right">MAX A-D :</td>
                                                <td rowspan="2"><%# Eval("MaxVal").ToString() %></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-size:11px">Input by <%# getLastModBy("LPB", Eval("CylinderNo")) %></td>
                                                <td colspan="2" style="font-size:11px">Input by <%# getLastModBy("LPD", Eval("CylinderNo")) %></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>