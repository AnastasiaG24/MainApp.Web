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

               var result = _session.UserLogin(data); // <-- nume clar
            Debug.WriteLine("Status autentificare: " + result.Status);
            if (result.Status)
               {

                Debug.WriteLine("Autentificare reușită!");
                Debug.WriteLine("Rol utilizator: " + result.User.Level);
                Debug.WriteLine("Sesiune UserRole: " + Session["UserRole"]);
                

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
                Debug.WriteLine("Autentificare eșuată!");
                ModelState.AddModelError("", "Nume de utilizator sau parola incorecta. Va rugam sa incercati din nou!");
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
