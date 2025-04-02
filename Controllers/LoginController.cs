using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;
using MainApp.Web.Models;
using System;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
     public class LoginController : Controller
     {
          private readonly ISession _session;

          public LoginController()
          {
               var b1 = new eUseControl.BusinessLogic.BusinessLogic();
               _session = b1.GetSessionBL();
          }

          // GET: Login
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(UserLogin login)
          {
               if (ModelState.IsValid)
               {
                    UserLoginData data = new UserLoginData
                    {
                         Credential = login.Credential,
                         Password = login.Password,
                         LoginIp = Request.UserHostAddress,
                         LoginDataTime = DateTime.Now
                    };

                    var UserLogin = _session.UserLogin(data);

                    if (UserLogin.Status)
                    {
                         LevelStatus status = _session.CheckLevel(UserLogin.SessionKey);
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("Nume de utilizator sau parola incorecta. Va rugam sa incercati din nou!", UserLogin.StatusMessage);
                    }
               }

               return View();
          }
     }
}