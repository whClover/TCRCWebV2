<%@ Page Title="Preliminary Template List" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="PrelimTemplateList.aspx.vb" Inherits="TCRCWebV2.PrelimTemplateList" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Preliminary Template List</h5>
                </div>
                <div class="card-body">
                    <div class="row">

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>