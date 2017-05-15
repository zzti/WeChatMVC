﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeChatMVC
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
                name: "useAPI",
                url: "api/{action}/{studentnum}/{pwd}",
                defaults: new { controller = "api", action = "action", id = UrlParameter.Optional },
                constraints: new { studentnum = @"\d*" }
                );

            routes.MapRoute(
                name: "FileUpLoad",
                url: "fileuploada/{action}",
                defaults: new { controller = "fileupload", action = "index", id = UrlParameter.Optional }
                );
        }
    }
}
