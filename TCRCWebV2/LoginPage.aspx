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
    <link href="~/assets/libs/sweetalert2/sweetalert2.min.css" rel="stylesheet" runat="server" />
    <script src="/assets/libs/sweetalert2/sweetalert2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="authentication-bg min-vh-100">
            <div class="bg-overlay bg-white"></div>
            <div class="container">
                <div class="d-flex flex-column min-vh-100 px-3 pt-4">
                    <div class="row justify-content-center my-auto">
                        <div class="col-md-8 col-lg-6 col-xl-4">
                            
                            <div class="text-center ">
                                <div class="mb-3 mb-md-3">
                                    <img src="~/assets/images/logo/tcrc_white.png" runat="server" class="img-responsive" height="80" />
                                </div>
                                <div class="mb-4">
                                    <h5>Welcome Back !</h5>
                                    <p>Sign in to continue to Web Applications.</p>
                                </div>
                                <form>
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

                                    <div class="mt-3">
                                        <asp:LinkButton runat="server" CssClass="btn btn-info w-100" ID="bLogin" OnClick="bLogin_Click"><span>Log In</span></asp:LinkButton>
                                    </div>

                                </form><!-- end form -->

                            </div>
                        </div><!-- end col -->
                    </div><!-- end row -->

                    <div class="row">
                        <div class="col-xl-12">
                            <div class="text-center text-muted p-4">
                                <p class="mb-0">&copy; <script>document.write(new Date().getFullYear())</script> Dashonic. Crafted with <i class="mdi mdi-heart text-danger"></i> by Plant System</p>
                            </div>
                        </div><!-- end col -->
                    </div><!-- end row -->

                </div>
            </div><!-- end container -->
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
