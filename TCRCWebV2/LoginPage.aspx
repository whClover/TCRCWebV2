<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginPage.aspx.vb" Inherits="TCRCWebV2.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login Page</title>

    <asp:PlaceHolder runat="server">
        <%: Styles.Render("~/Css") %>
    </asp:PlaceHolder>
</head>
<body>
    <form id="form1" runat="server">
        <div class="authentication-bg min-vh-100">
            <div class="bg-overlay bg-white"></div>
            <div class="container">
                <div class="d-flex flex-column min-vh-100 px-3 pt-4">
                    <div class="row justify-content-center my-auto">
                        <div class="col-lg-10">
                            <div class="py-5">
                                <div class="card auth-cover-card overflow-hidden">
                                    <div class="row g-0">
                                        <div class="col-lg-6">
                                            <div class="auth-img"></div>                                            
                                        </div><!-- end col -->
                                        <div class="col-lg-6">
                                            <div class="p-4 p-lg-5 bg-primary h-100 d-flex align-items-center justify-content-center">
                                                <div class="w-100">
                                                    <div class="mb-4 mb-md-5">
                                                        <a href="index.html" class="d-block auth-logo">
                                                            <img src="assets/images/logo-light.png" alt="" />
                                                        </a>
                                                    </div>
                                                    <div class="text-white-50 mb-4">
                                                        <h5 class="text-white">Sign In</h5>
                                                    </div>
                                                    <div class="form-floating form-floating-custom mb-3">                                                       
                                                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" Text="TCRC" ID="webapp"></asp:TextBox>
                                                        <label for="input-username">Web Application</label>
                                                        <div class="form-floating-icon">
                                                            <i class="fa fa-globe"></i>
                                                        </div>
                                                    </div>
                                                    <div class="form-floating form-floating-custom mb-3">
                                                        <asp:TextBox runat="server" CssClass="form-control" placeholder="Enter Username/JDE" ID="tjdeuser" AutoCompleteType="Disabled"></asp:TextBox>
                                                        <label for="input-username">Username / JDE Numbers</label>
                                                        <div class="form-floating-icon">
                                                            <i class="fa fa-user"></i>
                                                        </div>
                                                    </div>
                                                    <div class="form-floating form-floating-custom mb-3">
                                                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter Password" ID="tpass"></asp:TextBox>
                                                        <label for="input-password">Password</label>
                                                        <div class="form-floating-icon">
                                                            <i class="fa fa-lock"></i>
                                                        </div>
                                                    </div>
                                                    <div class="alert alert-danger" role="alert" id="eNotif" runat="server" style="display:none;">
                                                        <p runat="server" id="eTxtNofif"></p>
                                                    </div>
                                                    <div class="mt-3">
                                                        <asp:LinkButton runat="server" CssClass="btn btn-info w-100" ID="bLogin" OnClick="bLogin_Click">Log In</asp:LinkButton>
                                                    </div>
                                                    <div class="mt-4 text-center">
                                                        <a href="~/" runat="server" class="text-white-50 text-decoration-underline">Back To Main Menu</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div><!-- end col -->
                                    </div><!-- end row -->
                                </div><!-- end card -->
                            </div>
                        </div><!-- end col -->
                    </div><!-- end row -->

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="text-center text-muted p-4">
                                <p class="mb-0">&copy; <script>document.write(new Date().getFullYear())</script> Dashonic. Crafted with <i class="mdi mdi-heart text-danger"></i> by Pichforest</p>
                            </div>
                        </div><!-- end col -->
                    </div><!-- end row -->
                </div>
            </div>
            <!-- end container -->
        </div>
        <!-- end authentication section -->
    </form>
    <asp:PlaceHolder runat="server">
        <%= Scripts.Render("~/Scripts") %>
    </asp:PlaceHolder>

    <script type="text/javascript">
        document.onkeypress = function (event) {
            event = (event || window.event);
            if (event.keyCode == 13) {
                document.getElementById("<%= bLogin.ClientID %>").click();
            }
        }
    </script>
</body>
</html>
