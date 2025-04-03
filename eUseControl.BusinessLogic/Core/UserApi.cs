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
     public class UserApi : ISession, IUserOfert
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
