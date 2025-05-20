using System;
using System.Web.Mvc;
using eUseControl.Domain.Entities;
using eUseControl.BusinessLogic.Interfaces;

namespace MainApp.Web.Controllers
{
     public class RezervareController : Controller
     {
          private readonly IRezervare _rezervareBL;

          public RezervareController()
          {
               var logic = new eUseControl.BusinessLogic.BusinessLogic();
               _rezervareBL = logic.GetRezervareBL();
          }

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
                    _rezervareBL.SalveazaRezervare(rezervare);
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

          private decimal GetPret(string destinatie)
          {
               switch (destinatie?.ToLower())
               {
                    case "venetia": return 349.00m;
                    case "montblanc": return 479.00m;
                    case "kyoto": return 549.00m;
                    case "thailanda": return 649.00m;
                    default: return 0m;
               }
          }

          private int GetZile(string destinatie)
          {
               switch (destinatie?.ToLower())
               {
                    case "venetia": return 3;
                    case "montblanc": return 4;
                    case "kyoto": return 3;
                    case "thailanda": return 2;
                    default: return 0;
               }
          }

          [HttpPost]
          public ActionResult OfertaRezervare(string destinatie, string nume, string email, string cerere, int persoane)
          {
               if (Session["Username"] == null)
               {
                    TempData["destinatie"] = destinatie;
                    TempData["numeTemp"] = nume;
                    TempData["emailTemp"] = email;
                    TempData["cerereTemp"] = cerere;
                    TempData["persoaneTemp"] = persoane;

                    return RedirectToAction("Register", "Login");
               }

               var rezervare = new RezervareOferta
               {
                    Nume = nume,
                    Email = email,
                    CereriSpeciale = cerere,
                    NrPersoane = persoane,
                    Destinatie = destinatie,
                    Pret = GetPret(destinatie),
                    Zile = GetZile(destinatie),
                    DataRezervare = DateTime.Now
               };

               _rezervareBL.SalveazaOferta(rezervare);

               TempData["nume"] = nume;
               TempData["destinatie"] = destinatie;

               return RedirectToAction("Confirmare");
          }
     }
}
