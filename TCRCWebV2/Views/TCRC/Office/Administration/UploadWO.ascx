<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UploadWO.ascx.vb" Inherits="TCRCWebV2.UploadWO" %>

<div id="Panel1" runat="server" class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
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
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header bg-soft-purple">
                <h5 class="modal-title text-purple" id="myExtraLargeModalLabel">Upload WO Detail</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="col-md-12">
                    <div class="form-group">
                        <p>
                            Before Uploading:<br />
                            1. Download All Data from JDE (Show All Column)<br />
                            2. Copy to Microsoft Excel Files<br />
                            3. Save File as Type: Text (Tab Delimited)(.txt)<br />
                        </p>
                    </div>
                </div>
                <div class="col-md-12 mb-3">
                    <label class="form-label" for="title">Upload Here...</label><br />
                    <asp:ScriptManager runat="server" ID="scriptmanager1"></asp:ScriptManager>
                    <asp:UpdatePanel runat="server" ID="updatepanel1" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="align-content:center; margin-left:350px; margin-top:200px">
                                <asp:FileUpload ID="uploadfiles1" runat="server" />
                                <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_Click" />
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnUpload" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                        <ProgressTemplate>
                            <div class="overlay">
                                <div style="z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">
                                    <img alt="" src="../../../../images/Spinner.gif" />
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
            </div>
            <div class="card-footer">
                <asp:Label runat="server" ID="lerror" CssClass="badge badge-soft-warning" style="text-align:left !important"></asp:Label>
                <div class="d-flex flex-wrap gap-2">
                    <asp:Button runat="server" CssClass="btn btn-soft-purple" ID="bClose" data-dismiss="modal" Text="Close" />
                </div>
            </div>
        </div>
    </div>
</div>