<%@  Page Title="Assembly Pin Piston" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyPinPiston.aspx.vb" Inherits="TCRCWebV2.AssemblyPinPiston" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyMenu.ascx" TagPrefix="uc1" TagName="AssemblyMenu" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyAssignEngine.ascx" TagPrefix="uc1" TagName="AssemblyAssignEngine" %>


<asp:Content ContentPlaceHolderID="MenuContent" runat="server">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        window.addEventListener("scroll", function () {
            var scrollPosition = window.pageYOffset;
            document.getElementById('<%=ScrollPosition.ClientID %>').value = scrollPosition;
        });
    </script>
    <asp:HiddenField runat="server" ID="ScrollPosition" />
    <uc1:AssemblyAssignEngine runat="server" ID="AssemblyAssignEngine" />
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title" runat="server" id="lwono">WO.</h5>
                    <small class="card-title-desc" runat="server" id="lwodesc">WO Desc.</small>
                </div>
                <div class="card-body">
                    <div class="row">
                        <uc1:AssemblyMenu runat="server" ID="AssemblyMenu" />
                        <div class="col-md-12">
                            <div class="d-flex flex-wrap gap-2 mb-2 fw-bold">
                                <u>Pin Piston Clearance</u>
                            </div>
                            <div class="mt-3 mb-3">
                                <p class="text-muted font-size-13 mb-1" runat="server" id="lSectionProg">Overall Progress (50%)</p>
                                <div class="progress animated-progess custom-progress">
                                    <div runat="server" id="pSectionProg" class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                            <hr />
                            <div class="table-responsive">
                                <asp:Repeater runat="server" ID="rpt_Pin" OnItemDataBound="rpt_Pin_ItemDataBound" OnItemCommand="rpt_Pin_ItemCommand">
                                    <ItemTemplate>
                                        <ul class="list-inline main-chart mb-0 d-flex">
                                            <li class="list-inline-item chart-border-left me-0 border-0 align-self-center">
                                                <h4 class="text-primary my-1" runat="server" id="pNo">#1</h4>
                                            </li>
                                            <li class="list-inline-item chart-border-left me-0">
                                                <div class="mb-1">
                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Conrod Pin Bearing Diamatere(A)</label>
                                                    <asp:TextBox TextMode="Number" runat="server" CssClass="form-control form-control-sm" ID="tBearingDiA"></asp:TextBox>
                                                </div>
                                                <div class="mb-1">
                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Piston Pin Diametere(B)</label>
                                                    <asp:TextBox TextMode="Number" runat="server" CssClass="form-control form-control-sm" ID="tPinDiA"></asp:TextBox>
                                                </div>
                                                <div class="mb-1">
                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Joint Clearance (A - B)</label>
                                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" Enabled="false" ID="tJoint"></asp:TextBox>
                                                </div>
                                            </li>
                                            <li class="list-inline-item chart-border-left me-0">
                                                <div class="mb-1">
                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Surface Finish of Bore for Piston Pin Bearing</label>
                                                    <asp:TextBox TextMode="Number" runat="server" CssClass="form-control form-control-sm" ID="tBoresurface"></asp:TextBox>
                                                </div>
                                                <div class="mb-1">
                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Test Retention</label>
                                                    <asp:TextBox TextMode="Number" runat="server" CssClass="form-control form-control-sm" ID="tTestRetention"></asp:TextBox>
                                                </div>
                                            </li>
                                            <li class="list-inline-item chart-border-left me-0">
                                                <div class="mb-1">
                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Bend</label>
                                                    <asp:TextBox TextMode="Number" runat="server" CssClass="form-control form-control-sm" ID="tConrodBend"></asp:TextBox>
                                                </div>
                                                <div class="mb-1">
                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Twist</label>
                                                    <asp:TextBox TextMode="Number" runat="server" CssClass="form-control form-control-sm" ID="tConrodTwist"></asp:TextBox>
                                                </div>
                                            </li>
                                            <li class="list-inline-item chart-border-left me-0 d-flex">
                                                <div class="mb-1 align-self-center">
                                                    <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" CommandName="Update" CommandArgument='<%# Eval("CylinderNo") %>'>
                                                        <i class="fa fa-save"></i> Save
                                                    </asp:LinkButton>
                                                </div>
                                            </li>
                                        </ul>
                                        <hr />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>