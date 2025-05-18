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
    }
}
