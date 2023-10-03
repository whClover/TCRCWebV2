<%@ Page Title="Component Release Edit" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="ComponenRelEdit.aspx.vb" Inherits="TCRCWebV2.ComponenRelEdit" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-7">
            <div class="card">
                <div class="card-header">
                    <div class="d-flex justify-content-between">
                        <h5 class="card-title">Component Release Checklist</h5>
                        <div>
                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm " ID="bsave" OnClick="bsave_Click">
                                <i class="fa fa-save"></i> Save
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm mx-1" ID="bprint" OnClick="bprint_Click">
                                <i class="fa fa-print"></i> Print
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="bclose" OnClick="bclose_Click">
                                <i class="fa fa-times"></i> Close
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="card-body">
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
                                <th class="text-center text-primary bg-soft-primary" style="width:5%">No</th>
                                <th class="text-center text-primary bg-soft-primary">Descriptions</th>
                                <th class="text-center text-primary bg-soft-primary">Checklist</th>
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
                            <tr class="bg-soft-primary">
                                <td rowspan="4" class="text-center">2</td>
                                <td>Ensure the following report has been uploaded to the database</td>
                                <td></td>
                            </tr>
                            <tr class="bg-soft-primary">
                                <td>● Assembly check sheet</td>
                                <td class="text-center"><asp:CheckBox ID="chkAsmChk" runat="server" /></td>
                            </tr>
                            <tr class="bg-soft-primary">
                                <td>● Test performance Component Report</td>
                                <td class="text-center"><asp:CheckBox ID="chkTstPerform" runat="server" /></td>
                            </tr>
                            <tr class="bg-soft-primary">
                                <td>● Photos of the component on different position</td>
                                <td class="text-center"><asp:CheckBox ID="chkPhotoComp" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="text-center">3</td>
                                <td>Antirust protection - Ensure utilising VCI (Viscous Corrosion Inhibitor) oil misting on component</td>
                                <td class="text-center"><asp:CheckBox ID="chkAntiRust" runat="server" /></td>
                            </tr>
                            <tr class="bg-soft-primary">
                                <td class="text-center">4</td>
                                <td>Paint Quality - No stretch found and paint fully covered the area to be painted</td>
                                <td class="text-center"><asp:CheckBox ID="chkPaintQuality" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="text-center">5</td>
                                <td>Wrapping / Sealing - Properly wrap or seal</td>
                                <td class="text-center"><asp:CheckBox ID="chkWrapping" runat="server" /></td>
                            </tr>
                            <tr class="bg-soft-primary">
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
                                <td colspan="3" class="bg-soft-primary">Remarks / Finding</td>
                            </tr>
                            <tr>
                                <td colspan="3" class="bg-soft-primary">
                                    <asp:textbox TextMode="MultiLine" runat="server" CssClass="form-control" style="height:150px;" ID="tRemarks"></asp:textbox>
                                </td>
                            </tr>
                            <tr class="bg-soft-primary">
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
                            <tr class="bg-soft-primary">
                                <td colspan="3">Noted: If rejected, please notify for further instruction</td>
                            </tr>
                            <tr class="bg-soft-primary">
                                <td colspan="3">
                                    <asp:Label runat="server" ID="InspBy" Text="Inspect By:"></asp:Label>
                                </td>
                            </tr>
                            <tr class="bg-soft-primary">
                                <td colspan="3">
                                    <asp:Label runat="server" ID="InspDate" Text="Date:"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class="col-md-5">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Component Release Photo</h5>
                </div>
                <style>
                    .grid-container {
                        display: grid;
                        grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
                        grid-gap: 10px; 
                    }

                    .grid-item {
                        text-align: center;
                        border: 1px;
                        border-color: #f5f6f8;
                        padding: 5px;
                    }

                    .delete-button {
                        position: absolute;
                        top: 0;
                        right: 0;
                        padding: 5px;
                        background-color: red;
                        color: white;
                        border: none;
                        cursor: pointer;
                    }

                    .image-container {
                        position: relative;
                        display: inline-block;
                        border-radius: 8px;
                        overflow: hidden;
                        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                    }

                    /* Media queries untuk membuat grid responsif */
                    @media (max-width: 767px) {
                        .grid-container {
                            grid-template-columns: repeat(auto-fit, minmax(150px, 1fr));
                        }
                    }

                    @media (max-width: 479px) {
                        .grid-container {
                            grid-template-columns: repeat(auto-fit, minmax(100px, 1fr));
                        }
                    }

                    .imgku {
                        height: 180px;
                        width: 220px;
                        object-fit: cover;
                    }
                </style>
                <div class="card-body">
                    <div class="mb-3">
                        <div class="mb-3">
                            <label class="form-label">Upload Photos</label>
                            <asp:FileUpload runat="server" CssClass="form-control" ID="FileUpload" AllowMultiple="true" />
                        </div>
                    </div>
                    <div class="mb-3">
                        <div class="mb-3">
                            <asp:LinkButton runat="server" CssClass="btn btn-sm btn-primary" OnClick="buploadpoct_Click" ID="buploadpoct">
                                <i class="fa fa-upload"></i> Upload Pictures
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Repeater runat="server" ID="rpt_pict">
                        <HeaderTemplate>
                            <div class="grid-container">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="grid-item">
                                <div class="image-container">
                                    <img src='<%# Eval("PicturePath").ToString() %>' class="imgku" />
                                    <%--<button class="delete-button">Hapus</button>--%>
                                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger delete-button" ID="bdel" OnClick="bdel_Click" OnClientClick="return confirm('Are you sure?');" CommandArgument='<%# Eval("IDPict").ToString() %>'>
                                        <i class="fa fa-trash"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>