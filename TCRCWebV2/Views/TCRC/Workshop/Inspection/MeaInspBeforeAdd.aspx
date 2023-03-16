<%@ Page Title="Measure Inspection Worksheet" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="MeaInspBeforeAdd.aspx.vb" Inherits="TCRCWebV2.MeaInspBeforeAdd1" %>

<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Assign Inspection Template</h5>
                </div>
                <div class="card-body">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="mb-3">
                                    <label class="form-label" for="ddWONo">Work Order Number</label>
                                    <div class="row">
                                        <div class="col">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="two" AutoCompleteType="Disabled"></asp:TextBox>
                                            <small runat="server" id="twodesc"></small>
                                        </div>
                                        <div class="col-auto">
                                            <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="bsearch" OnClick="bsearch_Click">
                                                <i class="fa fa-search"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3">
                                <label class="form-label" for="formrow-firstname-input">Inspection Template Available</label>
                                <asp:DropDownList runat="server" ID="ddInspTemp" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Button ID="bSave" runat="server" Text="Assign Template" CssClass="btn btn-soft-purple btn-sm" OnClick="bSave_Click"/>
                    <asp:Button ID="bClose" runat="server" Text="Close" CssClass="btn btn-soft-purple btn-sm" OnClick="bClose_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>