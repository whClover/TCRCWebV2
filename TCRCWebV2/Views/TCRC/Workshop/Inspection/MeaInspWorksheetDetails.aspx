<%@ Page Title="Measure Inspection Worksheet" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="MeaInspWorksheetDetails.aspx.vb" Inherits="TCRCWebV2.MeaInspWorksheetDetails" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <!-- start page title -->
    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-flex align-items-center justify-content-between">
                <h4 class="mb-0">Measurement Inspection Worksheet</h4>

                <div class="page-title-right">
                    <ol class="breadcrumb m-0">
                        <li class="breadcrumb-item"><a href="javascript: void(0);">Workshop Page</a></li>
                        <li class="breadcrumb-item">Measurement Inspection Worksheet</li>
                        <li class="breadcrumb-item active" runat="server" id="lwo">WO.</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <!-- end page title -->

    <div class="row">
        <div class="col-lg-5">
            <div class="card card-h-100">
                <div class="card-header border-bottom-0">
                    <div class="d-flex align-items-start">
                        <div class="flex-grow-1">
                            <h5 class="card-title" runat="server" id="lhWO">WO.</h5>
                            <small runat="server" id="lWODesc">tes</small>
                        </div>
                    </div>
                </div>
                <div class="pb-4">
                    <div data-simplebar="init" style="max-height: 195px;"><div class="simplebar-wrapper" style="margin: 0px;"><div class="simplebar-height-auto-observer-wrapper"><div class="simplebar-height-auto-observer"></div></div><div class="simplebar-mask"><div class="simplebar-offset" style="right: -17px; bottom: 0px;"><div class="simplebar-content-wrapper" style="height: auto; overflow: hidden scroll;"><div class="simplebar-content" style="padding: 0px;">
                        <asp:Repeater runat="server" ID="rptProgress">
                            <HeaderTemplate>
                                <ul class="list-unstyled unstyled mb-0">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li class="px-4 py-3 pt-0">
                                    <div class="d-flex align-items-center">
                                        <div class="flex-shrink-0 me-3">
                                            <asp:LinkButton CssClass="btn btn-soft-purple" runat="server" ID="bShow" OnClick="bShow_Click" CommandArgument='<%# Eval("SectionName") %>'>
                                                <i class="fas fa-eye"></i>
                                            </asp:LinkButton>
                                        </div>
                                        <div class="flex-grow-1">
                                            <p class="text-muted mb-2"><%# Eval("SectionName") %> <span class="float-end fw-medium"><%# Eval("Progress") %> %</span></p>
                                            <div class="progress animated-progess custom-progress">
                                                <div class="progress-bar" role="progressbar" style='<%# "width:" & Eval("Progress") %>%' aria-valuenow='<%# Eval("Progress") %>' aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div></div></div></div><div class="simplebar-placeholder" style="width: auto; height: 290px;"></div></div><div class="simplebar-track simplebar-horizontal" style="visibility: hidden;"><div class="simplebar-scrollbar" style="transform: translate3d(0px, 0px, 0px); display: none;"></div></div><div class="simplebar-track simplebar-vertical" style="visibility: visible;"><div class="simplebar-scrollbar" style="height: 131px; transform: translate3d(0px, 0px, 0px); display: block;"></div></div></div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="d-flex flex-wrap gap-2 mb-3">
                <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="bMeaPrint" OnClick="bMeaPrint_Click">Print Worksheet</asp:LinkButton>
                <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="bBack" OnClick="bBack_Click">Back</asp:LinkButton>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="mb-3 card">
                <div class="card-header">
                    <asp:Label runat="server" ID="lTitle" CssClass="card-title"></asp:Label>
                </div>
                <div class="card-body">
                    <asp:Image runat="server" ID="img" style="display: block; margin-left:auto; margin-right:auto; Position:Static;" />
                    <div class="divider"></div>
                    <asp:PlaceHolder runat="server" id="ph_detail"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <div class="card-title">Section Remark</div>
                </div>
                <div class="card-body">
                    <asp:TextBox runat="server" ID="tRemark" CssClass="form-control form-control-sm mb-2" Height="100"></asp:TextBox>
                    <div class="text-center">
                        <%--<asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bSaveRemark" OnClick="bSaveRemark_Click">Save Remark</asp:LinkButton>--%>
                        <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="rmksave" OnClick="rmksave_Click">Save Remark</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function checkedJS(id) {
            $.ajax({
                type: "POST",
                url: "MeaInspWorksheetDetails.aspx/UpdateCheck",
                data: "{'IDInsp':'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: "false",
                success: function (response) {
                    location.reload();
                },
                error: function (request, status, error) {
                    alert(request.responseText);
                }
            });
        };

        function fillJS(id, objID) {
            var isinya = document.getElementById(objID).value;
            $.ajax({
                type: "POST",
                url: "MeaInspWorksheetDetails.aspx/fillJS",
                data: "{'IDInsp':'" + id + "','value':'" + isinya + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: "false",
                success: function (response) {
                    location.reload();

                },
                error: function (request, status, error) {
                    alert(request.responseText);
                }
            });
        };
    </script>

    

    <%--<asp:PlaceHolder runat="server" ID="phW"></asp:PlaceHolder>--%>
</asp:Content>