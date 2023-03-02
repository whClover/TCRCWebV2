<%@ Page Title="Measure Inspection Template Details" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="MeaTemplateSecDetails.aspx.vb" Inherits="TCRCWebV2.MeaTemplateSecDetails" %>

<%@ Register Src="~/Views/TCRC/Workshop/Inspection/MeaTemplateSecDetailsEdit.ascx" TagPrefix="uc1" TagName="MeaTemplateSecDetailsEdit" %>
<%@ Register Src="~/Views/TCRC/Workshop/Inspection/MeaInspTemplateRef.ascx" TagPrefix="uc1" TagName="MeaInspTemplateRef" %>
<%@ Register Src="~/Views/TCRC/Workshop/Inspection/MeaTemplatePicUpload.ascx" TagPrefix="uc1" TagName="MeaTemplatePicUpload" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>



<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-flex align-items-center justify-content-between">
                    <h4 class="mb-0">Measurement Inspection Section Details</h4>

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
                        <uc1:MeaTemplateSecDetailsEdit runat="server" ID="MeaTemplateSecDetailsEdit" />
                        <uc1:MeaInspTemplateRef runat="server" ID="MeaInspTemplateRef" />
                        <uc1:MeaTemplatePicUpload runat="server" id="MeaTemplatePicUpload" />
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
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="bAdd" OnClick="bAdd_Click">
                                <i class="fa fa-plus"></i> Add Sub-Section
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="bAddRef" OnClick="bAddRef_Click">
                                <i class="fa fa-plus"></i> Add Reference
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="bUploadPict" OnClick="bUploadPict_Click">
                                <i class="fa fas fa-paperclip"></i> Attach Section Picture
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="bBack" OnClick="bBack_Click">
                                <i class="fas fa-arrow-alt-circle-left"></i> Back
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <div class="card-title mb-2 fw-bold" id="TitleSection" runat="server">Section:</div>
                    </div>
                    <img id="imgSection" runat="server" src="~/assets/images/NoPicture.png" style="display: block; margin-left:auto; margin-right:auto;"
                            class="img-fluid" alt=" " />
                    <div class="card-body">
                        <asp:Repeater runat="server" ID="rpt_SubSection" OnItemDataBound="rpt_SubSection_ItemDataBound">
                            <ItemTemplate>
                                <div class="d-flex justify-content-between mb-2">
                                    <div>
                                        <div class="card-title mb-2">Sub-Section: <%# Eval("SubSectionName") %></div>
                                    </div>
                                    <div>
                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-purple btn-sm" ID="bAddItem" OnClick="bAddItem_Click"
                                            seqsubsection='<%#Eval("SeqSubSection") %>' subsection='<%# Eval("SubSectionName") %>'>
                                            <i class="fa fa-plus"></i> Add New Item
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-purple btn-sm" ID="bEditSub" OnClick="bEditSub_Click" 
                                            seqsubsection='<%#Eval("SeqSubSection") %>' subsection='<%# Eval("SubSectionName") %>'>
                                            <i class="fa fa-edit"></i> Edit Sub-Section
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-soft-purple btn-sm" ID="bRemoveSub" OnClick="bRemoveSub_Click"
                                            subsection='<%# Eval("SubSectionName") %>' OnClientClick="return confirm('Are you sure?');">
                                            <i class="fa fa-trash"></i> Remove Sub-Section
                                        </asp:LinkButton>
                                    </div>
                                </div>     
                                <div id="dPassive" runat="server"></div>
                                <asp:GridView runat="server" ID="gv_Item" AutoGenerateColumns="false" CssClass="table table-striped table-bordered gridview">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Button runat="server" ID="bEdit" CssClass="btn btn-link btn-sm text-purple" Text="Edit" OnClick="bEdit_Click" iddata='<%# Eval("IDDetail") %>' />
                                                <asp:Button runat="server" ID="bRemove" CssClass="btn btn-link btn-sm text-purple" Text="Remove" OnClick="bRemove_Click" iddata='<%# Eval("IDDetail") %>' 
                                                    OnClientClick="return confirm('Are you sure?');"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SeqItem" HeaderText="Sequence" ItemStyle-Width="5%" />
                                        <asp:BoundField DataField="ItemDesc" HeaderText="Description" ItemStyle-Width="40%" />
                                        <asp:BoundField DataField="LoopCount" HeaderText="Total Rows" ItemStyle-Width="10%"/>
                                        <asp:BoundField DataField="ValType" HeaderText="Value Type" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="RegisterBy" HeaderText="Register By" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="RegisterDate" HeaderText="Register Date" ItemStyle-Width="10%"/>
                                    </Columns>
                                </asp:GridView>
                                <hr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
