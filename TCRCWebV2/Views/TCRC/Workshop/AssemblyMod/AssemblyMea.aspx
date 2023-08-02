<%@ Page Title="Assembly List" MasterPageFile="~/Site.Master" MaintainScrollPositionOnPostback="true" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyMea.aspx.vb" Inherits="TCRCWebV2.AssemblyMea" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyMea.ascx" TagPrefix="uc1" TagName="AssemblyMea" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyGallery.ascx" TagPrefix="uc1" TagName="AssemblyGallery" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyMenu.ascx" TagPrefix="uc1" TagName="AssemblyMenu" %>



<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        window.addEventListener("scroll", function () {
            var scrollPosition = window.pageYOffset;
            document.getElementById('<%=ScrollPosition.ClientID %>').value = scrollPosition;
        });
    </script>
    <asp:HiddenField runat="server" ID="ScrollPosition" />
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <uc1:AssemblyMea runat="server" id="AssemblyMea" />
                <uc1:AssemblyGallery runat="server" id="AssemblyGallery" />
                <div class="card-header">
                    <h5 class="card-title" runat="server" id="lwono">WO.</h5>
                    <small class="card-title-desc" runat="server" id="lwodesc">WO Desc.</small>
                </div>
                <div class="card-body">
                    <div class="row">
                        <uc1:AssemblyMenu runat="server" id="AssemblyMenu" />
                        <div class="col-md-12">
                            <div class="tab-content text-muted mt-4 mt-md-0" id="v-pills-tabContent">
                                <div class="tab-pane fade show active">
                                    
                                    <ul class="nav nav-tabs nav-tabs-custom mb-3" role="tablist">
                                        <li class="nav-item" role="presentation">
                                            <asp:LinkButton runat="server" CssClass="nav-link active" ID="bMea" OnClick="bMea_Click">
                                                <span class="d-block d-sm-none"><i class="far fa-user"></i></span>
                                                <span class="d-none d-sm-block">Measurement List</span> 
                                            </asp:LinkButton>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <asp:LinkButton runat="server" CssClass="nav-link" ID="bSupvApv" OnClick="bSupvApv_Click">
                                                <span class="d-block d-sm-none"><i class="far fa-user"></i></span>
                                                <span class="d-none d-sm-block">Supervisor Approval</span> 
                                            </asp:LinkButton>
                                        </li>
                                    </ul>

                                    <div class="tab-content p-3 text-muted">
                                        <div class="tab-pane active" id="mealist" role="tabpanel">
                                            <div class="d-flex flex-wrap gap-2 mb-2 fw-bold">
                                                <u>Tools</u>
                                            </div>
                                            <div class="d-flex flex-wrap gap-2 mb-3">
                                                <asp:LinkButton runat="server" CssClass="btn btn-rounded btn-soft-primary btn-sm" ID="bgallery" OnClick="bgallery_Click">
                                                    <i class="fa fas fa-photo-video"></i> Assembly Gallery
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server" CssClass="btn btn-rounded btn-soft-primary btn-sm" ID="bswp" OnClick="bswp_Click">
                                                    <i class="fa fas fa-book-reader"></i> SWP/WI Assembly
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server" CssClass="btn btn-rounded btn-soft-primary btn-sm" ID="bprint" OnClick="bprint_Click">
                                                    <i class="fa fas fa-print"></i> Print PDF
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server" CssClass="btn btn-rounded btn-soft-primary btn-sm" ID="bBack" OnClick="bBack_Click">
                                                    <i class="fa fa-backspace"></i> Back
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server" CssClass="btn btn-rounded btn-soft-danger btn-sm">
                                                    <i class="fa fas fa-trash"></i> Delete Template
                                                </asp:LinkButton>
                                            </div>
                                            <div class="d-flex flex-wrap gap-2 fw-bold">
                                                <u>Section Progress</u>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6 mb-3">
                                                    <div class="mt-3">
                                                        <p class="text-muted font-size-13 mb-1" runat="server" id="lSectionProg">Section Progress (50%)</p>
                                                        <div class="progress animated-progess custom-progress">
                                                            <div runat="server" id="pSectionProg" class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 mb-3">
                                                    <div class="mt-3">
                                                        <p class="text-muted font-size-13 mb-1" runat="server" id="lSectionLH">Leading Hand Approval Progress (50%)</p>
                                                        <div class="progress animated-progess custom-progress">
                                                            <div runat="server" id="pSectionLH" class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                    
                                            <div class="d-flex flex-wrap gap-2 mb-2 fw-bold">
                                                <u>Assembly Section</u>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList runat="server" ID="ddsection" CssClass="form-control form-control-sm" OnSelectedIndexChanged="ddsection_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                            <hr />
                                            <div class="d-flex flex-wrap gap-2 justify-content-md-center mb-3">
                                                <h5 class="text-muted" runat="server" id="lsection">Section Name</h5>
                                            </div>
                                            <img runat="server" id="imgGp" src="../../../../assets/images/NoPicture.png" class="mb-3 img-fluid"
                                                style="display: block; margin-left:auto; margin-right:auto; Position:Static; height:70%"/>

                                            <div class="table-responsive">
                                                <asp:Repeater runat="server" ID="rpt_mea2" OnItemDataBound="rpt_mea2_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <table class="table table-hover mb-0 align-middle table-bordered">
                                                            <thead class="bg-warning fw-bold">
                                                                <tr>
                                                                    <th style="width:3%">No</th>
                                                                    <th style="width:40%">Activity</th>
                                                                    <th>Technical Spesification</th>
                                                                    <th>Actual Measurement</th>
                                                                    <th>Mech</th>
                                                                    <th>LH</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr runat="server" id="tRow">
                                                            <td style="width:3%">
                                                                <span class="form-label" runat="server" id="pSeq"></span>
                                                            </td>
                                                            <td style="width:40%">
                                                                <div class="flex-shrink-0 me-3">
                                                                    <div class="avatar-sm">
                                                                        <div class="avatar-title rounded-circle font-size-12" runat="server" id="cirB">
                                                                            <i class="fas fa-user" runat="server" id="iconB"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <asp:Image runat="server" id="imgdet" src='<%# Eval("PicturePath").ToString() %>' class="img-fluid" /> <br />
                                                                <span class="form-label" runat="server" id="pActivity"></span>
                                                            </td>
                                                            <td class="text-center">                                                              
                                                                <span class="form-label text-center" id="pMeasureType" runat="server"></span>
                                                                <asp:LinkButton runat="server" ID="bchange" CssClass="btn btn-sm" OnClick="bchange_Click" CommandArgument='<%# Eval("IDAssemblyInput") & "," & Eval("UnitType") %>'>
                                                                    <i class="fa fa-sync text-muted"></i>
                                                                </asp:LinkButton>
                                                                <hr />
                                                                <span class="form-label" runat="server" id="pFullSpec"></span>
                                                            </td>
                                                            <td>
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tVal" Visible="false" OnTextChanged="tVal_TextChanged" 
                                                                        IDAssembly='<%# Eval("IDAssemblyInput") %>' ValType='<%# Eval("ValType") %>' AutoPostBack="true"></asp:TextBox>
                                                                    <span class="input-group-text" id="sUnit" runat="server" Visible="false">-</span>
                                                                    <asp:LinkButton runat="server" ID="bOK2" CssClass="btn btn-soft-primary" Visible="false" CommandArgument='<%# Eval("IDAssemblyInput") %>' OnClick="bOK2_Click">OK</asp:LinkButton>
                                                                    <asp:LinkButton runat="server" ID="bNA" CssClass="btn btn-soft-secondary" Visible="false" CommandArgument='<%# Eval("IDAssemblyInput") %>' OnClick="bNA_Click">NA</asp:LinkButton>
                                                                </div>
                                                                <small runat="server" class="form-label text-danger fw-bold" id="lCheckSpec">Out of spec</small>
                                                                <hr />
                                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-secondary btn-sm" OnClick="breset_Click" CommandArgument='<%# Eval("IDAssemblyInput") %>' ID="breset" 
                                                                    OnClientClick="return confirm('Are you sure you want to reset the value?')">Reset Value</asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <label class="form-label" runat="server" id="pAsmBy"></label><br />
                                                                <label class="form-label" runat="server" id="pAsmDate"></label>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bLHApv" OnClick="bLHApv_Click" CommandArgument='<%# Eval("IDAssemblyInput") %>'>Approve</asp:LinkButton>
                                                                <label class="form-label" runat="server" id="pLH"></label>
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
        </div> 
    </div>
</asp:Content>