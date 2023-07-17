<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MeaInspTemplatePN.ascx.vb" Inherits="TCRCWebV2.MeaInspTemplatePN" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="myExtraLargeModalLabel">Add Part Number</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="col-md-12">
                    <asp:HiddenField runat="server" ID="IDGroup" />

                    <div class="mb-3 row">
                        <asp:HiddenField runat="server" ID="cursection" />
                        <label class="col-md-4 col-form-label">Section Name</label>
                        <div classc="col-md-8">
                            <asp:TextBox CssClass="form-control" runat="server" ID="tSection"></asp:TextBox>
                        </div>
                    </div>

                    <asp:GridView runat="server" ID="gvPN" AutoGenerateColumns="false" CssClass="table table-striped table-bordered gridview">
                        <Columns>
                            <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="IDPartList" DataField="IDPartList" />
                            <asp:BoundField HeaderText="Part Number" DataField="PartNumber" />
                        </Columns>
                    </asp:GridView>

                    
                    <script type="text/javascript">
                        $(document).ready(function () {
                            $('#<%= gvPN.ClientID %>').DataTable();
                        });
                    </script>
                </div>
            </div>
        </div>
    </div>
</div>