<%@ Page Title="Component Release Form" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="ComponentRel.aspx.vb" Inherits="TCRCWebV2.ComponentRel" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/Other/ComponentRelEdit.ascx" TagPrefix="uc1" TagName="ComponentRelEdit" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="col-md-12">
        <div class="card">
            <div class="card-header justify-content-between d-flex align-items-center bg-soft-purple">
                <h4 class="card-title text-purple">Component Release Form</h4>       
            </div><!-- end card header -->
            <div class="card-body">
                <div class="row">
                    <div class="col-md-4">
                        <div class="mb-3">
                            <label for="tWONo">WONo</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tWONo" AutoCompleteType="Disabled"></asp:TextBox>
                        </div>                                
                    </div>
                </div>
                <div class="btn-group mt-4 mt-md-0" role="group" aria-label="Basic example">
                    <asp:LinkButton runat="server" CssClass="btn btn-soft-purple" ID="bSearch" OnClick="bSearch_Click">
                        <i class="fa fa-search"></i> Search
                    </asp:LinkButton>
                </div><br />
                <asp:Label runat="server" ID="lcount" CssClass="badge badge-soft-purple"></asp:Label>
            </div>
            <div class="card-footer">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gv_comprel" AutoGenerateColumns="false" CssClass="table table-bordered gridview">
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="bg-soft-purple text-purple">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="bEdit" CssClass="btn btn-link btn-sm text-purple" CommandArgument='<%# Eval("WONo") %>' OnClick="bEdit_Click">
                                        Edit
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="WONo" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="WONo" />
                            <asp:BoundField HeaderText="WoDesc" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="WODesc" />
                            <asp:BoundField HeaderText="Current Activity" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="LastActivity" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <uc1:ComponentRelEdit runat="server" id="ComponentRelEdit" />
</asp:Content>