<%@ Page Title="Assembly Template Details" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="AssemblyTemplateDetails.aspx.vb" Inherits="TCRCWebV2.AssemblyTemplateDetails" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyTemplateSection.ascx" TagPrefix="uc1" TagName="AssemblyTemplateSection" %>
<%@ Register Src="~/Views/TCRC/Workshop/AssemblyMod/AssemblyTemplateGPPict.ascx" TagPrefix="uc1" TagName="AssemblyTemplateGPPict" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Assembly Template Details</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="mb-3 row">
                                <label for="example-text-input" class="col-md-2 col-form-label">Unit Desc</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="tunitdesc" CssClass="form-control form-control-sm" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3 row">
                                <label for="example-text-input" class="col-md-2 col-form-label">Template Name</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="tTemplateName" CssClass="form-control form-control-sm" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="mb-3">
                                <label>Assembly Section</label>
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddsection"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-3">
                                <label>Assembly Descriptions</label>
                                <asp:textbox runat="server" CssClass="form-control form-control-sm" ID="tDesc" AutoCompleteType="Disabled"></asp:textbox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-3">
                                <label>Sequence</label>
                                <asp:textbox runat="server" CssClass="form-control form-control-sm" ID="tseq" AutoCompleteType="Disabled"></asp:textbox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-3">
                                <label>Active</label>
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddactive">
                                    <asp:ListItem Text="TRUE" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="FALSE" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bsearch" OnClick="bsearch_Click">
                                <i class="fa fa-search"></i> Search
                            </asp:LinkButton>
                            <uc1:AssemblyTemplateSection runat="server" id="AssemblyTemplateSection" />
                            <uc1:AssemblyTemplateGPPict runat="server" id="AssemblyTemplateGPPict" />
                            <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="baddsection" OnClick="baddsection_Click">
                                <i class="fa fa-plus"></i> Add New Section
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater runat="server" ID="rpt_section" OnItemDataBound="rpt_section_ItemDataBound">
                <ItemTemplate>
                    <div class="text-center mb-3">
                        <h5 class="card-title mb-3" runat="server" id="hsection"></h5>
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="baddstep" OnClick="baddstep_Click" CommandArgument='<%# Eval("AssemblySection") %>'>
                                    <i class="fa fa-plus"></i> Add Step
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm" ID="bchangepict" OnClick="bchangepict_Click" CommandArgument='<%# Eval("AssemblySection") %>'>
                                    <i class="fa fa-image"></i> Change/Upload Picture
                                </asp:LinkButton>
                            </div>
                            
                        </div>
                        <img runat="server" id="imgGp" src='<%# Eval("PicturePathGroup").ToString() %>' class="mb-3 img-fluid"
                            style="display: block; margin-left:auto; margin-right:auto; Position:Static; height:50%"/>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-body p-0">
                                    <div class="table-responsive">
                                        <asp:Repeater runat="server" ID="rpt_details" OnItemDataBound="rpt_details_ItemDataBound">
                                            <HeaderTemplate>
                                                <table class="table table-hover table-bordered align-middle table-check">
                                                    <thead class="bg-primary text-white">
                                                        <tr>
                                                            <th style="width:5%"></th>
                                                            <th class="text-center">Sequence</th>
                                                            <th>Assembly Descriptions</th>
                                                            <th>Create By</th>
                                                            <th>Create Date</th>
                                                            <th>Modified By</th>
                                                            <th>Modified Date</th>
                                                            <th style="width:3%"></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton runat="server" CssClass="btn btn-sm btn-light" ID="bedit" OnClick="bedit_Click" CommandArgument='<%# Eval("IDTemplateAssembly") %>'>
                                                            <i class="fa fa-edit"></i>
                                                        </asp:LinkButton>
                                                        <asp:LinkButton runat="server" CssClass="btn btn-sm btn-light" ID="bhistory" OnClick="bhistory_Click" CommandArgument='<%# Eval("IDTemplateAssembly") %>'>
                                                            <i class="fa fa-history"></i>
                                                        </asp:LinkButton>
                                                        
                                                    </td>
                                                    <td class="text-center">
                                                        <span class="form-label" id="sSeq" runat="server"></span>
                                                    </td>
                                                    <td>
                                                        <asp:Image runat="server" ID="imgdet" class="mb-3 img-fluid"
                                                            style="display: block; height:50%" />
                                                        <div id="sDesc" runat="server"></div>
                                                    </td>
                                                    <td><span class="form-label" id="sRegBy" runat="server"></span></td>
                                                    <td><span class="form-label" id="sRegDate" runat="server"></span></td>
                                                    <td><span class="form-label" id="sModBy" runat="server"></span></td>
                                                    <td><span class="form-label" id="sModDate" runat="server"></span></td>
                                                    <td>
                                                        <asp:LinkButton runat="server" CssClass="btn btn-sm btn-light" ID="bdeactive" OnClick="bdeactive_Click" CommandArgument='<%# Eval("IDTemplateAssembly") %>' OnClientClick="return confirm('Are you sure?');">
                                                            <i class="fa fa-trash"></i>
                                                        </asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    
                   
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>