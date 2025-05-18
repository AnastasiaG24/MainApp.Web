using System.Web.Mvc;
using System.Web.Routing;

namespace MainApp.Web
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
                   name: "About",
                   url: "{controller}/{action}/{id}",
                   defaults: new { controller = "About", action = "Index_About", id = UrlParameter.Optional }

               );
               routes.MapRoute(
                   name: "Contact",
                   url: "{controller}/{action}/{id}",
                   defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
               );
               routes.MapRoute(
                  name: "Services",
                  url: "Services/{action}/{id}",
                  defaults: new { controller = "Servicii", action = "Index", id = UrlParameter.Optional }
              );
               routes.MapRoute(
                    name: "Promotii",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Promotii", action = "Index_Promotii", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Blog",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
                );
        }

     }
}

