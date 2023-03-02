<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ComponentRelEdit.ascx.vb" Inherits="TCRCWebV2.ComponentRelEdit" %>

<!--  Large modal example -->
<div id="Panel1" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog"
    aria-labelledby="myLargeModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header bg-soft-purple">
                <h5 class="modal-title text-purple" id="myLargeModalLabel">Release Forms</h5>
                <button type="button" class="btn-close" data-dismiss="modal"
                    aria-label="Close">
                </button>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">WO</label>
                            <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tWONo" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Component PN</label>
                            <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tCompPN" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Unit No</label>
                            <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tUnitNo" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Component Register</label>
                            <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tCompReg" Enabled="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Unit Model</label>
                            <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tUnitModel" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Date</label>
                            <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tDate" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Component Desc</label>
                            <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tCompDesc" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <hr />
                <table class="table table-bordered gridview">
                    <thead>
                        <tr>
                            <th class="text-center text-purple bg-soft-purple" style="width:5%">No</th>
                            <th class="text-center text-purple bg-soft-purple">Descriptions</th>
                            <th class="text-center text-purple bg-soft-purple">Checklist</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td rowspan="7" class="text-center">1</td>
                            <td>Visual Inspection</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>● All bolts are properly secured and fitted</td>
                            <td class="text-center"><asp:CheckBox ID="chkVisInsp1" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>● Stand is proper & safe (no damage found on stand)</td>
                            <td class="text-center"><asp:CheckBox ID="chkVisInsp2" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>● Check the cover condition is properly secured for component protection</td>
                            <td class="text-center"><asp:CheckBox ID="chkVisInsp3" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>● Check cleanliness condition (no oil spill found)</td>
                            <td class="text-center"><asp:CheckBox ID="chkVisInsp4" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>● Check ID Stamp or ID Plate</td>
                            <td class="text-center"><asp:CheckBox ID="chkVisInsp5" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>● Check for unsafe condition</td>
                            <td class="text-center"><asp:CheckBox ID="chkVisInsp6" runat="server" /></td>
                        </tr>
                        <tr class="bg-soft-purple">
                            <td rowspan="4" class="text-center">2</td>
                            <td>Ensure the following report has been uploaded to the database</td>
                            <td></td>
                        </tr>
                        <tr class="bg-soft-purple">
                            <td>● Assembly check sheet</td>
                            <td class="text-center"><asp:CheckBox ID="chkAsmChk" runat="server" /></td>
                        </tr>
                        <tr class="bg-soft-purple">
                            <td>● Test performance Component Report</td>
                            <td class="text-center"><asp:CheckBox ID="chkTstPerform" runat="server" /></td>
                        </tr>
                        <tr class="bg-soft-purple">
                            <td>● Photos of the component on different position</td>
                            <td class="text-center"><asp:CheckBox ID="chkPhotoComp" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="text-center">3</td>
                            <td>Antirust protection - Ensure utilising VCI (Viscous Corrosion Inhibitor) oil misting on component</td>
                            <td class="text-center"><asp:CheckBox ID="chkAntiRust" runat="server" /></td>
                        </tr>
                        <tr class="bg-soft-purple">
                            <td class="text-center">4</td>
                            <td>Paint Quality - No stretch found and paint fully covered the area to be painted</td>
                            <td class="text-center"><asp:CheckBox ID="chkPaintQuality" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="text-center">5</td>
                            <td>Wrapping / Sealing - Properly wrap or seal</td>
                            <td class="text-center"><asp:CheckBox ID="chkWrapping" runat="server" /></td>
                        </tr>
                        <tr class="bg-soft-purple">
                            <td class="text-center">6</td>
                            <td>Ensure seal installation attached on component</td>
                            <td class="text-center"><asp:CheckBox ID="chkEnSealIns" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="text-center">7</td>
                            <td>Ensure installation checklist attached on component</td>
                            <td class="text-center"><asp:CheckBox ID="chkInstChk" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="bg-soft-purple">Remarks / Finding</td>
                        </tr>
                        <tr>
                            <td colspan="3" class="bg-soft-purple">
                                <asp:textbox TextMode="MultiLine" runat="server" CssClass="form-control" style="height:150px;" ID="tRemarks"></asp:textbox>
                            </td>
                        </tr>
                        <tr class="bg-soft-purple">
                            <td colspan="3">
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-4">
                                        <asp:CheckBox ID="chkStatAcc" runat="server"  /> Accept
                                    </div>
                                    <div class="col-md-2"></div>
                                    <div class="col-md-4">
                                        <asp:CheckBox ID="chkStatRjt" runat="server"  /> Reject
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr class="bg-soft-purple">
                            <td colspan="3">Noted: If rejected, please notify for further instruction</td>
                        </tr>
                        <tr class="bg-soft-purple">
                            <td colspan="3">
                                <asp:Label runat="server" ID="InspBy" Text="Inspect By:"></asp:Label>
                            </td>
                        </tr>
                        <tr class="bg-soft-purple">
                            <td colspan="3">
                                <asp:Label runat="server" ID="InspDate" Text="Date:"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="modal-footer">
                <asp:Button ID="bSave" runat="server" Text="Save" CssClass="btn btn-soft-purple btn-sm" OnClick="bSave_Click"/>
                <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-soft-purple btn-sm" data-dismiss="modal" />
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div><!-- /.modal -->