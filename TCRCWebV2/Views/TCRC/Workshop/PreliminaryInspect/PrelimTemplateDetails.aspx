<%@ Page Title="Preliminary Template List" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="PrelimTemplateDetails.aspx.vb" Inherits="TCRCWebV2.PrelimTemplateDetails" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <div class="d-flex justify-content-between">
                        <h5 class="card-title">Preliminary Template Details</h5>
                        <div>
                            <button class="btn btn-light btn-sm" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight" aria-controls="offcanvasRight">
                                <i class="fa fa-filter"></i> Filter Data
                            </button>
                            <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm" ID="bexport" OnClick="bexport_Click">
                                <i class="fa fa-download"></i> Export Data
                            </asp:LinkButton>
                            <button class="btn btn-light btn-sm" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasTop" aria-controls="offcanvasTop">
                                <i class="fa fa-image"></i> Preliminary Pictures
                            </button>
                            <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm" ID="bclose" OnClick="bclose_Click">
                                <i class="fa fa-times"></i> Close
                            </asp:LinkButton>
                        </div>             
                    </div>
                </div>
                <div class="card-body">

                    <!-- top offcanvas -->
                    <div class="offcanvas offcanvas-top" tabindex="-1" id="offcanvasTop" aria-labelledby="offcanvasTopLabel">
                        <div class="offcanvas-header">
                            <h5 id="offcanvasTopLabel">Preliminary Pictures</h5>
                            <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                        </div>
                        <div class="offcanvas-body">
                            <style>
                                .img-container {
                                    position: relative;
                                    display: inline-flex;
                                    flex-direction: column;
                                    align-items: center;
                                    text-align: center;
                                    width: 200px; /* Atur lebar container sesuai kebutuhan */
                                    height: 200px; /* Atur tinggi container sesuai kebutuhan */
                                    overflow: hidden; /* Mengatur overflow agar gambar tidak melebihi batas container */
                                    border-radius: 10px; /* Mengatur sudut gambar */
                                }

                                .img-name {
                                    position: absolute;
                                    top: 0;
                                    left: 0;
                                    width: 100%;
                                    background-color: rgba(0, 0, 0, 0.8);
                                    color: #fff;
                                    padding: 5px;
                                    font-size: 12px;
                                    z-index: 1; /* Mengatur urutan tumpukan agar nama gambar berada di atas gambar */
                                }

                                .delete-button {
                                    position: absolute;
                                    bottom: 5px;
                                    left: 50%;
                                    transform: translateX(-50%);
                                    background-color: #ff0000;
                                    color: #fff;
                                    padding: 5px;
                                    font-size: 12px;
                                    border: none;
                                    cursor: pointer;
                                    opacity: 0; /* Mulai dengan mengatur opacity tombol hapus menjadi 0 */
                                    transition: opacity 0.3s ease; /* Animasi perubahan opacity saat transisi */
                                }

                                .img-container:hover .delete-button {
                                    opacity: 1; /* Mengubah opacity tombol hapus menjadi 1 saat hover */
                                }

                                .img-container img {
                                    display: block;
                                    max-width: 100%;
                                    max-height: 100%;
                                    object-fit: cover;
                                }
                            </style>
                            <asp:Repeater runat="server" ID="rpt_pict">
                                <HeaderTemplate>
                                    <div class="row row-cols-auto g-2">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="col">
                                        <div class="img-container">
                                            <div class="img-name"><%# Eval("Section") %></div>
                                            <img src='<%# Eval("PicturePath") %>' class="imgku" />
                                            <asp:LinkButton runat="server" CssClass="delete-button btn btn-sm btn-danger">
                                                <i class="fa fa-trash"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>   
                        </div>
                    </div>

                    <!-- right offcanvas -->
                    <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
                        <div class="offcanvas-header">
                            <h5 id="offcanvasRightLabel">Filter Data</h5>
                            <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                        </div>
                        <div class="offcanvas-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <dl class="dl-horizontal">
                                        <dt>Section</dt>
                                        <dd>
                                            <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddsection"></asp:DropDownList>
                                        </dd>
                                        <dt>Part Number</dt>
                                        <dd>
                                            <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tPN" AutoCompleteType="Disabled"></asp:TextBox>
                                        </dd>
                                        <dt>Part Description</dt>
                                        <dd>
                                            <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tpartdesc" AutoCompleteType="Disabled"></asp:TextBox>
                                        </dd>
                                        <dt>NDT</dt>
                                        <dd>
                                            <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddndt">
                                                <asp:ListItem Value="" Text=""></asp:ListItem>
                                                <asp:ListItem Value="0" Text="False"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="True"></asp:ListItem>
                                            </asp:DropDownList>
                                        </dd>
                                        <dt>Condition</dt>
                                        <dd>
                                            <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddcondition">
                                                <asp:ListItem Value="" Text=""></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Normal Condition"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Premature Failure"></asp:ListItem>
                                            </asp:DropDownList>
                                        </dd>
                                        <dt>Deactive</dt>
                                        <dd>
                                            <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="dddeactive">
                                                <asp:ListItem Value="0" Text="False"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="True"></asp:ListItem>
                                            </asp:DropDownList>
                                        </dd>
                                    </dl>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="bsearch" OnClick="bsearch_Click">
                                        <i class="fa fa-search"></i> Search
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="alert alert-primary alert-dismissible fade show" role="alert">
                                <i class="fa fa-info-circle me-2"></i>
                                Preliminary Template Header
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>ID Template Group</dt>
                                        <dd runat="server" id="sidgp">#</dd>
                                        <dt>Unit Descriptions</dt>
                                        <dd runat="server" id="sunitdesc">#</dd>
                                        <dt>Sheet Name</dt>
                                        <dd runat="server" id="ssheetname">#</dd>
                                    </dl>
                                </div>
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>Serial Global PN</dt>
                                        <dd runat="server" id="sglobalpn">#</dd>
                                        <dt>Maint ID</dt>
                                        <dd runat="server" id="smainid">#</dd>
                                        <dt>Template Status</dt>
                                        <dd runat="server" id="sdeactive">#</dd>
                                    </dl>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="alert alert-primary alert-dismissible fade show" role="alert">
                                <i class="fa fa-info-circle me-2"></i>
                                Document Information
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>Create By</dt>
                                        <dd runat="server" id="screateby">#</dd>
                                        <dt>Create Date</dt>
                                        <dd runat="server" id="screatedate">#</dd>
                                    </dl>
                                </div>
                                <div class="col-md-6">
                                    <dl class="dl-horizontal">
                                        <dt>Modified By</dt>
                                        <dd runat="server" id="smodby">#</dd>
                                        <dt>Modified Date</dt>
                                        <dd runat="server" id="smoddate">#</dd>
                                    </dl>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <asp:Repeater runat="server" ID="rptPrelim" OnItemDataBound="rptPrelim_ItemDataBound">
                        <ItemTemplate>
                            <div class="alert alert-warning alert-dismissible fade show" role="alert">
                                <i class="fa fa-ticket-alt me-2"></i>
                                <strong>Section :</strong> <%# Eval("SectionPart").ToString() %>
                            </div>
                            <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm mb-3" ID="badd" OnClick="badd_Click" CommandArgument='<%# Eval("SectionPart").ToString() %>'>
                                <i class="fa fa-plus-circle me-2"></i> Add Detail
                            </asp:LinkButton>
                            <div class="table-responsive">
                                <asp:GridView runat="server" CssClass="table table-hover align-middle table-check table-sm" ID="gvPrelim"
                                    AutoGenerateColumns="false" EmptyDataText="No Records Founds..." ShowHeaderWhenEmpty="true">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-CssClass="bg-light">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" CssClass="btn btn-light btn-sm" ID="bedit" CommandArgument='<%# Eval("IDTemplateDetail").ToString() %>' OnClick="bedit_Click">
                                                    <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Seq" DataField="Sequence" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="No Pict" DataField="NoPict" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Part Number" DataField="PartNumber" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Part Descriptions" DataField="PartDesc" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Qty" DataField="Qty" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Part Remark" DataField="PartDesc" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="NDT" DataField="NDT" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Condition" DataField="NormalCondition" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Deactive" DataField="Deactive" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Create By" DataField="CreateBy" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Create Date" DataField="CreateDate" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Modified By" DataField="ModBy" HeaderStyle-CssClass="bg-light" />
                                        <asp:BoundField HeaderText="Modified Date" DataField="ModDate" HeaderStyle-CssClass="bg-light" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <hr />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>