<%@ Page Title="5S Form" MasterPageFile="~/Report.Master" Language="vb" AutoEventWireup="false" CodeBehind="FiveS.aspx.vb" Inherits="TCRCWebV2.FiveS" %>

<asp:Content runat="server" ContentPlaceHolderID="ReportDyn">
    <div class="row">
        <div class="col-md-12">
            <div class="d-flex align-items-start">
                <div class="flex-grow-1">
                    <img src="../../../images/logo/Thiess.png" style="height:50px" />
                </div>
                <h4 runat="server" id="htitle"></h4>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater runat="server" ID="rpt_5s" OnItemDataBound="rpt_5s_ItemDataBound">
                <HeaderTemplate>
                    <table class="table table-bordered table-sm">
                        <thead style="vertical-align:middle" class="text-center bg-light">
                            <tr>
                                <th>Inspector</th>
                                <th>Date</th>
                                <th>Finding</th>
                                <th>Action Required</th>
                                <th>Area</th>
                                <th>Picture</th>
                                <th>Assigned To</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr runat="server" id="tmprow">
                        <td>
                            <span class="form-label" runat="server" id="linsp"></span>
                        </td>
                        <td>
                            <span class="form-label" runat="server" id="linspdate"></span>
                        </td>
                        <td>
                            <span class="form-label" runat="server" id="lfinding"></span>
                        </td>
                        <td>
                            <span class="form-label" runat="server" id="lactionreq"></span>
                        </td>
                        <td>
                            <span class="form-label" runat="server" id="larea"></span>
                        </td>
                        <td>
                            <style>
                                .imgku {
                                    height: 100px;
                                    width: 200px;
                                    object-fit: contain;
                                }
                            </style>
                            <asp:Image runat="server" ID="linspimg" CssClass="imgku" />
                        </td>
                        <td>
                            <span class="form-label" runat="server" id="lassignto"></span>
                        </td>
                        <td>
                            <span class="form-label" runat="server" id="lstatus"></span>
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
</asp:Content>