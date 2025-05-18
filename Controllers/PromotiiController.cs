using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainApp.Web.Controllers
{
    public class PromotiiController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index_Promotii");
        }

        public ActionResult Index_Promotii()
        {
            return View();
        }
    }
}