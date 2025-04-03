using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using System.Web.Mvc;

namespace MainApp.Web.Controllers
{
     public class ProductDetailController : Controller
     {
          private readonly IUserOfert _userOfert;

          // GET: ProductDetail
          public ProductDetailController()
          {
               BusinessLogic bussines1 = new BusinessLogic();
               _userOfert = bussines1.GetProductBL();
          }

          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          public ActionResult GetOfert(int id)
          {
               eUseControl.Domain.Entities.Product.Ofert ofert = _userOfert.GetOfertById(id);
               return View();
          }
     }

}