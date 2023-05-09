<%@ Page Title="Assembly Measure Form" MasterPageFile="~/Report.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyMea.aspx.vb" Inherits="TCRCWebV2.AssemblyMea2" %>

<asp:Content runat="server" ContentPlaceHolderID="ReportDyn">
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
                    <td>
                        <div class="mb-0">
                            <label class="form-label fw-bold">Work Order Number</label><br />
                            <asp:Label ID="lwono" runat="server" CssClass="form-label">#</asp:Label>
                        </div>
                    </td>
                    <td colspan="2">
                        <div class="mb-0">
                            <label class="form-label fw-bold">Unit Number</label><br />
                            <asp:Label ID="lunitno" runat="server" CssClass="form-label">#</asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="mb-0">
                            <label class="form-label fw-bold">Work Order Description</label><br />
                            <asp:Label ID="lwodesc" runat="server" CssClass="form-label">#</asp:Label>
                        </div>
                    </td>
                    <td>
                        <div class="mb-0">
                            <label class="form-label fw-bold">Unit Description</label><br />
                            <asp:Label ID="lunitdesc" runat="server" CssClass="form-label">#</asp:Label>
                        </div>
                    </td>
                    <td>
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
                <img class="mb-2" runat="server" src="~/images/NoPicture.png" 
                    style="display: block; margin-left:auto; margin-right:auto; Position:Static;"/>
            </div>

            <asp:GridView runat="server" ID="gv_table" AutoGenerateColumns="false" CssClass="table table-bordered table-striped w-100" OnRowDataBound="gv_table_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="text-center" HeaderText="No" DataField="Sequence" />
                    <asp:BoundField HeaderStyle-CssClass="text-center" HeaderText="Activity" DataField="AssemblyDesc" HtmlEncode="false" />
                    <asp:BoundField HeaderStyle-CssClass="text-center" HeaderText="Measurement Type" DataField="UnitTypeDesc" />
                    <asp:BoundField HeaderStyle-CssClass="text-center" HeaderText="Technical Spesification" DataField="SpecFull" />
                    <asp:BoundField HeaderStyle-CssClass="text-center" HeaderText="Actual Measurement" DataField="AssemblyVal" />
                    <asp:BoundField HeaderStyle-CssClass="text-center" HeaderText="Mech" DataField="ModBy" />
                    <asp:BoundField HeaderStyle-CssClass="text-center" HeaderText="LH" DataField="ApprovedBy" />
                </Columns>
            </asp:GridView>
        </ItemTemplate>
        <FooterTemplate>
            </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
