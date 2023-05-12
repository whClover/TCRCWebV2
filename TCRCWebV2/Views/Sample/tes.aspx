<%@ Page Title="Users Page" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="tes.aspx.vb" Inherits="TCRCWebV2.tes" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-4">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Inspection</h5>
                </div>
                <div class="card-body">
                    <div class="row icon-demo-content" id="newIcons">
                        <div class="col-xl-3 col-lg-4 col-sm-6">
                            <i class="fa fa-user fa-3x"></i>
                            <span>Measure Inspection</span>
                        </div>
                        <div class="col-xl-3 col-lg-4 col-sm-6">
                            <i class="mdi mdi-application-settings fa-3x"></i>
                            <span>Inspection Template</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>