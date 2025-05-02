using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;

namespace MainApp.Web.Controllers
{
          // GET: Admin
          public class AdminController : BaseController
          {
               // GET: Admin
               public ActionResult Index()
               {
                    SessionStatus(profile);
                    if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
                    {
                         return RedirectToAction("Index", "Login");
                    }

                    UDB();

                    if (main.User.Level.ToString() == "Admin")
                    {
                         main.Users = new UserContext().Users;
                    }

                    return View(main);
               }
          }
}