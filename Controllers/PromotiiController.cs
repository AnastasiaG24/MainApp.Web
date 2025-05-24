using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Services;
using eUseControl.Domain.Entities.Product;
namespace MainApp.Web.Controllers
{
     public class PromotiiController : Controller
     {
          private readonly AdminOffertBL _adminOffertBL = new AdminOffertBL();

          public ActionResult Index()
          {
               var oferte = _adminOffertBL.GetAllOferts();
               return View(oferte); 
          }


          public ActionResult Details(int? id)
          {
               if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

               var oferta = _adminOffertBL.GetOfertById(id.Value);
               if (oferta == null)
                    return HttpNotFound();

               return View(oferta);
          }

     }
}
