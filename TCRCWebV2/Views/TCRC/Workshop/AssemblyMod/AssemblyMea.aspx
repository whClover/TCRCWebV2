<%@ Page Title="Assembly List" MasterPageFile="~/Site.Master" MaintainScrollPositionOnPostback="true" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyMea.aspx.vb" Inherits="TCRCWebV2.AssemblyMea" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyMea.ascx" TagPrefix="uc1" TagName="AssemblyMea" %>

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
                <div class="card-header">
                    <h5 class="card-title">WO.</h5>
                    <small class="card-title-desc">WO Desc.</small>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                                <asp:LinkButton runat="server" CssClass="nav-link active" ID="n1">Measurement</asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="nav-link" ID="n2">Checksheet</asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="nav-link" ID="n3">Liner Projection</asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="nav-link" ID="n4">Upper Liner Bore</asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="nav-link" ID="n5">Pin Pistion Clearance</asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="nav-link" ID="n6">Valve Lash Adjustment</asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="nav-link" ID="n7">Fuel Inj. Trim Code</asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="nav-link" ID="n8">Piston Recommendation</asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="nav-link" ID="n9">Cylinder Head</asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="tab-content text-muted mt-4 mt-md-0" id="v-pills-tabContent">
                                <div class="tab-pane fade show active">
                                    <div class="d-flex flex-wrap gap-2 justify-content-md-center mb-2 fw-bold">
                                        <u>Tools</u>
                                    </div>
                                    <div class="d-flex flex-wrap gap-2 justify-content-md-center">
                                        <asp:LinkButton runat="server" CssClass="btn btn-rounded btn-soft-primary btn-sm">
                                            <i class="fa fas fa-photo-video"></i> Assembly Gallery
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-rounded btn-soft-primary btn-sm">
                                            <i class="fa fas fa-book-reader"></i> SWP/WI Assembly
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-rounded btn-soft-primary btn-sm">
                                            <i class="fa fas fa-trash"></i> Delete Template
                                        </asp:LinkButton>
                                    </div>
                                    <hr />
                                    <div class="d-flex flex-wrap gap-2 justify-content-md-center mb-3">
                                        <h5 class="text-muted">Section Name</h5>
                                    </div>
                                    <img runat="server" id="imgGp" src="../../../../assets/images/NoPicture.png" class="mb-3"
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
                                                            <asp:Button runat="server" ID="bLH" CssClass="btn btn-secondary mb-3 btn-sm" Text="LH Approve" />
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
                                                                        <h5 class="my-1 text-primary">
                                                                            Completed By 
                                                                            <span runat="server" id="pModBy" class="text-muted d-inline-block fw-normal font-size-13 ms-2">Indra</span>
                                                                        </h5>
                                                                    </li>
                                                                    <li class="list-inline-item chart-border-left me-0">
                                                                        <h5 class="my-1 text-primary">
                                                                            Completed Date 
                                                                            <span runat="server" id="pModDate" class="text-muted d-inline-block fw-normal font-size-13 ms-2">28/05/2023</span>
                                                                        </h5>
                                                                    </li>
                                                                    <li class="list-inline-item chart-border-left me-0">
                                                                        <h5 class="my-1 text-primary">
                                                                            LH Approved By
                                                                            <span runat="server" id="pApvBy" class="text-muted d-inline-block fw-normal font-size-13 ms-2">Tri Rahayu</span>
                                                                        </h5>
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div> 
    </div>
</asp:Content>