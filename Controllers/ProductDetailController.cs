using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainApp.Web.Controllers
{
    public class ProductDetailController : Controller
    {
        private IProduct _product;

        // GET: ProductDetail
        public ProductDetailController()
        {
            BussinesLogic bussines1 = new BussinesLogic();
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