using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;
using eUseControl.Domain.Enums;
using MainApp.Web.Models;
using System;
using System.Diagnostics;
using System.Web.Mvc;

public class LoginController : Controller
{
     private readonly ISession _session;

     public LoginController()
     {
          var b1 = new eUseControl.BusinessLogic.BusinessLogic();
          _session = b1.GetSessionBL();
     }

     // Afișare pagină de login
     [HttpGet]
     public ActionResult Login()
     {
          return View("~/Views/Login/Login.cshtml");
     }

     // Procesare date login
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

               //var UserLogin = _session.UserLogin(data);

               //if (UserLogin.Status)
               //{
               //     LevelStatus status = _session.CheckLevel(UserLogin.SessionKey);
               //     return RedirectToAction("Index", "Home");
               //}
               //else
               //{
               //     ModelState.AddModelError("", "Nume de utilizator sau parola incorecta. Va rugam sa incercati din nou!");
               //}
               var result = _session.UserLogin(data); // <-- nume clar

               if (result.Status && result.User != null)
               {
                    // Setăm datele în sesiune
                    Session["Username"] = result.User.Username;
                    Session["UserRole"] = result.User.Level.ToString(); // "Admin", "User"
                    Session["LoginStatus"] = "login";

                    // Redirecționăm după rol
                    if (result.User.Level == URole.Admin)
                         return RedirectToAction("Index", "Admin");
                    else
                         return RedirectToAction("Index", "Home");
               }
               else
               {
                    ModelState.AddModelError("", "Nume de utilizator sau parola incorecta. Va rugam sa incercati din nou!");
                    // Log the error message
                    Debug.WriteLine($"Login failed for user {login.Credential}: {result.StatusMessage}");
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

               var result = _session.RegisterUser(register);
               if (result)
               {
                    return RedirectToAction("Login", "Login");
               }
               else
               {
                    ModelState.AddModelError("", "Eroare la crearea contului. Încercați din nou.");
               }
          }

          return View("~/Views/Login/Register.cshtml");
     }
}
