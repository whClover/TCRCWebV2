  <%@ Page Title="Measure Inspection Template Section" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="MeaInspTemplateSec.aspx.vb" Inherits="TCRCWebV2.MeaInspTemplateSec" %>

<%@ Register Src="~/Views/TCRC/Workshop/Inspection/MeaTemplateSecEdit.ascx" TagPrefix="uc1" TagName="MeaTemplateSecEdit" %>
<%@ Register Src="~/Views/TCRC/Workshop/Inspection/MeaTemplateSecUpload.ascx" TagPrefix="uc1" TagName="MeaTemplateSecUpload" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/Inspection/MeaInspTemplatePN.ascx" TagPrefix="uc1" TagName="MeaInspTemplatePN" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-flex align-items-center justify-content-between">
                    <h4 class="mb-0">Measurement Inspection Template</h4>

                    <div class="page-title-right">
                        <ol class="breadcrumb m-0">
                            <li class="breadcrumb-item"><a href="javascript: void(0);">Workshop Page</a></li>
                            <li class="breadcrumb-item">Measurement Inspection Template</li>
                            <li class="breadcrumb-item active">Measurement Inspection Template Details</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
        <!-- end page title -->

        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <uc1:MeaTemplateSecEdit runat="server" ID="MeaTemplateSecEdit" />
                        <uc1:MeaTemplateSecUpload runat="server" ID="MeaTemplateSecUpload" />
                        <uc1:MeaInspTemplatePN runat="server" id="MeaInspTemplatePN" />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="mb-3 row">
                                    <label for="example-text-input" class="col-md-2 col-form-label">ID</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tID" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <label for="example-text-input" class="col-md-2 col-form-label">Unit Descriptions</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tUnitDesc" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <label for="example-text-input" class="col-md-2 col-form-label">Component</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tComp" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <label for="example-text-input" class="col-md-2 col-form-label">Template Descriptions</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tDesc" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="mb-3 row">
                                    <label for="example-text-input" class="col-md-2 col-form-label">Register By</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tRegBy" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <label for="example-text-input" class="col-md-2 col-form-label">Register Date</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tRegDate" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <div class="btn-group mt-4 mt-md-0" role="group" aria-label="Basic example">
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-purple mb-3" ID="bAdd" OnClick="bAdd_Click">
                                <i class="fa fa-plus"></i> Add Section
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-purple mb-3" ID="bUpload" OnClick="bUpload_Click">
                                <i class="fa fa-upload"></i> Upload Template
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-purple mb-3" ID="bShowSample" OnClick="bShowSample_Click">
                                <i class="fas fa-file-pdf"></i> Show Sample
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-purple mb-3" ID="bBack" OnClick="bBack_Click">
                                <i class="fas fa-arrow-alt-circle-left"></i> Back
                            </asp:LinkButton>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="gvSection" AutoGenerateColumns="false" CssClass="table table-striped table-bordered gridview">
                                <Columns>
                                    <asp:TemplateField ItemStyle-CssClass="text-center" ItemStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Button runat="server" ID="bDetails" CssClass="btn btn-link btn-sm text-purple" Text="Details" 
                                                sec='<%# Eval("SectionName") %>' OnClick="bDetails_Click" /> |
                                            <asp:Button runat="server" ID="bEdit" CssClass="btn btn-link btn-sm text-purple" Text="Edit" 
                                                OnClick="bEdit_Click" seq='<%# Eval("SeqSection") %>' sec='<%# Eval("SectionName") %>' aftinsp='<%# Eval("AfterInspection") %>' /> |
                                            <asp:Button runat="server" ID="bAddPN" CssClass="btn btn-link btn-sm text-purple" Text="Add PN" 
                                                OnClick="bAddPN_Click" sec='<%# Eval("SectionName") %>' /> |
                                            <asp:Button runat="server" ID="bDelete" CssClass="btn btn-link btn-sm text-purple" Text="Delete" OnClientClick="return confirm('Are you sure?');"
                                                Onclick="bDelete_Click" seq='<%# Eval("SeqSection") %>' sec='<%# Eval("SectionName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="10%" DataField="SeqText" HeaderText="Sequence" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="SectionName" HeaderText="Section Name" />
                                    <asp:BoundField DataField="AfterInspection" HeaderText="After Inspection" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>

</asp:Content>