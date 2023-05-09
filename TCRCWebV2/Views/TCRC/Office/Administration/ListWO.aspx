<%@ Page Title="List WO" MasterPageFile="~/Site.Master" Language="vb" Async="true" AutoEventWireup="false" CodeBehind="ListWO.aspx.vb" Inherits="TCRCWebV2.ListWO" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }
    </style>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <div class="col-md-12">
        <div class="card">
            <div class="card-header justify-content-between d-flex align-items-center bg-soft-primary">
                <h4 class="card-title text-primary">Work Order Details</h4>
            </div><!-- end card header -->
            <div class="card-body">
                <div class="mt-2">
                    <ul class="nav nav-tabs nav-tabs-custom mb-4" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" data-bs-toggle="tab" href="#listdata" role="tab">List</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-bs-toggle="tab" href="#uploaddata">Upload WO</a>
                        </li>
                    </ul><!-- end ul -->
                </div>

                <!-- Tab content -->
                <div class="tab-content">
                    <div class="tab-pane active" id="listdata" role="tabpanel">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="mb-3">
                                    <label for="tWONo">WONo</label>
                                    <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="tWONo" AutoCompleteType="Disabled"></asp:TextBox>
                                </div>   
                                <div class="btn-group mt-4 mt-md-0" role="group" aria-label="Basic example">
                                    <asp:LinkButton runat="server" CssClass="btn btn-soft-primary mb-3 btn-sm" ID="bSearch" OnClick="bSearch_Click">
                                        <i class="fa fa-search"></i> Search
                                    </asp:LinkButton>
                                </div><br />
                                <asp:Label runat="server" ID="lcount" CssClass="badge badge-soft-primary"></asp:Label>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-4">
                                <div class="card">
                                    <div>
                                        <ul class="list-group list-group-flush">
                                            <li class="list-group-item">
                                                <div class="d-flex align-items-center">
                                                    <div class="flex-shrink-0 me-3">
                                                        <div class="avatar-sm">
                                                            <div class="avatar-title rounded-circle font-size-12">
                                                                <i class="fas fa-calendar"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="flex-grow-1">
                                                        <p class="text-muted mb-1">Last Upload On:</p>
                                                        <h5 class="font-size-16 mb-0" runat="server" id="pLastDate">-</h5>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="d-flex align-items-center">
                                                    <div class="flex-shrink-0 me-3">
                                                        <div class="avatar-sm">
                                                            <div class="avatar-title rounded-circle font-size-12">
                                                                <i class="fas fa-user"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="flex-grow-1">
                                                        <p class="text-muted mb-1">Last Upload By:</p>
                                                        <h5 class="font-size-16 mb-0" runat="server" id="pLastBy">-</h5>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <hr />
                        <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm mb-2" ID="bPrev" OnClick="bPrev_Click"><</asp:LinkButton>
                        <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm mb-2" ID="bNext" OnClick="bNext_Click">></asp:LinkButton>
                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="gv_wodetails" AutoGenerateColumns="false" CssClass="table table-bordered gridview" AllowPaging="True" PageSize="30">
                                <Columns>
                                    <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="bg-soft-primary text-primary">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="bWO" CssClass="btn btn-link btn-sm text-primary" CommandArgument='<%# Eval("WONo") %>'>
                                                <%# Eval("WONo") %>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="WONo" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="WONo" />
                                    <asp:BoundField HeaderText="DocDate" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="DocDate" />
                                    <asp:BoundField HeaderText="Section" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="Section" />
                                    <asp:BoundField HeaderText="Maint Type" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="MaintType" />
                                    <asp:BoundField HeaderText="Unit Number" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="UnitNumber" />
                                    <asp:BoundField HeaderText="Unit Desc" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="UnitDesc" />
                                    <asp:BoundField HeaderText="Wo Desc" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="WoDesc" />
                                    <asp:BoundField HeaderText="Stat" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="WOStatus" />
                                    <asp:BoundField HeaderText="Last Activity" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="LastActivity" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="tab-pane" id="uploaddata" role="tabpanel">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel runat="server" ID="updatepanel1" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="mb-3">
                                            <h6>Upload Data</h6>
                                            <asp:FileUpload runat="server" ID="uploadfiles1" CssClass="form-control form-control-sm" />
                                        </div>
                                        <asp:LinkButton runat="server" id="btnUpload" CssClass="btn btn-soft-primary btn-sm" OnClick="btnUpload_Click" OnClientClick="showProgress()">
                                            <i class="fa fa-upload"></i> Upload Data
                                        </asp:LinkButton><br />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnUpload" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                                    <ProgressTemplate>
                                        <div class="text-center">
                                            <img alt="" src="../../../../images/Spinner2.gif" />
                                            <h6 class="text-muted">Uploading Data, Please Wait !</h6>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>                 
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>