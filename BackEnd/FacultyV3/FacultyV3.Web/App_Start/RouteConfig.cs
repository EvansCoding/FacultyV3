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
                name: "RESOURCE",
                url: "hoc-lieu/{id}",
                defaults: new { controller = "Detail_Menu", action = "ListResource", id = UrlParameter.Optional },
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
                name: "NEWSS",
                url: "thong-tin-thong-bao/{id}",
                defaults: new { controller = "Detail_News", action = "ListNewss", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );
            routes.MapRoute(
                name: "WORK",
                url: "tuyen-dung-viec-lam/{id}",
                defaults: new { controller = "Detail_News", action = "ListWorks", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "YOUTH_GROUP",
                url: "doan-thanh-nien/{id}",
                defaults: new { controller = "Detail_News", action = "ListYouth_Group", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );
            routes.MapRoute(
                name: "NEWS_FROM_THE_MINISTRY",
                url: "tin-tu-bo-mon/{id}",
                defaults: new { controller = "Detail_News", action = "ListMinistry", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );
            routes.MapRoute(
                name: "NEWS_FROM_FACULTY",
                url: "tin-tu-khoa/{id}",
                defaults: new { controller = "Detail_News", action = "ListFaculty", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "NEWS_FROM_UNIVERSIT",
                url: "tin-tu-truong/{id}",
                defaults: new { controller = "Detail_News", action = "ListUniversity", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "DETAILNEWS",
                url: "news/{category}/{title}/{id}",
                defaults: new { controller = "Detail_News", action = "DetailNews", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
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
