<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MeaTemplateSecUpload.ascx.vb" Inherits="TCRCWebV2.MeaTemplateSecUpload" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="myExtraLargeModalLabel">Template Section Add / Edit</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="col-md-12">
                    <div class="form-group">
                        <h4>How To Upload Data</h4>
                        <p>
                            1. Download template Below<br />
                            2. Fill data into template<br />
                            3. Save as data to .txt file<br />
                            4. Upload .txt file into web application
                        </p>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:LinkButton runat="server" ID="bDownloadTemp" CssClass="btn btn-info">
                        Download Template
                    </asp:LinkButton>
                </div>
                <div class="divider"></div>
                <div class="col-md-12">
                    <label class="form-label" for="title">Upload Here...</label><br />
                    <asp:FileUpload runat="server" ID="dUpload" />
                </div>
            </div>
            <div class="card-footer">
                <asp:Label runat="server" ID="lerror" CssClass="badge badge-soft-warning" style="text-align:left !important"></asp:Label>
                <div class="d-flex flex-wrap gap-2">
                    <asp:Button runat="server" CssClass="btn btn-soft-purple" ID="bUpload" OnClick="bUpload_Click" Text="Upload" />
                    <asp:Button runat="server" CssClass="btn btn-soft-purple" ID="bClose" data-dismiss="modal" Text="Close" />
                </div>
            </div>
        </div>
    </div>
</div>