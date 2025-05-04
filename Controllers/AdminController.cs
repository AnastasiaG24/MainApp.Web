using eUseControl.BusinessLogic.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainApp.Web.Controllers
{
    public class AdminController : Controller
    {
          // GET: Admin
          public ActionResult Index()
        {
               if ((string)Session["LoginStatus"] != "login")
                    return RedirectToAction("Login", "Login");

               if ((string)Session["UserRole"] != "Admin")
                    return RedirectToAction("Unauthorized", "Login");

               var users = new UserContext().Users.ToList();
               return View(users);
          }
          public ActionResult ManageUsers()
          {
               // Logica pentru afișarea utilizatorilor
               return View();
          }

     }
}