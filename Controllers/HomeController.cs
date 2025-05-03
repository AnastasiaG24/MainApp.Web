using System.Web.Mvc;

namespace MainApp.Web.Controllers
{
     public class HomeController : Controller
     {
          // GET: Home
          public ActionResult Index()
          {
               return View();
          }
     }
}