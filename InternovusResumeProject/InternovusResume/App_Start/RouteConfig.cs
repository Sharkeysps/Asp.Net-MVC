using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InternovusResume
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Resume",
              url: "Resume/{action}/{id}",
              defaults: new { controller = "Resume", action = "Resume", id = UrlParameter.Optional }
      );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Resume", action = "Resume", id = UrlParameter.Optional }
            );
        }
    }
}