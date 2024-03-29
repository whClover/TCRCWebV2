﻿<%@ Page Title="Measure Inspection Worksheet" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="MeaInspWorksheetRev.aspx.vb" Inherits="TCRCWebV2.MeaInspWorksheetRev" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/Inspection/MeaInspRemark.ascx" TagPrefix="uc1" TagName="MeaInspRemark" %>

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
        <div class="col-md-3">
            <div class="card card-h-100">
                <div class="card-header border-bottom-0">
                    <div class="justify-content-between d-flex align-items-center">
                        <div class="flex-grow-1">
                            <h5 class="card-title" runat="server" id="lhWO">WO.</h5>
                            <small runat="server" id="lWODesc">tes</small>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="d-grid gap-2">
                    <asp:Button runat="server" CssClass="btn btn-info btn-sm" Text="Send To Job Package" Enabled="false" ID="btnJP" OnClick="btnJP_Click" />
                </div>
                <div id="sidebar-menu">                    
                    <ul class="metismenu list-unstyled" id="side-menu">
                        <li class="menu-title" data-key="t-dashboards">
                            <small class="text-muted" runat="server" id="lOPb">Overall Progress : 100%</small>
                            <div class="progress progress-xl animated-progess mb-1 custom-progress">
                                <div runat="server" id="pBar" class="progress-bar bg-info" role="progressbar" style="width: 50%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                            </div>
                        </li>
                        <li class="menu-title" data-key="t-dashboards">
                            <small class="text-muted" runat="server" id="lOPLH">Leading Hand Approval : 100%</small>
                            <div class="progress progress-xl animated-progess mb-1 custom-progress">
                                <div runat="server" id="pBar2" class="progress-bar bg-warning" role="progressbar" style="width: 50%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                            </div>
                        </li>
                        <li class="menu-title" data-key="t-dashboards">Inspection Section :</li>
                        <asp:Repeater runat="server" ID="rpt_section" OnItemDataBound="rpt_section_ItemDataBound">
                            <ItemTemplate>
                                <li>
                                    <a href="javascript: void(0);" class="has-arrow">
                                        <i class="fa fa-book" data-feather="book"></i>
                                        <span id="SecName" runat="server"></span>
                                    </a>
                                    <asp:Repeater runat="server" ID="rpt_subsection" OnItemDataBound="rpt_subsection_ItemDataBound">
                                        <HeaderTemplate>
                                            <ul class="sub-menu" aria-expanded="true">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li>
                                                <a id="subsecname" runat="server"></a>
                                            </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-9" runat="server" id="MainDiv" style="display:none">
            <div class="card">
                <uc1:MeaInspRemark runat="server" id="MeaInspRemark" />
                <div class="card-header">
                    <div class="row mb-3">
                        <div class="col-lg-4 col-sm-6">
                            <h5 class="card-title" runat="server" id="lSectionName">Section: Section A</h5>
                            <small runat="server" id="lSubSection">Sub-Section: Sub-Section A.1</small>
                        </div>
                        <div class="col-lg-8 col-sm-6">
                            <div class="mt-4 mt-sm-0 d-flex align-items-center justify-content-sm-end gap-2">
                                <a class="btn btn-soft-primary" ID="bSave" OnClick="javascript:saveValues()">
                                    <i class="fa fa-save"></i> Save Data
                                </a>
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bEditRemark" OnClick="bEditRemark_Click">
                                    <i class="fa fa-edit"></i> Edit Section Remark
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bBack" OnClick="bBack_Click">
                                    <i class="fa fa-backspace"></i> Back
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="d-grid">
                        <asp:LinkButton Visible="false" runat="server" CssClass="btn btn-soft-success btn-sm" ID="bLHApv" OnClick="bLHApv_Click"
                            OnClientClick="return confirmLHApv();">
                            <i class="fas fa-check-square"></i> LH Approve
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="card-body">
                    <img src="../../../../images/NoPicture.png" runat="server" id="imgSection" 
                        class="img-fluid" style="display: block; margin-left:auto; margin-right:auto; Position:Static; height:70%" />
                    <hr />
                    <div class="row">
                        <div class="col-md-6">
                            <p class="text-muted mb-2">Section Remark:</p>
                            <h6 runat="server" id="lSectionRemark">Test</h6>
                        </div>
                        <div class="col-md-6">
                            <p class="text-muted mb-2">Section Approval:</p>
                            <h6 runat="server" id="lSectionApproval">Test</h6>
                        </div>
                    </div>
                    
                    <hr />
                    <div class="table-responsive d-flex justify-content-center">
                        <table class="table table-bordered table-striped w-100 gridview" style="font-size:80%">

                           <%--Start:Table Header--%>
                            <asp:Repeater ID="rptHeader" runat="server">
                                <HeaderTemplate>
                                    <thead>
                                        <tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <th id="myHeader" runat="server"><%# Eval("ItemDesc") %></th>
                                </ItemTemplate>
                                <FooterTemplate>
                                        </tr>
                                    </thead>
                                </FooterTemplate>
                            </asp:Repeater>
                            <%--End:Table Header--%>

                            <%--Start: Table Body--%>
                            <tbody>
                                 <asp:Repeater ID="rptItem" runat="server" OnItemDataBound="rptItem_ItemDataBound">
                                     <ItemTemplate>
                                         <tr>
                                             <td><%# Eval("StepDesc") %></td>
                                             <asp:PlaceHolder ID="placeholder1" runat="server"></asp:PlaceHolder>
                                         </tr>
                                     </ItemTemplate>
                                 </asp:Repeater>
                            </tbody>
                            <%--End: Table Body--%>
                            <script>
                                function saveValues() {
                                    var inputs = document.getElementsByName("txtValue");
                                    var data = [];

                                    // Loop melalui semua input dan simpan nilai ke array
                                    for (var i = 0; i < inputs.length; i++) {
                                        var inputid = inputs[i].id; //id
                                        var inputVal = inputs[i].value;
                                        data.push({ IDInsp: inputid, value: inputVal });

                                        $.ajax({
                                            type: "POST",
                                            url: "MeaInspWorksheetRev.aspx/UpdateInput",
                                            data: "{'IDInsp':'" + inputid + "','value':'" + inputVal + "'}",
                                            contentType: "application/json; charset=utf-8",
                                            dataType: "json",
                                            async: "false",
                                            success: function (response) {
                                                //location.reload();
                                                //console.log("IDInsp:" + inputid + ",Value:" + inputVal);
                                                
                                            },
                                            error: function (request, status, error) {
                                                alert(request.responseText);
                                            }
                                        });
                                    
                                    }
                                    toastr["success"]("Saved !");
                                }

                                function confirmLHApv() {
                                    var result = confirm("Are you sure to approve this section?");
                                    if (result === true) {
                                        return true; // Allow the code-behind event to execute
                                    } else {
                                        return false; // Cancel the code-behind event
                                    }
                                }
                            </script>
                        </table>
                    </div> 
                </div>
            </div>
        </div>
    </div>
</asp:Content>