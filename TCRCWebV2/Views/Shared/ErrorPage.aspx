<%@ Page Title="Error Page" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="ErrorPage.aspx.vb" Inherits="TCRCWebV2.ErrorPage" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="col-md-12">
        <div class="card border border-danger">
            <div class="card-header bg-transparent border-danger">
                <h6 class="my-0 text-danger fw-bold">Error Occured. Please Capture This Error And Send To Trahayu@thiess.co.id And MISetiawan@thiess.co.id</h6>
            </div>
            <div class="card-body">
                <h5 class="card-title mb-3">Error Details Informations</h5>
                <table class="table table-bordered">
                    <tbody>
                        <tr>
                            <td style="width:20%" class="fw-bold">UserName</td>
                            <td>
                                <span id="username" runat="server"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:20%" class="fw-bold">Error Data/Time</td>
                            <td>
                                <span id="tErrorTime" runat="server"></span>
                            </td>
                        </tr>
                        <tr >
                            <td style="width:20%" class="fw-bold">Page</td>
                            <td>
                                <span id="page" runat="server"></span>
                            </td>
                        </tr>
                        <tr >
                            <td style="width:20%" class="fw-bold">Sub/Function</td>
                            <td>
                                <span id="subfun" runat="server"></span>
                            </td>
                        </tr>
                        <tr >
                            <td style="width:20%" class="fw-bold">Error Description</td>
                            <td>
                                <span id="error" runat="server"></span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>