<%@ Page Title="5S Details" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="FiveSDetails.aspx.vb" Inherits="TCRCWebV2.FiveSDetails" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/5S/FiveSDetailsForm.ascx" TagPrefix="uc1" TagName="FiveSDetailsForm" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-8">
            <div class="card">
                <uc1:FiveSDetailsForm runat="server" id="FiveSDetailsForm" />
                <div class="card-header">
                    <div class="d-flex align-items-center">
                        <div class="flex-shrink-0 me-3">
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm btn-rounded" ID="bBack" OnClick="bBack_Click">
                                <i class="fas fa-reply"></i>
                            </asp:LinkButton>
                        </div>
                        <div class="flex-grow-1 overflow-hidden">
                            <h5 class="card-title">Champion 5S Program - TCRC</h5>
                            <span class="card-title-desc" runat="server" id="head1"></span> <br />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    Kategori yang dinilai/diobservasi tiap area: <br />
                    <div class="ms-2">
                        1. Housekeeping, kondisi area kerja bersih dan rapi terutama pada 
                        <span class="text-decoration-underline fw-bold">waktu kritikal menjelang istirahat dan pulang kerja.</span> <br />
                        2. Habit, mengamati kebiasaan positif dan negatif dari rekan kerja untuk area kerjanya masing-masing. <br />
                        3. Tools, menyampaikan ide baru dan temuan mengenai tools yang digunakan di workshop
                        <span class="text-decoration-underline fw-bold">(Catat dan diskusikan bersama engineering team).</span> <br />
                    </div>
                    <span class="fw-bold">Note: Jangan lupa untuk mengambil foto setiap ada temuan</span>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card">
                <div class="card-header bg-soft-primary">
                    <h6 class="card-title">Assign Leader</h6>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <h6>Assign ke Leader</h6>
                        <asp:DropDownList CssClass="form-select mb-3" runat="server" ID="ddLeader"></asp:DropDownList>
                        <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" OnClick="bassign_Click" ID="bassign">
                            Assign
                        </asp:LinkButton>
                    </div>
                    <hr />
                    <div class="mb-3">
                        <div class="d-grid">
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-primary mt-3" ID="bSupvApv" OnClick="bSupvApv_Click" OnClientClick="return confirm('Anda yakin?')">
                                Approve
                            </asp:LinkButton>
                        </div>
                         
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="page-title-box d-flex align-items-center justify-content-between">
            <h4 class="mb-0">Area Yang Diperiksa</h4>
            <div class="page-title-right">
                <ol class="breadcrumb m-0">
                    <li class="breadcrumb-item">(1) Kurang Baik</li>
                    <li class="breadcrumb-item">(2) Cukup Baik</li>
                    <li class="breadcrumb-item">(3) Sangat Baik</li>
                </ol>
            </div>
        </div>
    </div>

    <asp:Repeater runat="server" ID="rptArea" OnItemDataBound="rptArea_ItemDataBound">
        <ItemTemplate>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <div class="card-title" runat="server" id="hArea"><%# Eval("Seq") & ". " & Eval("AreaDesc") %></div>
                        </div>
                        <div class="card-body">
                            <div class="mb-3">
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="baddissue" OnClick="baddissue_Click" CommandArgument='<%# Eval("IDArea") %>'>
                                    <i class="fa fa-plus"></i> Tambahkan Temuan
                                </asp:LinkButton>
                            </div>
                            <asp:GridView runat="server" CssClass="table table-bordered p-0 table-sm" ID="gvdetails" EmptyDataText="No Issue !" AutoGenerateColumns="false" OnRowDataBound="gvdetails_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="No" HeaderStyle-CssClass="text-center bg-soft-primary" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblNo" CssClass="text-center" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Temuan" DataField="FindingDesc" HeaderStyle-CssClass="bg-soft-primary" />
                                    <asp:BoundField HeaderText="Action yang dilakukan terhadap temuan" DataField="FindingAct" HeaderStyle-CssClass="bg-soft-primary" />
                                    <asp:BoundField HeaderText="Nilai" DataField="NilaiVal" HeaderStyle-CssClass="bg-soft-primary" />
                                    <asp:BoundField HeaderText="Tanggal Temuan" DataField="RegDate" HeaderStyle-CssClass="bg-soft-primary" />
                                    <asp:TemplateField HeaderStyle-CssClass="bg-soft-primary" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-soft-light btn-sm" ID="bedit" OnClick="bedit_Click" CommandArgument='<%# Eval("IDFinding") %>'>
                                                <i class="fa fa-edit"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>