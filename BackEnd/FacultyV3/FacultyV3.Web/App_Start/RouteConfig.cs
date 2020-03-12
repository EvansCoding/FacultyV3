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
                name: "introduce",
                url: "gioi-thieu-khoa/{id}",
                defaults: new { controller = "Contact", action = "ContactView", id = UrlParameter.Optional },
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
