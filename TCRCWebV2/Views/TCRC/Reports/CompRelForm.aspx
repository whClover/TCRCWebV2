<%@ Page Title="Component Release Form" MasterPageFile="~/Report.Master" Language="vb" AutoEventWireup="false" CodeBehind="CompRelForm.aspx.vb" Inherits="TCRCWebV2.CompRelForm" %>

<asp:Content runat="server" ContentPlaceHolderID="ReportDyn">
    <div class="paper container">
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="d-flex align-items-center justify-content-sm-end">
                    <asp:image style="float: right;" runat="server" ImageUrl="~/assets/images/logo/Thiess.png" CssClass="img-responsive" height="52"></asp:image>
                </div>
                <span class="fw-bold" style="color:#0063B0;font-size:30px;clear:both;display: block;">
                    Balikpapan Support Facility TCRC Component Release Form
                </span>
                <div class="row">
                    <div class="col-md-12">
                        <table style="border-color:white" class="gridview table">
                            <tr>
                                <td style="width:20%">WO</td>
                                <td style="width:1%">:</td>
                                <td>
                                    <asp:Label ID="lWO" runat="server"></asp:Label>
                                </td>
                                <td style="width:20%">Component PN</td>
                                <td style="width:1%">:</td>
                                <td>
                                    <asp:Label ID="lCompPn" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%">Unit No</td>
                                <td style="width:1%">:</td>
                                <td>
                                    <asp:Label ID="lUnitNo" runat="server"></asp:Label>
                                </td>
                                <td style="width:20%">Component Register</td>
                                <td style="width:1%">:</td>
                                <td>
                                    <asp:Label ID="lCompReg" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%">Unit Model</td>
                                <td style="width:1%">:</td>
                                <td>
                                    <asp:Label ID="lUnitModel" runat="server"></asp:Label>
                                </td>
                                <td style="width:20%">Date</td>
                                <td style="width:1%">:</td>
                                <td>
                                    <asp:Label ID="lDateHead" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%">Comp Desc</td>
                                <td style="width:1%">:</td>
                                <td>
                                    <asp:Label ID="lCompDesc" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />

                <div class="row">
                    <div class="col-md-12">
                        <table class="gridview table table-bordered">
                            <thead>
                                <tr class="text-white" style="background-color:#0063B0">
                                    <th style="width:5%" class="text-center">No</th>
                                    <th style="width:85%" class="text-center">Description</th>
                                    <th class="text-center">Checklist</th>
                                </tr>
                            </thead>
                            <tbody style="color:#001641">
                                <tr>
                                    <td rowspan="7" class="text-center" style="background-color:#B5C9D6">1</td>
                                    <td>Visual Inspection</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>•	All bolts are properly secured and fitted</td>
                                    <td class="text-center"><asp:CheckBox ID="chkVisInsp1" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>•	Stand is proper & safe (no damage found on stand)</td>
                                    <td class="text-center"><asp:CheckBox ID="chkVisInsp2" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>•	Check the cover condition is properly secured for component protection</td>
                                    <td class="text-center"><asp:CheckBox ID="chkVisInsp3" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>•	Check cleanliness condition (no oil spill found)</td>
                                    <td class="text-center"><asp:CheckBox ID="chkVisInsp4" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>•	Check ID Stamp or ID Plate</td>
                                    <td class="text-center"><asp:CheckBox ID="chkVisInsp5" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>•	Check for unsafe condition</td>
                                    <td class="text-center"><asp:CheckBox ID="chkVisInsp6" runat="server" /></td>
                                </tr>
                                <tr style="background-color:#DAE4EA">
                                    <td rowspan="4" class="text-center" style="background-color:#B5C9D6">2</td>
                                    <td class="bg-soft-primary">Ensure the following report has been uploaded to the database</td>
                                    <td class="bg-soft-primary"></td>
                                </tr>
                                <tr style="background-color:#DAE4EA">
                                    <td>•	Assembly check sheet</td>
                                    <td class="text-center"><asp:CheckBox ID="chkAsmChk" runat="server" /></td>
                                </tr>
                                <tr style="background-color:#DAE4EA">
                                    <td>•	Test performance Component Report</td>
                                    <td class="text-center"><asp:CheckBox ID="chkTstPerfrom" runat="server" /></td>
                                </tr>
                                <tr style="background-color:#DAE4EA">
                                    <td>•	Photos of the component on different position</td>
                                    <td class="text-center"><asp:CheckBox ID="chkPhotoComp" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td class="text-center" style="background-color:#B5C9D6">3</td>
                                    <td>Antirust protection - Ensure utilising VCI (Viscous Corrosion Inhibitor) oil misting on component</td>
                                    <td class="text-center"><asp:CheckBox ID="chkAntiRust" runat="server" /></td>
                                </tr>
                                <tr style="background-color:#DAE4EA">
                                    <td class="text-center" style="background-color:#B5C9D6">4</td>
                                    <td>Paint Quality - No stretch found and paint fully covered the area to be painted</td>
                                    <td class="text-center"><asp:CheckBox ID="chkPaintQuality" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td class="text-center" style="background-color:#B5C9D6">5</td>
                                    <td>Wrapping / Sealing - Properly wrap or seal</td>
                                    <td class="text-center"><asp:CheckBox ID="chkWrapping" runat="server" /></td>
                                </tr>
                                <tr style="background-color:#DAE4EA">
                                    <td class="text-center" style="background-color:#B5C9D6">6</td>
                                    <td>Ensure seal installation attached on component</td>
                                    <td class="text-center"><asp:CheckBox ID="chkEnSealIns" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td class="text-center" style="background-color:#B5C9D6">7</td>
                                    <td>Ensure installation checklist attached on component</td>
                                    <td class="text-center"><asp:CheckBox ID="chkEnInstChk" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="background-color:#B5C9D6" colspan="3">Remarks / Finding</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:TextBox ID="tRemarks" style="background-color:#B5C9D6" runat="server" TextMode="MultiLine" Height="350" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="background-color:#B5C9D6">
                                    <td colspan="3">
                                        <div class="text-center">
                                          <div class="col-xs-6" style="display: inline-block;padding-right:350px">
                                            <asp:CheckBox ID="chkStatAcc" runat="server" /> Accept
                                          </div>
                                          <div class="col-xs-6" style="display: inline-block;padding-right:350px">
                                            <asp:CheckBox ID="chkStatRjt" runat="server" /> Reject
                                          </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="background-color:#B5C9D6">
                                    <td colspan="3">
                                        <asp:label runat="server" Text="Noted: If rejected, please notify for further instruction"></asp:label>
                                    </td>
                                </tr>
                                <tr style="background-color:#B5C9D6">
                                    <td colspan="3">
                                        <asp:label ID="lInspBy" runat="server" Text="Inspect By:"></asp:label>
                                    </td>
                                </tr>
                                <tr style="background-color:#B5C9D6">
                                    <td colspan="3">
                                        <asp:label ID="lDate" runat="server" Text="Date:"></asp:label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>