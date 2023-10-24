<%@ Page Title="5S Location Register" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="FiveSLocation.aspx.vb" Inherits="TCRCWebV2._5SLocation" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/5S/FiveSLocationForm.ascx" TagPrefix="uc1" TagName="FiveSLocationForm" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-6">
            <div class="card">
                <uc1:FiveSLocationForm runat="server" id="FiveSLocationForm" />
                <div class="card-header">
                    <h4 class="card-title">5S Location Register</h4>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="badd" OnClick="badd_Click">
                            <i class="fa fa-plus"></i> Add Location
                        </asp:LinkButton>
                    </div>
                    <asp:GridView ID="gv5SLocation" AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-sm">
                        <Columns>
                            <asp:TemplateField HeaderStyle-CssClass="text-center bg-light" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CssClass="btn btn-soft-light" CommandArgument='<%# Eval("IDLocation") %>' ID="bdetails" OnClick="bdetails_Click">
                                        <i class="fa fa-eye"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Descriptions" HeaderStyle-CssClass="bg-light">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CssClass="btn btn-link" ID="bedit" OnClick="bedit_Click" CommandArgument='<%# Eval("IDLocation") %>'>
                                        <%# Eval("LocationDesc").ToString() %>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>