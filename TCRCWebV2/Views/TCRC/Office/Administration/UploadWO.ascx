<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UploadWO.ascx.vb" Inherits="TCRCWebV2.UploadWO" %>

<div id="Panel1" runat="server" class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header bg-soft-purple">
                <h5 class="modal-title text-purple" id="myExtraLargeModalLabel">Upload WO Detail</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="col-md-12">
                    <div class="form-group">
                        <p>
                            Before Uploading:<br />
                            1. Download All Data from JDE (Show All Column)<br />
                            2. Copy to Microsoft Excel Files<br />
                            3. Save File as Type: Text (Tab Delimited)(*TXT)<br />
                        </p>
                    </div>
                </div>
                <div class="col-md-12 mb-3">
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