<%@ Page Title="Assembly Template Details" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyTemplateEdit.aspx.vb" Inherits="TCRCWebV2.AssemblyTemplateEdit" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="alert alert-purple alert-dismissible fade show" role="alert" id="qrychk" runat="server" visible="false">
            #
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header">
                    <div class="d-flex justify-content-between">
                        <h5 class="card-title">Assembly Step Details</h5>
                        <div>
                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm " ID="bsave" OnClick="bsave_Click">
                                <i class="fa fa-save"></i> Save
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="bclose" OnClick="bclose_Click">
                                <i class="fa fa-times"></i> Close
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="alert alert-primary alert-dismissible fade show" role="alert">
                                <i class="fa fa-info-circle me-2"></i>
                                Template Information
                            </div>
                            <dl class="dl-horizontal">
                                <dt>Assembly Template Group Name</dt>
                                <dd runat="server" id="sTemplateName">#</dd>
                                <dt>ID.Group</dt>
                                <dd runat="server" id="sIDGP">#</dd>
                                <dt>ID.Details</dt>
                                <dd runat="server" id="sIDDetal">#</dd>
                            </dl>
                        </div>
                        <div class="col-md-6">
                            <div class="alert alert-primary alert-dismissible fade show" role="alert">
                                <i class="fa fa-info-circle me-2"></i>
                                Document Information
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>Register By</dt>
                                        <dd runat="server" id="tRegBy">#</dd>
                                        <dt>Register Date</dt>
                                        <dd runat="server" id="tRegDate">#</dd>
                                    </dl>
                                </div>
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>Modified By</dt>
                                        <dd runat="server" id="tModBy">#</dd>
                                        <dt>Modified Date</dt>
                                        <dd runat="server" id="tModDate">#</dd>
                                    </dl>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="mb-1 row">
                                <label class="col-md-4 col-form-label">Assembly Section</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ReadOnly="true" ID="tsection"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-1 row">
                                <label class="col-md-4 col-form-label">Sequence</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tseq"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-1 row">
                                <label class="col-md-4 col-form-label">Assembly Description</label>
                                <div class="col-md-8">
                                    <div runat="server" class="sneditku" style="height:300px" id="tDesc"></div>
                                </div>
                            </div>
                            <div class="mb-1 row">
                                <label class="col-md-4 col-form-label">Value Type</label>
                                <div class="col-md-8">
                                    <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddvaltype">
                                        <asp:ListItem Text="Note (OK)" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Value (Number Only)" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Text & Number (Free-Text)" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="mb-1 row">
                                <label class="col-md-4 col-form-label">Instruction Type</label>
                                <div class="col-md-8">
                                    <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddInstrucType">
                                        <asp:ListItem Text="Info" Value="Info"></asp:ListItem>
                                        <asp:ListItem Text="Warning" Value="Warning"></asp:ListItem>
                                        <asp:ListItem Text="Stop" Value="Stop"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="mb-1 row">
                                <div class="d-flex justify-content-start">
                                    <label class="col-md-4 col-form-label">Step Picture</label>
                                    <div>
                                        <asp:FileUpload runat="server" CssClass="form-control form-control-sm mb-2" ID="fileupload" />
                                        <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm mb-2" ID="bupload" OnClick="bupload_Click">
                                            <i class="fa fa-upload"></i> Upload
                                        </asp:LinkButton>
                                        <img runat="server" id="img1" src="../../../../assets/images/NoPicture.png" class="mb-3 img-fluid"
                                         style="display: block; margin-left:auto; margin-right:auto; Position:Static; height:70%"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="alert alert-primary alert-dismissible fade show" role="alert">
                                <i class="fa fa-info-circle me-2"></i>
                                Spesification
                            </div>
                            <div class="mb-1 row">
                                <label class="col-md-4 col-form-label">Unit Type</label>
                                <div class="col-md-8">
                                    <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddunittype">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Metric" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="US" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="mb-1 row">
                                <label class="col-md-4 col-form-label">Spesification</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tspec" TextMode="number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-1 row">
                                <label class="col-md-4 col-form-label">Tolerance</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="ttolerance" TextMode="number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-1 row">
                                <label class="col-md-4 col-form-label">Unit</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tunit"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-1 row">
                                <div class="d-flex justify-content-between">
                                    <label class="col-md-4 col-form-label">Spesification Table</label>
                                    <div>
                                        <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm " ID="baddpec" OnClick="baddpec_Click">
                                            <i class="fa fa-plus"></i> Add
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="mb-1 row">
                                <div class="table-responsive">
                                    <asp:GridView runat="server" CssClass="table table-bordered align-middle table-check" ID="gvspec" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="Spec" HeaderText="Spesification" HeaderStyle-CssClass="bg-soft-warning" />
                                            <asp:BoundField DataField="Tolerance" HeaderText="Tolerance" HeaderStyle-CssClass="bg-soft-warning" />
                                            <asp:BoundField DataField="Unit" HeaderText="Unit" HeaderStyle-CssClass="bg-soft-warning" />
                                            <asp:BoundField DataField="UnitType" HeaderText="Unit Type" HeaderStyle-CssClass="bg-soft-warning" />
                                            <asp:TemplateField HeaderStyle-CssClass="bg-soft-warning">
                                                <ItemTemplate>
                                                    <div class="text-center">
                                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-light" ID="bdelspec" OnClick="bdelspec_Click"
                                                            OnClientClick="return confirm('Are you sure you want to delete?');" CommandArgument='<%# Eval("IDSpec") %>'>
                                                            <i class="fa fa-trash"></i>
                                                        </asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Assembly Section Picture</h5>
                </div>
                <div class="card-body">
                    <img runat="server" id="imgGp" src="../../../../assets/images/NoPicture.png" class="mb-3 img-fluid"
                        style="display: block; margin-left:auto; margin-right:auto; Position:Static; height:70%"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>