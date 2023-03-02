<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="TCRCWebV2._Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>BSF Plant Application Dashboard</title>

    <asp:PlaceHolder runat="server">
        <%: Styles.Render("~/Css") %>
    </asp:PlaceHolder>
</head>
<body data-layout="horizontal">
    <!-- Begin page -->
        <div id="layout-wrapper">

            <header id="page-topbar">
                <div class="navbar-header">
                    <div class="d-flex">
                        <!-- LOGO -->
                        <div class="navbar-brand-box">
                            <a href="index.html" class="logo logo-dark">
                                <span class="logo-lg">
                                    <img src="assets/images/logo/thiess.png" class="img-responsive" height="22">
                                </span>
                            </a>

                        </div>

                        <button type="button" class="btn btn-sm px-3 font-size-16 d-lg-none header-item" data-bs-toggle="collapse" data-bs-target="#topnav-menu-content">
                            <i class="fa fa-fw fa-bars"></i>
                        </button>
                    </div>
                </div>
                <div class="topnav">
                    <div class="container-fluid">
                        <nav class="navbar navbar-light navbar-expand-lg topnav-menu">
    
                            <div class="collapse navbar-collapse" id="topnav-menu-content">
                                <ul class="navbar-nav">
                                    <li class="nav-item">
                                        <a class="nav-link arrow-none" href="layouts-horizontal.html">
                                            <i class="icon nav-icon" data-feather="layout"></i>
                                            <span data-key="t-horizontal">Main Manu</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </nav>
                    </div>
                </div>
            </header>
    


            <!-- ============================================================== -->
            <!-- Start right Content here -->
            <!-- ============================================================== -->
            <div class="main-content">

                <div class="page-content">
                    <div class="container-fluid">

                        <!-- start page title -->
                        <div class="row">
                            <div class="col-12">
                                <div class="page-title-box d-flex align-items-center justify-content-between">
                                    <h4 class="mb-0">Welcome Back !</h4>

                                    <div class="page-title-right">
                                        <ol class="breadcrumb m-0">
                                            <li class="breadcrumb-item"><a href="javascript: void(0);">Main menu</a></li>
                                        </ol>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- end page title -->

                        <div class="row">
                            <div class="col-md-2">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="box">
                                            <div class="text-center">
                                                <img src="assets/images/logo/logo-tcrc.png" class="img-fluid mb-3" style="width:40%" /> <br />
                                                <a runat="server" href="~/LoginPage.aspx?id=1" type="text/html" class="mt-3">TCRC Web Applications</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>                                         
                            </div>
                            <div class="col-md-2">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="box">
                                            <div class="text-center">
                                                <img src="assets/images/illustrator/2.png" class="img-fluid mb-3" style="width:45%" /> <br />
                                                <a runat="server" href="~/LoginPage.aspx?id=2" type="text/html" class="mt-3">PER Web Applications</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>                                         
                            </div>
                            <div class="col-md-2">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="box">
                                            <div class="text-center">
                                                <img src="assets/images/illustrator/2.png" class="img-fluid mb-3" style="width:45%" /> <br />
                                                <a runat="server" href="~/LoginPage.aspx?id=3" type="text/html" class="mt-3">TMRP Web Applications</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>                                         
                            </div>
                            <div class="col-md-2">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="box">
                                            <div class="text-center">
                                                <img src="assets/images/illustrator/2.png" class="img-fluid mb-3" style="width:45%" /> <br />
                                                <a runat="server" href="~/LoginPage.aspx?id=4" type="text/html" class="mt-3">Fabshop Web Applications</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>                                         
                            </div>
                        </div>
                        
                    </div> <!-- container-fluid -->
                </div>
                <!-- End Page-content -->

                
                <footer class="footer">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-sm-6">
                                <script>document.write(new Date().getFullYear())</script> &copy; Dashonic.
                            </div>
                            <div class="col-sm-6">
                                <div class="text-sm-end d-none d-sm-block">
                                    Crafted with <i class="mdi mdi-heart text-danger"></i> by <a href="https://Pichforest.com/" target="_blank" class="text-reset">Pichforest</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </footer>
            </div>
            <!-- end main content-->

        </div>
        <!-- END layout-wrapper -->

    <asp:PlaceHolder runat="server">
        <%= Scripts.Render("~/Scripts") %>
    </asp:PlaceHolder>
</body>
</html>