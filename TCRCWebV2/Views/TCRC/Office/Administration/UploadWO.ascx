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
                    <asp:FileUpload runat="server" ID="dUpload" CssClass="mb-3" />
                    <div class="progress">
                        <div id="pbar" class="progress-bar" role="progressbar" style="width: 25%;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">25%</div>
                    </div>
                </div>
            </div>
            <div class="card-footer">
                <asp:Label runat="server" ID="lerror" CssClass="badge badge-soft-warning" style="text-align:left !important"></asp:Label>
                <div class="d-flex flex-wrap gap-2">
                    <asp:Button Visible="false" runat="server" CssClass="btn btn-soft-purple" ID="bUpload" OnClick="bUpload_Click" Text="Upload" />
                    <button type="button" class="btn btn-soft-purple" id="bTest" onclick="tesUpload()">Test</button>
                    <asp:Button runat="server" CssClass="btn btn-soft-purple" ID="bClose" data-dismiss="modal" Text="Close" />

                    <script type="text/javascript">
                        function tesUpload() {
                            $.ajax({
                                type: "POST",
                                url: "ListWO.aspx/ProgressUpload",
                                data: "{}",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: "false",
                                success: function (response) {
                                    //location.reload();
                                    //console.log("IDInsp:" + inputid + ",Value:" + inputVal);
                                },
                                error: function (request, status, error) {
                                    alert(request.responseText);
                                }
                            });
                        }
                    </script>
                </div>
            </div>
        </div>
    </div>
</div>