<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AssemblyGallery.ascx.vb" Inherits="TCRCWebV2.AssemblyGallery" %>

<div id="Panel1" runat="server" class="modal fade" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog modal-dialog-centered modal-lg">
        <div class="modal-content">
            <div class="modal-header bg-soft-primary">
                <h5 class="modal-title text-muted">Assembly Gallery</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <style>
                    .gallery {
                      display: grid;
                      grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
                      grid-auto-rows: minmax(250px, max-content);
                      grid-gap: 0;
                    }

                    .gallery img {
                      width: 100%;
                      height: 100%;
                      object-fit: cover;
                      object-position: center;
                    }
                </style>
                <asp:HiddenField runat="server" ID="hwono" />
                <div class="mb-3">
                    <h6>Assembly Section</h6>
                    <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddsection"></asp:DropDownList>
                    <asp:FileUpload runat="server" CssClass="form-control form-control-sm mb-3" id="fileupload"/>
                    <asp:LinkButton runat="server" CssClass="btn btn-soft-primary btn-sm btn-rounded" ID="bupload" OnClick="bupload_Click">
                        <i class="fa fa-upload"></i> Upload Picture
                    </asp:LinkButton>
                </div>
                <hr />
                <asp:Label CssClass="text-muted text-center" runat="server" ID="lna" Text="No Picture" Visible="false"></asp:Label>
                <asp:Repeater runat="server" ID="rpt_sec" OnItemDataBound="rpt_sec_ItemDataBound">
                    <ItemTemplate>
                        <h5 class="text-muted">Section: <%# Eval("SectionName") %></h5>
                        <div class="gallery">
                            <asp:Repeater runat="server" ID="rpt_pic">
                                <ItemTemplate>
                                    <div class="element-item">
                                        <a class="image-popup" href="../../../../images/tes/IMG_1586[1].JPG" title>
                                            <img src="../../../../images/tes/IMG_1586[1].JPG" class="img-fluid">
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>
</div>