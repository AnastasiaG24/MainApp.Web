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
     private string GetMD5Hash(string input)
     {
          using (var md5 = System.Security.Cryptography.MD5.Create())
          {
               var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
               var hashBytes = md5.ComputeHash(inputBytes);

               var sb = new System.Text.StringBuilder();
               foreach (var b in hashBytes)
               {
                    sb.Append(b.ToString("x2"));
               }
               return sb.ToString();
          }
     }

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
               Debug.WriteLine("A intrat în if (ModelState.IsValid)");
               Debug.WriteLine("Parola introdusă: " + login.Password);
               Debug.WriteLine("Parola MD5: " + GetMD5Hash(login.Password));
               Debug.WriteLine("Credential: " + login.Credential);

               UserLoginData data = new UserLoginData
               {
                    Credential = login.Credential,
                    Password = GetMD5Hash(login.Password),
                    LoginIp = Request.UserHostAddress,
                    LoginDataTime = DateTime.Now
               };

               var result = _session.UserLogin(data);

               if (result.Status && result.User != null)
               {
                    Debug.WriteLine("Autentificare reușită!");
                    Debug.WriteLine("Rol utilizator: " + result.User.Level);
                    Debug.WriteLine("Sesiune UserRole: " + Session["UserRole"]);

                    Session["Username"] = result.User.Username;
                    Session["UserRole"] = result.User.Level.ToString();
                    Session["LoginStatus"] = "login";

                    if (TempData["destinatie"] != null)
                    {
                         TempData.Keep(); // dacă vrei să le mai folosești în view

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

                    // 🔁 Dacă nu e vorba de rezervare, redirecționează normal
                    if (result.User.Level == URole.Admin)
                         return RedirectToAction("Index", "Admin");
                    else
                         return RedirectToAction("Index", "Home");
               }
               else
               {
                    ModelState.AddModelError("", "Nume de utilizator sau parola incorectă. Vă rugăm să încercați din nou!");
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

               register.Password = GetMD5Hash(register.Password);
               register.ConfirmPassword = GetMD5Hash(register.ConfirmPassword);

               var result = _session.RegisterUser(register); // AICI verificăm rezultatul

               // 🔽 AICI adaugi blocul pentru redirecționare dacă utilizatorul venea de la rezervare
               if (result)
               {
                    if (TempData["destinatie"] != null)
                    {
                         TempData.Keep(); // păstrează datele pentru pasul următor (login)
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

}
