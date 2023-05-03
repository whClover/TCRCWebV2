<%@ Page Title="test" MasterPageFile="~/Report.Master" Language="vb" AutoEventWireup="false" CodeBehind="test.aspx.vb" Inherits="TCRCWebV2.test" %>
<%@ Register Src="~/Views/TCRC/Reports/CoverPage.ascx" TagPrefix="uc1" TagName="CoverPage" %>


<asp:Content runat="server" ContentPlaceHolderID="ReportDyn">
    <style>
        .logo {
			position: absolute;
			top: 0;
			left: 0;
			width: 100px;
			height: auto;
		}
        .headerrpt {
            display: inline-block;
			vertical-align: top;
			margin-left: 10px;
        }
    </style>
    <div class="row">
        <div class="col-xs-3">
            <img src="../../../assets/images/logo/Thiess.png" class="logo" />
        </div>
    </div>
    <div class="row">
        <div class="headerrpt">
            <h5>TCRC</h5>
            <small>Web-Applications</small>
        </div>
    </div>
</asp:Content>