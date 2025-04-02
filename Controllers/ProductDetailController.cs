using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using System.Web.Mvc;

namespace MainApp.Web.Controllers
{
     public class ProductDetailController : Controller
     {
          private IUserOfert _product;

          // GET: ProductDetail
          public ProductDetailController()
          {
               BusinessLogic bussines1 = new BusinessLogic();
               _product = bussines1.GetProductBL();
          }

          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          public ActionResult GetProduct(int id)
          {
               ProductDetail prodDetail = _product.GetDetailProduct(id);
               return View();
          }
     }

}