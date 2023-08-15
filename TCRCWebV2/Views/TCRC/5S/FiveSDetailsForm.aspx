<%@ Page Title="5S Details" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="FiveSDetailsForm.aspx.vb" Inherits="TCRCWebV2.FiveSDetailsForm1" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header justify-content-between d-flex align-items-center">
                    <h5 class="card-title" runat="server" id="eTitle">Register Finding</h5>
                    <div class="mb-3">
                        <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bsave" OnClick="bsave_Click">
                            <i class="fa fa-save"></i> Save Data

                        </asp:LinkButton>
                        <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="bclose" OnClick="bclose_Click">X</asp:LinkButton>
                    </div>
                    
                </div>
                <div class="card-body">
                    <asp:HiddenField runat="server" ID="hidarea" />
                    <asp:HiddenField runat="server" ID="hidfinding" />
                    <asp:HiddenField runat="server" ID="hidfindingGP" />
                    <div class="mb-3">
                        <h6>Nama Area</h6>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="tArea"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <h6>Temuan</h6>
                        <asp:TextBox runat="server" CssClass="form-control" ID="tfinding" AutoCompleteType="none" Rows="5" Height="30px"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <h6>Action yang dilakukan</h6>
                        <asp:TextBox runat="server" CssClass="form-control" ID="taction" AutoCompleteType="none"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <h6>Nilai</h6>
                        <asp:DropDownList runat="server" CssClass="form-select" ID="ddnilai">
                            <asp:ListItem Text="Belum di Nilai" Value=""></asp:ListItem>
                            <asp:ListItem Text="Kurang Baik" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Cukup Baik" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Sangat Baik" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3" runat="server" id="dupload">
                        <div class="row mb-2">
                            <div class="col-md-8">
                                <h6>Upload Photo</h6>
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" ToolTip="Choose Picture to upload" AllowMultiple="true" />
                            </div>
                            <div class="col-md-4">
                                <h6>#</h6>
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-light" ID="bupload" OnClick="bupload_Click">
                                    <i class="fa fa-upload"></i>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row" runat="server" id="rupload">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header justify-content-between d-flex align-items-center">
                    <h4 class="card-title">Foto Temuan</h4>
                </div><!-- end card header -->
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <style>
                                .imgku {
                                    height: 400px;
                                    width: 600px;
                                    object-fit: cover;
                                }
                            </style>
                            <div class="row gallery-wrapper">
                                <asp:Repeater runat="server" ID="rpt_pict">
                                    <ItemTemplate>
                                        <div class="element-item col-xl-4 col-sm-6 mb-3">
                                            <div class="card">
                                                <div class="gallery-container">
                                                    <div class="text-center">
                                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="delpict" CommandArgument='<%# Eval("ID5SPict") %>' OnClientClick="return confirm('Apakah Anda yakin ingin menghapus gambar ini?');" OnClick="delpict_Click">
                                                            <i class="fa fa-times-circle text-danger"></i> Hapus Gambar
                                                        </asp:LinkButton>
                                                    </div>
                                                    <a class="image-popup" href="#" title="">
                                                        <img class="gallery-img imgku mx-auto" src='<%# Eval("remap") %>' runat="server" alt="" />
                                                        <div class="gallery-overlay"></div>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>