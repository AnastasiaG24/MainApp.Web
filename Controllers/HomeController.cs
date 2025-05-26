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
          public ActionResult About()
          {
               return View("~/Views/About/Index.cshtml");
          }
          public ActionResult Contact()
          {
               return View("~/Views/Contact/Index.cshtml");
          }
          public ActionResult Services()
          {
               return View("~/Views/Services/Index.cshtml");
          }

          public ActionResult Blog()
          {
               return View("~/Views/Blog/Index.cshtml");
          }
          public ActionResult Promotii()
          {
               return View("~/Views/Promotii/Promotii.cshtml");
          }

          public ActionResult Aventura() { return View("~/Views/Blog/Aventura.cshtml"); }
          public ActionResult Munti() { return View("~/Views/Blog/Munti.cshtml"); }
          public ActionResult Mare() { return View("~/Views/Blog/Mare.cshtml"); }
          public ActionResult Destinatii() { return View("~/Views/Pagini/Destinatie.cshtml"); }
          public ActionResult Explorare() { return View("~/Views/Pagini/Explorare.cshtml"); }
          public ActionResult Galerie() { return View("~/Views/Pagini/Galerie.cshtml"); }
          public ActionResult Ghid() { return View("~/Views/Pagini/Ghid.cshtml"); }
          public ActionResult Recenzii() { return View("~/Views/Pagini/Recenzii.cshtml"); }
          public ActionResult Eroare() { return View("~/Views/Pagini/Eroare.cshtml"); }
          public ActionResult RezervaCalatorie() { return View("~/Views/Pagini/Rezerveaza_calatorie.cshtml"); }
     }
}