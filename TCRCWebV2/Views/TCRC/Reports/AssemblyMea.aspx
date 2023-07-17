<%@ Page Title="Assembly Measure Form" MasterPageFile="~/Report.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyMea.aspx.vb" Inherits="TCRCWebV2.AssemblyMea2" %>
<%@ Register Src="~/Views/TCRC/Reports/CoverPage.ascx" TagPrefix="uc1" TagName="CoverPage" %>

<asp:Content runat="server" ContentPlaceHolderID="ReportDyn">
    <uc1:CoverPage runat="server" ID="CoverPage" />
    <div class="row">
        <div class="col-sm-12">
            <div class="page-title-box mb-3">
                <h4 class="mb-0 fw-bold" style="text-align:center">Digital Assembly Checksheet</h4>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <table class="table table-bordered">
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

            <asp:GridView runat="server" ID="gv_table" AutoGenerateColumns="false" CssClass="table table-bordered w-100" OnRowDataBound="gv_table_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="text-center bg-warning" HeaderText="No" DataField="Sequence" />
                    <%--<asp:BoundField HeaderStyle-CssClass="text-center bg-warning" HeaderText="Activity" DataField="AssemblyDesc" HtmlEncode="false" />--%>
                    <asp:TemplateField HeaderStyle-CssClass="text-center bg-warning" HeaderText="Activity">
                        <ItemTemplate>
                            <asp:Image runat="server" id="imgdet" src='<%# Eval("PicturePath").ToString() %>' class="img-fluid" visible='<%# Eval("PicturePath") != "" %>' /> <br />
                            <span class="form-label" runat="server" id="pActivity"><%# Eval("AssemblyDesc").ToString() %></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderStyle-CssClass="text-center bg-warning" HeaderText="Measurement Type" DataField="UnitTypeDesc" />
                    <asp:BoundField HeaderStyle-CssClass="text-center bg-warning" HeaderText="Technical Spesification" DataField="SpecFull" />
                    <asp:BoundField HeaderStyle-CssClass="text-center bg-warning" HeaderText="Actual Measurement" DataField="AssemblyVal" />
                    <asp:BoundField HeaderStyle-CssClass="text-center bg-warning" HeaderText="Mech" DataField="ModBy" />
                    <asp:BoundField HeaderStyle-CssClass="text-center bg-warning" HeaderText="LH" DataField="ApprovedBy" />
                </Columns>
            </asp:GridView>

            <table class="table table-bordered" id="tApv">
                <tbody>
                    <tr>
                        <td class="bg-warning fw-bold"></td>
                        <td class="bg-warning fw-bold">Approved By</td>
                        <td class="bg-warning fw-bold">Approved Date</td>
                    </tr>
                    <tr>
                        <td class="bg-warning fw-bold">Mechanic</td>
                        <td><%# GetMechNameDate(Eval("AssemblySection"), "1") %></td>
                        <td><%# GetMechNameDate(Eval("AssemblySection"), "2") %></td>
                    </tr>
                    <tr>
                        <td class="bg-warning fw-bold">Supervisor</td>
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
    <div class="last-page">
      <!-- konten terakhir dokumen -->
    </div>
</asp:Content>
