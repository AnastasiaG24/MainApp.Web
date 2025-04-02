using System.Web.Mvc;

namespace MainApp.Web
{
     public class FilterConfig
     {
          public static void RegisterGlobalFilters(GlobalFilterCollection filters)
          {
               filters.Add(new HandleErrorAttribute());
          }
     }
}
