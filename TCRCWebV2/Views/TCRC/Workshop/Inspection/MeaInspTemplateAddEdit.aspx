<%@ Page Title="Measure Inspection Template" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="MeaInspTemplateAddEdit.aspx.vb" Inherits="TCRCWebV2.MeaInspTemplateAddEdit" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">Add / Edit Template Section</h4>
            </div>
            <div class="card-body">
                <div class="col-md-12">
                    <div class="mb-3 row">
                        <label class="col-md-2 col-form-label">Sequence</label>
                        <div class="col-md-10">
                            <asp:TextBox ID="tSeq" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <label class="col-md-2 col-form-label">Section Name</label>
                        <div class="col-md-10">
                            <asp:TextBox ID="tSectionName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card-footer">
                <div class="d-flex flex-wrap gap-2">
                    <asp:Button runat="server" CssClass="btn btn-soft-purple" ID="bSave" OnClick="bSave_Click" text="Save"/>
                    <asp:Button runat="server" CssClass="btn btn-soft-purple" ID="bClose" OnClick="bClose_Click" Text ="Close" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>