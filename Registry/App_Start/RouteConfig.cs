using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Registry
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Service",
                url: "Service/getDetails/{token}/{result}",
                defaults: new { controller = "Service", action = "getDetails" }
            );

            routes.MapRoute(
                name: "Search",
                url: "Search/search/{token}/{val}",
                defaults: new { controller = "Search", action = "search" }
            );

            routes.MapRoute(
                name: "AllServices",
                url: "AllServices/getAllServices/{token}",
                defaults: new { controller = "AllServices", action = "getAllServices" }
            );

            routes.MapRoute(
                name: "Unpublish",
                url: "Unpublish/unpublishData/{token}/{val}",
                defaults: new { controller = "Unpublish", action = "unpublishData" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
