﻿<%@ Page Title="Assembly List" MasterPageFile="~/Site.Master" MaintainScrollPositionOnPostback="true" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyMea.aspx.vb" Inherits="TCRCWebV2.AssemblyMea" %>
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
                        <div class="col-md-9">
                            <div class="tab-content text-muted mt-4 mt-md-0" id="v-pills-tabContent">
                                <div class="tab-pane fade show active">
                                    
                                    <ul class="nav nav-tabs nav-tabs-custom mb-3" role="tablist">
                                        <li class="nav-item" role="presentation">
                                            <a class="nav-link active" data-bs-toggle="tab" href="#mealist" role="tab" aria-selected="false" tabindex="-1">
                                                <span class="d-block d-sm-none"><i class="far fa-user"></i></span>
                                                <span class="d-none d-sm-block">Measurement List</span> 
                                            </a>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <a class="nav-link" data-bs-toggle="tab" href="#supvapv" role="tab" aria-selected="false" tabindex="-1">
                                                <span class="d-block d-sm-none"><i class="far fa-envelope"></i></span>
                                                <span class="d-none d-sm-block">Supervisor Approval</span>   
                                            </a>
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

                                            <asp:Repeater runat="server" ID="rpt_mea" OnItemDataBound="rpt_mea_ItemDataBound">
                                                <ItemTemplate>
                                                    <div runat="server" id="pBorder" class="card border border-primary">
                                                        <div class="card-body">
                                                            <div class="d-flex align-items-start">
                                                                <div class="flex-grow-1">
                                                                    <div runat="server" id="pSeq" class="badge badge-soft-primary mb-3">Sequence: a</div>
                                                                </div>
    
                                                                <div class="flex-shrink-0">
                                                                    <asp:Button CommandArgument='<%# Eval("IDAssemblyInput") %>' runat="server" OnClientClick="return confirm('Are you sure ?');"
                                                                        ID="bLH" CssClass="btn btn-secondary mb-3 btn-sm" Text="LH Approve" OnClick="bLH_Click" />
                                                                </div> 
                                                            </div>
                                                            <div class="d-flex">
                                                                <div class="flex-shrink-0 me-3">
                                                                    <div class="avatar-sm mb-2">
                                                                        <div class="avatar-title bg-light text-primary rounded-circle">
                                                                            <i class="fa fa-info"></i>
                                                                        </div>
                                                                    </div>
                                                                    <span runat="server" id="pStatus" class="badge rounded-pill bg-warning just">NC</span>
                                                                </div>
                                                                <div class="flex-grow-1 overflow-hidden">
                                                                    <p class="text-muted mb-1" runat="server" id="pDesc">-</p>
                                                                    <div class="row mb-2">                                                              
                                                                        <div class="col-md-4">
                                                                            <p class="text-muted mb-1 fw-bold">Measurement Type: </p>
                                                                            <label runat="server" id="pMeaType" class="form-label text-muted"></label>
                                                                            <asp:LinkButton CommandArgument='<%# Eval("IDAssemblyInput") & "," & Eval("UnitType") %>' runat="server" ID="bChangeSpec" CssClass="btn btn-soft-light btn-sm" OnClick="bChangeSpec_Click">
                                                                                <i class="fa fa-recycle"></i>
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <p class="text-muted mb-1 fw-bold">Spesifications: </p>
                                                                            <p runat="server" id="pSpec">-</p>
                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <p class="text-muted mb-1 fw-bold">Values: </p>
                                                                            <label runat="server" id="pVal" class="form-label"></label>
                                                                            <asp:LinkButton CommandArgument='<%# Eval("IDAssemblyInput") %>' runat="server" ID="bedit" OnClick="bedit_Click" CssClass="btn btn-soft-light btn-sm">
                                                                                <i class="fa fa-edit"></i>
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>                                                           
                                                                    <div runat="server" id="pComp" class="text-md-end mt-4 mt-md-0">
                                                                        <hr />
                                                                        <ul class="list-inline main-chart mb-0">
                                                                            <li class="list-inline-item chart-border-left me-0 border-0">
                                                                                <h6 class="my-1 text-primary">
                                                                                    Completed By 
                                                                                    <span runat="server" id="pModBy" class="text-muted d-inline-block fw-normal font-size-13 ms-2">Indra</span>
                                                                                </h6>
                                                                            </li>
                                                                            <li class="list-inline-item chart-border-left me-0">
                                                                                <h6 class="my-1 text-primary">
                                                                                    Completed Date 
                                                                                    <span runat="server" id="pModDate" class="text-muted d-inline-block fw-normal font-size-13 ms-2">28/05/2023</span>
                                                                                </h6>
                                                                            </li>
                                                                            <li class="list-inline-item chart-border-left me-0">
                                                                                <h6 class="my-1 text-primary">
                                                                                    LH Approved By
                                                                                    <span runat="server" id="pApvBy" class="text-muted d-inline-block fw-normal font-size-13 ms-2">Tri Rahayu</span>
                                                                                </h6>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <div class="tab-pane" id="supvapv" role="tabpanel">
                                            <asp:GridView runat="server" CssClass="table table-bordered table-striped" ID="gv_supv" AutoGenerateColumns="false" OnRowDataBound="gv_supv_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField HeaderText="AssemblySection" DataField="AssemblySection" />
                                                    <asp:BoundField HeaderText="Measure %" DataField="Perc" />
                                                    <asp:BoundField HeaderText="LH Approval %" DataField="PercApproval" />
                                                    <asp:TemplateField HeaderText="Assigned To">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddSupv" 
                                                                OnSelectedIndexChanged="ddSupv_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Supv Approved By">
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" ID="bApv" OnClick="bApv_Click">Approve</asp:LinkButton>
                                                            <asp:Label runat="server" CssClass="form-label" ID="lApv"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
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