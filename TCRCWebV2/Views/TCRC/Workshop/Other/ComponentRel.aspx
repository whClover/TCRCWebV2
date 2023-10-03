<%@ Page Title="Component Release Form" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="ComponentRel.aspx.vb" Inherits="TCRCWebV2.ComponentRel" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>
<%@ Register Src="~/Views/TCRC/Workshop/Other/ComponentRelEdit.ascx" TagPrefix="uc1" TagName="ComponentRelEdit" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="col-md-12">
        <div class="card">
            <div class="card-header justify-content-between d-flex align-items-center bg-soft-primary">
                <h4 class="card-title text-primary">Component Release Form</h4>       
            </div><!-- end card header -->
            <div class="card-body">
                <div id="lalert" runat="server" class="alert alert-warning alert-dismissible fade show" role="alert">
                    <i class="uil uil-exclamation-triangle me-2"></i>
                    A simple warning alert—check it out!
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <div class="mb-3">
                            <label for="tWONo">WONo</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tWONo" AutoCompleteType="Disabled"></asp:TextBox>
                        </div>                                
                    </div>
                    <div class="col-md-2">
                        <div class="mb-3">
                            <label for="tWS">Workshop</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddWS">
                                <asp:ListItem Text="Powertrain" Value="Powertrain"></asp:ListItem>
                                <asp:ListItem Text="Engine" Value="Engine"></asp:ListItem>
                            </asp:DropDownList>
                        </div>                                
                    </div>
                    <div class="col-md-2">
                        <div class="mb-3">
                            <label for="tWS">Job Status</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddStatus">
                                <asp:ListItem Value="inprogress" Selected>Inprogress</asp:ListItem>
                                <asp:ListItem Value="complete">Complete</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="mb-3">
                            <label for="tWS">Job Package Status</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddFI">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="Empty">Empty</asp:ListItem>
                                <asp:ListItem Value="Done">Done</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="mb-3">
                            <label for="tWS">Perc Complete</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddPercComp">
                                <asp:ListItem Value="1" Selected><100%</asp:ListItem>
                                <asp:ListItem Value="2">100%</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="mb-3">
                            <label for="tWS">WO Year</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddYear">
                                <asp:ListItem Text=">2023" Value=">2023" Selected></asp:ListItem>
                                <asp:ListItem Value="<2023"><2023</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="btn-group mt-4 mt-md-0" role="group" aria-label="Basic example">
                    <asp:LinkButton runat="server" CssClass="btn btn-soft-primary" ID="bSearch" OnClick="bSearch_Click">
                        <i class="fa fa-search"></i> Search
                    </asp:LinkButton>
                </div><br />
                <asp:Label runat="server" ID="lcount" CssClass="badge badge-soft-primary"></asp:Label>
            </div>
            <div class="card-footer">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gv_comprel" AutoGenerateColumns="false" CssClass="table table-bordered gridview">
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="bg-soft-primary text-primary">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="bEdit" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' OnClick="bEdit_Click">
                                        <i class="fa fa-edit"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton OnClientClick="return confirm('Are you sure?');" runat="server" ID="bSendJP" CssClass="btn btn-soft-light btn-sm" CommandArgument='<%# Eval("WONo") %>' OnClick="bSendJP_Click">
                                        <i class="fa fa-upload"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="WONo" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="WONo" />
                            <asp:BoundField HeaderText="WoDesc" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="WODesc" />
                            <asp:BoundField HeaderText="Current Activity" HeaderStyle-CssClass="bg-soft-primary text-primary" DataField="LastActivity" />
                            <asp:BoundField HeaderText="Perc Complete" ItemStyle-CssClass="text-center" HeaderStyle-cssclass="bg-soft-primary text-primary text-center" DataField="PercComp" />
                            <asp:TemplateField HeaderText="Job Package Status" ItemStyle-CssClass="text-center" HeaderStyle-cssclass="bg-soft-primary text-primary text-center">
                                <ItemTemplate>
                                    <span class="text-primary"><%# Eval("JP") %></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <uc1:ComponentRelEdit runat="server" id="ComponentRelEdit" />
</asp:Content>