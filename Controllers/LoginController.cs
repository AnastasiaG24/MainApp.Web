using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;
using eUseControl.Domain.Enums;
using eUseControl.Helpers.Helpers;
using MainApp.Web.Models;
using System;
using System.Diagnostics;
using System.Web.Mvc;
using eUseControl.Helpers.Helpers;
using System.Web.Security;

public class LoginController : Controller
{
     private readonly ISession _session;

     public LoginController()
     {
          var b1 = new eUseControl.BusinessLogic.BusinessLogic();
          _session = b1.GetSessionBL();
     }

     [HttpGet]
     public ActionResult Login()
     {
          return View("~/Views/Login/Login.cshtml");
     }

     // LOGIN
     [HttpPost]
     [ValidateAntiForgeryToken]
     public ActionResult Index(UserLogin login)
     {
          if (ModelState.IsValid)
          {
               UserLoginData data = new UserLoginData
               {
                    Credential = login.Credential,
                    Password = HashHelper.GetMD5Hash(login.Password),
                    LoginIp = Request.UserHostAddress,
                    LoginDataTime = DateTime.Now
               };

               var result = _session.UserLogin(data);

               if (result.Status && result.User != null)
               {
                    Session["Username"] = result.User.Username;
                    Session["UserRole"] = result.User.Level.ToString();
                    Session["LoginStatus"] = "login";

                    if (result.User.Level == URole.Admin)
                         Session["Level"] = "Admin";
                    else
                         Session["Level"] = "User";

                    if (TempData["destinatie"] != null)
                    {
                         TempData.Keep();
                         string dest = TempData["destinatie"].ToString();
                         string nume = TempData["numeTemp"]?.ToString();
                         string email = TempData["emailTemp"]?.ToString();
                         string cerere = TempData["cerereTemp"]?.ToString();
                         int persoane = TempData["persoaneTemp"] != null ? Convert.ToInt32(TempData["persoaneTemp"]) : 2;

                         return RedirectToAction("OfertaRezervare", "Rezervare", new
                         {
                              destinatie = dest,
                              nume = nume,
                              email = email,
                              cerere = cerere,
                              persoane = persoane
                         });
                    }

                    if (result.User.Level == URole.Admin)
                         return RedirectToAction("Index", "Admin");
                    else
                         return RedirectToAction("Index", "Home");
               }
               else
               {
                    ModelState.AddModelError("", "Nume de utilizator sau parolă incorectă. Vă rugăm să încercați din nou!");
               }
          }

          return View("~/Views/Login/Login.cshtml");
     }



     [HttpGet]
     public ActionResult Register()
     {
          return View("~/Views/Login/Register.cshtml");
     }

     [HttpPost]
     [ValidateAntiForgeryToken]
     [ValidateInput(false)]
     public ActionResult Register(UserRegisterData register)
     {
          if (ModelState.IsValid)
          {
               if (register.Password != register.ConfirmPassword)
               {
                    ModelState.AddModelError("", "Parolele nu coincid.");
                    return View(register);
               }

               var userExists = _session.CheckUserExists(register.Credential, register.Email);
               if (userExists)
               {
                    ModelState.AddModelError("", "Utilizatorul sau emailul există deja.");
                    return View(register);
               }

               register.Password = HashHelper.GetMD5Hash(register.Password);
               register.ConfirmPassword = HashHelper.GetMD5Hash(register.ConfirmPassword);

               var result = _session.RegisterUser(register);

               if (result)
               {
                    if (TempData["destinatie"] != null)
                    {
                         TempData.Keep();
                    }

                    return RedirectToAction("Login", "Login");
               }

               else
               {
                    ModelState.AddModelError("", "Eroare la crearea contului. Încercați din nou.");
               }
          }

          return View("~/Views/Login/Register.cshtml");
     }
     public ActionResult Logout()
     {
          Session.Clear();
          Session.Abandon();

          return RedirectToAction("Index", "Home");
     }


}
