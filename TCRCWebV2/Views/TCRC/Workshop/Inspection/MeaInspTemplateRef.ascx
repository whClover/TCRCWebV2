<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MeaInspTemplateRef.ascx.vb" Inherits="TCRCWebV2.MeaInspTemplateRef" %>

<div id="panel1" runat="server" class="modal fade" tabindex="-1"
    aria-labelledby="exampleModalFullscreenLabel" aria-hidden="true">
    <div class="modal-dialog modal-fullscreen">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalFullscreenLabel">Add Reference / Spesifications</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <asp:HiddenField runat="server" ID="hAction" />
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-floating mb-3">                                                       
                            <asp:TextBox ID="tSec" runat="server" CssClass="form-control" placeholder="Section Name" AutoCompleteType="disabled" ReadOnly="true"></asp:TextBox>
                            <label for="input-username">Section Name</label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-floating mb-3">
                            <asp:HiddenField runat="server" ID="tcurSubSec" />
                            <asp:TextBox ID="tSubSec" runat="server" CssClass="form-control" placeholder="Sub-Section Name" AutoCompleteType="disabled"></asp:TextBox>
                            <label for="input-username">Sub-Section Name</label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-floating mb-3">                                                       
                            <asp:TextBox ID="tSeq" runat="server" CssClass="form-control" placeholder="Sequence" AutoCompleteType="disabled"></asp:TextBox>
                            <label for="input-username">Sub-Section Sequence</label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">                        
                        <textarea runat="server" id="summernote" name="editordata"></textarea>
                        <script>
                            $('#MainContent_MeaInspTemplateRef_summernote').summernote({
                                toolbar: [
                                    ['font', ['bold', 'underline', 'clear']],
                                    ['color', ['color']],
                                    ['table', ['table']],
                                    ['para', ['ul', 'ol', 'paragraph']],
                                ],
                                height: 500
                            });
                        </script>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" CssClass="btn btn-soft-purple" ID="bSave" OnClick="bSave_Click" Text="Save" /> 
                <button type="button" class="btn btn-soft-purple" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>