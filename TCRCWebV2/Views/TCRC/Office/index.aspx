<%@ Page Title="office Page" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="TCRCWebV2.index1" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <!-- start page title -->
    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-flex align-items-center justify-content-between">
                <h4 class="mb-0">Office Page</h4>

                <div class="page-title-right">
                    <ol class="breadcrumb m-0">
                        <li class="breadcrumb-item"><a href="javascript: void(0);">TCRC</a></li>
                        <li class="breadcrumb-item active">Office</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Administration</h5>
                </div>
                <div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <div class="d-flex align-items-center">
                                <div class="flex-shrink-0 me-3">
                                    <div class="avatar-sm">
                                        <div class="avatar-title rounded font-size-12">
                                            <i class="fas fa-user"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="flex-grow-1">
                                    <asp:LinkButton runat="server" CssClass="text-primary mb-1" ID="bWODetails" OnClick="bWODetails_Click">WO Detail</asp:LinkButton><br />
                                    <div class="text-danger" runat="server" id="tagWODetails">
                                        <i class="fa fa-lock"></i> Locked
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>