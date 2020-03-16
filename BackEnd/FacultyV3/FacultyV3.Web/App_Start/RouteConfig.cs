using System.Web.Mvc;
using System.Web.Routing;

namespace FacultyV3.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "contact",
                url: "lien-he/{id}",
                defaults: new { controller = "Contact", action = "ContactView", id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );
            routes.MapRoute(
                name: "introduceK",
                url: "gioi-thieu/gioi-thieu-khoa/{id}",
                defaults: new { controller = "Detail_Menu", action = "DetailMenu", id = "34251e7f-79d1-4fc0-9ad7-ab7900db522a" },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "group",
                url: "gioi-thieu/co-cau-to-chuc/{id}",
                defaults: new { controller = "Detail_Menu", action = "DetailMenu", id = "F83DE66C-CA9D-4E6E-B8BC-AB7900F16AC6" },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "DEPARTMENT",
                url: "gioi-thieu/to-bo-mon/{id}",
                defaults: new { controller = "Detail_Menu", action = "ListDepartment", id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "LECTURER",
                url: "gioi-thieu/can-bo-giang-vien/{id}",
                defaults: new { controller = "Lecturer", action = "LecturerView", id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "ADMISSION",
                url: "tuyen-sinh/{id}",
                defaults: new { controller = "Detail_Menu", action = "ListAdmission", id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );
            routes.MapRoute(
                name: "MENU",
                url: "home/{category}/{title}/{id}",
                defaults: new { controller = "Detail_Menu", action = "DetailMenu", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "LECTURER DETAIL",
                url: "can-bo-giang-vien/{title}/{id}",
                defaults: new { controller = "Lecturer", action = "DetailLecturer", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );
        }
    }
}
