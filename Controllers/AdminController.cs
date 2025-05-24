using eUseControl.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainApp.Web.Controllers
{
     public class AdminController : Controller
     {
          private readonly IAdminUser _adminUser;

          public AdminController()
          {
               var logic = new eUseControl.BusinessLogic.BusinessLogic();
               _adminUser = logic.GetAdminUserBL();
          }

          public ActionResult Index()
          {
               if ((string)Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Login", "Login");
               }

               if ((string)Session["UserRole"] != "Admin")
                    return RedirectToAction("Unauthorized", "Login");

               var users = _adminUser.GetAllUsers();
               return View(users);
          }

          public ActionResult ManageUsers()
          {
               if ((string)Session["LoginStatus"] != "login")
                    return RedirectToAction("Login", "Login");

               if ((string)Session["UserRole"] != "Admin")
                    return RedirectToAction("Unauthorized", "Login");

               var users = _adminUser.GetAllUsers();
               return View(users);
          }
     }

}