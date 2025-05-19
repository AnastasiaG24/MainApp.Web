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
               routes.MapRoute(
                    name: "Destinatie",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Pagini", action = "Destinatie", id = UrlParameter.Optional }
                );
               routes.MapRoute(
                    name: "Explorare",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Pagini", action = "Explorare", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Galerie",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Pagini", action = "Galerie", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                   name: "Ghid",
                   url: "{controller}/{action}/{id}",
                   defaults: new { controller = "Pagini", action = "Ghid", id = UrlParameter.Optional }
               );
            routes.MapRoute(
                   name: "Recenzii",
                   url: "{controller}/{action}/{id}",
                   defaults: new { controller = "Pagini", action = "Recenzii", id = UrlParameter.Optional }
               );
        }

     }
}

