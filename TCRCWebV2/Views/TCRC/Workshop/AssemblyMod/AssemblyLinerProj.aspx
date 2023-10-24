<%@ Page Title="Assembly Liner Projection" MasterPageFile="~/Site.Master" Language="vb" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeBehind="AssemblyLinerProj.aspx.vb" Inherits="TCRCWebV2.AssemblyLinerProj" %>
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
    <uc1:AssemblyAssignEngine runat="server" id="AssemblyAssignEngine" />
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
                                <u>Tools</u>
                            </div>
                            <div class="mt-3 mb-3">
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bna" OnClick="bna_Click" OnClientClick="return confirm('Are you sure?')">All n/a</asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bprint" OnClick="bprint_Click">
                                    <i class="fa fa-download"></i> Print
                                </asp:LinkButton>
                            </div>
                            <div class="d-flex flex-wrap gap-2 mb-2 fw-bold">
                                <u>Liner Projection</u>
                            </div>
                            <div class="mt-3 mb-3">
                                <p class="text-muted font-size-13 mb-1" runat="server" id="lSectionProg">Overall Progress (50%)</p>
                                <div class="progress animated-progess custom-progress">
                                    <div runat="server" id="pSectionProg" class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-md-8">
                                    <asp:Repeater runat="server" ID="rpt_liner" OnItemDataBound="rpt_liner_ItemDataBound" OnItemCommand="rpt_liner_ItemCommand">
                                        <ItemTemplate>
                                            <div class="card">
                                                <div class="card-header bg-soft-primary">
                                                    <h5 class="card-title" runat="server" id="lCylNo">Cylinder No.</h5>
                                                    <small class="card-title-desc" runat="server" id="lSpec">
                                                        Spesifications: 0.001inch - 0.006inch | 0.025mm - 0.152mm
                                                    </small>
                                                </div>
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="mb-1">
                                                                <label class="form-label" for="formrow-firstname-input">A</label>
                                                                <asp:TextBox name="txtValues" runat="server" CssClass="form-control form-control-sm" TextMode="Number" ID="tA"></asp:TextBox>
                                                                <%--<input class="form-control form-control-sm" id="tA" type="number" />--%>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="mb-1">
                                                                <label class="form-label" for="formrow-firstname-input">B</label>
                                                                <asp:TextBox name="txtValues" runat="server" CssClass="form-control form-control-sm" TextMode="Number" ID="tB"></asp:TextBox>
                                                                <%--<input class="form-control form-control-sm" id="tB" type="number" />--%>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="mb-1">
                                                                <label class="form-label" for="formrow-firstname-input" >Sum A-D:</label>
                                                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" TextMode="Number" Enabled="false" ID="tSum"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="mb-1">
                                                                <label class="form-label" for="formrow-firstname-input" >Avg A-D:</label>
                                                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" TextMode="Number" Enabled="false" ID="tAvg"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="mb-1">
                                                                <label class="form-label" for="formrow-firstname-input">C</label>
                                                                <asp:TextBox name="txtValues" runat="server" CssClass="form-control form-control-sm" TextMode="Number" ID="tC"></asp:TextBox>
                                                                <%--<input class="form-control form-control-sm" id="tC" type="number" />--%>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="mb-1">
                                                                <label class="form-label" for="formrow-firstname-input">D</label>
                                                                <asp:TextBox name="txtValues" runat="server" CssClass="form-control form-control-sm" TextMode="Number" ID="tD"></asp:TextBox>
                                                                <%--<input class="form-control form-control-sm" id="tD" type="number" />--%>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="mb-1">
                                                                <label class="form-label" for="formrow-firstname-input">Max A-D:</label>
                                                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" TextMode="Number" Enabled="false" ID="tMax"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="mb-1">
                                                                <label class="form-label" for="formrow-firstname-input">Min A-D:</label>
                                                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" TextMode="Number" Enabled="false" ID="tMin"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="d-grid gap-2 mt-3">
                                                                <asp:LinkButton CommandArgument='<%# Eval("CylinderNo") %>' CssClass="btn btn-soft-primary btn-sm btn-block mb-1" runat="server" ID="bSave" CommandName="Update">
                                                                    <i class="fa fa-save"></i> Save
                                                                </asp:LinkButton>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="mb-1">
                                                                <label class="form-label" for="formrow-firstname-input">Variation:</label>
                                                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" TextMode="Number" Enabled="false" ID="tVar"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>   
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="col-md-4">
                                    <div class="card">
                                        <div class="card-header bg-soft-warning">
                                            <h5 class="card-title">Max Variation of Avg Between Adjecent Liners</h5>
                                            <small class="card-title-desc">
                                                Spesifications:
                                            </small>
                                        </div>
                                        <div class="card-body">
                                            <asp:PlaceHolder runat="server" ID="ph1"></asp:PlaceHolder>                                                                    
                                        </div>
                                    </div>
                                    <div class="card">
                                        <div class="card-header bg-soft-warning">
                                            <h5 class="card-title">Max Variation Each Cylinder</h5>
                                            <small class="card-title-desc">
                                                Spesifications:
                                            </small>
                                        </div>
                                        <div class="card-body">
                                            <asp:PlaceHolder runat="server" ID="ph"></asp:PlaceHolder>                                                                    
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