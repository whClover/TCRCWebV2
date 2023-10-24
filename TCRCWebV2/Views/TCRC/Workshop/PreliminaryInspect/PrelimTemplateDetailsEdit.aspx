<%@ Page Title="Preliminary Template Details Edit" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="PrelimTemplateDetailsEdit.aspx.vb" Inherits="TCRCWebV2.PrelimTemplateDetailsEdit" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Preliminary Template Details</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="alert alert-primary alert-dismissible fade show" role="alert">
                                <i class="fa fa-info-circle me-2"></i>
                                Template Information
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:HiddenField runat="server" ID="hidpartlist" />
                                    <dl class="dl-horizontal">
                                        <dt>Template ID</dt>
                                        <dd runat="server" id="sid">#</dd>
                                        <dt>Part Number <asp:LinkButton runat="server" CssClass="btn btn-link btn-sm me-2"><i class="fa text-primary fa-search"></i></asp:LinkButton></dt>
                                        <dd runat="server" id="spn">#</dd>
                                        <dt>Part Description</dt>
                                        <dd runat="server" id="spndesc">#</dd>
                                    </dl>
                                </div>
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>Part Remark</dt>
                                        <dd>
                                            <asp:TextBox runat="server" ID="tpartremark" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </dd>
                                        <dt>Specification</dt>
                                        <dd>
                                            <asp:TextBox runat="server" ID="tspec" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </dd>
                                    </dl>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>Section</dt>
                                        <dd>
                                            <asp:DropDownList CssClass="form-control form-control-sm" ID="ddsection" runat="server"></asp:DropDownList>
                                        </dd>
                                        <dt>Sequence</dt>
                                        <dd>
                                            <asp:TextBox CssClass="form-control form-control-sm" ID="tseq" runat="server" TextMode="Number"></asp:TextBox>
                                        </dd>
                                        <dt>No. Picture</dt>
                                        <dd>
                                            <asp:TextBox CssClass="form-control form-control-sm" ID="tnopict" runat="server"></asp:TextBox>
                                        </dd>
                                        <dt>Qty</dt>
                                        <dd>
                                            <asp:TextBox CssClass="form-control form-control-sm" ID="tqty" runat="server" TextMode="Number"></asp:TextBox>
                                        </dd>
                                    </dl>
                                </div>
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>NDT</dt>
                                        <dd>
                                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddndt">
                                                <asp:ListItem Text="False" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </dd>
                                        <dt>Normal Condition</dt>
                                        <dd>
                                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="ddnormalcondition">
                                                <asp:ListItem Text="Normal Condition" Value="Normal Condition"></asp:ListItem>
                                                <asp:ListItem Text="Premature Failure" Value="Premature Failure"></asp:ListItem>
                                            </asp:DropDownList>
                                        </dd>
                                        <dt>Deactivate</dt>
                                        <dd>
                                            <asp:DropDownList CssClass="form-control form-control-sm" runat="server" ID="dddeactive">
                                                <asp:ListItem Text="False" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </dd>
                                    </dl>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm" ID="bsave" OnClick="bsave_Click">
                                        <i class="fa fa-save"></i> Save Data
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm" ID="bback" OnClick="bback_Click">
                                        <i class="fa fa-reply"></i> Back
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="alert alert-primary alert-dismissible fade show" role="alert">
                                <i class="fa fa-info-circle me-2"></i>
                                Template Group Information
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>Template Group ID</dt>
                                        <dd runat="server" id="sidgp">#</dd>
                                        <dt>Unit Description</dt>
                                        <dd runat="server" id="sunitdesc">#</dd>
                                    </dl>
                                </div>
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>Sheet Name</dt>
                                        <dd runat="server" id="ssheetname">#</dd>
                                        <dt>Global Part Number</dt>
                                        <dd runat="server" id="sglobalpn">#</dd>
                                    </dl>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-md-12 text-center">
                                    <asp:Image runat="server" CssClass="img-fluid" ImageUrl="~/images/NoPicture.png" />
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="alert alert-primary alert-dismissible fade show" role="alert">
                                        <i class="fa fa-info-circle me-2"></i>
                                        Document Information
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>Create Date</dt>
                                        <dd runat="server" id="sregdate">#</dd>
                                        <dt>Create By</dt>
                                        <dd runat="server" id="sregby">#</dd>
                                    </dl>
                                </div>
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>Modified Date</dt>
                                        <dd runat="server" id="smoddate">#</dd>
                                        <dt>Modified By</dt>
                                        <dd runat="server" id="smodby">#</dd>
                                    </dl>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>