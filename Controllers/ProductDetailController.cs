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

        public ActionResult Oferta(string destinatie)
        {
            ViewBag.Destinatie = destinatie;
            switch (destinatie?.ToLower())
            {
                case "venetia":
                    ViewBag.Titlu = "Veneția - Italia";
                    ViewBag.Descriere = "Descoperă farmecul romantic al Veneției!";
                    ViewBag.Pret = "$349.00";
                    ViewBag.Zile = 3;
                    break;
                case "montblanc":
                    ViewBag.Titlu = "Mont Blanc - Franța";
                    ViewBag.Descriere = "O aventură alpină de neuitat!";
                    ViewBag.Pret = "$479.00";
                    ViewBag.Zile = 4;
                    break;
                case "kyoto":
                    ViewBag.Titlu = "Kyoto - Japonia";
                    ViewBag.Descriere = "Explorați templele și grădinile japoneze!";
                    ViewBag.Pret = "$549.00";
                    ViewBag.Zile = 3;
                    break;
                case "thailanda":
                    ViewBag.Titlu = "Thailanda";
                    ViewBag.Descriere = "Plaje tropicale și gastronomie exotică!";
                    ViewBag.Pret = "$649.00";
                    ViewBag.Zile = 2;
                    break;
                default:
                    return HttpNotFound("Destinația nu a fost găsită.");
            }

            return View();
        }
    }

}