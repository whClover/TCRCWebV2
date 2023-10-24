<%@ Page Title="Workshop Page" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="indexWS.aspx.vb" Inherits="TCRCWebV2.indexWS" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <style>
        .grid-container {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
            grid-gap: 10px;
            padding: 10px;
        }

        /* Mengatur tampilan tile */
        .grid-item {
            background-color: #ffffff;
            padding: 20px;
            text-align: center;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
        }

            /* Mengatur ikon */
            .grid-item i {
                font-size: 24px;
                margin-bottom: 10px;
            }

        /* Mengatur responsivitas tile */
        @media screen and (max-width: 600px) {
            .grid-item {
                font-size: 14px;
            }

            /* Mengatur grid ketika lebar layar < 600px */
            .grid-container {
                grid-template-columns: repeat(2, 200px); /* Atur lebar tetap 200px */
                justify-content: center; /* Pusatkan grid-item */
            }
        }

        .grid-button {
            background-color: #ffffff;
            padding: 20px;
            text-align: center;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            cursor: pointer;
        }
    </style>
    <div class="row mb-3">
        <div class="col-md-4">
            <div class="">
                <h6 class="mb-2 text-decoration-underline">Measure Inspection</h6>
            </div>

            <div class="grid-container">
                <asp:LinkButton runat="server" CssClass="btn grid-button" ID="bMeaWorksheet" OnClick="bMeaWorksheet_Click">
                    <i class="fas fa-file-signature fa-2x text-muted"></i>
                    <div>Measure Worksheet</div>
                </asp:LinkButton>
                <asp:LinkButton runat="server" CssClass="btn grid-button" ID="bMeaTemplate" OnClick="bMeaTemplate_Click">
                    <i class="fa fa-book fa-2x text-muted"></i>
                    <div>Measure Template</div>
                </asp:LinkButton>
            </div>

            <hr />

            <div class="">
                <h6 class="mb-2 text-decoration-underline">Preliminary Inspection</h6>
            </div>

            <div class="grid-container">
                <asp:LinkButton runat="server" CssClass="btn grid-button">
                    <i class="fas fa-file-signature fa-2x text-muted"></i>
                    <div>Preliminary Worksheet</div>
                </asp:LinkButton>
                <asp:LinkButton runat="server" CssClass="btn grid-button" ID="bprelimtemplate" OnClick="bprelimtemplate_Click">
                    <i class="fa fa-book fa-2x text-muted"></i>
                    <div>Preliminary Template</div>
                </asp:LinkButton>
            </div>
        </div>

        <div class="col-md-4">
            <div class="">
                <h6 class="mb-2 text-decoration-underline">Component Assembly</h6>
            </div>

            <div class="grid-container">
                <asp:LinkButton runat="server" CssClass="btn grid-button" ID="basm" OnClick="basm_Click">
                    <i class="fas fa-file-signature fa-2x text-muted"></i>
                    <div>Assembly Worksheet</div>
                </asp:LinkButton>
                <asp:LinkButton runat="server" CssClass="btn grid-button" ID="basmtemplate" OnClick="basmtemplate_Click">
                    <i class="fa fa-book fa-2x text-muted"></i>
                    <div>Assembly Template</div>
                </asp:LinkButton>
            </div>

            <hr />

            <div class="">
                <h6 class="mb-2 text-decoration-underline">Component Testing</h6>
            </div>

            <div class="grid-container">
                <asp:LinkButton runat="server" CssClass="btn grid-button" ID="bwstesting" OnClick="bwstesting_Click">
                    <i class="fas fa-file-signature fa-2x text-muted"></i>
                    <div>Testing Worksheet</div>
                </asp:LinkButton>
            </div>

        </div>

        <div class="col-md-4">
            <div class="">
                <h6 class="mb-2 text-decoration-underline">5S Module</h6>
            </div>

            <div class="grid-container">
                <asp:LinkButton runat="server" CssClass="btn grid-button" ID="fivesummary" OnClick="fivesummary_Click">
                    <i class="fas fa-atlas fa-2x text-muted"></i>
                    <div>5S Summary</div>
                </asp:LinkButton>
                <asp:LinkButton runat="server" CssClass="btn grid-button" ID="b5sapv" OnClick="b5sapv_Click">
                    <i class="fas fa-user fa-2x text-muted"></i>
                    <div>My Outstanding Approval</div>
                </asp:LinkButton>
                <asp:LinkButton runat="server" CssClass="btn grid-button" ID="fivesreg" OnClick="fivesreg_Click">
                    <i class="fas fa-search fa-2x text-muted"></i>
                    <div>5S Register</div>
                </asp:LinkButton>
                <asp:LinkButton runat="server" CssClass="btn grid-button" ID="fivesloc" OnClick="fivesloc_Click">
                    <i class="fas fa-location-arrow fa-2x text-muted"></i>
                    <div>Location Register</div>
                </asp:LinkButton>
            </div>

        </div>

        
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="">
                <h6 class="mb-2 text-decoration-underline">Other Module</h6>
            </div>

            <div class="grid-container">
                <asp:LinkButton runat="server" CssClass="btn grid-button" ID="bCompRelease" OnClick="bCompRelease_Click">
                    <i class="fas fa-truck-loading fa-2x text-muted"></i>
                    <div>Component Release</div>
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>