using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Product;
using eUseControl.Domain.Entities.Res;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic.Core
{
     internal class AdminApi : ISession, IAdminOfert
     {
          public void AddOfert(Ofert ofert)
          {
               // TODO add validation
               if (ofert.Name == "")
               {
                    throw new System.ArgumentException();
               }

               // add some business logic

               // add to database dar ea inca nu-i
          }

          public LevelStatus CheckLevel(string key)
          {
               throw new System.NotImplementedException();
          }

          public void DeleteOfertById(int id)
          {
               throw new System.NotImplementedException();
          }

          public List<Ofert> GetAllOferts()
          {
               throw new System.NotImplementedException();
          }

          public Ofert GetOfertById(int id)
          {
               throw new System.NotImplementedException();
          }

          public void UpdateOfert(Ofert ofert)
          {
               throw new System.NotImplementedException();
          }

          public ActionStatus UserLogin(UserLoginData data)
          {
               throw new System.NotImplementedException();
          }
     }
}
