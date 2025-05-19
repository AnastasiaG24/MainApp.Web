using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainApp.Web.Controllers
{
    public class PaginiController : Controller
    {
        // GET: Pagini
        public ActionResult Destinatie()
        {
            return View();
        }
          public ActionResult Explorare()
          {
               return View();
          }
        public ActionResult Galerie()
        {
            return View();
        }
    }
}