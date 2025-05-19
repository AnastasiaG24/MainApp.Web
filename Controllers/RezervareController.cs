using System;
using System.Web.Mvc;
using eUseControl.Domain.Entities;         // pentru modelul Rezervare
using eUseControl.BusinessLogic.DBModel;  // pentru UserContext

namespace MainApp.Web.Controllers
{
    public class RezervareController : Controller
    {
        private readonly UserContext db = new UserContext();

        // GET: /Rezervare
        public ActionResult Index()
        {
            return View();
        }

        // POST: /Rezervare
        [HttpPost]
        public ActionResult Index(Rezervare rezervare)
        {
            if (ModelState.IsValid)
            {
                db.Rezervari.Add(rezervare);
                db.SaveChanges();
                return RedirectToAction("Confirmare");
            }

            return View(rezervare);
        }

        public ActionResult Confirmare()
        {
            return View();
        }


        public ActionResult OfertaRezervare(string destinatie)
        {
            ViewBag.Destinatie = destinatie;

            switch (destinatie?.ToLower())
            {
                case "venetia":
                    ViewBag.Titlu = "Veneția - Italia";
                    ViewBag.Pret = "$349.00";
                    ViewBag.Zile = "3 zile";
                    break;
                case "montblanc":
                    ViewBag.Titlu = "Mont Blanc - Franța";
                    ViewBag.Pret = "$479.00";
                    ViewBag.Zile = "4 zile";
                    break;
                case "kyoto":
                    ViewBag.Titlu = "Kyoto - Japonia";
                    ViewBag.Pret = "$549.00";
                    ViewBag.Zile = "3 zile";
                    break;
                case "thailanda":
                    ViewBag.Titlu = "Thailanda";
                    ViewBag.Pret = "$649.00";
                    ViewBag.Zile = "2 zile";
                    break;
                default:
                    return HttpNotFound("Oferta nu există.");
            }

            return View();
        }

    }
}
