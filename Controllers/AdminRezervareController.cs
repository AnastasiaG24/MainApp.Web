using eUseControl.BusinessLogic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainApp.Web.Controllers
{
     public class AdminRezervareController : Controller
     {
          private readonly AdminApi _adminApi = new AdminApi();

          public ActionResult Index()
          {
               var rezervari = _adminApi.GetAllRezervari()
                   .Where(r => !r.Aprobat && !r.Respins)
                   .ToList();

               return View(rezervari);
          }

          public ActionResult Aproba(int id)
          {
               _adminApi.AprobaRezervare(id);
               return RedirectToAction("RezervariAsteptare");
          }

          public ActionResult Respinge(int id)
          {
               _adminApi.RespingeRezervare(id);
               return RedirectToAction("RezervariAsteptare");
          }


          public ActionResult RezervariAsteptare()
          {
               var rezervari = _adminApi.GetAllRezervari().Where(r => !r.Aprobat && !r.Respins).ToList();
               return View("~/Views/Admin/RezervariAsteptare.cshtml", rezervari);
          }
     }
}