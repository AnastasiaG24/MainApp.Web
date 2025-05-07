using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Product;
using eUseControl.Domain.Entities.Res;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;
using eUseControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;


namespace eUseControl.BusinessLogic.Core
{
     public class UserApi : ISession, IUserOfert, IAuth
     {
          private readonly UserContext db;
          public UserApi()
          {
               db = new UserContext();
          }
          public LevelStatus CheckLevel(string key) //determinarea nivelului de acces al utilizatorului
          {
               var user = db.Users.FirstOrDefault(searchedUser => searchedUser.Username == key);
               if (user == null)
               {
                    return new LevelStatus
                    {
                         Level = URole.Guest,
                         SessionTime = DateTime.MinValue
                    };

               }
               return new LevelStatus
               {
                    Level = user.Level,
                    SessionTime = user.LastLogin
               };
          }

          public bool CheckUserExists(string credential, string email)
          {
               if (string.IsNullOrWhiteSpace(credential) || string.IsNullOrWhiteSpace(email))
                    return false;

               using (var db = new UserContext())
               {
                    var exists = db.Users.Any(u =>
                        u.Credential == credential || u.Email == email);

                    return exists;
               }
          }

          public bool RegisterUser(UserRegisterData register)
          {
               if (register.Credential == "")
               {
                    throw new ArgumentException("Numele de utilizator este obligatoriu.");
               }

               if (register.Password == "")
               {
                    throw new ArgumentException("Parola este obligatorie.");
               }

               if (register.Password.Length < 8)
               {
                    throw new ArgumentException("Parola trebuie să conțină cel puțin 8 caractere.");
               }

               if (register.Password != register.ConfirmPassword)
               {
                    throw new ArgumentException("Parolele nu coincid.");
               }

               if (register.Email == "")
               {
                    throw new ArgumentException("Emailul este obligatoriu.");
               }

               if (!register.Email.Contains("@") || !register.Email.Contains("."))
               {
                    throw new ArgumentException("Formatul emailului nu este valid.");
               }

               if (register.Country == "")
               {
                    throw new ArgumentException("Țara este obligatorie.");
               }


                    var exists = db.Users.FirstOrDefault(u =>
                        u.Credential == register.Credential || u.Email == register.Email);

                    if (exists != null)
                         throw new InvalidOperationException("Utilizatorul sau emailul există deja.");

               var cart = new Cart
               {
                    //Id = register.Id,
                    //UserId = register.UserId,

               };

               var newUser = new UserDbTable
               {
                    Credential = register.Credential,
                    Password = register.Password,
                    Email = register.Email,
                    Country = register.Country,
                    CreatedAt = DateTime.Now,
                    Username = register.Credential,
                    LastLogin = DateTime.Now
               };

               db.Users.Add(newUser);
               db.SaveChanges();
               
               return true;
          }

          public List<Ofert> GetAllOferts()
          {
               return db.Oferts.ToList();
          }

          public Ofert GetOfertById(int id)
          {
               var ofert = db.Oferts.FirstOrDefault(searchedOfert => searchedOfert.Id == id);

               if (ofert == null)
               {
                    throw new ArgumentException($"Oferta cu ID-ul {id} nu a fost găsită.");
               }
               return ofert;
          }

          public ActionStatus UserLogin(UserLoginData data)
          {
               var status = new ActionStatus();

               if (string.IsNullOrEmpty(data.Credential) || string.IsNullOrEmpty(data.Password))
               {
                    status.Status = false;
                    status.StatusMessage = "Credențialele nu pot fi goale.";
                    return status;
               }

               var user = db.Users.FirstOrDefault(u => u.Username == data.Credential || u.Email == data.Credential);

               if (user == null)
               {
                    status.Status = false;
                    status.StatusMessage = $"Utilizatorul '{data.Credential}' nu a fost găsit.";
                    return status;
               }
               if (user.Password != data.Password)
               {
                    status.Status = false;
                    status.StatusMessage = "Parola este incorectă.";
                    return status;
               }
               user.LastLogin = data.LoginDataTime;
               user.LastIp = data.LoginIp;
               status.Status = true;
               status.StatusMessage = "Autentificare cu succes.";
               status.SessionKey = user.Username;
               status.User = user;
               db.SaveChanges();
               return status;
          }

          public bool UserSessionStatus()
          {
               return true;
          }
          internal UserLoginResp UserSessionData(UserLoginData data)
          {
               UserDbTable result;

               result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password ==
               data.Password);

               if (result == null)
               {
                    return new UserLoginResp
                    {
                         Status = false,
                         StatusMessage = "The username or password is incorrect"
                    };
               }
               return new UserLoginResp { Status = true };
          }
     }
}
