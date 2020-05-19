using System.Web.Mvc;
using System.Web.Routing;

namespace FacultyV3.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            RouteTable.Routes.LowercaseUrls = true;
            RouteTable.Routes.AppendTrailingSlash = true;

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
                name: "scientific regulations ",
                url: "nghien-cuu-khoa-hoc/quy-dinh-khoa-hoc/{id}",
                defaults: new { controller = "Detail_Menu", action = "DetailMenu", id = "aa2f7477-227b-4147-815b-ab7a006f8205" },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "general information",
                url: "nghien-cuu-khoa-hoc/bieu-mau-khoa-hoc/{id}",
                defaults: new { controller = "Detail_Menu", action = "DetailMenu", id = "df6f8012-7463-452c-a058-ab7a006eb9e4" },
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

            //routes.MapRoute(
            //    name: "group",
            //    url: "sinh-vien/doan-thanh-nien/{id}",
            //    defaults: new { controller = "Detail_Menu", action = "DetailMenu", id = "F83DE66C-CA9D-4E6E-B8BC-AB7900F16AC6" },
            //    namespaces: new[] { "FacultyV3.Web.Controllers" }
            //);

            routes.MapRoute(
                name: "doan-thanh-nien",
                url: "sinh-vien/doan-thanh-nien/{id}",
                defaults: new { controller = "Detail_Menu", action = "DetailMenu", id = "F4720E44-9366-49DD-82BD-ABBF010B367D" },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "so-tay-sinh-vien",
                url: "sinh-vien/so-tay-sinh-vien/{id}",
                defaults: new { controller = "Detail_Menu", action = "DetailMenu", id = "FC1E3B28-1012-4BE7-90B3-ABBF0109AC69" },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "CONFERENCE",
                url: "hoi-nghi-khoa-hoc",
                defaults: new { controller = "Detail_Menu", action = "ListConference" },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "FORM",
                url: "sinh-vien/bieu-mau",
                defaults: new { controller = "Detail_Menu", action = "ListForm" },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );
            routes.MapRoute(
                name: "OLD STUDENT",
                url: "sinh-vien/cuu-sinh-vien",
                defaults: new { controller = "Student", action = "StudentView" },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );
            routes.MapRoute(
                name: "MENU",
                url: "home/{category}/{title}/{id}",
                defaults: new { controller = "Detail_Menu", action = "DetailMenu", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "New News",
                url: "tin-moi-nhat/{title}/{id}",
                defaults: new { controller = "Detail_News", action = "DetailNews", title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "LECTURER DETAIL",
                url: "can-bo-giang-vien/{title}/{code}",
                defaults: new { controller = "Lecturer", action = "DetailLecturer", title = UrlParameter.Optional, code = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "NEWSS",
                url: "thong-tin-thong-bao/",
                defaults: new { controller = "Detail_News", action = "ListNewss" },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );
            routes.MapRoute(
                name: "WORK",
                url: "tuyen-dung-viec-lam",
                defaults: new { controller = "Detail_News", action = "ListWorks" },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "YOUTH_GROUP",
                url: "doan-thanh-nien",
                defaults: new { controller = "Detail_News", action = "ListYouth_Group" },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );
            routes.MapRoute(
                name: "NEWS_FROM_THE_MINISTRY",
                url: "tin-tuc-chuyen-nganh",
                defaults: new { controller = "Detail_News", action = "ListMinistry" },
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
                name: "NEWS_FROM_PARTY_CELL",
                url: "tin-tu-chi-bo/{id}",
                defaults: new { controller = "Detail_News", action = "ListPartyCell", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "NEWS_FROM_UNION",
                url: "tin-tu-cong-doan/{id}",
                defaults: new { controller = "Detail_News", action = "ListUnion", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Education Program",
                url: "dao-tao/chuong-trinh-dao-tao/{id}",
                defaults: new { controller = "Detail_Menu", action = "ListEducation_Program", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "FacultyV3.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Trainning Sector",
                url: "dao-tao/nganh-dao-tao/{id}",
                defaults: new { controller = "Detail_Menu", action = "ListTraining_Sector", category = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
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
