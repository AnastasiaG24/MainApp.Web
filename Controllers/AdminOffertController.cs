using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Product;
using System.Net;
using System.Web.Mvc;

namespace MainApp.Web.Controllers
{
     public class AdminOffertController : Controller
     {
          private readonly IAdminOfert _adminOfert;

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
     }
     //TODO: Add CRUD methods, create, delete, update, read 
}