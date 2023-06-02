<%@ Page Title="Assembly Cylinder Head" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyCylHead.aspx.vb" Inherits="TCRCWebV2.AssemblyCylHead" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyMenu.ascx" TagPrefix="uc1" TagName="AssemblyMenu" %>


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
                                <u>Cylinder Head</u>
                            </div>
                            <div class="mt-3 mb-3">
                                <p class="text-muted font-size-13 mb-1" runat="server" id="lSectionProg">Overall Progress (50%)</p>
                                <div class="progress animated-progess custom-progress">
                                    <div runat="server" id="pSectionProg" class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                            <hr />

                            <asp:Repeater runat="server" ID="rpt_cylhead" OnItemDataBound="rpt_cylhead_ItemDataBound" OnItemCommand="rpt_cylhead_ItemCommand">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-md-6 d-flex">
                                            <h4 class="text-primary my-1" runat="server" id="H2">Cylinder No.<span class="text-muted fw-normal font-size-22 ms-2">#1</span></h4>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="card">
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="mb-1">
                                                                <label class="form-label font-size-13" for="formrow-firstname-input">Recommendation</label><br />
                                                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddCylRec">
                                                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                                                    <asp:ListItem Text="Rebuild" Value="Rebuild"></asp:ListItem>
                                                                    <asp:ListItem Text="Reman" Value="Reman"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="mb-1">
                                                                <label class="form-label font-size-13" for="formrow-firstname-input">Ex. Work Order</label><br />
                                                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tExWO"></asp:TextBox>
                                                            </div>
                                                        </div>                                                
                                                    </div>
                                                    <hr />
                                                    <div class="row col-md-12 mb-3">
                                                        <div class="col-md-6">
                                                            <h6 class="text-muted my-1" runat="server" id="pNo">Valve Recession Mesurement</h6>
                                                            <ul class="list-inline main-chart mb-0 d-flex">
                                                                <li class="chart-border-left me-0 border-0 align-self-center">
                                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Intake A</label><br />
                                                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tIntakeA"></asp:TextBox>
                                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Intake B</label><br />
                                                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tIntakeB"></asp:TextBox>
                                                                </li>
                                                                <li class="list-inline-item chart-border-left me-0">
                                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Exhaust A</label><br />
                                                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tExhaustA"></asp:TextBox>
                                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Exhaust B</label><br />
                                                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tExhaustB"></asp:TextBox>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <h6 class="text-muted my-1" runat="server" id="H1">Insert Bore Valve Diameter</h6>
                                                            <ul class="list-inline main-chart mb-0 d-flex">
                                                                <li class="chart-border-left me-0 border-0 align-self-center">
                                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Intake A</label><br />
                                                                    <asp:dropdownlist runat="server" CssClass="form-control form-control-sm" ID="ddIntakeA">
                                                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="OK" Value="OK"></asp:ListItem>
                                                                        <asp:ListItem Text="NOT OK" Value="NOT OK"></asp:ListItem>
                                                                    </asp:dropdownlist>
                                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Intake B</label><br />
                                                                    <asp:dropdownlist runat="server" CssClass="form-control form-control-sm" ID="ddIntakeB">
                                                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="OK" Value="OK"></asp:ListItem>
                                                                        <asp:ListItem Text="NOT OK" Value="NOT OK"></asp:ListItem>
                                                                    </asp:dropdownlist>
                                                                </li>
                                                                <li class="list-inline-item chart-border-left me-0">
                                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Exhaust A</label><br />
                                                                    <asp:dropdownlist runat="server" CssClass="form-control form-control-sm" ID="ddExhaustA">
                                                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="OK" Value="OK"></asp:ListItem>
                                                                        <asp:ListItem Text="NOT OK" Value="NOT OK"></asp:ListItem>
                                                                    </asp:dropdownlist>
                                                                    <label class="form-label font-size-13" for="formrow-firstname-input">Exhaust B</label><br />
                                                                    <asp:dropdownlist runat="server" CssClass="form-control form-control-sm" ID="ddExhaustB">
                                                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="OK" Value="OK"></asp:ListItem>
                                                                        <asp:ListItem Text="NOT OK" Value="NOT OK"></asp:ListItem>
                                                                    </asp:dropdownlist>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm btn-block">
                                                            <i class="fa fa-save"></i> Save
                                                        </asp:LinkButton>
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
</asp:Content>