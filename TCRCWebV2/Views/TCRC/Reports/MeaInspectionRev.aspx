<%@ Page Title="Component Release Form" MasterPageFile="~/Report.Master" Language="vb" AutoEventWireup="false" CodeBehind="MeaInspectionRev.aspx.vb" Inherits="TCRCWebV2.MeaInspectionRev" %>

<asp:Content runat="server" ContentPlaceHolderID="ReportDyn">
    <div class="row">
        <div class="col-sm-12">
            <div class="page-title-box mb-3">
                <h4 class="mb-0 fw-bold" style="text-align:center">Digital Inspection Checksheet</h4>
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
            <%--section--%>
            <h5 class="card-title text-primary fw-bold" style="text-align:left">
                Section: <%# Eval("SectionName").ToString() %>
            </h5>
            <img class="mb-2" runat="server" src='<%# Eval("PictureSection").ToString() %>' style="display: block; margin-left:auto; margin-right:auto; Position:Static;"/>
            <%--end: section--%>

            <%--subsection--%>
            <asp:Repeater runat="server" ID="rpt_subsection" OnItemDataBound="rpt_subsection_ItemDataBound">
                <HeaderTemplate>
                    <div style="text-align: center">
                </HeaderTemplate>
                
                <ItemTemplate>
                    <small class="text-center fw-bold"><mark>Sub-Section: <%# Eval("SubSectionName").ToString() %></mark></small>
                    
                    <table class="table table-bordered table-striped w-100 gridview">
                    <asp:Repeater runat="server" ID="rpt_ItemHead">
                        <HeaderTemplate>
                                <thead>
                                    <tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <th><%# Eval("ItemDesc") %></th>
                        </ItemTemplate>
                        <FooterTemplate>
                                    </tr>
                                </thead>
                            
                        </FooterTemplate>
                    </asp:Repeater>

                    <asp:Repeater runat="server" ID="rpt_ItemBody" OnItemDataBound="rpt_ItemBody_ItemDataBound">
                        <HeaderTemplate>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("StepDesc") %></td>
                                <asp:PlaceHolder ID="ph" runat="server"></asp:PlaceHolder>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                        </FooterTemplate>
                    </asp:Repeater>
                    </table>
                </ItemTemplate>

                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <%--end: subsection--%>
        </ItemTemplate>
        <FooterTemplate>
            </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

