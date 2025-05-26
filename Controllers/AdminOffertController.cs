using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic.Services;
using eUseControl.Domain.Entities.Product;
using System.Net;
using System.Web.Mvc;

namespace MainApp.Web.Controllers
{
     public class AdminOffertController : Controller
     {
          private readonly IAdminOfert _adminOfert;
          private readonly AdminOffertBL _adminOffertBL = new AdminOffertBL();
          // GET: ProductDetail
          public AdminOffertController()
          {
               BusinessLogic bussines1 = new BusinessLogic();
               _adminOfert = bussines1.GetAdminOfertBL();
          }

          public ActionResult Index()
          {
               return View();
          }

          public ActionResult GetOfert(int id)
          {
               Ofert ofert = _adminOfert.GetOfertById(id);
               return View(ofert);
          }

          public ActionResult Details(int? id)
          {
               if (id == null)
               {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Ofert ofert = _adminOfert.GetOfertById((int)id);
               if (ofert == null)
               {
                    return HttpNotFound();
               }
               return View(ofert);
          }
          public ActionResult Create()
          {
               if (Session["Level"]?.ToString() != "Admin")
                    return RedirectToAction("Index", "Home");

               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create(Ofert ofert)
          {
               if (Session["Level"]?.ToString() != "Admin")
                    return RedirectToAction("Index", "Home");

               if (ModelState.IsValid)
               {
                    _adminOffertBL.AddOfert(ofert);
                    return RedirectToAction("Index", "Promotii");
               }

               return View(ofert);
          }

          public ActionResult Edit(int? id)
          {
               if (Session["Level"]?.ToString() != "Admin")
                    return RedirectToAction("Index", "Home");

               if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

               var oferta = _adminOffertBL.GetOfertById(id.Value);
               if (oferta == null)
                    return HttpNotFound();

               return View(oferta);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(Ofert ofert)
          {
               if (Session["Level"]?.ToString() != "Admin")
                    return RedirectToAction("Index", "Home");

               if (ModelState.IsValid)
               {
                    _adminOffertBL.UpdateOfert(ofert);
                    return RedirectToAction("Index", "Promotii");
               }

               return View(ofert);
          }

          public ActionResult Delete(int? id)
          {
               if (Session["Level"]?.ToString() != "Admin")
                    return RedirectToAction("Index", "Home");

               if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

               var oferta = _adminOffertBL.GetOfertById(id.Value);
               if (oferta == null)
                    return HttpNotFound();

               return View(oferta);
          }

          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteConfirmed(int id)
          {
               if (Session["Level"]?.ToString() != "Admin")
                    return RedirectToAction("Index", "Home");

               _adminOffertBL.DeleteOfertById(id);
               return RedirectToAction("Index", "Promotii");
          }
     }
}