<%@ Page Title="Assembly Liner Bore" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyLinerBore.aspx.vb" Inherits="TCRCWebV2.AssemblyLinerBore" %>
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
                    <div class="row no-gutter">
                        <uc1:AssemblyMenu runat="server" ID="AssemblyMenu" />
                        <div class="col-md-12">
                            <div class="d-flex flex-wrap gap-2 mb-2 fw-bold">
                                <u>Upper Liner Bore</u>
                            </div>
                            <div class="mt-3 mb-3">
                                <p class="text-muted font-size-13 mb-1" runat="server" id="lSectionProg">Overall Progress (50%)</p>
                                <div class="progress animated-progess custom-progress">
                                    <div runat="server" id="pSectionProg" class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="text-md-start mt-4 mt-md-0">

                                    <asp:Repeater runat="server" ID="rpt_linerBore" OnItemDataBound="rpt_linerBore_ItemDataBound" OnItemCommand="rpt_linerBore_ItemCommand">
                                        <ItemTemplate>
                                            <ul class="list-inline main-chart mb-0">
                                                <li class="list-inline-item chart-border-left me-0 border-0">
                                                    <h4 class="text-primary my-1" runat="server" id="pNo">Piston No.<span class="text-muted fw-normal font-size-22 ms-2">#1</span></h4>
                                                </li>
                                                <li class="list-inline-item chart-border-left me-0">
                                                    <div class="mb-1">
                                                        <label class="form-label font-size-13" for="formrow-firstname-input">Recommendation</label>
                                                        <asp:DropDownList runat="server" ID="ddRec" CssClass="form-control form-control-sm">
                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                            <asp:ListItem Value="Insert" Text="Insert"></asp:ListItem>
                                                            <asp:ListItem Value="Original" Text="Original"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </li>
                                                <li class="list-inline-item chart-border-left me-0">
                                                    <div class="mb-1">
                                                        <label class="form-label font-size-13" for="formrow-firstname-input">Recommendation By</label><br />
                                                        <asp:Label runat="server" CssClass="form-label" Text="Indra" ID="lRecBy"></asp:Label>
                                                    </div>
                                                </li>
                                                <li class="list-inline-item chart-border-left me-0">
                                                    <div class="mb-1">
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
    </div>
</asp:Content>