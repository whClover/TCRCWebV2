<%@ Page Title="Assembly Check" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyChk.aspx.vb" Inherits="TCRCWebV2.AssemblyChk" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyMenu.ascx" TagPrefix="uc1" TagName="AssemblyMenu" %>

<asp:Content ContentPlaceHolderID="MenuContent" runat="server">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
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
                            <div class="mt-3 mb-3">
                                <p class="text-muted font-size-13 mb-1" runat="server" id="lSectionProg">Overall Progress (50%)</p>
                                <div class="progress animated-progess custom-progress">
                                    <div runat="server" id="pSectionProg" class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                            <div class="d-flex flex-wrap gap-2 mb-2 fw-bold">
                                <u>Assembly Section</u>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddsection" CssClass="form-control form-control-sm" AutoPostBack="true" OnSelectedIndexChanged="ddsection_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <hr />
                            <div class="d-flex flex-wrap gap-2 justify-content-md-center mb-3">
                                <h5 class="text-muted" runat="server" id="lsection">Section Name</h5>
                            </div>
                            <img src="../../../../images/NoPicture.png" class="img-fluid mb-3" 
                                style="display: block; margin-left:auto; margin-right:auto; Position:Static;" id="imgGp" runat="server"/>
                            <div class="mb-3 text-center">
                                <asp:LinkButton runat="server" CssClass="btn btn-rounded btn-soft-primary" ID="bchk" OnClick="bchk_Click">
                                    <i class="fa fa-check-circle"></i> Check
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="btn btn-rounded btn-soft-primary" ID="bna" OnClick="bna_Click">
                                    <i class="far fa-eye-slash"></i> N/A
                                </asp:LinkButton>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="gv_chk" runat="server" CssClass="table table-hover table-nowrap mb-0 align-middle table-check" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="CheckBoxHeader" runat="server" onclick="CheckAll(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="ID" Visible="false" DataField="IDInsDetail" />
                                        <asp:BoundField HeaderText="PN" DataField="PartNumber" />
                                        <asp:BoundField HeaderText="Pic No" DataField="NoPict" />
                                        <asp:BoundField HeaderText="Part Desc" DataField="PartDesc" />
                                        <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                        <asp:BoundField HeaderText="Recommendation" DataField="Recommendation" />
                                        <asp:BoundField HeaderText="Remark" DataField="PartRemark" />
                                        <asp:BoundField HeaderText="AssemblyBy" DataField="AssemblyBy" />
                                        <asp:BoundField HeaderText="AssemblyDate" DataField="AssemblyDate" />
                                    </Columns>
                                </asp:GridView>
                                <script type="text/javascript">
                                    function CheckAll(cb) {
                                        var grid = document.getElementById("<%= gv_chk.ClientID %>");
                                        var checkboxes = grid.getElementsByTagName("input");
                                        for (var i = 0; i < checkboxes.length; i++) {
                                            if (checkboxes[i].type === "checkbox" && checkboxes[i].id !== cb.id) {
                                                checkboxes[i].checked = cb.checked;
                                            }
                                        }
                                    }
                                </script>
                            </div>
                        </div>
                        <div class="col-md-12">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>