<%@ Page Title="Assembly Liner Projection" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyLinerProj.aspx.vb" Inherits="TCRCWebV2.AssemblyLinerProj" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyMenu.ascx" TagPrefix="uc1" TagName="AssemblyMenu" %>

<asp:Content ContentPlaceHolderID="MenuContent" runat="server">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title" runat="server" id="lwono">WO.</h5>
                    <small class="card-title-desc" runat="server" id="lwodesc">WO Desc.</small>
                </div>
                <div class="card-body">
                    <div class="row">
                        <uc1:AssemblyMenu runat="server" ID="AssemblyMenu" />
                        <div class="col-md-9">
                            <div class="d-flex flex-wrap gap-2 mb-2 fw-bold">
                                <u>Liner Projection</u>
                            </div>
                            <div class="mt-3 mb-3">
                                <p class="text-muted font-size-13 mb-1" runat="server" id="lSectionProg">Overall Progress (50%)</p>
                                <div class="progress animated-progess custom-progress">
                                    <div runat="server" id="pSectionProg" class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="card">
                                        <div class="card-header bg-soft-primary">
                                            <h5 class="card-title">Cylinder No.1</h5>
                                            <small class="card-title-desc">
                                                Spesifications: 0.001inch - 0.006inch | 0.025mm - 0.152mm
                                            </small>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="mb-1">
                                                        <label class="form-label font-size-10" for="formrow-firstname-input">A</label>
                                                        <input type="number" class="form-control form-control-sm">
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-1">
                                                        <label class="form-label font-size-10" for="formrow-firstname-input">B</label>
                                                        <input type="number" class="form-control form-control-sm">
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-1">
                                                        <label class="form-label font-size-10" for="formrow-firstname-input">C</label>
                                                        <input type="number" class="form-control form-control-sm">
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-1">
                                                        <label class="form-label font-size-10" for="formrow-firstname-input">D</label>
                                                        <input type="number" class="form-control form-control-sm">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="mb-1">
                                                        <label class="form-label font-size-10" for="formrow-firstname-input">Sum A-D:</label>
                                                        <input type="number" class="form-control form-control-sm" readonly="readonly">
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-1">
                                                        <label class="form-label font-size-10" for="formrow-firstname-input">Avg A-D:</label>
                                                        <input type="number" class="form-control form-control-sm" readonly="readonly">
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-1">
                                                        <label class="form-label font-size-10" for="formrow-firstname-input">Max A-D:</label>
                                                        <input type="number" class="form-control form-control-sm" readonly="readonly">
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-1">
                                                        <label class="form-label font-size-10" for="formrow-firstname-input">Min A-D:</label>
                                                        <input type="number" class="form-control form-control-sm" readonly="readonly">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="mb-1">
                                                <label class="form-label font-size-10" for="formrow-firstname-input">Variation:</label>
                                                <input type="number" class="form-control form-control-sm" readonly="readonly">
                                            </div>
                                            <div class="d-grid gap-2 mt-3">
                                                <asp:LinkButton CssClass="btn btn-soft-primary btn-sm btn-block mb-1" runat="server">
                                                    <i class="fa fa-save"></i> Save
                                                </asp:LinkButton>
                                            </div>      
                                        </div>
                                    </div>
                                </div>
                            </div>     
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>