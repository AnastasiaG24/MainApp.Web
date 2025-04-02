using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Product;
using eUseControl.Domain.Entities.Res;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;
using System;
using System.Collections.Generic;
using System.Linq;


namespace eUseControl.BusinessLogic.Core
{
     public class UserApi : ISession, IUserOfert
     {
          public LevelStatus CheckLevel(string key)
          {
               throw new NotImplementedException();
          }

          public List<Ofert> GetAllOferts()
          {
               throw new NotImplementedException();
          }

          public Ofert GetOfertById(int id)
          {
               throw new NotImplementedException();
          }

          public ActionStatus UserLogin(UserLoginData data)
          {
               throw new NotImplementedException();
          }

          public bool UserSessionStatus()
          {
               return true;
          }
          internal UserLoginResp UserSessionData(UserLoginData data)
          {
               UserDbTable result;
               using (var db = new UserContext())
               {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password ==
                    data.Password);
               }
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
