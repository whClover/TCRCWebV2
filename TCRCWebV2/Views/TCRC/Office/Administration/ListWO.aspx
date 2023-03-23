<%@ Page Title="List WO" MasterPageFile="~/Site.Master" Language="vb" Async="true" AutoEventWireup="false" CodeBehind="ListWO.aspx.vb" Inherits="TCRCWebV2.ListWO" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Office/Administration/UploadWO.ascx" TagPrefix="uc1" TagName="UploadWO" %>


<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="col-md-12">
        <div class="card">
            <div class="card-header justify-content-between d-flex align-items-center bg-soft-purple">
                <h4 class="card-title text-purple">List Work Order</h4>       
            </div><!-- end card header -->
            <div class="card-body">
                <uc1:UploadWO runat="server" id="UploadWO" />
                <div class="row">
                    <div class="col-md-4">
                        <div class="mb-3">
                            <label for="tWONo">WONo</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tWONo" AutoCompleteType="Disabled"></asp:TextBox>
                        </div>                                
                    </div>
                </div>
                <div class="btn-group mt-4 mt-md-0" role="group" aria-label="Basic example">
                    <asp:LinkButton runat="server" CssClass="btn btn-soft-purple mb-3" ID="bSearch" OnClick="bSearch_Click">
                        <i class="fa fa-search"></i> Search
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-soft-purple mb-3" ID="bUpload" OnClick="bUpload_Click">
                        <i class="fa fa-upload"></i> Upload
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-soft-purple mb-3" ID="bUpdate" OnClick="bUpdate_Click">
                        <i class="fa fa-upload"></i> Update
                    </asp:LinkButton>
                </div><br />
                <asp:Label runat="server" ID="lcount" CssClass="badge badge-soft-purple"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="progress">
                            <div runat="server" id="bProg" class="progress-bar bg-purple" role="progressbar" style="width: 0%;transition: width 0.6s ease;" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">0%</div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="card-footer">
                <asp:LinkButton runat="server" CssClass="btn btn-soft-purple btn-sm mb-2" ID="bPrev" OnClick="bPrev_Click"><</asp:LinkButton>
                <asp:LinkButton runat="server" CssClass="btn btn-soft-purple btn-sm mb-2" ID="bNext" OnClick="bNext_Click">></asp:LinkButton>
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gv_wodetails" AutoGenerateColumns="false" CssClass="table table-bordered gridview" AllowPaging="True" PageSize="30">
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="bg-soft-purple text-purple">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="bWO" CssClass="btn btn-link btn-sm text-purple" CommandArgument='<%# Eval("WONo") %>'>
                                        <%# Eval("WONo") %>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="WONo" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="WONo" />
                            <asp:BoundField HeaderText="DocDate" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="DocDate" />
                            <asp:BoundField HeaderText="Section" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="Section" />
                            <asp:BoundField HeaderText="Maint Type" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="MaintType" />
                            <asp:BoundField HeaderText="Unit Number" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="UnitNumber" />
                            <asp:BoundField HeaderText="Unit Desc" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="UnitDesc" />
                            <asp:BoundField HeaderText="Wo Desc" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="WoDesc" />
                            <asp:BoundField HeaderText="Stat" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="WOStatus" />
                            <asp:BoundField HeaderText="Last Activity" HeaderStyle-CssClass="bg-soft-purple text-purple" DataField="LastActivity" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>