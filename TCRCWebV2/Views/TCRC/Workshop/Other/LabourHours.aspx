<%@ Page Title="Settings Labour Hours" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="LabourHours.aspx.vb" Inherits="TCRCWebV2.LabourHours" %>
<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">List Of Labour Hours Target</h5>
                    <small class="card-title-desc">Target For All Component Rebuild Hours on TCRC</small>
                    <div class="float-end ms-2">
                        <asp:LinkButton runat="server" ID="bTest" CssClass="btn btn-soft-primary" OnClick="bTest_Click">
                            Test
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-2">
                            <div class="mb-3">
                                <label for="tWONo">Unit Descriptions</label>
                                <asp:DropDownList ID="ddlItems" runat="server" multiple></asp:DropDownList>
                                <script type="text/javascript">
                                    $(document).ready(function () {
                                        $("#<%= ddlItems.ClientID %>").select2({
                                            placeholder: "Select items",
                                            allowClear: true,
                                            closeOnSelect: false
                                        });
                                    });
                                </script>
                            </div>                                
                        </div>
                    </div>
                    <hr />
                    <div class="table-responsive">
                        <asp:GridView runat="server" ID="gv_list" CssClass="table table-bordered" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField ItemStyle-CssClass="text-primary" DataField="UnitDesc" HeaderText="Unit Descriptions" />
                                <asp:BoundField ItemStyle-CssClass="text-primary" DataField="MaintIDDesc" HeaderText="Component" />
                                <asp:BoundField DataField="Teardown" HeaderText="Teardown" />
                                <asp:BoundField DataField="Washing" HeaderText="Washing" />
                                <asp:BoundField DataField="Inspection" HeaderText="Inspection" />
                                <asp:BoundField DataField="MPI" HeaderText="MPI" />
                                <asp:BoundField DataField="Assembly" HeaderText="Assembly" />
                                <asp:BoundField DataField="Testing" HeaderText="Testing" />
                                <asp:BoundField DataField="PlaceStand" HeaderText="Place On Stand" />
                                <asp:BoundField DataField="Painted" HeaderText="Painting" />
                                <asp:BoundField DataField="Welding" HeaderText="Welding" />
                                <asp:BoundField DataField="PaintingStand" HeaderText="Painting Stand" />
                                <asp:BoundField ItemStyle-CssClass="bg-soft-primary text-center fw-bold" DataField="LabourTarget" HeaderText="Total Hours" />
                                <asp:BoundField ItemStyle-CssClass="bg-soft-success text-center fw-bold" DataField="AvgHrs" HeaderText="Actual Average Hours" />
                                <asp:BoundField DataField="RepairType" HeaderText="RepairType" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>