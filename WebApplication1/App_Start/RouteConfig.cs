using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Dashboard2",
                url: "Home/Dashboard2",
                defaults: new { controller = "Home", action = "Dashboard2" }
            );
            routes.MapRoute(
                name: "Charts",
                url: "Home/Charts",
                defaults: new { controller = "Home", action = "Charts" }
            );
            routes.MapRoute(
                name: "Calendar",
                url: "Home/Calendar",
                defaults: new { controller = "Home", action = "Calendar" }
            );
            routes.MapRoute(
                name: "Companies",
                url: "Home/Companies",
                defaults: new { controller = "Home", action = "Companies" }
            );
            routes.MapRoute(
                name: "FileManager",
                url: "Home/FileManager",
                defaults: new { controller = "Home", action = "FileManager" }
            );
            routes.MapRoute(
                name: "Tickets",
                url: "Home/Tickets",
                defaults: new { controller = "Home", action = "Tickets" }
            );
            routes.MapRoute(
                name: "TeamMembers",
                url: "Home/TeamMembers",
                defaults: new { controller = "Home", action = "TeamMembers" }
            );
        }
    }
}
