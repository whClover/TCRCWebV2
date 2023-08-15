Imports System.Web.Optimization

Public Class BundleConfig
    Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New StyleBundle("~/Css").Include(
            "~/assets/css/bootstrap.min.css",
            "~/assets/css/icons.min.css",
            "~/assets/css/app.min.css",
            "~/assets/costume/css/mycss.css",
            "~/assets/libs/choices.js/public/assets/styles/choices.min.css",
            "~/assets/libs/flatpickr/flatpickr.min.css",
            "~/assets/costume/alertify/css/alertify.min.css",
            "~/assets/costume/toast/toastr.min.css",
            "~/assets/costume/summernote/summernote-bs4.min.css",
            "~/assets/libs/sweetalert2/sweetalert2.min.css"
        ))

        bundles.Add(New ScriptBundle("~/Scripts").Include(
            "~/assets/libs/bootstrap/js/bootstrap.bundle.min.js",
            "~/assets/costume/js/jquery-3.5.1.min.js",
            "~/assets/costume/js/jquery-ui.min.js",
            "~/assets/libs/metismenujs/metismenujs.min.js",
            "~/assets/libs/simplebar/simplebar.min.js",
            "~/assets/libs/feather-icons/feather.min.js",
            "~/assets/js/app.js",
            "~/assets/libs/flatpickr/flatpickr.min.js",
            "~/assets/costume/multiselect/chosen.jquery.min.js",
            "~/assets/libs/choices.js/public/assets/scripts/choices.min.js",
            "~/assets/js/pages/form-advanced.init.js",
            "~/assets/costume/js/marquee.js",
            "~/assets/costume/js/myjs.js",
            "~/assets/costume/alertify/alertify.min.js"
        ))

        bundles.Add(New ScriptBundle("~/buatmodal").Include(
            "~/assets/costume/js/jquery-3.5.1.min.js",
            "~/assets/costume/js/bootstrap4.5.0.js",
            "~/assets/costume/alertify/alertify.min.js",
            "~/assets/costume/alertify/alertify.js",
            "~/assets/costume/toast/toastr.min.js"
        ))

        bundles.Add(New ScriptBundle("~/summernote").Include(
            "~/assets/costume/js/jquery-3.5.1.min.js",
            "~/assets/costume/summernote/popper.min.js",
            "~/assets/costume/js/bootstrap4.5.0.js",
            "~/assets/costume/summernote/summernote-bs4.min.js"
        ))
    End Sub
End Class
