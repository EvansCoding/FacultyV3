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
                     "~/Content/jquery-3.4.1.min.js"
                    ));

            bundles.Add(new StyleBundle("~/css/Admin").Include(
                    "~/Content/Admin/assets/libs/toastr/toastr.min.css",
                      "~/Content/Admin/assets/css/bootstrap.min.css",
                      "~/Content/Admin/assets/css/app.min.css")
                      .Include("~/Content/Admin/assets/css/icons.min.css"));

            bundles.Add(new ScriptBundle("~/script/client").Include(
                    "~/Content/Client/assets/js/jquery.min.js",
                    "~/Content/Client/assets/js/bootstrap.js",
                    "~/Content/Client/assets/js/waypoints.js",
                    "~/Content/Client/assets/js/jquery.counterup.js",
                    "~/Content/Client/assets/js/jquery.mixitup.js",
                    "~/Content/Client/assets/js/jquery.fancybox.pack.js",
                    "~/Content/Client/assets/js/slick.js",
                    "~/Content/Client/assets/js/custom.js"
                    ));

            bundles.Add(new StyleBundle("~/css/client").Include(
                      "~/Content/Client/assets/css/bootstrap.css",
                      "~/Content/Client/assets/css/slick.css",
                      "~/Content/Client/assets/css/jquery.fancybox.css",
                      "~/Content/Client/assets/css/theme-color/default-theme.css",
                      "~/Content/Client/assets/css/style.css"
                  ).Include("~/Content/Client/assets/css/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/css/client/swc").Include(
                    "~/Content/Client/assets/css/swc.css"
                ));
            bundles.Add(new StyleBundle("~/js/client/swc").Include(
                  "~/Content/Client/assets/js/jquery.min.js",
                  "~/Content/Client/assets/js/swc.js"
                ));

            bundles.Add(new ScriptBundle("~/script/jquery").Include(
                    "~/Content/Client/assets/js/jquery.min.js"
                ));

            bundles.Add(new StyleBundle("~/login/css").Include(
                    "~/Content/Admin/assets/css/bootstrap.min.css",
                    "~/Content/Admin/assets/css/icons.min.css",
                    "~/Content/Admin/assets/css/app.min.css"
                ));

            bundles.Add(new ScriptBundle("~/login/scripts").Include(
                    "~/Content/Admin/assets/js/vendor.min.js",
                    "~/Content/Admin/assets/js/app.min.js"
                ));
            bundles.Add(new ScriptBundle("~/script/slick").Include(
                    "~/Content/Client/assets/js/slick.js"
            ));

            BundleTable.EnableOptimizations = true;
        }
    }
}
