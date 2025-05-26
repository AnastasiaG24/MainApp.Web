using System.Web.Mvc;
using eUseControl.BusinessLogic.Core;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Product;

namespace MainApp.Web.Controllers
{
     public class RezervareController : Controller
     {
          private readonly UserApi _userApi = new UserApi();
          private readonly AdminApi _adminApi = new AdminApi();

          public ActionResult Rezerveaza(int id)
          {

               if (Session["Username"] == null)
               {
                    return RedirectToAction("Login", "Login");
               }


               var oferta = _adminApi.GetOfertById(id);


               var rezervare = new RezervareOferta
               {
                    Nume = Session["Username"].ToString(),
                    Email = Session["Email"]?.ToString() ?? "",
                    Destinatie = oferta.Description,
                    NumarPersoane = 1
               };

               ViewBag.Oferta = oferta;
               return View(rezervare);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Rezerveaza(RezervareOferta rezervare)
          {
               if (Session["Username"] == null)
               {
                    return RedirectToAction("Login", "Login");
               }

               if (ModelState.IsValid)
               {
                    rezervare.Aprobat = false;
                    _adminApi.SalveazaOferta(rezervare);

                    TempData["oferta"] = rezervare.Destinatie;
                    return RedirectToAction("RezervarileMele");
               }

               ViewBag.Oferta = new Ofert { Name = rezervare.Destinatie }; // fallback pentru afișare
               return View(rezervare);
          }

          public ActionResult RezervarileMele()
          {
               var username = Session["Username"]?.ToString();
               if (string.IsNullOrEmpty(username))
               {
                    return RedirectToAction("Index", "Login");
               }

               var rezervari = _userApi.GetRezervariByUsername(username);
               return View(rezervari);
          }

          public ActionResult Confirmare()
          {
               return View();
          }

     }
}
