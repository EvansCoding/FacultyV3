using System.Web;
using System.Web.Optimization;

namespace FacultyV3.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/script/Admin").Include(
                    "~/Content/Admin/assets/js/vendor.min.js",
                    "~/Scripts/sweetalert.min.js",
                     "~/Content/Admin/assets/js/pages/sweet-alerts.init.js",
                     "~/Content/Admin/assets/libs/toastr/toastr.min.js",
                     "~/Content/Admin/assets/js/app.min.js",
                     "~/Content/jquery-3.4.1.min.js"));

            bundles.Add(new StyleBundle("~/css/Admin").Include(
                    "~/Content/Admin/assets/libs/toastr/toastr.min.css",
                      "~/Content/Admin/assets/css/bootstrap.min.css",
                      "~/Content/Admin/assets/css/app.min.css",
                      "~/Content/Admin/assets/css/icons.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                    "~/Content/Client/js/vendor/modernizr-3.6.0.min.js",
                    "~/Content/Client/js/vendor/jquery-1.12.4.min.js",
                    "~/Content/Client/js/bootstrap.min.js",
                    "~/Content/Client/js/aos.js",
                    "~/Content/Client/js/wow.min.js",
                    "~/Content/Client/js/slick.min.js",
                    "~/Content/Client/js/jquery.easing.min.js",
                    "~/Content/Client/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Client/css/bootstrap.css",
                      "~/Content/Client/css/LineIcons.css",
                      "~/Content/Client/css/animate.css",
                      "~/Content/Client/css/aos.css",
                      "~/Content/Client/css/slick.css",
                      "~/Content/Client/css/default.css",
                      "~/Content/Client/css/style.css"
                      ).Include("~/Content/Client/css/font-awesome.min.css", new CssRewriteUrlTransform()));

            BundleTable.EnableOptimizations = false;
        }
    }
}
